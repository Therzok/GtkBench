using System;
using System.Linq;
using GLib;
using Gtk;
namespace GtkBench
{
	partial class Tests
	{
		struct Data
		{
			int x, y, z, t;
		}

		static Data[] arr = Enumerable.Repeat(new Data (), 100000).ToArray();
		static ListBase slist = new SList(arr, typeof(Data), true, true);

		static void AddListTestButton(VBox box)
		{
			var buttonBox = new HBox();
			buttonBox.Add(MakeButton("SList Stress for", OnListButtonClickedFor));
			buttonBox.Add(MakeButton("SList Stress foreach", OnListButtonClickedForeach));
			buttonBox.Add(MakeButton("SList Stress Linq", OnListButtonClickedLinq));
			box.Add(buttonBox);
		}

		static void OnListButtonClickedFor(object sender, EventArgs args)
		{
			var btn = (Button)sender;

			var res = new Data[slist.Count];
			for (int i = 0; i < slist.Count; ++i)
				res[i] = (Data)slist[i];
		}

		static void OnListButtonClickedForeach(object sender, EventArgs args)
		{
			var btn = (Button)sender;

			// This one is used for GLib.Marshaller.ListToArray.
			var res = new Data[slist.Count];
			int i = 0;
			foreach (Data item in slist)
				res[i] = item;
		}

		static void OnListButtonClickedLinq(object sender, EventArgs args)
		{
			var btn = (Button)sender;

			var res = slist.OfType<Data>().ToArray();
		}

		static void OnListButtonClickedMarshaller(object sender, EventArgs args)
		{
			var btn = (Button)sender;

			//var res = GLib.Marshaller.ListToArray<Data>(slist);
		}
	}
}
