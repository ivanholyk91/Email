using ParkingPass.Student.Infrastructure.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPass.Student.Infrastructure.REST.Interfaces
{
    public interface IHttpService
    {
        Task<T> GetRequest<T>(string controller, string method, string parametrs,string value, string token = null);
        Task<T> PostRequest<T>(string controller, string method, ContentType type, string token = null, object obj = null);
    }
}
