using GestionVecinal.Models.DTO;
using GestionVecinal.Services;

namespace GestionVecinal.Views;

public partial class CommunitySelect : ContentPage
{
    public List<ComunidadDTO> _comunidades;
    private readonly IComunidadesService _comunidadesService;
    public CommunitySelect(IComunidadesService comunidadesService)
    {
        this._comunidades = new List<ComunidadDTO>();
        this._comunidadesService = comunidadesService;
        OnStart();
        InitializeComponent();
    }

    private async Task OnStart()
    {
        this._comunidades = await this.GetComunidades();
        foreach (var comunidad in this._comunidades)
        {
            this.ComunidadesPicker.Children.Add(AddCommunityButton(comunidad));
        }
        this.ComunidadesPicker.Children.Add(AddNewCommunityButton());
    }

    private Button AddCommunityButton(ComunidadDTO comunidadDTO)
    {
        Button button = CreateButton(comunidadDTO.Direccion, "#FF0000"); ;
        button.Clicked += Button_Clicked;
        button.Pressed += Button_Focused;
        button.Released += Button_Unfocused;

        return button;
    }

    private Button AddNewCommunityButton()
        => CreateButton("+ Añadir nueva comunidad", "#4CAF50");
    private Button CreateButton(string text, string background)
        => new Button
        {
            Text = text,
            TextColor = Color.FromArgb("#AAAAAA"),
            BackgroundColor = Color.FromArgb(background),
            Padding = new Thickness(10, 20),
            WidthRequest = 120,
            HeightRequest = 100,
            Margin = new Thickness(10),
            FontSize = 14,
            LineBreakMode = LineBreakMode.WordWrap,
            FontAttributes = FontAttributes.Bold
        };
    
    private void Button_Clicked(object sender, EventArgs e)
    {
        // Manejar el evento Click del botón
        Button button = (Button)sender;
        Console.WriteLine($"Se ha hecho clic en el botón: {button.Text}");
    }

    private void Button_Focused(object sender, EventArgs e)
    {
        // Manejar el evento PointerEntered del botón
        Button button = (Button)sender;
        VisualStateManager.GoToState(button, "Focused");
        button.BackgroundColor = Color.FromArgb("#4CAF50");
        button.WidthRequest = button.Width * 1.5;
        button.HeightRequest = button.Height * 1.5;
    }

    private void Button_Unfocused(object sender, EventArgs e)
    {
        // Manejar el evento PointerEntered del botón
        Button button = (Button)sender;
        VisualStateManager.GoToState(button, "Normal");
        button.BackgroundColor = Color.FromArgb("#FF0000");
        button.WidthRequest = button.Width / 3 * 2;
        button.HeightRequest = button.Height / 3 * 2;
    }

    private async Task<List<ComunidadDTO>> GetComunidades()
    {
        List<ComunidadDTO> result = await this._comunidadesService.GetComunidades();
        return result;
    }
}
