using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;
using Products.Domain;

namespace Products.Application.Features.Products.Commands.UpdateList;

public class UpdateProductsInListCommand : IRequest<List<UpdateProductsInListResponse>>
{
    public List<Product> Products { get; set; }

    public class UpdateProductsInListCommandHandler : IRequestHandler<UpdateProductsInListCommand, List<UpdateProductsInListResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductsInListCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<UpdateProductsInListResponse>> Handle(UpdateProductsInListCommand request, CancellationToken cancellationToken)
        {
            var updateResponses = new List<UpdateProductsInListResponse>();

            foreach (var item in request.Products)
            {
                var product = await _productRepository.GetById(x => x.Id == item.Id);

                product.ProductCode = item.ProductCode;
                product.ProductName = item.ProductName;
                product.Description = item.Description;

                var productToReturn = await _productRepository.UpdateAsync(product);

                var response = _mapper.Map<UpdateProductsInListResponse>(productToReturn);

                updateResponses.Add(response);
            }

            return updateResponses;
        }
    }
}