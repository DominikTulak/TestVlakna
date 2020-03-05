using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PhotoEditor.Model
{
    class Functions
    {
        public BitmapImage src;

        int[,] array2D;

        public void ProvestVSamostatnemVlakne(BitmapImage img) //Úprava zelené v samostatném vlákně (bod č.1)
        {
            new System.Threading.Thread((img) =>
            {
                Uprava_3(img);
            }).Start();
        }
        public string PorovnatRychlostMetod() //Porovnání rychlosti 2 metod (v zadání bod č.3)
        {
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            //Metoda_1();
            stopwatch1.Stop();

            stopwatch2.Start();
            //Metoda_2();
            stopwatch2.Stop();

            /*nebo Console.WriteLine*/ return ("Čas první metody: {0},\n čas druhé metody: {1},\n rozdíl: {2}", stopwatch1.Elapsed, stopwatch2.Elapsed, (stopwatch1.Elapsed > stopwatch2.Elapsed ? stopwatch1.Elapsed - stopwatch2.Elapsed : stopwatch2.Elapsed - stopwatch1.Elapsed));
        }

        public BitmapImage Uprava_4(BitmapImage img, int delitel) //Redukce barevné hloubky (bod č.5)
        {
            array2D = BitmapImageToArray2D(img);
            for (int x = 0; x < array2D.GetLength(0); x++)
            {
                for (int y = 0; y < array2D.GetLength(1); y++)
                {
                    int soucet = (array2D[x, y] & 0xFF000000) / delitel;
                    soucet = soucet >> 16;
                    if (soucet > 255) soucet = 255;
                    soucet = soucet << 16;
                    array2D[x, y] = array2D[x, y] + soucet;
                }
            }
            return ConvertWriteableBitmapToBitmapImage(Array2DToBitmapImage());
        }
        




        public BitmapImage Uprava_1(BitmapImage img)
        {
            array2D = BitmapImageToArray2D(img);

            for (int x = 0; x < array2D.GetLength(0); x++)
            {
                for (int y = 0; y < array2D.GetLength(1); y++)
                {
                    array2D[x, y] = array2D[x, y] & 0xFF0000;
                }
            }
            return ConvertWriteableBitmapToBitmapImage(Array2DToBitmapImage());
        }

        public BitmapImage Uprava_2(BitmapImage img)
        {
            array2D = BitmapImageToArray2D(img);
            int o_kolik = 50;
            int cervena_zesileni = o_kolik << 16;

            for (int x = 0; x < array2D.GetLength(0); x++)
            {
                for (int y = 0; y < array2D.GetLength(1); y++)
                {
                    int soucet = (array2D[x, y] & 0x00FF0000) + cervena_zesileni;
                    soucet = soucet >> 16;
                    if (soucet > 255) soucet = 255;
                    soucet = soucet << 16;
                    array2D[x, y] = array2D[x, y] + soucet;
                }
            }
            return ConvertWriteableBitmapToBitmapImage(Array2DToBitmapImage());
        }
        public BitmapImage Uprava_3(BitmapImage img)
        {
            array2D = BitmapImageToArray2D(img);
            int o_kolik = 50;
            int zelena_zesileni = o_kolik << 16;

            for (int x = 0; x < array2D.GetLength(0); x++)
            {
                for (int y = 0; y < array2D.GetLength(1); y++)
                {
                    int soucet = (array2D[x, y] & 0x0000FF00) + zelena_zesileni;
                    soucet = soucet >> 16;
                    if (soucet > 255) soucet = 255;
                    soucet = soucet << 16;
                    array2D[x, y] = array2D[x, y] + soucet;
                }
            }
            return ConvertWriteableBitmapToBitmapImage(Array2DToBitmapImage());
        }
        

        public int[,] BitmapImageToArray2D(BitmapImage img)
        {
            array2D = new int[img.PixelHeight, img.PixelWidth];

            WriteableBitmap wb = new WriteableBitmap(img);
            int width = wb.PixelWidth;
            int height = wb.PixelHeight;
            int bytesPerPixel = (wb.Format.BitsPerPixel + 7) / 8;
            int stride = wb.BackBufferStride;
            wb.Lock();
            unsafe
            {
                byte* pImgData = (byte*)wb.BackBuffer;
                int cRowStart = 0;
                int cColStart = 0;
                for (int row = 0; row < height; row++)
                {
                    cColStart = cRowStart;
                    for (int col = 0; col < width; col++)
                    {
                        byte* bPixel = pImgData + cColStart;
                        //bPixel[0] // Blue
                        //bPixel[1] // Green
                        //bPixel[2] // Red
                        int pixel = bPixel[2]; //Red
                        pixel = (pixel << 8) + bPixel[1]; //Green
                        pixel = (pixel << 8) + bPixel[0]; //Blue
                        array2D[row, col] = pixel;

                        cColStart += bytesPerPixel;
                    }
                    cRowStart += stride;
                }
            }
            return array2D;

        }

        public WriteableBitmap Array2DToBitmapImage()
        {
            WriteableBitmap wb = new WriteableBitmap(src);
            int width = wb.PixelWidth;
            int height = wb.PixelHeight;
            int bytesPerPixel = (wb.Format.BitsPerPixel + 7) / 8;
            int stride = wb.BackBufferStride;
            wb.Lock();
            unsafe
            {
                byte* pImgData = (byte*)wb.BackBuffer;
                int cRowStart = 0;
                int cColStart = 0;
                for (int row = 0; row < height; row++)
                {
                    cColStart = cRowStart;
                    for (int col = 0; col < width; col++)
                    {
                        byte* bPixel = pImgData + cColStart;

                        bPixel[0] = (byte)((array2D[row, col] & 0xFF));// Blue
                        bPixel[1] = (byte)((array2D[row, col] & 0xFF00) >> 8);// Green
                        bPixel[2] = (byte)((array2D[row, col] & 0xFF0000) >> 16);// Red

                        cColStart += bytesPerPixel;
                    }
                    cRowStart += stride;
                }
            }
            wb.Unlock();
            wb.Freeze();

            return wb;

        }
        public BitmapImage ConvertWriteableBitmapToBitmapImage(WriteableBitmap wbm)
        {
            BitmapImage bmImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wbm));
                encoder.Save(stream);
                bmImage.BeginInit();
                bmImage.CacheOption = BitmapCacheOption.OnLoad;
                bmImage.StreamSource = stream;
                bmImage.EndInit();
                bmImage.Freeze();
            }
            return bmImage;
        }

        


    }
}