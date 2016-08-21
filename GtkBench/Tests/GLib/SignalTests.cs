using System;
using Gtk;
namespace GtkBench
{
	partial class Tests
	{
		static void AddSignalStressTestButton(VBox box)
		{
			var btn = MakeButton("Signal Stress", OnSignalButtonClicked);
			btn.Entered += (sender, e) =>
			{
			};
			box.Add(btn);
		}

		static void OnSignalButtonClicked(object sender, EventArgs args)
		{
			var btn = (Button)sender;
			for (int i = 0; i < 100000; ++i)
				GLib.Signal.Emit(btn, "enter");
		}
	}
}
