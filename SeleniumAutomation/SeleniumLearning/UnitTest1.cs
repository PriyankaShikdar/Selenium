namespace SeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Set up method execution");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test method execution");
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("TearDown method execution");
        }
    }
}