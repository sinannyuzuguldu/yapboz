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

namespace Yaz2Lab1
{


    public partial class Form1 : Form
    {
        Bitmap resim;
        int h, w;
        int btiksayisi = 0;
        int skor = 100;
        int dogruparcasayisi = 0;
        int source;
        Dictionary<int, string> enyuksek = new Dictionary<int, string>();
        String kullanıcı="";
        Color kenarlıkrengi;
        Object kaynakbuton;
        string[] isim = new string[20];
        int[] puan = new int[20];
        int ksayisi = 0;

        Bitmap[] buton = new Bitmap[16];
        Bitmap[] butonyedek = new Bitmap[16];
        Bitmap kaynakresim;

        public Form1()
        {
            InitializeComponent();
            oku();

        }

        public string kullaniciAdi { get; set; }

        private void parcala()
        {
            int wk = 0;
            int hk = 0;
            int bsayisi = 0;
            int i = 0;
            int j = 0;




            for (j = hk * h / 4; j < (hk + 1) * (h / 4); j++)
            {
                if (j > h)
                    break;
                for (i = (wk * w / 4); i < ((wk + 1) * w / 4); i++)
                {
                    buton[bsayisi].SetPixel((i % (w / 4)), (j % (h / 4)), resim.GetPixel(i, j));

                }

                if (i == w && j == ((hk + 1) * h / 4) - 1)
                {
                    //MessageBox.Show(i + "b" + j+"hk"+hk+"wk"+wk + "bs" + bsayisi);
                    hk++;
                    j = hk * h / 4;
                    wk = 0;
                    i = wk * w / 4;
                    bsayisi++;

                }
                else if (i == ((wk + 1) * w / 4) && j == ((hk + 1) * h / 4) - 1)
                {
                    //MessageBox.Show(i + " a" + j + "hk" + hk + "wk" + wk+"bs"+bsayisi);
                    j = hk * h / 4;
                    wk++;
                    bsayisi++;
                }
            }

            button1.BackgroundImage = butonyedek[0] = buton[0];
            button2.BackgroundImage = butonyedek[1] = buton[1];
            button3.BackgroundImage = butonyedek[2] = buton[2];
            button4.BackgroundImage = butonyedek[3] = buton[3];

            button5.BackgroundImage = butonyedek[4] = buton[4];
            button6.BackgroundImage = butonyedek[5] = buton[5];
            button7.BackgroundImage = butonyedek[6] = buton[6];
            button8.BackgroundImage = butonyedek[7] = buton[7];

            button9.BackgroundImage = butonyedek[8] = buton[8];
            button10.BackgroundImage = butonyedek[9] = buton[9];
            button11.BackgroundImage = butonyedek[10] = buton[10];
            button12.BackgroundImage = butonyedek[11] = buton[11];

            button13.BackgroundImage = butonyedek[12] = buton[12];
            button14.BackgroundImage = butonyedek[13] = buton[13];
            button15.BackgroundImage = butonyedek[14] = buton[14];
            button16.BackgroundImage = butonyedek[15] = buton[15];

        }

