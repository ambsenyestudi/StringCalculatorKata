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
            //Act
            Assert.IsTrue(true);
        }
    }
}
