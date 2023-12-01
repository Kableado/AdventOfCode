using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Claim_Tests
    {
        #region FromString

        [TestMethod]
        public void FromString__Test1()
        {
            Day03.Claim claim = Day03.Claim.FromString("#123 @ 3,2: 5x4");

            Assert.AreEqual(123, claim.ID);
            Assert.AreEqual(3, claim.Left);
            Assert.AreEqual(2, claim.Top);
            Assert.AreEqual(5, claim.Width);
            Assert.AreEqual(4, claim.Height);
        }

        [TestMethod]
        public void FromString__Test2()
        {
            Day03.Claim claim = Day03.Claim.FromString("#1 @ 1,3: 4x4");

            Assert.AreEqual(1, claim.ID);
            Assert.AreEqual(1, claim.Left);
            Assert.AreEqual(3, claim.Top);
            Assert.AreEqual(4, claim.Width);
            Assert.AreEqual(4, claim.Height);
        }

        [TestMethod]
        public void FromString__Test3()
        {
            Day03.Claim claim = Day03.Claim.FromString("#2 @ 3,1: 4x4");

            Assert.AreEqual(2, claim.ID);
            Assert.AreEqual(3, claim.Left);
            Assert.AreEqual(1, claim.Top);
            Assert.AreEqual(4, claim.Width);
            Assert.AreEqual(4, claim.Height);
        }

        [TestMethod]
        public void FromString__Test4()
        {
            Day03.Claim claim = Day03.Claim.FromString("#3 @ 5,5: 2x2");

            Assert.AreEqual(3, claim.ID);
            Assert.AreEqual(5, claim.Left);
            Assert.AreEqual(5, claim.Top);
            Assert.AreEqual(2, claim.Width);
            Assert.AreEqual(2, claim.Height);
        }

        #endregion FromString

        #region Overlaps

        [TestMethod]
        public void Overlaps__Test1()
        {
            Day03.Claim claim1 = Day03.Claim.FromString("#1 @ 1,3: 4x4");
            Day03.Claim claim2 = Day03.Claim.FromString("#3 @ 5,5: 2x2");

            bool result = Day03.Claim.Overlaps(claim1, claim2);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Overlaps__Test2()
        {
            Day03.Claim claim1 = Day03.Claim.FromString("#2 @ 3,1: 4x4");
            Day03.Claim claim2 = Day03.Claim.FromString("#3 @ 5,5: 2x2");

            bool result = Day03.Claim.Overlaps(claim1, claim2);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Overlaps__Test3()
        {
            Day03.Claim claim1 = Day03.Claim.FromString("#1 @ 1,3: 4x4");
            Day03.Claim claim2 = Day03.Claim.FromString("#2 @ 3,1: 4x4");

            bool result = Day03.Claim.Overlaps(claim1, claim2);

            Assert.AreEqual(true, result);
        }

        #endregion Overlaps
    }
}