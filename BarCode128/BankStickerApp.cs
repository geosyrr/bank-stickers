using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;
using Rectangle = iTextSharp.text.Rectangle;

namespace BarCode128
{
    public partial class BankStickerApp : Form
    {
        public BankStickerApp()
        {
            InitializeComponent();
            VoucherNo.Enabled = false;
            VoucherNo.Text = File.ReadAllText("BankNumber.txt");


            SelectBank.SelectedIndex = 0;
        }

        public string GetBankCode(int selectedIndex)
        {
            var rValue = String.Empty;

            if (selectedIndex < 0)
            {
                return rValue;
            }

            if (selectedIndex == 0)
            {
                return rValue = "14";
            }
            else if (selectedIndex == 1)
            {
                return rValue = "27";
            }
            else if (selectedIndex == 2)
            {
                return rValue = "28";
            }

            return rValue;
        }


        private string GetVoucherCode128(string bankCode, string bankBranchCode, long originalNumber)
        {
            var rValue = String.Empty;

            if (String.IsNullOrWhiteSpace(bankCode) || String.IsNullOrWhiteSpace(bankBranchCode) || originalNumber <= 0)
            {
                return rValue;
            }

            // Βήμα 1: Εισάγουμε στην εφαρμογή έναν 9ψήφιο αριθμό.
            // Βήμα 2: Προσθέτουμε τον αριθμό 21, στην αρχή του αριθμού από το Βήμα 1.
            // Βήμα 3: Διαιρούμε τον αριθμό από το Βήμα 2, με τον αριθμό 11 και κρατάμε μόνο το ακέραιο μέρος.
            // Βήμα 4: Πολλαπλασιάζουμε τον αριθμό από το Βήμα 3, με τον αριθμό 11.
            // Βήμα 5: Αφαιρούμε από τον αριθμό από το Βήμα 2, τον αριθμό από τον Βήμα 4 και το αποτέλεσμα είναι το check digit.Στην περίπτωση που το check digit που προκύπτει είναι ίσο με 10, τότε μετατρέπεται σε 0.
            // Βήμα 6: 21++ Αριθμός τράπεζας ++Αριθμός καταστήματος++ Αριθμός από το Βήμα 1++ Check digit.

            // Παρακάτω ένα παράδειγμα εφαρμογής του αλγόριθμου, για το κατάστημα 0909 της τράπεζας Eurobank(27).
            // Βήμα 1: 222007036
            // Βήμα 2: 21++ 222007036 => 21222007036
            // Βήμα 3: 21222007036 / 11 => 1929273366
            // Βήμα 4: 1929273366 * 11 => 21222007026
            // Βήμα 5: 21222007036 - 21222007026 => 10 => 0
            // Βήμα 6: 21++ 27++ 0909++ 222007036++ 0 => 212709092220070360

            var step2Result = Convert.ToInt64("21" + originalNumber);
            long step3Result = step2Result / 11;
            long step4Result = step3Result * 11;
            long step5Result = step2Result - step4Result;

            if (step5Result == 10)
            {
                step5Result = 0;
            }

            rValue = $"21-{bankCode}-{bankBranchCode}-{originalNumber}-{step5Result}";

            return rValue;
        }

