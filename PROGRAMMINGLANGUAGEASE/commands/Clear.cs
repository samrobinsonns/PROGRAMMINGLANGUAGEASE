using PROGRAMMINGLANGUAGEASE;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    public static class ClearCommand
    {
        public static void Execute(Canvas canvas)
        {
            // Clear the drawing canvas
            canvas.DrawingPictureBox.Invalidate();
        }
    }
}
