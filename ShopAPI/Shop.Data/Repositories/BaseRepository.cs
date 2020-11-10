using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shop.Data.Repositories
{
    abstract public class BaseRepository
    {
        public IDbConnection DbConnection { get; set; }

    }
}
