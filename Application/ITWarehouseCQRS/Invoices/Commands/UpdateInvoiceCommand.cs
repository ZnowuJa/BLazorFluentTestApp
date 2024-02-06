using Application.ViewModels;
using MediatR;

namespace Application.ITWarehouseCQRS.Invoices.Commands;
public class UpdateInvoiceCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Number { get; set; }
    public CompanyVm CompanyVm { get; set; }
    public DateTime Date { get; set; }
    public decimal? TotalNet { get; set; }
    public CurrencyVm CurrencyVm { get; set; }
    public bool ItemsGenerated { get; set; }

    public UpdateInvoiceCommand(int id, string number, CompanyVm companyVm, DateTime date, decimal totalNet, CurrencyVm currencyVm, bool itemsGenerated)
    {
        Id = id;
        Number = number;
        CompanyVm = companyVm;
        Date = date;
        TotalNet = totalNet;
        CurrencyVm = currencyVm;
        ItemsGenerated = itemsGenerated;

    }
}
