using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    // [Table("Categoria")] => Caso queira criar a tabela com um nome diferente
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(60, ErrorMessage = "This field should contain between 3 and 60 characters!")]
        [MinLength(3, ErrorMessage = "This field should contain between 3 and 60 characters!")]
        // [DataType("nvarchar")] => muda o tipo do atributo
        public string Title { get; set; }
    }
}