using Domain.Contracts;
using DTO.FormDTO;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {

        private IConfiguration _config;
        private readonly IFormDomain _formdomain;

        public FormController(IConfiguration config, IFormDomain formdomain)
        {
            _config = config;
            _formdomain = formdomain;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllForms()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                
                var forms = _formdomain.GetAllForms();
                return (forms != null) ? Ok(forms) : NotFound();
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet]
        [Route("getByName/{name}")]
        public IActionResult GetFormByName(string name)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                
                var forms = _formdomain.GetFormByName(name);
                return (forms != null) ? Ok(forms) : NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetFormById(Guid Id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                
                var forms = _formdomain.GetFormById(Id);
                return (forms != null) ? Ok(forms) : NotFound();
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult AddForm([FromBody] FormDTO forms)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var user = _formdomain.Add(forms);
                return Ok(user);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateForm([FromBody] FormDTO forms)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                else
                {
                    _formdomain.Update(forms);
                    return Ok("updated");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteForm(Guid Id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                
                _formdomain.Remove(Id);
                return Ok("update completed");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
