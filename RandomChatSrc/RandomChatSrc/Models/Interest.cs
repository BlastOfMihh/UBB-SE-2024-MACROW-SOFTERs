namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents the interests of a User.
    /// </summary>

    public class Interest(string interestName)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string InterestName { get; } = interestName;

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
            var other = (Interest)obj;
            return InterestName.Equals(other.InterestName, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(InterestName);
        }
    }
}
