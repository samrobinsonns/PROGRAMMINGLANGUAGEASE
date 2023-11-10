using PROGRAMMINGLANGUAGEASE.Commands;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents a command to change the current position on the canvas.
    /// </summary>
    public class PositionCommand : BasicCommand
    {
        /// <summary>
        /// Executes the 'moveto' command on the given canvas with the specified arguments.
        /// </summary>
        /// <param name="canvas">The canvas on which to change the position.</param>
        /// <param name="args">The arguments for the 'moveto' command, expecting x and y coordinates as the first two arguments.</param>

        public override void Execute(Canvas canvas, string[] args)
        {
            if (args.Length >= 2 && int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y))
            {
                // Set the current position to the specified coordinates
                canvas.CurrentPosition = new Point(x, y);
                canvas.CommandTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Invalid arguments for 'moveto' command. Please provide valid coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
