﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uctlCheckedList
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.clbListEventTypes = New System.Windows.Forms.CheckedListBox()
        Me.btnListEventTypes = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'clbListEventTypes
        '
        Me.clbListEventTypes.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbListEventTypes.FormattingEnabled = True
        Me.clbListEventTypes.HorizontalScrollbar = True
        Me.clbListEventTypes.Location = New System.Drawing.Point(3, 31)
        Me.clbListEventTypes.Name = "clbListEventTypes"
        Me.clbListEventTypes.Size = New System.Drawing.Size(555, 124)
        Me.clbListEventTypes.TabIndex = 46
        '
        'btnListEventTypes
        '
        Me.btnListEventTypes.Location = New System.Drawing.Point(2, 2)
        Me.btnListEventTypes.Name = "btnListEventTypes"
        Me.btnListEventTypes.Size = New System.Drawing.Size(556, 23)
        Me.btnListEventTypes.TabIndex = 45
        Me.btnListEventTypes.Text = "listEventTypes"
        Me.btnListEventTypes.UseVisualStyleBackColor = True
        '
        'uctlCheckedList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.clbListEventTypes)
        Me.Controls.Add(Me.btnListEventTypes)
        Me.Name = "uctlCheckedList"
        Me.Size = New System.Drawing.Size(561, 157)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents clbListEventTypes As CheckedListBox
    Friend WithEvents btnListEventTypes As Button
End Class
