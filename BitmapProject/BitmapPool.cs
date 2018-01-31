using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace BitmapProject
{
    class BitmapPool
    {
        private BitmapAdapter _bitmapAdapter;
        private List<Bitmap> _listBitmaps;
        private string _path;

        public List<Bitmap> ListBitmaps
        {
            get => _listBitmaps;
            private set => _listBitmaps = value; 
        }

        public BitmapPool()
        {
            _listBitmaps = new List<Bitmap>();
        }

        public void GetOriginal(string path)
        {
            if(_path == path)
                return;
            
            _path = path;
            Bitmap a = new Bitmap(path);
            _bitmapAdapter = new BitmapAdapter(_path);
            _listBitmaps.Add(_bitmapAdapter.Bitmap);
            _listBitmaps.Add(_bitmapAdapter.GetNegative());
            _listBitmaps.Add(_bitmapAdapter.GetTurnLeftBitmap());
            _listBitmaps.Add(_bitmapAdapter.GetTurnRightBitmap());
        }
    }
}
