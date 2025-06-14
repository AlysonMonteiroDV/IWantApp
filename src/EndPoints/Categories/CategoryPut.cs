using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Categories;

public class CategoryPut
{ 
    // o sinal "=>" indica que ele já esta setando o valor para a propriedade
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };

    public static Delegate Handle => Action;

    //[ FromRoute] indica que o parâmetro id será obtido da rota
    public static IResult Action([FromRoute] Guid id,CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        // Verifica se a categoria existe
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null)
        {
            return Results.NotFound();
        }

        //Faz as edições das propriedades de dentro da classe usando o metodo "EditInfo
        category.EditInfo(categoryRequest.Name, categoryRequest.Active);

        if (!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
        }



        // Atualiza os campos de auditoria
        context.SaveChanges();

        return Results.Ok();
    }
}


