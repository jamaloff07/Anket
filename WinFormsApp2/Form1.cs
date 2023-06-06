using System.IO.Pipes;
using System.Text.Json;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


    }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Anket anket = new Anket();
            switch (button.Text)
            {
                case "Save":
                    anket.name=textBox1.Text;
                    anket.surname = textBox2.Text;
                    anket.fatherN = textBox3.Text;
                    anket.country = textBox4.Text;
                    anket.city = textBox5.Text;
                    anket.phone= textBox6.Text;
                    anket.Birthday = dateTimePicker1.Value;
                    anket.Gender = radioButton1.Checked ? "Male" : "Famale";

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title=$"{textBox1.Text}";
                    saveFileDialog.Filter = "Json files (*.json)|*.json";

                    if (saveFileDialog.ShowDialog()==DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        string filled = JsonSerializer.Serialize(anket);

                        File.WriteAllText(filePath, filled);

                    }

                    break;
                case "Load":
`
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Title = $"{textBox1.Text}";
                    dialog.Filter = "Json files (*.json)|*.json";


                    break;
            }

        }
    }
}