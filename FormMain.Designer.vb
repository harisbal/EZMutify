<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.tbCurStatus = New System.Windows.Forms.TextBox()
        Me.BtnAdAdds = New System.Windows.Forms.Button()
        Me.nfi = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CMSnfi = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddCurrentAdvToListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditAdsListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnEditAdsList = New System.Windows.Forms.Button()
        Me.BtnPrev = New System.Windows.Forms.Button()
        Me.BtnPlayPause = New System.Windows.Forms.Button()
        Me.BtnForward = New System.Windows.Forms.Button()
        Me.CMSnfi.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnStart
        '
        Me.BtnStart.Location = New System.Drawing.Point(14, 96)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(255, 38)
        Me.BtnStart.TabIndex = 1
        Me.BtnStart.Text = "Start EZMutify"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'tbCurStatus
        '
        Me.tbCurStatus.Location = New System.Drawing.Point(13, 29)
        Me.tbCurStatus.Multiline = True
        Me.tbCurStatus.Name = "tbCurStatus"
        Me.tbCurStatus.Size = New System.Drawing.Size(253, 20)
        Me.tbCurStatus.TabIndex = 2
        '
        'BtnAdAdds
        '
        Me.BtnAdAdds.Location = New System.Drawing.Point(272, 29)
        Me.BtnAdAdds.Name = "BtnAdAdds"
        Me.BtnAdAdds.Size = New System.Drawing.Size(118, 61)
        Me.BtnAdAdds.TabIndex = 3
        Me.BtnAdAdds.Text = "Add to Ads"
        Me.BtnAdAdds.UseVisualStyleBackColor = True
        '
        'nfi
        '
        Me.nfi.BalloonTipText = "EZMutify is still running"
        Me.nfi.BalloonTipTitle = "EZMutify"
        Me.nfi.ContextMenuStrip = Me.CMSnfi
        Me.nfi.Icon = CType(resources.GetObject("nfi.Icon"), System.Drawing.Icon)
        Me.nfi.Text = "EZMutify"
        Me.nfi.Visible = True
        '
        'CMSnfi
        '
        Me.CMSnfi.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.AddCurrentAdvToListToolStripMenuItem, Me.EditAdsListToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.CMSnfi.Name = "CMSnfi"
        Me.CMSnfi.Size = New System.Drawing.Size(193, 92)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(192, 22)
        Me.ToolStripMenuItem1.Text = "Show EZMutify"
        '
        'AddCurrentAdvToListToolStripMenuItem
        '
        Me.AddCurrentAdvToListToolStripMenuItem.Name = "AddCurrentAdvToListToolStripMenuItem"
        Me.AddCurrentAdvToListToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.AddCurrentAdvToListToolStripMenuItem.Text = "Add Current Ad to List"
        '
        'EditAdsListToolStripMenuItem
        '
        Me.EditAdsListToolStripMenuItem.Name = "EditAdsListToolStripMenuItem"
        Me.EditAdsListToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EditAdsListToolStripMenuItem.Text = "Edit Adds List"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Spotify is Playing:"
        '
        'BtnEditAdsList
        '
        Me.BtnEditAdsList.Location = New System.Drawing.Point(273, 96)
        Me.BtnEditAdsList.Name = "BtnEditAdsList"
        Me.BtnEditAdsList.Size = New System.Drawing.Size(117, 38)
        Me.BtnEditAdsList.TabIndex = 5
        Me.BtnEditAdsList.Text = "Edit Ads List"
        Me.BtnEditAdsList.UseVisualStyleBackColor = True
        '
        'BtnPrev
        '
        Me.BtnPrev.BackgroundImage = Global.EZMutify.My.Resources.Resources.PlayPrev
        Me.BtnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPrev.Location = New System.Drawing.Point(13, 62)
        Me.BtnPrev.Name = "BtnPrev"
        Me.BtnPrev.Size = New System.Drawing.Size(81, 28)
        Me.BtnPrev.TabIndex = 6
        Me.BtnPrev.UseVisualStyleBackColor = True
        '
        'BtnPlayPause
        '
        Me.BtnPlayPause.BackgroundImage = Global.EZMutify.My.Resources.Resources.Play
        Me.BtnPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPlayPause.Location = New System.Drawing.Point(100, 62)
        Me.BtnPlayPause.Name = "BtnPlayPause"
        Me.BtnPlayPause.Size = New System.Drawing.Size(81, 28)
        Me.BtnPlayPause.TabIndex = 7
        Me.BtnPlayPause.UseVisualStyleBackColor = True
        '
        'BtnForward
        '
        Me.BtnForward.BackgroundImage = Global.EZMutify.My.Resources.Resources.PlayNext
        Me.BtnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnForward.Location = New System.Drawing.Point(186, 62)
        Me.BtnForward.Name = "BtnForward"
        Me.BtnForward.Size = New System.Drawing.Size(81, 28)
        Me.BtnForward.TabIndex = 8
        Me.BtnForward.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 146)
        Me.Controls.Add(Me.BtnForward)
        Me.Controls.Add(Me.BtnPlayPause)
        Me.Controls.Add(Me.BtnPrev)
        Me.Controls.Add(Me.BtnEditAdsList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnAdAdds)
        Me.Controls.Add(Me.tbCurStatus)
        Me.Controls.Add(Me.BtnStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.Text = "EZMutify"
        Me.CMSnfi.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents tbCurStatus As System.Windows.Forms.TextBox
    Friend WithEvents BtnAdAdds As System.Windows.Forms.Button
    Friend WithEvents nfi As System.Windows.Forms.NotifyIcon
    Friend WithEvents CMSnfi As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddCurrentAdvToListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditAdsListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnEditAdsList As System.Windows.Forms.Button
    Friend WithEvents BtnPrev As System.Windows.Forms.Button
    Friend WithEvents BtnPlayPause As System.Windows.Forms.Button
    Friend WithEvents BtnForward As System.Windows.Forms.Button

End Class
