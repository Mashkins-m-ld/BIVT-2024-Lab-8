using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        //поля 
        private string _output;
        private (string, char)[] _codes;

        //свойства 
        public string Output => _output;
        public (string, char)[] Codes
        {
            get
            {
                if (_codes == null) return null;
                (string, char)[] copy = new (string, char)[_codes.Length];
                Array.Copy(_codes, copy, _codes.Length);
                return copy;
            }
        }



        //конструктор 
        public Purple_4(string input, (string, char)[] codes) : base(input)
        {
            _output = default(string); //до вызова ревью output будет возвращать базовое значение
            _codes = new (string, char)[codes.Length];
            Array.Copy(codes, _codes,codes.Length);
        }

        //методы
        public override void Review()
        {
            if (_input == null) return;

            string result = _input;
            for (int i = 0; i < _codes.Length; i++)
            {
                result = result.Replace(""+_codes[i].Item2, ""+_codes[i].Item1);
            }
            _output = result;

            
        }

        public override string ToString()
        {
            return _output;

        }


    }
}
