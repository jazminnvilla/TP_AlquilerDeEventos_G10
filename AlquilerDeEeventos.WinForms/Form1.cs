
using AlquilerDeEventos.Datos;
using AlquilerDeEventos.Datos.Contexto;
using AlquilerDeEventos.Datos.Modelo;
using AlquilerDeEventos.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace AlquilerDeEeventos.WinForms
{
    public partial class Form1 : Form
    {
        private readonly AlquileresContext _context;
        private readonly CategoriaRepositorio _repositorio;

        private int categoriaSeleccionadaId = 0;

        public Form1()
        {
            InitializeComponent();

            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "AlquilerDeEventos.db");

            var opciones = new DbContextOptionsBuilder<AlquileresContext>()
                .UseSqlite($"Data Source={ruta}")
                .Options;

            _context = new AlquileresContext(opciones);

            // Cargamos datos ficticios para probar los reportes.
            // La clase DatosDePrueba evita repetir la carga.
            DatosDePrueba.Cargar(_context);

            _repositorio = new CategoriaRepositorio(_context);

            btnAgregar.Click += btnAgregar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnListar.Click += btnListar_Click;
            dgvCategorias.CellClick += dgvCategorias_CellClick;

            dgvCategorias.ReadOnly = true;
            dgvCategorias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            CargarCategorias();

            // Creamos el botón Ver reportes desde código.
            Button btnVerReportes = new Button();

            btnVerReportes.Name = "btnVerReportes";
            btnVerReportes.Text = "Ver reportes";
            btnVerReportes.Size = new Size(140, 35);

            btnVerReportes.Location = new Point(
                dgvCategorias.Left,
                dgvCategorias.Bottom + 15
            );

            int alturaNecesaria = btnVerReportes.Bottom + 20;

            if (ClientSize.Height < alturaNecesaria)
            {
                ClientSize = new Size(
                    ClientSize.Width,
                    alturaNecesaria
                );
            }

            Controls.Add(btnVerReportes);
            btnVerReportes.Click += btnVerReportes_Click;
        }

        private void CargarCategorias()
        {
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = _repositorio.ObtenerTodos();

            dgvCategorias.ClearSelection();
            categoriaSeleccionadaId = 0;
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresá un nombre.");
                return;
            }

            Categoria categoria = new Categoria
            {
                Nombre = txtNombre.Text.Trim()
            };

            _repositorio.Agregar(categoria);

            MessageBox.Show("Categoría agregada correctamente.");
            Limpiar();
            CargarCategorias();
        }

        private void btnModificar_Click(object? sender, EventArgs e)
        {
            if (categoriaSeleccionadaId == 0)
            {
                MessageBox.Show("Seleccioná una categoría.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresá un nombre.");
                return;
            }

            Categoria categoria = new Categoria
            {
                Id = categoriaSeleccionadaId,
                Nombre = txtNombre.Text.Trim()
            };

            _repositorio.Modificar(categoria);

            MessageBox.Show("Categoría modificada correctamente.");
            Limpiar();
            CargarCategorias();
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (categoriaSeleccionadaId == 0)
            {
                MessageBox.Show("Seleccioná una categoría.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que querés eliminar esta categoría?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    _repositorio.Eliminar(categoriaSeleccionadaId);

                    MessageBox.Show("Categoría eliminada correctamente.");
                    Limpiar();
                    CargarCategorias();
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show(
                        "No se puede eliminar porque tiene elementos relacionados.");
                }
            }
        }

        private void btnListar_Click(object? sender, EventArgs e)
        {
            Limpiar();
            CargarCategorias();
        }

        private void dgvCategorias_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvCategorias.Rows[e.RowIndex].DataBoundItem
                is Categoria categoria)
            {
                categoriaSeleccionadaId = categoria.Id;
                txtNombre.Text = categoria.Nombre;
            }
        }

        private void btnVerReportes_Click(
            object? sender, EventArgs e)
        {
            using (FormReportes ventana = new FormReportes())
            {
                ventana.ShowDialog();
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            categoriaSeleccionadaId = 0;
            dgvCategorias.ClearSelection();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}
