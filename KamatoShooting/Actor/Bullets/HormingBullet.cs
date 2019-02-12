using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamatoShooting.Device;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor
{
  class HormingBullet : PlayerBullet
  {
    private Character target;
    private Vector2 direction;
    private const float speed = 10;
    private float angle { get { return (float)Math.Atan2(direction.Y, direction.X); } }

    public HormingBullet(Vector2 position) : base(position, new Vector2(0,speed),ActorSide.Player)
    {
    }

    public override void Initialize()
    {
      target = null;
      direction = new Vector2(0,-1);
    }

    public override void Shutdown()
    {
      characterManager.Add(new BulletExplosion(position, angle));
    }


    public override void Update(GameTime gameTime)
    {
      SearchTarget();

      if (target != null && !target.IsDead())
      {
        direction = (target.centerPosition - position);
        direction.Normalize();
      }
      MoveForward();

      if (position.Y < -64) { endurance = 0; }
    }

    private void MoveForward()
    {
      position += direction * speed;
    }

    private void SearchTarget()
    {
      if (target != null) { return; }
      characterManager.GetCharacters(ActorSide.Enemy).Where(e=>e is Enemy).ToList().ForEach(e=> {
        if (target == null) { target = e; }
        else {
          if ((e.centerPosition - position).LengthSquared() < (target.centerPosition - position).LengthSquared())
          { target = e; }
        }
      });
    }

    public override void Draw()
    {
       renderer.DrawTexture(assetName, position, imageSize/2, angle);
    }

    public override void Hit(Character other)
    {
      if (!(other is Enemy)) { return; }

        GameDevice.Instance().GetSound().PlaySE("hit");
      endurance = 0;
    }
  }
}
