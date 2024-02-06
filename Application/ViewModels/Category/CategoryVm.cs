using Domain.Entities.ITWarehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Category;
public class CategoryVm
{
    public string Name { get; set; }
    public string Prefix { get; set; }
    public int CategoryTypeId { get; set; }
    public CategoryType CategoryType { get; set; }
}
