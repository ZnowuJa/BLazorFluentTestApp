using AutoMapper;
using Domain.Entities.ITWarehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class InvoiceVm
{
    public int Id { get; set; } 
    public string? Number { get; set; }
    public CompanyVm CompanyVm { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalNet { get; set; }
    public CurrencyVm CurrencyVm { get; set; }
    public bool ItemsGenerated { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Invoice, InvoiceVm>().ForMember(d => d.CompanyVm, s => s.MapFrom(src => src.Company)).ForMember(e => e.CurrencyVm, z => z.MapFrom(src2 => src2.Currency));
    }
}
