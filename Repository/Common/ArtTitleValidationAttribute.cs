using System.ComponentModel.DataAnnotations;

namespace Repository.Common
{
    public class ArtTitleValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var upperWord = "qwertyuiopasdfghjklzxcvbnm".ToUpper();
            string validationChar = @"qwertyuiopasdfghjklzxcvbnm@$&,".ToUpper();

            if (value is string artTitle)
            {
                if (artTitle.Length < 4)
                {
                    return new ValidationResult("ArtTitle's value is greater than 4 characters.");
                }
                var words = artTitle.Split(' ');
                foreach (var word in words)
                {
                    char[] letters = word.Trim().ToCharArray();
                    if (!upperWord.Contains(letters[0]))
                    {
                        return new ValidationResult(@"Each word of the ArtTitle must begin with the capital letter.");
                    }
                    foreach (var letter in letters)
                    {
                        if (!validationChar.Contains(letter.ToString().ToUpper()))
                        {
                            return new ValidationResult(@"The value of ArtTitle is not allow numbers (0, 1, 2 9) but allows special characters such as @, $, &, (, ). ");
                        }
                    }
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid ArtTitle value.");
        }
    }
}
