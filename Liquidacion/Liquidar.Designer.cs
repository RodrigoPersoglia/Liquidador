
namespace Liquidacion
{
    partial class Liquidar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DniTXB = new System.Windows.Forms.TextBox();
            this.BuscarEmpleadoBTN = new System.Windows.Forms.Button();
            this.EmpleadoTBX = new System.Windows.Forms.TextBox();
            this.LegajoTBX = new System.Windows.Forms.TextBox();
            this.buscarConceptoBTN = new System.Windows.Forms.Button();
            this.EliminarBTN = new System.Windows.Forms.Button();
            this.ModificarBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.descripcionTBX = new System.Windows.Forms.TextBox();
            this.IngresaTBX = new System.Windows.Forms.TextBox();
            this.EstrategiaCBX = new System.Windows.Forms.ComboBox();
            this.CancelarBTN = new System.Windows.Forms.Button();
            this.NumConceptoTBX = new System.Windows.Forms.TextBox();
            this.Agregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Cuadro = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExentoTXT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RemunerativoTXT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DescuentosTXT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TotalTXT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.DniTXB);
            this.splitContainer1.Panel1.Controls.Add(this.BuscarEmpleadoBTN);
            this.splitContainer1.Panel1.Controls.Add(this.EmpleadoTBX);
            this.splitContainer1.Panel1.Controls.Add(this.LegajoTBX);
            this.splitContainer1.Panel1.Controls.Add(this.buscarConceptoBTN);
            this.splitContainer1.Panel1.Controls.Add(this.EliminarBTN);
            this.splitContainer1.Panel1.Controls.Add(this.ModificarBTN);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.descripcionTBX);
            this.splitContainer1.Panel1.Controls.Add(this.IngresaTBX);
            this.splitContainer1.Panel1.Controls.Add(this.EstrategiaCBX);
            this.splitContainer1.Panel1.Controls.Add(this.CancelarBTN);
            this.splitContainer1.Panel1.Controls.Add(this.NumConceptoTBX);
            this.splitContainer1.Panel1.Controls.Add(this.Agregar);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(644, 561);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.TabIndex = 12;
            // 
            // DniTXB
            // 
            this.DniTXB.BackColor = System.Drawing.SystemColors.Window;
            this.DniTXB.Location = new System.Drawing.Point(374, 10);
            this.DniTXB.Name = "DniTXB";
            this.DniTXB.ReadOnly = true;
            this.DniTXB.Size = new System.Drawing.Size(104, 20);
            this.DniTXB.TabIndex = 31;
            // 
            // BuscarEmpleadoBTN
            // 
            this.BuscarEmpleadoBTN.Location = new System.Drawing.Point(151, 10);
            this.BuscarEmpleadoBTN.Name = "BuscarEmpleadoBTN";
            this.BuscarEmpleadoBTN.Size = new System.Drawing.Size(50, 20);
            this.BuscarEmpleadoBTN.TabIndex = 30;
            this.BuscarEmpleadoBTN.Text = "Buscar";
            this.BuscarEmpleadoBTN.UseVisualStyleBackColor = true;
            this.BuscarEmpleadoBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmpleadoTBX
            // 
            this.EmpleadoTBX.BackColor = System.Drawing.SystemColors.Window;
            this.EmpleadoTBX.Location = new System.Drawing.Point(207, 10);
            this.EmpleadoTBX.Name = "EmpleadoTBX";
            this.EmpleadoTBX.ReadOnly = true;
            this.EmpleadoTBX.Size = new System.Drawing.Size(161, 20);
            this.EmpleadoTBX.TabIndex = 29;
            // 
            // LegajoTBX
            // 
            this.LegajoTBX.BackColor = System.Drawing.SystemColors.Window;
            this.LegajoTBX.Location = new System.Drawing.Point(95, 10);
            this.LegajoTBX.MaxLength = 8;
            this.LegajoTBX.Name = "LegajoTBX";
            this.LegajoTBX.Size = new System.Drawing.Size(50, 20);
            this.LegajoTBX.TabIndex = 27;
            this.LegajoTBX.TextChanged += new System.EventHandler(this.LegajoTBX_TextChanged);
            this.LegajoTBX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LegajoTBX_KeyDown);
            // 
            // buscarConceptoBTN
            // 
            this.buscarConceptoBTN.Location = new System.Drawing.Point(151, 69);
            this.buscarConceptoBTN.Name = "buscarConceptoBTN";
            this.buscarConceptoBTN.Size = new System.Drawing.Size(50, 20);
            this.buscarConceptoBTN.TabIndex = 25;
            this.buscarConceptoBTN.Text = "Buscar";
            this.buscarConceptoBTN.UseVisualStyleBackColor = true;
            this.buscarConceptoBTN.Click += new System.EventHandler(this.buscarConceptoBTN_Click);
            // 
            // EliminarBTN
            // 
            this.EliminarBTN.Location = new System.Drawing.Point(557, 66);
            this.EliminarBTN.Name = "EliminarBTN";
            this.EliminarBTN.Size = new System.Drawing.Size(75, 23);
            this.EliminarBTN.TabIndex = 7;
            this.EliminarBTN.Text = "Eliminar";
            this.EliminarBTN.UseVisualStyleBackColor = true;
            this.EliminarBTN.Click += new System.EventHandler(this.EliminarBTN_Click);
            // 
            // ModificarBTN
            // 
            this.ModificarBTN.Location = new System.Drawing.Point(557, 36);
            this.ModificarBTN.Name = "ModificarBTN";
            this.ModificarBTN.Size = new System.Drawing.Size(75, 23);
            this.ModificarBTN.TabIndex = 6;
            this.ModificarBTN.Text = "Modificar";
            this.ModificarBTN.UseVisualStyleBackColor = true;
            this.ModificarBTN.Click += new System.EventHandler(this.ModificarBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(187, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Ingresa: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(19, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Ingreso:";
            // 
            // descripcionTBX
            // 
            this.descripcionTBX.BackColor = System.Drawing.SystemColors.Window;
            this.descripcionTBX.Location = new System.Drawing.Point(207, 69);
            this.descripcionTBX.Name = "descripcionTBX";
            this.descripcionTBX.Size = new System.Drawing.Size(161, 20);
            this.descripcionTBX.TabIndex = 3;
            // 
            // IngresaTBX
            // 
            this.IngresaTBX.Location = new System.Drawing.Point(246, 97);
            this.IngresaTBX.MaxLength = 15;
            this.IngresaTBX.Name = "IngresaTBX";
            this.IngresaTBX.Size = new System.Drawing.Size(100, 20);
            this.IngresaTBX.TabIndex = 4;
            this.IngresaTBX.TextChanged += new System.EventHandler(this.cuil2TBX_TextChanged);
            // 
            // EstrategiaCBX
            // 
            this.EstrategiaCBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EstrategiaCBX.FormattingEnabled = true;
            this.EstrategiaCBX.ItemHeight = 13;
            this.EstrategiaCBX.Items.AddRange(new object[] {
            "Por Hora",
            "Por Dia",
            "Por Importe"});
            this.EstrategiaCBX.Location = new System.Drawing.Point(76, 97);
            this.EstrategiaCBX.Name = "EstrategiaCBX";
            this.EstrategiaCBX.Size = new System.Drawing.Size(94, 21);
            this.EstrategiaCBX.TabIndex = 1;
            this.EstrategiaCBX.TextChanged += new System.EventHandler(this.EstrategiaCBX_TextChanged);
            // 
            // CancelarBTN
            // 
            this.CancelarBTN.Location = new System.Drawing.Point(557, 95);
            this.CancelarBTN.Name = "CancelarBTN";
            this.CancelarBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelarBTN.TabIndex = 8;
            this.CancelarBTN.Text = "Cancelar";
            this.CancelarBTN.UseVisualStyleBackColor = true;
            this.CancelarBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // NumConceptoTBX
            // 
            this.NumConceptoTBX.BackColor = System.Drawing.SystemColors.Window;
            this.NumConceptoTBX.Location = new System.Drawing.Point(95, 69);
            this.NumConceptoTBX.MaxLength = 8;
            this.NumConceptoTBX.Name = "NumConceptoTBX";
            this.NumConceptoTBX.Size = new System.Drawing.Size(50, 20);
            this.NumConceptoTBX.TabIndex = 2;
            this.NumConceptoTBX.Text = "0";
            this.NumConceptoTBX.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(557, 7);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(75, 23);
            this.Agregar.TabIndex = 5;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Concepto:";
            // 
            // Cuadro
            // 
            this.Cuadro.AllowUserToAddRows = false;
            this.Cuadro.AllowUserToDeleteRows = false;
            this.Cuadro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cuadro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.numero,
            this.Descripcion,
            this.Cantidad,
            this.Importe,
            this.Exento});
            this.Cuadro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cuadro.Location = new System.Drawing.Point(0, 0);
            this.Cuadro.Name = "Cuadro";
            this.Cuadro.ReadOnly = true;
            this.Cuadro.RowHeadersVisible = false;
            this.Cuadro.Size = new System.Drawing.Size(644, 222);
            this.Cuadro.TabIndex = 0;
            this.Cuadro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cuadro_CellClick);
            // 
            // check
            // 
            this.check.HeaderText = " ";
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 30;
            // 
            // numero
            // 
            this.numero.HeaderText = "Numero";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 60;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 250;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Remunerativo";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // Exento
            // 
            this.Exento.HeaderText = "Exento";
            this.Exento.Name = "Exento";
            this.Exento.ReadOnly = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Cuadro);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.TotalTXT);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.DescuentosTXT);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.RemunerativoTXT);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.ExentoTXT);
            this.splitContainer2.Size = new System.Drawing.Size(644, 435);
            this.splitContainer2.SplitterDistance = 222;
            this.splitContainer2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "Empleado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(473, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "EXENTO";
            // 
            // ExentoTXT
            // 
            this.ExentoTXT.Location = new System.Drawing.Point(532, 36);
            this.ExentoTXT.MaxLength = 15;
            this.ExentoTXT.Name = "ExentoTXT";
            this.ExentoTXT.ReadOnly = true;
            this.ExentoTXT.Size = new System.Drawing.Size(100, 20);
            this.ExentoTXT.TabIndex = 24;
            this.ExentoTXT.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(429, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 27;
            this.label5.Text = "REMUNERATIVO";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // RemunerativoTXT
            // 
            this.RemunerativoTXT.Location = new System.Drawing.Point(532, 10);
            this.RemunerativoTXT.MaxLength = 15;
            this.RemunerativoTXT.Name = "RemunerativoTXT";
            this.RemunerativoTXT.ReadOnly = true;
            this.RemunerativoTXT.Size = new System.Drawing.Size(100, 20);
            this.RemunerativoTXT.TabIndex = 26;
            this.RemunerativoTXT.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(445, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 29;
            this.label7.Text = "DESCUENTOS";
            // 
            // DescuentosTXT
            // 
            this.DescuentosTXT.Location = new System.Drawing.Point(532, 62);
            this.DescuentosTXT.MaxLength = 15;
            this.DescuentosTXT.Name = "DescuentosTXT";
            this.DescuentosTXT.ReadOnly = true;
            this.DescuentosTXT.Size = new System.Drawing.Size(100, 20);
            this.DescuentosTXT.TabIndex = 28;
            this.DescuentosTXT.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(473, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 31;
            this.label8.Text = "TOTAL";
            // 
            // TotalTXT
            // 
            this.TotalTXT.Location = new System.Drawing.Point(532, 88);
            this.TotalTXT.MaxLength = 15;
            this.TotalTXT.Name = "TotalTXT";
            this.TotalTXT.ReadOnly = true;
            this.TotalTXT.Size = new System.Drawing.Size(100, 20);
            this.TotalTXT.TabIndex = 30;
            this.TotalTXT.Text = "0";
            // 
            // Liquidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 561);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Liquidar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidar";
            this.Load += new System.EventHandler(this.Liquidar_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button CancelarBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.ComboBox EstrategiaCBX;
        private System.Windows.Forms.TextBox NumConceptoTBX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descripcionTBX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IngresaTBX;
        private System.Windows.Forms.Button EliminarBTN;
        private System.Windows.Forms.Button ModificarBTN;
        private System.Windows.Forms.DataGridView Cuadro;
        private System.Windows.Forms.Button BuscarEmpleadoBTN;
        private System.Windows.Forms.TextBox EmpleadoTBX;
        private System.Windows.Forms.TextBox LegajoTBX;
        private System.Windows.Forms.Button buscarConceptoBTN;
        private System.Windows.Forms.TextBox DniTXB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TotalTXT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DescuentosTXT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RemunerativoTXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ExentoTXT;
    }
}