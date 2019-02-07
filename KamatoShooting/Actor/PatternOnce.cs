using KamatoShooting.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Actor
{
  class PatternOnce
  {
    private List<Pattern> patterns;
    private int patternCount;
    private bool done;

    public PatternOnce()
    {
      patterns = new List<Pattern>();
      Initialize();

    }

    public void Initialize()
    {
      patternCount = 0;
      done = false;
    }

    public void AddPatern(Timer timer, MovePattern pattern)
    {
      patterns.Add(new Pattern(timer, pattern));
    }

    public void Update(GameTime gameTime)
    {
      if (patterns.Count <= patternCount) { return; }
      patterns[patternCount].timer.Update(gameTime);
      if (!done) { patterns[patternCount].patternMethod(); done = true; }
      if (patterns[patternCount].timer.IsTime()) { patternCount++; done = false; }
    }


  }
}
