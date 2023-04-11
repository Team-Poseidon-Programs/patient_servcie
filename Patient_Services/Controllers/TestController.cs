using Patient_Bussiness_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Patient_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        ILogic? _logic;

        public TestController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpPost("AddTest")]
        public IActionResult AddTest([FromBody] Test_M test)
        {
            try
            {
                var createdTest = _logic.AddTest(test);
                return Ok(createdTest);
            }
            catch (SqlException sqlE)
            {
                return BadRequest(sqlE.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetTestListbyid/{visitId}")]
        public IActionResult GetTestListbyVisitId([FromRoute] int visitId)
        {
            try
            {
                if (_logic.GetTestList(visitId) != null)
                {
                    return Ok(_logic.GetTestList(visitId));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (SqlException sqlE)
            {
                return BadRequest(sqlE.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTestIdbyname/{name}")]

        public IActionResult GetTestIdByName([FromRoute] string name)
        {
            try
            {
                if (_logic.GetTestIdByName(name) != 0)
                {
                    return Ok(_logic.GetTestIdByName(name));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (SqlException sqlE)
            {
                return BadRequest(sqlE.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateTest/{id}")]

        public IActionResult UpdateTest([FromBody] Test_M test, [FromRoute] int id)
        {
            try
            {
                if (id != null)
                {
                    _logic.UpdateTest(test, id);
                    return Ok(test);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (SqlException sqlE)
            {
                return BadRequest(sqlE.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteTest/{id}")]
        public IActionResult DeleteTest([FromRoute] int id)
        {
            try
            {
                var q = _logic.DeleteTestByID(id);


                return Ok(q);
            }


            catch (SqlException sqlE)
            {
                return BadRequest(sqlE.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }






    }
}
