using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Bussiness_Logic;
using Models;
using Microsoft.Data.SqlClient;

namespace Patient_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        ILogic logic;

        public PatientController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpPost("Add_Patient")]
        public IActionResult AddPatient([FromBody] Patient_M patient)
        {
            try
            {
                var pati = logic.AddPatient(patient);
                return Ok(patient);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update_Patient/{id}")]
        public IActionResult UpdatePatient([FromBody] Patient_M patient,[FromRoute] int id)
        {
            try
            {
                if (id != null)
                {
                    logic.UpdatePatient(patient, id);
                    return Ok(patient);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get_all_Patient")]
        public IActionResult GetAllPatient()
        {
            try
            {
                var patients = logic.GetAllPatient();

                if (patients.Count() > 0)
                {
                    return Ok(patients);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get_by_ID/{id}")]
        public IActionResult GetbyID([FromRoute] int id)
        {
            try
            {
                var value = logic.GetByID(id);
                return Ok(value);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PatientExist/{email}")]
        public IActionResult PatientExist([FromRoute] string email)
        {
            try
            {
                var value = logic.PatientIsExist(email);
                return Ok(value);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("patientLogin/{email}/{password}")]

        public IActionResult patientlogin([FromRoute] string email,[FromRoute] string password)
        {
            try
            {
                var value = logic.login(email, password);
                return Ok(value);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("phoneNo/isExist/{phone}")]

        public IActionResult phoneIsExist([FromRoute]string phone)
        {
            try
            {
                var value = logic.isExistPhone(phone);
                return Ok(value);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
