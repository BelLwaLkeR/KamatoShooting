// このファイルで必要なライブラリのnamespaceを指定
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

using KamatoShooting.Actor;
using KamatoShooting.Device;
using KamatoShooting.Def;
using KamatoShooting.Scene;
using KamatoShooting.Util;

/// <summary>
/// プロジェクト名がnamespaceとなります
/// </summary>
namespace KamatoShooting
{
	/// <summary>
	/// ゲームの基盤となるメインのクラス
	/// 親クラスはXNA.FrameworkのGameクラス
	/// </summary>
	public class Game1 : Game
	{
		// フィールド（このクラスの情報を記述）
		private GraphicsDeviceManager graphicsDeviceManager;//グラフィックスデバイスを管理するオブジェクト
		private Renderer renderer;
		private SceneManager sceneManager;
		private GameDevice gameDevice;
		/// <summary>
		/// コンストラクタ
		/// （new で実体生成された際、一番最初に一回呼び出される）
		/// </summary>
		public Game1()
		{
			//グラフィックスデバイス管理者の実体生成
			graphicsDeviceManager = new GraphicsDeviceManager(this);
			//コンテンツデータ（リソースデータ）のルートフォルダは"Contentに設定
			Content.RootDirectory = "Content";

			graphicsDeviceManager.PreferredBackBufferWidth = Screen.Width;
			graphicsDeviceManager.PreferredBackBufferHeight = Screen.Height;

			Window.Title = "かまトゥシューティング";


		}

		/// <summary>
		/// 初期化処理（起動時、コンストラクタの後に1度だけ呼ばれる）
		/// </summary>
		protected override void Initialize()
		{
			// この下にロジックを記述
			gameDevice = GameDevice.Instance(Content, GraphicsDevice);

      renderer = gameDevice.GetRenderer();

      // この下にロジックを記述
      renderer.LoadContent("black");
      renderer.LoadContent("gyoza");
      renderer.LoadContent("kamato");
      renderer.LoadContent("pipo-btleffect");
      renderer.LoadContent("stage");
      renderer.LoadContent("white");
      renderer.LoadContent("particle");
      renderer.LoadContent("particleBlue");
      renderer.LoadContent("EnemyBullet");
      renderer.LoadContent("Cloud");



      Sound sound = gameDevice.GetSound();
      string filepath = "";             //after

      sound.LoadBGM("gameplaybgm", filepath);

      sound.LoadSE("shot", filepath);
      sound.LoadSE("die", filepath);
      sound.LoadSE("hit", filepath);
      sound.LoadSE("kill", filepath);


      sceneManager = new SceneManager();

			IScene gamePlayScene = new GamePlayScene();
			sceneManager.Add(Scene.Scene.GamePlay,gamePlayScene);
			sceneManager.Add(Scene.Scene.Ending, new Ending(gamePlayScene));
      


			// この上にロジックを記述
			base.Initialize();// 親クラスの初期化処理呼び出し。絶対に消すな！！
		}

		/// <summary>
		/// コンテンツデータ（リソースデータ）の読み込み処理
		/// （起動時、１度だけ呼ばれる）
		/// </summary>
		protected override void LoadContent()
		{

			// この上にロジックを記述
		}

		/// <summary>
		/// コンテンツの解放処理
		/// （コンテンツ管理者以外で読み込んだコンテンツデータを解放）
		/// </summary>
		protected override void UnloadContent()
		{
			// この下にロジックを記述


			// この上にロジックを記述
		}

		/// <summary>
		/// 更新処理
		/// （1/60秒の１フレーム分の更新内容を記述。音再生はここで行う）
		/// </summary>
		/// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
		protected override void Update(GameTime gameTime)
		{
			// ゲーム終了処理（ゲームパッドのBackボタンかキーボードのエスケープボタンが押されたら終了）
			if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
				 (Keyboard.GetState().IsKeyDown(Keys.Escape)))
			{
				Exit();
			}
			gameDevice.Update(gameTime);
			sceneManager.Update(gameTime);

			// この上にロジックを記述
			base.Update(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
		}

		/// <summary>
		/// 描画処理
		/// </summary>
		/// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
		protected override void Draw(GameTime gameTime)
		{
			// 画面クリア時の色を設定
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// この下に描画ロジックを記述

			sceneManager.Draw();

			//この上にロジックを記述
			base.Draw(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
		}
	}
}
