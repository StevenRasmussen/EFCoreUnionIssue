namespace ConsoleApp1.Models
{
    internal abstract class LicenseBase
    {
        public int Id { get; set; }

        public List<LicenseRegistration>? Registrations { get; set; }
    }
}
