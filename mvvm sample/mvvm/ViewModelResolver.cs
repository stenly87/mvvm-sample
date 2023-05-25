using mvvm_sample.ClientWork.DBnamespace;
using mvvm_sample.ClientWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace mvvm_sample.mvvm
{
    public class ViewModelResolver : MarkupExtension
    {
        static DB db = new DB();

        static Dictionary<Type, BaseVM> map = new Dictionary<Type, BaseVM>();

        public Type VMType { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (!map.ContainsKey(VMType))
                map.Add(VMType, (BaseVM)Activator.CreateInstance(VMType, db));
            map[VMType].Update();
            return map[VMType];
        }
    }
}
