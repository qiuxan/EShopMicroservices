﻿
namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id): ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}

internal class DeleteProductCommandHandler
    (
        IDocumentSession session,
        ILogger<DeleteProductCommandHandler> logger
    ): ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting product with {command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if (product == null) {
            logger.LogWarning("Product with id {id} not found", command.Id);
            throw new ProductNotFoundException();
        }

        session.Delete(product);
        await session.SaveChangesAsync(cancellationToken);
        return new DeleteProductResult(true);
    }
}
