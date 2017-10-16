namespace CoffeeShop.Logic.Coffee.Abstract
{
    public abstract class Coffee : ICoffee
    {
        private string description;
        private CoffeSizeType size;

        public Coffee(string description, CoffeSizeType size)
        {
            // TODO: check for null 
            this.Description = description;
            this.Size = size;
        }

        public string FullDescription
        {
            get { return this.Size + " " + this.Description; }
        }

        public abstract string Id { get; }

        protected string Description
        {
            get { return this.description; }
            private set { this.description = value; }
        }

        protected CoffeSizeType Size
        {
            get { return this.size; }
            private set { this.size = value; }
        }

        public virtual decimal Cost()
        {
            return (int)this.Size / 100;
        }
    }
}
