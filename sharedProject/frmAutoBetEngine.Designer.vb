<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAutoBetEngine
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnListMarketCatalogue = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pageMarketCatalogue = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMaxResults = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.clbMarketProjection = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSort = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.pageMarketCatalogue.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1, Me.LoginToolStripMenuItem, Me.EinstellungenToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1117, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(12, 20)
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionToolStripMenuItem})
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.EinstellungenToolStripMenuItem.Text = "Einstellungen"
        '
        'ConnectionToolStripMenuItem
        '
        Me.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem"
        Me.ConnectionToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ConnectionToolStripMenuItem.Text = "Connection"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(63, 20)
        Me.ToolStripMenuItem1.Text = "Logging"
        '
        'btnListMarketCatalogue
        '
        Me.btnListMarketCatalogue.Location = New System.Drawing.Point(12, 44)
        Me.btnListMarketCatalogue.Name = "btnListMarketCatalogue"
        Me.btnListMarketCatalogue.Size = New System.Drawing.Size(184, 23)
        Me.btnListMarketCatalogue.TabIndex = 14
        Me.btnListMarketCatalogue.Text = "ListMarketCatalogue"
        Me.btnListMarketCatalogue.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 840)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1117, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.pageMarketCatalogue)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 88)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1084, 717)
        Me.TabControl1.TabIndex = 26
        '
        'pageMarketCatalogue
        '
        Me.pageMarketCatalogue.Controls.Add(Me.Button3)
        Me.pageMarketCatalogue.Controls.Add(Me.Label5)
        Me.pageMarketCatalogue.Controls.Add(Me.Label4)
        Me.pageMarketCatalogue.Controls.Add(Me.DateTimePicker2)
        Me.pageMarketCatalogue.Controls.Add(Me.DateTimePicker1)
        Me.pageMarketCatalogue.Controls.Add(Me.GroupBox1)
        Me.pageMarketCatalogue.Controls.Add(Me.ListView3)
        Me.pageMarketCatalogue.Controls.Add(Me.ListView2)
        Me.pageMarketCatalogue.Controls.Add(Me.TreeView1)
        Me.pageMarketCatalogue.Controls.Add(Me.DataGridView5)
        Me.pageMarketCatalogue.Controls.Add(Me.Button6)
        Me.pageMarketCatalogue.Controls.Add(Me.ListView1)
        Me.pageMarketCatalogue.Controls.Add(Me.Button5)
        Me.pageMarketCatalogue.Controls.Add(Me.TextBox2)
        Me.pageMarketCatalogue.Controls.Add(Me.Button1)
        Me.pageMarketCatalogue.Controls.Add(Me.btnClose)
        Me.pageMarketCatalogue.Controls.Add(Me.Label3)
        Me.pageMarketCatalogue.Controls.Add(Me.cboMaxResults)
        Me.pageMarketCatalogue.Controls.Add(Me.Label2)
        Me.pageMarketCatalogue.Controls.Add(Me.clbMarketProjection)
        Me.pageMarketCatalogue.Controls.Add(Me.Label1)
        Me.pageMarketCatalogue.Controls.Add(Me.cboSort)
        Me.pageMarketCatalogue.Location = New System.Drawing.Point(4, 22)
        Me.pageMarketCatalogue.Name = "pageMarketCatalogue"
        Me.pageMarketCatalogue.Padding = New System.Windows.Forms.Padding(3)
        Me.pageMarketCatalogue.Size = New System.Drawing.Size(1076, 691)
        Me.pageMarketCatalogue.TabIndex = 0
        Me.pageMarketCatalogue.Text = "MarketCatalogue"
        Me.pageMarketCatalogue.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(267, 596)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 53
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 420)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "bis"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 394)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "von"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(40, 414)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 50
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(40, 388)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 49
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(40, 491)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 45)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TurnInPlay"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(104, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(45, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "nein"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(17, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(33, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "ja"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'ListView3
        '
        Me.ListView3.CheckBoxes = True
        Me.ListView3.HideSelection = False
        Me.ListView3.Location = New System.Drawing.Point(152, 251)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(88, 97)
        Me.ListView3.TabIndex = 47
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'ListView2
        '
        Me.ListView2.CheckBoxes = True
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(34, 251)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(88, 97)
        Me.ListView2.TabIndex = 46
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(332, 274)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(532, 305)
        Me.TreeView1.TabIndex = 45
        '
        'DataGridView5
        '
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(887, 274)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.Size = New System.Drawing.Size(149, 305)
        Me.DataGridView5.TabIndex = 44
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(1041, 214)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(30, 43)
        Me.Button6.TabIndex = 43
        Me.Button6.Text = "V"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(332, 147)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(704, 112)
        Me.ListView1.TabIndex = 42
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(1042, 31)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(30, 109)
        Me.Button5.TabIndex = 41
        Me.Button5.Text = "V"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(332, 31)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(704, 109)
        Me.TextBox2.TabIndex = 40
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1042, 148)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 43)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(267, 31)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 437)
        Me.btnClose.TabIndex = 36
        Me.btnClose.Text = "-->"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 624)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 24)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Max Results"
        '
        'cboMaxResults
        '
        Me.cboMaxResults.FormattingEnabled = True
        Me.cboMaxResults.Items.AddRange(New Object() {"20", "50", "100", "250", "500", "1000"})
        Me.cboMaxResults.Location = New System.Drawing.Point(34, 651)
        Me.cboMaxResults.Name = "cboMaxResults"
        Me.cboMaxResults.Size = New System.Drawing.Size(206, 21)
        Me.cboMaxResults.TabIndex = 23
        Me.cboMaxResults.Text = "20"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 24)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Market_Projection"
        '
        'clbMarketProjection
        '
        Me.clbMarketProjection.FormattingEnabled = True
        Me.clbMarketProjection.Items.AddRange(New Object() {"COMPETITION", "EVENT", "EVENT_TYPE", "MARKET_START_TIME", "MARKET_DESCRIPTION", "RUNNER_DESCRIPTION", "RUNNER_METADATA"})
        Me.clbMarketProjection.Location = New System.Drawing.Point(34, 119)
        Me.clbMarketProjection.Name = "clbMarketProjection"
        Me.clbMarketProjection.Size = New System.Drawing.Size(206, 109)
        Me.clbMarketProjection.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 24)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Sortierung"
        '
        'cboSort
        '
        Me.cboSort.FormattingEnabled = True
        Me.cboSort.Items.AddRange(New Object() {"MINIMUM_TRADED", "MAXIMUM_TRADED", "MINIMUM_AVAILABLE", "MAXIMUM_AVAILABLE", "FIRST_TO_START", "LAST_TO_START"})
        Me.cboSort.Location = New System.Drawing.Point(34, 58)
        Me.cboSort.Name = "cboSort"
        Me.cboSort.Size = New System.Drawing.Size(206, 21)
        Me.cboSort.TabIndex = 19
        Me.cboSort.Text = "FIRST_TO_START"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1076, 691)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1076, 691)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(348, 44)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 27
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(518, 43)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmAutoBetEngine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 862)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnListMarketCatalogue)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmAutoBetEngine"
        Me.Text = "AutoBetEngine"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.pageMarketCatalogue.ResumeLayout(False)
        Me.pageMarketCatalogue.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripComboBox1 As ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents btnListMarketCatalogue As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents pageMarketCatalogue As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnClose As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cboMaxResults As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents clbMarketProjection As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSort As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button6 As Button
    Friend WithEvents DataGridView5 As DataGridView
    Friend WithEvents Button7 As Button
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Button2 As Button
    Friend WithEvents ListView3 As ListView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button3 As Button
End Class
