using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamatoShooting.Def;
using KamatoShooting.Device;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor.Enemys
{
  class Enemy1 : Enemy
  {
    private float speed=3;
    public Enemy1(Vector2 position) : base(position,20)
    {
    }

    public override void Draw()
    {
      base.Draw();
    }


    public override void Initialize()
    {
      SetPattern();
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
    }

    public override void Hit(Character other)
    {
      Damage(1);
      if (endurance <= 0)
      {
        GameDevice.Instance().GetSound().PlaySE("kill",true);
      }
    }
    private void SetPattern()
    {
      AddPattern(999, ()=> { position.Y += speed;position.X = (float)Math.Sin(MathHelper.ToRadians(position.Y/2)) * (Screen.Width / 2 - 100)+ Screen.Width / 2; });
    }

    protected override void Shot()
    {

    }

  }
}
