using Sistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class ApenasTeste : Form
    {
        public ApenasTeste()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            if (u.Load(1))
                Console.WriteLine("Usuario encontrado: " + u.Nome);
            else
                Console.WriteLine("Usuario nao encontrado");
        }
    }
}
