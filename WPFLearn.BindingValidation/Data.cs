using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.BindingValidation
{
    public class Data
    {
		private int _value = 10;

		public int Value 
		{
			get { return _value; }
			set { 
				if(value == 123)
				{
					throw new Exception("Exception 123");
				}
				_value = value;
			}
		}

		private string _myName;

		public string MyName
		{
			get { return _myName; }
			set { _myName = value; }
		}


	}
}
