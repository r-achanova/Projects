using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
  public  class ProductBusiness
    {
        private ProductContext productContext;
        public string GetAll()
        {
            using (productContext = new ProductContext())
            {
                var products = productContext.Products
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        category = p.Category.Name,
                    }).ToList();
                var sb = new StringBuilder();
                foreach (var item in products)
                {
                    sb.AppendLine($"{ item.Name} { item.Price}  {item.category }");
                }
                return sb.ToString().Trim();
            }
        }
        public Product GetProduct(int id)
        {
            using (productContext = new ProductContext())
            { return productContext.Products.Find(id); }
        }

        public Category GetCategory(int id)
        {
            using (productContext = new ProductContext())
            { return productContext.Categories.Find(id); }
        }
        public void AddProduct(Product product, Category category)
        {
            using (productContext = new ProductContext())
            {

                var categorySearch = productContext.Categories.FirstOrDefault(c => c.Name == category.Name);
                if (categorySearch == null)
                {
                    productContext.Categories.Add(category); //добавяме категорията
                    productContext.SaveChanges();
                    product.CategoryId = category.Id;
                    productContext.Products.Add(product);//добавяме продукта
                    productContext.SaveChanges();
                }
                else
                {
                    product.CategoryId = categorySearch.Id; //записваме id на категорията в продукта
                    productContext.Products.Add(product);//добавяме продукта
                    productContext.SaveChanges();
                }
            }
        }

        public void UpdateProduct(Product product, Category category)
        {
            using (productContext = new ProductContext())
            {
                var item = productContext.Products.Find(product.Id);
                var categorySearched = productContext.Categories.FirstOrDefault(c => c.Name == category.Name);
                if (item != null)
                {
                    var categorySearch = productContext.Categories.FirstOrDefault(c => c.Name == category.Name);
                    if (categorySearch == null)
                    {
                        productContext.Categories.Add(category); //добавяме категорията
                        productContext.SaveChanges();
                        product.CategoryId = category.Id;
                    }
                    else
                    {
                        product.CategoryId = categorySearch.Id; //записваме id на категорията в продукта

                    }
                    productContext.Entry(item).CurrentValues.SetValues(product);
                    productContext.SaveChanges();
                }
            }
        }

        public void UpdateStock(int storeId,int productId, int count)
        {
            using (productContext = new ProductContext())
            {
                var store = productContext.Stores.Find(storeId);
                var product = productContext.Products.Find(productId);
                if (store != null&& product!=null)
                {
                    var searchedItem = productContext.ProductsStores.FirstOrDefault(x => x.ProductId == productId && x.StoreId == storeId);
                    if (searchedItem==null)
                    {
                    ProductStore item = new ProductStore();
                    item.ProductId = productId;
                    item.StoreId = storeId;
                    item.Stock = count;
                    productContext.ProductsStores.Add(item);
                    productContext.SaveChanges();
                    }
                    else
                    {
                        searchedItem.Stock = count;
                        productContext.SaveChanges();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Error");
                }
             }
        }
        
        public void Delete(int id)
        {
            using (productContext = new ProductContext())
            {
                var product = productContext.Products.Find(id);
                if (product != null)
                {
                    productContext.Products.Remove(product);
                    productContext.SaveChanges();
                }
            }
        }

        public void AddStore(Store store)
        {
            using (productContext=new ProductContext())
            {
                productContext.Stores.Add(store);
                productContext.SaveChanges();
            }
        }
    }
}
