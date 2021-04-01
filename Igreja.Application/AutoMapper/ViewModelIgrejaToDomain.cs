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
    public class ViewModelIgrejaToDomain: Profile
    {
        public ViewModelIgrejaToDomain()
        {
            CreateMap<CadastroProprietarioIgrejaViewModel, IgrejaEntity>()
               .ConstructUsing(vw => new IgrejaEntity(vw.NomeIgreja,vw.CnpjIgreja));
        }
    }
}
