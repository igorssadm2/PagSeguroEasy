using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace msShop.TagHelpers.Enum
{
    public enum EnumAcaoTela
    {
        [EnumMember]
        Editar,
        [EnumMember]
        Excluir,
        [EnumMember]
        Consultar,
        [EnumMember]
        Incluir
    }
    public enum TipoDocumentoCPFCNPJ
    {
        [EnumMember]
        CPF = 1,
        [EnumMember]
        CNPJ = 2
    }
    public enum TipoFreteEnum
    {
        [EnumMember]
        PAC = 1,
        [EnumMember]
        SEDEX = 2,
        [EnumMember]
        NAOESPECIFICADO = 3
    }
    public enum MeioPagamentoEnum
    {
        [EnumMember]
        boleto = 1,
        [EnumMember]
        eft = 2,
        [EnumMember]
        creditCard = 3
    }


}
