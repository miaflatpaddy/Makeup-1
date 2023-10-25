﻿using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makeup_1.Models.ViewModels.RoleViewModels;
namespace Makeup_1.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index() => View(await roleManager.Roles.ToListAsync());
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ModelState.AddModelError(string.Empty, "Назва ролі не може бути порожньою");
                return View();
            }
            if (await roleManager.RoleExistsAsync(name))
            {
                ModelState.AddModelError(string.Empty, "Така роль вже існує!");
                return View();
            }
            await roleManager.CreateAsync(new IdentityRole { Name = name });
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UserList() => View(await userManager.Users.ToListAsync());

        [HttpGet]
        public async Task<IActionResult> EditUserRoles(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            User user = await userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            ChangeUserRolesDTO viewModel = new ChangeUserRolesDTO
            {
                Id = user.Id,
                AllRoles = await roleManager.Roles.ToListAsync(),
                UserRoles = await userManager.GetRolesAsync(user),
                Login = user.UserName,
                Email = user.Email
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRoles(ChangeUserRolesDTO model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(model.Id);
                if (user == null)
                    return NotFound();
                var oldUserRoles = await userManager.GetRolesAsync(user);
                var addedRoles = model.UserRoles.Except(oldUserRoles);
                var deletedRoles = oldUserRoles.Except(model.UserRoles);
                await userManager.AddToRolesAsync(user, addedRoles);
                await userManager.RemoveFromRolesAsync(user, deletedRoles);
                return RedirectToAction("UserList");
            }
            model.AllRoles = await roleManager.Roles.ToListAsync(); 
            return View(model);
        }
    }
}

