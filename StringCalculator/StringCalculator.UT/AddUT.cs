using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.UT
{
    [TestClass]
    public class AddUT
    {
        StringCalculator sut;
        [TestInitialize]
        public void InitSUT()
        {
            sut = new StringCalculator();
        }
        [TestMethod]
        public void GivenSEmptyShouldBe0()
        {
            var expected = 0;
            var result = sut.Add(string.Empty);
            Assert.IsTrue(result == expected);
        }
        [TestMethod]
        public void Given1ShouldBe1()
        {
            var expected = 1;
            var result = sut.Add("1");
            Assert.IsTrue(result == expected);
        }
        [TestMethod]
        public void Given2NumberShouldBeSum()
        {
            var expected = 3;
            var result = sut.Add("1,2");
            Assert.IsTrue(result == expected);
        }
        [TestMethod]
        public void GivenNewLineNumberShouldBeSum()
        {
            var expected = 6;
            var result = sut.Add("1\n2,3");
            Assert.IsTrue(result == expected);
        }
        [TestMethod]
        public void GivenDelemitresNumberShouldBeSum()
        {
            var expected = 3;
            var result = sut.Add("//;\n1;2");
            Assert.IsTrue(result == expected);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException),
            "Negatives not allowed -1")]
        public void GivenNegative1NumberShouldFormatException()
        {
            var result = sut.Add("-1");
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException),
            "Negatives not allowed -256")]
        public void GivenNegative256And1NumberShouldFormatException()
        {
            var result = sut.Add("-256,1");
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException),
            "Negatives not allowed -256, -128")]
        public void GivenNegative256And1AndNeg128NumberShouldFormatException()
        {
            var result = sut.Add("-256,1,-128");
        }
    }
}
