using Client.Exceptions;
using Domain.Core;
using Client.DTOs;
namespace Client.Mappers;

public class OrderMapper
{
    private static readonly DataStore DataStore = DataStore.Instance;
    
    public static Order ToOrder(OrderListDto dto)
    {
        List<Sandwich> sandwiches = new List<Sandwich>();
        foreach (var orderDto in dto.Orders)
        {
            if (orderDto.Name != null)
            {
                // Then it is a known sandwich
                Sandwich currentSandwich = DataStore.getByName(orderDto.Name);
                for (int i = 0; i < orderDto.Quantity; i++) sandwiches.Add(currentSandwich);;
            }
            else if (orderDto.Ingredients != null)
            {
                // Then it is a custom sandwich
                SandwichBuilder builder = new SandwichBuilder();
                orderDto.Ingredients.ForEach(ingredient => builder.WithIngredient(
                    DataStore.MapIngredient(ingredient.Name),
                    DataStore.MapQuantity(ingredient.Quantity)
                    ));
                Sandwich currentSandwich = builder.Build();

                for (int i = 0; i < orderDto.Quantity; i++) sandwiches.Add(currentSandwich);
            }
            else throw new InvalidJsonEntryException();
        }
        return new Order(sandwiches);
    }
}