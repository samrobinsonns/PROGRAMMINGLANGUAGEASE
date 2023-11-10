using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class MoveToCommandTests
    {
        [TestMethod]
        public void Execute_MoveTo_WithValidDimensions()
        {
            var canvas = new Canvas();
            var moveToCommand = new PositionCommand();
            string[] args = { "100", "50" }; // Test dimensions

            moveToCommand.Execute(canvas, args);

            Assert.AreEqual(new Point(100, 50), canvas.CurrentPosition);
        }

        [TestMethod]
        public void Execute_InvalidArguments_ShowsErrorMessage()
        {
            var canvas = new Canvas();
            var moveToCommand = new PositionCommand();
            string[] args = { "invalid", "50" };

            moveToCommand.Execute(canvas, args);
        }
    }
}
