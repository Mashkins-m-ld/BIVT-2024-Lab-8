using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public abstract class Purple
    {
        //поля
        protected string _input;

        //свойства
        public string Input => _input;

        //конструктор 
        public Purple(string input)
        {
            _input = input;
        }

        //методы 
        public abstract void Review();

    }
}
