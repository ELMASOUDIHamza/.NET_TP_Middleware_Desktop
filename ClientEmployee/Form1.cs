using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEmployee
{
    public partial class Form1 : Form
    {
        MiddleEmploye.RPC rpc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TcpChannel tcpChannel = new TcpChannel();
            ChannelServices.RegisterChannel(tcpChannel, false);
            rpc = (MiddleEmploye.RPC)Activator.GetObject(typeof(MiddleEmploye.RPC),
                "tcp://127.0.0.1:1234/emp") ;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            rpc.remplir(txtCIN.Text, txtNom.Text, txtPrenom.Text, double.Parse(txtSalaire.Text));
            listView1.Items.Add(new ListViewItem
                (new String[] { rpc.cin, rpc.nom, rpc.prenom, rpc.salaire.ToString() }));
        }
    }
}
