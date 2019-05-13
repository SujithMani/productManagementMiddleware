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
                    return RedirectToAction("Index", "Role");
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
            return View("Edit", "_LayoutAdmin", role);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Role role)
        {
            if (Session["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    bool result = roleDetailService.InsertRole(role);
                    if (result)
                    {
                        TempData["success"] = "Data Updated Successfully";
                    }
                    else
                    {
                        TempData["success"] = "Data Not Updated Successfully";
                    }
                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    return View("Edit", "_LayoutAdmin", role);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Details(int id)
        {
            if (Session["username"] != null)
            {
               
                    Role result = roleDetailService.GetSingleRole(id);
                    if (result != null)
                    {
                    return View("Details", "_LayoutAdmin", result);
                }
                    else
                    {
                    return RedirectToAction("Index", "Role");
                }
                  
                    
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Delete(int id)
        {
            if (Session["username"] != null)
            {

                bool result = roleDetailService.DeleteRole(id);
                if (result)
                {
                    TempData["success"] = "Data Deleted Successfully";
                }
                else
                {
                    TempData["success"] = "Data Not Deleted Successfully";
                }
                return RedirectToAction("Index", "Role");


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}