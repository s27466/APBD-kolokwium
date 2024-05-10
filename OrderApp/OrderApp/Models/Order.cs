namespace OrderApp.Models;

public class Order
{
    public int IdOrder { get; set; }
    public string Name { get; set; }
    public string Description  { get; set; }
    public DateTime date  { get; set; }
    public int IdClient  { get; set; }
}