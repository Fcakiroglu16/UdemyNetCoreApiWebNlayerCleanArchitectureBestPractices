namespace App.Application.Features.Products.Update;

public record UpdateProductRequest(string Name, decimal Price, int Stock, int CategoryId);