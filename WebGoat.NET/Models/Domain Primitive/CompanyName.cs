using System;
using System.Text.RegularExpressions;

namespace WebGoatCore.Models.Domain_Primitive
{
    public class CompanyName
    {
        private string companyName { get; }

        public CompanyName(string companyName)
        {
            this.companyName = Validate(companyName);
        }

        private static string Validate(string companyName)
        {
            // Null validation
            if (companyName == null)
            {
                throw new ArgumentNullException(nameof(companyName));
            }

            // Size validation
            if (companyName.Length < 2 || companyName.Length > 50)
            {
                throw new ArgumentException(
                    "Company name must contain between 2 and 50 characters.");
            }

            // Whitespace validation
            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new ArgumentException(
                    "Company name cannot be blank.");
            }

            // Lexical validation
            if (!Regex.IsMatch(companyName, @"^A[\p{L}\p{N} &.,'()-]+\z"))
            {
                throw new ArgumentException(
                    "Company name contains invalid characters.");
            }

            return companyName;
        }
    }
}