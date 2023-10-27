using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SOLID.ISPGoodAndBad
{
    //1.Class Library Read Imp
    //Class Library Create/Update/Delete Imp
    public class ReadProductRepository : IReadRepository
    {
        public Product GetByID(int ID)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetList()
        {
            throw new NotImplementedException();
        }
    }
    public class WriteProductRepository : IWriteRepository
    {
        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }
        public Product Delete(Product product)
        {
            throw new NotImplementedException();
        }
        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
    public interface IReadRepository
    {
        List<Product> GetList();
        Product GetByID(int ID);
    }
    public interface IWriteRepository
    {
        Product Create(Product product);
        Product Update(Product product);
        Product Delete(Product product);
    }
}