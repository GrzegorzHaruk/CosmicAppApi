namespace CosmicApp.Api.Tests
{
    public class CicdFailingTest
    {
        [Test]
        public void FailingTestRepaired()
        {
            var expected = 10;
            var result = 10;
            
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}