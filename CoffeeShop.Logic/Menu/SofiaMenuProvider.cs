namespace CoffeeShop.Logic.Menu
{
    using System.Collections.Generic;
    using Abstract;

    public class SofiaMenuProvider : MenuProvider
    {
        public override ICollection<string> GetCoffeeTypes()
        {
            var commonTypes = base.GetCoffeeTypes();
            var specialTypes = base.GetCoffeeTypes("CoffeeShop.Logic.Coffee.CoffeeTypes.SofiaStoreSpecialTypes");

            foreach (var type in specialTypes)
            {
                commonTypes.Add(type);
            }

            return commonTypes;
        }
    }
}
