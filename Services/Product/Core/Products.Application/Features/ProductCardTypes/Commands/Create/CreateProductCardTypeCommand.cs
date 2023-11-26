using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;
using Products.Domain;

namespace Products.Application.Features.ProductCardTypes.Commands.Create;

public class CreateProductCardTypeCommand : IRequest<CreateProductCardTypeResponse>
{
    public string ProductCardTypeCode { get; set; }
    public string ProductCardTypeName { get; set; }
    public string ProductCardTypeDescription { get; set; }

    public class CreateProductCardTypeCommandHandler : IRequestHandler<CreateProductCardTypeCommand, CreateProductCardTypeResponse>
    {
        private readonly IProductCardTypeRepository _productCardTypeRepository;
        private readonly IMapper _mapper;

        public CreateProductCardTypeCommandHandler(IProductCardTypeRepository productCardTypeRepository, IMapper mapper)
        {
            _productCardTypeRepository = productCardTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductCardTypeResponse> Handle(CreateProductCardTypeCommand request, CancellationToken cancellationToken)
        {
            var productCardType = _mapper.Map<ProductCardType>(request);
            productCardType.Id = Guid.NewGuid();

            var productToReturn = await _productCardTypeRepository.AddAsync(productCardType);

            return _mapper.Map<CreateProductCardTypeResponse>(productToReturn);

        }
    }
}