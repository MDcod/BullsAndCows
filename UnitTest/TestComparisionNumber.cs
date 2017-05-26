using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Test
{
    [TestClass]
    public class TestComparisionNumber
    {
        public void CountBullsCows(int[] e, int[] a, int[] expected)
        {
            var result = Program.ComparisonNumber(e, a);
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], result[i]);
        }

        [TestMethod]
        public void B1C1()
        {
            CountBullsCows(new int[] { 1, 2, 3, 4 }, new int[] { 2, 7, 3, 5 }, new int[] { 1, 1 });
        }

        [TestMethod]
        public void B4C0()
        {
            CountBullsCows(new int[] { 7, 4, 1, 9 }, new int[] { 7, 4, 1, 9 }, new int[] { 4, 0 });
        }

        [TestMethod]
        public void B0C4()
        {
            CountBullsCows(new int[] { 3, 2, 7, 8 }, new int[] { 8, 3, 2, 7 }, new int[] { 0, 4 });
        }

        [TestMethod]
        public void B2C2()
        {
            CountBullsCows(new int[] { 2, 8, 5, 3 }, new int[] { 2, 8, 3, 5 }, new int[] { 2, 2 });
        }

        [TestMethod]
        public void B3C0()
        {
            CountBullsCows(new int[] { 9, 8, 7, 4 }, new int[] { 9, 8, 7, 5 }, new int[] { 3, 0 });
        }

        [TestMethod]
        public void B0C3()
        {
            CountBullsCows(new int[] { 9, 8, 7, 4 }, new int[] { 4, 9, 8, 1 }, new int[] { 0, 3 });
        }
    }
}
