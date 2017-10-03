namespace CoffeeShop.Logic.Menu.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Coffee;

    public abstract class MenuProvider : IMenuProvider
    {
        public virtual ICollection<string> GetCoffeeTypes()
        {
            return this.GetNames("CoffeeShop.Logic.Coffee.CoffeeTypes").ToList();
        }

        public IEnumerable<string> GetCoffeeTypes(string fullNamespace)
        {
            return this.GetNames(fullNamespace);
        }

        public IEnumerable<string> GetCoffeeSizes()
        {
            return
                 Enum.GetValues(typeof(CoffeSizeType))
                .Cast<CoffeSizeType>()
                .Select(v => v.ToString())
                .ToList();
        }

        public IEnumerable<string> GetCoffeeCondiments()
        {
            return this.GetNames("CoffeeShop.Logic.Coffee.Condiments");
        }

        private IEnumerable<string> GetNames(string fullNamespace)
        {
            return
               Assembly
               .GetExecutingAssembly()
               .GetTypes()
               .Where(t => t.IsClass && t.Namespace == @fullNamespace)
               .Select(t => t.Name);
        }
    }
}
