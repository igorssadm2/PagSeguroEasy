

using System.Runtime.Serialization;

namespace PagSeguroEasy.Library.Enums
{
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
