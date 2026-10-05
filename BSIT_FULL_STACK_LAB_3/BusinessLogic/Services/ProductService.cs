using BusinessLogic.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services


public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductModel>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<ProductModel?> GetByIdAsync(Guid id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(ProductModel product)
    {
        Validate(product);

        product.Id = Guid.NewGuid();

        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(ProductModel product)
    {
        Validate(product);

        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<List<ProductModel>> SearchAsync(
        string keyword)
    {
        return await _productRepository.SearchAsync(keyword);
    }

    private static void Validate(ProductModel product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException(
                "Product name is required.");
        }

        if (product.Name.Trim().Length < 3)
        {
            throw new ArgumentException(
                "Product name must contain at least 3 characters.");
        }

        if (product.Price <= 0)
        {
            throw new ArgumentException(
                "Product price must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(product.Category))
        {
            throw new ArgumentException(
                "Category is required.");
        }
    }
}