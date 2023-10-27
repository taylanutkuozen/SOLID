using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SOLID.SRP.Bad
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        /*Yukarıdaki property bileşenlerini de kendi içerisinde tutuyor ve bunlarda bir  sorumluluk belirtiyor - 3.Sorumluluk*/
        private static List<Product> ProductList = new List<Product>();/*static yaparak class instance üzerinden erişilmez ve uygulama ayağa kalktığı an List memory'ye yüklenir. */ //List tutulduğu için burada bir Repo sorumluluğu var.
        public List<Product> GetProducts => ProductList;//Buradaki lambda gizli bir get isteğini temsil eder.
        /*
         public List<Product> GetProducts{ get {return ProductList;} }
         */
        public Product()
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
        public void SaveOrUpdate(Product product)//2.Sorumluluk - List üzerinde CRUD işlemleri yapılıyor
        {
            var hasProduct=ProductList.Any(p=>p.ProductID==product.ProductID);//Any metodu ile products List içerisinde olup olmadığı kontrol ediliyor.
            if(!hasProduct)
            {
                ProductList.Add(product);
            }
            else
            {
                var index=ProductList.FindIndex(x=>x.ProductID==product.ProductID);//FindIndex ile index'ini buluyoruz.
                ProductList[index] = product;
            }
        }
        public void Delete(int id)//2.Sorumluluk
        {
            var hasProduct=ProductList.Find(x=>x.ProductID==id);
            if (hasProduct == null)
            {
                throw new Exception("Ürün bulunamadı");
            }
            ProductList.Remove(hasProduct);
        }
        public void WriteToConsole()//1.Sorumluluk
        {
            ProductList.ForEach(x =>
            {
                Console.WriteLine($"{x.ProductID} - {x.ProductName}");
            });//ProductList.ForEach List içerisini dolaş anlamındadır.
        }
    }
}