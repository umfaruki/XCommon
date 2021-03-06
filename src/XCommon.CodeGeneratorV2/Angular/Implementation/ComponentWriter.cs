using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XCommon.CodeGenerator.Core;
using XCommon.CodeGenerator.Core.Extensions;
using XCommon.Util;

namespace XCommon.CodeGeneratorV2.Angular.Implementation
{
	public class ComponentWriter : BaseWriter, IComponentWriter
	{
		public void Run(string path, string module, string feature, List<string> components)
		{
			path = path.ToLower();

			foreach (var component in components)
			{
				var outlet = component.GetOutLet();
				var componentName = component.Replace("?o", string.Empty);
				var selector = componentName.GetSelector();

				if (!Regex.IsMatch(componentName, @"^[a-zA-Z]+$"))
				{
					Console.WriteLine($"Invalid component name: {component}");
					continue;
				}

				TypeScript(path, componentName, selector, module, feature);
				Sass(path, selector);
				Html(path, selector, outlet);
			}
		}

		private void TypeScript(string path, string name, string selector, string module, string feture)
		{
			var file = $"{selector}.component.ts";
			var builder = new StringBuilderIndented();
			var templateUrl = $"'./{selector}.html',";

			builder
				.AppendLine("import { Component, OnInit } from '@angular/core';")
				.AppendLine()
				.AppendLine("@Component({")
				.IncrementIndent()
				.AppendLine($"selector: '{selector}',")
				.AppendLine("templateUrl: " + templateUrl.ToLower())
				.AppendLine($"styles: [require('./{selector}.scss')]")
				.DecrementIndent()
				.AppendLine("})")
				.AppendLine($"export class {name.GetName()}Component implements OnInit {{")
				.IncrementIndent()
				.AppendLine("constructor() { }")
				.AppendLine()
				.AppendLine("ngOnInit(): void { }")
				.DecrementIndent()
				.AppendLine("}");

			Writer.WriteFile(path, file, builder, false);
		}

		private void Sass(string path, string selector)
		{
			var file = $"{selector}.scss";
			var builder = new StringBuilderIndented();
			
			builder
				.AppendLine($".{selector} {{")
				.AppendLine("}");

			Writer.WriteFile(path, file, builder, false);
		}

		private void Html(string path, string selector, bool outlet)
		{
			var file = $"{selector}.html";
			var builder = new StringBuilderIndented();

			builder
				.AppendLine($"<div class=\"{selector}\">")
				.IncrementIndent()
				.AppendLine($"<h1>Hey! I\"m {selector}</h1>");


			if (outlet)
			{
				builder
					.AppendLine("<router-outlet></router-outlet>");
			}

			builder
				.DecrementIndent()
				.AppendLine("</div>");

			Writer.WriteFile(path, file, builder, false);
		}
	}
}
