namespace Pipedrive.CustomFields
{
    public class AddressCustomField : ICustomField
    {
        public string Value { get; set; }

        public string Subpremise { get; set; }

        public string StreetNumber { get; set; }

        public string Route { get; set; }

        public string Sublocality { get; set; }

        public string Locality { get; set; }

        public string AdminAreaLevel1 { get; set; }

        public string AdminAreaLevel2 { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string FormattedAddress { get; set; }

        public AddressCustomField(
            string value,
            string subpremise,
            string streetNumber,
            string route,
            string sublocality,
            string locality,
            string adminAreaLevel1,
            string adminAreaLevel2,
            string country,
            string postalCode,
            string formattedAddress)
        {
            Value = value;
            Subpremise = subpremise;
            StreetNumber = streetNumber;
            Route = route;
            Sublocality = sublocality;
            Locality = locality;
            AdminAreaLevel1 = adminAreaLevel1;
            AdminAreaLevel2 = adminAreaLevel2;
            Country = country;
            PostalCode = postalCode;
            FormattedAddress = formattedAddress;
        }

        public override string ToString()
        {
            return FormattedAddress;
        }
    }
}
