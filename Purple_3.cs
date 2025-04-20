using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
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
                Array.Copy(_codes,copy, _codes.Length); 
                return copy;
            }
        }



        //конструктор 
        public Purple_3(string input) : base(input)
        {
            _output = default(string); //до вызова ревью output будет возвращать базовое значение
            _codes = new (string, char)[] { };
        }

        //методы
        public override void Review()
        {
            if (_input == null) return ;
            //кортеж сочетаний
            (string, int)[] combUnic = new (string, int)[] { };

            //все уникальные символы строки
            string chars = "" + _input[0];

            string result = string.Copy(_input);

            for (int i = 0; i < _input.Length - 1; i++)
            {


                if (!chars.Contains(_input[i + 1]) && char.IsLetter(_input[i+1]))
                {
                    chars += _input[i + 1];
                }

                if ( !(char.IsLetter(_input[i]) && char.IsLetter(_input[i + 1]) ) ) continue;
                

                string twoCh = "" + _input[i] + _input[i + 1];

                //ищем есть ли такая комбинация уже 
                bool flag = false;

                for (int j = 0; j < combUnic.Length; j++)
                {
                    if (combUnic[j].Item1 == twoCh)
                    {
                        flag = true;
                        combUnic[j].Item2 += 1;
                        break;
                    }
                }

                if (!flag) //нет такой комбинации 
                {
                    Array.Resize(ref combUnic, combUnic.Length + 1);
                    combUnic[combUnic.Length - 1].Item1 = twoCh;
                    combUnic[combUnic.Length - 1].Item2 = 1;
                }
            }

            //сортировка

            for (int i = 0; i < combUnic.Length; i++)
            {
                for (int j = 0; j < combUnic.Length - 1 - i; j++)
                {
                    if (combUnic[j].Item2 < combUnic[j + 1].Item2)
                    {
                        (string, int) copy = (combUnic[j + 1].Item1, combUnic[j + 1].Item2);
                        combUnic[j + 1] = combUnic[j];
                        combUnic[j] = copy;
                    }
                }
            }

            
            if (combUnic.Length > 5)
            {
                Array.Resize(ref combUnic, 5);
            }


            for (int i = 0; i < 5; i++)
            {
                
                //ищем чем можем заменить 
     
                for (int j = 33; j < 127; j++)
                {
                    if (!chars.Contains((char)j))
                    {
                        result = result.Replace(combUnic[i].Item1, "" + (char)j);
                        Array.Resize(ref _codes, _codes.Length + 1);
                        _codes[_codes.Length - 1] = (combUnic[i].Item1, (char)j);
                        chars += (char)j;
                        break;
                    }
                }
            }

            _output = result;
        }

        public override string ToString()
        {
            return _output;

        }


    }
}
