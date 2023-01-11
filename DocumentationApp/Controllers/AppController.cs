using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocumentationApp.Data;
using DocumentationApp.Models;
using DocumentationApp.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SelectPdf;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DocumentationApp.Controllers
{
    public class AppController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment hostingEnv;

        private readonly ICompositeViewEngine _compositeViewEngine;

        private readonly IConfiguration config;

        private readonly UserManager<IdentityUser> userManager;

        public AppController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, ICompositeViewEngine compositeViewEngine, IConfiguration config, UserManager<IdentityUser> userManager)
        {
            this.config = config;
            _context = context;
            hostingEnv = hostEnvironment;
            _compositeViewEngine = compositeViewEngine;
            this.userManager = userManager;
        }


        [Authorize(Roles = "Super Admin, Admin, Developer")]
        public async Task<IActionResult> ShowContents(int id)
        {
            //ViewBag.CurrentUser = HttpContext.User.Identity.Name;

            ViewBag.AppList = _context.Apps.Include(x => x.Menus).ThenInclude(x => x.Contents).FirstOrDefault(x => x.AppID == id);

            var result = await _context.Menus.Where(x => x.AppID == id).ToListAsync();

            return View(result);

        }


        //[Authorize(Roles ="Admin")]
        [Authorize(Roles = "Super Admin, Admin, Developer")]


        public async Task<IActionResult> Index()
        {
            return View(await _context.Apps.ToListAsync());
        }



        public async Task<IActionResult> PublicView(int? id, int? menuId = null)
        {
            ViewBag.appId = id;
            ViewBag.menuId = menuId;
            ViewBag.currentUser = HttpContext.User.Identity.Name;


            var u = HttpContext.User.Identity.Name;

            if (u != null)
            {
                var user = userManager.FindByNameAsync(u).Result;
                var roles = userManager.GetRolesAsync(user).Result.ToArray();

                if (roles.Any())
                {
                    if (menuId == null && id == null)
                    {
                        var result = _context.Apps.ToList();
                        ViewBag.AllApps = result;


                        return View(result);
                    }
                    else if (menuId == null && id != null)
                    {
                        var result = _context.Apps.Include(x => x.Menus).ThenInclude(x => x.Contents).Include(x => x.Menus).ThenInclude(x => x.MarkAsReads).FirstOrDefault(x => x.AppID == id);
                        ViewBag.MenuLevel1 = result;

                        HttpContext.Session.SetInt32("AppID", (int)id);


                        return View(result);
                    }
                    else
                    {
                        var result = _context.Apps.Include(x => x.Menus).ThenInclude(x => x.Contents).Include(x => x.Menus).ThenInclude(x => x.MarkAsReads).FirstOrDefault(x => x.AppID == id);

                        ViewBag.SelectedMenu = menuId;
                        ViewBag.MenuLevel1 = result;

                        HttpContext.Session.SetInt32("AppID", (int)id);

                        return View(result);
                    }


                }
                else
                {
                    if (menuId == null && id == null)
                    {
                        var result = _context.Apps.ToList();
                        ViewBag.AllApps = result;
                        return View(result);
                    }
                    else if (menuId == null && id != null)
                    {
                        var result = _context.Apps.Include(x => x.Menus.Where(x => x.IsRestricted == false)).ThenInclude(x => x.Contents).Include(x => x.Menus).ThenInclude(x => x.MarkAsReads).FirstOrDefault(x => x.AppID == id);
                        ViewBag.MenuLevel1 = result;


                        HttpContext.Session.SetInt32("AppID", (int)id);

                        return View(result);
                    }
                    else
                    {
                        var result = _context.Apps.Include(x => x.Menus.Where(x => x.IsRestricted == false)).ThenInclude(x => x.Contents).Include(x => x.Menus).ThenInclude(x => x.MarkAsReads).FirstOrDefault(x => x.AppID == id);
                        ViewBag.SelectedMenu = menuId;
                        ViewBag.MenuLevel1 = result;

                        HttpContext.Session.SetInt32("AppID", (int)id);

                        return View(result);
                    }
                }



            }
            else
            {
                if (menuId == null && id == null)
                {
                    var result = _context.Apps.ToList();
                    ViewBag.AllApps = result;
                    return View(result);
                }
                else if (menuId == null && id != null)
                {
                    var result = _context.Apps.Include(x => x.Menus.Where(x => x.IsRestricted == false)).ThenInclude(x => x.Contents).Include(x => x.Menus).ThenInclude(x => x.MarkAsReads).FirstOrDefault(x => x.AppID == id);
                    ViewBag.MenuLevel1 = result;

                    HttpContext.Session.SetInt32("AppID", (int)id);

                    return View(result);
                }
                else
                {
                    var result = _context.Apps.Include(x => x.Menus.Where(x => x.IsRestricted == false)).ThenInclude(x => x.Contents).Include(x => x.Menus).ThenInclude(x => x.MarkAsReads).FirstOrDefault(x => x.AppID == id);
                    ViewBag.SelectedMenu = menuId;
                    ViewBag.MenuLevel1 = result;

                    HttpContext.Session.SetInt32("AppID", (int)id);

                    return View(result);
                }


            }


        }


        //public async Task<IActionResult> PublicView(int? id, int? menuId = null)
        //{
        //    ViewBag.appId = id;
        //    ViewBag.menuId = menuId;
        //    ViewBag.currentUser = HttpContext.User.Identity.Name;

        //    if (menuId == null && id == null)
        //    {
        //        var result = _context.Apps.ToList();
        //        ViewBag.AllApps = result;


        //        return View(result);
        //    }
        //    else if (menuId == null && id != null)
        //    {
        //        var result = _context.Apps.Include(x => x.Menus).ThenInclude(x => x.Contents).Include(x => x.Menus).ThenInclude(x => x.MarkAsReads).FirstOrDefault(x => x.AppID == id);
        //        ViewBag.MenuLevel1 = result;



        //        return View(result);
        //    }
        //    else
        //    {
        //        //var result = _context.Apps.Include(x => x.Menus).ThenInclude(x => x.Content).FirstOrDefault(x => x.AppID == id);

        //        var result = _context.Apps.Include(x => x.Menus).ThenInclude(x => x.Contents).Include(x => x.Menus).ThenInclude(x => x.MarkAsReads).FirstOrDefault(x => x.AppID == id);

        //        ViewBag.SelectedMenu = menuId;
        //        ViewBag.MenuLevel1 = result;


        //        return View(result);
        //    }

        //}

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app = await _context.Apps
                .FirstOrDefaultAsync(m => m.AppID == id);
            if (app == null)
            {
                return NotFound();
            }

            return View(app);
        }

        [Authorize(Roles = "Super Admin, Admin, Developer")]

        public async Task<IActionResult> StartDocument(int id)
        {

            ViewBag.AppId = id;
            ViewData["ParentID"] = new SelectList(_context.Menus.Where(x => x.AppID == id), "MenuID", "MenuText");

            return View(new MenuViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin, Admin, Developer")]

        public async Task<IActionResult> StartDocument(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.MenuID <= 0)
                {

                    Menu menu = new Menu();
                    menu.MenuText = model.MenuText;
                    menu.MenuTags = model.MenuTags;
                    menu.ParentID = model.ParentID;
                    menu.AppID = model.AppID;
                    menu.CreatedBy = HttpContext.User.Identity.Name;
                    menu.CreatedDate = DateTime.Now;
                    menu.IsPublished = model.MenuPublish;
                    menu.IsRestricted = model.IsRestricted;


                    _context.Add(menu);
                    await _context.SaveChangesAsync();

                    Content content = new Content();
                    content.ContentBody = model.Content;
                    content.MenuID = menu.MenuID;
                    content.VersionNo = model.VersionNo;
                    content.CreatedBy = HttpContext.User.Identity.Name;
                    content.CreatedDate = DateTime.Now;
                    content.IsPublished = model.ContentPublish;
                    content.ContentTitle = model.ContentTitle;

                    _context.Add(content);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    var menu = await _context.Menus.FindAsync(model.MenuID);

                    if (menu == null)
                    {
                        return NotFound();
                    }


                    menu.MenuText = model.MenuText;
                    menu.MenuTags = model.MenuTags;
                    menu.ParentID = model.ParentID;
                    menu.AppID = model.AppID;
                    menu.UpdatedBy = HttpContext.User.Identity.Name;
                    menu.UpdatedDate = DateTime.Now;
                    menu.IsPublished = model.MenuPublish;
                    menu.IsRestricted = model.IsRestricted;

                    _context.Update(menu);
                    await _context.SaveChangesAsync();

                    var content = await _context.Contents.FindAsync(model.ContentID);
                    if (content == null)
                    {
                        return NotFound();
                    }
                    content.ContentBody = model.Content;
                    content.MenuID = model.MenuID;
                    content.VersionNo = model.VersionNo;
                    content.UpdatedBy = HttpContext.User.Identity.Name;
                    content.UpdatedDate = DateTime.Now;
                    content.IsPublished = model.ContentPublish;
                    content.ContentTitle = model.ContentTitle;
                    _context.Update(content);
                    await _context.SaveChangesAsync();


                    return RedirectToAction(nameof(Index));


                }
            }
            return View(model);
        }

        [Authorize(Roles = "Super Admin, Admin, Developer")]

        public async Task<IActionResult> Edit(int AppId, int? id, int? version)
        {
            ViewBag.AppId = AppId;
            ViewBag.VersionNo = version;
            ViewData["ParentID"] = new SelectList(_context.Menus.Where(x => x.AppID == AppId), "MenuID", "MenuText");


            if (id == null)
            {
                return NotFound();
            }
            Menu menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            var currentUser = HttpContext.User.Identity.Name;

            if (menu.CreatedBy == currentUser || HttpContext.User.IsInRole("Super Admin"))
            {
                var content = await _context.Contents.Where(x => x.MenuID == id).FirstOrDefaultAsync(x => x.VersionNo == version);



                MenuViewModel menuVm = new MenuViewModel()
                {
                    MenuID = menu.MenuID,
                    MenuText = menu.MenuText,
                    MenuTags = menu.MenuTags,
                    ParentID = menu.ParentID,
                    IsRestricted = menu.IsRestricted,
                    AppID = menu.AppID,
                    Content = content.ContentBody,
                    ContentMenuID = content.MenuID,
                    ContentID = content.ContentID,
                    VersionNo = content.VersionNo,
                    MenuPublish = menu.IsPublished,
                    ContentPublish = content.IsPublished,
                    ContentTitle = content.ContentTitle



                };


                return View("StartDocument", menuVm);


            }


            return RedirectToAction("ErrorView");


        }


        [HttpPost]
        public JsonResult MarkAsRead(int menuId)
        {
            if (ModelState.IsValid)
            {
                var model = new MarkAsRead
                {
                    UserName = HttpContext.User.Identity.Name,
                    DateTime = DateTime.Now,
                    IsRead = true,
                    MenuID = menuId
                };


                _context.MarkAsReads.Add(model);
                _context.SaveChanges();
            }

            return Json(new { res = true });


        }



        [HttpPost]
        [Authorize(Roles = "Super Admin")]

        public JsonResult PublishApp(int appId)
        {
            var app = _context.Apps.Find(appId);
            if (app == null)
            {
                return Json(NotFound());
            }

            _context.Apps.Attach(app);
            app.IsPublished = true;
            //_context.Entry(app).State = EntityState.Modified;
            _context.SaveChanges();
            return Json(new { res = true });
        }


        [HttpPost]
        [Authorize(Roles = "Super Admin")]

        public JsonResult UnPublishApp(int appId)
        {
            var app = _context.Apps.Find(appId);
            if (app == null)
            {
                return Json(NotFound());
            }

            _context.Apps.Attach(app);

            app.IsPublished = false;
            //_context.Entry(app).State = EntityState.Modified;
            _context.SaveChanges();
            return Json(new { res = true });
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin")]

        public JsonResult PublishMenu(int menuId)
        {
            var menu = _context.Menus.Find(menuId);
            if (menu == null)
            {
                return Json(NotFound());
            }

            _context.Menus.Attach(menu);

            menu.IsPublished = true;
            //_context.Entry(menu).State = EntityState.Modified;
            _context.SaveChanges();


            return Json(new { res = true });
        }


        [HttpPost]
        [Authorize(Roles = "Super Admin")]

        public JsonResult UnPublishMenu(int menuId)
        {
            var menu = _context.Menus.Find(menuId);
            if (menu == null)
            {
                return Json(NotFound());
            }

            _context.Menus.Attach(menu);

            menu.IsPublished = false;
            //_context.Entry(menu).State = EntityState.Modified;
            _context.SaveChanges();


            return Json(new { res = true });
        }


        public async Task<IActionResult> ChangeVersion(int id, int version)
        {
            var res = _context.Contents.Where(x => x.MenuID == id).FirstOrDefault(x => x.VersionNo == version);

            var currentUser = HttpContext.User.Identity.Name;



            if (res.CreatedBy == currentUser || HttpContext.User.IsInRole("Super Admin"))
            {
                ViewBag.MenuId = id;
                ViewBag.VersionNo = version;
                return View();
            }

            return RedirectToAction("ErrorView");



        }

        [HttpPost]
        [Authorize(Roles = "Super Admin, Admin, Developer")]

        public async Task<IActionResult> ChangeVersion(Content content)
        {

            if (ModelState.IsValid)
            {
                _context.Contents.Add(content);
                await _context.SaveChangesAsync();
                return RedirectToAction("PublicView");
            }
            return View(content);
        }


        [Authorize(Roles = "Super Admin, Admin, Developer")]

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new App());

            }
            else
            {
                var app = await _context.Apps.FindAsync(id);

                if (app == null)
                {
                    return NotFound();
                }
                return View("AddOrEdit", app);

            }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Admin, Admin, Developer")]

        public async Task<IActionResult> AddOrEdit([Bind("AppID,AppName,AppTitle,IsPublished")] App app)
        {
            if (ModelState.IsValid)
            {
                if (app.AppID <= 0)
                {

                    _context.Add(app);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    try
                    {

                        _context.Update(app);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AppExists(app.AppID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(app);
        }

        //[Authorize(Roles = "Super Admin, Admin, Developer")]
        [Authorize(Roles = "Super Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var app = await _context.Apps.FindAsync(id);
            if (app == null)
            {
                return NotFound();

            }
            _context.Apps.Remove(app);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Super Admin, Admin, Developer")]

        public async Task<IActionResult> DeleteMenu(int id)
        {



            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();

            }

            var currentUser = HttpContext.User.Identity.Name;



            if (menu.CreatedBy == currentUser || HttpContext.User.IsInRole("Super Admin"))
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            return RedirectToAction("ErrorView");


        }

        public JsonResult Search(string searchTest)
        {

            var appid = HttpContext.Session.GetInt32("AppID");

            var query = $"prcSearchContent";

            var list = new List<SearchVM>();



            using (SqlConnection conn = new SqlConnection(config.GetConnectionString("DefaultConnection")))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@appid", appid);
                cmd.Parameters.AddWithValue("@freetext", searchTest);

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    //var Menu = reader.FieldCount;
                    while (reader.Read())
                    {
                        var model = new SearchVM
                        {
                            AppID = Convert.ToInt32(reader["AppID"].ToString()),
                            MenuID = Convert.ToInt32(reader["MenuID"].ToString()),
                            ContentID = Convert.ToInt32(reader["ContentID"].ToString()),
                            ContentTitle = reader["ContentTitle"].ToString(),
                            ContentBody = reader["ContentBody"].ToString(),
                            MenuText = reader["MenuText"].ToString()
                        };

                        list.Add(model);

                    }

                }

                conn.Close();
            }



            //var contents = from c in _context.Contents
            //               join m in _context.Menus 
            //               on c.MenuID equals m.MenuID
            //               join a in _context.Apps
            //               on m.AppID equals a.AppID
            //              where EF.Functions.FreeText(c.ContentBody, searchTest) where a.AppID== appid
            //               select new { c.ContentID, c.MenuID, c.ContentBody, m.MenuText, a.AppID};



            //string value = string.Empty;
            //value = JsonConvert.SerializeObject(contents, Formatting.Indented, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});

            return Json(list, new Newtonsoft.Json.JsonSerializerSettings());
        }




        public IActionResult ErrorView()
        {
            return View();
        }


        public async Task<IActionResult> Content(int contentId)
        {

            var content = await _context.Contents
                .FirstOrDefaultAsync(m => m.ContentID == contentId);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }


        [HttpPost]
        public JsonResult SearchByUser(string searchedWord)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User.Identity.Name;
                if (user == null)
                {
                    return Json(new { res = false });
                }
                else
                {
                    var model = new SearchByUser
                    {
                        UserName = user,
                        SearchedTime = DateTime.Now,
                        SearchedWord = searchedWord
                    };
                    _context.SearchByUsers.Add(model);
                    _context.SaveChanges();
                }


            }

            return Json(new { res = true });


        }



        private bool AppExists(int id)
        {
            return _context.Apps.Any(e => e.AppID == id);
        }



    }
}



