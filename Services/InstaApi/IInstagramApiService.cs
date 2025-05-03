using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.InstaApi
{
    public interface IInstagramApiService
    {
        Task<List<InstagramApi>> GetInstagramMediaAsync();
    }
 
}
