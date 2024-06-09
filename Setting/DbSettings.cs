using TextPlus_BE.Setting;

namespace TextPlus_BE;

public class DbSettings : IDbSettings
{
    public string? ConnectionString { get; set; }
    public string? DataBaseName { get; set; }
}
