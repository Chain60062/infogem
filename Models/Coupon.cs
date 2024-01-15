using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public class Coupon
{
    [Key]
    public string Code { get; set; }
    public short DiscountPercentage { get; set; }
    public decimal? MinimumOrderValue { get; set; }
    public bool IsCouponValid { get; set; }
    public DateTime DiscountStartsAt { get; set; }
    public DateTime DiscountEndsAt { get; set; }

}
