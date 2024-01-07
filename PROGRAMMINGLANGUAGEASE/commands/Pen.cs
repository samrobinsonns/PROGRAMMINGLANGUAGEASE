using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    /// <summary>
    /// Represents a command to change the pen color for drawing on the canvas.
    /// </summary>
    public class PenCommand : BasicCommand
    {
        /// <summary>
        /// Executes the 'pen' command on the given canvas with the specified arguments.
        /// </summary>
        /// <param name="canvas">The canvas on which to change the pen color.</param>
        /// <param name="args">The arguments for the 'pen' command, expecting a color name as the first argument.</param>
        public override void Execute(Canvas canvas, string[] args)
        {
            TextBox commandTextBox = canvas.CommandTextBox;
            Pen currentPen = canvas.DrawingPen;
            if (args.Length >= 1)
            {
                string colorName = args[0].ToLower();
                Color newColor;

                switch (colorName)
                {
                    case "red":
                        newColor = Color.Red;
                        break;
                    case "blue":
                        newColor = Color.Blue;
                        break;
                    case "green":
                        newColor = Color.Green;
                        break;
                    case "yellow":
                        newColor = Color.Yellow;
                        break;
                    case "orange":
                        newColor = Color.Orange;
                        break;
                    case "purple":
                        newColor = Color.Purple;
                        break;
                    case "pink":
                        newColor = Color.Pink;
                        break;
                    case "cyan":
                        newColor = Color.Cyan;
                        break;
                    case "magenta":
                        newColor = Color.Magenta;
                        break;
                    case "brown":
                        newColor = Color.Brown;
                        break;
                    case "black":
                        newColor = Color.Black;
                        break;
                    case "white":
                        newColor = Color.White;
                        break;
                    case "gray":
                        newColor = Color.Gray;
                        break;
                    case "darkred":
                        newColor = Color.DarkRed;
                        break;
                    case "darkblue":
                        newColor = Color.DarkBlue;
                        break;
                    case "darkgreen":
                        newColor = Color.DarkGreen;
                        break;
                    case "darkorange":
                        newColor = Color.DarkOrange;
                        break;
                    case "darkcyan":
                        newColor = Color.DarkCyan;
                        break;
                    case "lavender":
                        newColor = Color.Lavender;
                        break;
                    case "lime":
                        newColor = Color.Lime;
                        break;
                    default:
                        MessageBox.Show("Invalid pen color. Available colors: red, blue, ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // Create a new pen with the new color and return it.
                canvas.DrawingPen = new Pen(newColor);
                // Set the fill color to the new color
                canvas.FillColor = newColor;
            }
            else
            {
                // Display an error message for no color provided.
                MessageBox.Show("Invalid pen command. Please provide a valid color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Use Invoke to update the commandTextBox on the UI thread
            commandTextBox.Invoke((MethodInvoker)delegate
            {
                commandTextBox.Clear();
            });
        }
    }
}
