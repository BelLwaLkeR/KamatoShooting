using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamatoShooting.Util;
using Microsoft.Xna.Framework;

using KamatoShooting.Device;
using KamatoShooting.Scene;

namespace KamatoShooting.Actor
{
	abstract class Character
	{
		protected enum State
		{
			Alive,
			Dying,
			Dead
		};
    
    protected   CharacterManager characterManager;
    protected   State     state;
    protected   Vector2   position;
    public      Vector2   Position { get { return position; } }
		protected   string    assetName;
    public      ActorSide actorSide { protected set; get; }
    protected   int       score;
    private     float     size;
    public      bool      isDead { get { return IsDead(); } set { if (value) { endurance = 0; } } }
    public      int       endurance { protected set; get; }
    public      Renderer  renderer;
    protected     Vector2   imageSize;
    public      Vector2   centerPosition { get { return position + imageSize / 2; } }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="assetName">画像名</param>
    /// <param name="size">あたり判定の範囲</param>
    /// <param name="actorSide">敵か味方か</param>
    /// <param name="endurance">耐久値</param>
    /// <param name="score">倒した時のスコア</param>
    public Character(string assetName, Vector2 position, float size, ActorSide actorSide, int endurance = 1, int score = 1)
      : this(assetName, position, Vector2.One * size, size, actorSide, endurance, score)
    {

    }

    public Character(string assetName, Vector2 position, float imageOneSideSize, float size, ActorSide actorSide, int endurance = 1, int score = 1)
      : this(assetName, position, Vector2.One * imageOneSideSize, size, actorSide, endurance, score)
    {

    }
    public Character(string assetName, Vector2 position, Vector2 imageSize, float size, ActorSide actorSide, int endurance = 1, int score = 1)
    {
      this.actorSide = actorSide;
			this.assetName = assetName;
      this.score = score;
      this.size = size;
      this.endurance = endurance;
      characterManager = CharacterManager.GetInstance();
      GameDevice device = GameDevice.Instance();
      renderer = device.GetRenderer();
      this.imageSize = imageSize;
      this.position = position -imageSize/2;
		}

		public abstract void Initialize();
		public abstract void Update(GameTime gameTime);
		public abstract void Shutdown();
    public abstract void Hit(Character other);
    public bool IsDead()
    {
      return endurance <= 0;
    }


		public virtual void Draw()
		{
      GameDevice.Instance().GetRenderer().DrawTexture(assetName, position);
		}

		public bool IsCollision(Character other)
		{
      
			float lengthSqrd = (centerPosition - other.centerPosition).LengthSquared();
			float radiusSum = size/2 + other.size/2;
      return lengthSqrd <= radiusSum * radiusSum;
		}

    public void Damage(int damage)
    {
      endurance -= damage;
      if (!IsDead()) { return; }
    }

    public virtual void Die()
    {
      isDead = true;
    }


  }
}
 