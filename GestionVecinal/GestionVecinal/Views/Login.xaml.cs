namespace GestionVecinal.Views;

public partial class Login : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    public Login(IServiceProvider serviceProvider)
	{
        _serviceProvider = serviceProvider;
        InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // Aquí puedes agregar la lógica para validar el usuario y contraseña
        if (username == "admin" && password == "1234") // Ejemplo básico
        {

            var mainPage = _serviceProvider.GetService<MainPage>();
            await Navigation.PushAsync(mainPage);
        }
        else
        {
            ErrorMessage.Text = "Usuario o contraseña incorrectos";
            ErrorMessage.IsVisible = true;
        }
    }
}