using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace cadm
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public struct CadmConfig
    {
        public string cvi_config { get; set; }
        public string cvi_config_args { get; set; }
        public string cvi_net { get; set; }
        public string cvi_net_args { get; set; }
        public string odoo { get; set; }
        public string odoo_args { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _cvi_config = "";
            _cvi_config_args = "";
            _cvi_net = "";
            _cvi_net_args = "";
            _odoo = "";
            _odoo_args = "";

            LoadConfig();
        }

        private void LoadConfig()
        {
            FileStream fs = new FileStream("cadm.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string configs = sr.ReadToEnd();

            if (configs != "")
            {
                CadmConfig cc = JsonConvert.DeserializeObject<CadmConfig>(configs);

                _cvi_config = cc.cvi_config;
                _cvi_config_args = cc.cvi_config_args;
                _cvi_net = cc.cvi_net;
                _cvi_net_args = cc.cvi_net_args;
                _odoo = cc.odoo;
                _odoo_args = cc.odoo_args;
            }
        }

        // cvi config
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_cvi_config != "")
            {
                Process.Start(_cvi_config, _cvi_config_args);
            }
        }

        // cvi net web
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_cvi_net != "")
            {
                Process.Start(_cvi_net, _cvi_net_args);
            }
        }

        // odoo
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_odoo != "")
            {
                Process.Start(_odoo, _odoo_args);
            }
        }

        // 配置
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            config c = new config();
            c.SetParam(_cvi_config, _cvi_net, _odoo, _cvi_config_args, _cvi_net_args, _odoo_args);
            c.ShowDialog();

            _cvi_config = c.cvi_config.Text;
            _cvi_net = c.cvi_net.Text;
            _odoo = c.odoo.Text;

            _cvi_config_args = c.cvi_config_args.Text;
            _cvi_net_args = c.cvi_net_args.Text;
            _odoo_args = c.odoo_args.Text;
        }

        private string _cvi_config;
        private string _cvi_config_args;
        private string _cvi_net;
        private string _cvi_net_args;
        private string _odoo;
        private string _odoo_args;
    }
}
