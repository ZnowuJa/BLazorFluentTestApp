using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ITWarehouseCQRS.Invoices.Queries;
public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, IQueryable<InvoiceVm>>
{
    private readonly IAppDbContext _appDbContext;
    private IMapper _mapper;
    public GetAllInvoicesQueryHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }
    public async Task<IQueryable<InvoiceVm>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        var result = await _appDbContext.Invoices.Where(p => p.StatusId == 1).Include(i => i.Company).Include(j => j.Currency).ToListAsync(cancellationToken);
        var res = _mapper.Map<List<InvoiceVm>>(result);
        return res.AsQueryable();
    }
}
