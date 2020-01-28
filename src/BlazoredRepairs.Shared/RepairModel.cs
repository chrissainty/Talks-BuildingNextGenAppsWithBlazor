using System.ComponentModel.DataAnnotations;

namespace BlazoredRepairs.Shared
{
    public class RepairModel
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the issue")]
        [MinLength(10, ErrorMessage = "Issue description must be longer than 10 characters")]
        public string Issue { get; set; }

        [Required(ErrorMessage = "Please select a trade")]
        public string Trade { get; set; }

        [Required(ErrorMessage = "Please enter a contact number")]
        [RegularExpression(@"^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$", ErrorMessage = "Please enter a valid contact number")]
        public string ContactNumber { get; set; }

        public bool Complete { get; set; }
    }
}