        private void karistir()
        {
            Bitmap temp = new Bitmap(w / 4, h / 4);
            Bitmap temp2 = new Bitmap(w / 4, h / 4);
            Random rnd = new Random();
            

            for (int i = 0; i < 50; i++)
            {
                int sayi = rnd.Next(1, 17);
                int sayi2 = rnd.Next(1, 17);

                foreach (Control item in Controls)
                {

                    if (item.Name == "button" + sayi)
                    {
                        temp = (Bitmap)item.BackgroundImage;
                    }
                    if (item.Name == "button" + sayi2)
                    {
                        temp2 = (Bitmap)item.BackgroundImage;
                    }

                }
                foreach (Control item in Controls)
                {

                    if (item.Name == "button" + sayi)
                    {
                        item.BackgroundImage=temp2;
                    }
                    if (item.Name == "button" + sayi2)
                    {
                        item.BackgroundImage = temp;
                    }

                }
            }

            butonyedek[0] = (Bitmap)button1.BackgroundImage;
            butonyedek[1] = (Bitmap)button2.BackgroundImage;
            butonyedek[2] = (Bitmap)button3.BackgroundImage;
            butonyedek[3] = (Bitmap)button4.BackgroundImage;

            butonyedek[4] = (Bitmap)button5.BackgroundImage;
            butonyedek[5] = (Bitmap)button6.BackgroundImage;
            butonyedek[6] = (Bitmap)button7.BackgroundImage;
            butonyedek[7] = (Bitmap)button8.BackgroundImage;

            butonyedek[8] = (Bitmap)button9.BackgroundImage;
            butonyedek[9] = (Bitmap)button10.BackgroundImage;
            butonyedek[10] = (Bitmap)button11.BackgroundImage;
            butonyedek[11] = (Bitmap)button12.BackgroundImage;

            butonyedek[12] = (Bitmap)button13.BackgroundImage;
            butonyedek[13] = (Bitmap)button14.BackgroundImage;
            butonyedek[14] = (Bitmap)button15.BackgroundImage;
            butonyedek[15] = (Bitmap)button16.BackgroundImage;


           for (int k = 0; k < 16; k++)
            {
                int dogrupixel = 0; int yanlispixel = 0;

                for (int i = 0; i < (w / 4) - 1; i++)
                {
                    for (int j = 0; j < (h / 4) - 1; j++)
                    {
                        if (buton[k].GetPixel(i, j).ToString().Equals(butonyedek[k].GetPixel(i, j).ToString()))
                        {
                            dogrupixel++;
                        }
                        else
                        {
                            yanlispixel++;
                        }


                    }

                }
                if (yanlispixel == 0)
                {
                    dogruparcasayisi++;
                    label2.Text = ""+dogruparcasayisi;
                   
                   

                    MessageBox.Show("Doğru Parça " + (k+1)+".parça");

                    foreach (Control item in Controls)
                    {
                        

                        if (item.Name == "button" + (k+1))
                        {
                            var btn = item as Button;

                            btn.FlatAppearance.BorderColor = Color.Green;
                            btn.FlatAppearance.BorderSize = 3;
                            btn.Enabled = false;
                        }
                        

                    }
                    

                }

                

            }

            if (dogruparcasayisi == 0)
            {
                MessageBox.Show("Doğru Parça Yok");
                karistir();
            }
            else
            {
                button18.Enabled = false;
            }
            
    


        }

        private void karşılaştır(Bitmap hedefbuton,Object sender,Object ksender)
        {
            var button = sender as Button;
            var kaynakbuton = ksender as Button;

            int dogrupixel = 0; int yanlispixel = 0;

            for (int i = 0; i < (w / 4)-1; i++)
            {     
                for (int j = 0; j < (h / 4)-1; j++)
                {                   
                    if (kaynakresim.GetPixel(i,j).ToString().Equals(hedefbuton.GetPixel(i,j).ToString()))
                    {
                        dogrupixel++;
                    }
                    else
                    {
                        yanlispixel++;  
                    }
                     

                }

                
            }

            //MessageBox.Show(dogrupixel + "  " + yanlispixel);
            if (yanlispixel==0)
            {
                skor = skor - 2;
                textBox1.Text = "" + skor;
                dogruparcasayisi++;
                label2.Text = "" + dogruparcasayisi;

                Bitmap gecici = (Bitmap)button.BackgroundImage;
                button.BackgroundImage =kaynakresim;
                kaynakbuton.BackgroundImage = gecici;

                //MessageBox.Show(" Doğru Parça!!!");
                button.Enabled = false;

                if (button.Enabled == false)
                {
                    kaynakbuton.FlatAppearance.BorderColor = Color.Black;
                    kaynakbuton.FlatAppearance.BorderSize = 1;

                    button.FlatAppearance.BorderColor = Color.Green;
                    button.FlatAppearance.BorderSize = 3;

                    kenarlıkrengi = button.FlatAppearance.BorderColor;
                    if (kenarlıkrengi.Name=="Green")
                    {
                        
                       
                    }
                }
                karşılaştır2();

                
                

            }
            else
            {
                skor = skor - 5;
                textBox1.Text = "" + skor;
                button.FlatAppearance.BorderColor = Color.Red;
                button.FlatAppearance.BorderSize = 4;

                kaynakbuton.FlatAppearance.BorderColor = Color.Red;
                kaynakbuton.FlatAppearance.BorderSize = 4;

                MessageBox.Show("Yanlış Parça!!!");

                kaynakbuton.FlatAppearance.BorderColor = Color.Black;
                kaynakbuton.FlatAppearance.BorderSize = 1;

                button.FlatAppearance.BorderColor = Color.Black;
                button.FlatAppearance.BorderSize = 1;
            }
            


        }


