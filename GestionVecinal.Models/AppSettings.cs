namespace GestionVecinal.Models
{
    public class AppSettings
    {
        public string Admin { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Labels Labels { get; set; } = new Labels();
        public Errors Errors { get; set; } = new Errors();
        public Placeholders Placeholders { get; set; } = new Placeholders();
    }

    public class Labels
    {
        public string Welcome { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string OpenedNewCommunityWindow { get; set;} = string.Empty;
        public ViewComunidadLabels ViewComunidadLabels { get; set; } = new ViewComunidadLabels();

    }

    public class ViewComunidadLabels
    {
        public string Comunidad { get; set; } = string.Empty;
        public string Miembros { get; set; } = string.Empty;
        public string Facturas { get; set; } = string.Empty;
        public string Proveedores { get; set; } = string.Empty;
        public string Juntas { get; set; } = string.Empty;
        public string Derramas { get; set; } = string.Empty;
        public string Incidencias { get; set; } = string.Empty;
        public string Presidentes { get; set; } = string.Empty;
    }

    public class Errors
    {
        public string Required { get; set; } = string.Empty;
        public string MinLength { get; set; } = string.Empty;
        public string MaxLength { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Compare { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
    }

    public class Placeholders
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
