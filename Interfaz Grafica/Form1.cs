using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_Grafica
{
    /// <summary>
    /// Ronaldo Nuñez  26
    /// En este formulario se muestra una tabla con los planetas descubiertos, con sus respectivas propiedades como su nombre, atmosfera, peligro y recursos.
    /// </summary>//
    public partial class Form1 : Form
    {
        List<Planetas> listaplanetas = new List<Planetas>();



        string archivo = "galaxia.txt";



        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
            GuardarArchivo();


            DgvPlanetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DgvPlanetas.MultiSelect = false;



            LeerArchivo();

            MostrarDatos();

            Diseño();


            foreach (DataGridViewColumn col in DgvPlanetas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void Diseño() 
        {
            this.Text = "CENTRO DE EXPLORACION GALACTICA";
            this.BackColor = Color.FromArgb(10, 10, 30);
            this.ForeColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

         
            DgvPlanetas.BackgroundColor = Color.FromArgb(20, 20, 50);

            DgvPlanetas.BorderStyle = BorderStyle.None;

            DgvPlanetas.EnableHeadersVisualStyles = false;

            DgvPlanetas.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(0, 120, 215);

            DgvPlanetas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            DgvPlanetas.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            DgvPlanetas.DefaultCellStyle.BackColor =
                Color.FromArgb(30, 30, 60);

            DgvPlanetas.DefaultCellStyle.ForeColor =
                Color.White;

            DgvPlanetas.DefaultCellStyle.SelectionBackColor =
                Color.Cyan;

            DgvPlanetas.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            DgvPlanetas.RowHeadersVisible = false;

            DgvPlanetas.GridColor = Color.DarkBlue;

            DgvPlanetas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            DgvPlanetas.Font =
                new Font("Consolas", 10);

            DgvPlanetas.Height = 300;

            
            BtnAgregar.BackColor = Color.MediumSlateBlue;
            BtnAgregar.ForeColor = Color.White;
            BtnAgregar.FlatStyle = FlatStyle.Flat;
            BtnAgregar.FlatAppearance.BorderSize = 0;
            BtnAgregar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnAgregar.Width = 170;
            BtnAgregar.Height = 45;

            BtnModificar.BackColor = Color.DeepSkyBlue;
            BtnModificar.ForeColor = Color.White;
            BtnModificar.FlatStyle = FlatStyle.Flat;
            BtnModificar.FlatAppearance.BorderSize = 0;
            BtnModificar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnModificar.Width = 170;
            BtnModificar.Height = 45;

         
            BtnEliminar.BackColor = Color.Crimson;
            BtnEliminar .ForeColor = Color.White;
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.FlatAppearance.BorderSize = 0;
            BtnEliminar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnEliminar.Width = 170;
            BtnEliminar.Height = 45;

            BtnSalir.BackColor = Color.Black;
            BtnSalir.ForeColor = Color.White;
            BtnSalir.FlatStyle = FlatStyle.Flat;
            BtnSalir.FlatAppearance.BorderColor = Color.Cyan;
            BtnSalir.FlatAppearance.BorderSize = 1;
            BtnSalir.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BtnSalir.Width = 170;
            BtnSalir.Height = 45;
        }
      
        private void LeerArchivo()
        {
            try
            {
                if (File.Exists(archivo))
                {
                    string[] lineas = File.ReadAllLines(archivo);

                    foreach (string linea in lineas)
                    {
                        // Solo procesar si la línea no está vacía
                        if (!string.IsNullOrWhiteSpace(linea))
                        {
                            string[] datos = linea.Split('|');

                            // Verificar que existan las 5 columnas antes de intentar leer
                            if (datos.Length >= 5)
                            {
                                Planetas p = new Planetas();
                                p.ID = int.Parse(datos[0]);
                                p.Nombre = datos[1];
                                p.Atmosfera = datos[2];
                                p.Peligro = datos[3];
                                p.Recursos = int.Parse(datos[4]);
                                listaplanetas.Add(p);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        public void MostrarDatos()
        {
            DgvPlanetas.DataSource = null;
            DgvPlanetas.DataSource = listaplanetas;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                int nuevoId = 1;

                if (listaplanetas.Count > 0)
                {
                    nuevoId = listaplanetas.Max(x => x.ID) + 1;
                }

                string[] nombres =
                {
                    "Zorath",
                    "Nebulon",
                    "Cryon",
                    "Xenthar",
                    "Omega-7"
                };

                string[] atmosferas =
                {
                    "Oxigeno",
                    "Toxica",
                    "Helio",
                    "Metano",
                    "Desconocida"
                };

                string[] peligros =
                {
                    "Bajo",
                    "Moderado",
                    "Alto",
                    "Extremo"
                };

                Planetas nuevo = new Planetas();

                nuevo.ID = nuevoId;
                nuevo.Nombre = nombres[r.Next(nombres.Length)];
                nuevo.Atmosfera = atmosferas[r.Next(atmosferas.Length)];
                nuevo.Peligro = peligros[r.Next(peligros.Length)];
                nuevo.Recursos = r.Next(100, 10000);

                listaplanetas.Add(nuevo);

                MostrarDatos();

                MessageBox.Show("Nuevo planeta descubierto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al descubrir planeta: " + ex.Message);
            }
        }


        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaplanetas.Count == 0)
                {
                    MessageBox.Show("No hay registros");
                    return;
                }

                int indice = r.Next(listaplanetas.Count);

                listaplanetas[indice].Atmosfera = "Inestable";
                listaplanetas[indice].Peligro = "CRITICO";
                listaplanetas[indice].Recursos += 5000;

                MostrarDatos();

                MessageBox.Show("Datos del planeta actualizados");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            GuardarArchivo();

            MessageBox.Show("Datos guardados correctamente");

            Application.Exit();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPlanetas.SelectedRows.Count > 0)
                {
                    DialogResult respuesta = MessageBox.Show(
                        "¿Eliminar planeta?",
                        "Confirmación",
                        MessageBoxButtons.YesNo
                    );

                    if (respuesta == DialogResult.Yes)
                    {
                        int fila = DgvPlanetas.SelectedRows[0].Index;

                        listaplanetas.RemoveAt(fila);

                        MostrarDatos();

                        MessageBox.Show("Registro eliminado");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un planeta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }
        private void GuardarArchivo()
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, false);

                foreach (Planetas p in listaplanetas)
                {
                    sw.WriteLine(
                        p.ID + "|" +
                        p.Nombre + "|" +
                        p.Atmosfera + "|" +
                        p.Peligro + "|" +
                        p.Recursos
                    );
                }

                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

    }
}



