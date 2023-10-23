using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMINGLANGUAGEASE.Commands
{
    abstract public class BasicCommand
    {
        abstract public void Execute(Canvas canvas, string[] args);
    }
}
