 Sub listar_Rep_Registro()
        Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dtsdatos As New DataTable
        Dim obj As New ClsRegistro
        Try
            rds.Name = "DataSet3"
            dtsdatos = obj.Listar_Registro_Dos.Tables(0)
            If dtsdatos.Rows.Count > 0 Then
                rds.Value = dtsdatos
                RepRegistro.LocalReport.DataSources.Clear()
                RepRegistro.LocalReport.DataSources.Add(rds)
                'RepRegistro.LocalReport.ReportPath = "C:\Users\SaloNet\Documents\Visual Studio 2015\Projects\prueba\prueba\Rep_Registros2.rdlc"
                RepRegistro.LocalReport.ReportPath = "C:\inetpub\SisRegistro\Rep_Registros.rdlc"
                RepRegistro.DataBind()
            Else
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub