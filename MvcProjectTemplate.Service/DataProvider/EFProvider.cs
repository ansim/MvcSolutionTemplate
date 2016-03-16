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
    [Export]
    public class EFProvider : IEFProvider
    {
        private ApplicationDbContext _DbContext;
        public EFProvider()
        {
            this._DbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext DbContext
        {
            get
            {
                return _DbContext;
            }
        }
    }
}
