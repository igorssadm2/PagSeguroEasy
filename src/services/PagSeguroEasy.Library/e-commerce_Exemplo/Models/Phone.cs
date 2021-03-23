

using msShop.TagHelpers;

namespace msShop.Models
{
    /// <summary>
    /// Represents a phone number
    /// </summary>
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
            this.areaCode = PagSeguroUtil.GetOnlyNumbers(areaCode);
            this.number = PagSeguroUtil.GetOnlyNumbers(number);
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
