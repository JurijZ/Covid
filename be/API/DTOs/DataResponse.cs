using API.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class DataResponse
    {
        public List<TypedCase> Data { get; set; }
        public int AllItemsCount { get; set; }
        public int MaxId { get; set; }
        public int PageSize { get; set; }
    }
}
