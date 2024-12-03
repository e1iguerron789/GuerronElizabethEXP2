using System.IO;
using Microsoft.Maui.Controls;
namespace GuerronElizabethEXP2;

public partial class StackLayout : ContentPage
{
	public StackLayout()
	{
		InitializeComponent();
	}
    private async void JBtn_Recargar_ClickEGuerron(object sender, EventArgs e)
    {
        string numero = JTex_NumeroEGuerron.Text;
        string nombre = JTex_NombreEGuerron.Text;

        if (string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(nombre))
        {
            await DisplayAlert("Error", "Por favor, ingrese todos los datos.", "OK");
            return;
        }

        if (numero.Length != 10 || !long.TryParse(numero, out _))
        {
            await DisplayAlert("Error", "El número de teléfono debe tener 10 dígitos válidos.", "OK");
            return;
        }

        string fileName = $"{nombre.Replace(" ", "")}.txt";
        string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
        File.WriteAllText(filePath, $"Nombre: {nombre}\nNúmero: {numero}");
        await DisplayAlert("Recarga Exitosa", "La recarga se realizó correctamente.", "OK");
        JLbl_ResumenEGuerron.Text = $"La última recarga realizada fue:\nNombre: {nombre}\nNúmero: {numero}";
        JTex_NumeroEGuerron.Text = string.Empty;
        JTex_NombreEGuerron.Text = string.Empty;
    }
}
