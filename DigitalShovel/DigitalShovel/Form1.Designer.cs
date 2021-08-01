namespace DigitalShovel
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.label_ui456 = new System.Windows.Forms.Label();
			this.label_ui1 = new System.Windows.Forms.Label();
			this.button_start = new System.Windows.Forms.Button();
			this.button_reset = new System.Windows.Forms.Button();
			this.label_filesCount = new System.Windows.Forms.Label();
			this.label_ui3 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label_progress = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button_destination = new System.Windows.Forms.Button();
			this.label_destination = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AllowDrop = true;
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Controls.Add(this.label_ui456);
			this.panel1.Location = new System.Drawing.Point(114, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(163, 74);
			this.panel1.TabIndex = 0;
			// 
			// label_ui456
			// 
			this.label_ui456.AutoSize = true;
			this.label_ui456.Location = new System.Drawing.Point(40, 30);
			this.label_ui456.Name = "label_ui456";
			this.label_ui456.Size = new System.Drawing.Size(83, 15);
			this.label_ui456.TabIndex = 5;
			this.label_ui456.Text = "Drop files here";
			// 
			// label_ui1
			// 
			this.label_ui1.AutoSize = true;
			this.label_ui1.Location = new System.Drawing.Point(12, 12);
			this.label_ui1.Name = "label_ui1";
			this.label_ui1.Size = new System.Drawing.Size(55, 15);
			this.label_ui1.TabIndex = 1;
			this.label_ui1.Text = "1. Source";
			// 
			// button_start
			// 
			this.button_start.Location = new System.Drawing.Point(202, 183);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(75, 23);
			this.button_start.TabIndex = 2;
			this.button_start.Text = "Start";
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += new System.EventHandler(this.button_start_Click);
			// 
			// button_reset
			// 
			this.button_reset.Location = new System.Drawing.Point(114, 183);
			this.button_reset.Name = "button_reset";
			this.button_reset.Size = new System.Drawing.Size(75, 23);
			this.button_reset.TabIndex = 3;
			this.button_reset.Text = "Reset";
			this.button_reset.UseVisualStyleBackColor = true;
			this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
			// 
			// label_filesCount
			// 
			this.label_filesCount.AutoSize = true;
			this.label_filesCount.Location = new System.Drawing.Point(114, 89);
			this.label_filesCount.Name = "label_filesCount";
			this.label_filesCount.Size = new System.Drawing.Size(37, 15);
			this.label_filesCount.TabIndex = 5;
			this.label_filesCount.Text = "0 files";
			// 
			// label_ui3
			// 
			this.label_ui3.AutoSize = true;
			this.label_ui3.Location = new System.Drawing.Point(12, 183);
			this.label_ui3.Name = "label_ui3";
			this.label_ui3.Size = new System.Drawing.Size(59, 15);
			this.label_ui3.TabIndex = 1;
			this.label_ui3.Text = "3. Actions";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 235);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(268, 23);
			this.progressBar1.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel2.Location = new System.Drawing.Point(-3, 215);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(296, 10);
			this.panel2.TabIndex = 8;
			// 
			// label_progress
			// 
			this.label_progress.AutoSize = true;
			this.label_progress.Location = new System.Drawing.Point(12, 261);
			this.label_progress.Name = "label_progress";
			this.label_progress.Size = new System.Drawing.Size(78, 30);
			this.label_progress.TabIndex = 1;
			this.label_progress.Text = "0 files / 0 files\r\n0 MB / 0 MB";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 125);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "2. Destination";
			// 
			// button_destination
			// 
			this.button_destination.Location = new System.Drawing.Point(114, 125);
			this.button_destination.Name = "button_destination";
			this.button_destination.Size = new System.Drawing.Size(123, 23);
			this.button_destination.TabIndex = 10;
			this.button_destination.Text = "Set Destination";
			this.button_destination.UseVisualStyleBackColor = true;
			this.button_destination.Click += new System.EventHandler(this.button_destination_Click);
			// 
			// label_destination
			// 
			this.label_destination.AutoSize = true;
			this.label_destination.Location = new System.Drawing.Point(114, 151);
			this.label_destination.Name = "label_destination";
			this.label_destination.Size = new System.Drawing.Size(85, 15);
			this.label_destination.TabIndex = 5;
			this.label_destination.Text = "No destination";
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 306);
			this.Controls.Add(this.label_destination);
			this.Controls.Add(this.button_destination);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label_progress);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label_ui3);
			this.Controls.Add(this.label_filesCount);
			this.Controls.Add(this.button_reset);
			this.Controls.Add(this.button_start);
			this.Controls.Add(this.label_ui1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form1";
			this.Text = "Digital Shovel";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label_ui1;
		private System.Windows.Forms.Button button_start;
		private System.Windows.Forms.Button button_reset;
		private System.Windows.Forms.Label label_filesCount;
		private System.Windows.Forms.Label label_ui3;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label_progress;
		private System.Windows.Forms.Label label_ui456;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_destination;
		private System.Windows.Forms.Label label_destination;
	}
}

