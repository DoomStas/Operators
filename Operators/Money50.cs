using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class Money50 : Money
    {
        public Money50(int count) : base(50, count)
        {
        }
        protected override Money CreateNew(int count)
        {
            return new Money50(count);
        }
    }
    
}
