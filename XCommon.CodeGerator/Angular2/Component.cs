﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XCommon.Extensions.String;
using XCommon.Util;
using System.Linq;
using System.Text.RegularExpressions;

namespace XCommon.CodeGerator.Angular2
{
	internal class Component
    {
		private Configuration.ConfigAngular Config => Generator.Configuration.Angular;

		internal void Run(string feature, List<string> components)
		{
			string path = Path.Combine(Config.ComponentPath, feature);

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			foreach (string component in components)
			{
                if (!Regex.IsMatch(component, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine($"Invalid component name: {component}");
                    continue;
                }

				var selector = GetSelector(component);

				TypeScript(path, component, selector, feature);
				Sass(path, component, selector);
				Html(path, component, selector);

                Console.WriteLine($"Generated component {selector}");
			}
		}
        
		private string GetSelector(string component)
		{
			var result = string.Empty;

			foreach (var item in component)
			{
				if (result.IsEmpty())
				{
					result += item;
					continue;
				}

				if (Char.IsUpper(item))
				{
					result += '-';
					result += item;
					continue;
				}

				result += item;
			}

			return result.ToLower();
		}
		
		private void TypeScript(string path, string name, string selector, string feture)
		{
			var file = Path.Combine(path, $"{selector}.component.ts");

			if (File.Exists(file))
			{
				Console.WriteLine($"File already exists: {file}");
				return;
			}

			StringBuilderIndented builder = new StringBuilderIndented();
            string templateUrl = $"templateUrl: \"{Config.HtmlRoot}/{feture}/{selector}.html\",";

			builder
				.AppendLine("import { Component, OnInit } from \"@angular/core\";")
				.AppendLine()
				.AppendLine("@Component({")
				.IncrementIndent()
				.AppendLine($"selector: \"{selector}\",")
				.AppendLine(templateUrl.ToLower())
				.AppendLine($"styles: [require(\"./{selector}.scss\")]")
                .DecrementIndent()
				.AppendLine("})")
				.AppendLine($"export class {name}Component implements OnInit {{")
				.IncrementIndent()
				.AppendLine("constructor() { }")
				.AppendLine()
				.AppendLine("ngOnInit() { }")
				.DecrementIndent()
				.AppendLine("}");

			File.WriteAllText(file, builder.ToString(), Encoding.UTF8);
		}

		private void Sass(string path, string name, string selector)
		{
			var file = Path.Combine(path, $"{selector}.scss");

			if (File.Exists(file))
			{
				Console.WriteLine($"File already exists: {file}");
				return;
			}

			StringBuilderIndented builder = new StringBuilderIndented();

			Config.StyleInclude.ForEach(c => builder.AppendLine(c));

			if (Config.StyleInclude.Count > 0)
				builder.AppendLine();

			builder
				.AppendLine($".{selector} {{")
				.AppendLine("}");

			File.WriteAllText(file, builder.ToString());
		}

		private void Html(string path, string name, string selector)
		{
			var file = Path.Combine(path, $"{selector}.html");

			if (File.Exists(file))
			{
				Console.WriteLine($"File already exists: {file}");
				return;
			}

			StringBuilderIndented builder = new StringBuilderIndented();

			builder
				.AppendLine($"<h1>Hey! I\"m {selector}</h1>");

			File.WriteAllText(file, builder.ToString());
		}
	}
}
