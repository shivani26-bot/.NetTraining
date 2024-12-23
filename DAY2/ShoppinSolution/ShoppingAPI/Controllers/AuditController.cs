using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Exceptions;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {

        //includes only 2 end points delete and get 
        private readonly IAuditLogService _auditService;

        public AuditController(IAuditLogService auditService)
        {
            _auditService = auditService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<AuditLog>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<AuditLog>> GetLogs()
        {
            try
            {
                var logs = _auditService.GetLog();
                return Ok(logs);
            }
            catch (RepositoryEmptyException e)
            {
                return NotFound(new ErrorDTO { ErrorNumber = 404, ErrorMessage = e.Message });
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<bool> DeleteLog(DateTime date)
        {
            try
            {
                var result = _auditService.Delete(date);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }
    }
}
