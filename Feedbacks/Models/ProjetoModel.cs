namespace Feedbacks.Models
{
    public class ProjetoModel
    {
        public int Id { get; set; }
        public string Projeto { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Final { get; set; }
        public ColaboradorModel Colaborador { get; set; }
    }
}
