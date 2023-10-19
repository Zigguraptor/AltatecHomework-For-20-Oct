using System.ComponentModel.DataAnnotations;

namespace AltatecHomework_For_20_Oct.DAL.Entity;

public class BookEntity
{
    [Key] public Guid Guid { get; set; }

    [Required(ErrorMessage = $"{nameof(Title)} не может быть пустым")]
    public required string Title { get; set; }

    [Required(ErrorMessage = $"{nameof(Author)} не может быть пустым")]
    public required string Author { get; set; }

    [Required(ErrorMessage = $"{nameof(PriceRub)} не может быть пустым")]
    [Range(0.0, double.PositiveInfinity, ErrorMessage = $"Стоимость должна быть положительным числом")]
    public required decimal PriceRub { get; set; }
}
