namespace Euler411Tests
{
    using Euler411;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StationDomainTests
    {
        [TestMethod]
        public void ShouldReturn14For123Stations()
        {
            AssertPathLength(123, 14);
        }

        [TestMethod]
        public void ShouldReturn48For10000Stations()
        {
            AssertPathLength(10000, 48);
        }

        [TestMethod]
        public void ShouldReturn5For22Stations()
        {
            AssertPathLength(22, 5);
        }

        [TestMethod]
        public void ShouldReturn5For16Stations()
        {
            AssertPathLength(16,5);
        }

        [TestMethod]
        public void ShouldReturn8For18Stations()
        {
            AssertPathLength(18, 8);
        }

        [TestMethod]
        public void ShouldReturn18For27Stations()
        {
            AssertPathLength(27, 18);
        }

        [TestMethod]
        public void ShouldReturn39366For59049Stations()
        {
            AssertPathLength(59049, 39366);
        }

        private static void AssertPathLength(int numberOfStationsToGenerate, int expectedPathLength)
        {
            var stationDomain = new StationDomain(numberOfStationsToGenerate);
            var result = stationDomain.CalculateValidPathLength();
            Assert.AreEqual(expectedPathLength, result, "Did not return expected path length.");
        }       
    }
}