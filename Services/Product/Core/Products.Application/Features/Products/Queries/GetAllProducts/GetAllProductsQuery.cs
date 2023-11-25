using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;

namespace Products.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<GetAllProductsResponse>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
            
        public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetListAsync();

            var response = _mapper.Map<List<GetAllProductsResponse>>(data);

            return response;

        }
    }
}