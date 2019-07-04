using KamatoShooting.Actor;
using KamatoShooting.Device;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting
{
  class GameLogic
  {
    Player player;

    public void Update()
    {
      PlayerMove();
    }

    private void PlayerMove()
    {
      float speed = 5;
      Vector2 velocity = new Vector2(); 
      if (Input.IsKeyDown(Keys.Left))   { velocity.X -= 1; }
      if (Input.IsKeyDown(Keys.Right))  { velocity.X += 1; }
      if (Input.IsKeyDown(Keys.Up))     { velocity.Y -= 1; }
      if (Input.IsKeyDown(Keys.Down))   { velocity.Y += 1; }
      
      player.position += velocity * speed;
    }


  }
}
