

namespace TestCore
{
    public class TestHelpers
    {
        [SetUp]
        public void Setup()
        {
        }


        //Happy flow
        [Test]
        [SetCulture("nl-NL")]
        [TestCase(1.99, "€ 1,99")]
        [TestCase(0.0, "€ 0,00")]
        [TestCase(1234.5, "€ 1.234,50")]
        [TestCase(-3.2, "€ -3,20")]
        public void TestPriceFormatting(decimal input, string expected)
        {
            decimal price = input;
            var result = string.Format("{0:C2}", price);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}