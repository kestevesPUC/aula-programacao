using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("veiculo")]
public class Veiculo
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Column("placa")]
    
    public string placa { get; set; }

    [Column("modelo")]
    
    public string modelo { get; set; }
    
    [Column("marca")]
    
    public string marca { get; set; }

    
    
    [Column("user_id")]
     
    public int userId { get; set; }


    public User User { get; set; }
    

    [Column("cadastro", TypeName = "timestamp") ]
    public DateTime cadastro { get; set; }
}