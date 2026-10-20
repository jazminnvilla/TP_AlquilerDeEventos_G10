
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

            var opciones = new DbContextOptionsBuilder<AlquileresContext>()
                .UseSqlServer(
                    @"Server=(localdb)\MSSQLLocalDB;Database=AlquilerDeEventosDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            _context = new AlquileresContext(opciones);
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
