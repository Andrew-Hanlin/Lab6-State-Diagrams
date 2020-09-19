using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace State_Diagrams
{

    // Displays a view of the number-guessing game:
    public partial class Form1 : Form
    {

        GameController c;  // holds handle to the controller object (no delegates today, OK?)
        Status state;     // remembers the current state of the game
        bool SecoundWon = false;


        public Form1(GameController c)
        {
            this.c = c;
            this.state = Status.Start;
            InitializeComponent();  // constructs the graphical part of the Form
            // set the label on it:
            label1.Text = "Type an int in range 0..10";
        }

        // handles a click of the OK button:
        private void button1_Click(object sender, EventArgs e)
        {
            if (state == Status.Win)
            {
                label1.Text = "Type an int in range 0..10";
                c = new GameController();
                state = Status.Start;
            }
            else
            {
                Tuple<Status, int> pair = c.handle(textBox1.Text);
                state = pair.Item1;    // remember the new state of the game
                int num = pair.Item2;  // a number computed by the controller
                if (state == Status.Win)
                {
                    label1.Text = "YOU WON! \npress OK to play again"; 

                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
