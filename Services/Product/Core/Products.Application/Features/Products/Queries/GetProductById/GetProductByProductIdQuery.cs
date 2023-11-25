using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;

namespace Products.Application.Features.Products.Queries.GetProductById;

public class GetProductByProductIdQuery : IRequest<GetProductByProductIdResponse>
{
    public Guid Id { get; set; }
    public class GetProductByProductIdQueryHandler : IRequestHandler<GetProductByProductIdQuery, GetProductByProductIdResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByProductIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByProductIdResponse> Handle(GetProductByProductIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetById(x => x.Id == request.Id);

            var response = _mapper.Map<GetProductByProductIdResponse>(data);

            return response;
        }
    }
}