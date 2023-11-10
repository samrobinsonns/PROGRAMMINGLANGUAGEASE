using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class RectangleCommandTests
    {
        [TestMethod]
        public void Execute_DrawsRectangle_WithValidDimensions()
        {
            var canvas = new Canvas();
            var rectangleCommand = new RectangleCommand();
            string[] args = { "100", "50" }; // Test dimensions
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            rectangleCommand.Execute(graphics, args, canvas);

            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandTextBox.Text));
        }

        [TestMethod]
        public void Execute_InvalidArguments_ShowsErrorMessage()
        {
            var canvas = new Canvas();
            var rectangleCommand = new RectangleCommand();
            string[] args = { "invalid", "50" }; // Invalid width
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            rectangleCommand.Execute(graphics, args, canvas);
        }
    }
}
