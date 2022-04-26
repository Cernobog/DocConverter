using DocConverter.Core.Adapters;
using System.Linq;
using System.Xml;
using Xunit;

namespace DocConverter.UnitTests.Adapters
{
    public class XML2JsonAdapterTests
    {
        private const string validXmlWithHeader = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <note>
              <to>Tove</to>
              <from>Jani</from>
              <heading>Reminder</heading>
              <body>Don't forget me this weekend!</body>
            </note>";
        private const string validXmlWithoutHeader = @"<note>
              <to>Tove</to>
              <from>Jani</from>
              <heading>Reminder</heading>
              <body>Don't forget me this weekend!</body>
            </note>";
        private const string invalidXml = @"<to>Tove</to>
              <from>Jani</from>
              <heading>Reminder</heading>
              <body>Don't forget me this weekend!</body>
            </note>";
        private const string jsonWithHeader = @"
            {
              "" ? xml"": {
                ""@version"": ""1.0"",
                ""@encoding"": ""UTF-8""
              },
              ""note"": {
                ""to"": ""Tove"",
                ""from"": ""Jani"",
                ""heading"": ""Reminder"",
                ""body"": ""Don't forget me this weekend!""
              }
            }";
        private const string jsonWithoutHeader = @"
            {
              ""note"": {
                ""to"": ""Tove"",
                ""from"": ""Jani"",
                ""heading"": ""Reminder"",
                ""body"": ""Don't forget me this weekend!""
              }
            }";


        [Fact]
        public void ValidXmlWithHeader_Convert_ShouldBeConvertedWithHeader()
        {
            var adapter = new XML2JsonAdapter(true);
            var result = adapter.Convert(validXmlWithHeader);

            Assert.Equal(NormalizeDocument(jsonWithHeader), NormalizeDocument(result));
        }

        [Fact]
        public void ValidXmlWithHeader_Convert_ShouldBeConvertedWithoutHeader()
        {
            var adapter = new XML2JsonAdapter(false);
            var result = adapter.Convert(validXmlWithHeader);

            Assert.Equal(NormalizeDocument(jsonWithoutHeader), NormalizeDocument(result));
        }

        [Fact]
        public void ValidXmlWithoutHeader_Convert_ShouldBeConvertedWithoutHeader()
        {
            var adapter = new XML2JsonAdapter(true);
            var result = adapter.Convert(validXmlWithoutHeader);

            Assert.Equal(NormalizeDocument(jsonWithoutHeader), NormalizeDocument(result));
        }

        [Fact]
        public void ValidXmlWithoutHeader1_Convert_ShouldBeConvertedWithoutHeader()
        {
            var adapter = new XML2JsonAdapter(false);
            var result = adapter.Convert(validXmlWithoutHeader);

            Assert.Equal(NormalizeDocument(jsonWithoutHeader), NormalizeDocument(result));
        }

        [Fact]
        public void InvalidXml_Convert_ExceptionShouldBeThrownOut()
        {
            var adapter = new XML2JsonAdapter(false);
            Assert.Throws<XmlException>(() => adapter.Convert(invalidXml));
        }



        private static string NormalizeDocument(string text)
        {
            return string.Concat(text.Where(c => !char.IsWhiteSpace(c)));
        }
    }
}
