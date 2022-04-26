using DocConverter.Core.Interfaces;

namespace DocConverter.Core
{
    public class DocConvert : IDocConvert
    {
        public async Task ConvertAsync(IImportProvider importProvider, IConvertAdapter adapter, IExportProvider exportProvider)
        {
            var inputDoc = await importProvider.ImportAsync();
            var convertedDoc = adapter.Convert(inputDoc);
            await exportProvider.ExportAsync(convertedDoc);
        }
    }
}
