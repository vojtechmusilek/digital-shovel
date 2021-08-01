using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DigitalShovel
{
	public static class Shovel
	{
		public static long totalBytesCount = 0;
		public static long totalBytesDone = 0;

		public static long totalFilesCount = 0;
		public static long totalFilesDone = 0;

		public static long currentFileWrites = 0;


		private static Label m_progressLabel;
		private static ProgressBar m_progressBar;


		public static void Start(IEnumerable<string> files, string destination, Label progressLabel, ProgressBar progressBar)
		{
			m_progressLabel = progressLabel;
			m_progressBar = progressBar;

			foreach (var item in files)
			{
				totalBytesCount += new FileInfo(item).Length;
				totalFilesCount++;
			}

			RefreshUI();

			foreach (var item in files)
			{
				bool success = false;
				for (int i = 0; i < 3; i++)
				{
					string fileDestination = "";
					try
					{
						currentFileWrites = 0;

						FileInfo source = new FileInfo(item);
						fileDestination = Path.Combine(destination, source.Name);

						if (File.Exists(fileDestination))
						{
							fileDestination = Path.Combine(destination, source.Name.Replace(source.Extension, " ") + "(" + DateTime.Now.ToString("HH-mm-ss-ff") + ")" + source.Extension);
						}

						Copy(source.FullName, fileDestination);

						totalFilesDone++;
						RefreshUI();
						success = true;
					}
					catch (Exception ex)
					{
						totalBytesDone -= currentFileWrites;
						RefreshUI();
						MessageBox.Show(ex.Message);
						Thread.Sleep(5000);
						
						try
						{
							File.Delete(fileDestination);
						}catch (Exception){}
					}

					if (success) break;
				}
			}

			RefreshUI(100);

			MessageBox.Show("Finished");
		}

		private static void RefreshUI(int val = 0)
		{
			m_progressBar.Value = val;
			m_progressBar.Refresh();

			m_progressLabel.Text = $"{totalFilesDone} files / {totalFilesCount} files\n{totalBytesDone / 1024 / 1024} MB / {totalBytesCount / 1024 / 1024} MB";
			m_progressLabel.Refresh();
		}

		private static void Copy(string from, string to)
		{
			int blockSize = 1 * 1024 * 1024;

			byte[] bytes;

			using (FileStream fsFrom = new FileStream(from, FileMode.Open, FileAccess.Read))
			{
				using (FileStream fsTo = File.Create(to))
				{
					long left = fsFrom.Length;

					while (left > 0)
					{
						if (blockSize > left) blockSize = (int)left;

						bytes = new byte[blockSize];

						fsFrom.Read(bytes, 0, blockSize);

						fsTo.Write(bytes, 0, blockSize);
						
						totalBytesDone += blockSize;
						currentFileWrites += blockSize;
						left -= blockSize;

						float newVal = ((float)(totalBytesDone / 1024 / 1024) / (float)(totalBytesCount / 1024 / 1024)) * 100;

						RefreshUI((int)newVal);
					}
				}
			}

		}
	}
}
