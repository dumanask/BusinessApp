using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;
using Products.Domain;

namespace Products.Application.Features.Products.Commands.CreateList;

public class CreateProductsInListCommand: IRequest<List<CreateProductsInListResponse>>
{
    public List<Product> Products { get; set; }

    // id'nin arrayden silinmesi gerekiyor. Silinince calisiyor.

    public class CreateProductsInListCommandHandler: IRequestHandler<CreateProductsInListCommand,List<CreateProductsInListResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductsInListCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<CreateProductsInListResponse>> Handle(CreateProductsInListCommand request, CancellationToken cancellationToken)
        {
            var createResponses = new List<CreateProductsInListResponse>();

            foreach (var item in request.Products)
            {
                var product = _mapper.Map<Product>(item);
                product.Id = Guid.NewGuid();

                var createResponse = await _productRepository.AddAsync(product);

                var response = _mapper.Map<CreateProductsInListResponse>(createResponse);

                createResponses.Add(response);
            }

            return createResponses;

        }
    }
}