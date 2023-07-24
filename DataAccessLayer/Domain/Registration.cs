namespace DataAccessLayer.Domain
{
    public record Registration
    {
        public string AreaCode { get; set; } = null!;
        public int RegistrationNumber { get; set; }
        public string SabeelName { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
        public string CNIC { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public int AreaId { get; set; }
        public string Address { get; set; } = null!;
    }
}
