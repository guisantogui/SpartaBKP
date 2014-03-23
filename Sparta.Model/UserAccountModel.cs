using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Model
{
    public class UserAccountModel
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Nome de usuário")]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Password { get; set; }

    }
}
