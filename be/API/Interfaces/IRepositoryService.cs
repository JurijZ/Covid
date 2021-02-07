using API.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IRepositoryService
    {
        public IEnumerable<TypedCase> GetDataPartition(int id, int pageSize);
        public int GetDataSize();
        int SaveNewCase(TypedCase newCase);
    }
}
