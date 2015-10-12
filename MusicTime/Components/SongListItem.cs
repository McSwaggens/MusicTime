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
    public class SongListItem : Control
    {
        public KnownSongInfo SongInfo;

        public SongListItem(KnownSongInfo ksi)
        {
            SongInfo = ksi;
        }
        
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
        }
    }
}
