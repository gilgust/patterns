using System.Drawing;
using System.Drawing.Imaging;

namespace BitmapProject
{
    class BitmapAdapter
    {
        private Bitmap _bitmap;

        public BitmapAdapter(string image)
        {
            _bitmap = new Bitmap(image);
        }

        public Bitmap Bitmap
        {
            get => _bitmap;
            set => _bitmap = value;
        }

        public Bitmap GetNegative()
        {
            Bitmap clone = (Bitmap)_bitmap.Clone();

            using (Graphics g = Graphics.FromImage(clone))
            {

                // negation ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] {-1, 0, 0, 0, 0},
                        new float[] {0, -1, 0, 0, 0},
                        new float[] {0, 0, -1, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {1, 1, 1, 0, 1}
                    });

                ImageAttributes attributes = new ImageAttributes();

                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(clone, new Rectangle(0, 0, clone.Width, clone.Height),
                    0, 0, clone.Width, clone.Height, GraphicsUnit.Pixel, attributes);
            }
            return clone;
        }

        public Bitmap GetTurnLeftBitmap()
        {
            Bitmap clone = (Bitmap)_bitmap.Clone();
            clone.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return clone;
        }

        public Bitmap GetTurnRightBitmap()
        {
            Bitmap clone = (Bitmap)_bitmap.Clone();
            clone.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return clone;
        }

    }
}
