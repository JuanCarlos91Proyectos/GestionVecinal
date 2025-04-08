using GestionVecinal.Models.DTO;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace GestionVecinal.Models.ViewModels
{
    public partial class CommunitySelectViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private List<ComunidadDTO> _comunidades = [];
        public List<ComunidadDTO> Comunidades { get { return _comunidades; } set { _comunidades = value; OnPropertyChanged(nameof(Comunidades)); }
        }
        public CommunitySelectViewModel(AppSettings appSettings) : base(appSettings)
        {
        }

        public Button AddCommunityButton(ComunidadDTO comunidadDTO)
        {
            Button button = CreateButton(comunidadDTO.Direccion, "#FF0000", (Microsoft.Maui.Graphics.Color)Application.Current.Resources["White"], comunidadDTO.Id.ToString()); 
            //button.Clicked += Button_Clicked;
            button.Pressed += Button_Focused;
            button.Released += Button_Unfocused;

            return button;
        }

        public Button AddNewCommunityButton()
            => CreateButton("+ Añadir nueva comunidad", "#4CAF50", (Microsoft.Maui.Graphics.Color)Application.Current.Resources["PrimaryPlus"], "");
        public Button CreateButton(string text, string background, Microsoft.Maui.Graphics.Color color, string id)
        {
            return new()
            {
                Text = text,
                TextColor = color,
                BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb(background),
                Padding = new Thickness(10, 20),
                WidthRequest = 120,
                HeightRequest = 100,
                Margin = new Thickness(10),
                FontSize = 14,
                LineBreakMode = LineBreakMode.WordWrap,
                FontAttributes = FontAttributes.Bold,
                ClassId = id
            };
        }

        

        private void Button_Focused(object sender, EventArgs e)
        {
            // Manejar el evento PointerEntered del botón
            Button button = (Button)sender;
            VisualStateManager.GoToState(button, "Focused");
            button.BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb("#4CAF50");
            button.WidthRequest = button.Width * 1.5;
            button.HeightRequest = button.Height * 1.5;
        }

        private void Button_Unfocused(object sender, EventArgs e)
        {
            // Manejar el evento PointerEntered del botón
            Button button = (Button)sender;
            VisualStateManager.GoToState(button, "Normal");
            button.BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb("#FF0000");
            button.WidthRequest = button.Width / 3 * 2;
            button.HeightRequest = button.Height / 3 * 2;
        }
    }
}
