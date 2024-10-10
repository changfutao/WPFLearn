using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.BindingParameters
{
    class Data
    {
        public string? Title { get; set; } = null;
		private int total = 10;

		public int Total
		{
			get { return total; }
			set {
				if (total == value) return;
				if (value > 100)
			    {
					total = value * 2;
				}
				else
				{

					total = value;
				}
			}
		}

	}
}
