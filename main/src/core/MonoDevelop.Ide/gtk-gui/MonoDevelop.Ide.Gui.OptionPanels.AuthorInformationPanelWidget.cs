
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.Ide.Gui.OptionPanels
{
	internal partial class AuthorInformationPanelWidget
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.CheckButton checkCustom;
		private global::Gtk.Alignment alignment1;
		private global::Gtk.Table infoTable;
		private global::Gtk.Entry companyEntry;
		private global::Gtk.Entry copyrightEntry;
		private global::Gtk.Entry emailEntry;
		private global::Gtk.Label label2;
		private global::Gtk.Label label3;
		private global::Gtk.Label label4;
		private global::Gtk.Label label5;
		private global::Gtk.Label label6;
		private global::Gtk.Entry nameEntry;
		private global::Gtk.Entry trademarkEntry;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.Ide.Gui.OptionPanels.AuthorInformationPanelWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.Ide.Gui.OptionPanels.AuthorInformationPanelWidget";
			// Container child MonoDevelop.Ide.Gui.OptionPanels.AuthorInformationPanelWidget.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.checkCustom = new global::Gtk.CheckButton ();
			this.checkCustom.CanFocus = true;
			this.checkCustom.Name = "checkCustom";
			this.checkCustom.Label = global::Mono.Unix.Catalog.GetString ("_Use custom author information for this solution");
			this.checkCustom.DrawIndicator = true;
			this.checkCustom.UseUnderline = true;
			this.vbox1.Add (this.checkCustom);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.checkCustom]));
			w1.Position = 1;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(24));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.infoTable = new global::Gtk.Table (((uint)(5)), ((uint)(2)), false);
			this.infoTable.Name = "infoTable";
			this.infoTable.RowSpacing = ((uint)(6));
			this.infoTable.ColumnSpacing = ((uint)(6));
			// Container child infoTable.Gtk.Table+TableChild
			this.companyEntry = new global::Gtk.Entry ();
			this.companyEntry.CanFocus = true;
			this.companyEntry.Name = "companyEntry";
			this.companyEntry.IsEditable = true;
			this.companyEntry.InvisibleChar = '●';
			this.infoTable.Add (this.companyEntry);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.infoTable [this.companyEntry]));
			w2.TopAttach = ((uint)(3));
			w2.BottomAttach = ((uint)(4));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.copyrightEntry = new global::Gtk.Entry ();
			this.copyrightEntry.CanFocus = true;
			this.copyrightEntry.Name = "copyrightEntry";
			this.copyrightEntry.IsEditable = true;
			this.copyrightEntry.InvisibleChar = '●';
			this.infoTable.Add (this.copyrightEntry);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.infoTable [this.copyrightEntry]));
			w3.TopAttach = ((uint)(2));
			w3.BottomAttach = ((uint)(3));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.emailEntry = new global::Gtk.Entry ();
			this.emailEntry.CanFocus = true;
			this.emailEntry.Name = "emailEntry";
			this.emailEntry.IsEditable = true;
			this.emailEntry.InvisibleChar = '●';
			this.infoTable.Add (this.emailEntry);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.infoTable [this.emailEntry]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("_Name:");
			this.label2.UseUnderline = true;
			this.infoTable.Add (this.label2);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.infoTable [this.label2]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("_Copyright:");
			this.label3.UseUnderline = true;
			this.infoTable.Add (this.label3);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.infoTable [this.label3]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("_Email:");
			this.label4.UseUnderline = true;
			this.infoTable.Add (this.label4);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.infoTable [this.label4]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 0F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("C_ompany:");
			this.label5.UseUnderline = true;
			this.infoTable.Add (this.label5);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.infoTable [this.label5]));
			w8.TopAttach = ((uint)(3));
			w8.BottomAttach = ((uint)(4));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 0F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("_Trademark:");
			this.label6.UseUnderline = true;
			this.infoTable.Add (this.label6);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.infoTable [this.label6]));
			w9.TopAttach = ((uint)(4));
			w9.BottomAttach = ((uint)(5));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.nameEntry = new global::Gtk.Entry ();
			this.nameEntry.CanFocus = true;
			this.nameEntry.Name = "nameEntry";
			this.nameEntry.IsEditable = true;
			this.nameEntry.InvisibleChar = '●';
			this.infoTable.Add (this.nameEntry);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.infoTable [this.nameEntry]));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child infoTable.Gtk.Table+TableChild
			this.trademarkEntry = new global::Gtk.Entry ();
			this.trademarkEntry.CanFocus = true;
			this.trademarkEntry.Name = "trademarkEntry";
			this.trademarkEntry.IsEditable = true;
			this.trademarkEntry.InvisibleChar = '●';
			this.infoTable.Add (this.trademarkEntry);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.infoTable [this.trademarkEntry]));
			w11.TopAttach = ((uint)(4));
			w11.BottomAttach = ((uint)(5));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			this.alignment1.Add (this.infoTable);
			this.vbox1.Add (this.alignment1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.alignment1]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.label2.MnemonicWidget = this.nameEntry;
			this.Hide ();
			this.checkCustom.Toggled += new global::System.EventHandler (this.UseDefaultToggled);
		}
	}
}
