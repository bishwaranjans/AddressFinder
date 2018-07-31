using System;
using System.Collections.Generic;
using System.Text;

namespace AddressFinder.Domain.Entities
{
    public class Address
    {
        public string Addressee { get; set; }
        public string DeliveryInformation { get; set; }
        public string CivicAddress { get; set; }
        public string Municipality { get; set; }
        public string Provinence { get; set; }
        public string PostalCode { get; set; }
    }
}