        private void karşılaştır2()
        {
            
            var button = kaynakbuton as Button;
            Bitmap temp = (Bitmap)button.BackgroundImage;

            int dogrupixel = 0; int yanlispixel = 0;

            for (int i = 0; i < (w / 4) -1; i++)
            {
                for (int j = 0; j < (h / 4) -1; j++)
                {
                    if (buton[source].GetPixel(i, j)== temp.GetPixel(i, j))
                    {
                        dogrupixel++;
                    }
                    else
                    {
                        yanlispixel++;
                    }


                }


            }

           // MessageBox.Show(dogrupixel + "  " + yanlispixel);
            if (yanlispixel == 0)
            {
                dogruparcasayisi++;                
                label2.Text = "" + dogruparcasayisi;
                button.Enabled = false;
                if (dogruparcasayisi == 16)
                {
                    isim[ksayisi] = label4.Text;
                    puan[ksayisi] = skor;
                    ksayisi++;
                    // enyuksek.Add( label4.Text, skor);
                    dosyayaYaz();
                    MessageBox.Show("Tebrikler Oyunu Bitirdiniz!!! \n  Skorunuz :"+skor);
                    listBox1.Items.Clear();
                    oku();
                    
                }
                
                if (button.Enabled == false)
                {
                    
                    button.FlatAppearance.BorderColor = Color.Green;
                    button.FlatAppearance.BorderSize = 3;

                    kenarlıkrengi = button.FlatAppearance.BorderColor;
                    if (kenarlıkrengi.Name == "Green")
                    {
                        
                       
                    }
                }
              


            }
           // MessageBox.Show("Değişim den sonra kontrol yapıldı");



        }

        public void oku()
        {
            int i = 0;            
            string yol = @"enyuksek.txt";
            FileStream fs = new FileStream(yol, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            while (yazi != null)
            {                
                isim[i] = yazi.Substring(0, yazi.IndexOf(','));
                puan[i++] = Convert.ToInt32(yazi.Substring(yazi.IndexOf(',')+1)); 
                yazi = sw.ReadLine();
                ksayisi++;
            }
            int temp;
            string temp2;
            for (int k = 0; k < puan.Length-1; k++)
            {                for (int j = 0; j < puan.Length-1; j++)
                {
                    if (puan[j] < puan[j + 1])
                    {
                        temp = puan[j];
                        puan[j] = puan[j + 1];
                        puan[j + 1] = temp;

                        temp2 = isim[j];
                        isim[j] = isim[j + 1];
                        isim[j + 1] = temp2;
                    }
                }
            }
            for (int k = 0; k < i; k++)
            
            {                
                //MessageBox.Show(isim[k] + " "+puan[k]);
                listBox1.Items.Add(isim[k] + "  " + puan[k]);
            }
            sw.Close();
            fs.Close();
        }

        public void dosyayaYaz()
        {
           
            string dosya_yolu = @"enyuksek.txt";          
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);            
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < ksayisi; i++)
            {
               sw.WriteLine(isim[i]+","+ puan[i]);
            }            
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = kullaniciAdi;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 0;
                kaynakbuton = button1;
                kaynakresim = (Bitmap)button1.BackgroundImage;

                button1.FlatAppearance.BorderColor = Color.SkyBlue;
                button1.FlatAppearance.BorderSize = 3;
                               
            }
            if (btiksayisi == 2)
            {
                button1.FlatAppearance.BorderColor = Color.SkyBlue;
                button1.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[0],sender,kaynakbuton);
                btiksayisi = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 1;
                kaynakbuton = button2;
                kaynakresim = (Bitmap)button2.BackgroundImage;

