﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtConnectionState = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.txtCookie = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.txtHeartbeatintervall = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRefreshRate = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnGO = New System.Windows.Forms.Button()
        Me.cboPriceData1 = New System.Windows.Forms.ComboBox()
        Me.lblPriceData = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPriceData2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboOrderData = New System.Windows.Forms.ComboBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txtRequest = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.UctlListMarketCatalogue = New sharedProject.uctlCheckedList()
        Me.UctlListEvents = New sharedProject.uctlCheckedList()
        Me.UctlListEventTypes = New sharedProject.uctlCheckedList()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txtConnectionState, Me.ToolStripSeparator2, Me.ToolStripLabel2, Me.txtCookie, Me.ToolStripSeparator1, Me.ToolStripLabel3, Me.txtHeartbeatintervall})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 812)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1415, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(101, 22)
        Me.ToolStripLabel1.Text = "Connection State:"
        '
        'txtConnectionState
        '
        Me.txtConnectionState.Enabled = False
        Me.txtConnectionState.Name = "txtConnectionState"
        Me.txtConnectionState.Size = New System.Drawing.Size(50, 25)
        Me.txtConnectionState.Text = "offline"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripLabel2.Text = "Cookie:"
        '
        'txtCookie
        '
        Me.txtCookie.Enabled = False
        Me.txtCookie.Name = "txtCookie"
        Me.txtCookie.Size = New System.Drawing.Size(333, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(101, 22)
        Me.ToolStripLabel3.Text = "Heartbeatintervall"
        '
        'txtHeartbeatintervall
        '
        Me.txtHeartbeatintervall.Enabled = False
        Me.txtHeartbeatintervall.Name = "txtHeartbeatintervall"
        Me.txtHeartbeatintervall.Size = New System.Drawing.Size(50, 25)
        Me.txtHeartbeatintervall.Text = "offline"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1, Me.LoginToolStripMenuItem, Me.EinstellungenToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1415, 24)
        Me.MenuStrip1.TabIndex = 11
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
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(70, 20)
        Me.ToolStripMenuItem1.Text = "Techform"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1212, 781)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(203, 24)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "keep Alive"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.LargeChange = 20
        Me.TrackBar1.Location = New System.Drawing.Point(613, 607)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(104, 45)
        Me.TrackBar1.SmallChange = 5
        Me.TrackBar1.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(610, 577)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Aktualisierungsintervall in Millisekunden"
        '
        'txtRefreshRate
        '
        Me.txtRefreshRate.Location = New System.Drawing.Point(723, 607)
        Me.txtRefreshRate.Name = "txtRefreshRate"
        Me.txtRefreshRate.Size = New System.Drawing.Size(69, 20)
        Me.txtRefreshRate.TabIndex = 28
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(608, 491)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(104, 23)
        Me.Button6.TabIndex = 29
        Me.Button6.Text = "create Request"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(613, 153)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(789, 268)
        Me.ListView2.TabIndex = 30
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(613, 123)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(789, 24)
        Me.Button7.TabIndex = 31
        Me.Button7.Text = "initialisiere oder lösche die Liste"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'btnGO
        '
        Me.btnGO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnGO.Location = New System.Drawing.Point(835, 595)
        Me.btnGO.Name = "btnGO"
        Me.btnGO.Size = New System.Drawing.Size(75, 32)
        Me.btnGO.TabIndex = 32
        Me.btnGO.Text = "GO!"
        Me.btnGO.UseVisualStyleBackColor = False
        '
        'cboPriceData1
        '
        Me.cboPriceData1.FormattingEnabled = True
        Me.cboPriceData1.Location = New System.Drawing.Point(613, 449)
        Me.cboPriceData1.Name = "cboPriceData1"
        Me.cboPriceData1.Size = New System.Drawing.Size(121, 21)
        Me.cboPriceData1.TabIndex = 33
        '
        'lblPriceData
        '
        Me.lblPriceData.AutoSize = True
        Me.lblPriceData.Location = New System.Drawing.Point(647, 433)
        Me.lblPriceData.Name = "lblPriceData"
        Me.lblPriceData.Size = New System.Drawing.Size(63, 13)
        Me.lblPriceData.TabIndex = 34
        Me.lblPriceData.Text = "Price Data1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(979, 435)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Price Data2"
        '
        'cboPriceData2
        '
        Me.cboPriceData2.FormattingEnabled = True
        Me.cboPriceData2.Location = New System.Drawing.Point(945, 451)
        Me.cboPriceData2.Name = "cboPriceData2"
        Me.cboPriceData2.Size = New System.Drawing.Size(121, 21)
        Me.cboPriceData2.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1309, 435)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Order Data"
        '
        'cboOrderData
        '
        Me.cboOrderData.FormattingEnabled = True
        Me.cboOrderData.Location = New System.Drawing.Point(1278, 451)
        Me.cboOrderData.Name = "cboOrderData"
        Me.cboOrderData.Size = New System.Drawing.Size(121, 21)
        Me.cboOrderData.TabIndex = 38
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Crimson
        Me.Button8.Location = New System.Drawing.Point(939, 595)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 32)
        Me.Button8.TabIndex = 39
        Me.Button8.Text = "STOPP!"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'txtRequest
        '
        Me.txtRequest.Enabled = False
        Me.txtRequest.Location = New System.Drawing.Point(723, 493)
        Me.txtRequest.Name = "txtRequest"
        Me.txtRequest.Size = New System.Drawing.Size(664, 20)
        Me.txtRequest.TabIndex = 40
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1072, 543)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 41
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(1131, 603)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 42
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(1131, 696)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(272, 23)
        Me.Button10.TabIndex = 43
        Me.Button10.Text = "Button10"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(595, 748)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(353, 21)
        Me.Button11.TabIndex = 45
        Me.Button11.Text = "Button11"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(595, 413)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(556, 124)
        Me.DataGridView2.TabIndex = 17
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(177, 70)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 51
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(492, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 52
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(658, 37)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 53
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'UctlListMarketCatalogue
        '
        Me.UctlListMarketCatalogue.Location = New System.Drawing.Point(0, 469)
        Me.UctlListMarketCatalogue.myType = Nothing
        Me.UctlListMarketCatalogue.Name = "UctlListMarketCatalogue"
        Me.UctlListMarketCatalogue.selektierteMenge = Nothing
        Me.UctlListMarketCatalogue.serializedRequestFromForm = ""
        Me.UctlListMarketCatalogue.serializedResponseFromForm = ""
        Me.UctlListMarketCatalogue.Size = New System.Drawing.Size(561, 157)
        Me.UctlListMarketCatalogue.Spalte_1 = Nothing
        Me.UctlListMarketCatalogue.Spalte_2 = Nothing
        Me.UctlListMarketCatalogue.Spalte_3 = Nothing
        Me.UctlListMarketCatalogue.TabIndex = 50
        Me.UctlListMarketCatalogue.Tag = ""
        '
        'UctlListEvents
        '
        Me.UctlListEvents.DataSource = Nothing
        Me.UctlListEvents.Location = New System.Drawing.Point(0, 291)
        Me.UctlListEvents.myType = Nothing
        Me.UctlListEvents.Name = "UctlListEvents"
        Me.UctlListEvents.selektierteMenge = Nothing
        Me.UctlListEvents.serializedRequestFromForm = ""
        Me.UctlListEvents.serializedResponseFromForm = ""
        Me.UctlListEvents.Size = New System.Drawing.Size(561, 157)
        Me.UctlListEvents.Spalte_1 = Nothing
        Me.UctlListEvents.Spalte_2 = Nothing
        Me.UctlListEvents.Spalte_3 = Nothing
        Me.UctlListEvents.TabIndex = 49
        '
        'UctlListEventTypes
        '
        Me.UctlListEventTypes.DataSource = Nothing
        Me.UctlListEventTypes.Location = New System.Drawing.Point(0, 123)
        Me.UctlListEventTypes.myType = Nothing
        Me.UctlListEventTypes.Name = "UctlListEventTypes"
        Me.UctlListEventTypes.selektierteMenge = Nothing
        Me.UctlListEventTypes.serializedRequestFromForm = ""
        Me.UctlListEventTypes.serializedResponseFromForm = ""
        Me.UctlListEventTypes.Size = New System.Drawing.Size(561, 157)
        Me.UctlListEventTypes.Spalte_1 = Nothing
        Me.UctlListEventTypes.Spalte_2 = Nothing
        Me.UctlListEventTypes.Spalte_3 = Nothing
        Me.UctlListEventTypes.TabIndex = 48
        '
        'TreeView2
        '
        Me.TreeView2.Location = New System.Drawing.Point(794, 37)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(121, 97)
        Me.TreeView2.TabIndex = 55
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1038, 55)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 56
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1415, 837)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.UctlListMarketCatalogue)
        Me.Controls.Add(Me.UctlListEvents)
        Me.Controls.Add(Me.UctlListEventTypes)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.txtRequest)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.cboOrderData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPriceData2)
        Me.Controls.Add(Me.lblPriceData)
        Me.Controls.Add(Me.cboPriceData1)
        Me.Controls.Add(Me.btnGO)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.txtRefreshRate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "AutoBetEngine"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents txtConnectionState As ToolStripTextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripComboBox1 As ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents txtCookie As ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Button1 As Button
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents txtHeartbeatintervall As ToolStripTextBox
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRefreshRate As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Button7 As Button
    Friend WithEvents btnGO As Button
    Friend WithEvents cboPriceData1 As ComboBox
    Friend WithEvents lblPriceData As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPriceData2 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboOrderData As ComboBox
    Friend WithEvents Button8 As Button
    Friend WithEvents txtRequest As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Button11 As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents UctlListEventTypes As uctlCheckedList
    Friend WithEvents UctlListEvents As uctlCheckedList
    Friend WithEvents UctlListMarketCatalogue As uctlCheckedList
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TreeView2 As TreeView
    Friend WithEvents Button5 As Button
End Class
