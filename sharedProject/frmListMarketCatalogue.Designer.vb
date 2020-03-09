<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmListMarketCatalogue
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
        Me.cboSort = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.clbMarketProjection = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMaxResults = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboSort
        '
        Me.cboSort.FormattingEnabled = True
        Me.cboSort.Items.AddRange(New Object() {"MINIMUM_TRADED", "MAXIMUM_TRADED", "MINIMUM_AVAILABLE", "MAXIMUM_AVAILABLE", "FIRST_TO_START", "LAST_TO_START"})
        Me.cboSort.Location = New System.Drawing.Point(44, 72)
        Me.cboSort.Name = "cboSort"
        Me.cboSort.Size = New System.Drawing.Size(206, 21)
        Me.cboSort.TabIndex = 0
        Me.cboSort.Text = "FIRST_TO_START"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(93, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sortierung"
        '
        'clbMarketProjection
        '
        Me.clbMarketProjection.FormattingEnabled = True
        Me.clbMarketProjection.Items.AddRange(New Object() {"COMPETITION", "EVENT", "EVENT_TYPE", "MARKET_START_TIME", "MARKET_DESCRIPTION", "RUNNER_DESCRIPTION", "RUNNER_METADATA"})
        Me.clbMarketProjection.Location = New System.Drawing.Point(44, 139)
        Me.clbMarketProjection.Name = "clbMarketProjection"
        Me.clbMarketProjection.Size = New System.Drawing.Size(206, 109)
        Me.clbMarketProjection.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(93, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Market_Projection"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 286)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Max Results"
        '
        'cboMaxResults
        '
        Me.cboMaxResults.FormattingEnabled = True
        Me.cboMaxResults.Items.AddRange(New Object() {"20", "50", "100", "250", "500", "1000"})
        Me.cboMaxResults.Location = New System.Drawing.Point(47, 313)
        Me.cboMaxResults.Name = "cboMaxResults"
        Me.cboMaxResults.Size = New System.Drawing.Size(206, 21)
        Me.cboMaxResults.TabIndex = 5
        Me.cboMaxResults.Text = "20"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(47, 372)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(196, 85)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "generate and close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmListMarketCatalogue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 513)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboMaxResults)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.clbMarketProjection)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSort)
        Me.Name = "frmListMarketCatalogue"
        Me.Text = "frmListMarketCatalogue"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboSort As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents clbMarketProjection As CheckedListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboMaxResults As ComboBox
    Friend WithEvents btnClose As Button
End Class
