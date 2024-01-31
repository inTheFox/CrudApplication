using GoodiniApp.Models;
using GoodiniApp.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace GoodiniApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// получить список всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userManager.GetUsers());
        }

        /// <summary>
        /// получить пользователя по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{userId:int}")]
        public IActionResult Get([FromRoute]int userId)
        {
            var user = _userManager.GetUserById(userId);
            if (user != null)
                return Ok(user);
            else
                return NotFound("User not found");
        }

        /// <summary>
        /// создать нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromForm]User user)
        {
            return Ok(_userManager.AddUser(user));
        }

        /// <summary>
        /// обновить информацию о пользователе
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{userId:int}")]
        public IActionResult Update([FromRoute]int userId, [FromForm] User user)
        {
            if (_userManager.GetUserById(userId) == null) return NotFound("user not found");
            return Ok(_userManager.UpdateUserById(userId, user));
        }

        /// <summary>
        /// удалить пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId:int}")]
        public IActionResult Delete([FromRoute] int userId)
        {
            _userManager.RemoveUserById(userId);
            return Ok();
        }
    }

}
