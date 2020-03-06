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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pageMarketCatalogue = New System.Windows.Forms.TabPage()
        Me.clbSort = New System.Windows.Forms.CheckedListBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.clbEventIds = New System.Windows.Forms.CheckedListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.clbMarketTypeCodes = New System.Windows.Forms.CheckedListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.clbMarketCountries = New System.Windows.Forms.CheckedListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.clbEventTypeIds = New System.Windows.Forms.CheckedListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMaxResults = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.clbMarketProjection = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSort = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.pageMarketCatalogue.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1, Me.LoginToolStripMenuItem, Me.EinstellungenToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1526, 24)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 720)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1526, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1248, 44)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1125, 258)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(117, 120)
        Me.TextBox1.TabIndex = 18
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1197, 102)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(192, 97)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(1404, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(51, 55)
        Me.DataGridView1.TabIndex = 20
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(1411, 88)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(44, 150)
        Me.DataGridView2.TabIndex = 21
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(1411, 244)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(47, 151)
        Me.DataGridView3.TabIndex = 22
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(1102, 401)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(353, 169)
        Me.DataGridView4.TabIndex = 23
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1248, 205)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(1471, 166)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(43, 308)
        Me.DataGrid1.TabIndex = 25
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.pageMarketCatalogue)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 88)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1084, 629)
        Me.TabControl1.TabIndex = 26
        '
        'pageMarketCatalogue
        '
        Me.pageMarketCatalogue.Controls.Add(Me.clbSort)
        Me.pageMarketCatalogue.Controls.Add(Me.btnClose)
        Me.pageMarketCatalogue.Controls.Add(Me.Label9)
        Me.pageMarketCatalogue.Controls.Add(Me.DateTimePicker1)
        Me.pageMarketCatalogue.Controls.Add(Me.clbEventIds)
        Me.pageMarketCatalogue.Controls.Add(Me.Label8)
        Me.pageMarketCatalogue.Controls.Add(Me.clbMarketTypeCodes)
        Me.pageMarketCatalogue.Controls.Add(Me.Label7)
        Me.pageMarketCatalogue.Controls.Add(Me.clbMarketCountries)
        Me.pageMarketCatalogue.Controls.Add(Me.Label6)
        Me.pageMarketCatalogue.Controls.Add(Me.clbEventTypeIds)
        Me.pageMarketCatalogue.Controls.Add(Me.Label5)
        Me.pageMarketCatalogue.Controls.Add(Me.Label4)
        Me.pageMarketCatalogue.Controls.Add(Me.Label3)
        Me.pageMarketCatalogue.Controls.Add(Me.cboMaxResults)
        Me.pageMarketCatalogue.Controls.Add(Me.Label2)
        Me.pageMarketCatalogue.Controls.Add(Me.clbMarketProjection)
        Me.pageMarketCatalogue.Controls.Add(Me.Label1)
        Me.pageMarketCatalogue.Controls.Add(Me.cboSort)
        Me.pageMarketCatalogue.Location = New System.Drawing.Point(4, 22)
        Me.pageMarketCatalogue.Name = "pageMarketCatalogue"
        Me.pageMarketCatalogue.Padding = New System.Windows.Forms.Padding(3)
        Me.pageMarketCatalogue.Size = New System.Drawing.Size(1076, 603)
        Me.pageMarketCatalogue.TabIndex = 0
        Me.pageMarketCatalogue.Text = "MarketCatalogue"
        Me.pageMarketCatalogue.UseVisualStyleBackColor = True
        '
        'clbSort
        '
        Me.clbSort.FormattingEnabled = True
        Me.clbSort.Items.AddRange(New Object() {"MINIMUM_TRADED", "MAXIMUM_TRADED", "MINIMUM_AVAILABLE", "MAXIMUM_AVAILABLE", "FIRST_TO_START", "LAST_TO_START"})
        Me.clbSort.Location = New System.Drawing.Point(37, 95)
        Me.clbSort.Name = "clbSort"
        Me.clbSort.Size = New System.Drawing.Size(206, 109)
        Me.clbSort.TabIndex = 37
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(22, 493)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(196, 85)
        Me.btnClose.TabIndex = 36
        Me.btnClose.Text = "generate and close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(682, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 24)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "eventIds"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(376, 457)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(206, 20)
        Me.DateTimePicker1.TabIndex = 34
        '
        'clbEventIds
        '
        Me.clbEventIds.FormattingEnabled = True
        Me.clbEventIds.Items.AddRange(New Object() {"COMPETITION", "EVENT", "EVENT_TYPE", "MARKET_START_TIME", "MARKET_DESCRIPTION", "RUNNER_DESCRIPTION", "RUNNER_METADATA"})
        Me.clbEventIds.Location = New System.Drawing.Point(637, 281)
        Me.clbEventIds.Name = "clbEventIds"
        Me.clbEventIds.Size = New System.Drawing.Size(206, 109)
        Me.clbEventIds.TabIndex = 33
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(393, 420)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 24)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "marketStartTime"
        '
        'clbMarketTypeCodes
        '
        Me.clbMarketTypeCodes.FormattingEnabled = True
        Me.clbMarketTypeCodes.Items.AddRange(New Object() {"COMPETITION", "EVENT", "EVENT_TYPE", "MARKET_START_TIME", "MARKET_DESCRIPTION", "RUNNER_DESCRIPTION", "RUNNER_METADATA"})
        Me.clbMarketTypeCodes.Location = New System.Drawing.Point(376, 281)
        Me.clbMarketTypeCodes.Name = "clbMarketTypeCodes"
        Me.clbMarketTypeCodes.Size = New System.Drawing.Size(206, 109)
        Me.clbMarketTypeCodes.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(393, 244)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(164, 24)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "marketTypeCodes"
        '
        'clbMarketCountries
        '
        Me.clbMarketCountries.FormattingEnabled = True
        Me.clbMarketCountries.Items.AddRange(New Object() {"COMPETITION", "EVENT", "EVENT_TYPE", "MARKET_START_TIME", "MARKET_DESCRIPTION", "RUNNER_DESCRIPTION", "RUNNER_METADATA"})
        Me.clbMarketCountries.Location = New System.Drawing.Point(376, 95)
        Me.clbMarketCountries.Name = "clbMarketCountries"
        Me.clbMarketCountries.Size = New System.Drawing.Size(206, 109)
        Me.clbMarketCountries.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(393, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 24)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "marketCountries"
        '
        'clbEventTypeIds
        '
        Me.clbEventTypeIds.FormattingEnabled = True
        Me.clbEventTypeIds.Items.AddRange(New Object() {"COMPETITION", "EVENT", "EVENT_TYPE", "MARKET_START_TIME", "MARKET_DESCRIPTION", "RUNNER_DESCRIPTION", "RUNNER_METADATA"})
        Me.clbEventTypeIds.Location = New System.Drawing.Point(637, 95)
        Me.clbEventTypeIds.Name = "clbEventTypeIds"
        Me.clbEventTypeIds.Size = New System.Drawing.Size(206, 109)
        Me.clbEventTypeIds.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(666, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 24)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "eventTypeIds"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(585, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 24)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Filter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 420)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 24)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Max Results"
        '
        'cboMaxResults
        '
        Me.cboMaxResults.FormattingEnabled = True
        Me.cboMaxResults.Items.AddRange(New Object() {"20", "50", "100", "250", "500", "1000"})
        Me.cboMaxResults.Location = New System.Drawing.Point(34, 447)
        Me.cboMaxResults.Name = "cboMaxResults"
        Me.cboMaxResults.Size = New System.Drawing.Size(206, 21)
        Me.cboMaxResults.TabIndex = 23
        Me.cboMaxResults.Text = "20"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(58, 244)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 24)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Market_Projection"
        '
        'clbMarketProjection
        '
        Me.clbMarketProjection.FormattingEnabled = True
        Me.clbMarketProjection.Items.AddRange(New Object() {"COMPETITION", "EVENT", "EVENT_TYPE", "MARKET_START_TIME", "MARKET_DESCRIPTION", "RUNNER_DESCRIPTION", "RUNNER_METADATA"})
        Me.clbMarketProjection.Location = New System.Drawing.Point(34, 281)
        Me.clbMarketProjection.Name = "clbMarketProjection"
        Me.clbMarketProjection.Size = New System.Drawing.Size(206, 109)
        Me.clbMarketProjection.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 24)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Sortierung"
        '
        'cboSort
        '
        Me.cboSort.FormattingEnabled = True
        Me.cboSort.Items.AddRange(New Object() {"MINIMUM_TRADED", "MAXIMUM_TRADED", "MINIMUM_AVAILABLE", "MAXIMUM_AVAILABLE", "FIRST_TO_START", "LAST_TO_START"})
        Me.cboSort.Location = New System.Drawing.Point(37, 31)
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
        Me.TabPage2.Size = New System.Drawing.Size(1076, 603)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1076, 603)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'frmAutoBetEngine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1526, 742)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGridView4)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnListMarketCatalogue)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmAutoBetEngine"
        Me.Text = "AutoBetEngine"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.pageMarketCatalogue.ResumeLayout(False)
        Me.pageMarketCatalogue.PerformLayout()
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
    Friend WithEvents Button2 As Button
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents DataGrid1 As DataGrid
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents pageMarketCatalogue As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnClose As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents clbEventIds As CheckedListBox
    Friend WithEvents Label8 As Label
    Friend WithEvents clbMarketTypeCodes As CheckedListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents clbMarketCountries As CheckedListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents clbEventTypeIds As CheckedListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboMaxResults As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents clbMarketProjection As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSort As ComboBox
    Friend WithEvents clbSort As CheckedListBox
End Class
