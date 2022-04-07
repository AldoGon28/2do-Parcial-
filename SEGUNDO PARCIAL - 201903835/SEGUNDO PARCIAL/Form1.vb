Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tipo As String
        tipo = ComboBox1.Text
        Dim c1, c2, c3 As Integer
        Dim total
        c1 = Val(TextBox1.Text)
        c2 = Val(TextBox2.Text)
        c3 = Val(TextBox3.Text)
        Select Case tipo
            Case "1ra Clase"
                total = (c1 * 50) + (c2 * 35) + (c3 * 70)
            Case "2da Clase"
                total = (c1 * 40) + (c2 * 25) + (c3 * 55)
            Case "3ra Clase"
                total = (c1 * 25) + (c2 * 10) + (c3 * 25)
        End Select
        Dim desc1, desc2 As Double
        If c1 + c2 + c3 > 10 Then
            desc1 = total * 0.1
        End If
        If c1 > 0 And c2 > 0 And c3 > 0 Then
            desc2 = total * 0.05
        End If
        Dim descT As Double
        descT = Math.Round(desc1 + desc2, 2)
        ManejoBD.Registrar(total, descT, (total - descT))
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.Text = 0
            TextBox1.Visible = True
        Else
            TextBox1.Text = 0
            TextBox1.Visible = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox2.Text = 0
            TextBox2.Visible = True
        Else
            TextBox2.Text = 0
            TextBox2.Visible = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            TextBox3.Text = 0
            TextBox3.Visible = True
        Else
            TextBox3.Text = 0
            TextBox3.Visible = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If estadoBD = False Then
            Try
                Conexion.ConnectionString = Cadena
                Conexion.Open()
                estadoBD = True
            Catch ex As Exception
                MsgBox("No se pudo conectar a la base de datos" & vbCrLf & ex.ToString())
            End Try
        Else
            MsgBox("La base de datos ya fue conectada previamente")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        ComboBox1.Text = ""
        MsgBox("Se limpiaron los datos exitosamente")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Pregunta As String
        Pregunta = MsgBox("¿Esta seguro de continua?", vbYesNo + vbQuestion, "PARCIAL 2")
        If Pregunta = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Reporte.Show()
    End Sub
End Class
