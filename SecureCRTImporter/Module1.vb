Imports System.IO
Imports System.Text



Module Module1
    Dim table As DataTable = InitializeTableColumns()

    Sub Main()
        ReadCSV()

    End Sub

    Sub ReadCSV()

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\Utils\SecureCRT Project\Report_IOS_Versions_of_Cisco_Devices.csv")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            Dim x As Integer = 0
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    'For Each currentField In currentRow
                    If x > 2 Then
                        Dim newrow As DataRow = table.NewRow
                        newrow("Name") = currentRow(0)
                        newrow("IP Address") = currentRow(1)
                        newrow("Machine Type") = currentRow(2)
                        newrow("Type") = Whattype(currentRow(2), currentRow(0))
                        table.Rows.Add(newrow)
                    End If
                    x += 1
                    'Next
                Catch ex As Microsoft.VisualBasic.
                            FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub
    Function InitializeTableColumns() As DataTable
        Dim table As New DataTable
        ' Create four typed columns in the DataTable.
        table.Columns.Add("Name", GetType(String))
        table.Columns.Add("IP Address", GetType(String))
        table.Columns.Add("Machine Type", GetType(String))
        table.Columns.Add("Type", GetType(String))

        Return table
    End Function
    Function Whattype(name As String, name2 As String) As String
        Dim Device_Type As String = "Error"

        If name.Contains("Catalyst") Or name.Contains("Catalyst") Then
            Device_Type = "Switch"
        ElseIf name.Contains("ISR") Or name.Contains("3925") Then
            Device_Type = "Router"
        ElseIf name.Contains("ASA") Then
            Device_Type = "Firewall"
        ElseIf name.Contains("Cisco") Then
            If name2.Contains("ASR") Then
                Device_Type = "Router"
            End If
            If name2.Contains("N9") Then
                Device_Type = "Nexus 9K"
            End If
        End If

        Return Device_Type
    End Function

End Module


