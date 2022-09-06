using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev2_SayiTahminiOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        { InitializeComponent(); }
        int erzurum = 0, bursa_sayisi = 0, bursa = 0, manti = 0, sarma = 0, bursa_birler, bursa_onlar, bursa_yuzler, bursa_binler, erzurum_birler, erzurum_onlar, erzurum_yuzler, erzurum_binler;
        //bursa tahmin edilen sayı, erzurum random sayı, manti = bulunduğu basamak doğru olan sayı
        //sarma = sayı doğru ama yanlış basamakta


        private void button1_Click(object sender, EventArgs e)
        {
            int c = 0;
            while (c < 1)
            {
                button2.Enabled = true; //tahmin girilebilmesi icin tamam butonunu etkin hale getiririz
                button1.Enabled = false; //program bitmeden tekrar yeni bir sayi uretilmemesi icin basla butonunu pasif ederiz

                Random rastgele = new Random();
                erzurum = rastgele.Next(1000, 9999);
               // textBox1.Text = erzurum.ToString(); //atanan random sayi bunu ekrana yazdirmiyoruz

                //erzurum yani random sayisini basamaklarina ayiriyoruz
                erzurum_birler = erzurum - ((erzurum / 10) * 10);
                erzurum = erzurum / 10;

                erzurum_onlar = erzurum - ((erzurum / 10) * 10);
                erzurum = erzurum / 10;

                erzurum_yuzler = erzurum - ((erzurum / 10) * 10);
                erzurum = erzurum / 10;

                erzurum_binler = erzurum - ((erzurum / 10) * 10);
                erzurum = erzurum / 10;

                if (erzurum_birler != erzurum_onlar && erzurum_birler != erzurum_yuzler && erzurum_birler != erzurum_binler && erzurum_onlar != erzurum_yuzler && erzurum_onlar != erzurum_binler && erzurum_yuzler != erzurum_binler)
                {
                    c++; //atanan erzurum(random) sayisinin rakamlarinin birbirinden farklı oldugunu kontrol amacli 
                         //if yapısını kullaniyoruz
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int b = 0;

            do
            {
                //her basamağı tek tek karsiastirmak icin bursa(tahmin)sayisinida basamaklarina ayiriyoruz
                int bursa = Convert.ToInt32(textBox2.Text); //bursa sayisini textBox 2 ye yazdiririz
                bursa_birler = bursa - ((bursa / 10) * 10);
                bursa = bursa / 10;

                bursa_onlar = bursa - ((bursa / 10) * 10);
                bursa = bursa / 10;

                bursa_yuzler = bursa - ((bursa / 10) * 10);
                bursa = bursa / 10;

                bursa_binler = bursa - ((bursa / 10) * 10);
                bursa = bursa / 10;

                bursa_sayisi++;
                textBox4.Text = bursa_sayisi.ToString();
                 //tahmin isimli int türündeki değişkene texbox2 ye yazılan değerin aktarılmasını sağlıyor

                if (bursa_birler != bursa_onlar && bursa_birler != bursa_yuzler && bursa_birler != bursa_binler && bursa_onlar != bursa_yuzler && bursa_onlar != bursa_binler && bursa_yuzler != bursa_binler)

                    b++; //atanan girilen bursa(tahmin) sayisinin rakamlarinin birbirinden farklı oldugunu kontrol amacli 
                         //if yapısını kullaniyoruz

                else

                    MessageBox.Show("Geçersiz sayı girdiniz! Lütfen rakamları farklı bir sayı giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //sayinin rakamlari farkli degilse ekrana uyari verir

                manti = 0;
                sarma = 0;
                textBox3.Text = "0 "+manti+"0"+sarma; //sayi gecersizse ipucu olarak 0,0 yazar
            }
            while (b < 0 && (bursa_birler != bursa_onlar && bursa_birler != bursa_yuzler && bursa_birler != bursa_binler && bursa_onlar != bursa_yuzler && bursa_onlar != bursa_binler && bursa_yuzler != bursa_binler));
            {
                if (erzurum_birler == bursa_birler)
                {                                                                                   //random sayi ile tahmin edilen sayinin basamaklari tek tek karsilastiriliyor
                    manti++;
                }
                if (erzurum_birler == bursa_onlar || erzurum_birler == bursa_yuzler || erzurum_birler == bursa_binler)
                {
                    sarma++;
                }
                if (erzurum_onlar == bursa_onlar)
                {
                    manti++;
                }
                if (erzurum_onlar == bursa_birler || erzurum_onlar == bursa_yuzler || erzurum_onlar == bursa_binler)
                {
                    sarma++;
                }
                if (erzurum_yuzler == bursa_yuzler)
                {
                    manti++;
                }
                if (erzurum_yuzler == bursa_birler || erzurum_yuzler == bursa_onlar || erzurum_yuzler == bursa_binler)
                {
                    sarma++;
                }
                if (erzurum_binler == bursa_binler)
                {
                    manti++;
                }
                if (erzurum_binler == bursa_birler || erzurum_binler == bursa_onlar || erzurum_binler == bursa_yuzler)
                {
                    sarma++;
                
                }
            textBox3.Text = "(+" + manti + ",-" + sarma + ")"; //ipucu degerlerini textBox 3 e yazdirir
            }

            if (manti == 4 && sarma == 0) //ipucu 4,0 olursa programin sona ermesini ve ekrana tebrikler yazilmasini sagliyor
            {
                MessageBox.Show("Tebrikler!\n" + bursa_sayisi.ToString() + ". tahminde sayıyı buldunuz.", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Enabled = true; //oyunun tekrar baslatılması icin basla butonu aktif edilir
                button2.Enabled = false; //dogru cevap verildiği icin tamam butonu devredisi birakilir
            }
        }
            private void Form1_Load(object sender, EventArgs e)
            {
                button2.Enabled = false; //program basladiginda tamam butonu devredisi birakilir
            }
        
    }
}
