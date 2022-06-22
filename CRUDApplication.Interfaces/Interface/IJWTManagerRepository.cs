using CRUDApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplication.Interfaces.Interface
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
