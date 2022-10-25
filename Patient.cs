using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using IntakeForm.Models;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace InTake
{
    public static class Patient
    {
        [FunctionName("User")]
        public static async Task<IActionResult> CreateTask(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "User")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<PersonalInformation>(requestBody);
            try
            {
                using (SqlConnection connection = new SqlConnection("InTakeDB"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("PersonalInfoUpdate", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FirstName", input.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@PreferredName", input.PreferredName));
                    cmd.Parameters.Add(new SqlParameter("@MiddleName", input.MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", input.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Suffix", input.Suffix));
                    cmd.Parameters.Add(new SqlParameter("@SSN", input.SSN));
                    cmd.Parameters.Add(new SqlParameter("@DateofBirth", input.DateofBirth));
                    cmd.Parameters.Add(new SqlParameter("@BirthSex", input.BirthSex));
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return new BadRequestResult();
            }
            return new OkResult();
        }
        [FunctionName("GetTasks")]
        public static async Task<IActionResult> GetTasks(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "task")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<PersonalInformation>(requestBody);

            try
            {
                using (SqlConnection connection = new SqlConnection("InTakeDB"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("PersonalInfoGetAll", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
            return new OkResult();
        }
    }
}
