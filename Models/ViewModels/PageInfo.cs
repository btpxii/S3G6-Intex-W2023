namespace Intex2.Models.ViewModels
{
    // Used to give details about page being accessed (for pagination)
    public class PageInfo
    {
        public int TotalNumBurials { get; set; }
        public int BurialsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int) Math.Ceiling((double) TotalNumBurials / BurialsPerPage);
    }
}