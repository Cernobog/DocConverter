using DocConverter.Core.Interfaces;
using System.Text;

namespace DocConverter.Core.ImportProviders;

public class TextFileImportProvider : IImportProvider
{
    private readonly string filename;

    public TextFileImportProvider(string filename)
    {
        this.filename = filename;
    }

    public async Task<string> ImportAsync()
    {
        using var fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        using var sr = new StreamReader(fs, Encoding.UTF8);

        return await sr.ReadToEndAsync();
    }
}
