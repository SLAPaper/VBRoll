Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim text As String = Nothing
        Dim random As Random = New Random
        Try
            Dim query As String = Me.TextBox1.Text
            Dim front, back, back2, description As String
            Dim times, count, faces, addend As UInteger

            Dim l1 As String() = Nothing
            l1 = query.Split("d".ToCharArray, 2)
            front = l1(0)
            back = l1(1)

            If front.Contains("#") Then
                Dim l21 As String() = Nothing
                l21 = front.Split("#")
                times = isNumeric(l21(0))
                count = isNumeric(l21(1))
            Else
                times = 1
                count = isNumeric(front)
            End If
            If IsNothing(times) Then
                times = 1
            End If
            If IsNothing(count) Then
                count = 1
            End If

            If back.Contains(" ") Then
                Dim l22 As String() = Nothing
                l22 = back.Split(" ".ToCharArray, 2)
                back2 = l22(0)
                description = l22(1)
            Else
                back2 = back
                description = Nothing
            End If

            If back2.Contains("+") Then
                Dim l31 As String() = Nothing
                l31 = back2.Split("+")
                faces = isNumeric(l31(0))
                addend = isNumeric(l31(1))
            Else
                faces = isNumeric(back2)
                addend = 0
            End If
            If IsNothing(faces) Then
                faces = 20
            End If
            If IsNothing(addend) Then
                addend = 0
            End If

            Dim result As List(Of UInteger) = New List(Of UInteger)
            For i As Integer = 0 To times - 1
                Dim dice_sum As UInteger = 0
                For j As Integer = 0 To count - 1
                    dice_sum += random.Next(faces)
                Next
                dice_sum += addend + 1
                result.Add(dice_sum)
            Next
            Dim s As String = ""
            For Each num As UInteger In result
                s = s + Convert.ToString(num) + ", "
            Next
            text = s + " " + description
        Catch ex As Exception
            text = random.Next(20) + 1
        End Try

        Me.TextBox2.Text = text
    End Sub

    Function isNumeric(ByVal s As String) As UInteger
        Dim flag As Boolean = True
        For Each c As Char In s
            If Not Char.IsDigit(c) Then
                flag = False
                Exit For
            End If
        Next
        If flag Then
            Return Convert.ToDecimal(s)
        Else
            Return Nothing
        End If
    End Function
End Class
