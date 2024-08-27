using App.Repositories.Products;
using FluentValidation;

namespace App.Services.Products.Create
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductRequestValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(x => x.Name)
                //.NotNull().WithMessage("Ürün ismi gereklidir.")
                .NotEmpty().WithMessage("ürün ismi gereklidir.")
                .Length(3, 10).WithMessage("ürün ismi  3 ile 10 karakter arasında olmalıdır.");
            //.MustAsync(MustUniqueProductNameAsync).WithMessage("ürün ismi veritabanında bulunmaktadır.");
            //.Must(MustUniqueProductName).WithMessage("ürün ismi veritabanında bulunmaktadır.");

            // price validation
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("ürün fiyatı 0'dan büyük olmalıdır.");


            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("ürün kategori değeri 0'dan büyük olmalıdır.");


            //stock inclusiveBetween validation
            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("stok adedi 1 ile 100 arasında olmalıdır");
        }


        #region 2.way async validation

        //private async Task<bool> MustUniqueProductNameAsync(string name, CancellationToken cancellationToken)
        //{
        //    return !await _productRepository.Where(x => x.Name == name).AnyAsync(cancellationToken);
        //}

        #endregion


        #region 1.way sync validation

        //private bool MustUniqueProductName(string name)
        //{
        //    return !_productRepository.Where(x => x.Name == name).Any();

        //    // false => bir hata var.
        //    // true => bir hata yok
        //}

        #endregion
    }
}