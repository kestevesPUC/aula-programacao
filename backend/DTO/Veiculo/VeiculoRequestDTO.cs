using System.ComponentModel.DataAnnotations;

public class VeiculoRequestDTO
{
    [Required(ErrorMessage = "A placa é obrigatória.")]
    [StringLength(8, ErrorMessage = "A placa deve ter no máximo 8 caracteres.")]
    public string Placa { get; set; }

    [Required(ErrorMessage = "O modelo é obrigatório.")]
    [StringLength(50, ErrorMessage = "O modelo deve ter no máximo 50 caracteres.")]
    public string Modelo { get; set; }

    [Required(ErrorMessage = "A marca é obrigatória.")]
    [StringLength(50, ErrorMessage = "A marca deve ter no máximo 50 caracteres.")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O usuário é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "UserId inválido.")]
    public int UserId { get; set; }


    public Veiculo ToEntity()
    {
        Veiculo veiculo = new Veiculo{
            placa = Placa.Trim().ToUpper(),
            modelo = Modelo.Trim(),
            marca = Marca.Trim(),
            userId = UserId,
            cadastro = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
        };
        
        return veiculo;
    }

}