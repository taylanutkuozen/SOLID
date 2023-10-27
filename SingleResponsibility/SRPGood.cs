using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SOLID.SRP.Good
{
    public class Product //Sadece propertyleri tutan bir class
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
    public class ProductRepository //ProductList tutan bir data
    {
        public ProductRepository()
        {
            ProductList = new()
            {
                new(){ProductID=1,ProductName="Kalem 1"},
                new(){ProductID=2,ProductName="Kalem 2"},
                new(){ProductID=3,ProductName="Kalem 3"},
                new(){ProductID=4,ProductName="Kalem 4"},
                new(){ProductID=5,ProductName="Kalem 5"}
            };
        }
        private static List<Product> ProductList = new List<Product>();/*static yaparak class instance üzerinden erişilmez ve uygulama ayağa kalktığı an List memory'ye yüklenir. */
        public List<Product> GetProducts => ProductList;
        public void SaveOrUpdate(Product product)
        {
            var hasProduct = ProductList.Any(p => p.ProductID == product.ProductID);//Any metodu ile products List içerisinde olup olmadığı kontrol ediliyor.
            if (!hasProduct)
            {
                ProductList.Add(product);
            }
            else
            {
                var index = ProductList.FindIndex(x => x.ProductID == product.ProductID);//FindIndex ile index'ini buluyoruz.
                ProductList[index] = product;
            }
        }
        public void Delete(int id)
        {
            var hasProduct = ProductList.Find(x => x.ProductID == id);
            if (hasProduct == null)
            {
                throw new Exception("Ürün bulunamadı");
            }
            ProductList.Remove(hasProduct);
        }
    }
    public class ProductPresenter // Product sunan bir class
    {
        public void WriteToConsole(List<Product> ProductList)
        {
            ProductList.ForEach(x =>
            {
                Console.WriteLine($"{x.ProductID} - {x.ProductName}");
            });//ProductList.ForEach List içerisini dolaş anlamındadır.
        }
    }
}