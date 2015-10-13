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
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            foreach (SongListItem item in Items) item.Width = Width - 20;
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
                item.Width = Width - 20;
                Controls.Add(item);
                i++;
            }
        }
    }

    public class SongListItem : Control
    {
        public static System.Drawing.Image Play;
        public static System.Drawing.Image Pause;
        public static System.Drawing.Image Favorite;
        public static System.Drawing.Image Unfavorite;

        public KnownSongInfo SongInfo;

        public SongListItem()
        {
            Height = 45;
            Font = new Font(Main.fontCollection.Families[1], 18, FontStyle.Regular, GraphicsUnit.Pixel);
            DoubleBuffered = true;
        }

        public Color HoverColor = Color.FromArgb(200, 205, 203);
        public Color NormalColor = Color.FromArgb(220, 225, 223);
        public Color FontColor = Color.FromArgb(20, 30, 25);

        public bool isHovered = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            Refresh();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(isHovered ? HoverColor : NormalColor);
            g.FillRectangle(p.Brush, 0, 0, Width, Height);
            p.Color = FontColor;
            g.DrawString(SongInfo.Name, Font, p.Brush, 2, Height / 8);
        }
    }
}
