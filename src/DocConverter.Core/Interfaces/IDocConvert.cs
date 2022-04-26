namespace DocConverter.Core.Interfaces
{
    public interface IDocConvert
    {
        Task ConvertAsync(IImportProvider importProvider, IConvertAdapter adapter, IExportProvider exportProvider);
    }
}