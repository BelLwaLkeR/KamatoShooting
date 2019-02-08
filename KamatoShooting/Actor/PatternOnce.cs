using KamatoShooting.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Actor
{
  class PatternOnce:APattern
  {
    private bool done;

    public override void Initialize()
    {
      done = false;
      base.Initialize();
    }


    public override void Update(GameTime gameTime)
    {
      if (patterns.Count <= patternCount) { return; }
      patterns[patternCount].timer.Update(gameTime);
      if (!done) { patterns[patternCount].patternMethod(); done = true; }
      if (patterns[patternCount].timer.IsTime()) { patternCount++; done = false; }
    }


  }
}
