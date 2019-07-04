using KamatoShooting.Actor;
using KamatoShooting.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Properties
{
  

  class EnemySpawnPattern
  {
    CharacterManager characterManager;

    public EnemySpawnPattern(CharacterManager characterManager)
    {
      this.characterManager = characterManager;

    }

    public void EnemySpawn(EnemyType enemyType, float delay)
    {
      EnemySpawn(enemyType, delay, Screen.Width/2);
    }

    public void EnemySpawn(EnemyType enemyType, float delay, float spawnX)
    {
    }



  }
}
