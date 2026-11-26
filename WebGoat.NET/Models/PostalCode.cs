using System;

namespace WebGoatCore.Models
{
    public sealed record PostalCode
    {
        public const int MaximumLength = 20;

        public string Value { get; }

        public PostalCode(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            foreach (char character in value)
            {
                if (char.IsControl(character))
                {
                    throw new ArgumentException(
                        "A postal code cannot contain control characters.",
                        nameof(value));
                }
            }

            string normalizedValue = value.Trim();
            if (normalizedValue.Length == 0)
            {
                throw new ArgumentException("A postal code cannot be empty.", nameof(value));
            }

            if (normalizedValue.Length > MaximumLength)
            {
                throw new ArgumentException(
                    $"A postal code cannot exceed {MaximumLength} characters.",
                    nameof(value));
            }

            Value = normalizedValue;
        }

        public override string ToString() => Value;
    }
}
