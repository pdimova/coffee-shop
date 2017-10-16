namespace CoffeeShop.Logic.Menu
{
    using System.Collections.Generic;
    using Abstract;
    using System.Reflection;
    using System;

    public class PlovdivMenuProvider : MenuProvider
    {
        private readonly string specificCoffeeTypesNamespace;

        public PlovdivMenuProvider(
            AssemblyName assemblyFullName,
            string commonCoffeeTypesNamespace,
            string specificCoffeeTypesNamespace,
            string condimentsNamespace) : base(assemblyFullName, commonCoffeeTypesNamespace, condimentsNamespace)
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
