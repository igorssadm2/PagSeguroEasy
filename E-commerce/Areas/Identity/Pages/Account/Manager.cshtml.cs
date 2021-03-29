using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using msShop.Funcoes.PagSeguro;
using msShop.Models;
using msShop.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Areas.Identity.Pages.Account
{
    public class DadosUsuarioModel : PageModel
    {
        public DadosUsuarioBLL  dadosUsuarioBLL{ get; set; }
        protected IdentityUser _user { get; set; }
        [BindProperty]
        public DadosUsuario DadosUsuario { get; set; }
        public DadosUsuarioModel(UserManager<IdentityUser> userManager, DadosUsuarioBLL dadosUsuario)
        {
            this._user = userManager.Users.FirstOrDefault();
            this.dadosUsuarioBLL = dadosUsuario;
        }

       public List<TipoDocumento> ListaTipoDocumentos { get; set; }
       
        public virtual List<TipoDocumento> lstTipoDocumento
        {
            get
            {
                if (this.LSTTIPODOCUMENTO == null)
                    this.LSTTIPODOCUMENTO = new TipoDocumento().ToList();
                return LSTTIPODOCUMENTO;
            }
            set
            {
                this.LSTTIPODOCUMENTO = value;
            }
        }
        internal List<TipoDocumento> LSTTIPODOCUMENTO;
        public IActionResult OnGet()
        {
            DadosUsuario = dadosUsuarioBLL.GetDadosUsuarioByIdUser(_user.Id);
            return Page();
        }

        public IActionResult OnPost()
        {
            var dados = dadosUsuarioBLL.GetDadosUsuarioByIdUser(_user.Id);
            if (ModelState.IsValid)
            {
                DadosUsuario.DadosUsuarioId = dados.DadosUsuarioId;
                DadosUsuario.UserId = _user.Id;
                var retorno = dadosUsuarioBLL.InsertOuUpdateDadosUsuario(DadosUsuario);
                return Page();
            }
            return Page();
        }


    }
}
