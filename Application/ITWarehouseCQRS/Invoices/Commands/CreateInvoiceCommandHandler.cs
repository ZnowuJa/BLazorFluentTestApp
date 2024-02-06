using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities.ITWarehouse;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Application.ITWarehouseCQRS.Invoices.Commands;
public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IMapper _mapper;
    public CreateInvoiceCommandHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
       
        Invoice item = new()
        {
            Number = request.Number,
            Company = await _appDbContext.Companies.Where(p => p.Id == request.CompanyVm.Id).FirstOrDefaultAsync(),
            Date = request.Date,
            TotalNet = request.TotalNet,
            Currency = await _appDbContext.Currencies.Where(p => p.Id == request.CurrencyVm.Id).FirstOrDefaultAsync(),
            ItemsGenerated = request.ItemsGenerated
        };

        _appDbContext.Invoices.Add(item);
        await _appDbContext.SaveChangesAsync();
        return item.Id;
    }
}
