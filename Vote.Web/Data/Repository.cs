using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.Web.Data
{
    public class Repository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }



    }
}
