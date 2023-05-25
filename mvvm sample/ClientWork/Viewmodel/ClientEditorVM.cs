using mvvm_sample.ClientWork.DBnamespace;
using mvvm_sample.ClientWork.Model;
using mvvm_sample.ClientWork.View;
using mvvm_sample.mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_sample.ClientWork.ViewModel
{
    public class ClientEditorVM : BaseVM
    {
        private Client client;

        public Client Client { 
            get => client;
            set
            {
                client = value;
                Signal();
            }
        }

        public VMCommand Save { get; set; }

        public ClientEditorVM(DB dB)
        {
           

            Save = new VMCommand(() =>
            {
                MainVM.ChangePage(new ClientList());
            },
            () => Client != null
            );
        }

        internal override void Update()
        {
            Client = EditClient.Edit;
        }
    }
}
