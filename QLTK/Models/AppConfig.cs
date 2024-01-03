namespace QLTK.Models;

public class AppConfig
{
    public string ModDataFolder { get; set; }

    public string PathAccounts { get; set; }

    public string PathSettings { get; set; }

    public string PathGame { get; set; }

    public int PortListener { get; set; }

    public string LinkNotification { get; set; }

    public string LinkHash { get; set; }

    public SaveSettings DefaultSaveSettings { get; set; }
}
