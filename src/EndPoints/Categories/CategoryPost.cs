using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.EndPoints.Categories;

public class CategoryPost
{ 
    // o sinal "=>" indica que ele já esta setando o valor para a propriedade
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        
     

        var category = new Category(categoryRequest.Name)
        {
            
            CreatedBy = "system", // Assuming a default creator for simplicity
            CreatedOn = DateTime.Now,
            EditedBy = "system", // Assuming a default editor for simplicity
            EditedOn = DateTime.Now

        };

        //
        if (!category.IsValid) 
            return Results.BadRequest(category.Notifications);

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}


