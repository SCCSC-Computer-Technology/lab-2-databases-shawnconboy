// Shawn Conboy
// CPT 206 A01H
// Lab 2 Database Population type thingamabob.

// There's lots of room for improvement. Uh...
// The buttons all work. But the data being highlighted 
// the min and max buttons, so that you see exactly which record
// matches the min and max would be nice. Or possibly just another
// label to show the city would be nice.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sConboyLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // auto added. this makes your db save when clicking the save button
        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDBDataSet);

        }

        // on load, but added automatically. data grid view controller is filled with that line of code
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

        }


        // this is where all the on click methods start...... _____________________________________

        private void populationAscendingButton_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.SortPopulationAscending(this.cityDBDataSet.City);
        }

        private void populationDescendingButton_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.SortPopulationDescending(this.cityDBDataSet.City);
        }

        private void citiesByName_Click(object sender, EventArgs e)
        {
            this.cityTableAdapter.SortCityName(this.cityDBDataSet.City);
        }

        private void totalButton_Click(object sender, EventArgs e)
        {
            decimal totalPopulation = 0;
            totalPopulation = (decimal) this.cityTableAdapter.PopulationSum();
            cityPopulationLabel.Text = totalPopulation.ToString("N0");

            cityNameLabel.Text = "Total";
        }

        private void averageButton_Click(object sender, EventArgs e)
        {
            decimal averagePopulation = 0;
            averagePopulation = (decimal) this.cityTableAdapter.PopulationAverage();
            cityPopulationLabel.Text = averagePopulation.ToString("N0");
            cityNameLabel.Text = "Average";
        }

        private void lowestButton_Click(object sender, EventArgs e)
        {
            decimal lowestPopulation = 0;
            lowestPopulation = (decimal) this.cityTableAdapter.PopulationMin();
            cityPopulationLabel.Text = lowestPopulation.ToString("N0");

            string cityName = (string)(this.cityTableAdapter.MinCityName());
            cityNameLabel.Text = cityName;
        }

        private void highestButton_Click(object sender, EventArgs e)
        {
            decimal highestPopulation = 0;
            highestPopulation = (decimal) (this.cityTableAdapter.PopulationMax());
            cityPopulationLabel.Text = (highestPopulation.ToString("N0"));

            string cityName = (string)(this.cityTableAdapter.MaxCityName());
            cityNameLabel.Text = cityName;
        }
    }
}
