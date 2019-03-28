/*
Course code: SODV2101
Term/Year: Fall/2018
Assignment code: A1
Author: Anderson Resende Viana
BVC username : a.resendeviana683
Date created : 2018-09-26
Description : Assignment 1 - Games - Tic Tac Toe
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe2
{
    public partial class Form1 : Form
    {
        bool myTurn = true;
        int turnCounter = 0;
        bool anyWinner = false;

        public Form1()
        {
            InitializeComponent();
            //ResetBoard();
        }

        public void ResetBoard()
        {
            myTurn = true;
            turnCounter = 0;
            anyWinner = false;
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void CheckWinner()
        {
            // horizontal check

            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (button1.Text != ""))
            {
                anyWinner = true;
            }

            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && button4.Text != "")
            {
                anyWinner = true;
            }

            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && button7.Text != "")
            {
                anyWinner = true;
            }


            // vertical check

            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && button1.Text != "")
            {
                anyWinner = true;
            }

            else if ((button2.Text == button6.Text) && (button6.Text == button8.Text) && button2.Text != "")
            {
                anyWinner = true;
            }

            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && button3.Text != "")
            {
                anyWinner = true;
            }

            // diagonal check

            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && button1.Text != "")
            {
                anyWinner = true;
            }

            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && button3.Text != "")
            {
                anyWinner = true;
            }


            if (anyWinner == true)
            {
                String theWinner = "";
                if (myTurn == true)
                {
                    theWinner = "X";
                }
                else
                {
                    theWinner = "O";
                }

                if (MessageBox.Show("Player " + theWinner + " wins! \nClick Cancel to exit.", "Game Result", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    ResetBoard();
                }
                else
                {
                    Application.Exit();
                }
            }

            else if (turnCounter >= 9)
            {
                if (MessageBox.Show("No winner... \nClick Cancel to exit.", "Game Result", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    ResetBoard();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button space = (Button)sender;

            if(space.Text == "")
            {
                if (myTurn == true)
                {
                    space.Text = "X";
                    space.ForeColor = Color.Red;
                }
                else
                {
                    space.Text = "O";
                    space.ForeColor = Color.Blue;
                }
                
                turnCounter++;
                CheckWinner();
                myTurn = !myTurn;
            }
            
        }
    }
}
