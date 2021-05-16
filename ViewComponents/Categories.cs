using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.ViewComponents
{
    public class Categories : ViewComponent
    {
        //Constructer
        private readonly ShoppingCartDBContext db;

        public Categories(ShoppingCartDBContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke() //Invoke olmak zorunda !
        {
            return View(db.CategoryTbls.ToList());
        }
    }
}
