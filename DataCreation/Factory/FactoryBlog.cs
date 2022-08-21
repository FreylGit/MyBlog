using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCreation.Factory
{
    public class FactoryBlog : FactoryBase<FactoryBlog>
    {
        public FactoryBlog()
        {
            Items = new List<FactoryBlog>();
        }
        public override void Create()
        {
            throw new NotImplementedException();
        }
    }
}
