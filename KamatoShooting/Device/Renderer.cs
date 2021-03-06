﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;//Assert用

namespace KamatoShooting.Device
{
  class Renderer
  {
    private ContentManager contentManager; //コンテンツ管理者
    private GraphicsDevice graphicsDevice; //グラフィック機器
    private SpriteBatch spriteBatch; //スプライト一括描画用オブジェクト

    //複数画像管理用変数の宣言と生成
    private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="content">Game1クラスのコンテンツ管理者</param>
    /// <param name="graphics">Game1クラスのグラフィック機器</param>
    public Renderer(ContentManager content, GraphicsDevice graphics)
    {
      contentManager = content;
      graphicsDevice = graphics;
      spriteBatch = new SpriteBatch(graphicsDevice);
    }

    /// <summary>
    /// 画像の読み込み
    /// </summary>
    /// <param name="assetName">アセット名（ファイルの名前）</param>
    /// <param name="filepath">画像へのファイルパス</param>
    public void LoadContent(string assetName, string filepath = "./")
    {
      //すでにキー（assetName：アセット名）が登録されているとき
      if (textures.ContainsKey(assetName))
      {
#if DEBUG //DEBUGモードの時のみ下記エラー分をコンソールへ表示
        Console.WriteLine(assetName + "はすでに読み込まれています。\n プログラムを確認してください。");
#endif

        //それ以上読み込まないのでここで終了
        return;
      }
      //画像の読み込みとDictionaryへアセット名と画像を登録
      Texture2D t = contentManager.Load<Texture2D>(filepath + assetName);
      textures.Add(assetName, t);
    }

    public void LoadContent(string assetName, Texture2D texture)
    {
      if (textures.ContainsKey(assetName))
      {
#if DEBUG //DEBUGモードの時のみ下記エラー分をコンソールへ表示
        Console.WriteLine(assetName + "はすでに読み込まれています。\n プログラムを確認してください。");
#endif

        //それ以上読み込まないのでここで終了
        return;
      }
      textures.Add(assetName, texture);
    }

    /// <summary>
    /// アンロード
    /// </summary>
    public void Unload()
    {
      textures.Clear();//Dictionaryの情報をクリア
    }

    /// <summary>
    /// 描画開始
    /// </summary>
    public void Begin()
    {
      spriteBatch.Begin();
    }

    /// <summary>
    /// 描画終了
    /// </summary>
    public void End()
    {
      spriteBatch.End();
    }

    /// <summary>
    /// 画像の描画（画像サイズはそのまま）
    /// </summary>
    /// <param name="assetName">アセット名</param>
    /// <param name="position">位置</param>
    /// <param name="alpha">透明値（1.0f：不透明 0.0f：透明）</param>
    public void DrawTexture(string assetName, Vector2 position, float alpha = 1.0f)
    {

      spriteBatch.Draw(textures[assetName], position, Color.White * alpha);
    }

    /// <summary>
    /// 画像の描画（画像を指定範囲内だけ描画）
    /// </summary>
    /// <param name="assetName">アセット名</param>
    /// <param name="position">位置</param>
    /// <param name="rect">指定範囲</param>
    /// <param name="alpha">透明値</param>
    public void DrawTexture(string assetName, Vector2 position, Rectangle rect, float alpha = 1.0f)
    {
      spriteBatch.Draw(
          textures[assetName], //テクスチャ
          position,            //位置
          rect,                //指定範囲（矩形で指定：左上の座標、幅、高さ）
          Color.White * alpha);//透明値
    }

    /// <summary>
    /// 画像を描画する
    /// </summary>
    /// <param name="assetName">アセット名</param>
    /// <param name="position">描画位置</param>
    /// <param name="centerPosition">中央位置</param>
    /// <param name="rotateAngle">角度[Rad]</param>
    /// <param name="alpha">アルファ値</param>
    public void DrawTexture(string assetName, Vector2 position, Vector2 centerPosition, float rotateAngle, float alpha = 1.0f)
    {
      DrawTexture(assetName, position+centerPosition, centerPosition, rotateAngle, Vector2.One, alpha);
    }

    /// <summary>
    /// 画像を描画する
    /// </summary>
    /// <param name="assetName">アセット名</param>
    /// <param name="position">描画位置</param>
    /// <param name="centerPosition">中央位置</param>
    /// <param name="scale">拡大率</param>
    /// <param name="alpha">アルファ値</param>
    public void DrawTexture(string assetName, Vector2 position, Vector2 centerPosition, Vector2 scale, float alpha = 1.0f)
    {
      DrawTexture(assetName, position, centerPosition, 0, scale, alpha);
    }

    /// <summary>
    /// 画像を描画する
    /// </summary>
    /// <param name="assetName">アセット名</param>
    /// <param name="position">描画位置</param>
    /// <param name="centerPosition">中央位置</param>
    /// <param name="rotateAngle">角度[Rad]</param>
    /// <param name="scale">拡大率</param>
    /// <param name="alpha">アルファ値</param>
    public void DrawTexture(string assetName, Vector2 position, Vector2 centerPosition, float rotateAngle, Vector2 scale, float alpha = 1.0f)
    {
      DrawTexture(assetName, position, null, rotateAngle, centerPosition, scale, SpriteEffects.None, 0, alpha);
    }


    public void DrawTexture(
      string assetName,
      Vector2 position,
      Rectangle? rect,
      float rotate,
      Vector2 rotatePosition,
      Vector2 scale,
      SpriteEffects effects = SpriteEffects.None,
      float depth = 0.0f,
      float alpha = 1.0f
      )
    {
      spriteBatch.Draw(
        textures[assetName],
        position,
        rect,
        Color.White * alpha,
        rotate,
        rotatePosition,
        scale,
        effects,
        depth
        );
    }

    public void DrawTexture(string assetName, Vector2 position, Color color, float alpha = 1.0f)
    {
      //デバッグモードの時のみ、画像描画前のアセット名チェック
      Debug.Assert(
        textures.ContainsKey(assetName),
        "描画時にアセット名の指定を間違えたか、画像の読み込み自体できていません");

      spriteBatch.Draw(textures[assetName], position, color * alpha);
    }

    public void DrawNumber(string assetName, Vector2 position, int number, float alpha = 1.0f)
    {
      Debug.Assert(textures.ContainsKey(assetName),
        "描画時にアセット名のしていをまちがえたか、" +
        "画像の読み込み自体出来ていません。");

      if (number < 0)
      {
        number = 0;
      }
      int width = 32;

      foreach (var n in number.ToString())
      {
        spriteBatch.Draw(textures[assetName],
          position,
          new Rectangle((n - '0') * width, 0, width, 64),
          Color.White * alpha);
        position.X += width;
      }
    }
    public void DrawNumber(string assetName, Vector2 position, float number, float alpha = 1.0f)
    {
      if (number < 0.0f)
      {
        number = 0.0f;
      }

      int width = 32;

      foreach (var n in number.ToString("00.00"))
      {
        if (n == '.')
        {
          spriteBatch.Draw(
            textures[assetName],
            position,
            new Rectangle(10 * width, 0, width, 64),
            Color.White * alpha
            );
        }
        else
        {
          spriteBatch.Draw(
            textures[assetName],
            position,
            new Rectangle((n - '0') * width, 0, width, 64),
            Color.White
            );
        }
        position.X += width;
      }

    }

    public Texture2D GetImage(string assetName)
    {
      return textures[assetName];
    }
  }
}
