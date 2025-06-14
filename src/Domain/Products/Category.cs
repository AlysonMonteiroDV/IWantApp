using Flunt.Validations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IWantApp.Domain.Products;

public class Category : Entity
{

    public string Name { get; private set; }
   
    public bool Active { get; private set; }


    //tudo que é obrigatório para a criação daquela entidade,
    //deve utiliza contrutor

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;


        Validate();


        
        

    }
    public void Validate()
    {
        // Validação de regras de negócio usando Flunt
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name")
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
            .IsNotNullOrEmpty(EditedBy, "EditedBy");

        //caso não esteja tudo certo,ele vem para o AddNotifications
        AddNotifications(contract);

    }


    public void EditInfo(string name, bool active)
    {
        Active = active;
        Name = name;

        Validate();

        
    }
}
