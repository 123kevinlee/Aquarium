using System;
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

		private void Form1_Load(object sender, EventArgs e)
		{
			timer1.Enabled = true;
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			#region Background objects
			Image sand = Properties.Resources.sand;
			PointF sandPos1 = new PointF(0, 500);
			PointF sandPos2 = new PointF(500, 500);
			e.Graphics.DrawImage(sand, sandPos2);
			e.Graphics.DrawImage(sand, sandPos1);

			Image rockWgrass = Properties.Resources.rockWgrass;
			PointF rockWgrassPos = new PointF(525, 380);
			e.Graphics.DrawImage(rockWgrass, rockWgrassPos);

			Image treasureChest = Properties.Resources.treasureChest;
			PointF treasureChestPos = new PointF(60, 400);
			e.Graphics.DrawImage(treasureChest, treasureChestPos);

			Image seaweed = Properties.Resources.seaweed;
			PointF seaweedPos1 = new PointF(175, 483);
			e.Graphics.DrawImage(seaweed, seaweedPos1);

			PointF seaweedPos4 = new PointF(325, 483);
			e.Graphics.DrawImage(seaweed, seaweedPos4);

			PointF seaweedPos6 = new PointF(425, 483);
			e.Graphics.DrawImage(seaweed, seaweedPos6);

			PointF seaweedPos7 = new PointF(475, 483);
			e.Graphics.DrawImage(seaweed, seaweedPos7);

			#endregion

			for (int i = 0; i < school.Length; i++)
			{
				school[i].DrawImage(e);
			}

			for (int i = 0; i < foodies.Length; i++)
			{
				foodies[i].Draw(e);
			}

			#region Foreground Objects

			Image rockAqua = Properties.Resources.rock;
			PointF rockAquaPos = new PointF(0, 440);
			e.Graphics.DrawImage(rockAqua, rockAquaPos);

			PointF seaweedPos8 = new PointF(-30, 483);
			e.Graphics.DrawImage(seaweed, seaweedPos8);

			PointF seaweedPos2 = new PointF(225, 483);
			e.Graphics.DrawImage(seaweed, seaweedPos2);

			PointF seaweedPos3 = new PointF(275, 483);
			e.Graphics.DrawImage(seaweed, seaweedPos3);

			PointF seaweedPos5 = new PointF(375, 483);
			e.Graphics.DrawImage(seaweed, seaweedPos5);
			#endregion

			#region foreachExample

			//foreach (Fish fish in school)
			//{
			//	fish.DrawImage(e);
			//}

			#endregion
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//check to see there are fish in the school
			for (int i = 0; i < school.Length; i++)
			{
				school[i].Update();
				if (school[i].hunger == 0 && school[i].GetPosition.Y == namePanelBottom)
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
		}

		private void createFish_Button_Click(object sender, EventArgs e)
		{
			AddFish(new Fish(new PointF(15, titleLabel.Bottom + 5), this, 4F, (float)1.4, Properties.Resources.fishOrange1));
			fishNumber_Label.Text = $"Fishes: {school.Length}";
		}

		private void feed_Button_Click(object sender, EventArgs e)
		{
			Random randomSpeed = new Random();
			int baseSpeed = randomSpeed.Next(2, 3);
			double extra = randomSpeed.NextDouble();
			double speed = baseSpeed + extra; //OG Default = 2f
			AddFood(new Food(new PointF(15, titleLabel.Bottom + 5), this, (float)speed, 10));

			#region FoodForm
			//Possible separate feed form implementation

			//if (foodAmount_text.Text != string.Empty)
			//{
			//	int amountFood = Convert.ToInt16(foodAmount_text.Text);
			//	for (int i = 0; i < amountFood; i++)
			//	{
			//		//MessageBox.Show(Convert.ToString(i));
			//		System.Threading.Thread.Sleep(1);
			//		AddFood(new Food(new PointF(15, titleLabel.Bottom + 5), this, 2F, 10));
			//	}
			//}
			//else
			//{
			//	AddFood(new Food(new PointF(15, titleLabel.Bottom + 5), this, 2F, 10));
			//}
			//FoodForm FoodForm = new FoodForm();
			//this.Controls.Add(FoodForm);
			//FoodForm.BringToFront();
			//FoodForm.Top = 0;
			//FoodForm.Left = feed_Button.Right;
			#endregion
		}

		public void AddFish(Fish fish)
		{
			Array.Resize(ref school, school.Length + 1);
			school[school.Length - 1] = fish;
		}

		public void RemoveFish(int index)
		{
			FishSwap(ref school[index], ref school[school.Length - 1]);
			Array.Resize(ref school, school.Length - 1);
			fishNumber_Label.Text = $"Fishes: {school.Length}";
		}

		public void FishSwap(ref Fish x, ref Fish y)
		{
			var temp = x;
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
			FoodSwap(ref foodies[index], ref foodies[foodies.Length - 1]);
			Array.Resize(ref foodies, foodies.Length - 1);
		}

		public void FoodSwap(ref Food x, ref Food y)
		{
			var temp = x;
			x = y;
			y = temp;
		}

		//X Button
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//Form get accessors

		public Point MousePos
		{
			get { return PointToClient(MousePosition); }
		}

		public int namePanelBottom
		{
			get { return panel1.Bottom; }
		}

		public Food[] foodArray
		{
			get { return foodies; }
		}
	}
}
