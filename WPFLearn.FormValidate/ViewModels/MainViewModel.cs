using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.FormValidate.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
		private string title = "我是标题";

		public string Title
		{
			get { return title; }
			set {
				if (title != value)
				{
					title = value;
					OnpropertyChanged();
				}
			}
		}

	}
}
