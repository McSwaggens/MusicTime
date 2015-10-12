using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicTimeCore;

namespace MusicTime
{
    public class KnownSongInfo
    {
        public string Artist { get; set; }
        public string Name { get; set; }

        private Song _internalSong;

        public void SetSong(Song song)
        {
            _internalSong = song;
        }

        public Song GetSong()
        {
            return _internalSong;
        }
    }
}
