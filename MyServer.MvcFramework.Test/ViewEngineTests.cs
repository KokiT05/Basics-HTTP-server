using MyServer.MvcFramework.ViewEngines;
using System.Reflection.Metadata;

namespace MyServer.MvcFramework.Test
{
    public class ViewEngineTests
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        public void TetGetHtmlMethod(string fileName)
        {
            TestViewModel testViewModel = new TestViewModel()
            {
                DateOfBirth = new DateTime(2023, 2, 20),
                Name = "Doggo Arghentino",
                Price = 12345.67M,
            };

            IViewEngine viewEngine = new ViewEngine();
            var view = File.ReadAllText($@"ViewTests/{fileName}.html");
            var result = viewEngine.GetHtml(view, testViewModel);
            var expectedResult = File.ReadAllText($@"ViewTest/{fileName}Reult.html");
            Assert.Equal(expectedResult, result);
        }

        public class TestViewModel
        {
            public decimal Price { get; set; }

            public string Name { get; set; }

            public DateTime DateOfBirth { get; set; }
        }
    }
}