﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aquarium
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private Fish[] school = new Fish[0];
		private Food[] foodies = new Food[0];
		#region MakeDraggable
		private bool mouseDown;
		private Point lastLocation;

		private void Draggable_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDown = true;
			lastLocation = e.Location;
		}

		private void Draggable_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				this.Location = new Point(
					(this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

				this.Update();
			}
		}

		private void Draggable_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;
		}
		#endregion

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			//Array.Resize(ref school, school.Length + 1);
			//Fish fishy = new Fish(e.X, e.Y, 4, this);
			//school[school.Length - 1] = fishy;
			//this.Controls.Add(fishy.fishPicture);
		}

		private void createFish_Button_Click(object sender, EventArgs e)
		{
			AddFish(new Fish(new PointF(15, titleLabel.Bottom + 5), this, 4F, (float)1.4, Properties.Resources.fishOrange1));
			fishNumber_Label.Text = $"Fishes: {school.Length}";
		}

		//private Fish fishy;

		private void Form1_Load(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			//fishy = new Fish(new PointF(15, titleLabel.Bottom + 5), this, 4F, (float)1.4, Properties.Resources.fishOrange1);
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < school.Length; i++)
			{
				school[i].DrawImage(e);
			}

			for (int i = 0; i < foodies.Length; i++)
			{
				foodies[i].Draw(e);
			}
			//foreach example
			//foreach (Fish fish in school)
			//{
			//	fish.DrawImage(e);
			//}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			//check to see there are fish in the school
			
			for (int i = 0; i < school.Length; i++)
			{
				school[i].Update();
				if (school[i].hunger == 0)
				{
					RemoveFish(i);
				}
				Invalidate();
			}

			for (int i = 0; i < foodies.Length; i++)
			{
				foodies[i].Update();
				Invalidate();
			}


			//foreach (Fish fishy in school)
			//{
			//	fishy.Update();
			//	//Recalls draw timer
			//	Invalidate();
			//}
		}

		public void AddFish(Fish fish)
		{
			Array.Resize(ref school, school.Length + 1);
			school[school.Length - 1] = fish;
		}

		public void RemoveFish(int index)
		{
			fishSwap(ref school[index], ref school[school.Length - 1]);
			Array.Resize(ref school, school.Length - 1);
			fishNumber_Label.Text = $"Fishes: {school.Length}";
		}

		public void fishSwap(ref Fish x, ref Fish y)
		{
			Fish temp = x;
			x = y;
			y = temp;
		}

		public void AddFood(Food foodPiece)
		{
			Array.Resize(ref foodies, foodies.Length + 1);
			foodies[foodies.Length - 1] = foodPiece;
		}

		public void RemoveFood(int index)
		{
			foodSwap(ref foodies[index], ref foodies[foodies.Length - 1]);
			Array.Resize(ref foodies, foodies.Length - 1);
		}

		public void foodSwap(ref Food x, ref Food y)
		{
			Food temp = x;
			x = y;
			y = temp;
		}
		//X Button
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public Point MousePos
		{
			get
			{
				return PointToClient(MousePosition);
			}
		}

		public int namePanelBottom
		{
			get { return panel1.Bottom; }
		}

		private void feed_Button_Click(object sender, EventArgs e)
		{
			AddFood(new Food(new PointF(15, titleLabel.Bottom + 5), this, 2F, 10));
		}

		public Food[] foodArray
		{
			get { return foodies; }
		}
	}

}
