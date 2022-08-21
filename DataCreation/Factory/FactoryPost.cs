using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCreation.Factory
{
    public class FactoryPost : FactoryBase<FactoryPost>
    {
        public FactoryPost()
        {
            Items = new List<FactoryPost>();
        }
        public override void Create()
        {
            throw new NotImplementedException();
        }
    }
}
