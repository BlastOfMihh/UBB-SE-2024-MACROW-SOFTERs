using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.InterestDomain
{
    public class Interest
    {
        public Guid Id { get; }
        public string InterestName { get; }

        public Interest(string interestName)
        {
            this.Id = Guid.NewGuid();
            this.InterestName = interestName;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Interest other = (Interest)obj;
            return this.Id == other.Id;  // or should compare `this.InterestName == other.InterestName`? probably not
        }
    }
}
