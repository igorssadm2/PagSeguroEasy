using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace msShop.Models
{
    /// <summary>
    /// Represents a PagSeguro web service error
    /// </summary>
    [Serializable]
    public sealed class ServiceError : ISerializable
    {
        private const string CodeField = "Code";
        private const string MessageField = "Message";

        /// <summary>
        /// Initializes a new instance of the PagSeguroServiceError class
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ServiceError(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        private ServiceError(SerializationInfo info, StreamingContext context)
        {
            this.Code = info.GetString(ServiceError.CodeField);
            this.Message = info.GetString(ServiceError.MessageField);
        }

        /// <summary>
        /// Populates a SerializationInfo with the data needed to serialize the target object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(ServiceError.CodeField, this.Code);
            info.AddValue(ServiceError.MessageField, this.Message);
        }

        /// <summary>
        /// Error code
        /// </summary>
        public string Code
        {
            get;
            private set;
        }

        /// <summary>
        /// Error description
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns a textual representation of this object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(this.Code);
            builder.Append("=");
            builder.Append(this.Message);
            return builder.ToString();
        }
    }
}
