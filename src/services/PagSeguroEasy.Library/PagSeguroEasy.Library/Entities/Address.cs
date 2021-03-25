using PagSeguroEasy.Library.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagSeguroEasy.Library.Entities
{
    public class Address
    {
        /// <summary>
        /// Represents an address location, typically for shipping or charging purposes.
        /// </summary>

        /// <summary>
        /// Initializes a new instance of the Address class
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Address class
        /// </summary>
        /// <param name="country"></param>
        /// <param name="state"></param>
        /// <param name="city"></param>
        /// <param name="district"></param>
        /// <param name="postalCode"></param>
        /// <param name="street"></param>
        /// <param name="number"></param>
        /// <param name="complement"></param>
        public Address(string country, string state, string city, string district, string postalCode, string street, string number, string complement)
        {
            this.country = country;
            this.state = state;
            this.city = city;
            this.district = district;
            this.postalCode = PagSeguroUtils.GetOnlyNumbers(postalCode);
            this.street = street;
            this.number = PagSeguroUtils.GetOnlyNumbers(number);
            this.complement = complement;
        }

        /// <summary>
        /// Country
        /// </summary>
        public string country
        {
            get;
            set;
        }

        /// <summary>
        /// State or province
        /// </summary>
        public string state
        {
            get;
            set;
        }

        /// <summary>
        /// City
        /// </summary>
        public string city
        {
            get;
            set;
        }

        /// <summary>
        /// District, county or neighborhood, if applicable
        /// </summary>
        public string district
        {
            get;
            set;
        }

        /// <summary>
        /// Postal/Zip code
        /// </summary>
        public string postalCode
        {
            get;
            set;
        }

        /// <summary>
        /// Street name
        /// </summary>
        public string street
        {
            get;
            set;
        }

        /// <summary>
        /// Number
        /// </summary>
        public string number
        {
            get;
            set;
        }

        /// <summary>
        /// Apartment, suite number or any other qualifier after the street/number pair.
        /// </summary>
        /// <example>
        /// Apt 274, building A. 
        /// </example>
        public string complement
        {
            get;
            set;
        }
    }
}

