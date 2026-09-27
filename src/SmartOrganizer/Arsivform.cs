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
    public partial class Arsivform : Form
    {
        public Arsivform()
        {
            InitializeComponent();
        }

        private void Arsivform_Load(object sender, EventArgs e)
        {
           
            listView1.Columns.Add("Dosya Adı", 200);
            listView1.Columns.Add("Tarih", 120);
            listView1.Columns.Add("Boyut", 100);

            
            string[] belgeUzantilari = { ".doc", ".docx", ".pdf", ".txt", ".xls", ".xlsx", ".ppt", ".pptx" };
            string[] medyaUzantilari = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".mp4", ".avi", ".mkv", ".mp3", ".wav", ".flac" }; 
            string[] uygulamaUzantilari = { ".exe", ".msi", ".bat", ".com" }; 
            string[] yazilimUzantilari = { ".cs", ".js", ".py", ".java", ".html", ".css", ".cpp", ".php", ".ts", ".xml", ".json" }; 

            
            string[] tumUzantilar = belgeUzantilari
                .Concat(medyaUzantilari)
                .Concat(uygulamaUzantilari)
                .Concat(yazilimUzantilari)
                .Distinct() 
                .ToArray();

           
            List<string> klasorler = new List<string>
            {
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
                
            };

            List<FileInfo> dosyalarListesi = new List<FileInfo>();

            foreach (string klasor in klasorler)
            {
                if (!Directory.Exists(klasor))
                {
                   
                    continue;
                }

               
                string[] dosyalar = Directory.GetFiles(klasor, "*.*", SearchOption.TopDirectoryOnly);

                foreach (string dosya in dosyalar)
                {
                    try 
                    {
                        FileInfo fi = new FileInfo(dosya);
                        string uzanti = fi.Extension.ToLower();

                        if (tumUzantilar.Contains(uzanti))
                        {
                            dosyalarListesi.Add(fi);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                      
                        Console.WriteLine($"Erişim engellendi: {dosya}");
                        continue;
                    }
                    catch (IOException)
                    {
                        
                        Console.WriteLine($"Dosya kullanımda: {dosya}");
                        continue;
                    }
                    catch (Exception ex)
                    {
                       
                        Console.WriteLine($"Dosya okunurken hata oluştu ({dosya}): {ex.Message}");
                        continue;
                    }
                }
            }

            
            var siraliDosyalar = dosyalarListesi.OrderByDescending(fi => fi.LastWriteTime).ToList(); // En yeniyi üste almak için Descending

            foreach (var fi in siraliDosyalar)
            {
                ListViewItem item = new ListViewItem(fi.Name);
                item.SubItems.Add(fi.LastWriteTime.ToShortDateString());
                item.SubItems.Add(FormatSize(fi.Length));
                item.Tag = fi.FullName; 
                listView1.Items.Add(item);
            }
        }

        
        private string FormatSize(long bytes)
        {
            if (bytes >= 1024 * 1024)
                return $"{(bytes / (1024f * 1024f)):0.0} MB";
            else if (bytes >= 1024)
                return $"{(bytes / 1024f):0.0} KB";
            else
                return $"{bytes} B";
        }

      
        private void btnBelgeler_Click(object sender, EventArgs e)
        {
            BelgelerForm form = new BelgelerForm();
            form.Show();
            this.Close();
        }

        private void btnTumDosyalar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMedyalar_Click(object sender, EventArgs e)
        {
            MedyalarForm form = new MedyalarForm();
            form.Show();
            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DosyaAraForm form = new DosyaAraForm();
            form.Show();
            this.Close(); 
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

       
        private void tsmKopyala_Click(object sender, EventArgs e)
        {
            ListView activeLV = GetActiveListView(contextMenuStrip1);
            if (activeLV != null && activeLV.SelectedItems.Count > 0)
            {
                string dosyaYolu = activeLV.SelectedItems[0].Tag?.ToString();
                if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
                {
                    try
                    {
                        
                        System.Collections.Specialized.StringCollection paths = new System.Collections.Specialized.StringCollection();
                        paths.Add(dosyaYolu);
                        Clipboard.SetFileDropList(paths);
                        MessageBox.Show($"{Path.GetFileName(dosyaYolu)} panoya kopyalandı.", "Kopyala");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Dosya kopyalanırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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