using Crycker.Data;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Crycker.Controls
{
    class MiniChart
    {
        Values values;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Image Image
        {
            get
            {
                return Draw();
            }
        }

        public MiniChart(int width, int height, Values values)
        {
            Width = width;
            Height = height;
            this.values = values;
        }

        private Bitmap Draw()
        {
            var image = new Bitmap(Width, Height);
            var drawing = Graphics.FromImage(image);

            if (values.Count < 2)
                return image;

            var min = values.Min();
            var max = values.Max();
            var scale = (Height - 2) / (max - min);

            drawing.SmoothingMode = SmoothingMode.AntiAlias;

            //var path = new GraphicsPath();

            float x = 0;
            float y = 0;
            float lastX = 0;
            float lastY = 0;

            for (int i = 1; i < values.Count; i++)
            {
                x += (Width - 2) / (float)(values.Count - 1);
                y = Height - (int)((values[i] - min) * scale);

                drawing.DrawLine(Pens.Black, lastX, lastY, x, y);
                drawing.DrawEllipse(values[i] == max ? Pens.Green : values[i] == min ? Pens.Red : Pens.Black, x, y, 2, 2);

                Debug.WriteLine($"{x}, {y}");

                lastX = x;
                lastY = y;

            }



            //drawing.DrawPath(Pens.Black, path);

            return image;
        }
    }
}
