using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    public class Money10 : Money
    {
        public Money10(int count) : base(10, count)
        {
        }
        protected override Money CreateNew(int count)
        {
            return new Money10(count);
        }
    }
}
