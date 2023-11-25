using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;
using Products.Domain;

namespace Products.Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreateProductResponse>
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();

            var productToReturn = await _productRepository.AddAsync(product);

            return _mapper.Map<CreateProductResponse>(productToReturn);

        }
    }
}