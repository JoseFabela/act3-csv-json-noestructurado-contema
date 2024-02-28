using Newtonsoft.Json.Linq;
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
using System.Xml;

namespace act3_csv_json_noestructurado_contema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnProcesarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv|Archivos XML (*.xml)|*.xml|Archivos JSON (*.json)|*.json|Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    ProcessCSV(filePath);
                }
                else if (filePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    ProcessXML(filePath);
                }
                else if (filePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    ProcessJSON(filePath);
                }
                else if (filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    ProcessUnstructuredFile(filePath);
                }
                else
                {
                    MessageBox.Show("Formato de archivo no compatible.");
                }
            }
        }
        private void ProcessCSV(string filePath)
        {
            try
            {
                List<string[]> csvData = ReadCSV(filePath);

                // Puedes realizar acciones con los datos del archivo CSV aquí
                // En este caso, mostrarlos en un DataGridView para clientes:
                ShowCustomerDataInDataGridView(csvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo CSV: {ex.Message}");
            }
        }

        private void ProcessXML(string filePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                // Puedes realizar acciones con el documento XML aquí
                // En este caso, mostrar las preferencias de notificación en un TextBox:
                ShowDataInTextBox(xmlDoc.OuterXml);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo XML: {ex.Message}");
            }
        }

        private void ProcessJSON(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);

                // Puedes realizar acciones con el contenido JSON aquí
                // En este caso, mostrar los registros de devoluciones en un TextBox:
                ShowDataInTextBox(JToken.Parse(jsonContent).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo JSON: {ex.Message}");
            }
        }

        private void ProcessUnstructuredFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);

                // Puedes realizar acciones con el contenido del archivo no estructurado aquí
                // En este caso, mostrar el contenido en un TextBox:
                ShowDataInTextBox(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo no estructurado: {ex.Message}");
            }
        }

        private List<string[]> ReadCSV(string filePath)
        {
            List<string[]> data = new List<string[]>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    data.Add(values);
                }
            }

            return data;
        }

        private void ShowCustomerDataInDataGridView(List<string[]> data)
        {
            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersVisible = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (string header in data[0])
            {
                dgv.Columns.Add(header, header);
            }

            for (int i = 1; i < data.Count; i++)
            {
                dgv.Rows.Add(data[i]);
            }

            Form dataForm = new Form();
            dataForm.Text = "Datos de Clientes";
            dataForm.Size = new System.Drawing.Size(600, 400);
            dataForm.Controls.Add(dgv);
            dataForm.ShowDialog();
        }

        private void ShowDataInTextBox(string content)
        {
            TextBox txtResult = new TextBox();
            txtResult.Multiline = true;
            txtResult.Dock = DockStyle.Fill;
            txtResult.Text = content;

            Form dataForm = new Form();
            dataForm.Text = "Contenido del Archivo";
            dataForm.Size = new System.Drawing.Size(600, 400);
            dataForm.Controls.Add(txtResult);
            dataForm.ShowDialog();
        }
    }
}
