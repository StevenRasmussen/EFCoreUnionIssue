namespace ConsoleApp1.Models
{
    internal class LicenseRegistration
    {
        public int Id { get; set; }

        public int LicenseId { get; set; }

        public LicenseBase? License { get; set; }
    }
}
