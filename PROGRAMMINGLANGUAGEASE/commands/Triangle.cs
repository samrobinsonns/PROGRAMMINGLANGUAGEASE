using System.Drawing;
using System.Windows.Forms;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class TriangleCommand
    {
        public void HandleTriangleCommand(Graphics graphics, string[] args, Point currentPosition, Pen drawingPen, TextBox commandTextBox)
        {
            if (args.Length >= 1)
            {
                if (int.TryParse(args[0], out int sideLength))
                {
                    int x1 = currentPosition.X;
                    int y1 = currentPosition.Y;
                    int x2 = x1 + sideLength;
                    int y2 = y1;
                    int x3 = x1 + sideLength / 2;
                    int y3 = y1 - (int)(System.Math.Sqrt(3) * sideLength / 2);

                    Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };

                    // Check if a new pen color has been set
                    if (drawingPen != null)
                    {
                        graphics.DrawPolygon(drawingPen, points);
                    }
                    else
                    {
                        graphics.DrawPolygon(Pens.Black, points); // Default to black if no pen color is set
                    }
                    commandTextBox.Clear();
                }
                else
                {
                    // Handle parsing errors here
                    MessageBox.Show("Invalid arguments for 'triangle' command. Please provide a valid side length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