        public void Print_Click_1(object sender, EventArgs e)
        {
            SelectBankError.Text = String.Empty;
            SelectBankCodeError.Text = String.Empty;

            long originalNumber = Convert.ToInt64(VoucherNo.Text);
            string bankCode = GetBankCode(SelectBank.SelectedIndex);
            string bankBranchCode = CodeOfBank.Text;
            int quantity = Convert.ToInt32(quantityNo.Value);

            if (String.IsNullOrEmpty(bankCode))
            {
                SelectBankError.Text = "Please choose a bank from list";
                SelectBankError.Visible = true;
            }

            if (!Regex.IsMatch(bankBranchCode, "^([0-9]{4})$"))
            {
                SelectBankCodeError.Text = "The required digits are 4";
                SelectBankCodeError.Visible = true;
                return;
            }

            var path = $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.pdf";

            BaseFont bfTimes = BaseFont.CreateFont("Arimo-Regular.ttf", BaseFont.IDENTITY_H, true);

            try
            {
                var pgSize = new iTextSharp.text.Rectangle(190f, 115f);
                using (Document doc = new Document(pgSize, -20, -20, 0, 0))
                {

                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

                    doc.Open();
                    PdfContentByte cb = writer.DirectContent;
                    for (int i = 0; i < quantity; i++)
                    {
                        //writer.PageEvent = new PageViewEvent();
                        doc.NewPage();

                        var codeWithDashes = GetVoucherCode128(bankCode, bankBranchCode, originalNumber + i);

                        if (String.IsNullOrWhiteSpace(codeWithDashes))
                        {
                            return;
                        }

                        var codeWithoutDashes = codeWithDashes.Replace("-", "");

                        // MORE INFO: https://www.mikesdotnetting.com/article/80/create-pdfs-in-asp-net-getting-started-with-itextsharp
                        // MORE INFO: https://forums.asp.net/t/1599409.aspx?Itextsharp+add+barcode+image+to+pdf+on+the+fly

                        //var doc = new Document(PageSize.A6);
                        //PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                        //doc.Open();
                        //doc.Add(new Paragraph("This is a custom size"));
                        //doc.Close();

                        Barcode128 bc = new Barcode128();
                        bc.Code = codeWithoutDashes;
                        bc.Size = 9;
                        bc.X = 1.3f;
                        bc.BarHeight = 35f;
                        bc.CodeType = Barcode128.CODE128;
                        bc.CodeSet = Barcode128.Barcode128CodeSet.C;

                        iTextSharp.text.Image image = bc.CreateImageWithBarcode(cb, null, null);
                        PdfPCell cell01 = new PdfPCell(new Phrase(codeWithoutDashes, new Font(bfTimes, 8, iTextSharp.text.Font.BOLD)));
                        cell01.PaddingBottom = 5f;
                        cell01.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell01.BorderWidth = 0;
                        PdfPCell cell02 = new PdfPCell(new Phrase(codeWithoutDashes, new Font(bfTimes, 8, iTextSharp.text.Font.BOLD)));
                        cell02.PaddingBottom = 2f;
                        cell02.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell02.BorderWidth = 0;
                        PdfPCell cell03 = new PdfPCell(new Phrase(" ", new Font(bfTimes, 11, iTextSharp.text.Font.NORMAL)));
                        cell03.BorderWidth = 0;
                        cell03.PaddingBottom = 10f;
                        PdfPCell cell04 = new PdfPCell(new Phrase($"{SelectBank.Text}{Environment.NewLine}{bankBranchCode}", new Font(bfTimes, 9, iTextSharp.text.Font.NORMAL)));
                        cell04.BorderWidth = 0;
                        cell04.PaddingBottom = 16f;
                        cell04.HorizontalAlignment = Element.ALIGN_CENTER;
                        PdfPCell cell05 = new PdfPCell(image);
                        cell05.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell05.PaddingBottom = 4f;
                        cell05.BorderWidth = 0;
                        cell05.Colspan = 2;

                        PdfPCell cell06 = new PdfPCell(new Phrase(codeWithDashes, new Font(bfTimes, 10, iTextSharp.text.Font.NORMAL)));
                        cell06.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell06.BorderWidth = 0;
                        cell06.Colspan = 2;
                        //image.ScaleAbsolute(240f, 87f);

                        PdfPTable table = new PdfPTable(2);
                        table.AddCell(cell01);
                        table.AddCell(cell02);
                        table.AddCell(cell03);
                        table.AddCell(cell04);
                        table.AddCell(cell05);
                        table.AddCell(cell06);

                        doc.Add(table);

                    }
                    doc.Close();
                }
            }
            catch (Exception ex)
            {

            }

            var lastUsedNumber = (Convert.ToInt64(VoucherNo.Text) + Convert.ToInt32(quantityNo.Value)).ToString();

            VoucherNo.Text = lastUsedNumber;
            File.WriteAllText("BankNumber.txt", lastUsedNumber);

            SendToPrinter(path);
        }

        private string ConvertToCode128C(string initialText)
        {
            var rValue = String.Empty;



            return rValue;
        }


        // MORE INFO: https://stackoverflow.com/questions/6103705/how-can-i-send-a-file-document-to-the-printer-and-have-it-print
        private void SendToPrinter(string path)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "Print";
            info.FileName = path;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();
            p.WaitForInputIdle();

            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
                p.Kill();
        }

       
    }
}

