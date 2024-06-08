namespace TextPlus_BE.Setting
{
    public interface IDbSettings
    {
        string? ConnectionString { get; set; }
        string? DataBaseName { get; set; }
    }
}
