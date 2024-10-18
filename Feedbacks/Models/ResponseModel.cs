public class ResponseModel<T>
{
    public T Dados { get; set; }
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }

    // Construtor padrão
    public ResponseModel()
    {
        Sucesso = false; // Inicializa como falso
        Mensagem = string.Empty; // Mensagem padrão vazia
        Dados = default(T); // Define Dados como o valor padrão para o tipo T
    }

    // Construtor com dados
    public ResponseModel(T dados)
    {
        Dados = dados;
        Sucesso = true;
        Mensagem = string.Empty;
    }

    // Construtor com mensagem
    public ResponseModel(string mensagem)
    {
        Dados = default(T);
        Sucesso = false;
        Mensagem = mensagem;
    }
}
