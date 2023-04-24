using Mango.Services.ProductAPI.Models.DTO;

namespace Mango.Services.ProductAPI.Respository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int productId);
        Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO);
        Task<bool> DeleteProdcut(int productId);
    }
}
