using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SOLID.OCP.Bad
{
    public class SalaryCalculator
    {
        public decimal Calculate(decimal salary, SalaryType salaryType)
        {
            decimal newSalary = 0;
            switch(salaryType)
            {
                case SalaryType.Low:
                    newSalary = salary * 2;
                    break;
                case SalaryType.Middle:
                    newSalary = salary * 4;
                    break;
                case SalaryType.High:
                    newSalary = salary * 6;
                    break;
                default:
                    break;
            }
            return newSalary;
        }
    }
    public enum SalaryType
    {
        Low,
        Middle,
        High
    }
}
/*Diyelim ki enum içerisine Low-Middle ve Middle-High adında iki tanım daha yapıyoruz. Bu sefer SalaryCalculator class'ındaki Calculator metodunun içindeki switch te değişiklik yapacağız (hesaplamalarda değişebilir) ve open-closed principle aykırı davranış olacak çünkü var olan yapıyı değiştiremeyiz.Yeni değişiklikler dışarıdan implement edilmeli veya implement ederken yeni classlar,metotlar oluşturabiliriz ama var olan yapıyı bozulmayacak.*/