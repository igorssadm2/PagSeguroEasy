

using System.Runtime.Serialization;

namespace PagSeguroEasy.Library.Enums
{
   public enum TipoFreteEnum
    {
        [EnumMember]
        PAC = 1,
        [EnumMember]
        SEDEX = 2,
        [EnumMember]
        NAOESPECIFICADO = 3
    }
}
