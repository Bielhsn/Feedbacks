using Microsoft.EntityFrameworkCore;
using Feedbacks.Data;
using Feedbacks.Dto.Colaborador;
using Feedbacks.Models;
using Feedbacks.Services.Colaborador;
namespace Feedbacks.Services.Colaborador
{
    public class ColaboradorService : IColaboradorInterface
    {
        private readonly AppDbContext _context;
        public ColaboradorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ColaboradorModel>> BuscarColaboradorPorId(int idColaborador)
        {
            ResponseModel<ColaboradorModel> resposta = new ResponseModel<ColaboradorModel>();
            try
            {

                var Colaborador = await _context.TB_Colaboradores.FirstOrDefaultAsync(ColaboradorBanco => ColaboradorBanco.Id == idColaborador);

                if (Colaborador == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = Colaborador;
                resposta.Mensagem = "Colaborador Localizado!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ColaboradorModel>> BuscarColaboradorPorIdProjeto(int idProjeto)
        {
            ResponseModel<ColaboradorModel> resposta = new ResponseModel<ColaboradorModel>();
            try
            {
                var Projeto = await _context.TB_Projetos
                    .Include(a => a.Colaborador)
                    .FirstOrDefaultAsync(ProjetoBanco => ProjetoBanco.Id == idProjeto);

                if (Projeto == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = Projeto.Colaborador;
                resposta.Mensagem = "Colaborador localizado!";
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ColaboradorModel>>> CriarColaborador(ColaboradorCriacaoDto ColaboradorCriacaoDto)
        {
            ResponseModel<List<ColaboradorModel>> resposta = new ResponseModel<List<ColaboradorModel>>();

            try
            {

                var Colaborador = new ColaboradorModel()
                {
                    Nome = ColaboradorCriacaoDto.Nome,
                    Funcao = ColaboradorCriacaoDto.Funcao,
                    Prioridade = ColaboradorCriacaoDto.Prioridade,
                    Data_Inicio = ColaboradorCriacaoDto.Data_Inicio,
                    Data_Final = ColaboradorCriacaoDto.Data_Final,
                };

                _context.Add(Colaborador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TB_Colaboradores.ToListAsync();
                resposta.Mensagem = "Colaborador criado com sucesso!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        public async Task<ResponseModel<List<ColaboradorModel>>> EditarColaborador(ColaboradorEdicaoDto ColaboradorEdicaoDto)
        {
            ResponseModel<List<ColaboradorModel>> resposta = new ResponseModel<List<ColaboradorModel>>();
            try
            {

                var Colaborador = await _context.TB_Colaboradores
                    .FirstOrDefaultAsync(ColaboradorBanco => ColaboradorBanco.Id == ColaboradorEdicaoDto.Id);

                if (Colaborador == null)
                {
                    resposta.Mensagem = "Nenhum Colaborador localizado!";
                    return resposta;
                }

                Colaborador.Nome = ColaboradorEdicaoDto.Nome;
                Colaborador.Funcao = ColaboradorEdicaoDto.Funcao;
                Colaborador.Prioridade = ColaboradorEdicaoDto.Prioridade;
                Colaborador.Data_Inicio = ColaboradorEdicaoDto.Data_Inicio;
                Colaborador.Data_Final = ColaboradorEdicaoDto.Data_Final;

                _context.Update(Colaborador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TB_Colaboradores.ToListAsync();
                resposta.Mensagem = "Colaborador Editado com Sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ColaboradorModel>>> ExcluirColaborador(int idColaborador)
        {
            ResponseModel<List<ColaboradorModel>> resposta = new ResponseModel<List<ColaboradorModel>>();

            try
            {

                var Colaborador = await _context.TB_Colaboradores
                    .FirstOrDefaultAsync(ColaboradorBanco => ColaboradorBanco.Id == idColaborador);

                if (Colaborador == null)
                {
                    resposta.Mensagem = "Nenhum Colaborador localizado!";
                    return resposta;
                }

                _context.Remove(Colaborador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TB_Colaboradores.ToListAsync();
                resposta.Mensagem = "Colaborador Removido com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        public async Task<ResponseModel<List<ColaboradorModel>>> ListarColaboradores()
        {
            ResponseModel<List<ColaboradorModel>> resposta = new ResponseModel<List<ColaboradorModel>>();
            try
            {

                var Colaboradores = await _context.TB_Colaboradores.ToListAsync();

                resposta.Dados = Colaboradores;
                resposta.Mensagem = "Todos os Colaboradores foram coletados!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
