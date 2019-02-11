using BeefKuaforSiram.Core.Domain;
using BeefKuaforSiram.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeefKuaforSiram.Persistence.Repositories
{
    public class KuaforAnketCevapRepository : Repository<KuaforAnketCevap>, IKuaforAnketCevapRepository
    {
        public KuaforAnketCevapRepository(PlutoContext context) : base(context)
        {
        }
        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}