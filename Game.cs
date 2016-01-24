using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace QualcosaConAivEngine
{
	class Game
	{
		public Game()
		{
			Engine engine = new Engine("Game", 1280, 720, fullscreen: true);
			Player player = new Player(64, 16, true);
			player.LoadAssets(engine);
			engine.SpawnObject("player", player);

			Ball ball = new Ball(12, 12, false);
			ball.LoadAssets(engine);
			engine.SpawnObject("ball", ball);

			Wall[] walls = {
				new Wall(0, 0, engine.Width, 10),
				new Wall(0, 0, 10, engine.Height),
				new Wall(engine.Width - 10, 0, 10, engine.Height), 
			};
			foreach (var wall in walls)
			{
				engine.SpawnObject("wall", wall);
			}
#if DEBUG
			engine.debugCollisions = true;
#endif
			engine.Run();
		}
	}
}
