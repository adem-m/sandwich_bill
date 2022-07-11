namespace Domain.Core.handlers;

public class BillMapper
{
    public static BillDTO ToBillDto(Bill bill)
    {
        List<SandwichDTO> sandwichDtos = new List<SandwichDTO>();
        foreach (var sandwich in bill.sandwiches)
        {
            sandwichDtos.Add(ToSandwichDto(sandwich));
        }

        Price price = bill.Total();
        return new BillDTO(
            sandwichDtos,
            price.Currency,
            price.Value
        );
    }

    private static SandwichDTO ToSandwichDto(KeyValuePair<Sandwich, int> sandwich)
    {
        List<IngredientDTO> ingredientDtos = new List<IngredientDTO>();

        foreach (var ingredient in sandwich.Key.Ingredients)
        {
            ingredientDtos.Add(new IngredientDTO(ingredient.Item1.Name, $"{ingredient.Item2.Value}{ingredient.Item2.Unit}"));
        }
        return new SandwichDTO(sandwich.Value, ingredientDtos);
    }
}