using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;
using Products.Domain;

namespace Products.Application.Features.Products.Commands.DeleteList;

public class DeleteProductsInListCommand: IRequest<List<DeleteProductsInListResponse>>
{
    public List<Guid> Ids { get; set; }

    public class DeleteProductsInListCommandHandler: IRequestHandler<DeleteProductsInListCommand,List<DeleteProductsInListResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductsInListCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<DeleteProductsInListResponse>> Handle(DeleteProductsInListCommand request, CancellationToken cancellationToken)
        {
            var deletedItems = new List<Product>();

            foreach (var id in request.Ids)
            {
                var item = await _productRepository.GetById(x => x.Id == id);
                if (item != null)
                {
                    deletedItems.Add((Product) item);
                }
            }
            await _productRepository.DeleteRangeAsync(deletedItems);

            return _mapper.Map<List<DeleteProductsInListResponse>>(deletedItems);
        }
    }
}