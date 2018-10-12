using Microsoft.Win32;
using Newtonsoft.Json;
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

namespace cadm
{
    /// <summary>
    /// config.xaml 的交互逻辑
    /// </summary>
    public partial class config : Window
    {
        public config()
        {
            InitializeComponent();
        }

        private bool SaveConfig()
        {
            FileStream fs = new FileStream("cadm.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                CadmConfig cc = new CadmConfig();
                cc.cvi_config = this.cvi_config.Text;
                cc.cvi_net = this.cvi_net.Text;
                cc.odoo = this.odoo.Text;

                cc.cvi_config_args = this.cvi_config_args.Text;
                cc.cvi_net_args = this.cvi_net_args.Text;
                cc.odoo_args = this.odoo_args.Text;

                string configs = JsonConvert.SerializeObject(cc);
                sw.Write(configs);
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sw.Close();
                fs.Close();
            }

            return true;
            
        }

        public void SetParam(string cvi_config, string cvi_net, string odoo, string cvi_config_args, string cvi_net_args, string odoo_args)
        {
            this.cvi_config.Text = cvi_config;
            this.cvi_net.Text = cvi_net;
            this.odoo.Text = odoo;

            this.cvi_config_args.Text = cvi_config_args;
            this.cvi_net_args.Text = cvi_net_args;
            this.odoo_args.Text = odoo_args;
        }

        // 关闭
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // select cvi config
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择文件";
            if (ofd.ShowDialog() == true)
            {
                this.cvi_config.Text = ofd.FileName;
            }
        }

        // select cvi net web
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择文件";
            if (ofd.ShowDialog() == true)
            {
                this.cvi_net.Text = ofd.FileName;
            }
        }

        // select odoo
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择文件";
            if (ofd.ShowDialog() == true)
            {
                this.odoo.Text = ofd.FileName;
            }
        }

        // 保存
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
        
            if (SaveConfig())
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
