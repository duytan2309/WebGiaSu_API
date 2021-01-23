using Lib.Data.Entities;
using Lib.Domain.ViewModel.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Domain.Proceduce.Interfaces
{
    public interface ITestInterface
    {
        List<Color> TestData(ColorViewModel model);
    }
}
