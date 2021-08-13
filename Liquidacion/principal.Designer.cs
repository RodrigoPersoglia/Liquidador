
namespace Liquidacion
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libroDeSueldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obraSocialToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.conceptosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.conveniosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empleadosToolStripMenuItem,
            this.novedadesToolStripMenuItem,
            this.liquidacionToolStripMenuItem,
            this.libroDeSueldosToolStripMenuItem,
            this.empresaToolStripMenuItem,
            this.categoriasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.listadoToolStripMenuItem});
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // listadoToolStripMenuItem
            // 
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            this.listadoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.listadoToolStripMenuItem.Text = "Listado";
            // 
            // novedadesToolStripMenuItem
            // 
            this.novedadesToolStripMenuItem.Name = "novedadesToolStripMenuItem";
            this.novedadesToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.novedadesToolStripMenuItem.Text = "Novedades";
            // 
            // liquidacionToolStripMenuItem
            // 
            this.liquidacionToolStripMenuItem.Name = "liquidacionToolStripMenuItem";
            this.liquidacionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.liquidacionToolStripMenuItem.Text = "Liquidacion";
            // 
            // libroDeSueldosToolStripMenuItem
            // 
            this.libroDeSueldosToolStripMenuItem.Name = "libroDeSueldosToolStripMenuItem";
            this.libroDeSueldosToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.libroDeSueldosToolStripMenuItem.Text = "Libro de Sueldos";
            // 
            // empresaToolStripMenuItem
            // 
            this.empresaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosToolStripMenuItem,
            this.sucursalesToolStripMenuItem,
            this.turnosToolStripMenuItem});
            this.empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            this.empresaToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.empresaToolStripMenuItem.Text = "Empresa";
            // 
            // datosToolStripMenuItem
            // 
            this.datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            this.datosToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.datosToolStripMenuItem.Text = "Datos";
            this.datosToolStripMenuItem.Click += new System.EventHandler(this.datosToolStripMenuItem_Click);
            // 
            // sucursalesToolStripMenuItem
            // 
            this.sucursalesToolStripMenuItem.Name = "sucursalesToolStripMenuItem";
            this.sucursalesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sucursalesToolStripMenuItem.Text = "Sucursales";
            this.sucursalesToolStripMenuItem.Click += new System.EventHandler(this.sucursalesToolStripMenuItem_Click);
            // 
            // turnosToolStripMenuItem
            // 
            this.turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            this.turnosToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.turnosToolStripMenuItem.Text = "Turnos";
            this.turnosToolStripMenuItem.Click += new System.EventHandler(this.turnosToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.obraSocialToolStripMenuItem1,
            this.conceptosToolStripMenuItem1,
            this.conveniosToolStripMenuItem});
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.categoriasToolStripMenuItem.Text = "Tablas Auxiliares";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editarToolStripMenuItem.Text = "Categorias";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // obraSocialToolStripMenuItem1
            // 
            this.obraSocialToolStripMenuItem1.Name = "obraSocialToolStripMenuItem1";
            this.obraSocialToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.obraSocialToolStripMenuItem1.Text = "Obra Social";
            this.obraSocialToolStripMenuItem1.Click += new System.EventHandler(this.obraSocialToolStripMenuItem1_Click);
            // 
            // conceptosToolStripMenuItem1
            // 
            this.conceptosToolStripMenuItem1.Name = "conceptosToolStripMenuItem1";
            this.conceptosToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.conceptosToolStripMenuItem1.Text = "Conceptos";
            this.conceptosToolStripMenuItem1.Click += new System.EventHandler(this.conceptosToolStripMenuItem1_Click);
            // 
            // conveniosToolStripMenuItem
            // 
            this.conveniosToolStripMenuItem.Name = "conveniosToolStripMenuItem";
            this.conveniosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.conveniosToolStripMenuItem.Text = "Convenios";
            this.conveniosToolStripMenuItem.Click += new System.EventHandler(this.conveniosToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Liquidacion.Properties.Resources.FONDO_3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Liquidacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novedadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libroDeSueldosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucursalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obraSocialToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem conceptosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem conveniosToolStripMenuItem;
    }
}

