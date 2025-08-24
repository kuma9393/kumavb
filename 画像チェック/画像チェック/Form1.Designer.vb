<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.データ表示 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.画像チェック = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'データ表示
        '
        Me.データ表示.Font = New System.Drawing.Font("メイリオ", 10.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.データ表示.Location = New System.Drawing.Point(717, 266)
        Me.データ表示.Name = "データ表示"
        Me.データ表示.Size = New System.Drawing.Size(136, 38)
        Me.データ表示.TabIndex = 0
        Me.データ表示.Text = "データ表示"
        Me.データ表示.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(24, 34)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 29
        Me.DataGridView1.Size = New System.Drawing.Size(655, 431)
        Me.DataGridView1.TabIndex = 1
        '
        '画像チェック
        '
        Me.画像チェック.Font = New System.Drawing.Font("メイリオ", 10.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.画像チェック.Location = New System.Drawing.Point(717, 180)
        Me.画像チェック.Name = "画像チェック"
        Me.画像チェック.Size = New System.Drawing.Size(136, 38)
        Me.画像チェック.TabIndex = 2
        Me.画像チェック.Text = "画像チェック"
        Me.画像チェック.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(717, 49)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(125, 27)
        Me.TextBox1.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 500)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.画像チェック)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.データ表示)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents データ表示 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents 画像チェック As Button
    Friend WithEvents TextBox1 As TextBox
End Class
