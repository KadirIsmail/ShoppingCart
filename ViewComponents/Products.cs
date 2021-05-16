using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.ViewComponents
{
    public class Products:ViewComponent
    {
        public readonly ShoppingCartDBContext db;
        public Products(ShoppingCartDBContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke(string categoryName) //Invoke olmak zorunda !
        {
            if (categoryName != null)
            {
                categoryName = categoryName.Replace("-", " ");
                var categoryR = db.CategoryTbls.Where(y => y.Name == categoryName).FirstOrDefault();
                if (categoryR != null)
                {
                    var categoryId = categoryR.Id;
                    return View(db.ProductTbls.Where(x => x.CategoryId == categoryId).ToList());
                }
            }
            return View(db.ProductTbls.ToList());
        }
    }
}
