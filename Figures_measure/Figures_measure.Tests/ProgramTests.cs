using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Figures_measure.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Measure_sqrt10divpi_10returned()
        {
            double arg = Math.Sqrt(10 / Math.PI);
            double expected = 10;
            Circle krug = new Circle(Math.Sqrt(10 / Math.PI));
            double actual = (int)krug.Measure();
            //если не отбрасывать дробную часть проверять методом AreEqual
            //становиться невозможно
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Measure_3and4and5_6returned()
        {
            double a = 3, b = 4, c = 5;
            double expected = 6;
            Triangle treug = new Triangle(3, 4, 5);
            double actual = treug.Measure();

            Assert.AreEqual(expected, actual);
        }
    }
}
