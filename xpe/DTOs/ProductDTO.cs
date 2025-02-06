using System.ComponentModel.DataAnnotations;

namespace xpe.DTOs;

public class ProductDTO
{
    [Key]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)] 
    public string Description { get; set; }
    
    [Range(0.01, double.MaxValue, ErrorMessage = "O {0} deve ser maior que zero")]
    public decimal? Price { get; set; }
    
    [StringLength(50, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres")]
    public string? Sku { get; set; }
    
    public bool Active { get; set; } = true;
    
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; set; }
}