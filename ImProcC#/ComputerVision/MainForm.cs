using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace ComputerVision
{
    public partial class MainForm : Form
    {
        private string sSourceFileName = "";        
        private FastImage workImage;
        private FastImage imagineOriginala;
        private Bitmap image = null;
        private Bitmap image2 = null;
        int T = 50;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            sSourceFileName = openFileDialog.FileName;
            panelSource.BackgroundImage = new Bitmap(sSourceFileName);
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            image2 = new Bitmap(sSourceFileName);
            imagineOriginala = new FastImage(image2); ;
        }

        private void buttonGrayscale_Click(object sender, EventArgs e)
        {
            Color color;

            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    byte average = (byte)((R + G + B) / 3);

                    color = Color.FromArgb(average, average, average);

                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
            
        }

        private void btnNeg_Click(object sender, EventArgs e)
        {
            Color color;
            workImage.Lock();
            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    byte newR = (byte)(255 - R);
                    byte newG = (byte)(255 - G);
                    byte newB = (byte)(255 - B);

                    color = Color.FromArgb(newR, newG, newB);

                    workImage.SetPixel(i, j, color);

                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void trackLight_ValueChanged(object sender, EventArgs e)
        {
            Color color;
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            workImage.Lock();
            int delta = trackLight.Value;


            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    byte newR, newG, newB;

                    if (R + delta > 255) { newR = 255; }
                    else if (R + delta < 0) { newR = 0; }
                    else newR = (byte)(R + delta);

                    if (G + delta > 255) { newG = 255; }
                    else if (G + delta < 0) { newG = 0; }
                    else newG = (byte)(G + delta);

                    if (B + delta > 255) { newB = 255; }
                    else if (B + delta < 0) { newB = 0; }
                    else newB = (byte)(B + delta);

                    color = Color.FromArgb(newR, newG, newB);

                    workImage.SetPixel(i, j, color);
                }
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Color color;
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            workImage.Lock();
            int delta = trackHisto.Value;

            int minR = 255;
            int maxR = 0;
            int minG = 255;
            int maxG = 0;
            int minB = 255;
            int maxB = 0;

            int aR=0, bR=0, aG=0, bG=0, aB=0, bB=0;

            int Rn, Gn, Bn; 


            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;

                    if (minR > R) { minR = R; }
                    if (maxR < R) { maxR = R; }
                    if (minG > G) { minG = G; }
                    if (maxG < G) { maxG = G; }
                    if (minB > B) { minB = B; }
                    if (maxB < B) { maxB = B; }

                    //color = Color.FromArgb(newR, newG, newB);

                   // workImage.SetPixel(i, j, color);
                }
            }

            aR = minR - delta;
            aG = minG - delta;
            aB = minB - delta;

            bR = maxR + delta;
            bG = maxG + delta;
            bB = maxB + delta;

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    int R = color.R;
                    int G = color.G;
                    int B = color.B;

                    Rn = (((bR - aR) * (R - minR)) / (maxR - minR)) + aR;
                    Gn = (((bG - aG) * (G - minG)) / (maxG - minG)) + aG;
                    Bn = (((bB - aB) * (B - minB)) / (maxB - minB)) + aB;

                    if (Rn > 255) { Rn = 255; }
                    if (Rn < 0) { Rn = 0; }
                    if (Gn > 255) { Gn = 255; }
                    if (Gn < 0) { Gn = 0; }
                    if (Bn > 255) { Bn = 255; }
                    if (Bn < 0) { Bn = 0; }

                    color = Color.FromArgb(Rn, Gn, Bn);

                     workImage.SetPixel(i, j, color);
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEqualize_Click(object sender, EventArgs e)
        {
            int[] hist = new int[256];
            int[] histc = new int[256];
            int[] transf = new int[256];

            Color color;
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            workImage.Lock();

            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    byte average = (byte)((R + G + B) / 3);

                    hist[average] = hist[average] + 1;

                }
            }
            histc[0] = hist[0];

            for (int i = 1; i <= 255; i++)
            {
                histc[i] = histc[i - 1] + hist[i];
            }

            for (int i = 0; i <= 255; i++)
            {
                transf[i] = (histc[i] * 255) / (workImage.Width * workImage.Height);
            }


            for (int i = 0; i < workImage.Width; i++)
            {
                for (int j = 0; j < workImage.Height; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    byte average = (byte)((R + G + B) / 3);
                    color = Color.FromArgb(transf[average], transf[average], transf[average]);

                    workImage.SetPixel(i,j,color);
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void reflexBox_TextChanged(object sender, EventArgs e)
        {
            Color color;
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            workImage.Lock();


            int x1, x2, y1, y2,x0= workImage.Width/2, y0= workImage.Height/2;
            //double sigma;
           // double pi = Math.PI;

            for (x1 = 0; x1 < workImage.Width; x1++)
            {
                for ( y1 = 0; y1 < workImage.Height; y1++)
                {
                    color = workImage.GetPixel(x1, y1);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    x2 = x1;
                    y2 = -y1+2*y0;

                    workImage.SetPixel(x2, y2, color);
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void comboBReflex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttZgomot_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text.ToString());
            int[,] H = new int[3, 3] { { 1, n, 1 }, { n, n * n, n }, { 1, n, 1 } };
            int s_red;
            int s_green;
            int s_blue;

            Color color;
            
            workImage.Lock();

            for (int i = 1; i <= workImage.Width-2; i++)
            {
                for (int j = 1; j <= workImage.Height-2; j++) 
                {
                     s_red = 0;
                     s_green = 0;
                     s_blue = 0;
                    for (int row=i-1; row <= i+1; row++) 
                    {
                     for (int col = j - 1; col <= j + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            s_red = s_red + R * H[row-i+1,col-j+1];
                            s_green = s_green + G * H[row - i + 1, col - j + 1];
                            s_blue = s_blue + B * H[row - i + 1, col - j + 1];
                           
                        }
                    }
                    s_red /= ((n + 2) * (n + 2));
                    s_green /= ((n + 2) * (n + 2));
                    s_blue /= ((n + 2) * (n + 2));

                    color = Color.FromArgb((int)s_red, (int)s_green, (int)s_blue);

                    workImage.SetPixel(i, j, color);
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void label4_Click(object sender, EventArgs e)
        {
          
        }

       /* public void CBP(int x,int y,int cs,int sr,int T)
        {
            int[] Q= new int[256];
            for (int i=x-sr;i<x+sr ; i++)
            {
                if (i<=0 & i> workImage.Width) {
                    for (int j = y - sr; j < y + sr; j++)
                    {
                        if (j <= 0 & j > workImage.Height) { 
                        if (i == x & j == y) { continue; }
                        if (SAD(x, y, i, j, cs) < T & !Salt_Pepper(i, j))
                        {
                           // Q[Color(i, j)] = Q[Color(i, j)] + 1;
                        }
                        }
                    }
                }
              //  return Max(Q);
            }
        }
        public int SAD(int x1, int x2, int y1, int y2, int cs)
        {
            int s= 0;
            Color color;
            for (int i = - cs/2; i <cs/2; i++)
            { if(i+x1 >= 0 & i + x1< workImage.Width & i + x2 >= 0 & i + x2 < workImage.Width){ 
                for (int j = -cs / 2; j < cs / 2; j++) 
                { if(j+x1 >= 0 & j + x1< workImage.Width & j + x2 >= 0 & j + x2 < workImage.Width) { 
                  if(i==0 & j == 0) { continue; }
                      color = workImage.GetPixel(i, j);
                      byte R = color.R;
                      byte G = color.G;
                      byte B = color.B;
                      byte average = (byte)((R + G + B) / 3);
                      color = Color.FromArgb(average, average, average);
                      workImage.SetPixel(i, j, color);
                         //   s = s + (color(i + x1, j + y1) - color(i + x2, j + y2));
                        }
                    }
               }
            }
            return s;
        }*/
      /*  public int CBPF(int cs,int sr,int t)
        {
          for(int i=0;i< workImage.Width - 1; i++)
            {
                for (int j = 0; j < workImage.Height - 1; j++)
                {
                 // if (Salt_Pepper(i, j)){ workImage.SetPixel(i, j, CBP(i, j,cs,sr,t)); }
                }
            }
        }*/
       /* public bool Salt_Pepper(int black, int white)
        {
            Color color;
            for (int i = 0; i < workImage.Width - 1; i++)
            {
                for (int j = 0; j < workImage.Height - 1; j++)
                {
                    color = workImage.GetPixel(i, j);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;
                    byte average = (byte)((R + G + B) / 3);
                    color = Color.FromArgb(average, average, average);
                   workImage.SetPixel(i, j, color);
                    if (color == Color.Black | color == Color.White)
                    { return true; }
                }
            }
            return false;       
        }*/
        private void btnMakarov_Click(object sender, EventArgs e)
        {
           // Color color;
            image = new Bitmap(sSourceFileName);
            workImage = new FastImage(image);
            workImage.Lock();

          //  int cs = 3;
          //  int sr = 4;
          //  int T = 500;

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            workImage.Unlock();
        }

        private void trece_sus_Click(object sender, EventArgs e)
        {
            Color color;
            int s_red;
            int s_green;
            int s_blue;

            int[,] H1 = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            int[,] H2 = new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            int[,] H3 = new int[3, 3] { { 1, -2, 1 }, { -2, 5, -2 }, { 1, -2, 1 } };

            //workImage = new FastImage(image);
          //  imagineOriginala = new FastImage(image2);
            workImage.Lock();
            imagineOriginala.Lock();
            
            for (int i = 1; i <= imagineOriginala.Width - 2; i++)
            {
                for (int j = 1; j <= imagineOriginala.Height - 2; j++)
                {
                    s_red = 0;
                    s_green = 0;
                    s_blue = 0;
                    for (int row = i - 1; row <= i + 1; row++)
                    {
                        for (int col = j - 1; col <= j + 1; col++)
                        {
                            color = imagineOriginala.GetPixel(row, col);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            s_red = s_red + R * H1[row - i + 1, col - j + 1];
                            s_green = s_green + G * H1[row - i + 1, col - j + 1];
                            s_blue = s_blue + B * H1[row - i + 1, col - j + 1];

                        }
                    }

                    if (s_red > 255) { s_red = 255; }
                    if (s_red < 0) { s_red = 0; }
                    if (s_green > 255) { s_green = 255; }
                    if (s_green < 0) { s_green = 0; }
                    if (s_blue > 255) { s_blue = 255; }
                    if (s_blue < 0) { s_blue = 0; }
                    color = Color.FromArgb((int)s_red, (int)s_green, (int)s_blue);

                    workImage.SetPixel(i, j, color);
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            imagineOriginala.Unlock();
            workImage.Unlock();
            
        }

        private void btnUnMak_Click(object sender, EventArgs e)
        {
            Color color;
            int s_red;
            int s_green;
            int s_blue;
            int L = 1;
            int[,] H = new int[3, 3] { { 1, 1, 1 }, { 1, L*L, 1 }, { 1, 1, 1 } };
            double c = 0.6;
            imagineOriginala = new FastImage(image2);
            workImage = new FastImage(image);
            workImage.Lock();
            imagineOriginala.Lock();

            for (int i = 1; i <= workImage.Width - 2; i++)
            {
                for (int j = 1; j <= workImage.Height - 2; j++)
                {
                    s_red = 0;
                    s_green = 0;
                    s_blue = 0;

                    for (int row = i - 1; row <= i + 1; row++)
                    {
                        for (int col = j - 1; col <= j + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            s_red = s_red + R * H[row - i + 1, col - j + 1];
                            s_green = s_green + G * H[row - i + 1, col - j + 1];
                            s_blue = s_blue + B * H[row - i + 1, col - j + 1];

                        }
                    }
                    s_red = s_red / ((L + 2) * (L + 2));
                    s_green = s_green / ((L + 2) * (L + 2));
                    s_blue = s_blue / ((L + 2) * (L + 2));
                    color = workImage.GetPixel(i, j);
                    

                    workImage.SetPixel(i, j, color);

                } 
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = workImage.GetBitMap();
            imagineOriginala.Unlock();
            workImage.Unlock();
        }

       public int Gmax(int max1, int max2, int max3, int max4)
        {
         return Math.Max(Math.Max(max1, max2), Math.Max(max3, max4));
            
        }

        private void btnKitsh2_Click(object sender, EventArgs e)
        {
            Color color;
            int s_red1;
            int s_green1;
            int s_blue1;
            int s_red2;
            int s_green2;
            int s_blue2;
            int s_red3;
            int s_green3;
            int s_blue3;
            int s_red4;
            int s_green4;
            int s_blue4;

            int max1=0 , max2=0, max3=0;

            int[,] H1 = new int[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
            int[,] H2 = new int[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } };
            int[,] H3 = new int[3, 3] { { 0, 1, 1 }, { -1, 0, 1 }, { -1, -1, 0 } };
            int[,] H4 = new int[3, 3] { { 1, 1, 0 }, { 1, 0, -1 }, { 0, -1, -1 } };

            workImage.Lock();
            imagineOriginala.Lock();

            for (int i = 1; i <= workImage.Width - 2; i++)
            {
                for (int j = 1; j <= workImage.Height - 2; j++)
                {
                     s_red1 = 0;
                     s_green1 = 0;
                     s_blue1 = 0;
                     s_red2 = 0;
                     s_green2 = 0;
                     s_blue2 = 0;
                     s_red3 = 0;
                     s_green3 = 0;
                     s_blue3 = 0;
                     s_red4 = 0;
                     s_green4 = 0;
                     s_blue4 = 0;

                    for (int row = i - 1; row <= i + 1; row++)
                    {
                        for (int col = j - 1; col <= j + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            s_red1 = s_red1 + R * H1[row - i + 1, col - j + 1];
                            s_green1 = s_green1 + G * H1[row - i + 1, col - j + 1];
                            s_blue1 = s_blue1 + B * H1[row - i + 1, col - j + 1];

                            s_red2 = s_red2 + R * H2[row - i + 1, col - j + 1];
                            s_green2 = s_green2 + G * H2[row - i + 1, col - j + 1];
                            s_blue2 = s_blue2 + B * H2[row - i + 1, col - j + 1];

                            s_red3 = s_red3 + R * H3[row - i + 1, col - j + 1];
                            s_green3 = s_green3 + G * H3[row - i + 1, col - j + 1];
                            s_blue3 = s_blue3 + B * H3[row - i + 1, col - j + 1];

                            s_red4 = s_red4 + R * H4[row - i + 1, col - j + 1];
                            s_green4 = s_green4 + G * H4[row - i + 1, col - j + 1];
                            s_blue4 = s_blue4 + B * H4[row - i + 1, col - j + 1];

                        }
                    }

                    int Nu_lasa_sa_treaca_de_limite(int x)
                    {
                        if (x > 255) {  return 255; }
                        else if(x<0) {  return 0; }
                        else return x;
                    }

                  max1= Gmax(s_red1, s_red2, s_red3, s_red4);
                  max2= Gmax(s_green1, s_green2, s_green3, s_green4);
                  max3= Gmax(s_blue1, s_blue2, s_blue3, s_blue4);

                    max1 = Nu_lasa_sa_treaca_de_limite(max1);
                    max2 = Nu_lasa_sa_treaca_de_limite(max2);
                    max3= Nu_lasa_sa_treaca_de_limite(max3);

                    color = Color.FromArgb(max1, max2, max3);
                    imagineOriginala.SetPixel(i, j, color);
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = imagineOriginala.GetBitMap();
           // imagineOriginala.Unlock();
            workImage.Unlock();
            imagineOriginala.Unlock();
        }

        private void btnPrewits_Click(object sender, EventArgs e)
        {
            Color color;
            int s_redP;
            int s_greenP;
            int s_blueP;
            int s_redQ;
            int s_greenQ;
            int s_blueQ;
            int Rr=0,Rg=0,Rb=0;
            

            int[,] P = new int[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
            int[,] Q = new int[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };

            workImage.Lock();
            imagineOriginala.Lock();

            for (int i = 1; i <= workImage.Width - 2; i++)
            {
                for (int j = 1; j <= workImage.Height - 2; j++)
                {
                    s_redP = 0;
                    s_greenP = 0;
                    s_blueP = 0;
                    s_redQ = 0;
                    s_greenQ = 0;
                    s_blueQ = 0;


                    for (int row = i - 1; row <= i + 1; row++)
                    {
                        for (int col = j - 1; col <= j + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            s_redP = s_redP + R * P[row - i + 1, col - j + 1];
                            s_greenP = s_greenP + G * P[row - i + 1, col - j + 1];
                            s_blueP = s_blueP + B * P[row - i + 1, col - j + 1];

                            s_redQ = s_redQ + R * Q[row - i + 1, col - j + 1];
                            s_greenQ = s_greenQ + G * Q[row - i + 1, col - j + 1];
                            s_blueQ = s_blueQ + B * Q[row - i + 1, col - j + 1];

                        }
                    }

                    int Nu_lasa_sa_treaca_de_limite(int x)
                    {
                        if (x > 255) { return 255; }
                        else if (x < 0) { return 0; }
                        else return x;
                    }

                    Rr = (int)Math.Sqrt((s_redP*s_redP)+(s_redQ * s_redQ));
                    Rg = (int)Math.Sqrt((s_greenP * s_greenP) + (s_greenQ * s_greenQ));
                    Rb = (int)Math.Sqrt((s_blueP * s_blueP) + (s_blueQ * s_blueQ));

                    Rr = Nu_lasa_sa_treaca_de_limite(Rr);
                    Rg = Nu_lasa_sa_treaca_de_limite(Rg);
                    Rb = Nu_lasa_sa_treaca_de_limite(Rb);

                    color = Color.FromArgb(Rr, Rg, Rb);
                    imagineOriginala.SetPixel(i, j, color);
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = imagineOriginala.GetBitMap();
            workImage.Unlock();
            imagineOriginala.Unlock();
        }

        private void btnFreiChen_Click(object sender, EventArgs e)
        {
            Color color;
            int s_red1 = 0;
            int s_green1 = 0;
            int s_blue1 = 0;
            int s_red2 = 0;
            int s_green2 = 0;
            int s_blue2 = 0;
            int s_red3 = 0;
            int s_green3 = 0;
            int s_blue3 = 0;
            int s_red4 = 0;
            int s_green4 = 0;
            int s_blue4 = 0;
            int s_red5 = 0;
            int s_green5 = 0;
            int s_blue5 = 0;
            int s_red6 = 0;
            int s_green6 = 0;
            int s_blue6 = 0;
            int s_red7 = 0;
            int s_green7 = 0;
            int s_blue7 = 0;
            int s_red8 = 0;
            int s_green8 = 0;
            int s_blue8 = 0;
            int s_red9 = 0;
            int s_green9 = 0;
            int s_blue9 = 0;
            int Rred = 0, Rgreen = 0, Rblue = 0;
            int suma_f1_f4_red = 0, suma_f1_f4_green = 0, suma_f1_f4_blue = 0, suma_f1_f9_red = 0, suma_f1_f9_green = 0, suma_f1_f9_blue = 0;




            int[,] F1 = new int[3, 3] { { 1, (int)Math.Sqrt(2), 1 }, { 0, 0, 0 }, { -1, -(int)Math.Sqrt(2), -1 } };
            int[,] F2 = new int[3, 3] { { 1, 0, -1 }, { (int)Math.Sqrt(2), 0, -(int)Math.Sqrt(2) }, { 1, 0, -1 } };
            int[,] F3= new int[3, 3] { { 0, -1, (int)Math.Sqrt(2) }, { 1, 0,-1 }, { -(int)Math.Sqrt(2), 1, 0 } };
            int[,] F4 = new int[3, 3] { { (int)Math.Sqrt(2), -1, 0 }, { -1, 0, 1 }, { 0, 1, -(int)Math.Sqrt(2) } };
            int[,] F5 = new int[3, 3] { { 0, 1, 0  }, { -1, 0, -1 }, { 0, 1, 0 } };
            int[,] F6 = new int[3, 3] { { -1, 0, 1 }, { 0, 0, 0 }, { 1, 0, -1 } };
            int[,] F7 = new int[3, 3] { { 1, -2, 1 }, { -2, 4, -2 }, { 1, -2, 1 } };
            int[,] F8 = new int[3, 3] { { -2, 1, -2 }, { 1, 4, 1 }, { -2, 1, -2 } };
            int[,] F9 = new int[3, 3] { { 1/9, 1/9, 1/9 }, { 1/9 , 1/9 , 1/9 }, { 1/9, 1/9, 1/9 } };

            workImage.Lock();
            imagineOriginala.Lock();

            for (int i = 1; i <= workImage.Width - 2; i++)
            {
                for (int j = 1; j <= workImage.Height - 2; j++)
                {
                    s_red1 = 0;
                    s_green1 = 0;
                    s_blue1 = 0;
                    s_red2 = 0;
                    s_green2 = 0;
                    s_blue2 = 0;
                    s_red3 = 0;
                    s_green3 = 0;
                    s_blue3 = 0;
                    s_red4 = 0;
                    s_green4 = 0;
                    s_blue4 = 0;
                    s_red5 = 0;
                    s_green5 = 0;
                    s_blue5 = 0;
                    s_red6 = 0;
                    s_green6 = 0;
                    s_blue6 = 0;
                    s_red7 = 0;
                    s_green7 = 0;
                    s_blue7 = 0;
                    s_red8 = 0;
                    s_green8 = 0;
                    s_blue8 = 0;
                    s_red9 = 0;
                    s_green9 = 0;
                    s_blue9 = 0;


                    for (int row = i - 1; row <= i + 1; row++)
                    {
                        for (int col = j - 1; col <= j + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            s_red1 = s_red1 + R * F1[row - i + 1, col - j + 1];
                            s_green1 = s_green1 + G * F1[row - i + 1, col - j + 1];
                            s_blue1 = s_blue1 + B * F1[row - i + 1, col - j + 1];

                            s_red2 = s_red2 + R * F2[row - i + 1, col - j + 1];
                            s_green2 = s_green2 + G * F2[row - i + 1, col - j + 1];
                            s_blue2 = s_blue2 + B * F2[row - i + 1, col - j + 1];

                            s_red3 = s_red3 + R * F3[row - i + 1, col - j + 1];
                            s_green3 = s_green3 + G * F3[row - i + 1, col - j + 1];
                            s_blue3 = s_blue3 + B * F3[row - i + 1, col - j + 1];

                            s_red4 = s_red4 + R * F4[row - i + 1, col - j + 1];
                            s_green4 = s_green4 + G * F4[row - i + 1, col - j + 1];
                            s_blue4 = s_blue4 + B * F4[row - i + 1, col - j + 1];

                            s_red5 = s_red5 + R * F5[row - i + 1, col - j + 1];
                            s_green5 = s_green5 + G * F5[row - i + 1, col - j + 1];
                            s_blue5 = s_blue5 + B * F5[row - i + 1, col - j + 1];

                            s_red6 = s_red6 + R * F6[row - i + 1, col - j + 1];
                            s_green6 = s_green6 + G * F6[row - i + 1, col - j + 1];
                            s_blue6 = s_blue6 + B * F6[row - i + 1, col - j + 1];

                            s_red7 = s_red7 + R * F7[row - i + 1, col - j + 1];
                            s_green7 = s_green7 + G * F7[row - i + 1, col - j + 1];
                            s_blue7 = s_blue7 + B * F7[row - i + 1, col - j + 1];

                            s_red8 = s_red8 + R * F8[row - i + 1, col - j + 1];
                            s_green8 = s_green8 + G * F8[row - i + 1, col - j + 1];
                            s_blue8 = s_blue8 + B * F8[row - i + 1, col - j + 1];

                            s_red9 = s_red9 + R * F9[row - i + 1, col - j + 1];
                            s_green9 = s_green9 + G * F9[row - i + 1, col - j + 1];
                            s_blue9 = s_blue9 + B * F9[row - i + 1, col - j + 1];

                        }
                    }

                    int Nu_lasa_sa_treaca_de_limite(int x)
                    {
                        if (x > 255) { return 255; }
                        else if (x < 0) { return 0; }
                        else return x;
                    }

                    suma_f1_f4_red = s_red1 + s_red2 + s_red3 + s_red4;
                    suma_f1_f4_green = s_green1 + s_green2 + s_green3 + s_green4;
                    suma_f1_f4_blue = s_blue1 + s_blue2 + s_blue3 + s_blue4;

                    suma_f1_f9_red = s_red1 + s_red2 + s_red3 + s_red4 + s_red5 + s_red6 + s_red7 + s_red8 + s_red9;
                    //suma_f1_f9_red = suma_f1_f9_red / 9;
                    suma_f1_f9_green = s_green1 + s_green2 + s_green3 + s_green4 + s_green5 + s_green6 + s_green7 + s_green8 + s_green9;
                   // suma_f1_f9_green = suma_f1_f9_green / 9;
                    suma_f1_f9_blue = s_blue1 + s_blue2 + s_blue3 + s_blue4 + s_blue5 + s_blue6 + s_blue7 + s_blue8 + s_blue9;
                    //suma_f1_f9_blue = suma_f1_f9_blue / 9;

                   Rred = (int)Math.Sqrt( (suma_f1_f4_red* suma_f1_f4_red) / (suma_f1_f9_red* suma_f1_f9_red))*255;
                    Rgreen = (int)Math.Sqrt((suma_f1_f4_green* suma_f1_f4_green) / (suma_f1_f9_green* suma_f1_f9_green))*255;
                    Rblue = (int)Math.Sqrt((suma_f1_f4_blue*suma_f1_f4_blue) / (suma_f1_f9_blue*suma_f1_f9_blue))*255;

                    Rred = Nu_lasa_sa_treaca_de_limite(Rred);
                    Rgreen = Nu_lasa_sa_treaca_de_limite(Rgreen);
                    Rblue = Nu_lasa_sa_treaca_de_limite(Rblue);


                    color = Color.FromArgb(Rred, Rgreen, Rblue);
                    imagineOriginala.SetPixel(i, j, color);
                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = imagineOriginala.GetBitMap();
            workImage.Unlock();
            imagineOriginala.Unlock();
        }

        double Gabor(int suma_p, int suma_q)
        {
            double u;
            if (suma_q == 0)
            {
                if ( suma_p >= 0) { u = (Math.PI) / 2; }
                else u = (-Math.PI) / 2;
            }
            else { u = (double)Math.Atan(suma_p / suma_q); }

            if (suma_q < 0) { u = u + Math.PI; }
            return u;
        }

        private void btnGabor_Click(object sender, EventArgs e)
        {
            Color color;
            int s_red_P;
            int s_green_P;
            int s_blue_P;
            int s_red_Q;
            int s_green_Q;
            int s_blue_Q;
            double uR,uG,uB;
            int Sum_R, Sum_G, Sum_B;
            double scale_R, scale_G, scale_B;

            int[,] P = new int[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } };
            int[,] Q = new int[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };

            workImage.Lock();
            imagineOriginala.Lock();

            for (int i = 1; i <= workImage.Width - 2; i++)
            {
                for (int j = 1; j <= workImage.Height - 2; j++)
                {
                    s_red_P = 0;
                    s_green_P = 0;
                    s_blue_P = 0;
                    s_red_Q = 0;
                    s_green_Q = 0;
                    s_blue_Q = 0;

                    Sum_R = 0;
                    Sum_G = 0;
                    Sum_B = 0;
                    scale_R = 0;
                    scale_B = 0;
                    scale_G = 0;

                    for (int row = i - 1; row <= i + 1; row++)
                    {
                        for (int col = j - 1; col <= j + 1; col++)
                        {
                            color = workImage.GetPixel(row, col);
                            int R = color.R;
                            int G = color.G;
                            int B = color.B;

                            s_red_P = s_red_P + R * P[row - i + 1, col - j + 1];
                            s_green_P = s_green_P + G * P[row - i + 1, col - j + 1];
                            s_blue_P = s_blue_P + B * P[row - i + 1, col - j + 1];

                            s_red_Q = s_red_Q + R * Q[row - i + 1, col - j + 1];
                            s_green_Q = s_green_Q + G * Q[row - i + 1, col - j + 1];
                            s_blue_Q = s_blue_Q + B * Q[row - i + 1, col - j + 1];
                        }
                    }
                    uR= Gabor(s_red_P  , s_red_Q  );
                    uR = uR + Math.PI;
                    uG = Gabor(s_green_P, s_green_Q);
                    uG = uG + Math.PI;
                    uB = Gabor(s_blue_P , s_blue_Q );
                    uB = uB + Math.PI;

                    scale_R =Math.Pow(Math.E , -(Math.Pow(i,2) * Math.Pow(j,2))) * Math.Sin(0.66 *( i* Math.Cos(uR) + j * Math.Sin(uR)));
                    scale_G = Math.Pow(Math.E, -(Math.Pow(i, 2) * Math.Pow(j, 2))) * Math.Sin(0.66 * (i * Math.Cos(uG) + j * Math.Sin(uG)));
                    scale_B = Math.Pow(Math.E, -(Math.Pow(i, 2) * Math.Pow(j, 2))) * Math.Sin(0.66 * (i * Math.Cos(uB) + j * Math.Sin(uB)));

                    int Nu_lasa_sa_treaca_de_limite(int x)
                    {
                        if (x > 255) { return 255; }
                        else if (x < 0) { return 0; }
                        else return x;
                    }

                    Nu_lasa_sa_treaca_de_limite(Sum_R);
                    Nu_lasa_sa_treaca_de_limite(Sum_G);
                    Nu_lasa_sa_treaca_de_limite(Sum_B);

                    Sum_R = Sum_R + (int)scale_R;
                    Sum_G = Sum_G + (int)scale_G;
                    Sum_B = Sum_B + (int)scale_B;

                    color = Color.FromArgb(Sum_R, Sum_G, Sum_B);
                    imagineOriginala.SetPixel(i, j, color);
                }

                
            }
            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = imagineOriginala.GetBitMap();
            workImage.Unlock();
            imagineOriginala.Unlock();
        }

        private void panelSource_MouseClick(object sender, MouseEventArgs e)
        {
            // String temporalT= valoareT.Text.ToString(); ce am facut aici ma ajuta cu afisare
            int T;
            T = int.Parse(valoareT.Text);

            int x, y;//coordonatele
            int contor = 0;

            workImage.Lock();
            imagineOriginala.Lock();

            x = e.X * (panelSource.Width / workImage.Width);
            y = e.Y * (panelSource.Height / workImage.Height);

            Color pixel = workImage.GetPixel(x, y);

            int average = (pixel.R + pixel.G + pixel.B);

            Queue<Color> Q = new Queue<Color>();
            Queue<Color> R = new Queue<Color>();

            while (Q != null) 
            {
                int media = average / contor;

                if (x < workImage.Width && y < workImage.Height) 
                {
                
                }

                pixel = Q.Dequeue();
            }

            imagineOriginala.SetPixel(x, y, pixel);
            for (int i = 1; i <= workImage.Width - 2; i++)
            {
                for (int j = 1; j <= workImage.Height - 2; j++)
                {

                }
            }

            panelDestination.BackgroundImage = null;
            panelDestination.BackgroundImage = imagineOriginala.GetBitMap();
            workImage.Unlock();
            imagineOriginala.Unlock();
        }

        /*  public void AfisareAxe() 
          {
              Graphics g;
              Pen redPen = new Pen(Color.Red, 1);

              g.DrawLine(Pens.Black, new Point(workImage.Width - 2, 0), new Point(workImage.Width - 2, this.Bottom));
              g.DrawLine(Pens.Black, new Point(0, workImage.Width - 2), new Point(this.Right, workImage.Width - 2));

          }
        */

        private void deseneazaLinii(int xinitial, int xfinal, int yinitial, int yfinal)
        {
            for (int i = xinitial; i < xfinal; i++)
            {
                imagineOriginala.SetPixel(i, (yinitial + yfinal) / 2, Color.Black);
            }

            for (int i = yinitial; i < yfinal; i++)
            {
                imagineOriginala.SetPixel((xinitial + xfinal) / 2, i, Color.Black);
            }
        }

        private int average(int xini, int xfin, int yini, int yfin)
        {
            int sum = 0, count = 0;
            for (int i = xini; i < xfin; i++)
            {
                for (int j = yini; j < yfin; j++)
                {
                    Color newColor = workImage.GetPixel(i, j);
                    int R = newColor.R;
                    int G = newColor.G;
                    int B = newColor.B;

                    sum += (R + G + B) / 3;
                    count++;
                }
            }

            if (count == 0)
            {
                return -1;
            }
            int rez = sum / count;
            return rez;
        }
        private void splitting(int xini, int xfin, int yini, int yfin)
        {
            int sum = 0, count = 0;
            int averageColor = average(xini, xfin, yini, yfin);

            if (averageColor == -1 || xfin - xini < 2 || yfin - yini < 2)
            {
                return;
            }

            for (int i = xini; i < xfin; i++)
            {
                for (int j = yini; j < yfin; j++)
                {
                    Color newColor = workImage.GetPixel(i, j);
                    int R = newColor.R;
                    int G = newColor.G;
                    int B = newColor.B;
                    int grayColor = (R + G + B) / 3;
                    sum += (grayColor - averageColor) * (grayColor - averageColor);
                    count++;

                }
            }

            int dev = sum / (count);

            if (dev > T)
            {
                deseneazaLinii(xini, xfin, yini, yfin);
                int xHalf = (xfin + xini) / 2;
                int yHalf = (yfin + yini) / 2;

                splitting(xini, xHalf, yini, yHalf);
                splitting(xHalf, xfin, yini, yHalf);
                splitting(xini, xHalf, yHalf, yfin);
                splitting(xHalf, xfin, yHalf, yfin);
            }
        }

      

        private void split_merge_Click(object sender, EventArgs e)
        {
                workImage.Lock();
                imagineOriginala.Lock();

                splitting(0, workImage.Width, 0, workImage.Height);

                panelDestination.BackgroundImage = null;
                panelDestination.BackgroundImage = imagineOriginala.GetBitMap();

                workImage.Unlock();
                imagineOriginala.Unlock();
            
        }

        private void panelSource_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
   
