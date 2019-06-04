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
            if (Session["username"] != null)
            {
                List<RoleView> adminDetails = roleDetailService.GetRoles();
                adminCreate.roles = adminDetails;
                return View("Create", "_LayoutAdmin", adminCreate);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult RenderRole()
        {
            List<RoleView> adminDetails = roleDetailService.GetRoles();
            return PartialView(adminDetails);
        }
        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminCreateRequestView adminCreate)
        {
            if (Session["username"] != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        AdminDetailsService insertAdmin = new AdminDetailsService();
                        var passHash = Encrypt(adminCreate.adminDetails.Password, "sblw-3hn8-sqoy19");
                        adminCreate.adminDetails.Password = passHash;
                        int res = insertAdmin.InsertAdminDetails(adminCreate.adminDetails);
                        if (res != 0)
                        {
                            int adminId = res;
                            foreach (int role in adminCreate.roles)
                            {
                                AdminUserRoleService adminUserRoleService = new AdminUserRoleService();
                                AdminUserRoleView roleView = new AdminUserRoleView { AdminUserId = adminId, AdminRoleId = role };
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
                            ModelState.AddModelError(string.Empty, "Something happend");
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            AdminEditView adminCreate = new AdminEditView();
            if (Session["username"] != null)
            {
                List<AdminEditRoleView> roleViewss = new List<AdminEditRoleView>();
                adminCreate.adminDetails = adminDetailsService.GetSingleAdminDetails(id);
                List<RoleView> roleDetails = roleDetailService.GetAllRoleByStatus();
                List<AdminUserRoleView> roleViews = adminUserRoleService.GetRoleIDByAdminId(id);
                roleViewss.AddRange(roleDetails.Select(ad => new AdminEditRoleView { roles = new RoleView { Id = ad.Id, RoleName = ad.RoleName } }));
                adminCreate.roles = roleViewss;
                adminCreate.adminRoles = roleViews;
                return View("Edit", "_LayoutAdmin", adminCreate);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminCreateRequestView adminCreate)
        {
            AdminEditView adminCreateEdit = new AdminEditView();
            if (Session["username"] != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        AdminDetailsService insertAdmin = new AdminDetailsService();
                        //var passHash = hashPassword(adminCreate.adminDetails.Password);
                        //adminCreate.adminDetails.Password = passHash;
                        int res = insertAdmin.InsertAdminDetails(adminCreate.adminDetails);
                        if (res != 0)
                        {
                            int adminId = res;
                            bool deleteAlreadyRoles = adminUserRoleService.DeleteRoleByAdmin(adminId);
                            foreach (int role in adminCreate.roles)
                            {
                                AdminUserRoleService adminUserRoleService = new AdminUserRoleService();
                                AdminUserRoleView roleView = new AdminUserRoleView { AdminUserId = adminId, AdminRoleId = role };
                                bool result = adminUserRoleService.UpdateUserRoleByAdminId(roleView);
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
                            List<AdminEditRoleView> roleViewss = new List<AdminEditRoleView>();
                            adminCreateEdit.adminDetails = adminDetailsService.GetSingleAdminDetails(adminCreate.adminDetails.Id);
                            List<RoleView> roleDetails = roleDetailService.GetAllRoleByStatus();
                            List<AdminUserRoleView> roleViews = adminUserRoleService.GetRoleIDByAdminId(adminCreate.adminDetails.Id);
                            roleViewss.AddRange(roleDetails.Select(ad => new AdminEditRoleView { roles = new RoleView { Id = ad.Id, RoleName = ad.RoleName } }));
                            adminCreateEdit.roles = roleViewss;
                            adminCreateEdit.adminRoles = roleViews;
                            ModelState.AddModelError(string.Empty, "Something happend");
                            return View("Edit", "_LayoutAdmin", adminCreate);
                        }


                    }
                    else
                    {
                        List<AdminEditRoleView> roleViewss = new List<AdminEditRoleView>();
                        adminCreateEdit.adminDetails = adminDetailsService.GetSingleAdminDetails(adminCreate.adminDetails.Id);
                        List<RoleView> roleDetails = roleDetailService.GetAllRoleByStatus();
                        List<AdminUserRoleView> roleViews = adminUserRoleService.GetRoleIDByAdminId(adminCreate.adminDetails.Id);
                        roleViewss.AddRange(roleDetails.Select(ad => new AdminEditRoleView { roles = new RoleView { Id = ad.Id, RoleName = ad.RoleName } }));
                        adminCreateEdit.roles = roleViewss;
                        adminCreateEdit.adminRoles = roleViews;
                        ModelState.AddModelError(string.Empty, "Something happend");
                        return View("Edit", "_LayoutAdmin", adminCreate);
                    }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(adminCreate);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            bool result = adminDetailsService.DeleteAdminById(id);
            if (result)
            {
                bool resRole = adminUserRoleService.DeleteRoleByAdmin(id);
                if (resRole)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {

            }
            return RedirectToAction("Index");
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
        //public string hashPassword(string pass)
        //{
        //    var hasher = new SHA1Managed();
        //    var data = hasher.ComputeHash(Encoding.UTF8.GetBytes(pass));

        //    return BitConverter.ToString(data).Replace("-", String.Empty);

        //}

        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
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
