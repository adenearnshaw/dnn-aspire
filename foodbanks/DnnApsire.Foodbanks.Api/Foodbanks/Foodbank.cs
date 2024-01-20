using System.Text.Json.Serialization;

namespace DnnAspire.Foodbanks.Api.Foodbanks;

public record Foodbank
{
    public string Id => Slug;
    public string Name { get; set; }

    public string Slug { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Postcode { get; set; }

    [JsonPropertyName("lat_lng")]
    public string Coordinates { get; set; }

    [JsonPropertyName("distance_m")]
    public int? Distance { get; set; }

    [JsonPropertyName("needs")]
    private Items? Items { get; set; } = default;

    [JsonPropertyName("need")]
    private Items? AlternativeItems { get; set; } = default;

    public List<Location> Locations { get; set; } = new();

    public Items ActualItems => Items ?? AlternativeItems ?? new Items { Id = "none", Needs = "None" };

    public List<string> NeededItems => ActualItems.Needs.Split(Environment.NewLine).Order().ToList();

    public string FormattedDistance
    {
        get
        {
            if (Distance is null)
            {
                return "Unknown distance from you";
            }

            return $"{(Distance / 1609.344):0.##} miles from you";
        }
    }
}


public record Location
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Address { get; set; }

    [JsonPropertyName("lat_lng")]
    public string Coordinates { get; set; }
}

public record Items
{
    public string Id { get; set; }
    public string Needs { get; set; }
    public string Excess { get; set; }
}