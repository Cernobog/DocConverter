namespace DocConverter.Core.Interfaces;

public interface IImportProvider
{
    Task<string> ImportAsync();
}
