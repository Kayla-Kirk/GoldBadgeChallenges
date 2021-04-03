using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimRepo
{
    public class ClaimsRepo
    {
        private Queue<Claims> _claims = new Queue<Claims>();
        public Queue<Claims> GetClaims()
        {
            return _claims;
        }

        public void AddClaim(Claims newClaims)
        {
            _claims.Enqueue(newClaims);
        }

        public void RemoveClaims()
        {
            _claims.Dequeue();
        }

        public void IsValid(Claims claim)
        {
            TimeSpan difference = claim.DateOfClaim - claim.DateOfIncident;

            if (difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
            {
                claim.IsValid = false;
            }
        }
    }
}
