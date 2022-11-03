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
using System.Reflection;

namespace ClientEmployee
{
    public partial class Form1 : Form
    {
        MiddleEmploye.RPC rpc;
        int selectedItem ;
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
        private void listView1_Click (object sender, EventArgs e)
        {
            selectedItem = listView1.SelectedIndices[0];
            txtNom.Text = listView1.Items[selectedItem].SubItems[1].Text;
            txtPrenom.Text = listView1.Items[selectedItem].SubItems[2].Text;
            txtSalaire.Text = listView1.Items[selectedItem].SubItems[3].Text;
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            rpc.remplir(txtCIN.Text, txtNom.Text, txtPrenom.Text, double.Parse(txtSalaire.Text));
            listView1.Items.Add(new ListViewItem
                (new String[] { rpc.cin, rpc.nom, rpc.prenom, rpc.salaire.ToString() }));

            txtCIN.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
            txtSalaire.Clear();

        }

        private void btnAugSalaire_Click(object sender, EventArgs e)
        {
            selectedItem = listView1.SelectedIndices[0];
            rpc.remplir(listView1.Items[selectedItem].SubItems[0].Text,
                            listView1.Items[selectedItem].SubItems[1].Text,
                            listView1.Items[selectedItem].SubItems[2].Text,
                            float.Parse(listView1.Items[selectedItem].SubItems[3].Text)
                            );

            rpc.augmenterSalaire();
            listView1.Items[selectedItem].SubItems[3].Text = rpc.salaire.ToString();    
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            listView1.Items[selectedItem].SubItems[1].Text = txtNom.Text;

            listView1.Items[selectedItem].SubItems[2].Text = txtPrenom.Text ;
            listView1.Items[selectedItem].SubItems[3].Text = txtSalaire.Text ;

            txtCIN.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
            txtSalaire.Clear();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            listView1.Items[selectedItem].Remove();
            txtCIN.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
            txtSalaire.Clear();
        }
    }
}
