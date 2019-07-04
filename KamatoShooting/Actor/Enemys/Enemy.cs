using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamatoShooting.Actor.Bullets;
using KamatoShooting.Def;
using KamatoShooting.Device;
using KamatoShooting.Util;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor
{
  public enum EnemyType
  {
    Kurotama,
    Shirotama,
    Paddle,
    PrincePachi
  };


  abstract class Enemy : Character
  {
    private Player player;

    #region その他処理
    private PatternUpdate pattern;
    private Timer shotTimer;
    private Sound sound;

    public Enemy(Vector2 position, int endurance = 50, EnemyType enemyType)
      : base(enemyType, position, 64, 64, ActorSide.Enemy, endurance, 1)
    {
      characterManager.Add(this);
      pattern = new PatternUpdate();
      Initialize();
      shotTimer = new CountDownTimer(0.5f);
      sound = GameDevice.Instance().GetSound();
    }

    public override void Hit(Character other)
    {
      Damage(1);
      if (endurance <= 0)
      {
        sound.PlaySE("kill");
      }
    }

    public override void Initialize()
    {
      player = CharacterManager.GetInstance().GetPlayer();
      SetPattern();
    }

    public override void Shutdown()
    {
    }

    public override void Update(GameTime gameTime)
    {
      if (shotTimer.IsTime())
      {
        Shot();
        shotTimer.Initialize();
      }


      pattern.Update(gameTime);
      if (position.Y > Screen.Height) { Die(); }
    }

    private void SetPattern()
    {
      ClearPattern();
      AddPattern(0.5f, () => { position.Y += 3.0f; });
      AddPattern(5f, () => { position.Y += 0.3f; });
      AddPattern(0.5f, () => { position.Y += 5f; });
      AddPattern(2.5f, () => { position.Y += 15.0f; });
      AddPattern(2.5f, () => { Die(); });
    }

    public void ClearPattern()
    {
      pattern.ClearPattern();
    }

    public void AddPattern(float time, PatternMethod pattern)
    {
      this.pattern.AddPattern(time, pattern);
    }
    #endregion

    protected virtual void Shot()
    {
      Vector2 velocity = new Vector2(0, 10);
      new EnemyBullet(centerPosition, velocity);
    }


  }
}