//public async Task<IActionResult> SinglePdfView(int menuId)
//{
//    var result = _context.Contents.Where(x=>x.MenuID==menuId).ToList();
//    return View(result);
//}

//[Route("singlePdf/{id}")]
//public async Task<IActionResult> SinglePdfAsync(int id)
//{


//    var fullView = new HtmlToPdf();
//    //fullView.Options.WebPageWidth = 1920;


//    fullView.Options.PdfPageSize = PdfPageSize.A4;
//    fullView.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

//    fullView.Options.WebPageWidth = 1024;
//    fullView.Options.WebPageHeight = 0;
//    fullView.Options.MarginLeft = 10;
//    fullView.Options.MarginRight = 10;
//    fullView.Options.MarginTop = 20;
//    fullView.Options.MarginBottom = 20;


//    fullView.Options.AutoFitWidth = HtmlToPdfPageFitMode.ShrinkOnly;
//    fullView.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;

//    var pdf = fullView.ConvertUrl(config.GetSection("SinglePdfUrl").Value + id);



//    var pdfBytes = pdf.Save();

//    using (var streamWriter = new StreamWriter(@"RoundTheCode.pdf"))
//    {
//        await streamWriter.BaseStream.WriteAsync(pdfBytes, 0, pdfBytes.Length);
//    }

