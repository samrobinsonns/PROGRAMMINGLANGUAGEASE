using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class DrawToCommandTests
    {
        [TestMethod]
        public void Execute_DrawTo_WithValidDimensions()
        {
            var canvas = new Canvas();
            var drawToCommand = new DrawToCommand();
            string[] args = { "100", "50" }; // Test location
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            drawToCommand.Execute(canvas, args);

            Assert.AreEqual(new Point(100, 50), canvas.CurrentPosition);
        }

        [TestMethod]
        public void Execute_InvalidArguments_ShowsErrorMessage()
        {
            var canvas = new Canvas();
            var drawToCommand = new DrawToCommand();
            string[] args = { "invalid", "50" };

            drawToCommand.Execute(canvas, args);
        }
    }
}
