namespace Intex2.Models.ViewModels
{
    public class BurialsViewModel
    {

        public IQueryable<Burialmain> Burialmains { get; set; }
        public IQueryable<Completebodyanalysischart> completebodyanalysischarts { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}