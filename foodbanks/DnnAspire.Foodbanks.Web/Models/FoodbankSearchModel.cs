namespace DnnAspire.Foodbanks.Web.Models;

public class FoodbankSearchModel
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Postcode { get; set; }
    public int? Distance { get; set; }
    public string FormattedDistance { get; set; }
}
