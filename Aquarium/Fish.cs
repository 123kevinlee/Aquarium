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
		public int hunger = 3000; //50 = about 1 seconds
		private bool trackingFood = false;
		private int closestFood = 0;

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

			Eat();

			hunger--;
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
			Food[] foodies = parentForm.foodArray;
			//Checks if there is food
			float closestDistance = 100000000000000; //Really large number :joy:
			if (foodies.Length > 0)
			{
				trackingFood = true;
				//Sorts from closest to farthest
				closestFood = 0;
				for (int i = 0; i < foodies.Length; i++)
				{
					float tempDistance = GetDistance(this.position, foodies[i].GetPosition);
					if (tempDistance < closestDistance)
					{
						closestDistance = tempDistance;
						closestFood = i;
					}
				}
			}
			
			if (closestDistance < 130) //Distance Limit
			{
				return foodies[closestFood].GetPosition;
			}
			else
			{
				trackingFood = false;
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
		}


		private void Eat()
		{
			int requiredDistance = 25;
			Food[] foodies = parentForm.foodArray;
			if (trackingFood == true)
			{
				if (Math.Abs(GetDistance(this.position, foodies[closestFood].GetPosition)) < requiredDistance)
				{
					parentForm.RemoveFood(closestFood);
					if (hunger < 5000) //Max Hunger, to prevent fatness :joy:
					{
						hunger += 1500;
					}
					trackingFood = false;
				} 
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
			Image hungryFish = Properties.Resources.fishHungry;
			if (hunger < 500)
			{
				e.Graphics.DrawImage(hungryFish, GetDrawPoints(target.X > position.X));
			}
			else
			{
				e.Graphics.DrawImage(fishImage, GetDrawPoints(target.X > position.X));
			}
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
				//right
				rotation += (float)Math.PI * 2;
				drawPoints[0] = new PointF(position.X + (fishImageWidth / 2), position.Y - (fishImageHeight / 2));
				drawPoints[1] = new PointF(position.X - (fishImageWidth / 2), position.Y - (fishImageHeight / 2));
				drawPoints[2] = new PointF(position.X + (fishImageWidth / 2), position.Y + (fishImageHeight / 2));

				drawPoints[0] = RotatePoint(drawPoints[0], position, rotation);
				drawPoints[1] = RotatePoint(drawPoints[1], position, rotation);
				drawPoints[2] = RotatePoint(drawPoints[2], position, rotation);
			}
			else
			{
				//left
				drawPoints[0] = new PointF(position.X + (fishImageWidth / 2), position.Y + (fishImageHeight / 2));
				drawPoints[1] = new PointF(position.X - (fishImageWidth / 2), position.Y + (fishImageHeight / 2));
				drawPoints[2] = new PointF(position.X + (fishImageWidth / 2), position.Y - (fishImageHeight / 2));

				drawPoints[0] = RotatePoint(drawPoints[0], position, rotation);
				drawPoints[1] = RotatePoint(drawPoints[1], position, rotation);
				drawPoints[2] = RotatePoint(drawPoints[2], position, rotation);
			}
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

		//public void DeathAnimation()
		//{
		//	int targetY = 0;
		//	int speed = 1;
		//	float deltaY = targetY - position.Y;
		//	float deltaPos = Math.Min(speed, deltaY);

		//	position.Y += (float)(deltaPos);
		//}
	}
}
