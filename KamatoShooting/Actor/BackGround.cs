using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamatoShooting.Def;
using KamatoShooting.Device;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor
{
  class BackGround : Character
  {
    private float scrollSpeed;
    private int imageHeight;

    public BackGround(float scrollSpeed,float y):base("stage", Vector2.Zero, 0, ActorSide.Natural)
    {
      this.scrollSpeed = scrollSpeed;
      imageHeight = GameDevice.Instance().GetRenderer().GetImage(assetName).Height;
      position = new Vector2(0,imageHeight*y);
    }

    public override void Initialize()
    {
    }

    public override void Shutdown()
    {
    }

    public override void Update(GameTime gameTime)
    {
      position.Y += scrollSpeed;
      if (position.Y >= Screen.Height)
      {
        position.Y -= imageHeight * 2;
      }
    }
  }
}
