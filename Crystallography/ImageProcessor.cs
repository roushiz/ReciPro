﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Crystallography
{
    public static class ImageProcess
    {
        /// <summary>
        /// GaussianBlurを施す。
        /// </summary>
        /// <param name="pixels">画像データの一次元配列</param>
        /// <param name="width">画像の幅</param>
        /// <param name="radius">ピクセル単位でのフィルムにじみ半値幅</param>
        /// <returns></returns>
        unsafe static public double[] GaussianBlur(double[] pixels, int width, double radius)
        {
            /*  var src = Cv.Mat<double>(width, pixels.Length / width, MatrixType.F64C1, pixels);
              var dst = src.Clone();
              src.Smooth(dst, SmoothType.Gaussian, (int)(radius * 3) * 2 + 1, 0, radius, radius);
              double[] results = new double[pixels.Length];
              Marshal.Copy(dst.DataArrayDouble.Ptr, results, 0, pixels.Length);

              return results;
              */
            int limit = (int)(radius * 2) * 2 + 1;
            int center = limit / 2;
            int height = pixels.Length / width;
            if (limit == 1 || width * height != pixels.Length)
                return pixels.ToArray();

            Dictionary<int, double> tempDic = new Dictionary<int, double>();

            for (int h = 0; h < limit; h++)
                for (int w = 0; w < limit; w++)
                    if ((h - center) * (h - center) + (w - center) * (w - center) <= center * center)
                        tempDic.Add((h - center) * width + w - center, Math.Exp(-((h - center) * (h - center) + (w - center) * (w - center)) / radius / radius * Math.Log(2)));
            double sum = tempDic.Values.Sum();
            var pair = tempDic.OrderBy(d => d.Value).ToArray();
            pair = pair.Select(d => new KeyValuePair<int, double>(d.Key, d.Value / sum)).ToArray();

            double[] blurredPixels = new double[pixels.Length];

            int thread = Environment.ProcessorCount;

            ParallelOptions p = new ParallelOptions { MaxDegreeOfParallelism = thread };

            double[][] blurTemp = new double[thread][];
            Parallel.For(0, thread, p, i =>
            {
                blurTemp[i] = new double[pixels.Length];
                for (int j = pair.Length / thread * i; j < Math.Min(pair.Length / thread * (i + 1), pair.Length); j++)
                {
                    double b = pair[j].Value;
                    int shift = pair[j].Key;
                    int start = Math.Max(-shift, 0);
                    int end = Math.Min(pixels.Length - shift, pixels.Length);
                    fixed (double* s = &pixels[start], d = &blurTemp[i][start + shift])
                    {
                        for (int k = 0; k < end - start; k++)
                            *(d + k) += b * (*(s + k));
                    }
                }
            }
            );
            for (int i = 1; i < thread; i++)
                for (int j = 0; j < pixels.Length; j++)
                    blurTemp[0][j] += blurTemp[i][j];

            return blurTemp[0];
        }

        /// <summary>
        /// GaussianBlurを施す。横方向と縦方向を分離するため、高速。
        /// </summary>
        /// <param name="pixels">画像データの一次元配列</param>
        /// <param name="width">画像の幅</param>
        /// <param name="radius">ピクセル単位でのフィルムにじみ半値半幅　</param>
        /// <returns></returns>
        unsafe static public double[] GaussianBlurFast(double[] pixels, int width, double hwhm)
        {
            
            int limit = (int)(hwhm * 3) * 2 + 1;
            int height = pixels.Length / width;

            int center = limit / 2;

            double[] pixelsFilmBlur1 = new double[width * height];
            double[] pixelsFilmBlur2 = new double[width * height];

            if (limit == 1)
            {
                for (int i = 0; i < pixels.Length; i++) pixelsFilmBlur2[i] = pixels[i];
                return pixelsFilmBlur2;
            }

            double[] blur = new double[limit];
            for (int h = 0; h < limit; h++)
                blur[h] = Math.Exp(-(h - center) * (h - center) / hwhm / hwhm * Math.Log(2));
            blur = Statistics.Normarize(blur);

            Parallel.For(0, width, w =>
            {
                for (int h = 0; h < height; h++)
                {
                    //if (pixels[h * width + w] != 0)
                    //for (int n = Math.Max(0, center - h); n < Math.Min(blur.Length, height - h + center); n++)
                    //    pixelsFilmBlur1[(h - center + n) * width + w] += blur[n] * pixels[h * width + w];

                    for (int n = Math.Max(0, center - h); n < Math.Min(blur.Length, height - h + center); n++)
                        pixelsFilmBlur1[h * width + w] += blur[n] * pixels[(h - center + n) * width + w];
                }
            });

            Parallel.For(0, height, h =>
            {
                for (int w = 0; w < width; w++)
                {
                    //if (pixelsFilmBlur1[h * width + w] != 0)
                    //for (int n = Math.Max(0, center - w); n < Math.Min(blur.Length, width - w + center); n++)
                    //    pixelsFilmBlur2[h * width + w - center + n] += blur[n] * pixelsFilmBlur1[h * width + w];
                    for (int n = Math.Max(0, center - w); n < Math.Min(blur.Length, width - w + center); n++)
                        pixelsFilmBlur2[h * width + w] += blur[n] * pixelsFilmBlur1[h * width + w - center + n];
                }
            });
            pixelsFilmBlur1 = null;

            return pixelsFilmBlur2;
        }

        /// <summary>
        /// 周囲のピクセルと比べて、標準偏差 × threshold以上外れたピクセルは、周囲のピクセルの平均強度にする。
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        unsafe static public double[] DustAndScratches(double[] pixels, int width, double radius, double threshold)
        {
            double[] results = new double[pixels.Length];
            Array.Copy(pixels, results, pixels.Length);
            int height = pixels.Length / width;

            List<int> index = new List<int>();
            for (int h = -(int)(radius + 1); h < (int)(radius + 1); h++)
                for (int w = -(int)(radius + 1); w < (int)(radius + 1); w++)
                    if (h * h + w * w <= radius * radius && h * h + w * w != 0)
                        index.Add(h * width + w);

            Parallel.For(1, height - 1, y =>
            {
                double[] list1 = new double[index.Count];
                double[] list2 = new double[index.Count >= 8 ? index.Count / 8 * 6 : index.Count];
                int pos = y * width;
                fixed (double* s = &pixels[pos], d = &results[pos])
                {
                    double* src = s, dst = d;
                    for (int x = 1; x < width - 1; x++)
                    {
                        src++;
                        dst++;

                        for (int i = 0; i < index.Count; i++)
                            list1[i] = *(src + index[i]);
                        Array.Sort(list1);
                        Array.Copy(list1, list1.Length / 8, list2, 0, list2.Length);
                        if (list2[0] > *src || list2[list2.Length - 1] < *src)
                        {
                            double sum = 0, sumSquare = 0;
                            for (int i = 0; i < list2.Length; i++)
                            {
                                sum += list2[i];
                                sumSquare += list2[i] * list2[i];
                            }
                            double average = sum / list2.Length;
                            double valiance = sumSquare / list2.Length - average * average;

                            if ((*src - average) * (*src - average) > valiance * threshold * threshold)
                                *dst = average;
                        }
                    }
                }
            });
            return results;
        }

        private static readonly object lockObj = new object();

        /// <summary>
        /// 画像中から、スポットを検出する。戻り値はList<Vector3DBase>. X, Y: スポットのピクセル上の位置,  Int: 強度
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <param name="distanceOfNearestSpots"></param>
        /// <param name="candidateNum"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public List<(double X, double Y, double Int)> FindSpots(double[] pixels, int width, double distanceOfNearestSpots = 5, int candidateNum = 500, IEnumerable<(double X, double Y)> activeSpots = null)
        {
            if (pixels == null) return null;
            var height = pixels.Length / width;
            var d = Deviate(pixels, width);

            //隣り合っているピクセルより小さな値を持つ場合はtrue
            var mList = new List<(int x, int y, double dev)>();
            Parallel.For(1, height - 1, y =>
             {
                 for (int x = 1; x < width - 1; x++)
                 {
                     var i = y * width + x;
                     var v = d[i];
                     if (v < 0 && v < d[i + 1] && v < d[i - 1] && v < d[i + width] && v < d[i - width] && v < d[i + 1 + width] && v < d[i - 1 + width] && v < d[i + 1 - width] && v < d[i - 1 - width])
                         lock (lockObj)
                             mList.Add((x, y, v));
                 }
             });
            mList.Sort((a, b) => (a.dev - b.dev > 0) ? 1 : (a.dev - b.dev < 0) ? -1 : 0);

            //minimumListの中から候補ピクセルを選出
            var list = new List<(int x, int y)>();
            var d2 = distanceOfNearestSpots * distanceOfNearestSpots;
            for (int i = 0; i < mList.Count && list.Count < candidateNum; i++)
                if (list.All(l => (mList[i].x - l.x) * (mList[i].x - l.x) + (mList[i].y - l.y) * (mList[i].y - l.y) > d2) &&
                   (activeSpots == null || activeSpots.Count() == 0 ||
                   activeSpots.All(s => (mList[i].x - s.X) * (mList[i].x - s.X) + (mList[i].y - s.Y) * (mList[i].y - s.Y) > d2)))
                    list.Add((mList[i].x, mList[i].y));

            //最後に自身を含めて周囲9ピクセルの平均強度を格納
            var vec = new List<(double X, double Y, double Int)>();
            for (int i = 0; i < list.Count; i++)
            {
                var intensity = 0.0;
                for (int xx = list[i].x - 1; xx < list[i].x + 2; xx++)
                    for (int yy = list[i].y - 1; yy < list[i].y + 2; yy++)
                        intensity += pixels[xx + yy * width] / 9.0;
                vec.Add((list[i].x, list[i].y, intensity));
            }
            return vec;
        }

        /// <summary>
        /// 画像を微分する
        /// </summary>
        /// <param name="pixels"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public double[] Deviate(double[] pixels, int width)
        {
            //画像を上下左右方向に微分する
            var height = pixels.Length / width;

            var pixelsH1 = new double[pixels.Length];
            var pixelsV1 = new double[pixels.Length];
            Parallel.For(0, height - 1, y =>
            {
                for (int x = 0; x < width - 1; x++)
                {
                    int index = y * width + x;
                    pixelsH1[index + 1] = pixels[index + 1] - pixels[index];
                    pixelsV1[index + width] = pixels[index + width] - pixels[index];
                }
            });

            var pixelsResults = new double[pixels.Length];
            Parallel.For(0, height - 1, y =>
              {
                  for (int x = 0; x < width - 1; x++)
                  {
                      int index = y * width + x;
                      pixelsResults[index] = pixelsH1[index + 1] - pixelsH1[index] + pixelsV1[index + width] - pixelsV1[index];
                  }
              });
            return pixelsResults;
        }

        /// <summary>
        /// 画像中からラインプロファイルを取得する
        /// </summary>
        /// <param name="pixels">なるべくParallelQuery<(double X, double Y, double Z)>の方がよい</param>
        /// <param name="imageWidth"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="width"></param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public PointD[] GetLineProfile(IEnumerable<(double X, double Y, double Z)> pixels, PointD start, PointD end, double width, double resolution)
        {
            //基本直線の式 a x + b y = c
            (double a, double b, double c) line = (end.Y - start.Y, start.X - end.X, (end.Y - start.Y) * start.X + (start.X - end.X) * start.Y);

            //候補となるピクセルは、以下の4本の直線(ax+by=c)の内部に存在するはず。
            (double a, double b, double c) parallel1 = (-line.a, -line.b, -line.c - width * Math.Sqrt(line.a * line.a + line.b * line.b));
            (double a, double b, double c) parallel2 = (line.a, line.b, line.c - width * Math.Sqrt(line.a * line.a + line.b * line.b));

            //(double a, double b, double c) normal1 = (-line.b, line.a, -line.b * start.X + line.a * start.Y);
            //(double a, double b, double c) normal2 = (line.b, -line.a, line.b * end.X - line.a * end.Y);

            var pixelsP = pixels is ParallelQuery<(double X, double Y, double Z)> ? (ParallelQuery<(double X, double Y, double Z)>)pixels : pixels.AsParallel();
            var targetPixels = pixelsP.Where(pix =>
            {
                (double X, double Y, double Z) = pix;
                var pts = new (double X, double Y)[] { (X - .5, Y - .5), (X + .5, Y - .5), (X + .5, Y + .5), (X - .5, Y + .5) };
                return pts.Any(p => p.X * parallel1.a + p.Y * parallel1.b >= parallel1.c) && pts.Any(p => p.X * parallel2.a + p.Y * parallel2.b >= parallel2.c);
            }).ToArray();

            var profile = new List<PointD>();
            var profileLength = (end - start).Length;
            var vec = (end - start) / profileLength;
            var center = (start + end) / 2;

            var startX = -(int)(profileLength / 2.0 / resolution + 0.5);
            return Enumerable.Range(startX, -startX * 2 + 1).ToList().AsParallel().Select(n =>
            {
                var s = center + resolution * (n - 0.5) * vec;
                var e = s + resolution * vec;
                (double a, double b, double c) normal1 = (-line.b, line.a, -line.b * s.X + line.a * s.Y);
                (double a, double b, double c) normal2 = (line.b, -line.a, line.b * e.X - line.a * e.Y);

                double intensity = 0, area = 0;
                foreach ((double x, double y, double z) in targetPixels)
                {
                    var pts = new[] { (x - .5, y - .5), (x + .5, y - .5), (x + .5, y + .5), (x - .5, y + .5) };
                    pts = Geometriy.GetPolygonDividedByLine(pts, normal1.a, normal1.b, normal1.c);
                    pts = Geometriy.GetPolygonDividedByLine(pts, normal2.a, normal2.b, normal2.c);
                    pts = Geometriy.GetPolygonDividedByLine(pts, parallel1.a, parallel1.b, parallel1.c);
                    pts = Geometriy.GetPolygonDividedByLine(pts, parallel2.a, parallel2.b, parallel2.c);
                    if (pts.Length > 2)
                    {
                        var a = Geometriy.GetPolygonalArea(pts);
                        area += a;
                        intensity += z * a;
                    }
                }
                return new PointD(n * resolution, area > 0 ? intensity / area : 0);
            }).ToArray();
        }
    }
}