using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamatoShooting.Util;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor
{



  class Enemy : Character
  {
    private Player player;
    private PatternUpdate pattern;

    public Enemy(Vector2 position) 
      : base("black", position, 64, ActorSide.Enemy, 5, 1)
    {
    }

    public override void Initialize()
    {
      player = CharacterManager.GetInstance().GetPlayer();
      SetPattern();
    }

    public override void Shutdown()
    {

    }

    public override void Update(GameTime gameTime)
    {
      pattern.Update(gameTime);
    }

    private void SetPattern()
    {
      pattern = new PatternUpdate();
      pattern.AddPatern(new CountDownTimer(0.5f), () => { position.Y += 5.0f; });
      pattern.AddPatern(new CountDownTimer(1.5f), () => { position.Y -= 0.5f; });
      pattern.AddPatern(new CountDownTimer(2.5f), () => { position.Y += 15.0f; });
      pattern.AddPatern(new CountDownTimer(2.5f), () => { endurance = 0; });
    }


  }
}
