﻿using DI2P1G6.Booking.Repository.Contract;
using DI2P1G6.Booking.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P1G6.Booking.Service
{
    public class TypesService(ITypesRepository typesRepository) : ITypesService
    {
        public List<DataModel.Type> GetAll()
        {
            return typesRepository.GetAll();
        }
    }
}
