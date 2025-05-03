using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public interface IApiServices
    {
        Task<List<ApiData>> GetAllAsync();
        Task<ApiData> GetByIdAsync(string productId);
    }
}
