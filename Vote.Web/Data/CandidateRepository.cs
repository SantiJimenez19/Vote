namespace Vote.Web.Data
{
    using System.Linq;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        private readonly DataContext context;

        public CandidateRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        IQueryable ICandidateRepository.GetallWithUsers()
        {
            return this.context.Candidates.Include(c => c.User);
        }
    }
}