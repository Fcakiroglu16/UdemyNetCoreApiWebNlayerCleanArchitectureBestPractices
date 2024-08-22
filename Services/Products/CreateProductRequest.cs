namespace App.Services.Products;

public record CreateProductRequest(string Name, decimal Price, int Stock);