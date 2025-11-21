using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code should be of minimum 3 charactors")]
        [MaxLength(3, ErrorMessage = "Code should be of maximum 3 charactors")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Code should be of maximum 100 charactors")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}