                button2.FlatAppearance.BorderColor = Color.SkyBlue;
                button2.FlatAppearance.BorderSize = 3;
            }
            if (btiksayisi == 2)
            {
                button2.FlatAppearance.BorderColor = Color.SkyBlue;
                button2.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[1], sender, kaynakbuton);
                

                btiksayisi = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 2;
                kaynakbuton = button3;
                kaynakresim = (Bitmap)button3.BackgroundImage;

                button3.FlatAppearance.BorderColor = Color.SkyBlue;
                button3.FlatAppearance.BorderSize = 3;

            }
            if (btiksayisi == 2)
            {
                button3.FlatAppearance.BorderColor = Color.SkyBlue;
                button3.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[2], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 3;
                kaynakbuton = button4;
                kaynakresim = (Bitmap)button4.BackgroundImage;

                button4.FlatAppearance.BorderColor = Color.SkyBlue;
                button4.FlatAppearance.BorderSize = 3;


            }
            if (btiksayisi == 2)
            {
                button4.FlatAppearance.BorderColor = Color.SkyBlue;
                button4.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[3], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 4;
                kaynakbuton = button5;
                kaynakresim = (Bitmap)button5.BackgroundImage;

                button5.FlatAppearance.BorderColor = Color.SkyBlue;
                button5.FlatAppearance.BorderSize = 3;


            }
            if (btiksayisi == 2)
            {
                button5.FlatAppearance.BorderColor = Color.SkyBlue;
                button5.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[4], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 5;
                button6.FlatAppearance.BorderColor = Color.SkyBlue;
                button6.FlatAppearance.BorderSize = 3;

                kaynakbuton = button6;
                kaynakresim = (Bitmap)button6.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button6.FlatAppearance.BorderColor = Color.SkyBlue;
                button6.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[5], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 6;
                button7.FlatAppearance.BorderColor = Color.SkyBlue;
                button7.FlatAppearance.BorderSize = 3;

                kaynakbuton = button7;
                kaynakresim = (Bitmap)button7.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button7.FlatAppearance.BorderColor = Color.SkyBlue;
                button7.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[6], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 7;
                button8.FlatAppearance.BorderColor = Color.SkyBlue;
                button8.FlatAppearance.BorderSize = 3;

                kaynakbuton = button8;
                kaynakresim = (Bitmap)button8.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button8.FlatAppearance.BorderColor = Color.SkyBlue;
                button8.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[7], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 8;
                button9.FlatAppearance.BorderColor = Color.SkyBlue;
                button9.FlatAppearance.BorderSize = 3;

                kaynakbuton = button9;
                kaynakresim = (Bitmap)button9.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button9.FlatAppearance.BorderColor = Color.SkyBlue;
                button9.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[8], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 9;
                button10.FlatAppearance.BorderColor = Color.SkyBlue;
                button10.FlatAppearance.BorderSize = 3;

                kaynakbuton = button10;
                kaynakresim = (Bitmap)button10.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button10.FlatAppearance.BorderColor = Color.SkyBlue;
                button10.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[9], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 10;
                button11.FlatAppearance.BorderColor = Color.SkyBlue;
                button11.FlatAppearance.BorderSize = 3;

                kaynakbuton = button11;
                kaynakresim = (Bitmap)button11.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button11.FlatAppearance.BorderColor = Color.SkyBlue;
                button11.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[10], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 11;
                button12.FlatAppearance.BorderColor = Color.SkyBlue;
                button12.FlatAppearance.BorderSize = 3;

                kaynakbuton = button12;
                kaynakresim = (Bitmap)button12.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button12.FlatAppearance.BorderColor = Color.SkyBlue;
                button12.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[11], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 12;
                button13.FlatAppearance.BorderColor = Color.SkyBlue;
                button13.FlatAppearance.BorderSize = 3;

                kaynakbuton = button13;
                kaynakresim = (Bitmap)button13.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button13.FlatAppearance.BorderColor = Color.SkyBlue;
                button13.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[12], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 13;
                button14.FlatAppearance.BorderColor = Color.SkyBlue;
                button14.FlatAppearance.BorderSize = 3;

                kaynakbuton = button14;
                kaynakresim = (Bitmap)button14.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button14.FlatAppearance.BorderColor = Color.SkyBlue;
                button14.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[13], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 14;
                button15.FlatAppearance.BorderColor = Color.SkyBlue;
                button15.FlatAppearance.BorderSize = 3;

                kaynakbuton = button15;
                kaynakresim = (Bitmap)button15.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button15.FlatAppearance.BorderColor = Color.SkyBlue;
                button15.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[14], sender, kaynakbuton);
                btiksayisi = 0;
            }

        }
        private void button16_Click(object sender, EventArgs e)
        {
            btiksayisi++;
            if (btiksayisi == 1)
            {
                source = 15;
                button16.FlatAppearance.BorderColor = Color.SkyBlue;
                button16.FlatAppearance.BorderSize = 3;

                kaynakbuton = button16;
                kaynakresim = (Bitmap)button16.BackgroundImage;


            }
            if (btiksayisi == 2)
            {
                button16.FlatAppearance.BorderColor = Color.SkyBlue;
                button16.FlatAppearance.BorderSize = 3;

                karşılaştır(buton[15], sender, kaynakbuton);
                btiksayisi = 0;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            karistir();
        }


        

        

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            String rsmyeri = "";
            OpenFileDialog rsm = new OpenFileDialog();

            

            if (rsm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rsmyeri = rsm.FileName;
                resim = new Bitmap(rsmyeri);
                h = resim.Height - (resim.Height % 4);
                w = resim.Width - (resim.Width % 4);
                textBox1.Text = "" + skor;

            }

            for (int i = 0; i < buton.Length; i++)
            {
                buton[i] = new Bitmap(w / 4, h / 4);
            }
            parcala();  
           

        }
    }
}
