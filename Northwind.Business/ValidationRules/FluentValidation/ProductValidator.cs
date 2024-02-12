using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        // fluent validation 
        public ProductValidator()
        {
            RuleFor(p=> p.ProductName).NotEmpty().WithMessage("Input the product name!");
            RuleFor(p=> p.CategoryID).NotEmpty();
            RuleFor(p=> p.UnitPrice).NotEmpty();
            RuleFor(p=> p.QuantityPerUnit).NotEmpty();
            RuleFor(p=> p.UnitsInStock).NotEmpty();

            RuleFor(p=> p.UnitPrice).GreaterThan(0);
            RuleFor(p=> p.UnitsInStock).GreaterThanOrEqualTo((short)0);
            RuleFor(p=> p.UnitPrice).GreaterThan(10).When(p=>p.CategoryID == 2);

            RuleFor(p => p.ProductName).Must(DontStartWithJ).WithMessage("The Product name Don't strart with 'J'");
        }
        private bool DontStartWithJ(string arg)
        {
            if(arg.StartsWith("j"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
