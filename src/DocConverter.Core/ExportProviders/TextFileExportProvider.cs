using DocConverter.Core.Interfaces;

namespace DocConverter.Core.ExportProviders;

public class TextFileExportProvider : IExportProvider
{
    private readonly string filename;

    public TextFileExportProvider(string filename)
    {
        this.filename = filename;
    }

    public async Task ExportAsync(string data)
    {
        using var outputFile = new StreamWriter(filename);
        await outputFile.WriteAsync(data);
    }
}
