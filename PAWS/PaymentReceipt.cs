﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PAWS
{
    public partial class PaymentReceipt : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DbConnect dbcon = new DbConnect();
        string title = "PAWS";
        public PaymentReceipt()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
        }

        private void PaymentReceipt_Load(object sender, EventArgs e)
        {

            this.ReceiptViewer.RefreshReport();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {


            cm = new SqlCommand("SELECT transno, pcode, pspecies, qty, price, total,c.name,cashier FROM tbPayment as cash LEFT JOIN tbCustomer c ON cash.cid = c.id WHERE transno = (SELECT MAX(transno) FROM tbPayment)", cn);


            SqlDataAdapter d = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            d.Fill(dt);

            // Clear previous data sources and add new data source with updated parameters
            ReceiptViewer.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("PaymentReceipt", dt);
            ReceiptViewer.LocalReport.ReportPath = @"C:\Users\ithau.DESKTOP-1P0GCC5\Desktop\DENNIS MUTUNGI\PAWS\PAWS\PaymentReceipt.rdlc";
            ReceiptViewer.LocalReport.DataSources.Add(source);


            // Refresh the report
            ReceiptViewer.RefreshReport();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ReceiptViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
