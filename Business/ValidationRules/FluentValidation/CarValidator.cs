using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(p => p.Description).MinimumLength(6).WithMessage("Description must be min six character");
			RuleFor(p => p.Description).NotEmpty().WithMessage("Description must be not null.");
			RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Dailyprice must be greater than zero");
			RuleFor(p => p.DailyPrice).NotEmpty().WithMessage("Dailyprice must be not null.");
			RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.CarId == 2);
			RuleFor(p => p.Description).Must(startWithB).Must(endWithN);
			RuleFor(p => p.CarId).NotEmpty();
		}

		private bool endWithN(string arg)
		{
			return arg.EndsWith("N");
		}

		private bool startWithB(string arg)
		{
			return arg.StartsWith("B");
		}
	}
}
