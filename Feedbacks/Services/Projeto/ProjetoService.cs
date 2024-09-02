using Microsoft.EntityFrameworkCore;
using Feedbacks.Data;
using Feedbacks.Models;
using Feedbacks.Dto.Colaborador;
using Feedbacks.Dto.Projeto;

namespace Feedbacks.Services.Projeto
{
    public class ProjetoService : IProjetoInterface
    {
        private readonly AppDbContext _context;

        public ProjetoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ProjetoModel>> BuscarProjetoPorId(int idProjeto)
        {
            ResponseModel<ProjetoModel> resposta = new ResponseModel<ProjetoModel>();
            try
            {

                var Projeto = await _context.TB_Projetos.Include(a => a.Colaborador)
                    .FirstOrDefaultAsync(ProjetoBanco => ProjetoBanco.Id == idProjeto);

                if (Projeto == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = Projeto;
                resposta.Mensagem = "Projeto Localizado com Sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProjetoModel>>> BuscarProjetoPorIdColaborador(int idColaborador)
        {
            ResponseModel<List<ProjetoModel>> resposta = new ResponseModel<List<ProjetoModel>>();
            try
            {
                var Projeto = await _context.TB_Projetos
                    .Include(a => a.Colaborador)
                    .Where(ProjetoBanco => ProjetoBanco.Colaborador.Id == idColaborador)
                    .ToListAsync();

                if (Projeto == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = Projeto;
                resposta.Mensagem = "Projetos Localizados!";
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProjetoModel>>> CriarProjeto(ProjetoCriacaoDto ProjetoCriacaoDto)
        {
            ResponseModel<List<ProjetoModel>> resposta = new ResponseModel<List<ProjetoModel>>();

            try
            {
                var Colaborador = await _context.TB_Colaboradores
                    .FirstOrDefaultAsync(ColaboradorBanco => ColaboradorBanco.Id == ProjetoCriacaoDto.Colaborador.Id);

                if (Colaborador == null)
                {
                    resposta.Mensagem = "Nenhum registro de Colaborador localizado!";
                    return resposta;
                }

                var Projeto = new ProjetoModel()
                {
                    Projeto = ProjetoCriacaoDto.Projeto,
                    Descricao = ProjetoCriacaoDto.Descricao,
                    Data_Inicio = ProjetoCriacaoDto.Data_Inicio,
                    Data_Final = ProjetoCriacaoDto.Data_Final,
                    Colaborador = Colaborador
                };

                _context.Add(Projeto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TB_Projetos.Include(a => a.Colaborador).ToListAsync();

                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProjetoModel>>> EditarProjeto(ProjetoEdicaoDto ProjetoEdicaoDto)
        {
            ResponseModel<List<ProjetoModel>> resposta = new ResponseModel<List<ProjetoModel>>();
            try
            {

                var Projeto = await _context.TB_Projetos
                     .Include(a => a.Colaborador)
                     .FirstOrDefaultAsync(ProjetoBanco => ProjetoBanco.Id == ProjetoEdicaoDto.Id);

                var Colaborador = await _context.TB_Colaboradores
                     .FirstOrDefaultAsync(ColaboradorBanco => ColaboradorBanco.Id == ProjetoEdicaoDto.Colaborador.Id);



                if (Colaborador == null)
                {
                    resposta.Mensagem = "Nenhum registro de Colaborador localizado!";
                    return resposta;
                }

                if (Projeto == null)
                {
                    resposta.Mensagem = "Nenhum registro de Projeto localizado!";
                    return resposta;
                }

                Projeto.Projeto = ProjetoEdicaoDto.Projeto;
                Projeto.Descricao = ProjetoEdicaoDto.Descricao;
                Projeto.Data_Inicio = ProjetoEdicaoDto.Data_Inicio;
                Projeto.Data_Final = ProjetoEdicaoDto.Data_Final;
                Projeto.Colaborador = Colaborador;

                _context.Update(Projeto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TB_Projetos.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProjetoModel>>> ExcluirProjeto(int idProjeto)
        {
            ResponseModel<List<ProjetoModel>> resposta = new ResponseModel<List<ProjetoModel>>();

            try
            {

                var Projeto = await _context.TB_Projetos.Include(a => a.Colaborador)
                    .FirstOrDefaultAsync(ProjetoBanco => ProjetoBanco.Id == idProjeto);

                if (Projeto == null)
                {
                    resposta.Mensagem = "Nenhum Projeto localizado!";
                    return resposta;
                }

                _context.Remove(Projeto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TB_Projetos.ToListAsync();
                resposta.Mensagem = "Projeto Removido com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProjetoModel>>> ListarProjetos()
        {
            ResponseModel<List<ProjetoModel>> resposta = new ResponseModel<List<ProjetoModel>>();
            try
            {

                var Projetos = await _context.TB_Projetos.Include(a => a.Colaborador).ToListAsync();

                resposta.Dados = Projetos;
                resposta.Mensagem = "Todos os Projetos foram coletados!";

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