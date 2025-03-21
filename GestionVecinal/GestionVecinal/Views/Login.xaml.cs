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

            var page = _serviceProvider.GetService<CommunitySelect>();
            await Navigation.PushAsync(page);
        }
        else
        {
            ErrorMessage.Text = "Usuario o contraseña incorrectos";
            ErrorMessage.IsVisible = true;
        }
    }
}