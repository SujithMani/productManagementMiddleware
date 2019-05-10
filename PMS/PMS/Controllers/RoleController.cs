using PMS_DAL.Models;
using PMS_SERVICE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class RoleController : Controller
    {
        RoleDetailService roleDetailService = new RoleDetailService();
        // GET: Role
        public ActionResult Index()
        {
           
            if (Session["username"] != null)
            {
                List<Role> adminDetails = roleDetailService.GetRoles();
                return View("Index", "_LayoutAdmin", adminDetails);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
                
        }
        public ActionResult Create()
        {
            if (Session["username"] != null)
            {
                return View("Create", "_LayoutAdmin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Role role)
        {
            if (Session["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    bool result = roleDetailService.InsertRole(role);
                    if (result)
                    {
                         TempData["success"] = "Data Inserted Successfully";
                    }
                    else
                    {
                        TempData["success"] = "Data Not Inserted Successfully";
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Create", "_LayoutAdmin",role);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Edit(int id)
        {
            Role role = roleDetailService.GetSingleRole(id);
            return View(role);
        }
    }
}