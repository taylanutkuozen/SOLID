﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SOLID.OCP.Good2
{

    public class LowSalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 2;
        }
    }
    public class MiddleSalaryCalculate 
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 4;
        }
    }
    public class HighSalaryCalculate 
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 6;
        }
    }
    public class ManagerSalaryCalculate 
    {
        public decimal Calculate(decimal salary)
        {
            return (salary * 7);
        }
    }

    public class SalaryCalculator
    {
        //Action parametre alabilen/almayan void metotlar
        //Predicate parametre alan geriye boolean dönen
        //Func delegate herhangi bir parametre alan geriye herhangi bir type dönen
        public decimal Calculate(decimal salary, Func<decimal,decimal> calculateDelegate)
        {
         return calculateDelegate(salary);
        }
    }
}
/*Delegateler metotları işaret eden yapılardır.*/