using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace Crud_opreation.Models
{
    public class ProductRepository
    {
        public int AddProduct(Product product)
        {
            using(var context=new Repository())
            {
                Product pro = new Product()
                {
                    ProductName = product.ProductName,
                    CategoryId = product.CategoryId,
                 };
                if (product.Category != null)
                {
                    pro.Category = new Category();
                    {            
                        pro.Category.CategoryName = product.Category.CategoryName;
                    };
                }
                context.Products.Add(pro);
                context.SaveChanges();
                return pro.ProductId;
            }
        }
        public  List<Product> GetProducts()
        {
            using (var context = new Repository())
            {
                var result = context.Products.ToList();
                    {
                       context.categories.ToList();
                    };
                
                return result;
            }
          
        }
        public Product GetDetails(int id)
        {
            using (var context = new Repository())
            {

                var result = context.Products.Where(x => x.ProductId == id).Include(x => x.Category).FirstOrDefault();
                
                return result;

               
            }

        }
        public bool UpdateProduct(int id,Product product) 
        {
            using (var context = new Repository())
            {
                var result = context.Products.Where(x => x.ProductId == id).Include(x => x.Category).FirstOrDefault();
                if (result!=null)
                {
                
                    result.ProductName = product.ProductName;
                    result.CategoryId= product.CategoryId;
                    result.Category.CategoryName= product.Category.CategoryName;
                   
                }
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteProduct(int id)
        {
            using (var context = new Repository())
            {
                var result = context.Products.FirstOrDefault(x => x.ProductId == id);
                {
                    if (result != null)
                    {
                        context.Products.Remove(result);
                        context.SaveChanges();
                        return true;
                    }
                    return false;

                }
            }
        }

    }
}