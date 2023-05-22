using System;

namespace mvvm_sample.ClientWork.Model
{
    public class Client
    {
        public string LastName { get; set; } = "Стасик";
        public DateTime Birthday { get; set; }  = DateTime.Now.Subtract(TimeSpan.FromDays(10*365));
    }
}
