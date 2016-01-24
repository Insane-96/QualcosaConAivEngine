using System;
using System.Drawing;
using Aiv.Engine;

namespace QualcosaConAivEngine
{
	class Wall:RectangleObject
	{
		public Wall(int X, int Y, int width, int height):base(width, height)
		{
			this.Color = Color.GreenYellow;
			this.Fill = true;
			this.X = X;
			this.Y = Y;
		}

		public override void Start()
		{
			base.Start();
			AddHitBox($"wall_{this.Id}", 0, 0, (int)this.Width, (int)this.Height);
		}
	}
}
