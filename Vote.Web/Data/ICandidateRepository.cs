
namespace Vote.Web.Data
{
    using System.Linq;
    using Vote.Web.Data.Entities;
    public interface ICandidateRepository : IGenericRepository<Candidate>
    {
        IQueryable GetallWithUsers();
    }
}
