namespace InheritancePolymorphism.Entities
{
    public class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }
        
        public ImportedProduct()
        {            
        }

        public ImportedProduct(string name, double price, double customsFee) : base(name, price)
        {
            CustomsFee = customsFee;
        }

        public double totalPrice()
        {
            return Price + CustomsFee;
        }

        public override string PriceTag()
        {
            return $"{Name} ${totalPrice()} (Customs fee: ${CustomsFee})";  
        }
    }
}