using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InventoryView
{
    public partial class frmGenBill : Form
    {
        public frmGenBill()
        {
            InitializeComponent();
        }

        private void btnGenBill_Click(object sender, EventArgs e)
        {
            string ExportToPath = string.Empty;
            string Filename = txtConsigneeName.Text.Trim() + "_Bill_" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";
            FolderBrowserDialog diaFolder = new FolderBrowserDialog();
            diaFolder.Description = "Select Folder To Save Data File";
            if (diaFolder.ShowDialog() == DialogResult.OK)
            {
                ExportToPath = diaFolder.SelectedPath;
                GenerateBill(ExportToPath, Filename);
                MessageBox.Show("File Saved Successfully - " + ExportToPath + @"\" + Filename);
            }
        }

        private void btnCalculateAmt_Click(object sender, EventArgs e)
        {
            CalculateAmounts();
        }

        private void GenerateBill(string FileSavePath, string filename)
        {
            try
            {
                float PointerPos = 0;
                iTextSharp.text.Font FontBigBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 30f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font FontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font FontNormalBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                if (!(System.IO.Directory.Exists(FileSavePath)))
                {
                    System.IO.Directory.CreateDirectory(FileSavePath);
                }
                System.IO.FileStream fs = System.IO.File.Create(FileSavePath + filename);

                Document document = new Document(PageSize.A4, 25, 25, 25, 25);
                document.SetMargins(40f, 40f, 60f, 60f);

                PdfWriter pdfWriter = PdfWriter.GetInstance(document, fs);
                document.Open();
                PdfContentByte cb = pdfWriter.DirectContent;

                Paragraph Address_P1 = new Paragraph();
                Chunk Address_C1 = new Chunk("ND MOBILE", FontBigBold);
                Address_P1.Add(Address_C1);
                Address_P1.SpacingBefore = 10f;
                Address_P1.Alignment = Element.ALIGN_CENTER;
                document.Add(Address_P1);

                PointerPos = pdfWriter.GetVerticalPosition(false);
                cb.MoveTo(40, PointerPos - 30);
                cb.LineTo(document.PageSize.Width - 40, PointerPos - 30);
                cb.Stroke();

                Paragraph Address_P = new Paragraph();
                Chunk Address_C = new Chunk("INVOICE", FontNormalBold);
                Address_P.Add(Address_C);
                Address_P.SpacingBefore = 35f;
                Address_P.Alignment = Element.ALIGN_CENTER;
                document.Add(Address_P);

                PointerPos = pdfWriter.GetVerticalPosition(false);
                cb.MoveTo(40, PointerPos - 10);
                cb.LineTo(document.PageSize.Width - 40, PointerPos - 10);
                cb.Stroke();

                PdfPTable DataTable = new PdfPTable(new float[] { 4f, 1f, 4f, 1f });
                DataTable.WidthPercentage = 100;
                DataTable.SpacingBefore = 20f;

                PdfPCell DataTable_Cell1 = new PdfPCell();
                DataTable_Cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                DataTable_Cell1.Colspan = 2;
                Paragraph DataTable_P1 = new Paragraph();
                Chunk DataTable_C1 = new Chunk("Consignee", FontNormalBold);
                DataTable_P1.Add(DataTable_C1);
                DataTable_Cell1.AddElement(DataTable_P1);
                DataTable.AddCell(DataTable_Cell1);

                PdfPCell DataTable_Cell2 = new PdfPCell();
                DataTable_Cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                DataTable_Cell2.Colspan = 2;
                Paragraph DataTable_P2 = new Paragraph();
                Chunk DataTable_C2 = new Chunk("Consignor", FontNormalBold);
                DataTable_P2.Add(DataTable_C2);
                DataTable_Cell2.AddElement(DataTable_P2);
                DataTable.AddCell(DataTable_Cell2);

                PdfPCell DataTable_Cell3 = new PdfPCell();
                DataTable_Cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                DataTable_Cell3.Colspan = 2;
                Paragraph DataTable_P3 = new Paragraph();
                Chunk DataTable_C3 = new Chunk("\n" + txtConsigneeName.Text.Trim(), FontNormalBold);
                DataTable_P3.Add(DataTable_C3);
                DataTable_Cell3.AddElement(DataTable_P3);
                DataTable.AddCell(DataTable_Cell3);

                PdfPCell DataTable_Cell4 = new PdfPCell();
                DataTable_Cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                DataTable_Cell4.Colspan = 2;
                Paragraph DataTable_P4 = new Paragraph();
                Chunk DataTable_C4 = new Chunk("\n" + txtConsignorName.Text.Trim(), FontNormalBold);
                DataTable_P4.Add(DataTable_C4);
                DataTable_Cell4.AddElement(DataTable_P4);
                DataTable.AddCell(DataTable_Cell4);

                PdfPCell DataTable_Cell5 = new PdfPCell();
                DataTable_Cell5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable_P5 = new Paragraph();
                Chunk DataTable_C5 = new Chunk(txtConsigneeAddress.Text.Trim(), FontNormal);
                DataTable_P5.Add(DataTable_C5);
                DataTable_Cell5.AddElement(DataTable_P5);
                DataTable.AddCell(DataTable_Cell5);

                PdfPCell DataTable_Cell51 = new PdfPCell();
                DataTable_Cell51.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable_P51 = new Paragraph();
                Chunk DataTable_C51 = new Chunk("", FontNormal);
                DataTable_P51.Add(DataTable_C51);
                DataTable_Cell51.AddElement(DataTable_P51);
                DataTable.AddCell(DataTable_Cell51);

                PdfPCell DataTable_Cell6 = new PdfPCell();
                DataTable_Cell6.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable_P6 = new Paragraph();
                Chunk DataTable_C6 = new Chunk(txtConsignorAddress.Text.Trim(), FontNormal);
                DataTable_P6.Add(DataTable_C6);
                DataTable_Cell6.AddElement(DataTable_P6);
                DataTable.AddCell(DataTable_Cell6);

                PdfPCell DataTable_Cell61 = new PdfPCell();
                DataTable_Cell61.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable_P61 = new Paragraph();
                Chunk DataTable_C61 = new Chunk("", FontNormal);
                DataTable_P61.Add(DataTable_C61);
                DataTable_Cell61.AddElement(DataTable_P61);
                DataTable.AddCell(DataTable_Cell61);

                PdfPCell DataTable_Cell7 = new PdfPCell();
                DataTable_Cell7.Border = iTextSharp.text.Rectangle.NO_BORDER;
                DataTable_Cell7.Colspan = 2;
                Paragraph DataTable_P7 = new Paragraph();
                Chunk DataTable_C7 = new Chunk("\nContact : " + txtConsigneeNumber.Text.Trim() + "\nREF ID : " + txtRefId.Text.Trim() + "\nDate : " + dtpDate.Value.ToString("dd-MM-yyyy"), FontNormal);
                DataTable_P7.Add(DataTable_C7);
                DataTable_Cell7.AddElement(DataTable_P7);
                DataTable.AddCell(DataTable_Cell7);

                PdfPCell DataTable_Cell8 = new PdfPCell();
                DataTable_Cell8.Border = iTextSharp.text.Rectangle.NO_BORDER;
                DataTable_Cell8.Colspan = 2;
                Paragraph DataTable_P8 = new Paragraph();
                Chunk DataTable_C8 = new Chunk("\nContact : " + txtConsignorNumber.Text.Trim() + "\nVAT/TIN : " + txtVatTin.Text.Trim() + "\nCST NO : " + txtCstNo.Text.Trim() + "\nIMEI : " + txtIMEI.Text.Trim(), FontNormal);
                DataTable_P8.Add(DataTable_C8);
                DataTable_Cell8.AddElement(DataTable_P8);
                DataTable.AddCell(DataTable_Cell8);
                document.Add(DataTable);

                PointerPos = pdfWriter.GetVerticalPosition(false);
                cb.MoveTo(40, PointerPos - 10);
                cb.LineTo(document.PageSize.Width - 40, PointerPos - 10);
                cb.Stroke();

                PdfPTable DataTable1 = new PdfPTable(new float[] { 4f, 2f, 2f, 2f, 3f });
                DataTable1.WidthPercentage = 100;
                DataTable1.SpacingBefore = 20f;

                PdfPCell DataTable1_Cell1 = new PdfPCell();
                DataTable1_Cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable1_P1 = new Paragraph();
                Chunk DataTable1_C1 = new Chunk("Description", FontNormalBold);
                DataTable1_P1.Add(DataTable1_C1);
                DataTable1_Cell1.AddElement(DataTable1_P1);
                DataTable1.AddCell(DataTable1_Cell1);

                PdfPCell DataTable1_Cell2 = new PdfPCell();
                DataTable1_Cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable1_P2 = new Paragraph();
                Chunk DataTable1_C2 = new Chunk("Quantity", FontNormalBold);
                DataTable1_P2.Add(DataTable1_C2);
                DataTable1_Cell2.AddElement(DataTable1_P2);
                DataTable1.AddCell(DataTable1_Cell2);

                PdfPCell DataTable1_Cell3 = new PdfPCell();
                DataTable1_Cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable1_P3 = new Paragraph();
                Chunk DataTable1_C3 = new Chunk("Price", FontNormalBold);
                DataTable1_P3.Add(DataTable1_C3);
                DataTable1_Cell3.AddElement(DataTable1_P3);
                DataTable1.AddCell(DataTable1_Cell3);

                PdfPCell DataTable1_Cell4 = new PdfPCell();
                DataTable1_Cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable1_P4 = new Paragraph();
                Chunk DataTable1_C4 = new Chunk("Tax (" + txtTax.Text.Trim() + "%)", FontNormalBold);
                DataTable1_P4.Add(DataTable1_C4);
                DataTable1_Cell4.AddElement(DataTable1_P4);
                DataTable1.AddCell(DataTable1_Cell4);

                PdfPCell DataTable1_Cell5 = new PdfPCell();
                DataTable1_Cell5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable1_P5 = new Paragraph();
                Chunk DataTable1_C5 = new Chunk("Net Amount", FontNormalBold);
                DataTable1_P5.Add(DataTable1_C5);
                DataTable1_Cell5.AddElement(DataTable1_P5);
                DataTable1.AddCell(DataTable1_Cell5);
                document.Add(DataTable1);

                PointerPos = pdfWriter.GetVerticalPosition(false);
                cb.MoveTo(40, PointerPos - 10);
                cb.LineTo(document.PageSize.Width - 40, PointerPos - 10);
                cb.Stroke();

                PdfPTable DataTable2 = new PdfPTable(new float[] { 4f, 2f, 2f, 2f, 3f });
                DataTable2.WidthPercentage = 100;
                DataTable2.SpacingBefore = 20f;

                PdfPCell DataTable2_Cell1 = new PdfPCell();
                DataTable2_Cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable2_P1 = new Paragraph();
                Chunk DataTable2_C1 = new Chunk(txtDesc.Text.Trim(), FontNormal);
                DataTable2_P1.Add(DataTable2_C1);
                DataTable2_Cell1.AddElement(DataTable2_P1);
                DataTable2.AddCell(DataTable2_Cell1);

                PdfPCell DataTable2_Cell2 = new PdfPCell();
                DataTable2_Cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable2_P2 = new Paragraph();
                DataTable2_P2.Alignment = Element.ALIGN_CENTER;
                Chunk DataTable2_C2 = new Chunk(txtQty.Text.Trim(), FontNormal);
                DataTable2_P2.Add(DataTable2_C2);
                DataTable2_Cell2.AddElement(DataTable2_P2);
                DataTable2.AddCell(DataTable2_Cell2);

                PdfPCell DataTable2_Cell3 = new PdfPCell();
                DataTable2_Cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable2_P3 = new Paragraph();
                Chunk DataTable2_C3 = new Chunk(txtPrice.Text.Trim(), FontNormal);
                DataTable2_P3.Add(DataTable2_C3);
                DataTable2_Cell3.AddElement(DataTable2_P3);
                DataTable2.AddCell(DataTable2_Cell3);

                PdfPCell DataTable2_Cell4 = new PdfPCell();
                DataTable2_Cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable2_P4 = new Paragraph();
                Chunk DataTable2_C4 = new Chunk(txtTaxAmt.Text.Trim(), FontNormal);
                DataTable2_P4.Add(DataTable2_C4);
                DataTable2_Cell4.AddElement(DataTable2_P4);
                DataTable2.AddCell(DataTable2_Cell4);

                PdfPCell DataTable2_Cell5 = new PdfPCell();
                DataTable2_Cell5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable2_P5 = new Paragraph();
                Chunk DataTable2_C5 = new Chunk(txtNetAmount.Text.Trim(), FontNormal);
                DataTable2_P5.Add(DataTable2_C5);
                DataTable2_Cell5.AddElement(DataTable2_P5);
                DataTable2.AddCell(DataTable2_Cell5);

                PdfPCell DataTable2_Cell11 = new PdfPCell();
                DataTable2_Cell11.Colspan = 4;
                DataTable2_Cell11.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable2_P11 = new Paragraph();
                Chunk DataTable2_C11 = new Chunk("Shipping Charges (+)", FontNormal);
                DataTable2_P11.Add(DataTable2_C11);
                DataTable2_Cell11.AddElement(DataTable2_P11);
                DataTable2.AddCell(DataTable2_Cell11);

                PdfPCell DataTable2_Cell21 = new PdfPCell();
                DataTable2_Cell21.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable2_P21 = new Paragraph();
                Chunk DataTable2_C21 = new Chunk(txtShipCharge.Text.Trim(), FontNormal);
                DataTable2_P21.Add(DataTable2_C21);
                DataTable2_Cell21.AddElement(DataTable2_P21);
                DataTable2.AddCell(DataTable2_Cell21);

                //PdfPCell DataTable2_Cell12 = new PdfPCell();
                //DataTable2_Cell12.Colspan = 4;
                //DataTable2_Cell12.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //Paragraph DataTable2_P12 = new Paragraph();
                //Chunk DataTable2_C12 = new Chunk("Coupons & Discount (-)", FontNormal);
                //DataTable2_P12.Add(DataTable2_C12);
                //DataTable2_Cell12.AddElement(DataTable2_P12);
                //DataTable2.AddCell(DataTable2_Cell12);

                //PdfPCell DataTable2_Cell22 = new PdfPCell();
                //DataTable2_Cell22.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //Paragraph DataTable2_P22 = new Paragraph();
                //Chunk DataTable2_C22 = new Chunk(txtCouponsDiscounts.Text.Trim(), FontNormal);
                //DataTable2_P22.Add(DataTable2_C22);
                //DataTable2_Cell22.AddElement(DataTable2_P22);
                //DataTable2.AddCell(DataTable2_Cell22);

                document.Add(DataTable2);

                PointerPos = pdfWriter.GetVerticalPosition(false);
                cb.MoveTo(40, PointerPos - 10);
                cb.LineTo(document.PageSize.Width - 40, PointerPos - 10);
                cb.Stroke();

                PdfPTable DataTable3 = new PdfPTable(new float[] { 4f, 2f, 2f, 2f, 3f });
                DataTable3.WidthPercentage = 100;
                DataTable3.SpacingBefore = 20f;

                PdfPCell DataTable3_Cell1 = new PdfPCell();
                DataTable3_Cell1.Colspan = 4;
                DataTable3_Cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable3_P1 = new Paragraph();
                Chunk DataTable3_C1 = new Chunk("Total.", FontNormal);
                DataTable3_P1.Add(DataTable3_C1);
                DataTable3_Cell1.AddElement(DataTable3_P1);
                DataTable3.AddCell(DataTable3_Cell1);

                double total = (txtNetAmount.Text.Trim() == "" ? 0 : Convert.ToDouble(txtNetAmount.Text.Trim())) + (txtShipCharge.Text.Trim() == "" ? 0 : Convert.ToDouble(txtShipCharge.Text.Trim()));
                PdfPCell DataTable3_Cell2 = new PdfPCell();
                DataTable3_Cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable3_P2 = new Paragraph();
                Chunk DataTable3_C2 = new Chunk(Convert.ToString(total), FontNormal);
                DataTable3_P2.Add(DataTable3_C2);
                DataTable3_Cell2.AddElement(DataTable3_P2);
                DataTable3.AddCell(DataTable3_Cell2);

                document.Add(DataTable3);

                PointerPos = pdfWriter.GetVerticalPosition(false);
                cb.MoveTo(40, PointerPos - 10);
                cb.LineTo(document.PageSize.Width - 40, PointerPos - 10);
                cb.Stroke();

                PdfPTable DataTable4 = new PdfPTable(new float[] { 4f, 2f, 2f, 2f, 3f });
                DataTable4.WidthPercentage = 100;
                DataTable4.SpacingBefore = 20f;

                PdfPCell DataTable4_Cell1 = new PdfPCell();
                DataTable4_Cell1.Colspan = 4;
                DataTable4_Cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable4_P1 = new Paragraph();
                Chunk DataTable4_C1 = new Chunk("Coupons & Discount (-)", FontNormal);
                DataTable4_P1.Add(DataTable4_C1);
                DataTable4_Cell1.AddElement(DataTable4_P1);
                DataTable4.AddCell(DataTable4_Cell1);

                PdfPCell DataTable4_Cell2 = new PdfPCell();
                DataTable4_Cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable4_P2 = new Paragraph();
                Chunk DataTable4_C2 = new Chunk(txtCouponsDiscounts.Text.Trim(), FontNormal);
                DataTable4_P2.Add(DataTable4_C2);
                DataTable4_Cell2.AddElement(DataTable4_P2);
                DataTable4.AddCell(DataTable4_Cell2);

                document.Add(DataTable4);

                PointerPos = pdfWriter.GetVerticalPosition(false);
                cb.MoveTo(40, PointerPos - 10);
                cb.LineTo(document.PageSize.Width - 40, PointerPos - 10);
                cb.Stroke();

                PdfPTable DataTable5 = new PdfPTable(new float[] { 4f, 2f, 2f, 2f, 3f });
                DataTable5.WidthPercentage = 100;
                DataTable5.SpacingBefore = 20f;

                PdfPCell DataTable5_Cell1 = new PdfPCell();
                DataTable5_Cell1.Colspan = 4;
                DataTable5_Cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable5_P1 = new Paragraph();
                Chunk DataTable5_C1 = new Chunk("Grand Total.", FontNormal);
                DataTable5_P1.Add(DataTable5_C1);
                DataTable5_Cell1.AddElement(DataTable5_P1);
                DataTable5.AddCell(DataTable5_Cell1);

                PdfPCell DataTable5_Cell2 = new PdfPCell();
                DataTable5_Cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph DataTable5_P2 = new Paragraph();
                Chunk DataTable5_C2 = new Chunk(txtTotalAmt.Text.Trim(), FontNormal);
                DataTable5_P2.Add(DataTable5_C2);
                DataTable5_Cell2.AddElement(DataTable5_P2);
                DataTable5.AddCell(DataTable5_Cell2);

                document.Add(DataTable5);

                PointerPos = pdfWriter.GetVerticalPosition(true);
                cb.MoveTo(40, PointerPos - 10);
                cb.LineTo(document.PageSize.Width - 40, PointerPos - 10);
                cb.Stroke();

                Paragraph DataTable3_P51 = new Paragraph();
                DataTable3_P51.SpacingBefore = 20f;
                Chunk DataTable3_C51 = new Chunk("Authorized Signatory", FontNormal);
                DataTable3_P51.Add(DataTable3_C51);
                DataTable3_P51.Alignment = Element.ALIGN_RIGHT;
                document.Add(DataTable3_P51);

                Paragraph DataTable3_P52 = new Paragraph();
                DataTable3_P52.SpacingBefore = 10f;
                Chunk DataTable3_C52 = new Chunk("ND Mobile         ", FontNormal);
                DataTable3_P52.Add(DataTable3_C52);
                DataTable3_P52.Alignment = Element.ALIGN_RIGHT;
                document.Add(DataTable3_P52);

                document.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception In GenerateBill. Ex - " + ex.Message.ToString());
            }
        }

        private void CalculateAmounts()
        {
            try
            {
                if (txtQty.Text != "" && txtPrice.Text != "" && txtTax.Text != "")
                {
                    if (Convert.ToDouble(txtQty.Text.Trim()) > 0 && Convert.ToDouble(txtPrice.Text.Trim()) > 0 && Convert.ToDouble(txtTax.Text.Trim()) > 0)
                    {
                        double qtyPrice = 0;
                        double taxPrice = 0;
                        double netPrice = 0;
                        qtyPrice = Convert.ToDouble(txtQty.Text.Trim()) * Convert.ToDouble(txtPrice.Text.Trim());
                        taxPrice = (Convert.ToDouble(txtTax.Text.Trim()) * qtyPrice) / 100;
                        txtTaxAmt.Text = Convert.ToString(taxPrice);
                        netPrice = qtyPrice + taxPrice;
                        txtNetAmount.Text = Convert.ToString(netPrice);
                        txtTotalAmt.Text = Convert.ToString(netPrice + (txtShipCharge.Text.Trim() == "" ? 0 : Convert.ToDouble(txtShipCharge.Text.Trim())) - (txtCouponsDiscounts.Text.Trim() == "" ? 0 : Convert.ToDouble(txtCouponsDiscounts.Text.Trim())));
                    }
                }
                //else
                //{
                //    MessageBox.Show("Enter Proper Quantity OR Price OR Tax Value In %");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception In CalculateAmounts. Ex - " + ex.Message.ToString());
            }
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            CalculateAmounts();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateAmounts();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            CalculateAmounts();
        }

        private void txtShipCharge_TextChanged(object sender, EventArgs e)
        {
            CalculateAmounts();
        }

        private void txtCouponsDiscounts_TextChanged(object sender, EventArgs e)
        {
            CalculateAmounts();
        }
    }
}
