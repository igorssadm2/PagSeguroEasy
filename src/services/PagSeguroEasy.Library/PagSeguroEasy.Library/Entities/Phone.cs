

using PagSeguroEasy.Library.Utils;

namespace PagSeguroEasy.Library.Entities
{
   public class Phone
    {
        /// <summary>
        /// Initializes a new instance of the Phone class
        /// </summary>
        public Phone()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Phone class
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="number"></param>
        public Phone(string areaCode, string number)
        {
            this.areaCode = PagSeguroUtils.GetOnlyNumbers(areaCode);
            this.number = PagSeguroUtils.GetOnlyNumbers(number);
        }

        /// <summary>
        /// Area code
        /// </summary>
        public string areaCode
        {
            get;
            set;
        }

        /// <summary>
        /// Phone number
        /// </summary>
        public string number
        {
            get;
            set;
        }
    }
}
