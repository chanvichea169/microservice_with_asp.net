using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    public class PlatformUpdateDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Publisher { get; set; }

        [Required]
        public required string Cost { get; set; }
    }
}