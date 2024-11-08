using odiazS7.Models;

namespace odiazS7.Views;

public partial class vActualizarElim : ContentPage
{
	public vActualizarElim(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

    }
}