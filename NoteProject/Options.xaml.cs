using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoteProject
{
    /// <summary>
    /// Logika interakcji dla klasy Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        private NoteClassLibrary.Model.Options options;
        public Options(NoteClassLibrary.Model.Options options)
        {
            this.options = options;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            options.Filename = filename.Text;
            XMLOptions.Save(NoteClassLibrary.Model.Options.RootOptions, options);
            Close();
        }
    }
}
