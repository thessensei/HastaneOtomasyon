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
using static System.Net.WebRequestMethods;

namespace HastaneOtomasyon
{
    public partial class Randevuİslemleri: Form
    {
        public Randevuİslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (VeriKontrolEt()==true)
            {
                bool nullMu = AnaForm.hastane.RandevuAra(int.Parse(textBox4.Text))==null;
                if (nullMu)
                {
                    Randevu randevu = new Randevu
                    {
                        Isim = textBox1.Text,
                        Soyisim = textBox2.Text,
                        Hastalık = comboBox1.Text,
                        Tcno = Convert.ToInt32(textBox4.Text),
                        Telno = int.Parse(textBox5.Text)
                    };
                    AnaForm.hastane.RandevuEkle(randevu);
                    MessageBox.Show("Randevu OLuşturulmuştur");
                    string[] array = new string[]
                    {
                    randevu.Isim,
                    randevu.Soyisim,
                    randevu.Hastalık,
                    randevu.Telno.ToString(),
                    randevu.Tcno.ToString()
                    };
                    listView1.Items.Add(new ListViewItem(array));
                }
                else
                {
                    MessageBox.Show("O Tc ile Dahan Önceden Randevu OLuşturulmuştur.");
                }
                
            }
        }
        public bool VeriKontrolEt()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen İsminizi Giriniz.");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {

                MessageBox.Show("Lütfen Soy İsminizi Giriniz.");
                return false;
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Lütfen Hastalık Türü Giriniz.");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Lütfen TC No Giriniz.");
                return false;
            }
            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Lütfen Telefon No Giriniz.");
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void Randevuİslemleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnaForm anaForm = new AnaForm();
            anaForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string text = listView1.SelectedItems[3].Text;
                Randevu randevu = AnaForm.hastane.RandevuAra(int.Parse(text));
                if (randevu != null)
                {
                    AnaForm.hastane.RandevuSil(randevu);
                    if (AnaForm.hastane.RandevuSil(randevu) == true)
                    {
                        MessageBox.Show("Film başarıyla silindi.");
                        this.listView1.Items.Remove(this.listView1.SelectedItems[0]);

                    }
                    else
                        MessageBox.Show("Hatayla Karşılaşıldı");
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string text = this.listView1.SelectedItems[0].Text;
                Randevu randevu = AnaForm.hastane.RandevuAra(int.Parse(text));
                if (randevu != null)
                {
                    if (VeriKontrolEt())
                    {
                        randevu.Isim = textBox1.Text;
                        randevu.Soyisim = textBox2.Text;
                        randevu.Hastalık = comboBox1.Text;
                        randevu.Tcno = int.Parse(textBox4.Text);
                        randevu.Telno = int.Parse(textBox5.Text);
                        bool GuncellendiMi = AnaForm.hastane.RandevuGuncelle(randevu);
                        if (GuncellendiMi)
                        {
                            MessageBox.Show("Başarıyla Güncellendi");
                            listView1.Items.Clear();
                            foreach (Randevu randevu1 in AnaForm.hastane.randevular)
                            {
                                string[] array = new string[]
                                {
                                    randevu1.Isim,
                                    randevu1.Soyisim,
                                    randevu1.Hastalık,
                                    randevu1.Tcno.ToString(),
                                    randevu1.Telno.ToString()
                                };
                                listView1.Items.Add(new ListViewItem(array));
                            }
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Güncellek istediğiniz şeyleri girin.");
                    }
                }
            }
        }
    }
}
