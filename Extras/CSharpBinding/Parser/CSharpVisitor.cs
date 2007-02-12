// created on 04.08.2003 at 17:49
using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.CodeDom;

using RefParser = ICSharpCode.NRefactory.Parser;
using AST = ICSharpCode.NRefactory.Parser.AST;
using MonoDevelop.Projects.Parser;
using CSharpBinding.Parser.SharpDevelopTree;
using ModifierFlags = ICSharpCode.NRefactory.Parser.AST.Modifier;
using ClassType = MonoDevelop.Projects.Parser.ClassType;
using CSGenericParameter = CSharpBinding.Parser.SharpDevelopTree.GenericParameter;

namespace CSharpBinding.Parser
{
	public class Using : AbstractUsing
	{
	}
	
	public class CSharpVisitor : RefParser.AbstractAstVisitor
	{
		DefaultCompilationUnit cu = new DefaultCompilationUnit();
		Stack currentNamespace = new Stack();
		Stack currentClass = new Stack();
		static ICSharpCode.NRefactory.Parser.CodeDOMVisitor domVisitor = new ICSharpCode.NRefactory.Parser.CodeDOMVisitor ();
		
		public DefaultCompilationUnit Cu {
			get {
				return cu;
			}
		}
		
		public override object Visit(AST.CompilationUnit compilationUnit, object data)
		{
			//TODO: usings, Comments
			compilationUnit.AcceptChildren(this, data);
			return cu;
		}
		
		public override object Visit(AST.Using usingDeclaration, object data)
		{
			Using u = new Using();
			if (usingDeclaration.IsAlias)
				u.Aliases[usingDeclaration.Alias.Type] = usingDeclaration.Name;
			else
				u.Usings.Add(usingDeclaration.Name);
			cu.Usings.Add(u);
			return data;
		}
		
		public AttributeTarget GetAttributeTarget (string attb)
		{
			switch (attb)
			{
				// check the 'assembly', I didn't saw it being used in c# parser....
				case "assembly":
					return AttributeTarget.Assembly;
				case "event":
					return AttributeTarget.Event;
				case "return":
					return AttributeTarget.Return;
				case "field":
					return AttributeTarget.Field;
				case "method":
					return AttributeTarget.Method;
				case "module":
					return AttributeTarget.Module;
				case "param":
					return AttributeTarget.Param;
				case "property":
					return AttributeTarget.Property;
				case "type":
					return AttributeTarget.Type;
				default:
					return AttributeTarget.None;
			}
		} 
		
		void FillAttributes (IDecoration decoration, IEnumerable attributes)
		{
			// TODO Expressions???
			foreach (AST.AttributeSection section in attributes) {
				DefaultAttributeSection resultSection = new DefaultAttributeSection (GetAttributeTarget (section.AttributeTarget), GetRegion (section.StartLocation, section.EndLocation));
				foreach (AST.Attribute attribute in section.Attributes)
				{
					CodeExpression[] positionals = new CodeExpression [attribute.PositionalArguments.Count];
					for (int n=0; n<attribute.PositionalArguments.Count; n++) {
						positionals [n] = GetDomExpression (attribute.PositionalArguments[n]);
					}
					
					NamedAttributeArgument[] named = new NamedAttributeArgument [attribute.NamedArguments.Count];
					for (int n=0; n<attribute.NamedArguments.Count; n++) {
						ICSharpCode.NRefactory.Parser.AST.NamedArgumentExpression arg = (ICSharpCode.NRefactory.Parser.AST.NamedArgumentExpression) attribute.NamedArguments [n];
						named [n] = new NamedAttributeArgument (arg.Name, GetDomExpression (arg.Expression));
					}
					
					DefaultAttribute resultAttribute = new DefaultAttribute (attribute.Name, positionals, named, GetRegion (attribute.StartLocation, attribute.EndLocation));
					resultSection.Attributes.Add (resultAttribute);
				}
				decoration.Attributes.Add (resultSection);				
			}

		}
		
