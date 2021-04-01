using AutoMapper;
using Igreja.Domain.Entity;
using Igreja.Service.Abstract.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.AutoMapper
{
    public class ViewModelToEnderecoDomain : Profile
    {
        public ViewModelToEnderecoDomain()
        {
            CreateMap<CadastroProprietarioIgrejaViewModel, Endereco>()
               .ConstructUsing(vw => new Endereco(vw.NomeEnderecoIgreja, vw.CepIgreja));
        }
    }
}
