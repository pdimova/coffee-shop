namespace CoffeeShop.Logic.Menu
{
    using System.Collections.Generic;
    using Abstract;

    public class PlovdivMenuProvider : MenuProvider
    {
        public override ICollection<string> GetCoffeeTypes()
        {
            var commonTypes = base.GetCoffeeTypes();
            var specialTypes = base.GetCoffeeTypes("CoffeeShop.Logic.Coffee.CoffeeTypes.PlovdivStoreSpecialTypes");

            foreach (var type in specialTypes)
            {
                commonTypes.Add(type);
            }

            return commonTypes;
        }
    }
}
