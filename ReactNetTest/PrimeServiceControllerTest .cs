using NUnit.Framework;
using System.Collections.Generic;

namespace ReactNet.Controllers
{
    [TestFixture]
    public class PrimeServiceControllerTests
    {
        [TestFixture]
        public class PrimeService_IsPrimeShould
        {
            [Test]
            public void IsPrime_InputIs1_ReturnFalse()
            {
                PrimeServiceController primeService = CreatePrimeService();
                var result = primeService.IsPrime(1);

                Assert.IsFalse(result, "1 should not be prime");
            }

            [TestCase(-1)]
            [TestCase(0)]
            [TestCase(1)]
            public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
            {
                PrimeServiceController primeService = CreatePrimeService();
                var result = primeService.IsPrime(value);

                Assert.IsFalse(result, $"{value} should not be prime");
            }

            [Test]
            public void When_MatrixIsLessThanThreeByThree_Then_IsMagicSquareFalse()
            {
                var matrix = new List<List<decimal>>
               {
                   new List<decimal> {1.0m, 2.0m},
                   new List<decimal> {4.0m, 4.0m}
               };

                Assert.IsTrue(PrimeServiceController.isMagicSquare(matrix));
            }

            private PrimeServiceController CreatePrimeService()
            {
                return new PrimeServiceController();
            }
        }
    }
}

//dotnet add package Microsoft.AspNetCore.Mvc.Abstractions --version 2.2.0
//dotnet add package Microsoft.AspNetCore.Mvc.ViewFeatures --version 2.2.0
