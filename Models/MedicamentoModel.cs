using System.ComponentModel.DataAnnotations;

namespace ControleMedicamentos.Models;

public class MedicamentoModel
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Nome do medicamento obrigatório")]
    public string? NomeMedicamento { get; set; }
    [Required(ErrorMessage = "Digite data de fabricação do medicamento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}" , ApplyFormatInEditMode = true)]
    public DateTime DataFabricacao { get; set; }
    [Required(ErrorMessage = "Digite a data de vencimento do medicamento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataVencimento { get; set; }
    public string? Descricao { get; set; }
}
