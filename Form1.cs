using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assginment1
{
    public partial class Form1 : Form
        //Sheridan Antwi
        //PROG1815 SEC2
        // Assignment 1
        // Revision date: 2021-06-11
        // purpose: Restaurant table management
    {

        string[,] tables = new string[15, 6]
        {
            {"Table 1", "8", "Free", " ", "0", "0" },
            {"Table 2", "4", "Free", " ", "0", "1" },
            {"Table 3", "8", "Free", " ", "0", "2" },
            {"Table 4", "4", "Free", " ", "0", "3" },
            {"Table 5", "8", "Free", " ", "0",  "4"},
            {"Table 6", "4", "Free", " ", "0", "5"},
            {"Table 7", "8", "Free", " ", "0", "6"},
            {"Table 8", "4", "Free", " ", "0", "7"},
            {"Table 9", "8", "Free", " ", "0", "8"},
            {"Table 10", "4", "Free", " ", "0", "9"},
            {"Table 11", "8", "Free", " ", "0", "10"},
            {"Table 12", "4", "Free", " ", "0", "11"},
            {"Table 13", "8", "Free", " ", "0", "12"},
            {"Table 14", "4", "Free", " ", "0", "13"},
            {"Table 15", "8", "Free", " ", "0", "14"},
            
        };


        List<string> waitinglist = new List<string>(20);
        
        


        public Form1()
        {
            InitializeComponent();
        }




        

        private void AssginButton_Click(object sender, EventArgs e) //assgin button
        {
            decimal guestnumber = guestNumberBox.Value;
            string customerName = customerNameBox.Text;           

            

            int j = 0;

            //beginning of for loop going through the tables array//
            for (int i = 0; i < 15; i++)
            {
                
                
            // beginning of if and else statements check to see if the names are the same or if a name and number are not filled in
               if (tables[i, 0] == TableLabelDisplay.Text)
                {


                     if (customerNameBox.Text == "")
                    {
                        MessageBox.Show("fill in name");
                    }


                   else if (guestnumber == 0)
                    {
                        MessageBox.Show("please enter numebr of guest");
                        customerName = "";
                        guestnumber = 0;


                    }



                    else
                    {
                        j = Convert.ToInt32(tables[i, 5]);

                        tables[j, 3] = customerName;
                        string guestnumber_S = Convert.ToString(guestnumber);
                        tables[j, 4] = guestnumber_S;
                        tables[j, 2] = "Occupied";
                        MessageBox.Show("Table booked");
                    }
                  


                }
                else if (customerNameBox.Text == tables[i, 3])
                {
                    MessageBox.Show("Name already entered");
                    customerName = "";
                    guestnumber = 0;

                }
                // end of if and else statements
            } // end of for loop
        }

        private void addToWaitinglistButton_Click(object sender, EventArgs e)
        {
            waitinglist.Add(customerNameBox.Text + " " + Convert.ToString(guestNumberBox.Value));
            MessageBox.Show(" Customer has been added");
            // adds to waiting list and tells user that a customer has being added//
        }

        private void showWaitingListButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < waitinglist.Count; i++)
            {
                ShowWaitingListTextBox.Text = waitinglist[i];
                //shows waiting list in text box selected
            }
        }

        private void ShowTableButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                    showTableTextBox.Text += $"{tables[i, 0]}  {tables[i, 3]}  {tables[i, 4]} \n";
            }       // shows table assginment list in the text box selected
        }


        private void CancelButton_Click(object sender, EventArgs e)
        { // cancels the table and removes the information on the table selected
            int j = 0;

            for (int i = 0; i < 15; i++)
            {

                
                if (tables[i, 0] == TableLabelDisplay.Text)
                {
                    j = Convert.ToInt32(tables[i, 5]);
                }
            }

            tables[j, 3] = "";
           
            tables[j, 4] = Convert.ToString(0);
            tables[j, 2] = "free";
            MessageBox.Show("Assginment canceled");

        }

        private void Table_Click(object sender, EventArgs e)
        { // keeps track of the table selected and displays the table info in the selected text boxes//
            Button b = (Button)sender;

            int j = 0;

            TableLabelDisplay.Text = b.Text;

            for (int i = 0; i < 15; i++)
            {
                
                 if(tables[i,0] == b.Text)
                {
                    j = Convert.ToInt32(tables[i, 5]);
                   
                }
            }
            tableCapacityLabelDisplay.Text = tables[j, 1];
            customerNameBox.Text = tables[j, 3];
            decimal guest = Convert.ToDecimal(tables[j, 4]);
            guestNumberBox.Value = guest;


        }

        // Main Problem: i couldn't get the for loops to work to display the waiting list or table list,
        //can you please include on the feedback how to do that because i have tried everything and this
        //is one of the reason why i took so long to do this assignment. Thank you
    }
}
