using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Util
{
  abstract class Timer
  {
    protected float limitTime;
    protected float currentTime;

    public Timer(float second)
    {
      limitTime = 60 * second;
      TimerManager.GetInstance().Add(this);
    }

    public Timer() : this(1)
    {

    }

    public abstract void Initialize();
		protected abstract void AUpdate(GameTime gameTime);
		public abstract bool IsTime();
		public abstract float Rate();
    public abstract void Finish();
    public void Update (GameTime gameTime)
    {
      AUpdate(gameTime);
    }

		public void SetTime(float second)
		{
			limitTime = 60 * second;
		}

		public float Now()
		{
			return currentTime / 60f;
		}

    internal void ResetTime(float time)
    {
      SetTime(time);
      Initialize();
    }
  }
}
