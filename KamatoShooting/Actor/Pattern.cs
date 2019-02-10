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
    public float time;
    public PatternMethod patternMethod;

    public Pattern(float time, PatternMethod patternMethod)
    {
      this.time = time;
      this.patternMethod = patternMethod;
    }
  }
}
