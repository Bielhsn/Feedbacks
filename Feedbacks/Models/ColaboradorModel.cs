using System.Text.Json.Serialization;

namespace Feedbacks.Models
{
    public class ColaboradorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public int Prioridade { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Final { get; set; }
        [JsonIgnore]
        public ICollection<ProjetoModel> Projetos { get; set; }
    }
}
