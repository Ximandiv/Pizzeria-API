using System.ComponentModel.DataAnnotations;

namespace Pizza.Domain.Entities.Pizza;

public class Pizza
{
    [Key]
    public int Pizza_Id { get; set; }
    public string Pizza_Name { get; set; }
    public string Pizza_Ingredients { get; set; }
    public int Pizza_Price { get; set; }
}
