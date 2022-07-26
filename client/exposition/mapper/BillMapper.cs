using Domain.Core;
using Client.DTOs;
namespace Client.Mappers;

public class BillMapper
{
    public static BillDto ToBillDto(Bill bill)
    {
        List<SandwichDto> sandwichDtos = new List<SandwichDto>();
        foreach (var sandwich in bill.sandwiches)
        {
            sandwichDtos.Add(ToSandwichDto(sandwich));
        }
        Price price = bill.Total();
        return new BillDto(
            sandwichDtos,
            price.Currency,
            price.Value
        );
    }

    private static SandwichDto ToSandwichDto(KeyValuePair<Sandwich, int> sandwich)
    {
        List<IngredientDto> ingredientDtos = new List<IngredientDto>();

        foreach (var ingredient in sandwich.Key.Ingredients)
        {
            ingredientDtos.Add(new IngredientDto(ingredient.Item1.Name, $"{ingredient.Item2.Value}{ingredient.Item2.Unit}"));
        }
        return new SandwichDto(sandwich.Value, ingredientDtos);
    }
}