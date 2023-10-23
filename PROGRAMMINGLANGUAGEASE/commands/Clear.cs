using PROGRAMMINGLANGUAGEASE;
using PROGRAMMINGLANGUAGEASE.Commands;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public class ClearCommand : BasicCommand
    {
        public override void Execute(Canvas canvas, string[] args)
        {
            // Clear the drawing canvas
            canvas.DrawingPictureBox.Invalidate();
        }
    }
}
