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
    private float scale;
    private float alpha;
    public BulletExplosion(Vector2 position) : base("gyoza", position, 0, ActorSide.Natural, 999, 0)
    {
    }

    public override void Initialize()
    {

    }

    public override void Shutdown()
    {

    }

    public override void Update(GameTime gameTime)
    {

    }

    public override void Draw()
    {
      renderer.DrawTexture(assetName, position, null, 0,Vector2.One*8, Vector2.One);
    }
  }
}
