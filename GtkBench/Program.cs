using System;
using System.Diagnostics;
using Gtk;

namespace GtkBench
{
	class MainClass
	{
		static void AddSignalStressTestButton(VBox box)
		{
			var btn = new Button
			{
				Label = "Signal Stress",
				HeightRequest = 200,
				WidthRequest = 200,
			};
			btn.Clicked += (sender, e) =>
			{
				for (int i = 0; i < 100000; ++i)
					GLib.Signal.Emit(btn, "enter");
			};
			btn.Entered += (sender, e) =>
			{
			};
			box.Add(btn);
		}

		static void AddStressTestButtons(VBox box)
		{
			AddSignalStressTestButton(box);
		}

		public static void Main(string[] args)
		{
			Application.Init();
			MainWindow win = new MainWindow();
			var box = new VBox();
			win.Add(box);
			AddStressTestButtons(box);
			win.ShowAll();
			Application.Run();
		}
	}
}
