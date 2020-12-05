using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev3
{
    public class Bilgi
    {
        public Bilgi sonraki;
        public int islemsuresi;
        public int beklemesüresi;
        public string isim;
        public int oncelik;
        public Bilgi (string isim, int oncelik, int islemsuresi) {
            this.oncelik = oncelik;
            this.islemsuresi = islemsuresi;
            this.isim = isim;
        }
    }
    public class Liste {
        Bilgi ilk = null;
        Bilgi son = null;
        public int maxsize;
        public string son_alinan_kisi;
        public void add_sira(string isim, int oncelik, int islemsuresi)
        {
            if (size()<maxsize)
            {
                Bilgi bilgi = new Bilgi(isim, oncelik, islemsuresi);
                bilgi.beklemesüresi = sureHesapla(oncelik);
                Bilgi gecici = ilk;
                Bilgi bironceki = null;
                while (gecici != null && gecici.oncelik <= bilgi.oncelik)
                {
                    bironceki = gecici;
                    gecici = gecici.sonraki;
                }
                if (ilk == null && son == null)
                {
                    ilk = bilgi;
                    son = bilgi;
                    son.sonraki = null;
                }
                else
                {
                    try
                    {                        
                        bironceki.sonraki = bilgi;
                        bilgi.sonraki = gecici;
                        if (gecici == null)// döngü sona kadar ulaştıysa
                        {
                            son = bilgi;
                            son.sonraki = null;
                        }
                    }
                    catch
                    {                        
                        bilgi.sonraki = ilk;
                        ilk = bilgi;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Max Değere Ulaşıldı");
            }
            guncelle();
          

        }
        public int size()
        {
            int sayac = 0;
            Bilgi gecici = ilk;
            while (gecici!= null)
            {
                sayac++;
                gecici = gecici.sonraki;
            }
            return sayac;
        }
        public void kisial()
        {                     
            if (size() != 0)
            {
                if (son == ilk)
                {
                    son_alinan_kisi = ilk.isim;
                    ilk = null;
                    son = null;
                }
                else
                {
                   son_alinan_kisi = ilk.isim;
                   ilk = ilk.sonraki;
                }
            }
            else
            {
                MessageBox.Show("Listede Eleman Yok");
            }
            guncelle();
        }
        public void listBoxaEkle(ListBox x, ListBox y, ListBox z)
        {
            Bilgi gecici = ilk;
            while (gecici != null)
            {
                if (gecici.oncelik==1)
                {
                    x.Items.Add(gecici.isim + " İşlem=" + gecici.islemsuresi + " Bek.=" + gecici.beklemesüresi);
                    gecici = gecici.sonraki;
                }
                else if (gecici.oncelik==2)
                {
                    y.Items.Add(gecici.isim + " İşlem=" + gecici.islemsuresi + " Bek.=" + gecici.beklemesüresi);
                    gecici = gecici.sonraki;
                }
                else
                {
                    z.Items.Add(gecici.isim + " İşlem=" + gecici.islemsuresi + " Bek.=" + gecici.beklemesüresi);
                    gecici = gecici.sonraki;
                }                
            }           
        }
        public int sureHesapla(int oncelik)
        {
            Bilgi gecici = ilk;
            int sonuc = 0;
            
                while (gecici != null && gecici.oncelik <= oncelik)
                {
                    sonuc = sonuc + gecici.islemsuresi;
                    gecici = gecici.sonraki;
                }
        
            return sonuc;
        }
        public void guncelle()
        {
            Bilgi gecici = ilk;
            int toplam = 0;
            while (gecici!=null)
            {
                gecici.beklemesüresi = toplam;
                toplam += gecici.islemsuresi;
                gecici = gecici.sonraki;
            }
        }

    }
}
