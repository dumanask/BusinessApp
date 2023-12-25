using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Application.Features.Products.Constants;
using Products.Application.Services.Repositories;
using Products.Domain;
using Shared.Exceptions.Types;
using Shared.Rules;

namespace Products.Application.Features.Products.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;

    public ProductBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ProductCodeCannotBeDuplicatedWhenInserted(string productCode)
    {
        Product? result = await _productRepository.GetAsync(predicate: p => p.ProductCode == productCode);

        if (result != null)
        {
            throw new BusinessExceptions(ProductMessages.ProductCodeExists);
        }
    }

}

