using System.Linq;
using System.Threading.Tasks;
using Intex2.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intex2.Controllers
{
    // RBAC functionality can only be accessed by admin users
    [Authorize(Roles = "Administrator")]
    public class UserRoleManagementController : Controller
    {
        // Brings in the usermanager and rolemanager tools
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        // Constructs the RBAC controller with above tools
        public UserRoleManagementController(UserManager<ApplicationUser> userManager,
                                            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // Displays basic RBAC page
        [HttpGet]
        public IActionResult Index()
        {
            //get all users and send to view
            var users = userManager.Users.ToList();
            return View(users);
        }

        // Displays details about users
        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            //find user by userId
            //Add UserName to ViewBag
            //get userRole of users and send to view
            var user = await userManager.FindByIdAsync(userId);

            ViewBag.UserName = user.UserName;

            // Get roles associated with user
            var userRoles = await userManager.GetRolesAsync(user);

            return View(userRoles);
        }

        // Displays the add role page, where additional roles can be created
        [HttpGet]
        public IActionResult AddRole()
        {
            return RedirectToAction(nameof(DisplayRoles));
        }
        // Handles creation of new roles
        [HttpPost]
        public async Task<IActionResult> AddRole(string role)
        {
            //create new role using roleManager
            //return to displayRoles
            await roleManager.CreateAsync(new IdentityRole(role));
            return RedirectToAction(nameof(DisplayRoles));
        }
        // Displays all available roles
        [HttpGet]
        public IActionResult DisplayRoles()
        {
            //get all roles and pass to view
            var roles = roleManager.Roles.ToList();

            return View(roles);
        }
        // Displays screen where users can be added to roles
        [HttpGet]
        public IActionResult AddUserToRole()
        {
            //get all users
            //get all roles
            //create selectlist and pass using viewBag
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();

            ViewBag.Users = new SelectList(users, "Id", "UserName");
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View();
        }
        // Handles associating users with roles
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRole userRole)
        {
            //find user from userRole.UserId
            //assign role to user
            //redirect to index

            var user = await userManager.FindByIdAsync(userRole.UserId);

            await userManager.AddToRoleAsync(user, userRole.RoleName);

            return RedirectToAction(nameof(Index));
        }
        // Displays the remove user role page, removes user role
        [HttpGet]
        public async Task<IActionResult> RemoveUserRole(string role, string userName)
        {
            //get user from userName
            //remove role of user using userManager
            //return to details with parameter userId

            var user = await userManager.FindByNameAsync(userName);

            var result = await userManager.RemoveFromRoleAsync(user, role);

            return RedirectToAction(nameof(Details), new { userId = user.Id });
        }
        // Displays roles, deletes a role
        [HttpGet]
        public async Task<IActionResult> RemoveRole(string role)
        {
            //get role to delete using role Name
            //delete role using roleManager
            //redirect to displayroles

            var roleToDelete = await roleManager.FindByNameAsync(role);
            var result = await roleManager.DeleteAsync(roleToDelete);

            return RedirectToAction(nameof(DisplayRoles));
        }
    }
}