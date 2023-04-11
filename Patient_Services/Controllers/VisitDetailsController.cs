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
    public class VisitDetailsController : ControllerBase
    {
        ILogic logic;

        public VisitDetailsController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpPost("AddVisitDetails")]
        public IActionResult AddVisitDetails([FromBody] Visit_Details_M visit_Details_M)
        {
            try
            {
                var visit = logic.AddVisitDetails(visit_Details_M);
                return Ok(visit_Details_M);
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

        [HttpGet("GetVisitDetailsById/{id}")]
        public IActionResult GetVisitDetailsById([FromRoute] int id)
        {
            try
            {
                var result = logic.GetVisitDetailsById(id);
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


        [HttpGet("GetParticularVisitDetailsById/{id}")]
        public IActionResult GetParticularVisitDetailsById([FromRoute] int id)
        {
            try
            {
                var result = logic.GetParticularVisitById(id);
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

        [HttpGet("GetVisitDetailsByAcceptanceId/{id}")]
        public IActionResult GetVisitDetailsByAcceptanceId([FromRoute] int id)
        {
            try
            {
                var result = logic.GetVisitByAcceptanceNo(id);
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
