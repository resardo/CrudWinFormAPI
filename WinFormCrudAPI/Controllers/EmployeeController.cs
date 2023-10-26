using Domain.Contracts;
using DTO.EmployeeDTO;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IConfiguration _config;
        private readonly IEmployeeDomain _userDomain;

        public EmployeeController(IConfiguration config,IEmployeeDomain userDomain)
        {
            _config = config;
            _userDomain = userDomain;
        }



        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                
                var users = _userDomain.GetAllUsers();
                return (users != null) ? Ok(users) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
               
                var user = _userDomain.GetUserById(userId);
                return (user != null) ? Ok(user) : NotFound();
                
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost]
        [Route("Register")]
        public IActionResult Register(EmployeeDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                else
                {
                    _userDomain.Create(request);
                    return Ok(request);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPut]
        [Route("Update")]

        public IActionResult Update([FromBody] EmployeeDTO employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                else
                {
                    _userDomain.Update(employee);
                    return Ok("updated");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _userDomain.Remove(Id);
                return Ok("update completed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
