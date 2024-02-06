using Application.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Application.Validation;
public class InvoiceVmValidator :AbstractValidator<InvoiceVm>
{
    public InvoiceVmValidator()
    {
        RuleFor(x => x.Number).NotEmpty().MinimumLength(3).MaximumLength(25);
        RuleFor(x => x.CompanyVm).SetValidator(new CompanyVmValidator());
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.CurrencyVm).SetValidator(new CurrencyVmValidator());
    }
}
