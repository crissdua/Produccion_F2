Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing.Text
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports System.Web.UI.WebControls
Public Class FrmP
#Region "Variables"
    Public con As New Conexion
    Dim oCompany As SAPbobsCOM.Company
    Dim connectionString As String = Conexion.ObtenerConexion.ConnectionString
    Public Shared SQL_Conexion As SqlConnection = New SqlConnection()
    Dim reader As StreamReader
    Dim entra As String
    Dim sale As String
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
#End Region
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Public Sub New(ByVal user As String)
        MyBase.New()
        InitializeComponent()
        '  Note which form has called this one
        ToolStripStatusLabel1.Text = user
    End Sub

    Public Function CargaGridLecturaBC()
        Dim query1 As String
        query1 = ""
        Dim query2 As String
        query2 = ""
        Try
            reader = File.OpenText(System.Windows.Forms.Application.StartupPath + "\" + txtOrder.Text + ".txt")
            entra = System.Windows.Forms.Application.StartupPath + "\" + txtOrder.Text + ".txt"
            Dim line As String = Nothing

            Dim lines As Integer = 0
            While (reader.Peek() <> -1)
                line = reader.ReadLine()
                Dim rnum As Integer = DGV.Rows.Add()
                DGV.Rows.Item(rnum).Cells(0).Value = line.ToString
                System.Windows.Forms.Application.DoEvents()
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("El Picking del numero de orden no existe")
        End Try


    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DGV.Rows.Clear()
        CargaGridLecturaBC()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As Integer = MessageBox.Show("Desea limpiar el objeto?", "Atencion", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            MessageBox.Show("Cancelado")
        ElseIf result = DialogResult.No Then
            MessageBox.Show("Puede continuar!")
        ElseIf result = DialogResult.Yes Then
            DGV.Rows.Clear()
            MessageBox.Show("Inicie un objeto nuevo")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As Integer = MessageBox.Show("Desea salir del modulo?", "Atencion", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Puede continuar")
        ElseIf result = DialogResult.Yes Then
            MessageBox.Show("Finalizando modulo")
            Try
                con.oCompany.Disconnect()
            Catch
            End Try
            Application.Exit()
            Me.Close()
        End If
    End Sub


    Private Function transferencia()
        Dim i As Integer = 0
        Dim oReturn As Integer = -1
        Dim oError As Integer = 0
        Dim errMsg As String = ""
        Dim sql As String
        Dim items As String
        Dim oRecordSet As SAPbobsCOM.Recordset

        Try
            If con.Connected = True Then
                Dim transfer As SAPbobsCOM.StockTransfer = con.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oStockTransfer)




                While i < (DGV.Rows.Count)
                    sql = ("WITH batchs AS
                            (
                            SELECT T0.ItemCode, SUM(CASE T0.Direction when 0 then 1 else -1 end * T0.Quantity) as Quantitys, T0.BatchNum , T1.U_Heat,t1.U_Coi,t1.U_Ancho,t1.U_Correlativo
                            FROM IBT1 T0 inner join obtn T1 on T0.BatchNum = t1.DistNumber
                            GROUP BY T0.BatchNum, T0.ItemCode, T1.U_Heat,t1.U_Coi,t1.U_Ancho,t1.U_Correlativo)
                            SELECT ItemCode, Quantitys, BatchNum, U_Heat, U_Coi,U_Ancho,U_Correlativo from batchs where Quantitys > 0 and BatchNum = '" + DGV.Rows(i).Cells(0).Value.ToString + "'")
                    oRecordSet = con.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
                    oRecordSet.DoQuery(sql)
                    If oRecordSet.RecordCount > 0 Then
                        transfer.Lines.SetCurrentLine(i)
                        transfer.Lines.ItemCode = oRecordSet.Fields.Item(0).Value
                        transfer.Lines.Quantity = oRecordSet.Fields.Item(1).Value
                        transfer.Lines.BatchNumbers.BatchNumber = oRecordSet.Fields.Item(2).Value
                        transfer.Lines.BatchNumbers.Quantity = oRecordSet.Fields.Item(1).Value
                        transfer.Lines.BatchNumbers.AddmisionDate = Now.ToShortDateString
                        transfer.Lines.BatchNumbers.UserFields.Fields.Item("U_Heat").Value = oRecordSet.Fields.Item(3).Value
                        transfer.Lines.BatchNumbers.UserFields.Fields.Item("U_Coi").Value = oRecordSet.Fields.Item(4).Value
                        transfer.Lines.BatchNumbers.UserFields.Fields.Item("U_Ancho").Value = oRecordSet.Fields.Item(5).Value
                        transfer.Lines.BatchNumbers.UserFields.Fields.Item("U_Correlativo").Value = oRecordSet.Fields.Item(6).Value
                        transfer.Lines.BatchNumbers.Add()
                        transfer.Lines.Add()
                        items += oRecordSet.Fields.Item(2).Value & "|"
                    End If
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
                    oRecordSet = Nothing
                    GC.Collect()
                    i = i + 1

                End While
                transfer.FromWarehouse = "PT"
                transfer.ToWarehouse = "BMP2"
                transfer.DocDate = Now.ToShortDateString
                transfer.Comments = "Lotes Transferidos: " & items.TrimEnd("|") & " De Orden: " & txtOrder.Text
                oReturn = transfer.Add()
                If oReturn <> 0 Then
                    con.oCompany.GetLastError(oError, errMsg)
                    reader.Close()
                    MsgBox("Error en los Items: " & items & "Error Referente a: " & errMsg)
                    My.Computer.FileSystem.WriteAllText(System.Windows.Forms.Application.StartupPath + "\Log\LogErroresTransferencia.txt", DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss") & "Error en los Items: " & items & "Error Referente a: " & errMsg & vbCrLf, True)
                    sale = System.Windows.Forms.Application.StartupPath + "\Temp\" + txtOrder.Text + "-ERROR-" & DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") & ".txt"
                    File.Move(entra, sale)
                Else
                    MessageBox.Show("Transferencia Realizada con Exito")
                    sale = System.Windows.Forms.Application.StartupPath + "\Temp\" + txtOrder.Text + "-TransFerido" & DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") & ".txt"
                    File.Move(entra, sale)
                    txtOrder.Clear()
                    DGV.Rows.Clear()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Verifique que El archivo Existe en la carpeta Raiz")
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim result As Integer = MessageBox.Show("Desea realizar la TransFerencia?", "Atencion", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                MessageBox.Show("Cancelado")
            ElseIf result = DialogResult.No Then
                MessageBox.Show("No se realizara la TransFerencia")
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                If con.Connected Then
                    transferencia()
                Else
                    con.MakeConnectionSAP()
                    If con.Connected Then
                        transferencia()
                    Else
                        MessageBox.Show("Error de Conexion, intente Nuevamente")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error: " + ex.Message.ToString)
        End Try
    End Sub

    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode.Equals(Keys.Enter) Then
            Button1_Click(1, e)
        End If
    End Sub

    Private Sub txtOrder_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrder.KeyDown
        Call EnterClick(sender, e)
    End Sub

End Class
