using System;
using System.Diagnostics;
using Gtk;

namespace GtkBench
{
	partial class Tests
	{
		static void AddStressTestButtons(VBox box)
		{
			AddSignalStressTestButton(box);
			AddListTestButton(box);
		}

		static Button MakeButton(string label, EventHandler clickHandler)
		{
			var btn = new Button
			{
				Label = label,
				HeightRequest = 200,
				WidthRequest = 200,
			};
			btn.Clicked += clickHandler;
			return btn;
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
