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
    protected override void AUpdate(GameTime gameTime)
    {
      patterns[patternCount].patternMethod();
    }
  }
}
