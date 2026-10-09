using System.Drawing.Drawing2D;

namespace Form1;

public partial class Form1 : Form
{
    private int mode = 1;

    public Form1()
    {
        InitializeComponent();
        this.Text = "Praktikum Grafika Komputer";
        this.ClientSize = new Size(800, 650);
        this.DoubleBuffered = true;
        this.BackColor = Color.White;

        Button btn1 = new Button { Text = "Objek Sederhana", Location = new Point(10, 10), Size = new Size(150, 30) };
        Button btn2 = new Button { Text = "Objek Kompleks", Location = new Point(170, 10), Size = new Size(150, 30) };
        btn1.Click += (s, e) => { mode = 1; Invalidate(); };
        btn2.Click += (s, e) => { mode = 2; Invalidate(); };
        Controls.Add(btn1);
        Controls.Add(btn2);

        this.Paint += Form1_Paint;
    }

    private void Form1_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TranslateTransform(0, 50);

        if (mode == 1) GambarSederhana(g);
        else GambarKompleks(g);
    }

    private void GambarIkan(Graphics g, float x, float y, float skala)
    {
        GraphicsState keadaan = g.Save();
        g.TranslateTransform(x, y);
        g.ScaleTransform(skala, skala);
        g.TranslateTransform(-200, -130);

        Point[] sirip = { new Point(340, 215), new Point(420, 130), new Point(470, 225) };
        g.FillPolygon(Brushes.OrangeRed, sirip);

        Point[] ekor = { new Point(545, 290), new Point(660, 190), new Point(660, 390) };
        g.FillPolygon(Brushes.OrangeRed, ekor);

        g.FillEllipse(Brushes.Orange, 200, 200, 360, 180);

        using Pen penInsang = new Pen(Color.DarkRed, 4);
        g.DrawArc(penInsang, 320, 225, 70, 130, 90, 180);

        using Pen penGaris = new Pen(Color.DarkOrange, 5);
        g.DrawLine(penGaris, 430, 215, 430, 365);
        g.DrawLine(penGaris, 475, 225, 475, 355);

        g.FillEllipse(Brushes.White, 240, 255, 40, 40);
        g.FillEllipse(Brushes.Black, 252, 267, 18, 18);

        using Pen penMata = new Pen(Color.Black, 3);
        g.DrawEllipse(penMata, 240, 255, 40, 40);

        g.DrawArc(Pens.Black, 205, 305, 50, 30, 20, 120);

        g.Restore(keadaan);
    }

    private void GambarSederhana(Graphics g)
    {
        GambarIkan(g, 200, 130, 1f);
    }

    private void GambarKompleks(Graphics g)
    {
        using LinearGradientBrush brushLaut = new LinearGradientBrush(
            new Rectangle(0, 0, 800, 600), Color.DeepSkyBlue, Color.MidnightBlue, 90f);
        g.FillRectangle(brushLaut, 0, 0, 800, 600);

        using Pen penCahaya = new Pen(Color.FromArgb(70, Color.White), 8);
        for (int i = 0; i < 6; i++)
        {
            g.DrawLine(penCahaya, 100 + i * 140, 0, i * 140 - 40, 480);
        }

        g.FillRectangle(Brushes.SandyBrown, 0, 500, 800, 100);

        using GraphicsPath badanKapal = new GraphicsPath();
        badanKapal.AddEllipse(80, 270, 260, 90);
        g.FillPath(Brushes.Gold, badanKapal);
        using Pen penKapal = new Pen(Color.DarkGoldenrod, 4);
        g.DrawPath(penKapal, badanKapal);

        g.FillRectangle(Brushes.Gold, 180, 240, 60, 35);
        g.DrawRectangle(penKapal, 180, 240, 60, 35);

        using Pen penPeriskop = new Pen(Color.DimGray, 5);
        g.DrawLine(penPeriskop, 210, 240, 210, 205);
        g.DrawLine(penPeriskop, 210, 205, 235, 205);

        Point[] bendera = { new Point(237, 196), new Point(237, 214), new Point(256, 205) };
        g.FillPolygon(Brushes.Red, bendera);
        g.DrawPolygon(Pens.Black, bendera);

        using Region bingkai = new Region(new Rectangle(120, 295, 32, 32));
        bingkai.Exclude(new Rectangle(125, 300, 22, 22));
        g.FillRegion(Brushes.SaddleBrown, bingkai);
        g.FillEllipse(Brushes.LightCyan, 125, 300, 22, 22);
        g.FillEllipse(Brushes.LightCyan, 200, 300, 22, 22);
        g.FillEllipse(Brushes.LightCyan, 270, 300, 22, 22);

        GambarIkan(g, 500, 200, 0.32f);

        for (int i = 0; i < 3; i++)
        {
            g.DrawEllipse(Pens.White, 482 - i * 6, 170 - i * 35, 12 + i * 4, 12 + i * 4);
        }

        using SolidBrush brushTudung = new SolidBrush(Color.FromArgb(210, 221, 160, 221));
        g.FillPie(brushTudung, 340, 60, 140, 120, 180, 180);
        using SolidBrush brushKilau = new SolidBrush(Color.FromArgb(110, Color.White));
        g.FillPie(brushKilau, 362, 72, 96, 76, 180, 180);
        g.DrawPie(Pens.Purple, 340, 60, 140, 120, 180, 180);

        using SolidBrush brushTepi = new SolidBrush(Color.FromArgb(210, Color.Plum));
        for (int i = 0; i < 7; i++)
        {
            g.FillEllipse(brushTepi, 340 + i * 20, 112, 20, 16);
        }

        using Pen penTentakel = new Pen(Color.FromArgb(180, Color.Plum), 2);
        for (int i = 0; i < 6; i++)
        {
            float tx = 352 + i * 23;
            PointF[] tentakel = new PointF[5];
            for (int j = 0; j < 5; j++)
            {
                float tinggi = 25 + (i % 2) * 10;
                tentakel[j] = new PointF(tx + (float)Math.Sin(j * 1.5 + i) * 6, 126 + j * tinggi);
            }
            g.DrawCurve(penTentakel, tentakel);
        }

        using Pen penLenganMulut = new Pen(Color.FromArgb(200, Color.Orchid), 5);
        Point[] lenganMulut = { new Point(410, 124), new Point(395, 150), new Point(425, 175),
                                new Point(405, 200), new Point(415, 215), new Point(432, 232),
                                new Point(410, 255) };
        g.DrawBeziers(penLenganMulut, lenganMulut);

        using Pen penRumput = new Pen(Color.SeaGreen, 8);
        Point[] rumput = { new Point(660, 505), new Point(635, 450), new Point(665, 400),
                           new Point(640, 350), new Point(660, 310) };
        g.DrawCurve(penRumput, rumput);
        g.DrawBezier(penRumput, 730, 505, 700, 440, 760, 400, 725, 330);

        using Pen penKarang = new Pen(Color.Crimson, 5);
        Point[] karang = { new Point(400, 505), new Point(410, 450), new Point(440, 425),
                           new Point(470, 455), new Point(480, 505), new Point(440, 515) };
        g.DrawClosedCurve(penKarang, karang);

        g.FillRectangle(Brushes.SaddleBrown, 520, 465, 90, 40);
        g.DrawRectangle(Pens.Black, 520, 465, 90, 40);

        Rectangle[] batu = new Rectangle[5];
        for (int i = 0; i < 5; i++) batu[i] = new Rectangle(20 + i * 32, 520, 26, 22);
        g.FillRectangles(Brushes.Gray, batu);

        using Bitmap bintang = new Bitmap(32, 32);
        using (Graphics gb = Graphics.FromImage(bintang))
        {
            gb.SmoothingMode = SmoothingMode.AntiAlias;
            PointF[] titik = new PointF[10];
            for (int i = 0; i < 10; i++)
            {
                double sudut = (i * 36 - 90) * Math.PI / 180;
                float r = (i % 2 == 0) ? 15 : 6;
                titik[i] = new PointF(16 + (float)(r * Math.Cos(sudut)), 16 + (float)(r * Math.Sin(sudut)));
            }
            gb.FillPolygon(Brushes.Orange, titik);
        }
        g.DrawImage(bintang, 250, 525);
        g.DrawImage(bintang, 330, 550);
        g.DrawImage(bintang, 690, 540);
    }
}