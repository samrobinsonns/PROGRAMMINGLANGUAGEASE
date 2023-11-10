using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class CircleCommandTests
    {
        [TestMethod]
        public void Execute_WithValidRadius_DrawsCircle()
        {
            // Arrange
            var canvas = new Canvas();
            var circleCommand = new CircleCommand();
            string[] args = new string[] { "50" }; // Example radius for circle
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            // Act
            circleCommand.Execute(graphics, args, canvas);

            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandTextBox.Text));
        }

        [TestMethod]
        public void Execute_WithInvalidRadius_ShowsErrorMessage()
        {
            var canvas = new Canvas();
            var circleCommand = new CircleCommand();
            string[] args = new string[] { "invalidRadius" };
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            circleCommand.Execute(graphics, args, canvas);

        }
    }
}
