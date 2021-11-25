using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;

namespace MarDevs.OC.Core
{
	public class ReportPrinter
	{
		public void ImprimirReporte(LocalReport report, string printerName)
		{
			ImprimirReporte(report, printerName, false);
		}
		public void ImprimirReporte(LocalReport report, string printerName, bool horizontal)
		{
			ReportPageSettings settings = report.GetDefaultPageSettings();
			decimal height = horizontal ? settings.PaperSize.Width : settings.PaperSize.Height;
			decimal width = horizontal ? settings.PaperSize.Height : settings.PaperSize.Width;
			decimal marginTop = settings.Margins.Top;
			decimal marginBottom = settings.Margins.Bottom;
			decimal marginLeft = settings.Margins.Left;
			decimal marginRight = settings.Margins.Right;
			height = height / 100;
			width = width / 100;
			marginTop = marginTop / 100;
			marginBottom = marginBottom / 100;
			marginLeft = marginLeft / 100;
			marginRight = marginRight / 100;
			string deviceInfo =
			  "<DeviceInfo>" +
			  "  <OutputFormat>EMF</OutputFormat>" +
			  "  <PageWidth>" + width.ToString(CultureInfo.InvariantCulture) + "in</PageWidth>" +
			  "  <PageHeight>" + height.ToString(CultureInfo.InvariantCulture) + "in</PageHeight>" +
			  "  <MarginTop>" + marginTop.ToString(CultureInfo.InvariantCulture) + "in</MarginTop>" +
			  "  <MarginLeft>" + marginLeft.ToString(CultureInfo.InvariantCulture) + "in</MarginLeft>" +
			  "  <MarginRight>" + marginRight.ToString(CultureInfo.InvariantCulture) + "in</MarginRight>" +
			  "  <MarginBottom>" + marginBottom.ToString(CultureInfo.InvariantCulture) + "in</MarginBottom>" +
			  "</DeviceInfo>";

			Warning[] warnings;
			m_streams = new List<Stream>();
			report.Render("Image", deviceInfo, CreateStream, out warnings);

			foreach (Stream stream in m_streams)
				stream.Position = 0;

			//IMPRIMIR EL REPORTE
			if (m_streams == null || m_streams.Count == 0)
				return;

			PrintDocument printDoc = new PrintDocument();
			printDoc.PrinterSettings.PrinterName = printerName;
			
			printDoc.PrinterSettings.DefaultPageSettings.Landscape = horizontal;
			printDoc.DefaultPageSettings.Landscape = horizontal;
			
			printDoc.PrinterSettings.DefaultPageSettings.PaperSize = settings.PaperSize;
			printDoc.DefaultPageSettings.PaperSize = settings.PaperSize;

			if (!printDoc.PrinterSettings.IsValid)
			{
				string msg = String.Format("Can't find printer \"{0}\".", printerName);
				Console.WriteLine(msg);
				return;
			}
			printDoc.PrintPage += new PrintPageEventHandler(PrintReportPage);
			printDoc.Print();
		}
		public byte[] GenerarPDFReporte(LocalReport report, bool horizontal)
		{
			ReportPageSettings settings = report.GetDefaultPageSettings();
			decimal height = horizontal ? settings.PaperSize.Width : settings.PaperSize.Height;
			decimal width = horizontal ? settings.PaperSize.Height : settings.PaperSize.Width;
			decimal marginTop = settings.Margins.Top;
			decimal marginBottom = settings.Margins.Bottom;
			decimal marginLeft = settings.Margins.Left;
			decimal marginRight = settings.Margins.Right;
			height = height / 100;
			width = width / 100;
			marginTop = marginTop / 100;
			marginBottom = marginBottom / 100;
			marginLeft = marginLeft / 100;
			marginRight = marginRight / 100;
			string deviceInfo =
			  "<DeviceInfo>" +
			  "  <OutputFormat>PDF</OutputFormat>" +
			  "  <PageWidth>" + width.ToString(CultureInfo.InvariantCulture) + "in</PageWidth>" +
			  "  <PageHeight>" + height.ToString(CultureInfo.InvariantCulture) + "in</PageHeight>" +
			  "  <MarginTop>" + marginTop.ToString(CultureInfo.InvariantCulture) + "in</MarginTop>" +
			  "  <MarginLeft>" + marginLeft.ToString(CultureInfo.InvariantCulture) + "in</MarginLeft>" +
			  "  <MarginRight>" + marginRight.ToString(CultureInfo.InvariantCulture) + "in</MarginRight>" +
			  "  <MarginBottom>" + marginBottom.ToString(CultureInfo.InvariantCulture) + "in</MarginBottom>" +
			  "  <StartPage>0</StartPage>" +		
			  "</DeviceInfo>";

			Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = report.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
			return bytes;
		}

		private int m_currentPageIndex = 0;
		private List<Stream> m_streams;
		private void PrintReportPage(object sender, PrintPageEventArgs ev)
		{
			Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
			ev.Graphics.DrawImage(pageImage, ev.PageBounds);

			m_currentPageIndex++;
			ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
		}
		private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
		{
			//Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
			Stream stream = new MemoryStream();
			m_streams.Add(stream);
			return stream;
		}

		[DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesW", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		static extern int DocumentProperties(IntPtr hwnd, IntPtr hPrinter, [MarshalAs(UnmanagedType.LPWStr)] string pDeviceName, IntPtr pDevModeOutput, ref IntPtr pDevModeInput, int fMode);
		[DllImport("kernel32.dll")]
		static extern IntPtr GlobalLock(IntPtr hMem);
		[DllImport("kernel32.dll")]
		static extern bool GlobalUnlock(IntPtr hMem);
		[DllImport("kernel32.dll")]
		static extern bool GlobalFree(IntPtr hMem);

		public static void OpenPrinterPropertiesDialog(string nombreImpresora, IntPtr handle)
		{
			PrinterSettings printerSettings = new PrinterSettings();
			printerSettings.PrinterName = nombreImpresora;

			IntPtr hDevMode = printerSettings.GetHdevmode(printerSettings.DefaultPageSettings);
			IntPtr pDevMode = GlobalLock(hDevMode);
			int sizeNeeded = DocumentProperties(handle, IntPtr.Zero, printerSettings.PrinterName, pDevMode, ref pDevMode, 0);
			IntPtr devModeData = Marshal.AllocHGlobal(sizeNeeded);
			DocumentProperties(handle, IntPtr.Zero, printerSettings.PrinterName, devModeData, ref pDevMode, 14);
			GlobalUnlock(hDevMode);
			printerSettings.SetHdevmode(devModeData);
			printerSettings.DefaultPageSettings.SetHdevmode(devModeData);
			GlobalFree(hDevMode);
			Marshal.FreeHGlobal(devModeData);
		}
	}
}
