﻿using Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ITWarehouseCQRS.Parts.Commands;
public class UpdatePartCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryVm CategoryVm { get; set; }
    public VendorVm VendorVm { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public int WarrantyPeriod { get; set; }
    public bool isCurrentlyOrderable { get; set; }
    public UpdatePartCommand(int id, string name, CategoryVm categoryVm, VendorVm vendorVm, string description, string photo, int warrantyPeriod, bool iscurrentlyOrderable)
    {
        Id = id;
        Name = name;
        CategoryVm = categoryVm;
        VendorVm = vendorVm;
        Description = description;
        Photo = photo;
        WarrantyPeriod = warrantyPeriod;
        isCurrentlyOrderable = iscurrentlyOrderable;
    }
}