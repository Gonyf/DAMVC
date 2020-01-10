using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAMVC.DTO;

namespace DAMVC.ViewModels
{
    public class RegisterUserVm
    {
        [Required]
        public UserForRegisterDTO UserInfo { get; set; }

        public string Error { get; set; }
    }
}
