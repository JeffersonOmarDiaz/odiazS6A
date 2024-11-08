using Newtonsoft.Json;
using odiazS7.Models;
using System.Collections.ObjectModel;

namespace odiazS7.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.17.52/uisraelws/estudiante.php";
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
        lvEstudiantes.ItemsSource = estud;

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
}