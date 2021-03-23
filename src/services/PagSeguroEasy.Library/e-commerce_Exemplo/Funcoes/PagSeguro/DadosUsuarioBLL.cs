using msShop.Models;
using System.Linq;

namespace msShop.Funcoes.PagSeguro
{
    public class DadosUsuarioBLL : FuncoesBase
    {
        public DadosUsuarioBLL(AppDbContext contextoBancodeDados) : base(contextoBancodeDados)
        {

        }

        public DadosUsuario GetDadosUsuarioByIdUser(string Iduser)
        {
            var DadosUsuario = this.bancodeDados.DadosUsuario.Where(x => x.UserId == Iduser).FirstOrDefault();
            if (DadosUsuario == null)
            {
                DadosUsuario = new DadosUsuario();
                DadosUsuario.UserId = Iduser;
            }
            return DadosUsuario;
        }

        public DadosUsuario InsertOuUpdateDadosUsuario(DadosUsuario dadosUsuario)
        {
            var dados = this.bancodeDados.DadosUsuario.Where(x => x.UserId == dadosUsuario.UserId).FirstOrDefault();
            if (dados != null)
                this.bancodeDados.Entry(dados).CurrentValues.SetValues(dadosUsuario);
            else
                this.bancodeDados.DadosUsuario.Add(dadosUsuario);

            this.bancodeDados.SaveChanges();
            return dadosUsuario;
        }
    }
}
