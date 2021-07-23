using AutoMapper;
using Igreja.Application.ViewModel;
using Igreja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.AutoMapper
{
    public class ComentarioViewModelToComentarioDomain: Profile
    {

        public ComentarioViewModelToComentarioDomain()
        {
            ViewModelToDomain();
        }

        public void ViewModelToDomain()
        {
            CreateMap<ComentarioViewModel, Comentario>().ConstructUsing(c => new Comentario(c.IdUserPostResponse, c.IdUserFielResponse, c.Response, c.IdPost));
        }

    }
}
