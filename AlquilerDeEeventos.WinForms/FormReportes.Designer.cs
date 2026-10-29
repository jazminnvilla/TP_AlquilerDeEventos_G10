
namespace AlquilerDeEeventos.WinForms
{
    partial class FormReportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            cbmReportes = new ComboBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnReportes = new Button();
            dgvReportes = new DataGridView();
            lblResultados = new Label();
            lblHasta = new Label();
            lblDesde = new Label();

            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();

            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(109, 44);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(122, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reportes de alquileres";

            //
            // cbmReportes
            //
            cbmReportes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmReportes.FormattingEnabled = true;
            cbmReportes.Location = new Point(250, 44);
            cbmReportes.Name = "cbmReportes";
            cbmReportes.Size = new Size(310, 23);
            cbmReportes.TabIndex = 1;

            //
            // dtpDesde
            //
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(152, 102);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(245, 23);
            dtpDesde.TabIndex = 2;

            //
            // dtpHasta
            //
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(449, 102);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(245, 23);
            dtpHasta.TabIndex = 3;

            //
            // btnReportes
            //
            btnReportes.Location = new Point(344, 149);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(152, 29);
            btnReportes.TabIndex = 4;
            btnReportes.Text = "Generar reporte";
            btnReportes.UseVisualStyleBackColor = true;

            //
            // dgvReportes
            //
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;
            dgvReportes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(74, 225);
            dgvReportes.MultiSelect = false;
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.Size = new Size(689, 270);
            dgvReportes.TabIndex = 5;

            //
            // lblResultados
            //
            lblResultados.AutoSize = true;
            lblResultados.Location = new Point(74, 202);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(140, 15);
            lblResultados.TabIndex = 6;
            lblResultados.Text = "Resultados de la consulta";

            //
            // lblHasta
            //
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(449, 84);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(69, 15);
            lblHasta.TabIndex = 7;
            lblHasta.Text = "Fecha hasta";

            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(152, 84);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(72, 15);
            lblDesde.TabIndex = 8;
            lblDesde.Text = "Fecha desde";

            //
            // FormReportes
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);

            Controls.Add(lblDesde);
            Controls.Add(lblHasta);
            Controls.Add(lblResultados);
            Controls.Add(dgvReportes);
            Controls.Add(btnReportes);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(cbmReportes);
            Controls.Add(lblTitulo);

            Name = "FormReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes de alquileres";

            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private ComboBox cbmReportes;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnReportes;
        private DataGridView dgvReportes;
        private Label lblResultados;
        private Label lblHasta;
        private Label lblDesde;
    }
}
