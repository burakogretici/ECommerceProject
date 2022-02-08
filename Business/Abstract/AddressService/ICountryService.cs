﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;


namespace Business.Abstract.AddressService
{
    public interface ICountryService 
    {
        IResult Add(Country country);
        IResult Update(Country country);
        IResult Delete(Country country);

        IDataResult<List<Country>> GetAll();
        IDataResult<Country> GetById(int id);
    }
}
