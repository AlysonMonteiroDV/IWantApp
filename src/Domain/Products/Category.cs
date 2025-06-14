using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{

    public string Name { get; set; }
   
    public bool Active { get; set; }


    //tudo que é obrigatório para a criação daquela entidade,
    //deve utiliza contrutor

    public Category(string name)
    {
        // Validação de regras de negócio usando Flunt
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name");
         
        //caso não esteja tudo certo,ele vem para o AddNotifications
        AddNotifications(contract);

        Name = name;
        Active = true;
      
    }
}
