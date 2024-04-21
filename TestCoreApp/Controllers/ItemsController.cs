using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Date;
using TestCoreApp.Migrations;
using TestCoreApp.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TestCoreApp.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {

        public ItemsController(AppDbContext db ,IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }

        private readonly IHostingEnvironment _host;

        private readonly AppDbContext _db;


        public IActionResult Index()
        {
            IEnumerable<Item> itemsList = _db.Items.Include(d => d.Category).ToList();

            return View(itemsList);
        }

        public IActionResult New()
        {
            Createselectlist();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if(item.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't 100");
            }
            if (ModelState.IsValid) 
            {
                string fileName = string.Empty;
                if(item.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = item.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.imagePath = fileName;
                }

                _db.Add(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        public void Createselectlist(int selectId = 1)
        {
            //List<Category> categories = new List<Category>
            //{
            //    new Category() {Id = 0, Name = "Select Category" },
            //    new Category() {Id = 1, Name = "Computers"},
            //    new Category() {Id = 2, Name = "Mobiles"},
            //    new Category() {Id = 3, Name = "Electric Machines"},
            //};

            List<Category> categories = _db.categories.ToList();

            SelectList ListItems = new SelectList(categories, "Id", "Name", selectId);
            ViewBag.categoryList = ListItems;
        }

        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id ==0 )
            {
                return NotFound();
            }
            var item = _db.Items.FirstOrDefault(x => x.Id == Id);

            Createselectlist(item.categoryId);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item, IFormFile newImage)
        {
            if (ModelState.IsValid)
            {
                if (newImage != null && newImage.Length > 0)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    string fileName = Path.GetFileName(newImage.FileName);
                    string fullPath = Path.Combine(myUpload, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        newImage.CopyTo(stream);
                    }
                    item.imagePath = fileName;
                }

                _db.Update(item);
                _db.SaveChanges();
                TempData["EditData"] = "Item has been edited successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }


        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.FirstOrDefault(x => x.Id == Id);

            Createselectlist(item.categoryId);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? Id)
        {
            var item = _db.Items.Find(Id);
            if(item == null)
            {
                return NotFound();
            }


            _db.Remove(item);
            _db.SaveChanges();
            TempData["DeleteDate"] = "Item has been Remove successfully";
            return RedirectToAction("Index");
        }

    }
}
