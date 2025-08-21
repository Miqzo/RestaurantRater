using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantRater.Shared.Models;

public enum RestaurantStyle
{
    ALaCarte = 0,
    Buffet = 1,
    FastFood = 2,
}

public class Restaurant
{
    public int Id { get; set; }

    //Basic info
    [Required, MaxLength(64)]
    public string Name { get; set; } = string.Empty;
    [Required, MaxLength(64)]
    public string Location { get; set; } = string.Empty; //For example the city or neighborhood

    //Metadata
    [Range(1, 5)]
    public int PriceBracket { get; set; } //1-5, 1 is cheapest, 5 is most expensive
    public RestaurantStyle Style { get; set; } //0 = AlaCarte, 1 = Buffet, 2 = FastFood

    //Scores (1-5)
    [Range(1,5)] public int FoodScore { get; set; } //Taste, quality and selection of food
    [Range(1,5)] public int DrinksScore { get; set; } //Selection and quality of drinks
    [Range(1,5)] public int DessertScore { get; set; } //Selection and quality of desserts
    [Range(1,5)] public int SettingScore { get; set; } //Ambiance, cleanliness, comfort, quality of service
    [Range(1,5)] public int ValueScore { get; set; } //Value for money, how much you get for what you pay

    //Short written review
    [MaxLength(200)]
    public string Review { get; set; } = string.Empty;

    //Additional rating, not calculated into the average, nullable due to not everyone having children
    [Range(1,5)]
    public int ChildFriendlyScore { get; set; } //How child-friendly the restaurant is, if applicable

    //Calculated average score, calculated at runtime as the ratings are updated
    [NotMapped]
    public double AverageScore => (FoodScore + DrinksScore + DessertScore + SettingScore + ValueScore) / 5.0;
}