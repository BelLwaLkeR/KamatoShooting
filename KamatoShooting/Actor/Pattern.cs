using KamatoShooting.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Actor
{
  public delegate void MovePattern();
  struct Pattern
  {
    public Timer timer;
    public MovePattern patternMethod;

    public Pattern(Timer timer, MovePattern patternMethod)
    {
      this.timer = timer;
      this.patternMethod = patternMethod;
    }
  }
}
