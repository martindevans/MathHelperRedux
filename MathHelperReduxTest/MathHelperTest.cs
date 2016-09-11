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

        [TestMethod]
        public void AssertThat_InverseLerp_CalculatesValueInRange()
        {
            Assert.AreEqual(0.5f, MathHelper.InverseLerp(0, 1, 0.5f));
        }

        [TestMethod]
        public void AssertThat_InverseLerp_CalculatesValueUnderRange()
        {
            Assert.AreEqual(-0.5f, MathHelper.InverseLerp(0, 10, -5f));
        }

        [TestMethod]
        public void AssertThat_InverseLerp_CalculatesValueOverRange()
        {
            Assert.AreEqual(2f, MathHelper.InverseLerp(0, 7, 14));
        }

        [TestMethod]
        public void AssertThat_InverseLerp_CalculatesValueInRange_WithReverseRange()
        {
            Assert.AreEqual(0.25f, MathHelper.InverseLerp(1, 0, 0.75f));
        }

        [TestMethod]
        public void AssertThat_InverseLerp_CalculatesValueUnderRange_WithReverseRange()
        {
            Assert.AreEqual(1.5f, MathHelper.InverseLerp(10, 0, -5f));
        }

        [TestMethod]
        public void AssertThat_InverseLerp_CalculatesValueOverRange_WithReverseRange()
        {
            Assert.AreEqual(-1f, MathHelper.InverseLerp(7, 0, 14));
        }

        [TestMethod]
        public void AssertThat_BilinearLerp_LerpsInRange()
        {
            var v = MathHelper.BilinearLerp(MathHelper.Lerp, 0.5f, 0.5f, 1f, 2, 3, 4);

            Assert.AreEqual(2.5f, v);
        }

        [TestMethod]
        public void AssertThat_BilinearLerp_LerpsOverXRange()
        {
            var v = MathHelper.BilinearLerp(MathHelper.Lerp, 1.5f, 0.5f, 1f, 2, 3, 4);

            Assert.AreEqual(2.5f, v);
        }

        [TestMethod]
        public void AssertThat_BilinearLerp_LerpsOverYRange()
        {
            var v = MathHelper.BilinearLerp(MathHelper.Lerp, 0.5f, 1.5f, 1f, 2, 3, 4);

            Assert.AreEqual(0.5f, v);
        }

        [TestMethod]
        public void AssertThat_TrilinearLerp_LerpsInRange()
        {
            var v = MathHelper.TrilinearLerp<float>(MathHelper.Lerp, 0.5f, 0.5f, 0.5f, 1, 2, 3, 4, 1, 2, 3, 4);

            Assert.AreEqual(2.5f, v);
        }

        [TestMethod]
        public void AssertThat_TrilinearLerp_LerpsOverXRange()
        {
            var v = MathHelper.TrilinearLerp<float>(MathHelper.Lerp, 1.5f, 0, 0.5f, 1, 1, 1, 1, 5, 6, 7, 8);

            Assert.AreEqual(1, v);
        }
    }
}
