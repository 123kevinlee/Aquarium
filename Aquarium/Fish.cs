using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Aquarium
{
	public class Fish
	{
		private PointF position;
		private PointF target;
		private Form1 parentForm;
		private float speed;
		private Image fishImage;
		private float drawScale;
		public Random random = new Random();

		public PointF GetPosition
		{
			get { return position; }
		}

		public Fish(PointF startPosition, Form1 parentForm, float speed, float drawScale, Image fishImage)
		{
			this.position = startPosition;
			this.parentForm = parentForm;
			this.speed = speed;
			this.drawScale = drawScale;
			this.fishImage = fishImage;
			target = position;
			//fishImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
		}

		public void Update()
		{
			//Setting new target
			target = FindTarget();

			//Update position
			ChangePosition();
		}

		private void ChangePosition()
		{
			float deltaX = target.X - position.X;
			float deltaY = target.Y - position.Y;

			float angleToTarget = (float)Math.Atan2(deltaY, deltaX);
			float deltaPos = Math.Min(speed, GetDistance(target, position));

			position.X += (float)(Math.Cos(angleToTarget) * deltaPos);
			position.Y += (float)(Math.Sin(angleToTarget) * deltaPos);

			
		}

		private PointF FindTarget()
		{
			if (target == position)
			{
				//float previousX = target.X;
				PointF temp = new PointF(random.Next(0, parentForm.Width), random.Next(parentForm.namePanelBottom, parentForm.Height));
				//float deltaX = target.X - position.X;
				//float deltaY = target.Y - position.Y;
				//bool direction = false;

				//if (previousX > temp.X)
				//{
				//	direction = true;
				//}
				//else if (previousX < temp.X)
				//{
				//	direction = false;
				//}
				//if (previousX > temp.X && direction == true)
				//{
				//	fishImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
				//}
				//else if (previousX < temp.X && direction == false)
				//{
				//	fishImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
				//}
				return temp;
			}
			else
			{
				return target;
			}
		}

		public static float GetDistance(PointF point1, PointF point2)
		{
			float deltaX = point1.X - point2.X;
			float deltaY = point1.Y - point2.Y;
			return (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
		}

		public void Draw(PaintEventArgs e)
		{
			e.Graphics.FillEllipse(Brushes.Black, position.X - 50, position.Y, 100, 100);
		}

		public void DrawImage(PaintEventArgs e)
		{
			float fishImageWidth = fishImage.Width * drawScale;
			float fishImageHeight = fishImage.Height * drawScale;

			float centerX = position.X - (fishImageWidth / 2);
			float centerY = position.Y - (fishImageHeight / 2);

			//e.Graphics.DrawImage(fishImage, centerX, centerY, fishImageWidth, fishImageHeight);
			e.Graphics.DrawImage(fishImage, centerX, centerY, fishImageWidth, fishImageHeight);
		}
		//private int x, y;
		////private int destinationX, destinationY;
		//private Point position;
		//private Point target;
		//private float speed;
		//private int hunger;
		//private PictureBox fish;
		//private Random random = new Random();
		//private Form mainForm;

		//public Fish(int x, int y, int speed, Form form)
		//{
		//	//this.x = x;
		//	//this.y = y;
		//	this.position = new Point(x, y);
		//	this.mainForm = form;
		//	this.speed = speed;
		//	hunger = 0;

		//	//Declaring Fish
		//	fish = new PictureBox();
		//	fish.Location = position;
		//	fish.Image = Aquarium.Properties.Resources.fishOrange1;
		//	fish.Size = new Size(49, 32);
		//	fish.SizeMode = PictureBoxSizeMode.Zoom;
		//	target = new Point(random.Next(0, mainForm.Width), random.Next(0, mainForm.Height));
		//	//destinationX = random.Next(1, 500);
		//	//destinationY = random.Next(1, 500);
		//}

		//public void Swim()
		//{
		//	//Setting new target
		//	target = FindTarget();

		//	//Update position
		//	ChangePosition();

		//}

		//private void ChangePosition()
		//{
		//	float deltaX = target.X - position.X;
		//	float deltaY = target.Y - position.Y;

		//	float angleToTarget = (float)Math.Atan2(deltaY, deltaX);

		//	position.X += (int)(Math.Cos(angleToTarget) * speed);
		//	position.Y += (int)(Math.Sin(angleToTarget) * speed);
		//}

		//private Point FindTarget()
		//{
		//	//TODO: Add targeting logic here

		//	if (x == 0 || x == mainForm.Width)
		//	{
		//		return new Point(random.Next(0, mainForm.Width), random.Next(0, mainForm.Height));
		//	}
		//	if (y == 0 || x == mainForm.Height)
		//	{
		//		return new Point(random.Next(0, mainForm.Width), random.Next(0, mainForm.Height));
		//	}
		//	return target;
		//}

		//public PictureBox fishPicture
		//{
		//	get { return fish; }
		//}

		////public void Swim()
		////{
		////	hunger++;
		////	if (hunger > 500)
		////	{
		////		fish.BackColor = Color.Red;
		////	}
		////	if (hunger > 1000)
		////	{
		////		//fish.Size(
		////	}

		////	if (x > destinationX || x == 0 || x == mainForm.Width)
		////	{
		////		x -= 1;
		////	}
		////	else
		////	{
		////		x++;
		////	}
		////	if (y > destinationY || y == 0 || x == mainForm.Height)
		////	{
		////		y -= 1;
		////	}
		////	else
		////	{
		////		y++;
		////	}
		////	position = new Point(x, y);
		////	fish.Location = position;
		////}
	}
}
