using System.ComponentModel.DataAnnotations;

public class VeiculoUpdateDTO
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
}