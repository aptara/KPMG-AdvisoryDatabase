using AdvisoryDatabase.Business.Repository;
using AdvisoryDatabase.DataAccess.DataAccessService;
using AdvisoryDatabase.Framework.Entities;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AdvisoryDatabase.Business.Service.API
{
  public class TaskService : Repository<Task, Int32>
  {
    protected override DataAccess.Repository.DataAccessRepository<Task, int> CreateDalManager()
    {
      return new DataAccessTaskLocation();
    }
  }

  public class LocationService : Repository<LocationDetail, Int32>
  {
    protected override DataAccess.Repository.DataAccessRepository<LocationDetail, int> CreateDalManager()
    {
      return new DataAccessLocation();
    }
  }
}
