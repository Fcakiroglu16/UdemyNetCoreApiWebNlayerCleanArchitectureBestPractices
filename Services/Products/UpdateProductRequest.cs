namespace App.Services.Products;

public record UpdateProductRequest(string Name, decimal Price, int Stock);