using Apsiyon.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Apsiyon.Controller
{
    public class ApsiyonControllerBase : ControllerBase
    {
        /// <summary>
        /// According to the success status of the sent IResult object, if it is successful, 200 Ok (with data if there is data), and if it is unsuccessful, 400 Bad Request IActionResult is returned with the message.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public IActionResult ReturnResult(IResult result)
        {
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }

        public string GetLanguage()
        {
            string result = string.Empty;

            result = this.Request.Headers["lng"];

            return result ?? "en";
        }
    }
}
