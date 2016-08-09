using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Media;

namespace GW2Helper.Tests
{
    [TestClass()]
    public class ColorResolverTests
    {
        [TestMethod()]
        public void RedIsCorrectlyReturnedColorResolver()
        {
            ColorResolver resolver = new ColorResolver();
            Color testColorRed;

            testColorRed= Color.FromRgb(189, 0, 0);

            Color toTest = resolver.FromTimeSpan(new TimeSpan(0, 0, 0, 15));

            Assert.AreEqual(testColorRed,toTest);
        }

        [TestMethod()]
        public void NotAllReturnedSolidColorBrushesAreEqualColorResolver()
        {
            ColorResolver resolver = new ColorResolver();
            SolidColorBrush testColorNotRed = new SolidColorBrush();

            testColorNotRed.Color = Color.FromRgb(19, 0, 0);
            SolidColorBrush toTest = new SolidColorBrush();
            toTest.Color = resolver.FromTimeSpan(new TimeSpan(0, 3, 0, 0));

            Assert.AreNotEqual(testColorNotRed.Color, toTest.Color);
        }
    }
}