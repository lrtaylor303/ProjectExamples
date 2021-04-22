using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatPercentageCalculator
{
    //Program:      Fat Percentage Calculator
    //Developer:    Lauren Taylor
    //Date:         2/13/21
    //About:        This program will take input from the user in the form of calories and fat grams
    //              and then use those numbers to calculate how much of the calories are from fat and
    //              that percentage.
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTotalCaloriesTextBox.Text = "";
            inputFatGramsTextBox.Text = "";
            lowFatCheckBox.Checked = false;
            lowFatLabel.Text = "";
            displayCaloriesFatLabel.Text = "";
            displayPercentageCaloriesLabel.Text = "";
            inputTotalCaloriesTextBox.Focus();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            //Declare Variables
            decimal caloriesFromFat = 0;
            decimal percentCaloriesFromFat = 0;
            bool isLowFat = false;

            //Change input
            bool totalCaloriesParsed = decimal.TryParse(inputTotalCaloriesTextBox.Text, out decimal totalCalories);
            bool totalFatGramsParsed = decimal.TryParse(inputFatGramsTextBox.Text, out decimal totalFatGrams);
            lowFatLabel.Text = string.Empty;
            displayPercentageCaloriesLabel.Text = string.Empty;
            displayCaloriesFatLabel.Text = string.Empty;

            //Check input
            if (totalCaloriesParsed && totalCalories <= 0 || !totalCaloriesParsed )
            {
                MessageBox.Show("This is not a valid entry.");
                return;
            }

            if (totalFatGramsParsed && totalFatGrams <= 0 || !totalFatGramsParsed || totalFatGrams * 9 >= totalCalories)
            {
                MessageBox.Show("This is not a valid entry.");
                return;
            }


            //Calculate calories from fat

            caloriesFromFat = (totalFatGrams * 9m);

            //Calculate percentage of calories from fat

            percentCaloriesFromFat = (caloriesFromFat / totalCalories) * 100;

            //Determine if food is low fat
            isLowFat = percentCaloriesFromFat < 30;

            if (isLowFat && lowFatCheckBox.Checked)
                lowFatLabel.Text = "This food is low fat.";
            else if (!isLowFat && lowFatCheckBox.Checked)
                lowFatLabel.Text = "This food is not low fat.";

            //Display output
            displayCaloriesFatLabel.Text = "This food has " + caloriesFromFat + " calories from fat.";
            displayPercentageCaloriesLabel.Text = "This food has " + percentCaloriesFromFat + "% calories from fat.";
        }
    }
}
