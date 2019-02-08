using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor.Bullets
{
  class NoMoveEnemy : Enemy
  {
    public NoMoveEnemy(Vector2 position, int endurance = 50000) : base(position, endurance)
    {
    }

    public override void Draw()
    {
      base.Draw();
    }

    public override void Hit(Character other)
    {
      base.Hit(other);
    }

    public override void Initialize()
    {
      base.Initialize();
    }

    public override void Shutdown()
    {
      base.Shutdown();
    }


    public override void Update(GameTime gameTime)
    {
    }
  }
}
