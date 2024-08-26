
using Microsoft.AspNetCore.Http;

namespace Catalog.API.Products.UpdateProduct;



public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

internal class UpdateProductCommandHandler
    (
        IDocumentSession session,
        ILogger<UpdateProductCommandHandler> logger
    ) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler.Handle called with {@command}", command);

        // update the product entity from the command object using session.LoadAsync<Product>(query.Id, cancellationToken)

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);


        if (product is null)
        {
            logger.LogWarning("Product with Id {Id} not found", command.Id);
            throw new ProductNotFoundException();
        }
        

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;


        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