		CodeExpression GetDomExpression (object ob)
		{
			return (CodeExpression) ((ICSharpCode.NRefactory.Parser.AST.Expression)ob).AcceptVisitor (domVisitor, null);
		}
		
//		ModifierEnum VisitModifier(ICSharpCode.NRefactory.Parser.Modifier m)
//		{
//			return (ModifierEnum)m;
//		}
		
		public override object Visit(AST.NamespaceDeclaration namespaceDeclaration, object data)
		{
			string name;
			if (currentNamespace.Count == 0) {
				name = namespaceDeclaration.Name;
			} else {
				name = String.Concat((string)currentNamespace.Peek(), '.', namespaceDeclaration.Name);
			}
			currentNamespace.Push(name);
			object ret = namespaceDeclaration.AcceptChildren(this, data);
			currentNamespace.Pop();
			return ret;
		}
		
		ClassType TranslateClassType(RefParser.AST.ClassType type)
		{
			switch (type) {
				case RefParser.AST.ClassType.Class:
					return ClassType.Class;
				case RefParser.AST.ClassType.Enum:
					return ClassType.Enum;
				case RefParser.AST.ClassType.Interface:
					return ClassType.Interface;
				case RefParser.AST.ClassType.Struct:
					return ClassType.Struct;
			}
			return ClassType.Class;
		}
		
		public override object Visit(AST.TypeDeclaration typeDeclaration, object data)
		{
			DefaultRegion bodyRegion = GetRegion(typeDeclaration.StartLocation, typeDeclaration.EndLocation);
			DefaultRegion declarationRegion = bodyRegion; //GetRegion (typeDeclaration.DeclarationStartLocation, typeDeclaration.DeclarationEndLocation);
			ModifierFlags mf = typeDeclaration.Modifier;
			Class c = new Class(cu, TranslateClassType(typeDeclaration.Type), mf, declarationRegion, bodyRegion);
			
			FillAttributes (c, typeDeclaration.Attributes);
			
			c.Name = typeDeclaration.Name;
			if (currentClass.Count > 0) {
				Class cur = ((Class)currentClass.Peek());
				cur.InnerClasses.Add(c);
				c.DeclaredIn = cur;
			} else {
				if (currentNamespace.Count > 0)
					c.Namespace = (string) currentNamespace.Peek();
				cu.Classes.Add(c);
			}
			
			// Get base classes (with generic arguments et al)
			if (typeDeclaration.BaseTypes != null) {
				foreach (ICSharpCode.NRefactory.Parser.AST.TypeReference type in typeDeclaration.BaseTypes) {
					c.BaseTypes.Add(new ReturnType(type));
				}
			}
			if (c.ClassType == ClassType.Enum) {
				c.BaseTypes.Add (new ReturnType ("System.Enum"));
			}
			
			// Get generic parameters for this type
			if (typeDeclaration.Templates != null && typeDeclaration.Templates.Count > 0) {
				c.GenericParameters = new GenericParameterList();
				c.Name = String.Concat (c.Name, "`", typeDeclaration.Templates.Count.ToString());
				foreach (AST.TemplateDefinition td in typeDeclaration.Templates) {
					c.GenericParameters.Add (new CSGenericParameter(td));
				}
			}
			
			currentClass.Push(c);
			object ret = typeDeclaration.AcceptChildren(this, data);
			currentClass.Pop();
			c.UpdateModifier();
			return ret;
		}
		
		public override object Visit(AST.DelegateDeclaration typeDeclaration, object data)
		{
			DefaultRegion declarationRegion = GetRegion (typeDeclaration.StartLocation, typeDeclaration.EndLocation);
			ModifierFlags mf = typeDeclaration.Modifier;
			Class c = new Class (cu, ClassType.Delegate, mf, declarationRegion, null);
			
			FillAttributes (c, typeDeclaration.Attributes);
			
			c.Name = typeDeclaration.Name;
			if (currentClass.Count > 0) {
				Class cur = ((Class)currentClass.Peek());
				cur.InnerClasses.Add(c);
				c.DeclaredIn = cur;
			} else {
				if (currentNamespace.Count > 0)
					c.Namespace = (string) currentNamespace.Peek();
				cu.Classes.Add(c);
			}
			
			if (typeDeclaration.ReturnType == null)
				return c;
				
			ReturnType type = new ReturnType (typeDeclaration.ReturnType);
			
			mf = ModifierFlags.None;
			Method method = new Method ("Invoke", type, mf, null, null);
			ParameterCollection parameters = new ParameterCollection();
			if (typeDeclaration.Parameters != null) {
				foreach (AST.ParameterDeclarationExpression par in typeDeclaration.Parameters) {
					parameters.Add (CreateParameter (par, method));
				}
			}
			method.Parameters = parameters;
			c.Methods.Add(method);			
			
			c.UpdateModifier();
			return c;
		}
		
