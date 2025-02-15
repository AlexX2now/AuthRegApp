﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace УП_Субботин_5
{
    public partial class Austronaut : Form
    {
        public Austronaut()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Astronaut astronaut = new Astronaut(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                label5.Text = Convert.ToString(astronaut.GetFlight());
                label6.Text = astronaut.GetHours();
                label7.Text = Convert.ToString(astronaut.GetAverage());
            }
            catch
            {
                MessageBox.Show("Пожалуйста, проверьте вашу информацию.");
            }
        }
    }
}
