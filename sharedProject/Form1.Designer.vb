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
        Me.Button2 = New System.Windows.Forms.Button()
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.txtMarket = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnGO = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(143, 384)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Market Info"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txtConnectionState, Me.ToolStripSeparator2, Me.ToolStripLabel2, Me.txtCookie, Me.ToolStripSeparator1, Me.ToolStripLabel3, Me.txtHeartbeatintervall})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 946)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1147, 25)
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1, Me.LoginToolStripMenuItem, Me.EinstellungenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1147, 24)
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
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(932, 406)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(203, 24)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "keep Alive"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 44)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(295, 23)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "listEventTypes"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(12, 73)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(295, 124)
        Me.DataGridView2.TabIndex = 17
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 203)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(80, 20)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.Text = "1"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(115, 203)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(192, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Events"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(13, 230)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(294, 150)
        Me.dgv1.TabIndex = 20
        '
        'txtMarket
        '
        Me.txtMarket.Location = New System.Drawing.Point(13, 386)
        Me.txtMarket.Name = "txtMarket"
        Me.txtMarket.Size = New System.Drawing.Size(80, 20)
        Me.txtMarket.TabIndex = 22
        Me.txtMarket.Text = "1"
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(13, 413)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(294, 501)
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(12, 920)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(295, 23)
        Me.Button5.TabIndex = 25
        Me.Button5.Text = "Märkte übernehmen"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.LargeChange = 20
        Me.TrackBar1.Location = New System.Drawing.Point(346, 424)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(104, 45)
        Me.TrackBar1.SmallChange = 5
        Me.TrackBar1.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(343, 394)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Aktualisierungsintervall in Millisekunden"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(456, 424)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(69, 20)
        Me.TextBox2.TabIndex = 28
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(346, 351)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 29
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(346, 73)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(789, 268)
        Me.ListView2.TabIndex = 30
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(346, 43)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(789, 24)
        Me.Button7.TabIndex = 31
        Me.Button7.Text = "initialisiere oder lösche die Liste"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'btnGO
        '
        Me.btnGO.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnGO.Location = New System.Drawing.Point(705, 398)
        Me.btnGO.Name = "btnGO"
        Me.btnGO.Size = New System.Drawing.Size(75, 32)
        Me.btnGO.TabIndex = 32
        Me.btnGO.Text = "GO!"
        Me.btnGO.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 971)
        Me.Controls.Add(Me.btnGO)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtMarket)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button2)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "AutoBetEngine"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents txtConnectionState As ToolStripTextBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
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
    Friend WithEvents Button4 As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents txtMarket As TextBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button5 As Button
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Button7 As Button
    Friend WithEvents btnGO As Button
End Class
