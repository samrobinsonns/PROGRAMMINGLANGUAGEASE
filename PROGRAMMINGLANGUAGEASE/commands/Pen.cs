using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class PenCommand
    {
        public static Pen HandlePenCommand(Pen currentPen, string[] args)
        {
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
                        // Display an error message for an invalid color.
                        MessageBox.Show("Invalid pen color. Available colors: red, blue, ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return currentPen; // Return the current pen if the color is invalid.
                }

                // Create a new pen with the new color and return it.
                return new Pen(newColor);
            }
            else
            {
                // Display an error message for no color provided.
                MessageBox.Show("Invalid pen command. Please provide a valid color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return currentPen; // Return the current pen if the command is invalid.
            }
        }
    }
}
