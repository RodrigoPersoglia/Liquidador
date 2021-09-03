using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquidacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarEmpleado agregar = new AgregarEmpleado();
            agregar.MdiParent = this;
            agregar.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.MdiParent = this;
            cat.Show();
        }

        //private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        //{

        //}

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turno turno = new Turno();
            turno.MdiParent = this;
            turno.Show();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sucursal suc = new Sucursal();
            suc.MdiParent = this;
            suc.Show();
        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();
            empresa.MdiParent = this;
            empresa.Show();
        }

        private void obraSocialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            obraSocial os = new obraSocial();
            os.MdiParent = this;
            os.Show();
        }

        private void conveniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Convenio conv = new Convenio();
            conv.MdiParent = this;
            conv.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarEmpleado mod = new ModificarEmpleado();
            mod.MdiParent = this;
            mod.Show();
        }

        private void conceptosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConceptoCrud concepto = new ConceptoCrud();
            concepto.MdiParent = this;
            concepto.Show();
        }

        private void liquidarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liquidar liquidacion = new Liquidar();
            liquidacion.MdiParent = this;
            liquidacion.Show();

        }
    }
}
