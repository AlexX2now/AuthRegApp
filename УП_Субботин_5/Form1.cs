using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace УП_Субботин_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isMasked = false;
        private char originalPasswordChar;
        public string Kaptcha;

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox5.Text;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Пожалуйста, не оставляйте поля пустыми");
            }
            else
            {
                if (text.Length < 8)
                {
                    MessageBox.Show("Текст должен содержать не менее 8 символов.");
                }
                else
                {
                    if (!text.Any(char.IsLetter))
                    {
                        MessageBox.Show("Текст должен иметь хотя бы одну букву.");
                    }
                    else
                    {
                        if (!text.Any(char.IsDigit))
                        {
                            MessageBox.Show("Текст должен иметь хотя бы одну цифру.");
                        }
                        else
                        {

                            if (textBox5.Text == textBox6.Text)
                            {
                                string currentDirectory = Environment.CurrentDirectory;
                                string relativePath = Path.Combine(currentDirectory, @"Данные\Данные.txt");
                                StreamWriter streamWriter = new StreamWriter(relativePath);
                                streamWriter.WriteLine(textBox1.Text);
                                streamWriter.WriteLine(textBox2.Text);
                                streamWriter.WriteLine(textBox3.Text);
                                streamWriter.WriteLine(textBox4.Text);
                                streamWriter.WriteLine(textBox5.Text);
                                streamWriter.Close();
                                MessageBox.Show("Вы успешно зарегестрировались в системе!");
                                tabControl1.SelectedIndex = 0;
                            }
                            else
                            {
                                MessageBox.Show("Пожалуйста, корректно запиши подтверждение пароля.");
                            }
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isMasked)
            {
                textBox8.PasswordChar = originalPasswordChar;
            }
            else
            {
                originalPasswordChar = textBox8.PasswordChar;
                textBox8.PasswordChar = '*';
            }

            isMasked = !isMasked;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string currentDirectory = Environment.CurrentDirectory;
                string relativePath = Path.Combine(currentDirectory, @"Данные\Данные.txt");
                string[] lines = File.ReadAllLines(relativePath);

                int lineNeeded = 4;
                if (lines.Length >= lineNeeded)
                {
                    string valueNeeded = lines[lineNeeded - 1];

                    if (textBox7.Text == valueNeeded)
                    {
                        if (label9.Visible == false)
                        {
                            int lineNumberToCheck = 5;

                            if (lines.Length >= lineNumberToCheck)
                            {
                                string valueToCheck = lines[lineNumberToCheck - 1];

                                if (textBox8.Text == valueToCheck)
                                {
                                    Austronaut austronaut = new Austronaut();
                                    austronaut.Show();
                                }
                                else
                                {
                                    label9.Visible = true;
                                    label10.Visible = true;
                                    textBox9.Visible = true;
                                    String allowchar = " ";
                                    allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                                    allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
                                    allowchar += "1,2,3,4,5,6,7,8,9,0";
                                    char[] a = { ',' };
                                    String[] ar = allowchar.Split(a);
                                    String pwd = " ";
                                    string temp = " ";
                                    Random r = new Random();
                                    int kol = 6;
                                    for (int i = 0; i < kol; i++)
                                    {
                                        temp = ar[(r.Next(0, ar.Length))];
                                        pwd += temp;
                                    }
                                    Kaptcha = pwd;
                                    label10.Text = pwd;
                                }
                            }
                        }
                        else if (label9.Visible == true)
                        {
                            int lineNumberToCheck = 5;
                            if (" " + textBox9.Text == Kaptcha)
                            {
                                if (lines.Length >= lineNumberToCheck)
                                {
                                    string valueToCheck = lines[lineNumberToCheck - 1];

                                    if (textBox8.Text == valueToCheck)
                                    {
                                        Austronaut austronaut = new Austronaut();
                                        austronaut.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Вы неправильно ввели пароль");
                                    }

                                }
                            }
                            else
                                MessageBox.Show("Вы неправильно ввели капчу.");
                            String allowchar = " ";
                            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
                            allowchar += "1,2,3,4,5,6,7,8,9,0";
                            char[] a = { ',' };
                            String[] ar = allowchar.Split(a);
                            String pwd = " ";
                            string temp = " ";
                            Random r = new Random();
                            int kol = 6;
                            for (int i = 0; i < kol; i++)
                            {
                                temp = ar[(r.Next(0, ar.Length))];
                                pwd += temp;
                            }
                            label10.Text = pwd;
                            Kaptcha = pwd;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неправильный логин");
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Пожалуйста, не оставляйте поля пустыми.");
            }
        }
    }
}