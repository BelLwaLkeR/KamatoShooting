using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Util
{
  class TimerManager
  {
    private static TimerManager Instance;
    private List<Timer> timers;
    private TimerManager()
    {
      timers = new List<Timer>();
    }

    public static TimerManager GetInstance()
    {
      if (Instance == null) { Instance = new TimerManager(); }
      return Instance;
    }

    public void Add(Timer timer)
    {
      timers.Add(timer);
    }

    public void Clear()
    {
      timers.Clear();
    }

    public void Update(GameTime gameTime)
    {
      timers.ForEach(t => t.Update(gameTime));
    }
    
  }
}
