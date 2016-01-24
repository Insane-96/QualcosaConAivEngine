using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aiv.Engine;
using OpenTK.Input;

namespace QualcosaConAivEngine
{
	class Ball : SpriteObject
	{
		private bool isStick;
		private float direction;
		private int rows;
		private int cols;
		private float movementSpeed;

		public Ball(int width, int height, bool autoHitbox) : base(width, height, autoHitbox)
		{
			isStick = false;
			direction = 315;
			rows = 1;
			cols = 1;
			X = 640 - Width / 2;
			Y = 360 - Height / 2;
			movementSpeed = 110;
		}

		public override void Start()
		{
			base.Start();
			CreateAnimation();
			AddHitBox("ball", 0, 0, (int)Width / cols, (int)Height / rows);
		}

		public void LoadAssets(Engine engine)
		{
			SpriteAsset image = new SpriteAsset("../../assets/ball.png");
			int tileWidth = image.Width / cols;
			int tileHeight = image.Height / rows;
			for (int x = 0; x < cols; x++)
			{
				for (int y = 0; y < rows; y++)
				{
					engine.LoadAsset($"ball_{x}_{y}", new SpriteAsset("../../assets/ball.png", x * tileWidth, y * tileHeight, tileWidth, tileHeight));
				}
			}
		}

		public void CreateAnimation()
		{
			AddAnimation("ball_idle", new List<string> { "ball_0_0" }, Int32.MaxValue);
			CurrentAnimation = "ball_idle";
		}

		public override void Update()
		{
			base.Update();
			Movement();

			if (direction < 0)
				direction += 360;
			else if (direction >= 360)
				direction -= 360;
		}

		private void Movement()
		{
			if (!isStick)
			{
				X += (float)Math.Cos(Math.PI * direction / 180) * movementSpeed * Engine.DeltaTime;
				Y -= (float)Math.Sin(Math.PI * direction / 180) * movementSpeed * Engine.DeltaTime;
			}
			if (CheckCollisions().Count > 0)
			{
				direction -= 90;
				Console.WriteLine(CheckCollisions()[0].OtherHitBox);
			}
		}
	}
}
