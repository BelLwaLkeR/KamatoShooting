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

    protected override void ANext()
    {
      done = false;
    }

    protected override void AUpdate(GameTime gameTime)
    {
      if (done) { return; }
      patterns[patternCount].patternMethod();
      done = true; 
      
    }


  }
}
