//
// ViMode.cs
//
// Author:
//   Michael Hutchinson <mhutchinson@novell.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Text;
using System.Collections.Generic;

namespace Mono.TextEditor
{
	
	
	public class ViMode : EditMode
	{
		State state;
		string status;
		StringBuilder commandBuffer = new StringBuilder ();
		
		public ViMode ()
		{
		}
		
		Action<TextEditorData> GetNavCharAction (char c)
		{
			switch (c) {
			case 'h':
				return CaretMoveActions.Left;
			case 'b':
				return CaretMoveActions.PreviousWord;
			case 'l':
				return CaretMoveActions.Right;
			case 'w':
				return CaretMoveActions.NextWord;
			case 'k':
				return CaretMoveActions.Up;
			case 'j':
				return CaretMoveActions.Down;
			case '%':
				return MiscActions.GotoMatchingBracket;
			case '0':
				return CaretMoveActions.LineStart;
			case '^':
			case '_':
				return CaretMoveActions.LineFirstNonWhitespace;
			case '$':
				return CaretMoveActions.LineEnd;
			case 'G':
				return CaretMoveActions.ToDocumentEnd;
			}
			return null;
		}
		
		Action<TextEditorData> GetDirectionKeyAction (Gdk.Key key, Gdk.ModifierType modifier)
		{
			//
			// NO MODIFIERS
			//
			if ((modifier & (Gdk.ModifierType.ShiftMask | Gdk.ModifierType.ControlMask)) == 0) {
				switch (key) {
				case Gdk.Key.Left:
				case Gdk.Key.KP_Left:
					return CaretMoveActions.Left;
					
				case Gdk.Key.Right:
				case Gdk.Key.KP_Right:
					return CaretMoveActions.Right;
					
				case Gdk.Key.Up:
				case Gdk.Key.KP_Up:
					return CaretMoveActions.Up;
					
				case Gdk.Key.Down:
				case Gdk.Key.KP_Down:
					return CaretMoveActions.Down;
				
				//not strictly vi, but more useful IMO
				case Gdk.Key.KP_Home:
				case Gdk.Key.Home:
					return CaretMoveActions.LineHome;
					
				case Gdk.Key.KP_End:
				case Gdk.Key.End:
					return CaretMoveActions.LineEnd;
				}
			}
			//
			// === CONTROL ===
			//
			else if ((modifier & Gdk.ModifierType.ShiftMask) == 0
			         && (modifier & Gdk.ModifierType.ControlMask) != 0)
			{
				switch (key) {
				case Gdk.Key.Left:
				case Gdk.Key.KP_Left:
					return CaretMoveActions.PreviousWord;
					
				case Gdk.Key.Right:
				case Gdk.Key.KP_Right:
					return CaretMoveActions.NextWord;
					
				case Gdk.Key.Up:
				case Gdk.Key.KP_Up:
					return ScrollActions.Up;
					
				// usually bound at IDE level
				case Gdk.Key.u:
					return CaretMoveActions.PageUp;
					
				case Gdk.Key.Down:
				case Gdk.Key.KP_Down:
					return ScrollActions.Down;
					
				case Gdk.Key.d:
					return CaretMoveActions.PageDown;
				
				case Gdk.Key.KP_Home:
				case Gdk.Key.Home:
					return CaretMoveActions.ToDocumentStart;
					
				case Gdk.Key.KP_End:
				case Gdk.Key.End:
					return CaretMoveActions.ToDocumentEnd;
				}
			}
			return null;
		}
		
		Action<TextEditorData> GetInsertKeyAction (Gdk.Key key, Gdk.ModifierType modifier)
		{
			//
			// NO MODIFIERS
			//
			if ((modifier & (Gdk.ModifierType.ShiftMask | Gdk.ModifierType.ControlMask)) == 0) {
				switch (key) {
				case Gdk.Key.Tab:
					return MiscActions.InsertTab;
					
				case Gdk.Key.Return:
				case Gdk.Key.KP_Enter:
					return MiscActions.InsertNewLine;
					
				case Gdk.Key.BackSpace:
					return DeleteActions.Backspace;
					
				case Gdk.Key.Delete:
				case Gdk.Key.KP_Delete:
					return DeleteActions.Delete;
				}
			}
			//
			// CONTROL
			//
			else if ((modifier & Gdk.ModifierType.ControlMask) != 0
			         && (modifier & Gdk.ModifierType.ShiftMask) == 0)
			{
				switch (key) {
				case Gdk.Key.BackSpace:
					return DeleteActions.PreviousWord;
					
				case Gdk.Key.Delete:
				case Gdk.Key.KP_Delete:
					return DeleteActions.NextWord;
				}
			}
			//
			// SHIFT
			//
			else if ((modifier & Gdk.ModifierType.ControlMask) == 0
			         && (modifier & Gdk.ModifierType.ShiftMask) != 0)
			{
				switch (key) {
				case Gdk.Key.ISO_Left_Tab:
					return MiscActions.RemoveTab;
					
				case Gdk.Key.BackSpace:
					return DeleteActions.Backspace;
				}
			}
			return null;
		}
		
