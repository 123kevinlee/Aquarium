﻿using System;
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
		private readonly Form1 parentForm;
		private float speed;
		private readonly Image fishImage;
		private readonly float drawScale;
		public Random random = new Random();
		public int hunger = 3000; //50 = about 1 seconds ; 3000 = about 1 minute
		private bool trackingFood = false;
		private int closestFood;

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

			FoodSystem();

			if (hunger > 0)
			{
				hunger--;
			}
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

		//Curving swimming variables
		private double moveVelocity;
		private bool upORdown;

		private PointF FindTarget()
		{
			Food[] foodies = parentForm.foodArray;
			float closestDistance = 100000000000000; //Really large number as the default closest distance :joy:

			//Checks if there is food 
			if (foodies.Length > 0)
			{
				//Calculates nearest food
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

			//How far you want a fish to travel for a piece of food
			int chaseRange = 150;

			//Target after death
			if (hunger == 0)
			{
				speed = 1.5f;
				PointF floatToTop = new PointF(position.X, parentForm.namePanelBottom);
				return floatToTop;
			}

			//tracking nearest food
			else if (closestDistance < chaseRange && hunger != 0  && hunger < 15000) //Max Hunger(15000 = 5 minutes), to prevent fatness :joy:
			{
				trackingFood = true;
				return foodies[closestFood].GetPosition;
			}

			//normal swimming
			else
			{
				moveVelocity = random.NextDouble();
				if (this.position.Y < parentForm.namePanelBottom + 20 || this.position.Y > parentForm.Height - 225) //Prevents curving off the screen
				{
					moveVelocity = 0;
				}
				
				trackingFood = false; 

				if (target == position)
				{
					PointF randomPoint = new PointF(random.Next(0, parentForm.Width), random.Next(parentForm.namePanelBottom, parentForm.Height - 5));
					int upORdownRand = random.Next(0, 2);
					if (upORdownRand == 0)
					{
						upORdown = false; //curves down
					}
					else
					{
						upORdown = true; //curves up
					}
					return randomPoint;
				}
				else
				{
					//Moving target allows the fish to curve while swimming
					PointF movingTarget = new PointF(target.X, target.Y + (float)moveVelocity);
					if (upORdown == true) 
					{
						movingTarget = new PointF(target.X, target.Y - (float)moveVelocity);
					}
					return movingTarget;

					//return target; (legacy target system: used to just return the same target until target was reached)
				}
			}
		}

		private void FoodSystem()
		{
			int eatDistance = 25;
			Food[] foodies = parentForm.foodArray;

			if (trackingFood == true)
			{
				if (Math.Abs(GetDistance(this.position, foodies[closestFood].GetPosition)) < eatDistance)
				{
					parentForm.RemoveFood(closestFood);
					hunger += 1500;
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

		public void DrawImage(PaintEventArgs e)
		{
			Image hungryFish = Properties.Resources.fishHungry;
			Image deadFish = Properties.Resources.fishDead;

			//Dead Fish...
			if (hunger == 0)
			{
				e.Graphics.DrawImage(deadFish, GetDrawPoints(target.X > position.X));
			}

			//Hungry Fish : 750 = 15 secs until death
			else if (hunger < 750 && hunger > 0)
			{
				e.Graphics.DrawImage(hungryFish, GetDrawPoints(target.X > position.X));
			}
			
			//Normal Fish
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

			if (hunger == 0)
			{
				//Belly Up!
				drawPoints[0] = new PointF(position.X + (fishImageWidth / 2), position.Y + (fishImageHeight / 2));
				drawPoints[1] = new PointF(position.X - (fishImageWidth / 2), position.Y + (fishImageHeight / 2));
				drawPoints[2] = new PointF(position.X + (fishImageWidth / 2), position.Y - (fishImageHeight / 2));
			}

			else if (isFlipped && hunger > 0)
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
	}
}
