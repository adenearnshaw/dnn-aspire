using System.Text.Json.Serialization;

namespace DnnAspire.Foodbanks.Web.Models;

public record FoodbankModel
{
    public string Name { get; set; }

    public string Slug { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Postcode { get; set; }

    [JsonPropertyName("lat_lng")]
    public string Coordinates { get; set; }
    public int? Distance { get; set; }

    public List<FoodbankLocation> Locations { get; set; } = new();

    public Items ActualItems { get; set; }

    public List<string> NeededItems { get; set; } = new();

    public string FormattedDistance { get; set; }
    public double Latitude => Convert.ToDouble(Coordinates?.Split(",", StringSplitOptions.RemoveEmptyEntries)[0] ?? "0");
    public double Longitude => Convert.ToDouble(Coordinates?.Split(",", StringSplitOptions.RemoveEmptyEntries)[1] ?? "0");
}


public record FoodbankLocation
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Address { get; set; }

    [JsonPropertyName("lat_lng")]
    public string Coordinates { get; set; }

    public double Latitude => Convert.ToDouble(Coordinates?.Split(",", StringSplitOptions.RemoveEmptyEntries)[0] ?? "0");
    public double Longitude => Convert.ToDouble(Coordinates?.Split(",", StringSplitOptions.RemoveEmptyEntries)[1] ?? "0");
}

public record Items
{
    public string Id { get; set; }
    public string Needs { get; set; }
    public string Excess { get; set; }
}