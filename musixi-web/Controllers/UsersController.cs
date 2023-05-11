using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using musixi_core.DTOs;
using musixi_core.Models;
using musixi_web.Filters;
using musixi_web.Services;

namespace musixi_web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserApiService _userApiService;
        private readonly RoleApiService _roleApiService;

        public UsersController(UserApiService userApiService, RoleApiService roleApiService)
        {
            _userApiService = userApiService;
            _roleApiService = roleApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userApiService.GetUsersWithRoleAsync());
        }

        public async Task<IActionResult> Save()
        {
            var rolesDto = await _roleApiService.GetAllAsync();
            ViewBag.roles = new SelectList(rolesDto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userApiService.SaveAsync(userDto);
                return RedirectToAction(nameof(Index));
            }

            var rolesDto = await _roleApiService.GetAllAsync();
            ViewBag.roles = new SelectList(rolesDto, "Id", "Name");
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userApiService.GetByIdAsync(id);
            var rolesDto = await _roleApiService.GetAllAsync();
            ViewBag.roles = new SelectList(rolesDto, "Id", "Name", user.RoleId);
            return View(user);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userApiService.UpdateAsync(userDto);
                return RedirectToAction(nameof(Index));
            }

            var rolesDto = await _roleApiService.GetAllAsync();
            ViewBag.roles = new SelectList(rolesDto, "Id", "Name", userDto.RoleId);
            return View(userDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _userApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
