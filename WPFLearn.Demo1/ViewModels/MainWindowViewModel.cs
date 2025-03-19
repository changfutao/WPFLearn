using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.Demo1.Base;

namespace WPFLearn.Demo1.ViewModels
{
    public class MainWindowViewModel: RaisePropertyChange
    {
		// 激活页面标题
		private string pageTitle;

		public string PageTitle
		{
			get { return pageTitle; }
			set { 
				pageTitle = value;
				RaisePropertyChanged(nameof(PageTitle));
			}
		}
		// 菜单树
        public List<Menu> Menus { get; set; }
		// 用户
        public User User { get; set; }

        public MainWindowViewModel()
        {
			Menus = new List<Menu>()
			{
				new Menu{ MenuName = "Dashboard", MenuIcon = "\ue642", MenuPage = "WPFLearn.Demo1.Views.Dashboard"},
				new Menu{ MenuName = "Tool", MenuIcon = "\ue642", MenuPage = "WPFLearn.Demo1.Views.Tool"},
			};
			pageTitle = Menus[0].MenuName;
			User = new User { UserName = "Ross" };
		    ShowPage(Menus[0].MenuPage);

            SwitchPageCommand = new CommandBase
			{
				ActionExecute = new Action<object>(ShowPage)
			};
        }

		private object page;

		public object Page
		{
			get { return page; }
			set { page = value;
				RaisePropertyChanged(nameof(Page));
			}
		}

		private void ShowPage(object page)
		{
			this.PageTitle = this.Menus.FirstOrDefault(a => a.MenuPage == page.ToString())?.MenuName;
            var type = this.GetType().Assembly.GetType(page.ToString());
            var obj = Activator.CreateInstance(type);
            this.Page = obj;
        }


		public CommandBase SwitchPageCommand { get; set; }
    }
}
