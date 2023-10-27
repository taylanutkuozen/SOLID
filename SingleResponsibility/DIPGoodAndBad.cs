using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SOLID.DIPGoodAndBad
{
public class ProductService
    {
        private readonly IRepository _repository;//Bu interface kimi implement ettiği bilmediği için Dependency Inversion Principle uyuyor. Low level modüllerde istenilen her değişiklik yapılabilir. Interface implement eden herhangi bir class'ı verebiliriz.
        public ProductService(IRepository repository)
        {
            _repository = repository;
        }
        public List<string> GetAll()
        {
            return _repository.GetAll();
        }
    }
public class ProductRepositoryFromSqlServer : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() {"SqlServer Kalem 1", "SqlServer Kalem 2" };
        }
    }
    public class ProductRepositoryFromOracle : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "Oracle Kalem 1", "Oracle Kalem 2" };
        }
    }
    public interface IRepository
    {
        List<string> GetAll();
    }
}
/*Sürdürülebilir kodlar olması için akış hep iki yönlü olmalıdır. yukarıdan-aşağıya(interface veya abstract class ile) + aşağıdan yukarıya*/
/*Abstraction--> new() işlemi kullanılamayan: interface ve abstract class new()'lenemez-daha çok interface*/
/*Abstract class-->base class'larda ortak objeleri tanımlama tarafında daha çok kullanırız.*/