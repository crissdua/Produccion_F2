<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmP
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.BarCodes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtOrder = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(195, 258)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 23)
        Me.Button3.TabIndex = 71
        Me.Button3.Text = "Salir"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(100, 258)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 23)
        Me.Button2.TabIndex = 70
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(59, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "Entradas"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BarCodes})
        Me.DGV.Location = New System.Drawing.Point(62, 56)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(165, 196)
        Me.DGV.TabIndex = 66
        '
        'BarCodes
        '
        Me.BarCodes.HeaderText = "BarCodes"
        Me.BarCodes.Name = "BarCodes"
        Me.BarCodes.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 302)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(292, 22)
        Me.StatusStrip1.TabIndex = 65
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'txtOrder
        '
        Me.txtOrder.Location = New System.Drawing.Point(62, 30)
        Me.txtOrder.Name = "txtOrder"
        Me.txtOrder.Size = New System.Drawing.Size(100, 20)
        Me.txtOrder.TabIndex = 72
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(5, 258)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(89, 23)
        Me.Button4.TabIndex = 73
        Me.Button4.Text = "Aceptar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Location = New System.Drawing.Point(168, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 23)
        Me.Button1.TabIndex = 69
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 324)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtOrder)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "FrmP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents DGV As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents txtOrder As TextBox
    Friend WithEvents BarCodes As DataGridViewTextBoxColumn
    Friend WithEvents Button4 As Button
End Class
