using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.Web.Data
{
    using Vote.Web.Data.Entities;
    public interface ICandidateRepository : IGenericRepository<Candidate>
    {
    }
}
