using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI
{
    public class Services
    {
        private readonly SettingSite _settingSite ;
        public Services(IOptionsSnapshot<SettingSite> settings)
        {
            _settingSite = settings.Value;
        }

        public SettingSite Get()
        {
            return _settingSite;
        }
    }
}
