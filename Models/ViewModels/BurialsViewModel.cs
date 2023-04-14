namespace Intex2.Models.ViewModels
{
    public class BurialsViewModel
    {
        // Used to access burialmains page with tag helper

        public IQueryable<Burialmain> Burialmains { get; set; }
        public IQueryable<Completebodyanalysischart> completebodyanalysischarts { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}