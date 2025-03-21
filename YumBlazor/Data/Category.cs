using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data;

public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "이름을 입력하세요.")]
    public string? Name { get; set; }
}