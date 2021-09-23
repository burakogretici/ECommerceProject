﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract.AddressDal
{
    public interface IAddressDal : IEntityRepository<Address>
    {
        List<AddressDetailDto> GetAddressDetails();
    }
}
