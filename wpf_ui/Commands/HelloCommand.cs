using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpf_ui.Commands
{
    public class HelloCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show("Hello world message!");
        }
    }
}
