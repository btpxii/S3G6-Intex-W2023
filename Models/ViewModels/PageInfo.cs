namespace Intex2.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBurials { get; set; }
        public int BurialsPerPage { get; set; }
        public int CurrentPage { get; set; }
        //num of pages we need

        public int TotalPages => (int) Math.Ceiling((double) TotalNumBurials / BurialsPerPage);
    }
}