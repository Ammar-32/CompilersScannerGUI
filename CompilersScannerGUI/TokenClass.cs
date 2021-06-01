using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersDesign
{
    class Token
    {
        private string _item;
        private string _type;

        public Token(string item, string type)
        {
            Item = item;
            Type = type;
        }

        public string Item
        {
            set { _item = value; }
            get { return _item; }
        }
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }

        public override string ToString()
        {
            return Item + " : " + Type + "\n\r";
        }
    }
}
