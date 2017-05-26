using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Test
{
    [TestClass]
    public class TestInputValidation
    {
        public void Validation(string input, bool expected)
        {
            var result = Program.InputValidation(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NotNumber()
        {
            Validation("1a34", false);
            Validation("dsfsdr", false);
        }

        [TestMethod]
        public void MoreChar()
        {
            Validation("16435", false);
        }

        [TestMethod]
        public void LessChar()
        {
            Validation("134", false);
        }

        [TestMethod]
        public void Space()
        {
            Validation("1  4 3 2", false);
        }

        [TestMethod]
        public void Clone()
        {
            Validation("1232", false);
        }

        [TestMethod]
        public void RightInput()
        {
            Validation("1234", true);
        }
    }
}
