using PROGRAMMINGLANGUAGEASE.Commands;
using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents a command to reset the drawing settings to their default values.
    /// </summary>
    public class ResetCommand : BasicCommand
    {
        /// <summary>
        /// Executes the reset command on the given canvas.
        /// </summary>
        /// <param name="canvas">The canvas on which to execute the reset command.</param>
        /// <param name="args">The arguments for the command, not used in this command.</param>
        public override void Execute(Canvas canvas, string[] args)
        {
            // Reset the drawing settings to their default values
            canvas.CurrentPosition = new Point(40, 40);
        }
    }
}

