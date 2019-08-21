using NUnit.Framework;

namespace ReactNet.Controllers
{
    [TestFixture]
    public class HelloWorldControllerTests
    {
        [Test]
        public void WelcomeTests()
        {
            HelloWorldController uut = new HelloWorldController();
            Assert.AreEqual("don't know yet", uut.Welcome("Ngan", 2));
        }
    }
}

//dotnet add package Microsoft.AspNetCore.Mvc.Abstractions --version 2.2.0
//dotnet add package Microsoft.AspNetCore.Mvc.ViewFeatures --version 2.2.0