		DefaultRegion GetRegion(Point start, Point end)
		{
			return new DefaultRegion(start.Y, start.X, end.Y, end.X);
		}
		
		public override object Visit(AST.MethodDeclaration methodDeclaration, object data)
		{
			VisitMethod (methodDeclaration, data);
			return null;
		}
		
		Method VisitMethod (AST.MethodDeclaration methodDeclaration, object data)
		{
			DefaultRegion region     = GetRegion(methodDeclaration.StartLocation, methodDeclaration.EndLocation);
			DefaultRegion bodyRegion = GetRegion(methodDeclaration.EndLocation, methodDeclaration.Body != null ? methodDeclaration.Body.EndLocation : new Point(-1, -1));

			ReturnType type = new ReturnType(methodDeclaration.TypeReference);
			Class c       = (Class)currentClass.Peek();
			
			ModifierFlags mf = methodDeclaration.Modifier;
			Method method = new Method (String.Concat(methodDeclaration.Name), type, mf, region, bodyRegion);
			ParameterCollection parameters = method.Parameters;
			if (methodDeclaration.Parameters != null) {
				foreach (AST.ParameterDeclarationExpression par in methodDeclaration.Parameters) {
					parameters.Add (CreateParameter (par, method));
				}
			}
			
			// Get generic parameters for this type
			if (methodDeclaration.Templates != null && methodDeclaration.Templates.Count > 0) {
				method.GenericParameters = new GenericParameterList();
				foreach (AST.TemplateDefinition td in methodDeclaration.Templates) {
					method.GenericParameters.Add (new CSGenericParameter(td));
				}
			}
			
			FillAttributes (method, methodDeclaration.Attributes);
			
			c.Methods.Add(method);
			return method;
		}
		
		IParameter CreateParameter (AST.ParameterDeclarationExpression par, IMember declaringMember)
		{
			ReturnType parType = new ReturnType (par.TypeReference);
			DefaultParameter p = new DefaultParameter (declaringMember, par.ParameterName, parType);
			if ((par.ParamModifier & AST.ParamModifier.Out) != 0)
				p.Modifier |= ParameterModifier.Out;
			if ((par.ParamModifier & AST.ParamModifier.Ref) != 0)
				p.Modifier |= ParameterModifier.Ref;
			if ((par.ParamModifier & AST.ParamModifier.Params) != 0)
				p.Modifier |= ParameterModifier.Params;
			return p;
		}
		
