namespace pizza.Service
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public string Price { get; set; }

        public int quantity { get; set; }

        public BasketDto(int id, string pizzaName,string price, int quantity)
        {
            Id = id;
            PizzaName = pizzaName;
            Price = price;
            this.quantity = quantity;
        }
    }
}