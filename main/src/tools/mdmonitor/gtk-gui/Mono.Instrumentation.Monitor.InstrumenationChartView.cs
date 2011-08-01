
// This file has been generated by the GUI designer. Do not modify.
namespace Mono.Instrumentation.Monitor
{
	internal partial class InstrumenationChartView
	{
		private global::Gtk.VBox vbox3;
		private global::Gtk.HPaned hpaned2;
		private global::Gtk.HBox hbox4;
		private global::Gtk.VBox boxCharts;
		private global::Gtk.HBox hboxChartBar;
		private global::Gtk.ToggleButton toggleTimeView;
		private global::Gtk.ToggleButton toggleListView;
		private global::Gtk.Button buttonZoomOut;
		private global::Gtk.Button buttonZoomIn;
		private global::Gtk.VBox frameCharts;
		private global::Gtk.HScrollbar chartScroller;
		private global::Gtk.VBox vbox5;
		private global::Gtk.HBox hboxSeriesBar;
		private global::Gtk.Button buttonRemoveCounter;
		private global::Gtk.Button buttonAddCounter;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TreeView listSeries;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Mono.Instrumentation.Monitor.InstrumenationChartView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Mono.Instrumentation.Monitor.InstrumenationChartView";
			// Container child Mono.Instrumentation.Monitor.InstrumenationChartView.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hpaned2 = new global::Gtk.HPaned ();
			this.hpaned2.CanFocus = true;
			this.hpaned2.Name = "hpaned2";
			this.hpaned2.Position = 471;
			// Container child hpaned2.Gtk.Paned+PanedChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.boxCharts = new global::Gtk.VBox ();
			this.boxCharts.Name = "boxCharts";
			this.boxCharts.Spacing = 6;
			// Container child boxCharts.Gtk.Box+BoxChild
			this.hboxChartBar = new global::Gtk.HBox ();
			this.hboxChartBar.Name = "hboxChartBar";
			this.hboxChartBar.Spacing = 6;
			// Container child hboxChartBar.Gtk.Box+BoxChild
			this.toggleTimeView = new global::Gtk.ToggleButton ();
			this.toggleTimeView.CanFocus = true;
			this.toggleTimeView.Name = "toggleTimeView";
			this.toggleTimeView.UseUnderline = true;
			this.toggleTimeView.Relief = ((global::Gtk.ReliefStyle)(2));
			this.toggleTimeView.Label = global::Mono.Unix.Catalog.GetString ("Time View");
			this.hboxChartBar.Add (this.toggleTimeView);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hboxChartBar [this.toggleTimeView]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hboxChartBar.Gtk.Box+BoxChild
			this.toggleListView = new global::Gtk.ToggleButton ();
			this.toggleListView.CanFocus = true;
			this.toggleListView.Name = "toggleListView";
			this.toggleListView.UseUnderline = true;
			this.toggleListView.Relief = ((global::Gtk.ReliefStyle)(2));
			this.toggleListView.Label = global::Mono.Unix.Catalog.GetString ("List View");
			this.hboxChartBar.Add (this.toggleListView);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxChartBar [this.toggleListView]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hboxChartBar.Gtk.Box+BoxChild
			this.buttonZoomOut = new global::Gtk.Button ();
			this.buttonZoomOut.CanFocus = true;
			this.buttonZoomOut.Name = "buttonZoomOut";
			this.buttonZoomOut.UseUnderline = true;
			this.buttonZoomOut.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child buttonZoomOut.Gtk.Container+ContainerChild
			global::Gtk.Alignment w3 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w4 = new global::Gtk.HBox ();
			w4.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-zoom-out", global::Gtk.IconSize.Menu);
			w4.Add (w5);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w7 = new global::Gtk.Label ();
			w4.Add (w7);
			w3.Add (w4);
			this.buttonZoomOut.Add (w3);
			this.hboxChartBar.Add (this.buttonZoomOut);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hboxChartBar [this.buttonZoomOut]));
			w11.PackType = ((global::Gtk.PackType)(1));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hboxChartBar.Gtk.Box+BoxChild
			this.buttonZoomIn = new global::Gtk.Button ();
			this.buttonZoomIn.CanFocus = true;
			this.buttonZoomIn.Name = "buttonZoomIn";
			this.buttonZoomIn.UseUnderline = true;
			this.buttonZoomIn.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child buttonZoomIn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w12 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w13 = new global::Gtk.HBox ();
			w13.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w14 = new global::Gtk.Image ();
			w14.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-zoom-in", global::Gtk.IconSize.Menu);
			w13.Add (w14);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w16 = new global::Gtk.Label ();
			w13.Add (w16);
			w12.Add (w13);
			this.buttonZoomIn.Add (w12);
			this.hboxChartBar.Add (this.buttonZoomIn);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hboxChartBar [this.buttonZoomIn]));
			w20.PackType = ((global::Gtk.PackType)(1));
			w20.Position = 3;
			w20.Expand = false;
			w20.Fill = false;
			this.boxCharts.Add (this.hboxChartBar);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.boxCharts [this.hboxChartBar]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child boxCharts.Gtk.Box+BoxChild
			this.frameCharts = new global::Gtk.VBox ();
			this.frameCharts.Name = "frameCharts";
			this.frameCharts.Spacing = 6;
			// Container child frameCharts.Gtk.Box+BoxChild
			this.chartScroller = new global::Gtk.HScrollbar (null);
			this.chartScroller.Name = "chartScroller";
			this.chartScroller.Adjustment.Upper = 100;
			this.chartScroller.Adjustment.PageIncrement = 10;
			this.chartScroller.Adjustment.PageSize = 10;
			this.chartScroller.Adjustment.StepIncrement = 1;
			this.frameCharts.Add (this.chartScroller);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.frameCharts [this.chartScroller]));
			w22.PackType = ((global::Gtk.PackType)(1));
			w22.Position = 2;
			w22.Expand = false;
			w22.Fill = false;
			this.boxCharts.Add (this.frameCharts);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.boxCharts [this.frameCharts]));
			w23.Position = 1;
			this.hbox4.Add (this.boxCharts);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.boxCharts]));
			w24.Position = 0;
			this.hpaned2.Add (this.hbox4);
			global::Gtk.Paned.PanedChild w25 = ((global::Gtk.Paned.PanedChild)(this.hpaned2 [this.hbox4]));
			w25.Resize = false;
			// Container child hpaned2.Gtk.Paned+PanedChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hboxSeriesBar = new global::Gtk.HBox ();
			this.hboxSeriesBar.Name = "hboxSeriesBar";
			this.hboxSeriesBar.Spacing = 6;
			// Container child hboxSeriesBar.Gtk.Box+BoxChild
			this.buttonRemoveCounter = new global::Gtk.Button ();
			this.buttonRemoveCounter.CanFocus = true;
			this.buttonRemoveCounter.Name = "buttonRemoveCounter";
			this.buttonRemoveCounter.UseStock = true;
			this.buttonRemoveCounter.UseUnderline = true;
			this.buttonRemoveCounter.Relief = ((global::Gtk.ReliefStyle)(2));
			this.buttonRemoveCounter.Label = "gtk-remove";
			this.hboxSeriesBar.Add (this.buttonRemoveCounter);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hboxSeriesBar [this.buttonRemoveCounter]));
			w26.PackType = ((global::Gtk.PackType)(1));
			w26.Position = 0;
			w26.Expand = false;
			w26.Fill = false;
			// Container child hboxSeriesBar.Gtk.Box+BoxChild
			this.buttonAddCounter = new global::Gtk.Button ();
			this.buttonAddCounter.CanFocus = true;
			this.buttonAddCounter.Name = "buttonAddCounter";
			this.buttonAddCounter.UseStock = true;
			this.buttonAddCounter.UseUnderline = true;
			this.buttonAddCounter.Relief = ((global::Gtk.ReliefStyle)(2));
			this.buttonAddCounter.Label = "gtk-add";
			this.hboxSeriesBar.Add (this.buttonAddCounter);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hboxSeriesBar [this.buttonAddCounter]));
			w27.PackType = ((global::Gtk.PackType)(1));
			w27.Position = 1;
			w27.Expand = false;
			w27.Fill = false;
			this.vbox5.Add (this.hboxSeriesBar);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hboxSeriesBar]));
			w28.Position = 0;
			w28.Expand = false;
			w28.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.listSeries = new global::Gtk.TreeView ();
			this.listSeries.WidthRequest = 100;
			this.listSeries.CanFocus = true;
			this.listSeries.Name = "listSeries";
			this.listSeries.HeadersVisible = false;
			this.GtkScrolledWindow1.Add (this.listSeries);
			this.vbox5.Add (this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.GtkScrolledWindow1]));
			w30.Position = 1;
			this.hpaned2.Add (this.vbox5);
			global::Gtk.Paned.PanedChild w31 = ((global::Gtk.Paned.PanedChild)(this.hpaned2 [this.vbox5]));
			w31.Resize = false;
			w31.Shrink = false;
			this.vbox3.Add (this.hpaned2);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hpaned2]));
			w32.Position = 0;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.toggleTimeView.Toggled += new global::System.EventHandler (this.OnToggleTimeViewToggled);
			this.toggleListView.Toggled += new global::System.EventHandler (this.OnToggleListViewToggled);
			this.buttonZoomIn.Clicked += new global::System.EventHandler (this.OnButtonZoomInClicked);
			this.buttonZoomOut.Clicked += new global::System.EventHandler (this.OnButtonZoomOutClicked);
			this.chartScroller.ValueChanged += new global::System.EventHandler (this.OnChartScrollerValueChanged);
			this.buttonAddCounter.Clicked += new global::System.EventHandler (this.OnButtonAddCounterClicked);
			this.buttonRemoveCounter.Clicked += new global::System.EventHandler (this.OnButtonRemoveCounterClicked);
		}
	}
}
