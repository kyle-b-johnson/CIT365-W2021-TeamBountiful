﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MegaDesk_TeamBountiful
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes(List<DeskQuote> localQuotes)
        {
            InitializeComponent();

            this.Text = @"Search Results";

            InitalizeDataGrid(localQuotes);
        }

        public ViewAllQuotes()
        {
            InitializeComponent();

            InitalizeDataGrid(MainMenu.DataFiler.DeskQuotes);
        }

        private void ButtonMainMenu_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            Close();
        }

        private void InitalizeDataGrid(List<DeskQuote> localQuotes)
        {
            DataGridView quotesDataGridView = QuotesDataGridView;

            string[] headers =
            {
                "Customer Name",
                "Width",
                "Depth",
                "Drawers",
                "Surface Material",
                "Rush Order",
                "Date",
                "Total Price",
            };

            // Force select column smaller
            quotesDataGridView.RowHeadersWidth = 20;
            // Set columns widths
            int[] columnWidths = {
                100,
                40,
                40,
                55,
                60,
                50,
                60,
                55,
            };

            quotesDataGridView.ColumnCount = headers.Length;

            for (int i = 0; i < headers.Length; i++)
            {
                quotesDataGridView.Columns[i].Name = headers[i];
                quotesDataGridView.Columns[i].Width = columnWidths[i];
            }

            //QuotesDataGridView.Rows.Clear();

            // To view all.. iterate through Filer.DeskQuotes. Something like:
            //foreach (var quote in MainMenu.DataFiler.DeskQuotes)
            foreach (var quote in localQuotes)
            {
                string[] row =
                {
                    quote.CustomerName,
                    quote.TheDesk.Width.ToString(),
                    quote.TheDesk.Depth.ToString(),
                    quote.TheDesk.Drawers.ToString(),
                    quote.TheDesk.SurfaceMaterial.ToString(),
                    quote.RushOrder,
                    quote.QuoteDate.ToString("d"),
                    string.Format($"{quote.TotalPrice:C}"),
                };

                QuotesDataGridView.Rows.Add(row);
            }   
        }

    }
}
