using GestionVecinal.Models.DTO;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using GestionVecinal.Models;
using GestionVecinal.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestionVecinal.ViewModels
{
    public interface IAddCommunityWindowService
    {
        void OpenAddCommunityWindow(Action onClose);
    }

    public partial class CommunitySelectViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private List<ComunidadDTO> _comunidades = [];
        public List<ComunidadDTO> Comunidades { 
            get { return _comunidades; } 
            set { _comunidades = value; OnPropertyChanged(nameof(Comunidades)); }
        }

        private ObservableCollection<Button> _communityButtons = new();
        public ObservableCollection<Button> CommunityButtons
        {
            get => _communityButtons;
            set { _communityButtons = value; OnPropertyChanged(nameof(CommunityButtons)); }
        }

        private string _addNewCommunityText;
        public string AddNewCommunityText
        {
            get => _addNewCommunityText;
            set { _addNewCommunityText = value; OnPropertyChanged(nameof(AddNewCommunityText)); }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set { _isVisible = value; OnPropertyChanged(nameof(IsVisible)); }
        }

        private bool _isVisibleBusyMessage;
        public bool IsVisibleBusyMessage
        {
            get => _isVisibleBusyMessage;
            set { _isVisibleBusyMessage = value; OnPropertyChanged(nameof(IsVisibleBusyMessage)); }
        }


        public ICommand LoadButtonsCommand { get; }
        public ICommand AddNewCommunityCommand { get; }
        public ICommand ViewCommunityCommand { get; }
        public ICommand ButtonFocusCommand { get; }
        public ICommand ButtonUnfocusCommand { get; }
        public event Action? OnAddCommunityClosed;
        private readonly IComunidadesService _comunidadesService;
        private readonly IAddCommunityWindowService _addCommunityWindowService;
        public CommunitySelectViewModel(AppSettings appSettings,
            IServiceProvider serviceProvider,
            INavigationService navigationService,
            IComunidadesService comunidadesService,
            IAddCommunityWindowService addCommunityWindowService)
            : base(appSettings, serviceProvider, navigationService)
        {
            LoadButtonsCommand = new Command(async () => await LoadButtonsAsync());
            AddNewCommunityCommand = new Command(HandleAddNewCommunity);
            ViewCommunityCommand = new Command<int>(async (comunidadId) => await HandleViewComunidad(comunidadId));
            ButtonFocusCommand = new Command<Button>(button => Button_Focused(button, EventArgs.Empty));
            ButtonUnfocusCommand = new Command<Button>(button => Button_Unfocused(button, EventArgs.Empty));
            _comunidadesService = comunidadesService;
            _addCommunityWindowService = addCommunityWindowService;
        }

        public async Task LoadButtonsAsync()
        {
            CommunityButtons.Clear();
            IsVisible = false;
            Comunidades = await this._comunidadesService.GetAsync();
            foreach (var comunidad in Comunidades)
            {
                Button comunidadButton = AddCommunityButton(comunidad);
                comunidadButton.Command = ViewCommunityCommand;
                comunidadButton.CommandParameter = comunidad.Id;
                CommunityButtons.Add(comunidadButton);
            }
            Button newCommunityButton = AddNewCommunityButton(AddNewCommunityText);
            newCommunityButton.Command = AddNewCommunityCommand;
            CommunityButtons.Add(newCommunityButton);
            IsVisible = true;
        }

        public Button AddCommunityButton(ComunidadDTO comunidadDTO)
        {
            Button button = CreateButton(comunidadDTO.Direccion, "#FF0000", (Microsoft.Maui.Graphics.Color)Application.Current.Resources["White"], comunidadDTO.Id.ToString()); 
            return button;
        }

        public Button AddNewCommunityButton(string text)
            => CreateButton(text, "#4CAF50", (Microsoft.Maui.Graphics.Color)Application.Current.Resources["White"], "");
        public Button CreateButton(string text, string background, Microsoft.Maui.Graphics.Color textColor, string id)
        {
            return new()
            {
                Text = text,
                TextColor = textColor,
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

        private void HandleAddNewCommunity()
        {
            _addCommunityWindowService.OpenAddCommunityWindow(() =>
            {
                // Esto dispara el evento para que la Vista sepa que debe refrescar
                OnAddCommunityClosed?.Invoke();
            });
        }

        private async Task HandleViewComunidad(int comunidadId)
        {
            await _navigationService.GoToAsync("ViewComunidad", new Dictionary<string, object> { ["comunidadId"] = comunidadId });
        }
    }
}
