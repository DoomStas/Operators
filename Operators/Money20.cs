using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class Money20 : Money
    {
        public Money20(int count) : base(20, count)
        {
        }
        protected override Money CreateNew(int count)
        {
            return new Money20(count);
        }
    }
    
}
