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

        // on load, but added  automatically. data grid view controller is filled with that line of code
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

        }

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
            informationLabel.Text = totalPopulation.ToString("N0");

        }

        private void averageButton_Click(object sender, EventArgs e)
        {
            decimal averagePopulation = 0;
            averagePopulation = (decimal) this.cityTableAdapter.PopulationAverage();
            informationLabel.Text = averagePopulation.ToString("N0");
        }

        private void lowestButton_Click(object sender, EventArgs e)
        {
            decimal lowestPopulation = 0;
            lowestPopulation = (decimal) this.cityTableAdapter.PopulationMin();
            informationLabel.Text = lowestPopulation.ToString("N0");
        }

        private void highestButton_Click(object sender, EventArgs e)
        {
            decimal highestPopulation = 0;
            highestPopulation = (decimal) (this.cityTableAdapter.PopulationMax());
            informationLabel.Text = (highestPopulation.ToString("N0"));
        }
    }
}
