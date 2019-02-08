using KamatoShooting.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Actor
{
  abstract class APattern
  {
    protected List<Pattern> patterns;
    protected int patternCount;

    public APattern()
    {
      patterns = new List<Pattern>();
      Initialize();

    }

    public virtual void Initialize()
    {
      patternCount = 0;
    }

    public void AddPattern(float sec, PatternMethod pattern)
    {
      patterns.Add(new Pattern(new CountDownTimer(sec), pattern));
    }
    public void ClearPattern()
    {
      patterns.Clear();
    }

    public void ResetCount()
    {
      patternCount = 0;
    }

    public void SetCount(int count)
    {
      if (count < 0) { patternCount = 0; }
      else if (count >= patterns.Count) { patternCount = patterns.Count - 1; }
      else { patternCount = 0; }
    }
    public abstract void Update(GameTime gameTime);
  }
}
