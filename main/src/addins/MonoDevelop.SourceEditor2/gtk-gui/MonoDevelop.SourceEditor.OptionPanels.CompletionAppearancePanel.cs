
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.SourceEditor.OptionPanels
{
	internal partial class CompletionAppearancePanel
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label2;
		private global::Gtk.SpinButton spinbutton1;
		private global::Gtk.Label label3;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.VBox vbox5;
		private global::Gtk.CheckButton filterByBrowsableCheckbutton;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Fixed fixed1;
		private global::Gtk.RadioButton normalOnlyRadiobutton;
		private global::Gtk.Alignment alignment1;
		private global::Gtk.Label label4;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Fixed fixed2;
		private global::Gtk.RadioButton includeAdvancedRadiobutton;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.Label label5;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.SourceEditor.OptionPanels.CompletionAppearancePanel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.SourceEditor.OptionPanels.CompletionAppearancePanel";
			// Container child MonoDevelop.SourceEditor.OptionPanels.CompletionAppearancePanel.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Completion list has");
			this.hbox1.Add (this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.spinbutton1 = new global::Gtk.SpinButton (0, 100, 1);
			this.spinbutton1.CanFocus = true;
			this.spinbutton1.Name = "spinbutton1";
			this.spinbutton1.Adjustment.PageIncrement = 10;
			this.spinbutton1.ClimbRate = 1;
			this.spinbutton1.Numeric = true;
			this.hbox1.Add (this.spinbutton1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.spinbutton1]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("rows");
			this.hbox1.Add (this.label3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label3]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment3.Name = "alignment3";
			this.alignment3.LeftPadding = ((uint)(12));
			// Container child alignment3.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.filterByBrowsableCheckbutton = new global::Gtk.CheckButton ();
			this.filterByBrowsableCheckbutton.CanFocus = true;
			this.filterByBrowsableCheckbutton.Name = "filterByBrowsableCheckbutton";
			this.filterByBrowsableCheckbutton.Label = global::Mono.Unix.Catalog.GetString ("_Filter members by [EditorBrowsable] attribute");
			this.filterByBrowsableCheckbutton.Active = true;
			this.filterByBrowsableCheckbutton.DrawIndicator = true;
			this.filterByBrowsableCheckbutton.UseUnderline = true;
			this.vbox5.Add (this.filterByBrowsableCheckbutton);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.filterByBrowsableCheckbutton]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			this.hbox2.Add (this.fixed1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.fixed1]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Padding = ((uint)(6));
			// Container child hbox2.Gtk.Box+BoxChild
			this.normalOnlyRadiobutton = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("_Show Normal members only"));
			this.normalOnlyRadiobutton.CanFocus = true;
			this.normalOnlyRadiobutton.Name = "normalOnlyRadiobutton";
			this.normalOnlyRadiobutton.DrawIndicator = true;
			this.normalOnlyRadiobutton.UseUnderline = true;
			this.normalOnlyRadiobutton.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.hbox2.Add (this.normalOnlyRadiobutton);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.normalOnlyRadiobutton]));
			w7.Position = 1;
			this.vbox5.Add (this.hbox2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox2]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(38));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("<i>EditorBrowsableState.Always</i>");
			this.label4.UseMarkup = true;
			this.alignment1.Add (this.label4);
			this.vbox5.Add (this.alignment1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.alignment1]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.fixed2 = new global::Gtk.Fixed ();
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			this.hbox3.Add (this.fixed2);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.fixed2]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Padding = ((uint)(6));
			// Container child hbox3.Gtk.Box+BoxChild
			this.includeAdvancedRadiobutton = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Show Normal and _Advanced members"));
			this.includeAdvancedRadiobutton.CanFocus = true;
			this.includeAdvancedRadiobutton.Name = "includeAdvancedRadiobutton";
			this.includeAdvancedRadiobutton.DrawIndicator = true;
			this.includeAdvancedRadiobutton.UseUnderline = true;
			this.includeAdvancedRadiobutton.Group = this.normalOnlyRadiobutton.Group;
			this.hbox3.Add (this.includeAdvancedRadiobutton);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.includeAdvancedRadiobutton]));
			w12.Position = 1;
			this.vbox5.Add (this.hbox3);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox3]));
			w13.Position = 3;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.LeftPadding = ((uint)(38));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 0F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("<i>EditorBrowsableState.Always and EditorBrowsableState.Advanced</i>");
			this.label5.UseMarkup = true;
			this.alignment2.Add (this.label5);
			this.vbox5.Add (this.alignment2);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.alignment2]));
			w15.Position = 4;
			w15.Expand = false;
			w15.Fill = false;
			this.alignment3.Add (this.vbox5);
			this.vbox1.Add (this.alignment3);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.alignment3]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