		public override object Visit(AST.OperatorDeclaration operatorDeclaration, object data)
		{
			string name = null;
			bool binary = operatorDeclaration.Parameters.Count == 2;
			
			switch (operatorDeclaration.OverloadableOperator) {
				case AST.OverloadableOperatorType.Add:
					if (binary)
						name = "op_Addition";
					else
						name = "op_UnaryPlus";
					break;
				case AST.OverloadableOperatorType.Subtract:
					if (binary)
						name = "op_Subtraction";
					else
						name = "op_UnaryNegation";
					break;
				case AST.OverloadableOperatorType.Multiply:
					if (binary)
						name = "op_Multiply";
					break;
				case AST.OverloadableOperatorType.Divide:
					if (binary)
						name = "op_Division";
					break;
				case AST.OverloadableOperatorType.Modulus:
					if (binary)
						name = "op_Modulus";
					break;
				
				case AST.OverloadableOperatorType.Not:
					name = "op_LogicalNot";
					break;
				case AST.OverloadableOperatorType.BitNot:
					name = "op_OnesComplement";
					break;
				
				case AST.OverloadableOperatorType.BitwiseAnd:
					if (binary)
						name = "op_BitwiseAnd";
					break;
				case AST.OverloadableOperatorType.BitwiseOr:
					if (binary)
						name = "op_BitwiseOr";
					break;
				case AST.OverloadableOperatorType.ExclusiveOr:
					if (binary)
						name = "op_ExclusiveOr";
					break;
				
				case AST.OverloadableOperatorType.ShiftLeft:
					if (binary)
						name = "op_LeftShift";
					break;
				case AST.OverloadableOperatorType.ShiftRight:
					if (binary)
						name = "op_RightShift";
					break;
				
				case AST.OverloadableOperatorType.GreaterThan:
					if (binary)
						name = "op_GreaterThan";
					break;
				case AST.OverloadableOperatorType.GreaterThanOrEqual:
					if (binary)
						name = "op_GreaterThanOrEqual";
					break;
				case AST.OverloadableOperatorType.Equality:
					if (binary)
						name = "op_Equality";
					break;
				case AST.OverloadableOperatorType.InEquality:
					if (binary)
						name = "op_Inequality";
					break;
				case AST.OverloadableOperatorType.LessThan:
					if (binary)
						name = "op_LessThan";
					break;
				case AST.OverloadableOperatorType.LessThanOrEqual:
					if (binary)
						name = "op_LessThanOrEqual";
					break;
				
				case AST.OverloadableOperatorType.Increment:
					name = "op_Increment";
					break;
				case AST.OverloadableOperatorType.Decrement:
					name = "op_Decrement";
					break;
				
				case AST.OverloadableOperatorType.True:
					name = "op_True";
					break;
				case AST.OverloadableOperatorType.False:
					name = "op_False";
					break;
			}
			if (name != null) {
				Method method = VisitMethod (operatorDeclaration, data);
				method.Name = name;
				method.Modifiers = method.Modifiers | ModifierEnum.SpecialName;
				return null;
			} else
				return base.Visit (operatorDeclaration, data);
		}
		
		public override object Visit(AST.ConstructorDeclaration constructorDeclaration, object data)
		{
			DefaultRegion region     = GetRegion(constructorDeclaration.StartLocation, constructorDeclaration.EndLocation);
			DefaultRegion bodyRegion = GetRegion(constructorDeclaration.EndLocation, constructorDeclaration.Body != null ? constructorDeclaration.Body.EndLocation : new Point(-1, -1));
			Class c       = (Class)currentClass.Peek();
			
			ModifierFlags mf = constructorDeclaration.Modifier;
			Constructor constructor = new Constructor (mf, region, bodyRegion);
			ParameterCollection parameters = new ParameterCollection();
			if (constructorDeclaration.Parameters != null) {
				foreach (AST.ParameterDeclarationExpression par in constructorDeclaration.Parameters) {
					parameters.Add (CreateParameter (par, constructor));
				}
			}
			constructor.Parameters = parameters;
			
			FillAttributes (constructor, constructorDeclaration.Attributes);
			
			c.Methods.Add(constructor);
			return null;
		}
		
		public override object Visit(AST.DestructorDeclaration destructorDeclaration, object data)
		{
			DefaultRegion region     = GetRegion(destructorDeclaration.StartLocation, destructorDeclaration.EndLocation);
			DefaultRegion bodyRegion = GetRegion(destructorDeclaration.EndLocation, destructorDeclaration.Body != null ? destructorDeclaration.Body.EndLocation : new Point(-1, -1));
			
			Class c       = (Class)currentClass.Peek();
			
			ModifierFlags mf = destructorDeclaration.Modifier;
			Destructor destructor = new Destructor (c.Name, mf, region, bodyRegion);
			
			FillAttributes (destructor, destructorDeclaration.Attributes);
			
			c.Methods.Add(destructor);
			return null;
		}
		
