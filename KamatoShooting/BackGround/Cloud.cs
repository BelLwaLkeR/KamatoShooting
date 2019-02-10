using KamatoShooting.Actor;
using KamatoShooting.Def;
using KamatoShooting.Device;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.BackGround
{
  class Cloud : Character
  {
    float speed;
    Random random;
    float scale;
    public Cloud() : base("Cloud", Vector2.Zero,new Vector2(650f,476f), 0, ActorSide.Natural, 1, 0)
    {
      random = GameDevice.Instance().GetRandom();
    }

    public override void Hit(Character other)
    {
    }

    public override void Initialize()
    {
      position = new Vector2(random.Next((int)(-imageSize.X / 2f), Screen.Width), random.Next((int)-imageSize.Y*3,(int)-imageSize.Y));
      speed = random.Next(10, 20);
      scale = (float)random.NextDouble()*0.8f +0.3f;

    }

    public override void Shutdown()
    {
    }

    public override void Update(GameTime gameTime)
    {
      position.Y += speed;
      if (position.Y > Screen.Height) { Initialize(); }
    }

    public override void Draw()
    {
      renderer.DrawTexture(assetName, position, Vector2.Zero, Vector2.One*scale);

    }
  }
}
