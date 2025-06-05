using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShellPOC.ViewModels;

namespace ShellPOC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class FullDrawerPage : Drawer<FullDrawerViewModel>
{
    public FullDrawerPage(FullDrawerViewModel fullDrawerViewModel)
        : base(fullDrawerViewModel)
    {
        InitializeComponent();
    }
}