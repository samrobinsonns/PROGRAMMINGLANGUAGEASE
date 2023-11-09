using PROGRAMMINGLANGUAGEASE.Commands;
using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class FillCommand : BasicCommand
    {
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
                        return; // Exit the method after showing the message box
                }
            }
            else
            {
                // Handle missing fill mode argument
                MessageBox.Show("Missing argument for 'fill' command. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method after showing the message box
            }

            commandTextBox.Clear(); // Clear the command text box after executing the command
        }
    }
}
