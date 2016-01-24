using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;
using OpenTK;

namespace QualcosaConAivEngine
{
	class Player : SpriteObject
	{
		private int rows;
		private int cols;
		private bool isMoving;

		public Player(int width, int height, bool autoHitBox) : base(width, height, autoHitBox)
		{
			cols = 1;
			rows = 1;
		}

		public void LoadAssets(Engine engine)
		{
			SpriteAsset image = new SpriteAsset("../../assets/bar.png");
			int tileWidth = image.Width / rows;
			int tileHeight = image.Height / cols;
			for (int x = 0; x < cols; x++)
			{
				for (int y = 0; y < rows; y++)
				{
					engine.LoadAsset($"bar_{x}_{y}", new SpriteAsset("../../assets/bar.png", x * tileWidth, y * tileHeight, tileWidth, tileHeight));
				}
			}
		}

		public override void Start()
		{
			base.Start();
			CreateAnimation();
			Y = 650;
		}

		private void CreateAnimation()
		{
			AddAnimation("bar_moving", new List<string> { "bar_0_0" }, 5);
			AddAnimation("bar_idle", new List<string> { "bar_0_0" }, 5);
			CurrentAnimation = "bar_idle";
		}

		public override void Update()
		{
			base.Update();
			Input();
		}

		public void Input()
		{
			if (Engine.MouseX > this.Width / 2 && Engine.MouseX < Engine.Width - (this.Width / 2))
				X = Engine.MouseX - this.Width / 2;
			else
			{
				if (Engine.MouseX < this.Width / 2)
					X = 0;
				else if (Engine.MouseX > Engine.Width - this.Width / 2)
					X = Engine.Width - this.Width;
			}
			if (Engine.MouseLeft)
				this.Scale = new Vector2(1.25f,1f);
			else if (Engine.MouseRight)
				this.Scale = new Vector2(0.75f, 1f);
			else if (Engine.MouseMiddle)
				this.Scale = new Vector2(1f, 1f);
		}
	}
}
