namespace OrderApp.Models;

public class Order
{
    public int IdOrder { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public int IdClient { get; set; }
    public List<Product> Products { get; set; } // Lista produktów w zamówieniu
}
