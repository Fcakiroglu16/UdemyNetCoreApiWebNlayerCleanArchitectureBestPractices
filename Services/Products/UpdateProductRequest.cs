namespace App.Services.Products;

public record UpdateProductRequest(int Id, string Name, decimal Price, int Stock);