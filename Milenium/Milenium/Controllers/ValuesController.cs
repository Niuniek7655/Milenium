using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;

namespace Milenium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;
        private readonly IModelValidator _validator;

        public ValuesController(ILogger<ValuesController> logger, IRepository repository, IModelValidator validator)
        {
            _logger = logger;
            _repository = repository;
            _validator = validator;
        }

        // GET api/values
        [HttpGet("{format}"), FormatFilter]
        public ActionResult<IEnumerable<TestObject>> GetAll()
        {
            IEnumerable<TestObject> collection = _repository.GetAll();
            return Ok(collection);
        }

        // GET api/values/5
        [HttpGet("{format}/{id}"), FormatFilter]
        public ActionResult<TestObject> Get(int id)
        {
            TestObject value = _repository.Get(id);
            _logger.LogInformation($"Return object {id}");
            return value;
        }

        // POST api/values
        [HttpPost("{format}"), FormatFilter]
        public ActionResult Create([FromBody] TestObject value)
        {
            try
            {
                bool isCorrect = _validator.Validate(value);
                if(!isCorrect)
                {
                    _logger.LogInformation($"Invalid object");
                    return BadRequest();
                }
                _repository.Add(value);
                _logger.LogInformation($"Add object {value.Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Can not add object");
                return StatusCode(500);
            }
        }

        // PUT api/values/5
        [HttpPut("{format}/{id}"), FormatFilter]
        public ActionResult Update(int id, [FromBody] TestObject value)
        {
            try
            {
                bool isCorrect = _validator.Validate(value);
                if (!isCorrect)
                {
                    _logger.LogInformation($"Invalid object");
                    return BadRequest();
                }
                _repository.Update(id, value);
                _logger.LogInformation($"Update object {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Can not update object {id}");
                return StatusCode(500);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{format}/{id}"), FormatFilter]
        public ActionResult Remove(int id)
        {
            try
            {
                _repository.Remove(id);
                _logger.LogInformation($"Remove object {id}");
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Can not remove object {id}");
                return StatusCode(500);
            }
        }
    }
}
