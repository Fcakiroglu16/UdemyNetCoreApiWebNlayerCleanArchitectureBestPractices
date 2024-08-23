﻿using App.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class ProductsController(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await productService.GetAllListAsync());


        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetPagedAll(int pageNumber, int pageSize) =>
            CreateActionResult(await productService.GetPagedAllListAsync(pageNumber, pageSize));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await productService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            return CreateActionResult(await productService.CreateAsync(request));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request) =>
            CreateActionResult(await productService.UpdateAsync(id, request));


        //[HttpPut("UpdateStock")]
        //public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) =>
        //    CreateActionResult(await productService.UpdateStockAsync(request));


        [HttpPatch("stock")]
        public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) =>
            CreateActionResult(await productService.UpdateStockAsync(request));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteAsync(id));
    }
}