using ClientconvertisseurV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientconvertisseurV1.Services
{
    public interface IService
    {
        Task<List<Devise>> GetDevisesAsync(string nomControleur);
    }
}
