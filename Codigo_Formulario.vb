Public Class DDD
    Inherits System.Web.UI.Page
    Dim obj As New ClsAlumos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CargarComboCarrera()
            Call CargarComboSemestre()
        End If
        Call listar()
    End Sub
    Sub listar()
        gwAlumno.DataSource = obj.Listar_Alumno.Tables(0)
        gwAlumno.DataBind()
    End Sub
    Sub Listar_Alumno_Modificar()
        '--Mostrar datos en caja de texto
        Dim dt As New DataTable
        dt = obj.Listar_Alumno_Buscar(txtId.Text).Tables(0)
        txtNombre.Text = dt.Rows(0)(1).ToString
        txtApellido.Text = dt.Rows(0)(2).ToString
        txtDireccion.Text = dt.Rows(0)(3).ToString
        DroCarrera.SelectedValue = dt.Rows(0)(4).ToString
        DroSemestre.SelectedValue = dt.Rows(0)(5).ToString
    End Sub

    Sub CargarComboCarrera()
        Dim dtcombo As New DataTable
        dtcombo = obj.Listar_Carrera_Combo.Tables(0)
        Me.DroCarrera.DataSource = dtcombo
        Me.DroCarrera.DataValueField = "idcarrera"
        Me.DroCarrera.DataTextField = "descripcion"
        Me.DroCarrera.DataBind()
    End Sub
    Sub CargarComboSemestre()
        Dim dtcombo As New DataTable
        dtcombo = obj.Listar_Semestre_Combo.Tables(0)
        Me.DroSemestre.DataSource = dtcombo
        Me.DroSemestre.DataValueField = "idsemestre"
        Me.DroSemestre.DataTextField = "descripcion"
        Me.DroSemestre.DataBind()
    End Sub
    Sub limpiar()
        txtId.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDireccion.Text = ""
        txtAlertaEliminar.Visible = False
        txtAlertaModificar.Visible = False
        txtAlertaGuardar.Visible = False
    End Sub
    'SELECCIONAR REGISTRO PARA AMOSTRAR en las cajas de texto
    Protected Sub gwDocente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gwAlumno.SelectedIndexChanged
        Dim row As GridViewRow = gwAlumno.SelectedRow
        Dim id As Integer = Convert.ToInt32(gwAlumno.DataKeys(row.RowIndex).Value)
        txtId.Text = id
        Call Listar_Alumno_Modificar()
    End Sub
    'SELECCIONAR PAGINA DE LA GRILLA
    Private Sub gwDocente_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwAlumno.PageIndexChanging
        gwAlumno.PageIndex = e.NewPageIndex
        Call listar()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        
                obj.Insertar_Alumno(txtNombre.Text, txtApellido.Text, txtDireccion.Text, DroCarrera.SelectedValue, DroSemestre.SelectedValue)
                Call limpiar()
                listar()
              
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
      
                obj.Actualizar_Alumno(txtNombre.Text, txtApellido.Text, txtDireccion.Text, DroCarrera.SelectedValue, DroSemestre.SelectedValue, txtId.Text)
               
                Call listar()
                Call limpiar()
             
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
       
            obj.Eliminar_Alumno(txtId.Text)
            Call limpiar()
            listar()

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        txtId.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDireccion.Text = ""
        txtAlertaEliminar.Visible = False
    End Sub
    Protected Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        Call listar()
    End Sub
End Class