
using Lib.Data.Entities;
using Lib.Domain.EF.Interfaces;
using Lib.Domain.Proceduce.Interfaces;
using Lib.Domain.ViewModel.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Domain.Proceduce.Repositories
{
    public class TestRepository : ITestInterface
    {
        private IDapper _dapper;
        public TestRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public List<Color> TestData(ColorViewModel model)
        {
            return _dapper.ExecProcedureData<Color>("NameController_Color_GetList", new
            {
                model.P_Name
            }).ToList();
        }
    }
}
