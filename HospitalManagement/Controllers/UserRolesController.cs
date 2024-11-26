using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View("Index", roles);
        }


        [HttpGet]
        public async Task<IActionResult> Create(string roleId = null)
        {
            if (!string.IsNullOrEmpty(roleId))
            {
                // Fetch the existing role by roleId
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    return NotFound(); // Handle if the role does not exist
                }

                // Pass the role name to the view if editing an existing role
                ViewBag.RoleName = role.Name;
                return View("Create",role);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            //Check duplicate roles(Existing roles)

            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }



    }
}
