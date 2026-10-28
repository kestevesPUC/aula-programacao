using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("user")]
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Column("cpf")]
    public string cpf { get; set; }

    [Column("senha")]
    public string senha { get; set; }

    [Column("nome")]
    public string nome { get; set; }

    [Column("cadastro", TypeName = "timestamp") ]
    public DateTime cadastro { get; set; }
}