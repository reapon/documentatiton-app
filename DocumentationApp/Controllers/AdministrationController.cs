﻿using DocumentationApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentationApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;



        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        [Authorize(Roles ="Super Admin")]
        public IActionResult RegisterWithRole()
        {

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var role in roleManager.Roles)
            {
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }

            ViewBag.Roles = list;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin")]

        public async Task<IActionResult> RegisterWithRole(RegisterWithRole model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {

                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true,

                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    result = await userManager.AddToRoleAsync(user, model.RoleName);

                    //await signInManager.SignInAsync(user, isPersistent: false);
                    
                    return RedirectToAction("ListUsers", "Administration");

                }



            }

            return RedirectToAction("ListUsers", "Administration");
        }





        [HttpGet]
        [Authorize(Roles = "Super Admin")]

        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        [Authorize(Roles = "Super Admin")]

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin")]

        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Super Admin")]

        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in userManager.Users)
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        // This action responds to HttpPost and receives EditRoleViewModel
        [HttpPost]
        [Authorize(Roles = "Super Admin")]

        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Super Admin")]

        public async Task<IActionResult> ListUsers()
        {
            var users = await userManager.Users.ToListAsync();

            if (users.Count == 0)
            {
                return View("NotFound");
            }

            var model = new List<EditUserViewModel>();
            // GetClaimsAsync retunrs the list of user Claims
            // var userClaims = await userManager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            foreach (var user in users)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var submodel = new EditUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = userRoles
                };
                model.Add(submodel);
            }
            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "Super Admin")]

        public async Task<IActionResult> EditUser(string id)
        {
            ViewBag.userId = id;

            var user = await userManager.FindByIdAsync(id);
            ViewBag.userName = user.UserName;



            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new List<RoleUserViewModel>();

            foreach (var role in roleManager.Roles)
            {

                var userRoles = await userManager.IsInRoleAsync(user, role.Name);

                var roleUserViewModel = new RoleUserViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };

                if (userRoles)
                {
                    roleUserViewModel.IsSelected = true;
                }
                else
                {
                    roleUserViewModel.IsSelected = false;
                }
                model.Add(roleUserViewModel);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin")]

        public async Task<IActionResult> EditUser(List<RoleUserViewModel> model, string id)
        {


            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var role = await roleManager.FindByIdAsync(model[i].RoleId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("ListUsers");
                }
            }

            return RedirectToAction("ListUsers");
        }
    }
}
