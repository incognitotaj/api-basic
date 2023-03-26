using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController()
        {
        }

        [HttpGet()]
        public ApiResponse Get()
        {
            var result = new
            {
                name = "Salman Taj",
                dateOfBirth = DateTime.Now.AddYears(41),
            };

            return new ApiResponse("New record has been created to the database", result, 200);
        }
    }
}
