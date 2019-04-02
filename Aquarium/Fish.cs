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
		public float roat;

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
				PointF temp = new PointF(random.Next(0, parentForm.Width), random.Next(parentForm.namePanelBottom, parentForm.Height));
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
			e.Graphics.DrawImage(fishImage, GetDrawPoints(target.X > position.X));
		}

		private PointF[] GetDrawPoints(bool isFlipped)
		{
			float fishImageWidth = fishImage.Width * drawScale;
			float fishImageHeight = fishImage.Height * drawScale;

			PointF[] drawPoints = new PointF[3];

			float deltaX = target.X - position.X;
			float deltaY = target.Y - position.Y;
			float rotation = (float)Math.Atan2(deltaY, deltaX);
			roat = rotation;

			if (isFlipped)
			{
				drawPoints[0] = new PointF(position.X + (fishImageWidth / 2), position.Y - (fishImageHeight / 2));
				drawPoints[1] = new PointF(position.X - (fishImageWidth / 2), position.Y - (fishImageHeight / 2));
				drawPoints[2] = new PointF(position.X + (fishImageWidth / 2), position.Y + (fishImageHeight / 2));

				drawPoints[0] = RotatePoint(drawPoints[0], position, rotation);
				drawPoints[1] = RotatePoint(drawPoints[1], position, rotation);
				drawPoints[2] = RotatePoint(drawPoints[2], position, rotation);
			}
			else
			{
				drawPoints[0] = new PointF(position.X - (fishImageWidth / 2), position.Y - (fishImageHeight / 2));
				drawPoints[1] = new PointF(position.X + (fishImageWidth / 2), position.Y - (fishImageHeight / 2));
				drawPoints[2] = new PointF(position.X - (fishImageWidth / 2), position.Y + (fishImageHeight / 2));

				drawPoints[0] = RotatePoint(drawPoints[0], position, rotation);
				drawPoints[1] = RotatePoint(drawPoints[1], position, rotation);
				drawPoints[2] = RotatePoint(drawPoints[2], position, rotation);
			}
			//if (rotation > Math.PI / 2 || rotation < -Math.PI / 2 )
			//{
			//	PointF[] flipPoints = new PointF[3];
			//	flipPoints[0] = drawPoints[1];
			//	flipPoints[1] = drawPoints[0];
			//	flipPoints[2] = new PointF(flipPoints[0].X, drawPoints[2].Y);
			//	return flipPoints;
			//}
			//}
			//}

			return drawPoints;
		}

		public static PointF RotatePoint(PointF originalPoint, PointF axis, float rotation)
		{
			PointF relativePoint = new PointF(originalPoint.X - axis.X, originalPoint.Y - axis.Y);
			PointF rotatedPoint = new PointF(0, 0);

			//Rotate
			rotatedPoint.X = (float)((relativePoint.X * Math.Cos(rotation)) - (relativePoint.Y * Math.Sin(rotation)));
			rotatedPoint.Y = (float)((relativePoint.X * Math.Sin(rotation)) + (relativePoint.Y * Math.Cos(rotation)));

			//Recentering
			rotatedPoint.X += axis.X;
			rotatedPoint.Y += axis.Y;

			return rotatedPoint;
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
