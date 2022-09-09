using System.ComponentModel.DataAnnotations;

namespace AskMe.Views.ViewModels
{
    public class AskMeSearchViewModel
    {
        [Required]
        public string Query { get; set; }
    }
}
