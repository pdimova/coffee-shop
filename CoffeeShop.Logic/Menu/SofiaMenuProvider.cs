namespace CoffeeShop.Logic.Menu
{
    using System.Collections.Generic;
    using Abstract;
    using System.Reflection;
    using System;

    public class SofiaMenuProvider : MenuProvider
    {
        //private const string sofiaStoreSpecialTypesNamespace = "CoffeeShop.Logic.Coffee.CoffeeTypes.SofiaStoreSpecialTypes";
        private readonly string specificCoffeeTypesNamespace;

        public SofiaMenuProvider(
            AssemblyName assemblyFullName,
            string commonCoffeeTypesNamespace,
            string specificCoffeeTypesNamespace) : base(assemblyFullName, commonCoffeeTypesNamespace)
        {
            if (specificCoffeeTypesNamespace == null)
            {
                throw new ArgumentNullException();
            }
            this.specificCoffeeTypesNamespace = specificCoffeeTypesNamespace;
        }

        public override ICollection<string> GetCoffeeTypes()
        {
            var commonTypes = base.GetCoffeeTypes();
            var specialTypes = base.GetCoffeeTypes(specificCoffeeTypesNamespace);

            foreach (var type in specialTypes)
            {
                commonTypes.Add(type);
            }

            return commonTypes;
        }
    }
}