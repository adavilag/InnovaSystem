using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSystem.Core.Application.Inventory.Products.Queries
{
    public record GetProductById(int id) : IRequest<ProductDto> { }
}
