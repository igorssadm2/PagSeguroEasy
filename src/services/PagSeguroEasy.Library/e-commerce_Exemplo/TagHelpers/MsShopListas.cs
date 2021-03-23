using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using msShop.TagHelpers.Enum;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.TagHelpers
{
    public class MsShopListas
    {
       

    }

    public class TipoDocumento : ObservableCollection<TipoDocumento>
    {
        public int ID { get; set; }
        public string Tipodocumento{ get; set; }
        public TipoDocumento()
        {
            this.Add(new TipoDocumento() {ID = (int)TipoDocumentoCPFCNPJ.CPF, Tipodocumento = TipoDocumentoCPFCNPJ.CPF.ToString()});
            this.Add(new TipoDocumento() {ID = (int)TipoDocumentoCPFCNPJ.CNPJ, Tipodocumento = TipoDocumentoCPFCNPJ.CNPJ.ToString()});
        }
    }


}
