//
// ProjectDomService.cs
//
// Author:
//   Mike Krüger <mkrueger@novell.com>
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
using System.Collections.Generic;
using System.Diagnostics;
using MonoDevelop.Projects;

namespace MonoDevelop.Dom.Parser
{
	public static class ProjectDomService
	{
		static Dictionary<string, ProjectDom> doms = new Dictionary<string, ProjectDom> ();
		static List<IParser> parsers = new List<IParser>();
		
		public static List<IParser> Parsers {
			get {
				return parsers;
			}
		}

		public static void Init ()
		{
			MonoDevelop.Ide.Gui.IdeApp.ProjectOperations.CombineOpened += delegate {
				LoadWholeSolution ();
			};
		}
		
		static IParser GetParser (string projectType)
		{
			foreach (IParser parser in parsers) {
				if (parser.CanParseProjectType (projectType))
					return parser;
			}
			return null;
		}
		
		static ProjectDom GetDom (Project project)
		{
			Debug.Assert (project != null);
			return GetDom (project.FileName);
		}
		
		static ProjectDom GetDom (string fileName)
		{
			Debug.Assert (!String.IsNullOrEmpty (fileName));
			if (!doms.ContainsKey (fileName))
				doms [fileName] = new ProjectDom ();
			return doms [fileName];
		}
		
		static void LoadWholeSolution ()
		{
			foreach (CombineEntry entry in MonoDevelop.Ide.Gui.IdeApp.ProjectOperations.CurrentOpenCombine.GetAllProjects ()) {
				Project project = (Project)entry;
				IParser parser = GetParser (project.ProjectType);
				if (parser == null)
					continue;
					
				ProjectDom dom = GetDom (project);
				foreach (ProjectFile file in project.ProjectFiles) {
					dom.UpdateCompilationUnit (parser.Parse (file.FilePath));
				}
			}
		}
	}
}
