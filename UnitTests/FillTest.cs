using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;

namespace UnitTests
{
    [TestClass]
    public class FillCommandTests
    {
        [TestMethod]
        public void Execute_ToggleFillModeOn()
        {
            // Arrange
            var canvas = new Canvas();
            var fillCommand = new FillCommand();
            string[] args = { "on" };

            // Act
            fillCommand.Execute(canvas, args);

            // Assert
            Assert.IsTrue(canvas.IsFilling);
        }

        [TestMethod]
        public void Execute_ToggleFillModeOff()
        {
            // Arrange
            var canvas = new Canvas();
            var fillCommand = new FillCommand();
            string[] args = { "off" };

            // Act
            fillCommand.Execute(canvas, args);

            // Assert
            Assert.IsFalse(canvas.IsFilling);
        }
    }
}
