﻿using System.Collections.Generic;

namespace XCommon.CodeGenerator.Core.Entity
{
	public class ItemGroup
    {
		public ItemGroup()
		{
			Items = new List<Item>();
		}

		public string Name { get; set; }
		
		public List<Item> Items { get; set; }
	}
}