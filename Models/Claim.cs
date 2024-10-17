namespace PROG6212_Part1.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string Lecturer { get; set; } // Lecturer name
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
