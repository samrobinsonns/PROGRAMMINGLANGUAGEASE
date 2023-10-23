using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    abstract public class GraphicsCommand
    {
        abstract public void Execute(Graphics graphics, string[] args, Canvas canvas);
    }
}
