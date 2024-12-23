using Newtonsoft.Json;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models.DTOs;

namespace ProductMicroservice.Services
{
    public class AuditLogService : IAuditLogService
    {

        HttpClient _httpClient;
        public AuditLogService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<AuditLogDTO> LogAudit(AuditLogDTO auditLog)
        {

            //request url where we should make request , here we are trying to call auditlogmicroservice from productmicroservice 
            //we can get the url by running auditlogmicroservice by running post request we can see the request url
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5286/api/Audit", auditLog);
            if (response.IsSuccessStatusCode)
            {
                var responsedata = await response.Content.ReadAsStringAsync();
                var auditLogData = JsonConvert.DeserializeObject<AuditLogDTO>(responsedata);
                return auditLogData;
            }
            throw new Exception("Error while adding modification to auditlog");
        }
    }
}

