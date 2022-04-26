using DocConverter.Core;
using DocConverter.Core.Adapters;
using DocConverter.Core.ExportProviders;
using DocConverter.Core.ImportProviders;

var import = new TextFileImportProvider(Path.Combine(AppContext.BaseDirectory, @"..\..\..\ExampleDocuments\source.xml"));
var export = new TextFileExportProvider(Path.Combine(AppContext.BaseDirectory, @"..\..\..\ExampleDocuments\output.json")); 
var adapter = new XML2JsonAdapter(false);

var convert = new DocConvert();
await convert.ConvertAsync(import, adapter, export);

