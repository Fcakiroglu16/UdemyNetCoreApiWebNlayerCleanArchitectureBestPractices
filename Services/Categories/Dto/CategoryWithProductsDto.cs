using App.Services.Products;

namespace App.Services.Categories.Dto;

public record CategoryWithProductsDto(int Id, string Name, List<ProductDto> Products);