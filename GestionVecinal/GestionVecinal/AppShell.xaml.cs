using GestionVecinal.Views;

namespace GestionVecinal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        public void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(CommunitySelect), typeof(CommunitySelect));
            Routing.RegisterRoute(nameof(ViewComunidad), typeof(ViewComunidad));
        }
    }
}