		// No attributes?
		public override object Visit(AST.FieldDeclaration fieldDeclaration, object data)
		{
			DefaultRegion region     = GetRegion(fieldDeclaration.StartLocation, fieldDeclaration.EndLocation);
			Class c = (Class)currentClass.Peek();
			ReturnType type = null;
			if (fieldDeclaration.TypeReference == null) {
				Debug.Assert(c.ClassType == ClassType.Enum);
			} else {
				type = new ReturnType(fieldDeclaration.TypeReference);
			}
			if (currentClass.Count > 0) {
				foreach (AST.VariableDeclaration field in fieldDeclaration.Fields) {
					DefaultField f;
					f = new DefaultField (type, field.Name, (ModifierEnum) fieldDeclaration.Modifier, region);	
					if (c.ClassType == ClassType.Enum)
						f.AddModifier (ModifierEnum.Const);
					c.Fields.Add(f);
					FillAttributes (f, fieldDeclaration.Attributes);
				}
			}
			
			return null;
		}
		
		public override object Visit(AST.PropertyDeclaration propertyDeclaration, object data)
		{
			DefaultRegion region     = GetRegion(propertyDeclaration.StartLocation, propertyDeclaration.EndLocation);
			DefaultRegion bodyRegion = GetRegion(propertyDeclaration.BodyStart,     propertyDeclaration.BodyEnd);
			
			ReturnType type = new ReturnType(propertyDeclaration.TypeReference);
			Class c = (Class)currentClass.Peek();
			
			ModifierFlags mf = propertyDeclaration.Modifier;
			DefaultProperty property = new DefaultProperty (propertyDeclaration.Name, type, (ModifierEnum)mf, region, bodyRegion);
			
			FillAttributes (property, propertyDeclaration.Attributes);
			
			if (propertyDeclaration.HasGetRegion)
				property.GetterRegion = GetRegion (propertyDeclaration.GetRegion.StartLocation, propertyDeclaration.GetRegion.EndLocation);
			if (propertyDeclaration.HasSetRegion) 
				property.SetterRegion = GetRegion (propertyDeclaration.SetRegion.StartLocation, propertyDeclaration.SetRegion.EndLocation);
						
			c.Properties.Add(property);
			return null;
		}
		
		public override object Visit(AST.EventDeclaration eventDeclaration, object data)
		{
			DefaultRegion region     = GetRegion(eventDeclaration.StartLocation, eventDeclaration.EndLocation);
			DefaultRegion bodyRegion = GetRegion(eventDeclaration.BodyStart,     eventDeclaration.BodyEnd);
			ReturnType type = new ReturnType(eventDeclaration.TypeReference);
			Class c = (Class)currentClass.Peek();
			DefaultEvent e = null;
			
/*			if (eventDeclaration.VariableDeclarators != null) {
				foreach (ICSharpCode.NRefactory.Parser.AST.VariableDeclaration varDecl in eventDeclaration.VariableDeclarators) {
					ModifierFlags mf = eventDeclaration.Modifier;
					e = new DefaultEvent (c, varDecl.Name, type, mf, region, bodyRegion);
					FillAttributes (e, eventDeclaration.Attributes);
					c.Events.Add(e);
				}
			} else {
*/				ModifierFlags mf = eventDeclaration.Modifier;
				e = new DefaultEvent (eventDeclaration.Name, type, (ModifierEnum)mf, region, bodyRegion);
				FillAttributes (e, eventDeclaration.Attributes);
				c.Events.Add(e);
//			}
			return null;
		}
		
		public override object Visit(AST.IndexerDeclaration indexerDeclaration, object data)
		{
			DefaultRegion region     = GetRegion(indexerDeclaration.StartLocation, indexerDeclaration.EndLocation);
			DefaultRegion bodyRegion = GetRegion(indexerDeclaration.BodyStart,     indexerDeclaration.BodyEnd);
			ParameterCollection parameters = new ParameterCollection();
			Class c = (Class)currentClass.Peek();
			ModifierFlags mf = indexerDeclaration.Modifier;
			DefaultIndexer i = new DefaultIndexer (new ReturnType(indexerDeclaration.TypeReference), parameters, (ModifierEnum)mf, region, bodyRegion);
			if (indexerDeclaration.Parameters != null) {
				foreach (AST.ParameterDeclarationExpression par in indexerDeclaration.Parameters) {
					parameters.Add (CreateParameter (par, i));
				}
			}
			FillAttributes (i, indexerDeclaration.Attributes);
			c.Indexer.Add(i);
			return null;
		}
	}
}
