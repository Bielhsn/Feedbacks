namespace Feedbacks.Dto.Colaborador
{
    public class ColaboradorEdicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public int Prioridade { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Final { get; set; }
    }
}
