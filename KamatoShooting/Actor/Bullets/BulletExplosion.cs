using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor
{
  class BulletExplosion : Character
  {
    private readonly float scaleChangeRate = 0.1f;
    private readonly float alphaChangeRate = 0.05f;
    private float scale;
    private float alpha;
    private float angle;

    public BulletExplosion(Vector2 position) : 
      this(position, 0)
    {
    }
    public BulletExplosion(Vector2 position, float angle) : base("gyoza", position, Vector2.Zero,0, ActorSide.Natural, 999, 0)
    {
      alpha = 1;
      scale = 1;
      this.angle = angle;
    }

    public override void Initialize()
    {

    }

    public override void Shutdown()
    {

    }

    public override void Update(GameTime gameTime)
    {
      alpha -= alphaChangeRate;
      scale += scaleChangeRate;
      if (alpha <= 0) { Die(); }
    }

    public override void Draw()
    {
      renderer.DrawTexture(assetName, position, imageSize/2, angle, Vector2.One * scale, alpha);
    }

    public override void Hit(Character other)
    {
    }
  }
}
