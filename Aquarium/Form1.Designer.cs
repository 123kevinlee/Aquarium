namespace Aquarium
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.feed_Button = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.createFish_Button = new System.Windows.Forms.Button();
			this.titleLabel = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.fishNumber_Label = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Navy;
			this.panel1.Controls.Add(this.fishNumber_Label);
			this.panel1.Controls.Add(this.feed_Button);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.createFish_Button);
			this.panel1.Controls.Add(this.titleLabel);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(814, 37);
			this.panel1.TabIndex = 1;
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseDown);
			this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseMove);
			this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseUp);
			// 
			// feed_Button
			// 
			this.feed_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.feed_Button.FlatAppearance.BorderSize = 0;
			this.feed_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.feed_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.feed_Button.ForeColor = System.Drawing.Color.Blue;
			this.feed_Button.Location = new System.Drawing.Point(413, 5);
			this.feed_Button.Name = "feed_Button";
			this.feed_Button.Size = new System.Drawing.Size(85, 28);
			this.feed_Button.TabIndex = 3;
			this.feed_Button.Text = "Feed Fish";
			this.feed_Button.UseVisualStyleBackColor = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Aquarium.Properties.Resources.reddot;
			this.pictureBox1.Location = new System.Drawing.Point(791, 10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(20, 20);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// createFish_Button
			// 
			this.createFish_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.createFish_Button.FlatAppearance.BorderSize = 0;
			this.createFish_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.createFish_Button.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.createFish_Button.ForeColor = System.Drawing.Color.Blue;
			this.createFish_Button.Location = new System.Drawing.Point(290, 5);
			this.createFish_Button.Name = "createFish_Button";
			this.createFish_Button.Size = new System.Drawing.Size(85, 28);
			this.createFish_Button.TabIndex = 1;
			this.createFish_Button.Text = "Add Fish";
			this.createFish_Button.UseVisualStyleBackColor = false;
			this.createFish_Button.Click += new System.EventHandler(this.createFish_Button_Click);
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.Color.White;
			this.titleLabel.Location = new System.Drawing.Point(6, 7);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(150, 24);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Jack Sparrow";
			this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseDown);
			this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseMove);
			this.titleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseUp);
			// 
			// timer1
			// 
			this.timer1.Interval = 15;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// fishNumber_Label
			// 
			this.fishNumber_Label.AutoSize = true;
			this.fishNumber_Label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fishNumber_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.fishNumber_Label.Location = new System.Drawing.Point(178, 12);
			this.fishNumber_Label.Name = "fishNumber_Label";
			this.fishNumber_Label.Size = new System.Drawing.Size(79, 18);
			this.fishNumber_Label.TabIndex = 2;
			this.fishNumber_Label.Text = "Fishes: 0";
			this.fishNumber_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseDown);
			this.fishNumber_Label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseMove);
			this.fishNumber_Label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Draggable_MouseUp);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(212)))), ((int)(((byte)(244)))));
			this.ClientSize = new System.Drawing.Size(814, 549);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Text = "mainForm";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Button createFish_Button;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button feed_Button;
		private System.Windows.Forms.Label fishNumber_Label;
	}
}

