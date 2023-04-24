using Mango.Services.ProductAPI.Models.DTO;
using Mango.Services.ProductAPI.Respository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDTO _response;
        private IProductRepository _productRepository;


        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDTO();//Para no tener que instanciar constantemente
        }
        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            { 
                IEnumerable<ProductDTO> productDTOs = await _productRepository.GetProducts();
                _response.Result = productDTOs; 
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]//mandatory for looking with id
        public async Task<ResponseDTO> Get(int id)
        {
            try
            {
                 ProductDTO productDTO = await _productRepository.GetProductById(id);
                _response.Result = productDTO;
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        
        public async Task<ResponseDTO> Post([FromBody] ProductDTO productDTO)
        {

            try
            { 
                ProductDTO model = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = model;
            }

            catch(Exception ex) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
            
        }
        [HttpPut]

        public async Task<ResponseDTO> Put([FromBody] ProductDTO productDTO)
        {

            try
            {
                ProductDTO model = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = model;
            }

            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }


        [HttpDelete]

        public async Task<ResponseDTO> Delete(int id)
        {

            try
            {
                bool isSuccess = await _productRepository.DeleteProdcut(id);
                _response.Result = isSuccess;
            }

            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }
    }
}
