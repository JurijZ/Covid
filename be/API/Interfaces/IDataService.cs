using API.DTOs;
using API.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDataService
    {
        DataResponse GetData(int id, int pageSize);
        NewCaseResponse NewData(TypedCase newCase);
    }
}
