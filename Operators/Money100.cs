using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class Money100 : Money
    {
        public Money100(int count) : base(100, count)
        {
        }
        protected override Money CreateNew(int count)
        {
            return new Money100(count);
        }
    }
    
}
