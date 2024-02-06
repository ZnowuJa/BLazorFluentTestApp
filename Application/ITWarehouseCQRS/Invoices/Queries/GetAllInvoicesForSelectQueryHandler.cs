using Application.Interfaces;
using Application.ITWarehouseCQRS.Invoices.Queries;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities.ITWarehouse;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ITWarehouseCQRS.Invoices.Queries;
internal class GetAllInvoicesForSelectQueryHandler : IRequestHandler<GetAllInvoicesForSelectQuery, IQueryable<InvoiceVm>>
{
    private readonly IAppDbContext _appDbContext;
    private IMapper _mapper;

    public GetAllInvoicesForSelectQueryHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;

    }

    public async Task<IQueryable<InvoiceVm>> Handle(GetAllInvoicesForSelectQuery request, CancellationToken cancellationToken)
    {
        Invoice item = new Invoice() { Id = 0, Number = "Select..."};
        List<Invoice> itemList = [item];
        var result = await _appDbContext.Invoices.Where(p => p.StatusId == 1).Include(i => i.Company).Include(j => j.Currency).ToListAsync(cancellationToken);
        itemList.AddRange(result);
        var res = _mapper.Map<List<InvoiceVm>>(itemList);
        return res.AsQueryable();
    }
}

