using PROGRAMMINGLANGUAGEASE.Commands;
using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents a command to toggle the fill mode on or off in a canvas.
    /// </summary>
    public class FillCommand : BasicCommand
    {
        /// <summary>
        /// Executes the fill command on the given canvas.
        /// </summary>
        /// <param name="canvas">The canvas on which to toggle the fill mode.</param>
        /// <param name="args">The arguments for the fill command, expecting 'on' or 'off' as the first argument.</param>
        public override void Execute(Canvas canvas, string[] args)
        {
            TextBox commandTextBox = canvas.CommandTextBox; // Get the command text box from the canvas

            if (args.Length >= 1)
            {
                string fillMode = args[0].ToLower();

                switch (fillMode)
                {
                    case "on":
                        // Enable filling with the current pen color
                        canvas.IsFilling = true;
                        canvas.FillColor = canvas.DrawingPen.Color;
                        break;
                    case "off":
                        // Disable filling
                        canvas.IsFilling = false;
                        break;
                    default:
                        // Handle unrecognized fill mode
                        MessageBox.Show("Invalid fill mode. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            else
            {
                // Handle missing fill mode argument
                MessageBox.Show("Missing argument for 'fill' command. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            commandTextBox.Clear(); // Clear the command text box after executing the command
        }
    }
}
