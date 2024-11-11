using Newtonsoft.Json;
using odiazS7.Models;
using System.Collections.ObjectModel;

namespace odiazS7.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.3.108/uisraelws/estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;

    public vEstudiante()
	{
		InitializeComponent();
		mostrar();
	}

	public async void mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
        //lvEstudiantes.ItemsSource = estud;
        gvEstudiantes.ItemsSource = estud;

    }

    private void btnIsertar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vInsertar());
    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizarElim(objEstudiante));
    }

    private void gvEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //var objEstudiante = (Estudiante)e.CurrentSelection;
        var estudianteSeleccionado = e.CurrentSelection.FirstOrDefault() as Estudiante;
        if (estudianteSeleccionado != null)
        {
            Navigation.PushAsync(new vActualizarElim(estudianteSeleccionado));
        }

    // Limpiar la selecci�n despu�s de manejarla
    ((CollectionView)sender).SelectedItem = null;
    }
}