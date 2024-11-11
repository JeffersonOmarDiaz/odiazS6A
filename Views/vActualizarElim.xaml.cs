using odiazS7.Models;
using System.Net;

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

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        WebClient client = new WebClient();
        var parametros = new System.Collections.Specialized.NameValueCollection();
        parametros.Add("nombre", txtNombre.Text);
        parametros.Add("apellido", txtApellido.Text);
        parametros.Add("edad", txtEdad.Text);
        string urlput = "http://192.168.3.108/uisraelws/estudiante.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text;
        client.UploadValues(urlput, "PUT", parametros);
        await Navigation.PushAsync(new vEstudiante());
        await DisplayAlert("Exito", "Actualizado correctamente", "Aceptar");
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Eliminar", "¿Está seguri que desea eliminar este elemento?", "Eliminar", "Cancelar");
        if(result)
        {
            try
            {
                WebClient client = new WebClient();
                string urldelete = "http://192.168.3.108/uisraelws/estudiante.php?codigo=" + txtCodigo.Text;

                // Realizar la petición DELETE
                client.UploadValues(urldelete, "DELETE", new System.Collections.Specialized.NameValueCollection());

                await DisplayAlert("Éxito", "Eliminado correctamente", "Aceptar");

                // Navegar de vuelta a la vista principal
                await Navigation.PushAsync(new vEstudiante());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrió un error al eliminar: " + ex.Message, "Aceptar");
            }
            await DisplayAlert("Eliminar", "Eliminado correctamente", "Aceptar");
        }
    }
}