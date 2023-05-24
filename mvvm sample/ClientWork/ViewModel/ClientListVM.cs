using mvvm_sample.ClientWork.Model;
using mvvm_sample.ClientWork.View;
using mvvm_sample.mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_sample.ClientWork.ViewModel
{
    public class ClientListVM : BaseVM
    {
        private Client selectedClient;

        public ObservableCollection<Client> Clients { get; set; }

        public VMCommand AddClient { get; set; }
        public VMCommand<Client> EditClient { get; set; }

        public Client SelectedClient { 
            get => selectedClient;
            set
            {
                selectedClient = value;
                Signal();
            }
        }

        public ClientListVM()
        {
            Clients = new ObservableCollection<Client>(
                ClientDB.GetInstance().LoadClients());

            AddClient = new VMCommand(() =>
            {
                var client = new Client();
                Clients.Add(client);
                ClientDB.GetInstance().Add(client);
            });

            EditClient = new VMCommand<Client>(s =>
            {
                Model.EditClient.Edit = s;
                MainVM.ChangePage(new ClientEditor());
            }, 
            s => s != null);

        }
    }
}
