
namespace AlquilerDeEeventos.WinForms
{
    partial class Form1
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
            lblnombre = new Label();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnListar = new Button();
            dgvCategorias = new DataGridView();
            txtNombre = new TextBox();

            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();

            // lblnombre
            lblnombre.AutoSize = true;
            lblnombre.Location = new Point(108, 24);
            lblnombre.Name = "lblnombre";
            lblnombre.Size = new Size(134, 15);
            lblnombre.TabIndex = 0;
            lblnombre.Text = "Nombre de la categoria:";

            // btnAgregar
            btnAgregar.Location = new Point(48, 99);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(134, 41);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;

            // btnModificar
            btnModificar.Location = new Point(220, 99);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(134, 41);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;

            // btnEliminar
            btnEliminar.Location = new Point(394, 99);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(134, 41);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;

            // btnListar
            btnListar.Location = new Point(566, 99);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(134, 41);
            btnListar.TabIndex = 4;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;

            // dgvCategorias
            dgvCategorias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(48, 152);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(652, 211);
            dgvCategorias.TabIndex = 6;

            // txtNombre
            txtNombre.Location = new Point(92, 54);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(570, 23);
            txtNombre.TabIndex = 8;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);

            Controls.Add(txtNombre);
            Controls.Add(dgvCategorias);
            Controls.Add(btnListar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(lblnombre);

            Name = "Form1";
            Text = "Gestión de categorías";

            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblnombre;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnListar;
        private DataGridView dgvCategorias;
        private TextBox txtNombre;
    }
}
