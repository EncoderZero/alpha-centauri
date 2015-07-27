using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using binbash.Models;
using System.IO;

namespace binbash.Controllers {
    public class ProductsController : Controller {
        private BinBashModels db = new BinBashModels();

        private const string PRODUCT_IMAGE_FOLDER_PATH = "/Content/Images/Products/";

        // GET: Products
        public ActionResult Index() {
            var categories = db.Categories.Include(p => p.Products);
            return View(categories.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if(product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create() {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,CategoryId")] Product product) {
            if(ModelState.IsValid) {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if(product == null) {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,CategoryId,ImageURL")] Product product) {
            if(ModelState.IsValid) {

                Product dbProduct = db.Products.Find(product.Id);
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
                dbProduct.Price = product.Price;
                dbProduct.CategoryId = product.CategoryId;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if(product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/UploadImage/5
        [HttpPost]
        public ActionResult UploadImage(int? id, HttpPostedFileBase ProductImage) {

            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } else if(ProductImage == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if(product == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string extension = Path.GetExtension(ProductImage.FileName);
            string filename = id.ToString() + extension;
            string fileURL = Path.Combine(PRODUCT_IMAGE_FOLDER_PATH, filename);
            string filePath = Path.Combine(Server.MapPath("~" + PRODUCT_IMAGE_FOLDER_PATH), filename);

            ProductImage.SaveAs(filePath);
            product.ImageURL = fileURL;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
