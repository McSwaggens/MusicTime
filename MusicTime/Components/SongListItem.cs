using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicTimeCore;

namespace MusicTime.Components
{
    public class SongListPanel : Panel
    {
        List<SongListItem> Items = new List<SongListItem>();

        public SongListPanel()
        {
            AutoScroll = true;
            DoubleBuffered = true;
        }

        public void Set(IEnumerable<KnownSongInfo> info)
        {
            List<KnownSongInfo> construct = new List<KnownSongInfo>();
            foreach (KnownSongInfo i in info)
            {
                construct.Add(i);
            }
            Render(construct);
            Order();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Items.Count > 0)
                Order();
        }

        public void Order()
        {
            int GridWidth = (Width / (300 + 20));
            int GridHeight = (Height / (100 + 20));

            //Console.WriteLine("Max Grid Width: " + GridWidth + "\nMax Grid Height: " + GridHeight);

            for (int i = 0; i < Items.Count; i++)
            {
                SongListItem item = Items[i];
                item.Location = new Point(i % GridWidth * 310, i/GridWidth * 110);
                //Console.WriteLine("Max Grid Width: " + GridWidth + "\nMax Grid Height: " + GridHeight);
            }
        }

        private void Render(IEnumerable<KnownSongInfo> Songs)
        {
            foreach (SongListItem item in Items)
            {
                item.Dispose();
                Controls.Remove(item);
            }
            Items.Clear();
            Controls.Clear();
            int i = 0;
            foreach (KnownSongInfo info in Songs)
            {
                SongListItem item = new SongListItem();
                item.SongInfo = info;
                item.Location = new Point(0, ( 50 * i ));
                item.Size = new Size(300, 100);
                Items.Add(item);
                Controls.Add(item);
                i++;
            }
        }
    }

    public class SongListItem : Control
    {
        public static System.Drawing.Image Play_Norm = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("eplay");
        public static System.Drawing.Image Play_Hovered = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("eplay_hovered");
        public static System.Drawing.Image Heart_Norm = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("heart_disabled");
        public static System.Drawing.Image Heart_Hovered = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("heart_enabled");

        public KnownSongInfo SongInfo;

        private Controller PlayButton = new Controller(Play_Norm, Play_Hovered);
        private Controller FavoriteButton = new Controller(Heart_Norm, Heart_Hovered);

        public SongListItem()
        {
            Height = 45;
            Font = new Font(Main.fontCollection.Families[1], 18, FontStyle.Regular, GraphicsUnit.Pixel);
            DoubleBuffered = true;
            Controls.Add(PlayButton);
            Controls.Add(FavoriteButton);
            PlayButton.BackColor = NormalColor;
            FavoriteButton.BackColor = NormalColor;
            PlayButton.Size = new Size(20, 20);
            FavoriteButton.Size = new Size(20, 20);
            PlayButton.Visible = false;
            FavoriteButton.Visible = false;
            PlayButton.invisOnLeave = true;
            FavoriteButton.invisOnLeave = true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            PlayButton.Location = new Point(Width - PlayButton.Width, ( Height / 2 ) - ( PlayButton.Height / 2 ));
            FavoriteButton.Location = new Point(Width - (FavoriteButton.Width) - (PlayButton.Width + 10), ( Height / 2 ) - ( FavoriteButton.Height / 2 ));
            Refresh();
        }

        public Color HoverColor = Color.FromArgb(10, 21, 51);
        public Color NormalColor = Color.FromArgb(10, 21, 51);
        public Color FontColor = Color.FromArgb(20, 30, 25);

       //public Color HoverColor = Color.FromArgb(200, 205, 203);
       //public Color NormalColor = Color.FromArgb(220, 225, 223);
       //public Color FontColor = Color.FromArgb(20, 30, 25);

        public bool isHovered = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            Console.WriteLine("Entered");
            PlayButton.Visible = true;
            FavoriteButton.Visible = true;
            PlayButton.BackColor = HoverColor;
            FavoriteButton.BackColor = HoverColor;
            isHovered = true;
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!PlayButton.isHovered || !FavoriteButton.isHovered)
            {
                Console.WriteLine("In");
                //PlayButton.Visible = false;
                //FavoriteButton.Visible = false;
                PlayButton.BackColor = NormalColor;
                FavoriteButton.BackColor = NormalColor;
                isHovered = false;
                Refresh();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(isHovered ? HoverColor : NormalColor);
            g.FillRectangle(p.Brush, 0, 0, Width, Height);
            p.Color = Color.White;
            g.DrawString(SongInfo.Name, Font, p.Brush, 2, Height / 8);
        }
    }
}
