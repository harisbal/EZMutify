Imports System.Diagnostics
Imports CoreAudioApi
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class FormMain

    Dim devEnum As MMDeviceEnumerator = New MMDeviceEnumerator()
    Dim SndDevice As MMDevice
    Dim audioSesCntrl As AudioSessionControl
    Dim spotifyAudioCntrl As AudioSessionControl
    Dim SndDevCnt As Integer
    Dim SpotifyRunning As Boolean
    Dim Processes() As Process
    Dim spotifyProc As Process
    Dim spotifyAdds As New List(Of String)
    Dim spotifyMainTitle As String
    Dim path As String = Replace(System.IO.Path.GetDirectoryName( _
        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "file:\", "")
    Dim adsListPath As String = path & "\Advertisments List.txt"
    Dim sSpotifyPlayingAd = "EZMutify is silencing an ad"
    Dim sSpotifyNotRunning As String = "Spotify is not running - Plz start Spotify"
    Dim sSpotifyNotPlayingSong As String = "Spotify is not playing any song"
    Dim sSpotifyAd As String = "Spotify - Spotify – Spotify"
    Dim ReservedStrings() As String = {sSpotifyNotRunning, sSpotifyNotPlayingSong, sSpotifyAd, sSpotifyPlayingAd}
    Dim spotifyControl As New Spotify
    Dim storedSpotifyVol As Single
    Dim muteMasterVol As Single = 5 / 100 '(Range from 0 to 1.0)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnStart.Click

        If BtnStart.Text = "Stop EZMutify" Then
            BtnStart.Text = "Start EZMutify"
            Exit Sub
        Else
            BtnStart.Text = "Stop EZMutify"
        End If

        If Not System.IO.File.Exists(adsListPath) Then
            System.IO.File.Create(adsListPath).Dispose()
        End If

        Application.DoEvents()
        Dim adPlaying As Boolean = False
        Me.Focus()

        storedSpotifyVol = audioSesCntrl.SimpleAudioVolume.MasterVolume

        Do While SpotifyRunning = True
            Application.DoEvents()
            'Reading the adds here mutes the new added ads
            Dim ad As String = ""
            Using sr As New StreamReader(adsListPath)
                Do Until sr.EndOfStream
                    ad = sr.ReadLine.ToString
                    spotifyAdds.Add(ad)
                Loop
            End Using

            Try
                spotifyProc.Refresh()
                spotifyMainTitle = spotifyProc.MainWindowTitle.ToString
            Catch ex As Exception
                SpotifyRunning = False
            End Try

            Processes = Process.GetProcessesByName("Spotify")
            If Processes.Count = 0 Then
                SpotifyRunning = False
                tbCurStatus.Text = sSpotifyNotRunning
            End If

            If spotifyMainTitle <> "Spotify" Then
                Try
                    tbCurStatus.Text = spotifyMainTitle.ToString.Remove(0, 10)
                    adPlaying = False
                Catch ex As Exception
                    Debug.Print(ex.ToString)
                End Try
            Else
                tbCurStatus.Text = sSpotifyNotPlayingSong
            End If

            If spotifyMainTitle = sSpotifyAd Then
                adPlaying = True
                'After Update Spotify does not play the ad if in muted state
                'audioSesCntrl.SimpleAudioVolume.Mute = True
                If spotifyAudioCntrl.SimpleAudioVolume.MasterVolume <> muteMasterVol Then
                    storedSpotifyVol = audioSesCntrl.SimpleAudioVolume.MasterVolume
                End If
                spotifyAudioCntrl.SimpleAudioVolume.MasterVolume = muteMasterVol
            Else
                For Each ad In spotifyAdds
                    If spotifyMainTitle = "Spotify - " & ad Then
                        adPlaying = True
                        'audioSesCntrl.SimpleAudioVolume.Mute = True
                        If spotifyAudioCntrl.SimpleAudioVolume.MasterVolume <> muteMasterVol Then
                            storedSpotifyVol = audioSesCntrl.SimpleAudioVolume.MasterVolume
                        End If
                        spotifyAudioCntrl.SimpleAudioVolume.MasterVolume = muteMasterVol
                        tbCurStatus.Text = sSpotifyPlayingAd
                    End If
                Next
            End If

            If adPlaying = False Then
                Thread.Sleep(300)
                spotifyAudioCntrl.SimpleAudioVolume.MasterVolume = storedSpotifyVol
                'audioSesCntrl.SimpleAudioVolume.Mute = False
            End If
        Loop

    End Sub

    Private Function PlayState() As Boolean
        spotifyProc.Refresh()
        spotifyMainTitle = spotifyProc.MainWindowTitle.ToString
        If spotifyMainTitle = "Spotify" Then
            BtnPlayPause.BackgroundImage = My.Resources.Play
            Return False
        Else
            BtnPlayPause.BackgroundImage = My.Resources.Pause
            Return True
        End If
    End Function

    Private Sub BtnAdAdds_Click(sender As Object, e As EventArgs) Handles BtnAdAdds.Click

        Me.Focus()
        If Not System.IO.File.Exists(adsListPath) Then
            System.IO.File.Create(adsListPath).Dispose()
        End If

        Dim sb As New StringBuilder()
        Dim line As String

        Using sr As New StreamReader(adsListPath)

            For Each add In ReservedStrings
                If tbCurStatus.Text = add Then
                    Exit Sub
                End If
            Next

            Do Until sr.EndOfStream
                line = sr.ReadLine()
                If line = tbCurStatus.Text Then
                    MsgBox("Advertisment already in the list")
                    Exit Sub
                End If
            Loop
            sr.BaseStream.Position = 0
            sb.Append(sr.ReadToEnd())
            sb.AppendLine(tbCurStatus.Text)
        End Using

        Using outfile As New StreamWriter(adsListPath)
            outfile.Write(sb.ToString())
        End Using
        MsgBox("Advertisment added to the Ads list")

    End Sub

    Private Sub FormMain_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        'First minimize the form
        Me.WindowState = FormWindowState.Minimized
        'Now make it invisible (make it look like it went into the system tray)
        Me.Visible = False
        'Cancel the closing of the application
        e.Cancel = True
        nfi.Visible = True
        nfi.ShowBalloonTip(2000)
        'MsgBox("FTProgram has been minimized to the task bar.")

    End Sub

    Private Sub nfi_MouseDown(sender As Object, e As MouseEventArgs) Handles nfi.MouseDown
        If Me.Visible = False Then
            If e.Button = MouseButtons.Left Then
                Me.Show()
                Me.BringToFront()
                Me.WindowState = FormWindowState.Normal
            End If
        Else
            If e.Button = MouseButtons.Left Then Me.Hide()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Show()
        Me.BringToFront()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub AddCurrentAdvToListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCurrentAdvToListToolStripMenuItem.Click
        Call BtnAdAdds_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'Unmute in case user exits program in middle of ad
        Try
            If audioSesCntrl.SimpleAudioVolume.Mute = True Then
                audioSesCntrl.SimpleAudioVolume.Mute = False
            End If
        Catch ex As Exception
        Finally
            End
        End Try

        Try
            If spotifyAudioCntrl.SimpleAudioVolume.MasterVolume = 5 Then
                spotifyAudioCntrl.SimpleAudioVolume.MasterVolume = storedSpotifyVol
            End If
        Catch ex As Exception
        Finally
            End
        End Try

        End
    End Sub

    Private Sub EditAdsListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditAdsListToolStripMenuItem.Click
        If Not System.IO.File.Exists(adsListPath) Then
            System.IO.File.Create(adsListPath).Dispose()
        Else
            System.Diagnostics.Process.Start(adsListPath)
        End If
    End Sub

    Private Sub BtnEditAdsList_Click(sender As Object, e As EventArgs) Handles BtnEditAdsList.Click
        If Not System.IO.File.Exists(adsListPath) Then
            System.IO.File.Create(adsListPath).Dispose()
        Else
            System.Diagnostics.Process.Start(adsListPath)
        End If
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        spotifyControl.PlayPrev()
    End Sub

    Private Sub BtnForward_Click(sender As Object, e As EventArgs) Handles BtnForward.Click
        spotifyControl.PlayNext()
    End Sub

    Private Sub BtnPlayPause_Click(sender As Object, e As EventArgs) Handles BtnPlayPause.Click
        spotifyControl.PlayPause()
        PlayState()
    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BtnStart.Text = "Start EZMutify"
        'Check if Spotify is active
        Processes = Process.GetProcessesByName("Spotify")
        If Processes.Count = 0 Then
            SpotifyRunning = False
            tbCurStatus.Text = sSpotifyNotRunning
            Exit Sub
        Else
            spotifyProc = Processes(0)
            SpotifyRunning = True
            spotifyMainTitle = spotifyProc.MainWindowTitle.ToString
            SndDevice = devEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia)
            SndDevCnt = SndDevice.AudioSessionManager.Sessions.Count

            For i = 0 To SndDevCnt - 1
                audioSesCntrl = SndDevice.AudioSessionManager.Sessions.Item(i)
                If audioSesCntrl.SessionIdentifier.Contains("spotify.exe") Then
                    spotifyAudioCntrl = SndDevice.AudioSessionManager.Sessions.Item(i)
                    spotifyAudioCntrl.SimpleAudioVolume.Mute = False
                    Exit For
                End If
            Next

        End If

        PlayState()
    End Sub

    Private Sub tbCurStatus_TextChanged(sender As Object, e As EventArgs) Handles tbCurStatus.TextChanged
        PlayState()
    End Sub

End Class
