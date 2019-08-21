using NUnit.Framework;

namespace ReactNet.Controllers
{
    [TestFixture]
    public class SampleDataControllerTests
    {
        [Test]
        public void SampleDataTests()
        {
            SampleDataController uut = new SampleDataController();
            Assert.AreEqual("don't know yet", uut.WeatherForecasts());
        }
    }
}

//dotnet add package Microsoft.AspNetCore.Mvc.Abstractions --version 2.2.0
//dotnet add package Microsoft.AspNetCore.Mvc.ViewFeatures --version 2.2.0
