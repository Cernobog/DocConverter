using DocConverter.Core.ImportProviders;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DocConverter.IntegrationTests.ImportProviders
{
    public class TextFileImportProviderTests
    {
        [Fact]
        public async Task FileExists_ImportAsync_ShouldReturnAllData()
        {
            var importProvider = new TextFileImportProvider(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data\textfile.txt"));
            var result = await importProvider.ImportAsync();
            Assert.Equal("hello\r\nworld", result);
        }

        [Fact]
        public async Task FileNotExists_ImportAsync_ShouldThowException()
        {
            var importProvider = new TextFileImportProvider(Path.Combine(AppContext.BaseDirectory, @"..\..\..\nonExistsFile.txt"));
            await Assert.ThrowsAsync<FileNotFoundException>(() => importProvider.ImportAsync());
            
        }

    }
}
