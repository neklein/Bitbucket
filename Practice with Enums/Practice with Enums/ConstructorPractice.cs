using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class ConstructorPractice
    {
        private DateTime _createDate;
        public DateTime CreateDate { get { return _createDate; } }

        public ConstructorPractice()
        {
            _createDate = DateTime.Now;
        }
    }
}
