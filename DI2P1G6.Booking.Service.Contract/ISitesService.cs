using DI2P1G6.Booking.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P1G6.Booking.Service.Contract
{
    public interface ISitesService
    {
        List<Site> GetAll();

    }

}
