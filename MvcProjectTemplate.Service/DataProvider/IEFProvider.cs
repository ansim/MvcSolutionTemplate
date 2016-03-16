using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.Composition;
using $ext_safeprojectname$.Data;

namespace $safeprojectname$
{
    [InheritedExport(typeof(IEFProvider))]
    public interface IEFProvider
    {
        ApplicationDbContext DbContext { get; }
    }
}
