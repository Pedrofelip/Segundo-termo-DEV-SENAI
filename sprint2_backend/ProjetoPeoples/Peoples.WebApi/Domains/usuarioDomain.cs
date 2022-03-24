using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class usuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Informe o tipo do usuario(id)")]
        public int permissao { get; set; }

        [Required(ErrorMessage = "Informe o Email do Usuario")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe uma senha")]
        [StringLength(15, MinimumLength = 3)]
        public string senha { get; set; }
    }
}