		Action<TextEditorData> GetCommandCharAction (char c)
		{
			switch (c) {
			case 'u':
				return MiscActions.Undo;
			}
			return null;
		}
		
		public string Status {
			get { return status; }
			private set {
				status = value;
				OnStatusChanged ();
			}
		}
		
		protected virtual void OnStatusChanged ()
		{
			if (StatusChanged != null)
				StatusChanged (this, EventArgs.Empty);
		}
		
		protected virtual string RunCommand (string command)
		{
			return "Command not recognised";
		}
		
		public event EventHandler StatusChanged;
		
		public override bool WantsToPreemptIM {
			get {
				return state != State.Insert && state != State.Replace;
			}
		}
		
		void ResetEditorState (TextEditorData data)
		{
			data.ClearSelection ();
			if (!data.Caret.IsInInsertMode)
				data.Caret.IsInInsertMode = true;
		}
		
		protected override void HandleKeypress (Gdk.Key key, uint unicodeKey, Gdk.ModifierType modifier)
		{
			if (key == Gdk.Key.Escape || (key == Gdk.Key.c && (modifier & Gdk.ModifierType.ControlMask) != null)) {
				ResetEditorState (Data);
				state = State.Normal;
				commandBuffer.Length = 0;
				Status = string.Empty;
				return;
			}
			
			int keyCode;
			Action<TextEditorData> action;
			
			switch (state) {
			case State.Normal:
				if (((modifier & (Gdk.ModifierType.ShiftMask | Gdk.ModifierType.ControlMask)) == 0)) {
					switch ((char)unicodeKey) {
					case ':':
						state = State.Command;
						commandBuffer.Append (":");
						Status = commandBuffer.ToString ();
						return;
					
					case 'i':
					case 'a':
						Status = "-- INSERT --";
						state = State.Insert;
						return;
						
					case 'R':
						Caret.IsInInsertMode = false;
						Status = "-- REPLACE --";
						state = State.Replace;
						return;
						
					case 'v':
						Status = "-- VISUAL --";
						state = State.Visual;
						return;
						
					case 'd':
						Status = "d";
						state = State.Delete;
						return;
					}
				}
				
				action = GetNavCharAction ((char)unicodeKey);
				if (action == null)
					action = GetDirectionKeyAction (key, modifier);
				if (action == null)
					action = GetCommandCharAction ((char)unicodeKey);
				
				if (action != null)
					RunAction (action);
				
				return;
				
			case State.Delete:
				if (((modifier & (Gdk.ModifierType.ShiftMask | Gdk.ModifierType.ControlMask)) == 0 
				     && key == Gdk.Key.d))
				{
					action = DeleteActions.CaretLine;
				} else {
					action = GetNavCharAction ((char)unicodeKey);
					if (action == null)
						action = GetDirectionKeyAction (key, modifier);
					if (action != null)
						action = DeleteActions.FromMoveAction (action);
				}
				
				if (action != null) {
					RunAction (action);
				}
				
				state = State.Normal;
				return;
				
			case State.Insert:
			case State.Replace:
				action = GetInsertKeyAction (key, modifier);
				if (action == null)
					action = GetDirectionKeyAction (key, modifier);
				
				if (action != null)
					RunAction (action);
				else if (unicodeKey != 0)
					InsertCharacter (unicodeKey);
				
				return;
				
			case State.Visual:
				action = GetNavCharAction ((char)unicodeKey);
				if (action == null)
					action = GetDirectionKeyAction (key, modifier);
				
				if (action != null)
					RunAction (SelectionActions.FromMoveAction (action));
				
				return;
				
			case State.Command:
				if (key == Gdk.Key.Return || key == Gdk.Key.KP_Enter) {
					Status = RunCommand (commandBuffer.ToString ());
					commandBuffer.Length = 0;
					state = State.Normal;
				} else if (unicodeKey != 0) {
					commandBuffer.Append ((char)unicodeKey);
					Status = commandBuffer.ToString ();
				}
				return;
			}
		}
		
		enum State {
			Normal = 0,
			Command,
			Delete,
			Visual,
			VisualLine,
			Insert,
			Replace
		}
	}
}
