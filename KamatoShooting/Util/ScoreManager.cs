using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Util
{
  class ScoreManager
  {
    static ScoreManager instance;
    public int score { private set; get; }
    private ScoreManager() { }

    public static ScoreManager GetInstance()
    {
      if (instance == null) { instance = new ScoreManager(); }
      return instance;
    }

    public void Initialize()
    {
      ResetScore();
    }

    public void ResetScore()
    {
      score = 0;
    }

    public void AddScore(int score)
    {
      this.score += score;
    }
  }
}