//    return File(pdfBytes, "application/pdf");

//}



//[Route("website/{id}")]
//public async Task<IActionResult> WebsiteAsync(int id)
//{


//    var fullView = new HtmlToPdf();
//    //fullView.Options.WebPageWidth = 1920;


//    fullView.Options.PdfPageSize = PdfPageSize.A4;
//    fullView.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

//    fullView.Options.WebPageFixedSize = false;

//    fullView.Options.WebPageWidth = 1024;
//    fullView.Options.WebPageHeight = 0;
//    fullView.Options.MarginLeft = 10;
//    fullView.Options.MarginRight = 10;
//    fullView.Options.MarginTop = 20;
//    fullView.Options.MarginBottom = 20;



//    fullView.Options.AutoFitWidth = HtmlToPdfPageFitMode.ShrinkOnly;
//    fullView.Options.AutoFitHeight = HtmlToPdfPageFitMode.NoAdjustment;





//    var pdf = fullView.ConvertUrl(config.GetSection("ConvertUrl").Value + id);



//    var pdfBytes = pdf.Save();

//    using (var streamWriter = new StreamWriter(@"RoundTheCode.pdf"))
//    {
//        await streamWriter.BaseStream.WriteAsync(pdfBytes, 0, pdfBytes.Length);
//    }

//    return File(pdfBytes, "application/pdf");

//}




//public async Task<IActionResult> PdfView(int id)
//{
//    var result = _context.Apps.Include(x => x.Menus).ThenInclude(x => x.Contents).FirstOrDefault(x => x.AppID == id);
//    ViewBag.MenuLevel1 = result;


//    return View(result);            
//}