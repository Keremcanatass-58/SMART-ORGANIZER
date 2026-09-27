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
    public partial class DosyaAraForm : Form
    {
        public DosyaAraForm()
        {
            InitializeComponent();
            
            InitializeListViewColumns();
        }

        
        private void InitializeListViewColumns()
        {
            
            if (listView1 != null && listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Dosya Adı", 200);
                listView1.Columns.Add("Tarih", 120);
                listView1.Columns.Add("Boyut", 100);
                
                listView1.ContextMenuStrip = contextMenuStrip1; 
            }
        }


        private void btnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); 

            string aramaMetni = txtAra.Text.Trim();
            if (string.IsNullOrEmpty(aramaMetni))
            {
                MessageBox.Show("Lütfen arama kriteri giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            List<string> aramaKlasorleri = new List<string>
            {
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), 
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)    
                
            };

            List<FileInfo> bulunanDosyalar = new List<FileInfo>();
            foreach (string klasorYolu in aramaKlasorleri)
            {
                if (!Directory.Exists(klasorYolu))
                {
                    Console.WriteLine($"Klasör bulunamadı veya erişilemez: {klasorYolu}");
                    continue; 
                }

                try
                {
                    IEnumerable<string> dosyalar = Directory.EnumerateFiles(klasorYolu, "*.*", SearchOption.AllDirectories);

                    foreach (string dosyaYolu in dosyalar)
                    {
                        try
                        {
                            
                            if (Path.GetFileName(dosyaYolu).IndexOf(aramaMetni, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                dosyaYolu.IndexOf(aramaMetni, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                FileInfo fi = new FileInfo(dosyaYolu);
                                bulunanDosyalar.Add(fi);
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            
                            Console.WriteLine($"Erişim reddedildi: {dosyaYolu}");
                        }
                        catch (IOException)
                        {
                            
                            Console.WriteLine($"G/Ç Hatası: {dosyaYolu}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Dosya işlenirken bir hata oluştu ({dosyaYolu}): {ex.Message}");
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Klasör erişimi reddedildi: {klasorYolu}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Arama sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
            if (bulunanDosyalar.Count > 0)
            {
                foreach (FileInfo fi in bulunanDosyalar.OrderBy(f => f.Name)) 
                {
                    ListViewItem item = new ListViewItem(fi.Name);
                    item.SubItems.Add(fi.LastWriteTime.ToShortDateString());
                    item.SubItems.Add(FormatSize(fi.Length));
                    item.Tag = fi.FullName; 
                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Aradığınız kriterlere uygun dosya bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        
        private void btnArsiv_Click(object sender, EventArgs e)
        {
            Arsivform arsivform = new Arsivform();
            arsivform.Show();
            this.Close(); 
        }

        private void btnMedyalar_Click(object sender, EventArgs e)
        {
            MedyalarForm form = new MedyalarForm();
            form.Show();
            this.Close(); 
        }

        private void btnBelgeler_Click(object sender, EventArgs e)
        {
            BelgelerForm form = new BelgelerForm();
            form.Show();
            this.Close(); 
        }

        private void btnTumDosyalar_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
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