using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.EndPoints.Categories;

public class CategoryGetAll
{
    // o sinal "=>" indica que ele já esta setando o valor para a propriedade
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryResponse
        {
            // Delimita o que será retornado na resposta
            Id = c.Id,
            Name = c.Name,
            Active = c.Active
        });

        return Results.Ok(response);
    }
}


