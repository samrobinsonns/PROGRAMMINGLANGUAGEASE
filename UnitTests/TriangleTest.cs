using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class TriangleCommandTests
    {
        [TestMethod]
        public void Execute_WithValidRadius_DrawsCircle()
        {
            var canvas = new Canvas();
            var circleCommand = new TriangleCommand();
            string[] args = new string[] { "50" }; // Test size for triangle
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            circleCommand.Execute(graphics, args, canvas);

            Assert.IsTrue(string.IsNullOrEmpty(canvas.CommandTextBox.Text));
        }

        [TestMethod]
        public void Execute_WithInvalidRadius_ShowsErrorMessage()
        {
            var canvas = new Canvas();
            var triangleCommand = new TriangleCommand();
            string[] args = new string[] { "invalidSize" };
            var graphics = Graphics.FromImage(new Bitmap(100, 100));

            triangleCommand.Execute(graphics, args, canvas);

        }
    }
}
