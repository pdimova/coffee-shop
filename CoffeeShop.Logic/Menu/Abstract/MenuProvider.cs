namespace CoffeeShop.Logic.Menu.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Coffee;

    public abstract class MenuProvider : IMenuProvider
    {
        private readonly AssemblyName assemblyFullName;
        private readonly string commonCoffeeTypesNamespace;
        private readonly string condimentsNamespace;


        public MenuProvider(
            AssemblyName assemblyFullName,
            string commonCoffeeTypesNamespace,
            string condimentsNamespace)
        {
            if (assemblyFullName == null)
            {
                throw new ArgumentNullException();
            }

            if (commonCoffeeTypesNamespace == null)
            {
                throw new ArgumentNullException();
            }

            if (condimentsNamespace == null)
            {
                throw new ArgumentNullException();
            }

            this.assemblyFullName = assemblyFullName;
            this.commonCoffeeTypesNamespace = commonCoffeeTypesNamespace;
            this.condimentsNamespace = condimentsNamespace;
        }

        public virtual ICollection<string> GetCoffeeTypes()
        {
            return this.GetNames(commonCoffeeTypesNamespace).ToList();
        }

        protected IEnumerable<string> GetCoffeeTypes(string fullNamespace)
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
            return this.GetNames(condimentsNamespace);
        }

        private IEnumerable<string> GetNames(string fullNamespace)
        {
            return
               Assembly
               .Load(this.assemblyFullName)
               .GetTypes()
               .Where(t => t.IsClass && t.Namespace == @fullNamespace)
               .Select(t => t.Name);
        }
    }
}