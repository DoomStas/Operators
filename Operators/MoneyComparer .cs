using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Operators
{
    public class MoneyComparer : IComparer
    {
        public SortMode SortMode { get; }
    
        public MoneyComparer(SortMode sortMode)
        {
            SortMode = sortMode;
        }

        public int Compare(object x, object y)
        { 
            Money a = (Money)x;
            Money b = (Money)y;

            if (SortMode == SortMode.Ascending)
                return a.Nominal.CompareTo(b.Nominal);
            else
                return b.Nominal.CompareTo(a.Nominal);
        }
    }
}
