using AuditLogMicroservice.Interfaces;
using AuditLogMicroservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditLogMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 

    public class AuditController : ControllerBase
    {
        private readonly IAuditLogService _auditService;

        public AuditController(IAuditLogService auditService)
        {
            _auditService = auditService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(AuditLog), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<ICollection<AuditLog>> CreateLog(AuditLog auditLog)
        {
            try
            {
                var log = _auditService.AddAuditLog(auditLog);
                return Ok(log);
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
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
