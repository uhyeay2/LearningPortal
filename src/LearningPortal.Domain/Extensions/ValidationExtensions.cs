using LearningPortal.Domain.Constants;
using LearningPortal.Domain.Models;

namespace LearningPortal.Domain.Extensions
{
    public static class ValidationExtensions
    {
        #region Strings Are Not Null/Empty/WhiteSpace

        public static void AddIfAnyStringsAreNullOrWhiteSpace(this List<ValidationFailedMessage> list, params(string NameOfProperty, string Value)[] requiredStrings)
        {
            foreach (var (nameOfProperty, value) in requiredStrings)
            {
                list.AddIfStringIsNullOrWhiteSpace(nameOfProperty, value);
            }
        }

        public static void AddIfStringIsNullOrWhiteSpace(this List<ValidationFailedMessage> list, string nameOfProperty, string value)
        {
            list ??= new List<ValidationFailedMessage>();

            if (string.IsNullOrWhiteSpace(value))
            {
                list.Add(new ValidationFailedMessage(nameOfProperty, ValidationFailureMessage.RequiredString));
            }
        }

        #endregion

        #region Guids Are Not Null/Empty

        public static void AddIfGuidIsNullOrEmpty(this List<ValidationFailedMessage> list, string nameOfProperty, Guid? value)
        {
            list ??= new List<ValidationFailedMessage>();

            if (value == null || value == Guid.Empty)
            {
                list.Add(new ValidationFailedMessage(nameOfProperty, ValidationFailureMessage.RequiredGuid));
            }
        }

        #endregion

        #region Email Field Is Not Null/Empty And In Valid Format

        public static void AddIfEmailIsNotValidFormat(this List<ValidationFailedMessage> list, string nameOfProperty, string email)
        {
            list ??= new List<ValidationFailedMessage>();

            if (string.IsNullOrWhiteSpace(email))
            {
                list.Add(new ValidationFailedMessage(nameOfProperty, ValidationFailureMessage.RequiredString));
            }
            else if(!new System.Text.RegularExpressions.Regex(@".+@.\..+").IsMatch(email))
            {
                list.Add(new ValidationFailedMessage(nameOfProperty, ValidationFailureMessage.EmailIncorrectFormat));
            }
        }

        #endregion
    }
}
