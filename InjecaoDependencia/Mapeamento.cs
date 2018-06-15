using AutoMapper;
using Identity.Models;
using Identity.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Usuario;

namespace InjecaoDependencia
{
    public class Mapeamento : Profile
    {
        public Mapeamento()
        {
            CreateMap<ApplicationUser, UsuarioViewModel>().ReverseMap();
        }
    }
}
