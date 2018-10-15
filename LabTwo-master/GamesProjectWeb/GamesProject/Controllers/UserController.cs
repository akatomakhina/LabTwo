using GamesProject.CustomFilters;
using GamesProjectWeb.Logic.Common.Models;
using GamesProjectWeb.Logic.Common.Services;
using NLog;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GamesProject.Controllers
{
    [RoutePrefix("api/user")]
    [GameExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserController(IUserService userService, ILogger logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Create a user.", Type = typeof(User))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> CreateUser()
        {
            var user = await _userService.CreateUserAsync().ConfigureAwait(false);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed user.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteUser([FromUri] int id)
        {
            await _userService.DeleteUserAsync(id).ConfigureAwait(false);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
