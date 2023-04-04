using System.ComponentModel.DataAnnotations;

namespace Shopbridge.Data
{
  public class Items
  {
    [Key]
    public int ItemID { get; set; }

    [Required]
    public string ItemName { get; set; }

    [MaxLength(50)]
    public string ItemDescription { get; set; }

    public string ItemCategory { get; set; }

    public string ItemQuantity { get; set; }

    [Required]
    public double ItemPrice { get; set; }

    public double ItemDiscount { get; set; }

    public string CountryOfOrigin { get; set; }

    public string Brand { get; set; }
  }
}
