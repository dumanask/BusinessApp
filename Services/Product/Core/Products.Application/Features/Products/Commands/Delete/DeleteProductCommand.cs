using AutoMapper;
using MediatR;
using Products.Application.Services.Repositories;
using Products.Domain;

namespace Products.Application.Features.Products.Commands.Delete;

public class DeleteProductCommand: IRequest<DeleteProductResponse>
{
    public Guid Id { get; set; }

    public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand,DeleteProductResponse> 
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetById(predicate: b => b.Id == request.Id);

            await _productRepository.DeleteAsync(product);

            DeleteProductResponse response = _mapper.Map<DeleteProductResponse>(product);
            return response;
        }
    }
}