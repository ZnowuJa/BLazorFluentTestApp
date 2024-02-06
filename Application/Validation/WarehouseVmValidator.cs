﻿using Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation;
public class WarehouseVmValidator : AbstractValidator<WarehouseVm>
{
    public WarehouseVmValidator()
    {
        RuleFor(x => x.Number).GreaterThan(999).NotEqual(9999);
        RuleFor(x => x.Name).MinimumLength(3).MaximumLength(25);
        RuleFor(x => x.Name).NotEqual("Select...");
    }
}
