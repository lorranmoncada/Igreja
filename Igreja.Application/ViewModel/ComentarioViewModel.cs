﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Application.ViewModel
{
    public class ComentarioViewModel
    {
        public Guid? IdUserFielResponse { get; set; }
        public Guid? IdUserPostResponse { get; set; }
        public Guid IdPost { get; set; }
        public string Response { get; set; }
        public int QtdComentario {get;set;}
    }
}
