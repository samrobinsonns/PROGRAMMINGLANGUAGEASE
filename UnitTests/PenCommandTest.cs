using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTests
{
    [TestClass]
    public class PenCommandTests
    {
        [TestMethod]
        public void Execute_ChangesPenColorToRed()
        {
            var canvas = new Canvas();
            var penCommand = new PenCommand();
            string[] args = new string[] { "red" };

            penCommand.Execute(canvas, args);

            Assert.AreEqual(Color.Red, canvas.DrawingPen.Color);
        }
    }
}
