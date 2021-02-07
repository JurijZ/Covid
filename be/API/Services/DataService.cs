using API.DTOs;
using API.Interfaces;
using API.POCOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class DataService : IDataService
    {
        private IConfiguration configuration { get; }
        private IRepositoryService repository;
        public DataService(IConfiguration configuration, IRepositoryService repository)
        {
            this.configuration = configuration;
            this.repository = repository;
        }

        public DataResponse GetData(int id, int pageSize)
        {
            var allItemsCount = repository.GetDataSize();
            var data = repository.GetDataPartition(id, pageSize);

            DataResponse dataResponse = new DataResponse
            {
                Data = data.ToList(),
                AllItemsCount = allItemsCount,
                MaxId = data.OrderByDescending(x=> x.object_id).FirstOrDefault().object_id + 1 ?? 1,
                PageSize = pageSize
            };

            return dataResponse;
        }

        public NewCaseResponse NewData(TypedCase newCase)
        {
            int id = repository.SaveNewCase(newCase);

            return new NewCaseResponse(){ Id = id};
        }
    }
}
