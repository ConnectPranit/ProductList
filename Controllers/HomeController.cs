using Crud_opreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace Crud_opreation.Controllers
{
    public class HomeController : Controller
    { 

       private ProductRepository _repository = new ProductRepository();

        public ActionResult Index(int? i)
        {
           var result= _repository.GetProducts();
            return View(result.ToPagedList(i ?? 1,5));
        }

        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _repository.AddProduct(product);
                return RedirectToAction("Index");
            }
          
            return View();
        }
        public ActionResult Details(int id)
        {
            var result = _repository.GetDetails(id);
            return View(result);
        }
        public ActionResult Edit(int id)
        {
            var product = _repository.GetDetails(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                _repository.UpdateProduct(product.ProductId, product);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}