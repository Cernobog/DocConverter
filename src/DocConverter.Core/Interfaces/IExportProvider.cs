namespace DocConverter.Core.Interfaces;

public interface IExportProvider
{
    Task ExportAsync(string data);
}
