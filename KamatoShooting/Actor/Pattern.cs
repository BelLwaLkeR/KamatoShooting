using KamatoShooting.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Actor
{
  public delegate void PatternMethod();
  struct Pattern
  {
    public Timer timer;
    public PatternMethod patternMethod;

    public Pattern(Timer timer, PatternMethod patternMethod)
    {
      this.timer = timer;
      this.patternMethod = patternMethod;
    }
  }
}
