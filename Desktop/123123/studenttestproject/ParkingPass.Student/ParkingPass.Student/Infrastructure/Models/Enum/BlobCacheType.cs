using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPass.Student.Infrastructure.Models.Enum
{
    public enum BlobCacheType : byte
    {
        LocalMachine,
        Secure,
        UserAccount,
        InMemory
    }
}
