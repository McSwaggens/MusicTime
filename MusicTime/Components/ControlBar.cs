using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusicTime.Components
{
    public class ControlBar : Panel
    {
        TimeController timeController = new TimeController();
        Controller Play_Pause;
        Controller FastForward;
        Controller Rewind;

        private Image Play_Norm = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("play");
        private Image Play_Hovered = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("play_hovered");
        private Image Pause_Norm = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("pause");
        private Image Pause_Hovered = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("pause_hovered");

        private Image fastforward_Norm = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("fastforward");
        private Image fastforward_hovered = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("fastforward_hovered");
        private Image rewind_Norm = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("rewind");
        private Image rewind_hovered = ( Bitmap )MusicTime.Properties.Resources.ResourceManager.GetObject("rewind_hovered");

        public ControlBar()
        {
            //Play/Pause Button
            Play_Pause = new Controller(Play_Norm, Play_Hovered);
            Controls.Add(Play_Pause);
            Play_Pause.Size = new Size(37, 37);
            Play_Pause.Click += Play_Pause_Click;
            Play_Pause.DoubleClick += Play_Pause_Click;

            //Skit Forward Button
            FastForward = new Controller(fastforward_Norm, fastforward_hovered);
            Controls.Add(FastForward);
            FastForward.Size = new Size(24, 24);

            //Skip Backwards
            Rewind = new Controller(rewind_Norm, rewind_hovered);
            Controls.Add(Rewind);
            Rewind.Size = new Size(24, 24);
            

            //Time Controller
            Controls.Add(timeController);
            timeController.Width = Width;
            timeController.Height = 10;
            timeController.Location = new Point(0, 0);
        }

        private bool pp_state = false;

        private void Play_Pause_Click(object sender, EventArgs e)
        {
            pp_state = !pp_state;
            if (pp_state)
            {
                Play_Pause.image_Normal = Pause_Norm;
                Play_Pause.image_Hovered = Pause_Hovered;
            }
            else
            {
                Play_Pause.image_Normal = Play_Norm;
                Play_Pause.image_Hovered = Play_Hovered;
            }
            Play_Pause.Refresh();
        }



        protected override void OnPaintBackground(PaintEventArgs e) { }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(7, 11, 23));
            g.FillRectangle(pen.Brush, 0, 0, Width, Height);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            timeController.Width = Width;

            Play_Pause.Location = new Point((Width / 2) - (Play_Pause.Width / 2), ( Height / 2 ) - ( Play_Pause.Height / 2 ) + 1);

            FastForward.Location = new Point(Play_Pause.Location.X + ( Play_Pause.Width ) + 30, ( Height / 2 ) - ( FastForward.Height / 2 ) + 1);

            Rewind.Location = new Point(Play_Pause.Location.X - ( Rewind.Width ) - 30, ( Height / 2 ) - ( FastForward.Height / 2 ) + 1);
        }
    }

    public class Controller : Control
    {
        public Image image_Normal;
        public Image image_Hovered;
        public bool isHovered = false;
        public bool invisOnLeave = false;
        public Controller(Image i, Image hi)
        {
            image_Normal = i;
            image_Hovered = hi;
            DoubleBuffered = true;
        }

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

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(isHovered ? image_Hovered : image_Normal, new Rectangle(0, 0, Width, Height));
        }
    }

    public class TimeController : Control
    {

        bool isHovered  = false;

        public int Position = 50;

        public TimeController()
        {
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
        }

        bool isMouseDown = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Position = ( int )( ( ( ( float )e.X ) / ( ( float )Width ) ) * ( ( float )100 ) );
            isMouseDown = true;
            Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {

            isMouseDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Position = ( int )( ( ( ( float )e.X ) / ( ( float )Width ) ) * ( ( float )100 ) );
                Refresh();
            }
        }

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

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(19, 112, 204));
            float at = ( Width / 100f ) * Position;
            g.DrawLine(pen, 0, 0, at, 0);
            pen.Color = Color.FromArgb(20, 79, 138);
            g.FillRectangle(pen.Brush, 0, 1, at, (isHovered ? 3 : 2 ));
            if (isHovered)
            {
                pen.Color = Color.FromArgb(20, 79, 138);
                //g.FillRectangle(pen.Brush, 0, 5, at, 2);
            }
        }
    }
}
