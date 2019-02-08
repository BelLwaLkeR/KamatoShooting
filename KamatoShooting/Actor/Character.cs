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
    
    protected State state;
    protected Vector2 position;
    public Vector2 Position { get { return position; } }
		protected string assetName;
    public ActorSide actorSide { protected set; get; }
    protected int score;
    protected CharacterManager characterManager;
    private float size;
    public bool isDead { get { return IsDead(); } set { if (value) { endurance = 0; } } }
    public int endurance { protected set; get; }
    public Renderer renderer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="assetName">画像名</param>
    /// <param name="size">あたり判定の範囲</param>
    /// <param name="actorSide">敵か味方か</param>
    /// <param name="endurance">耐久値</param>
    /// <param name="score">倒した時のスコア</param>
    public Character(string assetName, Vector2 position, float size, ActorSide actorSide ,int endurance = 1, int score=1)
		{
      this.actorSide = actorSide;
			this.assetName = assetName;
      this.score = score;
      this.size = size;
      this.endurance = endurance;
      characterManager = CharacterManager.GetInstance();
      GameDevice device = GameDevice.Instance();
      renderer = device.GetRenderer();
      this.position = position;
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
			float lengthSqrd = (position - other.position).LengthSquared();
			float radiusSum = size/2 + other.size/2;
      return lengthSqrd <= radiusSum * radiusSum;
		}

    public void Damage(int damage)
    {
      endurance -= damage;
      if (!IsDead()) { return; }
    }

    public void Die()
    {
      isDead = true;
    }


  }
}
 