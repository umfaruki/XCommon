﻿using System.Collections.Generic;
using XCommon.Patterns.Repository.Executes;

namespace XCommon.Patterns.Specification.Validation.Implementation
{
	internal class SpecificationList<TEntity>
	{
		public ISpecificationValidation<TEntity> Specification { get; set; }

		public bool StopIfInvalid { get; set; }
	}

	public class SpecificationValidation<TEntity> : ISpecificationValidation<TEntity>
	{
		public SpecificationValidation()
		{
			SpecificationsList = new List<SpecificationList<TEntity>>();
			Add(new AndIsNotEmpty<TEntity, object>(c => c, AndIsNotEmptyType.Object, "Entity {0} can't be null", typeof(TEntity).Name), true);
		}

		private List<SpecificationList<TEntity>> SpecificationsList { get; set; }

		public bool IsSatisfiedBy(TEntity entity)
			=> IsSatisfiedBy(entity, new Execute());

		public bool IsSatisfiedBy(TEntity entity, Execute execute)
		{
			bool result = true;

			foreach (var item in SpecificationsList)
			{
				var satisfied = item.Specification.IsSatisfiedBy(entity, execute);
				result = result && satisfied;

				if (!result && item.StopIfInvalid)
					break;
			}

			return result;
		}

		public void Add(ISpecificationValidation<TEntity> specification, bool stopIfInvalid = false)
		{
			SpecificationsList.Add(new SpecificationList<TEntity> { Specification = specification, StopIfInvalid = stopIfInvalid });
		}
	}
}