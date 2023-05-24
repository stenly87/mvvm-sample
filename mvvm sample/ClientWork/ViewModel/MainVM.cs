using mvvm_sample.ClientWork.View;
using mvvm_sample.mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace mvvm_sample.ClientWork.ViewModel
{
    public class MainVM : BaseVM
    {
        static MainVM instance;
        private Page currentPage;

        public Page CurrentPage
        {
            get => currentPage;
            set
            { 
                currentPage = value;
                Signal();
            }
        }

        public static void ChangePage(Page page)
        {
            instance.CurrentPage = page;
        }

        public MainVM()
        {
            instance = this;
            CurrentPage = new ClientList();
        }
    }
}
