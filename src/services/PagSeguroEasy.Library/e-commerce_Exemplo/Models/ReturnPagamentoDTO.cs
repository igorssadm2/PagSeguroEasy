using System;

using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace msShop.Models.DTO
{
    public class ReturnPagamentoDTO
    {
        public Transaction transaction { get; set; }
        public Errors Errors { get; set; }
        [XmlRoot(ElementName = "paymentMethod")]
        public class PaymentMethod
        {
            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
            [XmlElement(ElementName = "code")]
            public string Code { get; set; }
        }

        [XmlRoot(ElementName = "item")]
        public class Item
        {
            [XmlElement(ElementName = "id")]
            public string Id { get; set; }
            [XmlElement(ElementName = "description")]
            public string Description { get; set; }
            [XmlElement(ElementName = "quantity")]
            public string Quantity { get; set; }
            [XmlElement(ElementName = "amount")]
            public string Amount { get; set; }
        }

        [XmlRoot(ElementName = "items")]
        public class Items
        {
            [XmlElement(ElementName = "item")]
            public List<Item> Item { get; set; }
        }

        [XmlRoot(ElementName = "phone")]
        public class Phone
        {
            [XmlElement(ElementName = "areaCode")]
            public string AreaCode { get; set; }
            [XmlElement(ElementName = "number")]
            public string Number { get; set; }
        }

        [XmlRoot(ElementName = "document")]
        public class Document
        {
            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
            [XmlElement(ElementName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "documents")]
        public class Documents
        {
            [XmlElement(ElementName = "document")]
            public Document Document { get; set; }
        }

        [XmlRoot(ElementName = "sender")]
        public class Sender
        {
            [XmlElement(ElementName = "name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "email")]
            public string Email { get; set; }
            [XmlElement(ElementName = "phone")]
            public Phone Phone { get; set; }
            [XmlElement(ElementName = "documents")]
            public Documents Documents { get; set; }
        }

        [XmlRoot(ElementName = "address")]
        public class Address
        {
            [XmlElement(ElementName = "street")]
            public string Street { get; set; }
            [XmlElement(ElementName = "number")]
            public string Number { get; set; }
            [XmlElement(ElementName = "complement")]
            public string Complement { get; set; }
            [XmlElement(ElementName = "district")]
            public string District { get; set; }
            [XmlElement(ElementName = "city")]
            public string City { get; set; }
            [XmlElement(ElementName = "state")]
            public string State { get; set; }
            [XmlElement(ElementName = "country")]
            public string Country { get; set; }
            [XmlElement(ElementName = "postalCode")]
            public string PostalCode { get; set; }
        }

        [XmlRoot(ElementName = "shipping")]
        public class Shipping
        {
            [XmlElement(ElementName = "address")]
            public Address Address { get; set; }
            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
            [XmlElement(ElementName = "cost")]
            public string Cost { get; set; }
        }

        [XmlRoot(ElementName = "rawCode")]
        public class RawCode
        {
            [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string Nil { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
        }

        [XmlRoot(ElementName = "rawMessage")]
        public class RawMessage
        {
            [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string Nil { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
        }

        [XmlRoot(ElementName = "normalizedCode")]
        public class NormalizedCode
        {
            [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string Nil { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
        }

        [XmlRoot(ElementName = "normalizedMessage")]
        public class NormalizedMessage
        {
            [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string Nil { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
        }

        [XmlRoot(ElementName = "gatewaySystem")]
        public class GatewaySystem
        {
            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
            [XmlElement(ElementName = "rawCode")]
            public RawCode RawCode { get; set; }
            [XmlElement(ElementName = "rawMessage")]
            public RawMessage RawMessage { get; set; }
            [XmlElement(ElementName = "normalizedCode")]
            public NormalizedCode NormalizedCode { get; set; }
            [XmlElement(ElementName = "normalizedMessage")]
            public NormalizedMessage NormalizedMessage { get; set; }
            [XmlElement(ElementName = "authorizationCode")]
            public string AuthorizationCode { get; set; }
            [XmlElement(ElementName = "nsu")]
            public string Nsu { get; set; }
            [XmlElement(ElementName = "tid")]
            public string Tid { get; set; }
            [XmlElement(ElementName = "establishmentCode")]
            public string EstablishmentCode { get; set; }
            [XmlElement(ElementName = "acquirerName")]
            public string AcquirerName { get; set; }
        }

        [XmlRoot(ElementName = "transaction")]
        public class Transaction
        {
            [XmlElement(ElementName = "date")]
            public string Date { get; set; }
            [XmlElement(ElementName = "code")]
            public string Code { get; set; }
            [XmlElement(ElementName = "reference")]
            public string Reference { get; set; }
            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
            [XmlElement(ElementName = "status")]
            public string Status { get; set; }
            [XmlElement(ElementName = "lastEventDate")]
            public string LastEventDate { get; set; }
            [XmlElement(ElementName = "paymentMethod")]
            public PaymentMethod PaymentMethod { get; set; }
            [XmlElement(ElementName = "grossAmount")]
            public string GrossAmount { get; set; }
            [XmlElement(ElementName = "discountAmount")]
            public string DiscountAmount { get; set; }
            [XmlElement(ElementName = "feeAmount")]
            public string FeeAmount { get; set; }
            [XmlElement(ElementName = "netAmount")]
            public string NetAmount { get; set; }
            [XmlElement(ElementName = "extraAmount")]
            public string ExtraAmount { get; set; }
            [XmlElement(ElementName = "installmentCount")]
            public string InstallmentCount { get; set; }
            [XmlElement(ElementName = "itemCount")]
            public string ItemCount { get; set; }
            [XmlElement(ElementName = "items")]
            public Items Items { get; set; }
            [XmlElement(ElementName = "sender")]
            public Sender Sender { get; set; }
            [XmlElement(ElementName = "shipping")]
            public Shipping Shipping { get; set; }
            [XmlElement(ElementName = "gatewaySystem")]
            public GatewaySystem GatewaySystem { get; set; }
        }

    }

    [XmlRoot(ElementName = "error")]
    public class Error
    {
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "message")]
        public string Message { get; set; }
    }

    [XmlRoot(ElementName = "errors")]
    public class Errors
    {
        [XmlElement(ElementName = "error")]
        public Error Error { get; set; }
    }
 

}
