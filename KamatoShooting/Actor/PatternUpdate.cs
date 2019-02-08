using KamatoShooting.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Actor
{
  class PatternUpdate:APattern
  {
    public override void Update(GameTime gameTime)
    {
      if (patterns.Count <= patternCount) { return; }
      patterns[patternCount].timer.Update(gameTime);
      patterns[patternCount].patternMethod();
      if (patterns[patternCount].timer.IsTime()) { patternCount++; }
    }
  }
}
