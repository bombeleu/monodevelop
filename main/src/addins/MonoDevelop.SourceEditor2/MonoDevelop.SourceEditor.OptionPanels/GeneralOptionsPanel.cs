// GeneralOptionsPanel.cs
//
// Author:
//   Mike Krüger <mkrueger@novell.com>
//
// Copyright (c) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using MonoDevelop.Ide.Gui.Dialogs; 

namespace MonoDevelop.SourceEditor.OptionPanels
{
	partial class GeneralOptionsPanel : Gtk.Bin, IOptionsPanel
	{
		public GeneralOptionsPanel()
		{
			this.Build();
			this.codeCompletioncheckbutton.Toggled += HandleCodeCompletioncheckbuttonToggled;
		}

		void HandleCodeCompletioncheckbuttonToggled (object sender, EventArgs e)
		{
			this.enableParameterInsightCheckbutton.Sensitive = 
				this.autoCodeCompletionCheckbutton.Sensitive = 
					this.spaceOrPunctiuationCheckbutton.Sensitive = 
						this.hideObsoleteItemsCheckbutton.Sensitive = 
							this.codeCompletioncheckbutton.Active;
		}
		
	
		public virtual Gtk.Widget CreatePanelWidget ()
		{
			this.codeCompletioncheckbutton.Active = DefaultSourceEditorOptions.Instance.EnableCodeCompletion;
			this.foldingCheckbutton.Active = DefaultSourceEditorOptions.Instance.ShowFoldMargin;
			this.foldregionsCheckbutton.Active = DefaultSourceEditorOptions.Instance.DefaultRegionsFolding;
			this.foldCommentsCheckbutton.Active = DefaultSourceEditorOptions.Instance.DefaultCommentFolding;
			this.enableParameterInsightCheckbutton.Active = DefaultSourceEditorOptions.Instance.EnableAutoCodeCompletion;
			this.spaceOrPunctiuationCheckbutton.Active = DefaultSourceEditorOptions.Instance.CompleteWithSpaceOrPunctuation;
			this.enableParameterInsightCheckbutton.Active = DefaultSourceEditorOptions.Instance.EnableParameterInsight;
			this.hideObsoleteItemsCheckbutton.Active = DefaultSourceEditorOptions.Instance.HideObsoleteItems;
			this.autoCodeCompletionCheckbutton.Active = DefaultSourceEditorOptions.Instance.EnableAutoCodeCompletion;
			this.fontselection.SetFontName (DefaultSourceEditorOptions.Instance.FontName);
			radiobutton2.Active = !(radiobutton1.Active = this.fontselection.FontName == MonoDevelop.Ide.DesktopService.DefaultMonospaceFont);
			
			HandleCodeCompletioncheckbuttonToggled (this, EventArgs.Empty);
			return this;
		}
		
		public virtual void ApplyChanges ()
		{
			DefaultSourceEditorOptions.Instance.EnableCodeCompletion = this.codeCompletioncheckbutton.Active;
			DefaultSourceEditorOptions.Instance.ShowFoldMargin = this.foldingCheckbutton.Active;
			DefaultSourceEditorOptions.Instance.DefaultRegionsFolding = this.foldregionsCheckbutton.Active;
			DefaultSourceEditorOptions.Instance.DefaultCommentFolding = this.foldCommentsCheckbutton.Active;
			DefaultSourceEditorOptions.Instance.EnableAutoCodeCompletion = this.autoCodeCompletionCheckbutton.Active;
			DefaultSourceEditorOptions.Instance.CompleteWithSpaceOrPunctuation = this.spaceOrPunctiuationCheckbutton.Active;
			DefaultSourceEditorOptions.Instance.EnableParameterInsight = this.enableParameterInsightCheckbutton.Active;
			DefaultSourceEditorOptions.Instance.HideObsoleteItems = this.hideObsoleteItemsCheckbutton.Active;
			if (this.radiobutton1.Active)
				MonoDevelop.Ide.Fonts.FontService.SetFont("Editor", MonoDevelop.Ide.DesktopService.DefaultMonospaceFont);
			else MonoDevelop.Ide.Fonts.FontService.SetFont ("Editor", this.fontselection.FontName);
		}

		public void Initialize (OptionsDialog dialog, object dataObject)
		{
		}

		public bool IsVisible ()
		{
			return true;
		}

		public bool ValidateChanges ()
		{
			return true;
		}
	}
}
