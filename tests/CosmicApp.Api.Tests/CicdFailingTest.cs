namespace CosmicApp.Api.Tests
{
    public class CicdFailingTest
    {
        [Test]
        public void FailingTest()
        {
            var expected = 10;
            var result = 100;
            
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}