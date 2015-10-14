using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicTime.Components;
using System.IO;
using System.Drawing.Text;
using MusicTimeCore;
using System.Threading;

namespace MusicTime
{
    public partial class Main : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public static PrivateFontCollection fontCollection = new PrivateFontCollection();

        public Main()
        {
            InitializeComponent();

            LoadFont(MusicTime.Properties.Resources.OleoScript_Regular);
            LoadFont(MusicTime.Properties.Resources.SourceSansPro_Regular);

            MusicTime_Title.Font = new Font(fontCollection.Families[0], 30, FontStyle.Regular, GraphicsUnit.Pixel);
            MusicTime_Title.ForeColor = Color.FromArgb(20, 79, 138);
            MusicTime_Title.Location = new Point(( Width / 2 ) - ( MusicTime_Title.Width / 2 ), ( (Height - 80) / 2 ) - ( MusicTime_Title.Height / 2 ));

            SearchBox.TextChanged += SearchBox_Typed;
        }

        protected override void OnClosed(EventArgs e)
        {
            //Threads may be in the background, using this will force exit the process
            Environment.Exit(0);
        }

        private SearchThread CurrentSearchThread;
        private Thread TextAniThread;
        private bool TextChanged = false;
        private bool allive = false;
        private void SearchBox_Typed(object sender, EventArgs e)
        {
            if (CurrentSearchThread != null)
            {
                CurrentSearchThread.isPrimary = false;
            }
            if (!String.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchCollection.Visible = false;
                if (TextAniThread == null)
                {
                    TextAniThread = new Thread(() =>
                    {
                        allive = true;
                        while (true)
                        {
                            TextChanged = false;
                            Thread.Sleep(350);

                            if (!TextChanged)
                            {
                                CurrentSearchThread = new Main.SearchThread(this);
                                CurrentSearchThread.Start();
                                break;
                            }
                        }
                        allive = false;
                        TextAniThread = null;
                    });
                }
                if (!allive)
                    TextAniThread.Start();
                TextChanged = true;
                LoadingAnimation.Visible = true;
                MusicTime_Title.Visible = true;
            }
            else
            {
                LoadingAnimation.Visible = false;
                MusicTime_Title.Visible = false;
            }
        }

        class SearchThread
        {
            public Main forminst;
            private Thread thread;

            public void Start()
            {
                thread.Start();
            }

            public SearchThread(Main inst)
            {
                forminst = inst;
                thread = new Thread(() =>
                {
                    try
                    {
                        IEnumerable<Song> Result;
                        Result = MusicTimeCore.SourceFetch.Search(forminst.SearchBox.Text);
                        string g = forminst.SearchBox.Text;
                        List<KnownSongInfo> build = new List<KnownSongInfo>();
                        int Filtered = 0;
                        foreach (Song song in Result)
                        {
                            song.Name = System.Web.HttpUtility.HtmlDecode(song.Name);
                            if (!song.Name.Contains("Ð"))
                            {
                                build.Add(new KnownSongInfo() { Artist = song.Artist, Name = song.Name });
                            }
                            else Filtered++;
                        }
                        Console.WriteLine("Filtered " + Filtered + " results");
                        if (isPrimary)
                        {
                            forminst.Invoke(new MethodInvoker(delegate
                            {
                                forminst.LoadingAnimation.Visible = false;
                                forminst.MusicTime_Title.Visible = false;
                                forminst.SearchCollection.Set(build);
                            }));
                        }
                        Console.WriteLine("Returned for: \"" + g + "\"");
                    } catch (Exception ee)
                    {
                        Console.WriteLine("Error fetching content: " + ee.Message);
                    }
                    finally
                    {
                        forminst.Invoke(new MethodInvoker(delegate
                        {
                            forminst.SearchCollection.Visible = true;
                        }));
                    }
                });
            }
            public bool isPrimary = true;
        }

        void LoadFont (byte[] font)
        {
            Stream fontStream = new MemoryStream(font);
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            Byte[] fontData = new Byte[fontStream.Length];
            fontStream.Read(fontData, 0, ( int )fontStream.Length);
            Marshal.Copy(fontData, 0, data, ( int )fontStream.Length);
            uint cFonts = 0;
            AddFontMemResourceEx(data, ( uint )fontData.Length, IntPtr.Zero, ref cFonts);
            fontCollection.AddMemoryFont(data, ( int )fontStream.Length);
            fontStream.Close();
            Marshal.FreeCoTaskMem(data);
        }

        protected override void OnShown(EventArgs e)
        {
            controlBar.Height = 50;
            CheckSizing();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            CheckSizing();
        }

        void CheckSizing()
        {
            controlBar.Location = new Point(0, ClientSize.Height - controlBar.Height);
            controlBar.Width = ClientSize.Width;
            controlBar.Refresh();
            MusicTime_Title.Location = new Point(( Width / 2 ) - ( MusicTime_Title.Width / 2 ), ( ( Height - 80 ) / 2 ) - ( MusicTime_Title.Height / 2 ));
            LoadingAnimation.Location = new Point(MusicTime_Title.Location.X + ( MusicTime_Title.Width / 3 ), MusicTime_Title.Location.Y + 45);
            SearchBox.Location = new Point(( (Width) / 2 ) - ( SearchBox.Width / 2 ), 7);
            //panel1.Visible = SearchCollection.Location.X > panel1.Width;
            //Console.WriteLine(Width);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
