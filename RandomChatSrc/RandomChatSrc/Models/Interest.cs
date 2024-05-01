// <copyright file="Interest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents the interests of a User.
    /// </summary>
    public class Interest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Interest"/> class with a specified interest name.
        /// </summary>
        /// <param name="interestName">The name of the interest.</param>
        public Interest(string interestName)
        {
            this.InterestName = interestName;
        }

        /// <summary>
        /// Gets the unique identifier for the interest.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Gets the name of the interest.
        /// </summary>
        public string InterestName { get; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
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
            return this.InterestName.Equals(other.InterestName, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}