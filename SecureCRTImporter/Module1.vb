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
                        newrow("Type") = currentRow(2)
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
        table.Columns.Add("Type", GetType(String))

        Return table
    End Function
End Module


