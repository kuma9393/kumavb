Imports System.IO
Imports System.Text

Public Class Form1
    ' グローバルにプロセスを保持する
    Private proc As Process


    Private Sub 画像チェック_Click(sender As Object, e As EventArgs) Handles 画像チェック.Click
        Try
            Label1.Text = "aaa"
            Dim DateFile As String
            DateFile = TextBox1.Text
            If DateFile.Length <> 8 Then
                MessageBox.Show("日付は8桁で入力してください")
                Return
            End If

            RunAnalysisAsync(DateFile)


        Catch ex As Exception
            MessageBox.Show("実行時エラー: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    ///////
    Private Async Sub RunAnalysisAsync(DateFile As String)
        ' 実行するEXEファイルのフルパス
        Dim exePath As String = "C:\画像検査AI\dist\analysis.exe"

        ' ProcessStartInfoを使ってプロセスを設定
        Dim psi As New ProcessStartInfo()
        psi.FileName = exePath
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True ' コンソールウィンドウを表示しない
        psi.Arguments = DateFile

        ' プロセスを開始
        proc = Process.Start(psi)
        ///////
        ' 出力とエラーを非同期で読み取る
        Dim outputTask As Task(Of String) = proc.StandardOutput.ReadToEndAsync()
        Dim errorTask As Task(Of String) = proc.StandardError.ReadToEndAsync()

        ' プロセスの終了を待機
        Await Task.Run(Sub() proc.WaitForExit())

        ' 出力結果を取得
        Dim output As String = Await outputTask
        Dim errorOutput As String = Await errorTask

        ' プロセスの終了コードを取得
        Dim exitCode As Integer = proc.ExitCode

        If exitCode = 0 Then
            ' 出力を表示
            MessageBox.Show("画像チェックが完了しました")

        Else
            ' 停止出力を表示
            MessageBox.Show("画像チェックが停止しました")
        End If
        ///////
            

        'MessageBox.Show("出力:" & vbCrLf & output, "実行結果")


        If Not String.IsNullOrWhiteSpace(errorOutput) Then
            MessageBox.Show("エラー:" & vbCrLf & errorOutput, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub データ表示_Click(sender As Object, e As EventArgs) Handles データ表示.Click
        ' 固定ファイルパス
        Dim filePath As String = "C:\画像検査AI\画像検査AI\output.csv"

        ' ファイルの存在確認
        If Not File.Exists(filePath) Then
            MessageBox.Show("CSVファイルが見つかりません。" & vbCrLf & filePath, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' CSVをすべての行として読み込む（Shift-JISなども可）
            Dim lines() As String = File.ReadAllLines(filePath, Encoding.UTF8)

            ' 空チェック
            If lines.Length = 0 Then
                MessageBox.Show("CSVファイルが空です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' DataGridView 初期化
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            ' ヘッダ（1行目）
            Dim headers() As String = lines(0).Split(","c)
            ' No列を最初に追加
            DataGridView1.Columns.Add("No", "No")
            For Each header As String In headers
                DataGridView1.Columns.Add(header, header)
            Next

            ' データ行
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    Dim values() As String = lines(i).Split(","c)

                    ' 最初の列にNo（連番）を追加するため、新しい配列を作る
                    Dim newRow(values.Length) As String ' 元の +1列分のサイズ
                    newRow(0) = i.ToString() ' No列（1から始まる）

                    ' 残りのデータをコピー
                    For j As Integer = 0 To values.Length - 1
                        newRow(j + 1) = values(j)
                    Next

                    DataGridView1.Rows.Add(newRow)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("読み込みエラー：" & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' フォームロード時に現在の日付を表示
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = DateTime.Now.ToString("yyyyMMdd") ' yyyy/MM/dd形式で表示
    End Sub

    ///////
    Private Sub btnstop_Click(sender As Object, e As EventArgs) Handles btnstop.Click
        ProcessKiller()
    End Sub

    Private Sub ProcessKiller()
        ' 停止したいプロセスの名前を定義
        Const TargetProcessName As String = "analysis" ' .exeは含めない
        ' 指定したプロセス名で実行中のすべてのプロセスを取得
        Dim processes As Process() = Process.GetProcessesByName(TargetProcessName)

        If processes.Length > 0 Then
            ' プロセスが見つかった場合、それぞれを強制終了
            For Each p As Process In processes
                Try
                    p.Kill()
                    Console.WriteLine($"{p.ProcessName} プロセスを停止しました。")
                Catch ex As Exception
                    Console.WriteLine($"プロセス {p.ProcessName} の停止中にエラーが発生しました: {ex.Message}")
                End Try
            Next
        Else
            Console.WriteLine($"{TargetProcessName} というプロセスは見つかりませんでした。")
        End If
    End Sub
    ///////
End Class
