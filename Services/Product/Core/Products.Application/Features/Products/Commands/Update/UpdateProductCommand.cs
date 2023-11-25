using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;

namespace Products.Application.Features.Products.Commands.Update;

public class UpdateProductCommand :IRequest<UpdateProductResponse>
{
    public Guid Id { get; set; }
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,UpdateProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(x => x.Id == request.Id);

            product.ProductCode = request.ProductCode;
            product.ProductName = request.ProductName;
            product.Description = request.Description;

            var productToReturn = await _productRepository.UpdateAsync(product);

            return _mapper.Map<UpdateProductResponse>(productToReturn);
        }
    }
}