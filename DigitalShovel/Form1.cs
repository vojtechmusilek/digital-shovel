using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalShovel
{
	public partial class Form1 : Form
	{
		List<string> files;
		string destination = "";

		public Form1()
		{
			InitializeComponent();

			panel1.AllowDrop = true;
			panel1.DragEnter += panel_DragEnter;
			panel1.DragDrop += panel_DragDrop;
			panel1.DragLeave += panel_DragLeave;

			files = new List<string>();
		}

		int progressDots = 0;

		private void UpdateUI()
		{
			if (Shovel.finished)
			{
				progressDots = 0;
				timer1.Stop();
			}

			progressBar1.Value = (int)Shovel.progressBarValue;
			progressBar1.Refresh();

			label_progress.Text = 
				$"{Shovel.totalFilesDone} files / {Shovel.totalFilesCount} files\n"+
				$"{Shovel.totalBytesDone / 1024 / 1024} MB / {Shovel.totalBytesCount / 1024 / 1024} MB\n"+
				$"{Shovel.progressText}{"".PadLeft(progressDots, '.')}";
			label_progress.Refresh();

			progressDots++;
			if (progressDots > 3) progressDots = 0;
		}


		private void panel_DragDrop(object sender, DragEventArgs e)
		{
			foreach (var item in (string[])e.Data.GetData(DataFormats.FileDrop))
			{
				if (File.Exists(item) && !files.Contains(item))
				{
					files.Add(item);
				}
			}

			label_filesCount.Text = files.Count + " files";
			panel1.BackColor = Color.FromName("ControlDark");
		}

		private void panel_DragEnter(object sender, DragEventArgs e)
		{
			panel1.BackColor = Color.FromName("ControlDarkDark");
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
		}

		private void panel_DragLeave(object sender, EventArgs e)
		{
			panel1.BackColor = Color.FromName("ControlDark");
		}
		


		private void button_reset_Click(object sender, EventArgs e)
		{
			files.Clear();
			destination = "";
			label_filesCount.Text = "0 files";
			label_destination.Text = "No destination";
			progressBar1.Value = 0;
			label_progress.Text = "0 files / 0 files\n0 MB / 0 MB";
			Shovel.currentFileWrites = 0;
			Shovel.totalBytesCount = 0;
			Shovel.totalBytesDone = 0;
			Shovel.totalFilesCount = 0;
			Shovel.totalFilesDone = 0;
		}

		private void button_start_Click(object sender, EventArgs e)
		{
			button_start.Enabled = false;
			button_reset.Enabled = false;
			button_destination.Enabled = false;
			panel1.AllowDrop = false;
			panel1.Enabled = false;

			if (files.Count == 0) { MessageBox.Show("no files"); return; }
			if (destination == "") { MessageBox.Show("no destination"); return; }

			Task.Run(() =>
			{
				Shovel.Start(files, destination);
			});
		}

		private void button_destination_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					destination = fbd.SelectedPath;

					string vizDestination = destination;

					if (vizDestination.Length > 25)
					{
						vizDestination = "..." + destination.Substring(destination.Length - Math.Min(22, destination.Length));
					}

					label_destination.Text = vizDestination;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			UpdateUI();
		}
	}
}
