using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Bussiness_Logic;
using Models;
using Microsoft.Data.SqlClient;
using EF_Layer.Entities;

namespace Patient_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        ILogic logic;

        public PrescriptionController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpPost("AddPrescription")]
        public IActionResult AddPrescription([FromBody] Prescription_M prescription_M)
        {
            try
            {
                var pres = logic.AddPrescription(prescription_M);
                return Ok(prescription_M);
            }
            catch (SqlException sq)
            {
                return BadRequest(sq);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetPrescriptionById/{id}")]
        public IActionResult GetPrescriptionById([FromRoute] int id)
        {
            try
            {
                var result = logic.GetPrescriptionById(id);
                return Ok(result);
            }
            catch (SqlException sq)
            {
                return BadRequest(sq.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
