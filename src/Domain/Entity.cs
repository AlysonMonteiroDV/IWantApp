namespace IWantApp.Domain;
using Flunt.Notifications;

// deixando a class Entity abstrata, para que não seja instanciada diretamente
public abstract class Entity : Notifiable<Notification>
{
    public Entity()
    {
        // Inicializando o Id com um novo Guid(global Unique Identifier)
        // e as datas de criação e edição com a data atual
        Id = Guid.NewGuid();
      
    }   

    public Guid Id { get; set; }

    // Propriedades de auditoria
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string EditedBy { get; set; }
    public DateTime EditedOn { get; set; }
}
