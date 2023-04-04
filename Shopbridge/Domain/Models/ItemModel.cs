namespace Shopbridge.Domain.Models
{
  public class ItemModel
  {
    public int ID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public string Quantity { get; set; }

    public double Price { get; set; }

    public double Discount { get; set; }

    public string CountryOfOrigin { get; set; }

    public string Brand { get; set; }

  }
}
