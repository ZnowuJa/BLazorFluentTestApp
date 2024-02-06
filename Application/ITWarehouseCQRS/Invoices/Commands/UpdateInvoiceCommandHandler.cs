using Application.Interfaces;
using AutoMapper;
using Domain.Entities.ITWarehouse;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ITWarehouseCQRS.Invoices.Commands;
public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, int>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IMapper _mapper;
    public UpdateInvoiceCommandHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var result = await _appDbContext.Invoices.Where(p => p.Id == request.Id).Include(i => i.Company).Include(j => j.Currency).FirstOrDefaultAsync();
        Invoice item = new()
        {
            Number = request.Number,
            Company = await _appDbContext.Companies.Where(p => p.Id == request.CompanyVm.Id).FirstOrDefaultAsync(),
            Date = request.Date,
            TotalNet = request.TotalNet,
            Currency = await _appDbContext.Currencies.Where(p => p.Id == request.CurrencyVm.Id).FirstOrDefaultAsync(),
            ItemsGenerated = request.ItemsGenerated
        };

        _appDbContext.Invoices.Update(item);
        await _appDbContext.SaveChangesAsync();
        return item.Id;
    }
}
