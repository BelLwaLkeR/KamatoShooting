using Microsoft.Xna.Framework;
using KamatoShooting.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Scene
{
	interface IScene
	{
		void Initialize();
		void Update(GameTime gameTime);
		void Draw( );
		void Shutdown();

		bool IsEnd();
		Scene Next();

	}
}
