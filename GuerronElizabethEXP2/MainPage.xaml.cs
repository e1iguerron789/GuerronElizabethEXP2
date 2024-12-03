namespace GuerronElizabethEXP2
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            string nombre = "Elizabeth";
            string apellido = "Guerron";
            string folderName = nombre + apellido;
            string folderPath = Path.Combine(FileSystem.AppDataDirectory, folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = folderName + ".txt";
            string filePath = Path.Combine(folderPath, fileName);
            string recargaInfo = "Información de la recarga es: $100.00\nFecha es: " + DateTime.Now;

            await File.WriteAllTextAsync(filePath, recargaInfo);
            await DisplayAlert("Éxito", "La información se ha guardado correctamente en " + filePath, "OK");
        }
    }

}
