﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Abstract.UserDal
{
    public interface IOperationClaimDal : IEntityRepository<OperationClaim>
    {
    }
}
