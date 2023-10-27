using SOLID.DIPGoodAndBad;
var ProductService=new ProductService(new ProductRepositoryFromSqlServer());
ProductService.GetAll().ForEach(x => Console.WriteLine(x));
var ProductService2 = new ProductService(new ProductRepositoryFromOracle());
ProductService2.GetAll().ForEach(x => Console.WriteLine(x));
Console.ReadLine();