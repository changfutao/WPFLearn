using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.SingleValueConverter
{
    class Data
    {
        public string Title { get; set; } = "我是标题";

		/// <summary>
		/// 性别 1 男 2 女 3 未知
		/// </summary>
		private int gender = 1;

		public int Gender
		{
			get { return gender; }
			set { gender = value; }
		}
		public DateTime DateNow { get; set; } = DateTime.Now;
    }
}
