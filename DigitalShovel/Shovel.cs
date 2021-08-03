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
		
		public static float progressBarValue = 0;
		public static string progressText = "Waiting for start";
		
		public static bool finished = false;

		public static void Start(IEnumerable<string> files, string destination)
		{
			progressText = "Started";

			foreach (var item in files)
			{
				totalBytesCount += new FileInfo(item).Length;
				totalFilesCount++;
			}

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
						success = true;
					}
					catch (Exception ex)
					{
						totalBytesDone -= currentFileWrites;
						MessageBox.Show(ex.Message);
						Thread.Sleep(5000);
						
						try
						{
							if (File.Exists(fileDestination)) File.Delete(fileDestination);
							if (File.Exists(fileDestination + ".part")) File.Delete(fileDestination + ".part");
						}
						catch (Exception){}
					}

					if (success) break;
				}
			}

			progressBarValue = 100;

			progressText = "Finished!";
			finished = true;
		}

		private static void Copy(string from, string to)
		{
			int blockSize = 8 * 1024 * 1024;

			byte[] bytes;

			using (FileStream fsFrom = new FileStream(from, FileMode.Open, FileAccess.Read))
			{
				using (FileStream fsTo = File.Create(to + ".part"))
				{
					long left = fsFrom.Length;

					int i = 0;

					progressText = "Copying";

					while (left > 0)
					{
						if (blockSize > left) blockSize = (int)left;

						bytes = new byte[blockSize];

						fsFrom.Read(bytes, 0, blockSize);
						fsTo.Write(bytes, 0, blockSize);
						if (i % 100 == 0) fsTo.Flush();

						totalBytesDone += blockSize;
						currentFileWrites += blockSize;
						left -= blockSize;

						float newVal = ((float)(totalBytesDone / 1024 / 1024) / (float)(totalBytesCount / 1024 / 1024)) * 100;

						progressBarValue = newVal;
						i++;
					}

					progressText = "Waiting for disk";
				}
			}

			File.Move(to + ".part", to);
		}
	}
}
