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
			if (files.Count == 0) { MessageBox.Show("no files"); return; }
			if (destination == "") { MessageBox.Show("no destination"); return; }

			Shovel.Start(files, destination, label_progress, progressBar1);
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
	}
}
