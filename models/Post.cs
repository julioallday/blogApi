using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogApi.models;

public class Post
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Required field.")]
    [MaxLength( 32, ErrorMessage = "Max 32 caracters.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Required field")]
    [MaxLength( 4000, ErrorMessage = "Max 4000 caracters.")]
    public string? Content { get; set; }
    
    [Required(ErrorMessage = "Required field..")]
    [MaxLength( 28, ErrorMessage = "Max 28 caracters." )]
    public string? Author { get; set; }

}