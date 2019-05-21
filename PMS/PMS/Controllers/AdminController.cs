using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Models.ViewModels;
using PMS_SERVICE.Services;
namespace PMS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private AdminDetailsService adminDetailsService = new AdminDetailsService();
        private AdminUserRoleService adminUserRoleService = new AdminUserRoleService();
        private RoleDetailService roleDetailService = new RoleDetailService();
        public ActionResult Index()
        {
            List<AdminDetailsVIew> adminDetails= adminDetailsService.GetAdminDetails();
            return View("Index", "_LayoutAdmin", adminDetails);
        }
        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            if (Session["username"] != null)
            {

                AdminDetailsVIew result = adminDetailsService.GetSingleAdminDetails(id);
                if (result != null)
                {
                    return View("Details", "_LayoutAdmin", result);
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            //AdminDetailsVIew adminDetailsVIew = new AdminDetailsVIew();
            //List<AdminUserRoleView> adminDetails = adminUserRoleService.GetAdminUserRoles();
            //adminDetailsVIew.AdminUserRoles = adminDetails;
            AdminCreateView adminCreate = new AdminCreateView();
            List<RoleView> adminDetails = roleDetailService.GetRoles();
            adminCreate.roles = adminDetails;
            return View("Create", "_LayoutAdmin", adminCreate);
        }
        public ActionResult RenderRole()
        {
            List<RoleView> adminDetails = roleDetailService.GetRoles();
            return PartialView(adminDetails);
        }
        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(AdminCreateRequestView adminCreate)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    AdminDetailsService insertAdmin = new AdminDetailsService();
                    var passHash = hashPassword(adminCreate.adminDetails.Password);
                    adminCreate.adminDetails.Password = passHash;
                    int res = insertAdmin.InsertAdminDetails(adminCreate.adminDetails);
                    if(res != 0)
                    {
                        int adminId = res;
                        foreach (int role in adminCreate.roles)
                        {
                            AdminUserRoleService adminUserRoleService = new AdminUserRoleService();
                            AdminUserRoleView roleView = new AdminUserRoleView { AdminUserId = adminId , AdminRoleId = role};
                            bool result = adminUserRoleService.InsertAdminUserRole(roleView);
                            if (result)
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    } 
                    else
                    {
                        AdminCreateView adminCreateRole = new AdminCreateView();
                        List<RoleView> adminDetailsRole = roleDetailService.GetRoles();
                        adminCreateRole.roles = adminDetailsRole;
                        ModelState.AddModelError(string.Empty,"Something happend");
                        return View(adminCreateRole);
                    }
                    

                }
                else
                {
                    AdminCreateView adminCreateRole = new AdminCreateView();
                    List<RoleView> adminDetailsRole = roleDetailService.GetRoles();
                    adminCreateRole.roles = adminDetailsRole;
                    return View(adminCreateRole);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(adminCreate);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            AdminEditView adminCreate = new AdminEditView();
            adminCreate.adminDetails = adminDetailsService.GetSingleAdminDetails(id);
            List<RoleView> roleDetails = roleDetailService.GetRoles();
            List<AdminEditRoleView> roleViews = adminUserRoleService.GetRoleIDByAdminId(id);
            roleViews.AddRange(roleDetails.Select(ad => new AdminEditRoleView { roles = new RoleView { Id = ad.Id,RoleName=ad.RoleName} }));
            adminCreate.roles = roleViews;
            return View("Edit", "_LayoutAdmin", adminCreate);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public string hashPassword(string pass)
        {
            var hasher = new SHA1Managed();
            var data = hasher.ComputeHash(Encoding.UTF8.GetBytes(pass));

            return BitConverter.ToString(data).Replace("-", String.Empty);

        }
        [HttpPost]
        public JsonResult CheckUsername(string user)
        {
            if(user != null)
            {
                bool isValid = adminDetailsService.CheckUserNameAvailable(user);
                return Json(isValid);
            }
            else
            {
                bool isValid = false;
                return Json(isValid);
            }
           
        }
    }
}
