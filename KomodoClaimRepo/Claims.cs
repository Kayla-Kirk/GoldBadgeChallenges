using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimRepo
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }

    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claims()
        {

        }

        public Claims(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime incidentDate, DateTime claimDate, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
            IsValid = isValid;

        }
    }
}
