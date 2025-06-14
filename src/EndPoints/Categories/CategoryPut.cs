using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.EndPoints.Categories;

public class CategoryPut
{ 
    // o sinal "=>" indica que ele já esta setando o valor para a propriedade
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };

    public static Delegate Handle => Action;

    //[ FromRoute] indica que o parâmetro id será obtido da rota
    public static IResult Action([FromRoute] Guid id,CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        // Verifica se a categoria existe
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
        // Para aplicar as alterações, é necessário verificar se a categoria foi encontrada
        category.Name = categoryRequest.Name;
        category.Active = categoryRequest.Active;

        // Atualiza os campos de auditoria
        context.SaveChanges();

        return Results.Ok();
    }
}


