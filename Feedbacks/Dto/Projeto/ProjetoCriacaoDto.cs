﻿using Feedbacks.Dto.Vinculo;
using Feedbacks.Models;

namespace Feedbacks.Dto.Projeto
{
    public class ProjetoCriacaoDto
    {
        public string Projeto { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Final { get; set; }
        public ColaboradorVinculoDto Colaborador { get; set; }
    }
}