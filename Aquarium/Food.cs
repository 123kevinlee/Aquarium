using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Aquarium
{
	public class Food
	{
		private PointF position;
		private Form1 parentForm;
		private float speed;
		private int size;
		public Random random = new Random();

		public PointF GetPosition
		{
			get { return position; }
		}

		public Food(PointF startPosition, Form1 parentForm, float speed, int size)
		{
			this.parentForm = parentForm;
			this.speed = speed;
			this.size = size;
			position = startPosition;

			position.X = random.Next(10, parentForm.Width - 10);
		}

		public void Update()
		{
			//Update position
			ChangePosition();
		}

		private void ChangePosition()
		{
			int targetY = parentForm.Height - size + 1;
			float deltaY = targetY - position.Y;
			float deltaPos = Math.Min(speed, deltaY);

			position.Y += (float)(deltaPos);
		}

		public void Draw(PaintEventArgs e)
		{
			Image food = Properties.Resources.food; 
			//e.Graphics.FillEllipse(Brushes.Brown, position.X, position.Y, size, size);
			e.Graphics.DrawImage(food, position);
		}
	}
}
