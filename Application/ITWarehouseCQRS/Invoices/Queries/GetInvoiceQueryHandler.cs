using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ITWarehouseCQRS.Invoices.Queries;
public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, InvoiceVm>
{
    private readonly IAppDbContext _appDbContext;
    private readonly IMapper _mappper;
    public GetInvoiceQueryHandler(IAppDbContext appDbContext, IMapper mappper)
    {
        _appDbContext = appDbContext;
        _mappper = mappper;
    }
    public async Task<InvoiceVm> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        
        var result = await _appDbContext.Invoices.Where(p => p.Id == request.InvoiceId).Include(i => i.Company).Include(j => j.Currency).FirstOrDefaultAsync();
        var res = _mappper.Map<InvoiceVm>(result);
        return res;
    }
}
