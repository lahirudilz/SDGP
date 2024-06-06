namespace susFaceGen.Models.ViewModels
{
    public class GenerateImageVIewModel
    {
        public Case Case { get; set; }
        public Statement Statement { get; set; }
        public bool IsCaseSubmitted { get; set; } = false;
        public bool IsGenerated { get; set; } = false;
        public string ImageUrl { get; set; } = "../images/user.webp";
        
    }
}
