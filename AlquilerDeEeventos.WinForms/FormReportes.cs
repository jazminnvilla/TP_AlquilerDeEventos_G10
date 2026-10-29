
using AlquilerDeEventos.Datos.Contexto;
using AlquilerDeEventos.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace AlquilerDeEeventos.WinForms
{
    public partial class FormReportes : Form
    {
        private readonly AlquileresContext _context;
        private readonly ReporteRepositorio _reportes;

        public FormReportes()
        {
            InitializeComponent();

            // Usamos la misma ubicación SQLite que Form1.
            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "AlquilerDeEventos.db");

            var opciones = new DbContextOptionsBuilder<AlquileresContext>()
                .UseSqlite($"Data Source={ruta}")
                .Options;

            _context = new AlquileresContext(opciones);
            _reportes = new ReporteRepositorio(_context);

            // Cargamos las cinco opciones del ComboBox.
            cbmReportes.Items.Clear();
            cbmReportes.Items.Add("Disponibilidad por fecha");
            cbmReportes.Items.Add("Reservas pendientes");
            cbmReportes.Items.Add("Alquileres entre fechas");
            cbmReportes.Items.Add("Elementos más alquilados");
            cbmReportes.Items.Add("Pendientes de devolución");

            cbmReportes.SelectedIndex = 0;

            // Configuración de la tabla.
            dgvReportes.ReadOnly = true;
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;

            // Conexión de los eventos.
            btnReportes.Click += btnReportes_Click;
            cbmReportes.SelectedIndexChanged +=
                cbmReportes_SelectedIndexChanged;

            ActualizarFechas();
        }

        private void cbmReportes_SelectedIndexChanged(
            object? sender, EventArgs e)
        {
            ActualizarFechas();
            dgvReportes.DataSource = null;
            lblResultados.Text = "Resultados de la consulta";
        }

        private void ActualizarFechas()
        {
            int opcion = cbmReportes.SelectedIndex;

            // Disponibilidad: una fecha.
            // Alquileres entre fechas: dos fechas.
            dtpDesde.Enabled = opcion == 0 || opcion == 2;
            dtpHasta.Enabled = opcion == 2;
        }

        private void btnReportes_Click(object? sender, EventArgs e)
        {
            if (cbmReportes.SelectedIndex == 2 &&
                dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha desde no puede ser posterior a la fecha hasta.");
                return;
            }

            try
            {
                object resultado;

                switch (cbmReportes.SelectedIndex)
                {
                    case 0:
                        resultado = _reportes.DisponibilidadPorFecha(
                            dtpDesde.Value);
                        break;

                    case 1:
                        resultado = _reportes.ReservasPendientes();
                        break;

                    case 2:
                        resultado = _reportes.AlquileresEntreFechas(
                            dtpDesde.Value, dtpHasta.Value);
                        break;

                    case 3:
                        resultado = _reportes.ElementosMasAlquilados();
                        break;

                    case 4:
                        resultado = _reportes.PendientesDeDevolucion();
                        break;

                    default:
                        MessageBox.Show("Seleccioná un reporte.");
                        return;
                }

                dgvReportes.DataSource = null;
                dgvReportes.DataSource = resultado;

                lblResultados.Text =
                    $"Resultados encontrados: {dgvReportes.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo generar el reporte: " + ex.Message);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}