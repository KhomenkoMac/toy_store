using System.ComponentModel.DataAnnotations;

namespace entities.DTO
{
    public abstract class DTO
    {
        [Key]
        public int Id { get; set; }
    }
}
