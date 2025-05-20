using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; 

namespace SmartOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            List<ListView> listViews = new List<ListView> { listView1, listView2, listView3, listView4 };
            foreach (var lv in listViews)
            {
                lv.Columns.Add("Dosya Adı", 200);
                lv.Columns.Add("Tarih", 120);
                lv.Columns.Add("Boyut", 100);
               
            }

            string[] belgeUzantilari = { ".doc", ".docx", ".pdf", ".txt", ".xls", ".xlsx", ".ppt", ".pptx" };
            string[] medyaUzantilari = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".mp4", ".avi", ".mkv", ".mp3" };
            string[] uygulamaUzantilari = { ".exe", ".msi" };
            string[] yazilimUzantilari = { ".cs", ".js", ".py", ".java", ".html", ".css", ".cpp", ".php", ".ts" };

            List<string> klasorler = new List<string>
            {
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads")
            };

            foreach (string klasor in klasorler)
            {
                if (!Directory.Exists(klasor)) continue;

                string[] dosyalar = Directory.GetFiles(klasor);
                foreach (string dosya in dosyalar)
                {
                    FileInfo fi = new FileInfo(dosya);
                    string uzanti = fi.Extension.ToLower();

                    ListViewItem item = new ListViewItem(fi.Name);
                    item.SubItems.Add(fi.LastWriteTime.ToShortDateString());
                    item.SubItems.Add(FormatSize(fi.Length));
                   
                    item.Tag = fi.FullName; 

                    if (belgeUzantilari.Contains(uzanti))
                        listView1.Items.Add(item);
                    else if (medyaUzantilari.Contains(uzanti))
                        listView2.Items.Add(item);
                    else if (uygulamaUzantilari.Contains(uzanti))
                        listView3.Items.Add(item);
                    else if (yazilimUzantilari.Contains(uzanti))
                        listView4.Items.Add(item);
                }
            }

            string FormatSize(long bytes)
            {
                if (bytes >= 1024 * 1024)
                    return $"{(bytes / (1024f * 1024f)):0.0} MB";
                else if (bytes >= 1024)
                    return $"{(bytes / 1024f):0.0} KB";
                else
                    return $"{bytes} B";
            }
        }

        private void btnBelgeler_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBelgeler_Click_1(object sender, EventArgs e)
        {
            BelgelerForm form = new BelgelerForm();
            form.Show();
        }

        private void btnMedyalar_Click(object sender, EventArgs e)
        {
            MedyalarForm form = new MedyalarForm();
            form.Show();
        }

        private void btnArsiv_Click(object sender, EventArgs e)
        {
            Arsivform arsivform = new Arsivform();
            arsivform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DosyaAraForm form = new DosyaAraForm();
            form.Show();
        }

        
        private void tsmAc_Click(object sender, EventArgs e)
        {
            
            ListView activeLV = GetActiveListView(contextMenuStrip1); 
            if (activeLV != null && activeLV.SelectedItems.Count > 0)
            {
              
                string dosyaYolu = activeLV.SelectedItems[0].Tag?.ToString();

                if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(dosyaYolu); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Dosya açılırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Dosya bulunamadı veya yolu geçersiz: {dosyaYolu}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen açmak için bir dosya seçin.", "Uyarı");
            }
        }

        
        private ListView GetActiveListView(ContextMenuStrip menu)
        {
            Control sourceControl = menu.SourceControl;
            if (sourceControl is ListView)
            {
                return (ListView)sourceControl;
            }
            return null;
        }

        
        private void tsmKopyala_Click(object sender, EventArgs e)
        {
            ListView activeLV = GetActiveListView(contextMenuStrip1);
            if (activeLV != null && activeLV.SelectedItems.Count > 0)
            {
                string dosyaYolu = activeLV.SelectedItems[0].Tag?.ToString();
                if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
                {
                    
                    MessageBox.Show($"{Path.GetFileName(dosyaYolu)} kopyalandı (şimdilik sadece mesaj).", "Kopyala");
                }
                else
                {
                    MessageBox.Show("Kopyalanacak dosya bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen kopyalamak için bir dosya seçin.", "Uyarı");
            }
        }

        private void tsmSil_Click(object sender, EventArgs e)
        {
            ListView activeLV = GetActiveListView(contextMenuStrip1);
            if (activeLV != null && activeLV.SelectedItems.Count > 0)
            {
                string dosyaYolu = activeLV.SelectedItems[0].Tag?.ToString();
                if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
                {
                    DialogResult result = MessageBox.Show($"{Path.GetFileName(dosyaYolu)} silinecek. Emin misiniz?", "Silmeyi Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(dosyaYolu);
                            activeLV.Items.Remove(activeLV.SelectedItems[0]); 
                            MessageBox.Show($"{Path.GetFileName(dosyaYolu)} başarıyla silindi.", "Başarılı");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Dosya silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek dosya bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir dosya seçin.", "Uyarı");
            }
        }

        private void tsmYolaGit_Click(object sender, EventArgs e)
        {
            ListView activeLV = GetActiveListView(contextMenuStrip1);
            if (activeLV != null && activeLV.SelectedItems.Count > 0)
            {
                string dosyaYolu = activeLV.SelectedItems[0].Tag?.ToString();
                if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
                {
                    try
                    {
                        System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{dosyaYolu}\"");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Dizini açarken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dosya yolu bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen yolu gitmek için bir dosya seçin.", "Uyarı");
            }
        }
    }
}