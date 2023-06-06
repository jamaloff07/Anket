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

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Title = $"{textBox1.Text}";
                    openFileDialog.Filter = "Json files (*.json)|*.json";

                    if (openFileDialog.ShowDialog()==DialogResult.OK)
                    {
                        string filePath=openFileDialog.FileName;

                        string json=File.ReadAllText(filePath);

                        Anket loadedAnket=JsonSerializer.Deserialize<Anket>(json);

                        textBox1.Text = loadedAnket.name;
                        textBox2.Text = loadedAnket.surname;
                        textBox3.Text = loadedAnket.fatherN;
                        textBox4.Text = loadedAnket.country;
                        textBox5.Text = loadedAnket.city;
                        textBox6.Text = loadedAnket.phone;
                        dateTimePicker1.Value = loadedAnket.Birthday;


                        if (loadedAnket.Gender =="Male")
                        {
                            radioButton1.Checked=true;
                            radioButton2.Checked=false;
                        }

                        else if (loadedAnket.Gender=="Famale")
                        {
                            radioButton2.Checked = true;
                            radioButton1.Checked = false;

                        }
                    }



                    break;
            }

        }
    }
}