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
    private Timer timer;

    public APattern()
    {
      patterns = new List<Pattern>();
      timer = new CountDownTimer();
      Initialize();

    }

    public virtual void Initialize()
    {
      patternCount = 0;
    }

    public void AddPattern(float sec, PatternMethod pattern)
    {
      patterns.Add(new Pattern(sec, pattern));
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

    public void Update(GameTime gameTime)
    {
      if (patternCount < 0 ){ return; }
      if (patternCount >= patterns.Count) { return; }

      AUpdate(gameTime);
      if (timer.IsTime())
      {
        Next();
      }
    }

    public void Next()
    {

      patternCount++;
      if (patternCount >= patterns.Count) { return; }
      timer.ResetTime(patterns[patternCount].time);
      ANext();
    }

    protected virtual void ANext()
    { }
    protected abstract void AUpdate(GameTime gameTime);
  }
}
