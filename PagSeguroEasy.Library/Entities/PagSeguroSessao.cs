

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace PagSeguroEasy.Library.Models
{
   public class PagSeguroSessao
    {
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(AnonymousType = true)]
        [XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class session
        {

            private string idField;

            /// <remarks/>
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }


        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [SerializableAttribute()]
        [DesignerCategoryAttribute("code")]
        [XmlTypeAttribute(AnonymousType = true)]
        [XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class card
        {

            private string tokenField;

            /// <remarks/>
            public string token
            {
                get
                {
                    return this.tokenField;
                }
                set
                {
                    this.tokenField = value;
                }
            }
        }
    }
}
