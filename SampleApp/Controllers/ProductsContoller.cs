using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {

        private readonly ISampleAppRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ISampleAppRepository repository, ILogger<ProductsController> logger)
        {

            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products:{ex}");
                return BadRequest("Failed to get products");
            }
        }
    }
}
