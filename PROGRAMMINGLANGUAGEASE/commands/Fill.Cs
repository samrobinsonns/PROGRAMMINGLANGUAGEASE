using System;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public static class FillCommand
    {
        public static void Execute(Canvas canvas, string[] args, Pen drawingPen)
        {
            if (args.Length >= 1)
            {
                string fillMode = args[0].ToLower();

                switch (fillMode)
                {
                    case "on":
                        // Implement logic to enable filling using the color from drawingPen
                        Color fillColor = drawingPen.Color; // Get the color from the drawingPen
                        // Use fillColor for filling logic
                        break;
                    case "off":
                        // Implement logic to disable filling
                        break;
                    default:
                        // Handle unrecognized fill mode
                        MessageBox.Show("Invalid fill mode. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                // Handle missing fill mode argument
                MessageBox.Show("Missing argument for 'fill' command. Use 'on' or 'off'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
