using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Key]
        public string Id { get; set; }
    }
}
