using System;
using MathHelperRedux;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathHelperReduxTest
{
    [TestClass]
    public class MathHelperTest
    {
        [TestMethod]
        public void AssertThat_ToRadians_ConvertsToExpectedValue()
        {
            Assert.AreEqual(0.174533f, 10f.ToRadians(), 0.0001f);
        }

        [TestMethod]
        public void AssertThat_ToRadians_ConvertsToExpectedValue_WithNegativeValue()
        {
            Assert.AreEqual(-0.174533f, -10f.ToRadians(), 0.0001f);
        }

        [TestMethod]
        public void AssertThat_ToRadians_ConvertsToExpectedValue_Over360()
        {
            Assert.AreEqual(6.45772f, 370f.ToRadians(), 0.0001f);
        }

        [TestMethod]
        public void AssertThat_ToDegrees_ConvertsToExpectedValue()
        {
            Assert.AreEqual(10f, 0.174533f.ToDegrees(), 0.0001f);
        }

        [TestMethod]
        public void AssertThat_ToDegrees_ConvertsToExpectedValue_WithNegativeValue()
        {
            Assert.AreEqual(-10f, -0.174533f.ToDegrees(), 0.0001f);
        }

        [TestMethod]
        public void AssertThat_ToDegrees_ConvertsToExpectedValue_Over360()
        {
            Assert.AreEqual(370f, 6.45772f.ToDegrees(), 0.0001f);
        }

        [TestMethod]
        public void AssertThat_ClampInt_ClampsToMin()
        {
            Assert.AreEqual(0, MathHelper.Clamp(-5, 0, 10));
        }

        [TestMethod]
        public void AssertThat_ClampInt_ClampsToMax()
        {
            Assert.AreEqual(10, MathHelper.Clamp(15, 0, 10));
        }

        [TestMethod]
        public void AssertThat_ClampInt_DoesNothingInRange()
        {
            Assert.AreEqual(5, MathHelper.Clamp(5, 0, 10));
        }

        [TestMethod]
        public void AssertThat_ClampFloat_ClampsToMin()
        {
            Assert.AreEqual(0, MathHelper.Clamp(-5f, 0, 10));
        }

        [TestMethod]
        public void AssertThat_ClampFloat_ClampsToMax()
        {
            Assert.AreEqual(10, MathHelper.Clamp(15f, 0, 10));
        }

        [TestMethod]
        public void AssertThat_ClampFloat_DoesNothingInRange()
        {
            Assert.AreEqual(5, MathHelper.Clamp(5f, 0, 10));
        }

        [TestMethod]
        public void AssertThat_Lerp_LerpsInRange()
        {
            Assert.AreEqual(5, MathHelper.Lerp(0, 10, 0.5f));
        }

        [TestMethod]
        public void AssertThat_Lerp_LerpsOverRange()
        {
            Assert.AreEqual(15, MathHelper.Lerp(0, 10, 1.5f));
        }

        [TestMethod]
        public void AssertThat_Lerp_LerpsUnderRange()
        {
            Assert.AreEqual(-15, MathHelper.Lerp(0, 10, -1.5f));
        }
    }
}
