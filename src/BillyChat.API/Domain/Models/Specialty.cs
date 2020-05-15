using System; 

namespace BillyChat.API.Domain.Models
{
    public class Specialty
    {
        public Specialty()
        {
            this.VerifiedOnDate = DateTime.MinValue;
            this.IsVerified = false;
            this.VerifiedBy = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string VerifiedBy { get; private set; }
        public DateTimeOffset VerifiedOnDate { get; private set; }
        public int InstitutionId { get; private set; }
        public Institution ObtainedFrom { get; private set; }
        public bool IsVerified { get; private set; }
        public void SetAsVerified(Institution ins, string verifier)
        {
            if (this.IsVerified)
            {
                throw new InvalidOperationException(
                    $"Can only verify a specialty once. [Specialty: " +
                    $"{this.Name} was verified on " +
                    $"{this.VerifiedOnDate.ToString()} " +
                    $"by {this.VerifiedBy}.]"
                );
            }

            this.ObtainedFrom = ins;
            this.IsVerified = true;
            this.VerifiedOnDate = DateTime.UtcNow;
        }
    }
}