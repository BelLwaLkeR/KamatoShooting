using KamatoShooting.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Actor
{


  class PatternUpdate
  {
    private List<Pattern> patterns;
    private int patternCount;
    public PatternUpdate()
    {
      patterns = new List<Pattern>();
      Initialize();

    }

    public void Initialize()
    {
      patternCount = 0;
    }

    public void AddPatern(Timer timer, MovePattern pattern)
    {
      patterns.Add(new Pattern(timer, pattern));
    }

    public void Update(GameTime gameTime)
    {
      if (patterns.Count <= patternCount) { return; }
      patterns[patternCount].timer.Update(gameTime);
      patterns[patternCount].patternMethod();
      if (patterns[patternCount].timer.IsTime()) { patternCount++; }
    }
  }
}
