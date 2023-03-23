﻿#region
using MemoryPack;
using MemoryPack.Compression;
using Microsoft.Scripting.Utils;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Math;
#endregion

namespace ReciPro;
public partial class FormImageSimulator : Form
{
    #region プロパティ

    public ImageSimulatorSetting Setting { get => new ImageSimulatorSetting("", this); set => value.Apply(this); }

    public bool Native => toolStripComboBoxCaclulationLibrary.SelectedIndex == 0;
    public HRTEM_Modes HRTEM_Mode
    {
        get => radioButtonModeQuasiCoherent.Checked ? HRTEM_Modes.Quasi : HRTEM_Modes.TCC;
        set
        {
            if (value == HRTEM_Modes.Quasi)
                radioButtonModeQuasiCoherent.Checked = true;
            else
                radioButtonModeTransmissionCrossCoefficient.Checked = true;
        }
    }

    public ImageModes ImageMode
    {
        get => radioButtonHRTEM.Checked ? ImageModes.HRTEM : radioButtonProjectedPotential.Checked ? ImageModes.POTENTIAL : ImageModes.STEM;
        set
        {
            if (value == ImageModes.HRTEM)
                radioButtonHRTEM.Checked = true;
            else if (value == ImageModes.POTENTIAL)
                radioButtonProjectedPotential.Checked = true;
            else
                radioButtonSTEM.Checked = true;

        }
    }

    /// <summary>
    /// 電子の加速電圧 (kV)
    /// </summary>
    public double AccVol { get => numericBoxAccVol.Value; set => numericBoxAccVol.Value = value; }
    /// <summary>
    /// 電子の波長 (nm)
    /// </summary>
    public double Rambda => UniversalConstants.Convert.EnergyToElectronWaveLength(AccVol);

    /// <summary>
    /// 対物絞りのサイズ (rad)
    /// </summary>
    public double ObjAperRadius
    {
        get => checkBoxOpenAperture.Checked ? double.PositiveInfinity : numericBoxObjAperRadius.Value / 1000;
        set
        {
            if (double.IsPositiveInfinity(value))
                checkBoxOpenAperture.Checked = true;
            else
            {
                checkBoxOpenAperture.Checked = true;
                numericBoxObjAperRadius.Value = value * 1000;
            }
        }
    }


    /// <summary>
    /// 対物絞りの中心位置X (rad)
    /// </summary>
    public double ObjAperX { get => numericBoxObjAperX.Value / 1000; set => numericBoxObjAperX.Value = value * 1000; }
    /// <summary>
    /// 対物絞りの中心位置Y (rad)
    /// </summary>
    public double ObjAperY { get => numericBoxObjAperY.Value / 1000; set => numericBoxObjAperY.Value = value * 1000; }

    /// <summary>
    /// β (llumination semiangle) (rad)
    /// </summary>
    public double Beta { get => numericBoxBetaAgnle.Value / 1000; set => numericBoxBetaAgnle.Value = value * 1000; }

    /// <summary>
    /// Bloch波の数
    /// </summary>
    public int BlochNum { get => numericBoxNumOfBlochWave.ValueInteger; set => numericBoxNumOfBlochWave.Value = value; }

    /// <summary>
    /// 試料の厚み (nm) (シリアルモードではないとき)
    /// </summary>
    public double Thickness { get => numericBoxThickness.Value; set => numericBoxThickness.Value = value; }

    /// <summary>
    /// デフォーカス値 (nm) (シリアルモードではないとき) 
    /// </summary>
    public double Defocus { get => numericBoxDefocus.Value; set => numericBoxDefocus.Value = value; }

    /// <summary>
    /// 球面収差 Cs (nm)
    /// </summary>
    public double Cs { get => numericBoxCs.Value * 1000000; set => numericBoxCs.Value = value / 1000000; }

    /// <summary>
    /// 色収差 Cc (nm)
    /// </summary>
    public double Cc { get => numericBoxCc.Value * 1000000; set => numericBoxCc.Value = value / 1000000; }

    /// <summary>
    /// 電子の加速電圧の揺らぎ (kV) numericBoxDeltaV.ValueはFWHMだが、2 * Sqrt(2 * Log(2)) で割って、σに変換する
    /// </summary>
    public double DeltaVol { get => numericBoxDeltaV.Value / 1000 / 2 / Sqrt(2 * Log(2)); set => numericBoxDeltaV.Value = value * 1000 * 2 * Sqrt(2 * Log(2)); }


    /// <summary>
    /// Δ
    /// </summary>
    public double Delta => Cc * DeltaVol / AccVol;

    /// <summary>
    /// Scherzer focus (nm)
    /// </summary>
    public double Scherzer => Cs > 0 ? -Sqrt(4.0 / 3.0 * Cs * Rambda) : Sqrt(4.0 / 3.0 * -Cs * Rambda);

    /// <summary>
    /// STEM Inelasticを計算する際のスライス厚み(nm単位)
    /// </summary>
    public double SliceThicknessForInelastic { get => numericBoxSliceThicknessForInelasticSTEM.Value; set => numericBoxSliceThicknessForInelasticSTEM.Value = value; }

    /// <summary>
    /// 実効的光源サイズ (nm単位)
    /// </summary>
    public double SourceSize { get => numericBoxSourceSize.Value / 1000; set => numericBoxSourceSize.Value = value * 1000; }

    /// <summary>
    /// イメージの解像度 (nm/pix)
    /// </summary>
    public double ImageResolution { get => numericBoxResolution.Value / 1000.0; set => numericBoxResolution.Value = value * 1000.0; }

    /// <summary>
    /// イメージサイズ 
    /// </summary>
    public Size ImageSize { get => new(numericBoxWidth.ValueInteger, numericBoxHeight.ValueInteger); set { numericBoxWidth.Value = value.Width; numericBoxHeight.Value = value.Height; } }

    public double[] ThicknessArray
    {
        get
        {
            if (radioButtonSingleMode.Checked || !checkBoxSerialThickness.Checked)
                return new[] { numericBoxThickness.Value };
            try
            {
                return textBoxThicknessList.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(str => Convert.ToDouble(str)).ToArray();
            }
            catch
            {
                MessageBox.Show("Values in Thickness list are invalid.");
                return null;
            }
        }
        set
        {
            if (value != null && value.Length > 0)
                textBoxThicknessList.Text = String.Join("\r\n", value);
        }
    }

    public double[] DefocusArray
    {
        get
        {
            if (radioButtonSingleMode.Checked || !checkBoxSerialDefocus.Checked)
                return new[] { numericBoxDefocus.Value };
            try
            {
                return textBoxDefocusList.Text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(str => Convert.ToDouble(str)).ToArray();
            }
            catch
            {
                MessageBox.Show("Values in Defocus list are invalid.");
                return null;
            }
        }
        set
        {
            if (value != null && value.Length > 0)
                textBoxDefocusList.Text = String.Join("\r\n", value);
        }
    }

    /// <summary>
    /// STEM検出器の内径角度 (rad)
    /// </summary>
    public double DetectorInnerAngle { get => numericBoxSTEM_DetectorInnerAngle.Value / 1000; set => numericBoxSTEM_DetectorInnerAngle.Value = value * 1000; }

    /// <summary>
    /// STEM検出器の外径角度 (rad)
    /// </summary>
    public double DetectorOuterAngle { get => numericBoxSTEM_DetectorOuterAngle.Value / 1000; set => numericBoxSTEM_DetectorOuterAngle.Value = value * 1000; }


    public double ConvergenceAngle { get => numericBoxSTEM_ConvergenceAngle.Value / 1000; set => numericBoxSTEM_ConvergenceAngle.Value = value * 1000; }

    private BetheMethod.Beam[] Beams { get; set; }

    private BetheMethod.Beam[] BeamsInside { get; set; }


    #endregion プロパティ

    #region フィールド、enum

    public string SettingName = "";

    public FormMain FormMain;
    public FormDiffractionSpotInfo FormDiffractionSpotInfo;

    public FormPresets formPresets;

    readonly Stopwatch sw1 = new(), sw2 = new(), sw3 = new(), sw4 = new();
    private static readonly double Pi2 = PI * PI;

    private ScalablePictureBox[,] pictureBoxes = new ScalablePictureBox[0, 0];

    private PseudoBitmap scaleImage;
    public enum ImageModes { HRTEM, POTENTIAL, STEM }

    public enum HRTEM_Modes { Quasi, TCC }

    #endregion フィールド

    #region 起動、終了、フォームイベントの関連
    public FormImageSimulator()
    {
        InitializeComponent();

        FormDiffractionSpotInfo = new FormDiffractionSpotInfo { Visible = false, FormImageSimulator = this };

        formPresets = new FormPresets() { Visible = false, Owner = this, TopMost = true, formImageSimulator = this };
    }

    private void FormImageSimulator_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        FormMain.toolStripButtonImageSimulator.Checked = false;
        FormDiffractionSpotInfo.Visible = false;
        this.Visible = false;
    }

    private void FormImageSimulator_Load(object sender, EventArgs e)
    {
        toolStripComboBoxCaclulationLibrary.SelectedIndex = 0;

        var width = pictureBoxPhaseScale.ClientRectangle.Width;
        var height = pictureBoxPhaseScale.ClientRectangle.Height;
        var temp = Enumerable.Range(0, width * height).ToList().Select(n => (double)(n % width) / width).ToArray();
        scaleImage = new PseudoBitmap(temp, width) { MaxValue = 1, MinValue = 0 };
        scaleImage.SetScaleRotation();
        pictureBoxPhaseScale.Image = scaleImage.GetImage();

        width = pictureBoxScaleOfIntensity.ClientRectangle.Width;
        height = pictureBoxScaleOfIntensity.ClientRectangle.Height;
        temp = Enumerable.Range(0, width * height).ToList().Select(n => (double)(n % width) / width).ToArray();
        scaleImage = new PseudoBitmap(temp, width) { MaxValue = 1, MinValue = 0 };
        scaleImage.SetScaleGray();
        pictureBoxScaleOfIntensity.Image = scaleImage.GetImage();

        comboBoxScaleColorScale.SelectedIndex = 0;

    }

    /// <summary>
    /// このフォームのVisibleが変更されたとき。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FormImageSimulator_VisibleChanged(object sender, EventArgs e)
    {
        if (this.Visible)
        {
            CalculateInsideSpotInfo();
            DrawLenzGraph();
        }
    }
    #endregion 起動、終了関連

    #region PseudoBitmapに格納する情報
    public class ImageInfo
    {
        public int Width, Height;
        public double Resolution;
        public PointD A, B, C;
        public Matrix3D Mat;
        public string Text;
        public bool LockIntensity;

        public ImageInfo(int width, int height, double resolution, Matrix3D mat, string text, bool lockIntensity = false)
        {
            Width = width;
            Height = height;
            Resolution = resolution;
            Mat = mat;
            A = new PointD(mat.E11, mat.E21);
            B = new PointD(mat.E12, mat.E22);
            C = new PointD(mat.E13, mat.E23);
            Text = text;
            LockIntensity = lockIntensity;
        }
    }
    #endregion PseudoBitmapに格納する情報

    #region Simulateボタン
    /// <summary>
    /// Simulateボタンが押されたとき
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonSimulate_Click(object sender, EventArgs e)
    {
        toolStripStatusLabel1.Text = "";
        toolStripProgressBar.Value = 0;

        if (ImageMode == ImageModes.HRTEM)
            SimulateHRTEM();
        else if (ImageMode == ImageModes.POTENTIAL)
            simulatePotential();
        else if (ImageMode == ImageModes.STEM)
            simulateSTEM();
    }
    #endregion

    #region STEMシミュレーション

    int stemDirectionTotal = 0;
    private void simulateSTEM(bool realtimeMode = false)
    {
        sw1.Reset(); sw2.Reset(); sw3.Reset(); sw4.Reset();
        sw1.Restart();
        if (ThicknessArray == null || DefocusArray == null) return;

        //ローテーション配列を作る //一辺が2.の正方形の中に一辺1/Nのピクセルを詰め込み、中心ピクセルが、円の中心とちょうど一致するような問題を考える
        var directions = new List<Vector3DBase>();

        // 収束角を1.05倍にしておく
        var division = (int)Math.Ceiling(numericBoxSTEM_ConvergenceAngle.Value * 2 * 1.05 / numericBoxSTEM_AngleResolution.Value);
        var sin = Sin(numericBoxSTEM_ConvergenceAngle.Value * 1.05 / 1000);

        var radius = division / 2.0;
        for (int h = 0; h < division; h++)
            for (int w = 0; w < division; w++)
            {
                var x = (w - radius + 0.5) / (radius - 0.5) * sin;
                var y = -(h - radius + 0.5) / (radius - 0.5) * sin;//結晶の座標系は、X軸が右、Y軸が上、Z軸が手前なのでYを反転
                directions.Add(new Vector3DBase(x, y, -Sqrt(1 - x * x - y * y)));
            }

        bool inside(int i) => (i % division - radius + 0.5) * (i % division - radius + 0.5) + (i / division - radius + 0.5) * (i / division - radius + 0.5) <= radius * radius;

        stemDirectionTotal = Enumerable.Range(0, division * division).Count(i => inside(i));

        toolStripProgressBar.Maximum = stemDirectionTotal;
        FormMain.Crystal.Bethe.StemProgressChanged += stemProgressChanged;
        FormMain.Crystal.Bethe.StemCompleted += stemCompleted;

        FormMain.Crystal.Bethe.RunSTEM(
            BlochNum,
            AccVol,
            Cs,
            Delta,
            SliceThicknessForInelastic,
            ImageSize,
            ImageResolution,
            SourceSize,
            FormMain.Crystal.RotationMatrix,
            ThicknessArray,
            DefocusArray,
            directions.ToArray(),
            ConvergenceAngle,
            DetectorInnerAngle,
            DetectorOuterAngle,
            radioButtonSTEM_target_Both.Checked || radioButtonSTEM_target_Elas.Checked,
            radioButtonSTEM_target_Both.Checked || radioButtonSTEM_target_Inel.Checked
            );

        this.buttonSimulate.Visible = false;
        this.buttonStop.Visible = true;
        this.splitContainer1.Enabled = false;

    }
    #region BackgroundWorkerからのProgressChanged, Completed

    private void buttonStop_Click(object sender, EventArgs e)
    {
        FormMain.Crystal.Bethe.CancelSTEM();
        this.buttonSimulate.Visible = true;
        this.buttonStop.Visible = false;
        this.splitContainer1.Enabled = true;
    }

    private bool skipProgressChangedEvent = false;
    private void stemProgressChanged(object sender, ProgressChangedEventArgs e)
    {

        if (skipProgressChangedEvent) return;
        skipProgressChangedEvent = true;

        double current = e.ProgressPercentage;
        long s1 = sw1.ElapsedMilliseconds, s2 = sw2.ElapsedMilliseconds, s3 = sw3.ElapsedMilliseconds, s4 = sw4.ElapsedMilliseconds;

        var message = (string)e.UserState;
        if (message.StartsWith("Calculating I_inelastic(Q)", StringComparison.Ordinal))
        {
            if (sw1.IsRunning) sw1.Stop();
            if (sw2.IsRunning) sw2.Stop();
            if (sw3.IsRunning) sw3.Stop();
            if (!sw4.IsRunning) sw4.Restart();
            var sec = s4 / 1000.0;
            var totalsec = sec + (s1 + s2 + s3) / 1000.0;
            toolStripProgressBar.Value = (int)((current / 1E6 * 0.8 + 0.2) * toolStripProgressBar.Maximum);
            toolStripStatusLabel1.Text = $"Ellapsed time : {totalsec:f1} s.  Stage 4: Calculating I_inelastic(Q).  ";
            toolStripStatusLabel2.Text = $"{current / 1E4:f1} % completed,  wait for more {sec * (1E6 - current) / current:f1} s.";
        }
        else if (message.StartsWith("Calculating U", StringComparison.Ordinal))
        {
            if (sw1.IsRunning) sw1.Stop();
            if (sw2.IsRunning) sw2.Stop();
            if (!sw3.IsRunning) sw3.Restart();
            var sec = s3 / 1000.0;
            var totalsec = sec + (s1 + s2) / 1000.0;
            toolStripProgressBar.Value = (int)((current / 1E6 * 0.01 + 0.19) * toolStripProgressBar.Maximum);
            toolStripStatusLabel1.Text = $"Ellapsed time : {totalsec:f1} s.  Stage 3: Calculating U' matrix.  ";
            toolStripStatusLabel2.Text = $"{current / 1E4:f1} % completed,  wait for more {sec * (1E6 - current) / current:f1} s.";
        }
        else if (message.StartsWith("Calculating I_elastic(Q)", StringComparison.Ordinal))
        {
            if (sw1.IsRunning) sw1.Stop();
            if (!sw2.IsRunning) sw2.Restart();
            var sec = s2 / 1000.0;
            var totalsec = sec + s1 / 1000.0;
            toolStripProgressBar.Value = (int)((current / 1E6 * 0.01 + 0.18) * toolStripProgressBar.Maximum);
            toolStripStatusLabel1.Text = $"Ellapsed time : {totalsec:f1} s.  Stage 2: Calculating I_elastic(Q).  ";
            toolStripStatusLabel2.Text = $"{current / 1E4:f1} % completed,  wait for more {sec * (1E6 - current) / current:f1} s.";
        }
        else
        {
            var sec = s1 / 1000.0;
            toolStripProgressBar.Value = (int)((current / 1E6 * 0.18 + 0.0) * toolStripProgressBar.Maximum);
            toolStripStatusLabel1.Text = $"Ellapsed time : {sec:f1} s.  Stage 1: Calculating Tg for " + stemDirectionTotal.ToString() + " directions (" + message + ").";
            toolStripStatusLabel2.Text = $"{current / 1E4:f1} % completed,  wait for more {sec * (1E6 - current) / current:f1} s.";
        }
        Application.DoEvents();
        skipProgressChangedEvent = false;
    }

    private void stemCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        FormMain.Crystal.Bethe.StemCompleted -= stemCompleted;
        FormMain.Crystal.Bethe.StemProgressChanged -= stemProgressChanged;
        long s1 = sw1.ElapsedMilliseconds, s2 = sw2.ElapsedMilliseconds, s3 = sw3.ElapsedMilliseconds, s4 = sw4.ElapsedMilliseconds;

        if (!e.Cancelled)
        {
            SendImage(ThicknessArray.Length, DefocusArray.Length, FormMain.Crystal.Bethe.STEM_Image, ImageSize.Width, ImageSize.Height);
            toolStripProgressBar.Value = toolStripProgressBar.Maximum;
            toolStripStatusLabel1.Text = $"Completed! Total ellapsed time: {(s1 + s2 + s3 + s4) / 1000.0:f1} sec.";
            toolStripStatusLabel1.Text += $"  Stage 1: {s1 / 1000.0:f1} sec.  Stage 2: {s2 / 1000.0:f1} sec.  Stage 3: {s3 / 1000.0:f1} sec.  Stage 4: {s4 / 1000.0:f1} sec.";

        }
        else
        {
            toolStripStatusLabel1.Text = $"Interupted! Total ellapsed time: {(s1 + s2 + s3) / 1000.0:f1} sec.";
        }
        toolStripStatusLabel2.Text = "";
        this.buttonSimulate.Visible = true;
        this.buttonStop.Visible = false;
        this.splitContainer1.Enabled = true;
        sw1.Stop(); sw1.Reset(); sw2.Stop(); sw2.Reset(); sw3.Reset(); sw3.Reset();
        Application.DoEvents();
    }

    #endregion

    #endregion;

    #region HREMシミュレーション
    public void SimulateHRTEM(bool realtimeMode = false)
    {
        sw1.Restart();

        if (ThicknessArray == null || DefocusArray == null) return;

        Beams = FormMain.Crystal.Bethe.GetDifractedBeamAmpriltudes(BlochNum, AccVol, FormMain.Crystal.RotationMatrix, ThicknessArray[0]);

        //LTF(レンズ伝達関数)を計算 && apertureの外にあるbeamを除外
        BeamsInside = BetheMethod.ExtractInsideBeams(Beams, AccVol, ObjAperRadius, ObjAperX, ObjAperY);
        if (BeamsInside.Length < 2)//絞りに入るスポットが2未満の時は、警告を出してリターン
        {
            if (!realtimeMode)
                MessageBox.Show("Obj. Aper. size is too small. Try again after increase the value!");
            return;
        }

        int width = ImageSize.Width, height = ImageSize.Height, dLen = DefocusArray.Length, tLen = ThicknessArray.Length;
        var totalImage = new double[tLen][][];

        for (int t = 0; t < tLen; t++)
        {
            //ベーテ法で振幅を計算. t=0の時は、最初の判定の時に計算済み
            Beams = t == 0 ? Beams : FormMain.Crystal.Bethe.GetDifractedBeamAmpriltudes(BlochNum, AccVol, FormMain.Crystal.RotationMatrix, ThicknessArray[t]);
            //絞りの内側のビームを取得
            BeamsInside = BetheMethod.ExtractInsideBeams(Beams, AccVol, ObjAperRadius, ObjAperX, ObjAperY);
            toolStripStatusLabel1.Text = $"Solving eigen problem: {sw1.ElapsedMilliseconds} msec.   ";

            //HRTEM画像を取得
            totalImage[t] = FormMain.Crystal.Bethe.GetHRTEMImage(BeamsInside, ImageSize, ImageResolution, Cs, Beta, Delta, DefocusArray, HRTEM_Mode == HRTEM_Modes.Quasi, Native);
            //進捗状況を報告
            toolStripProgressBar.Value = (int)(toolStripProgressBar.Maximum / tLen * (t + 1));
            toolStripStatusLabel1.Text += $"{toolStripProgressBar.Value} % completed.  ";
            if (!realtimeMode)
                Application.DoEvents();
        }
        var temp = sw1.ElapsedMilliseconds;
        toolStripStatusLabel1.Text += $"Generation of HRTEM images: {sw1.ElapsedMilliseconds} msec,   ";

        SendImage(tLen, dLen, totalImage, width, height);

        toolStripStatusLabel1.Text += $"Drawing: {sw1.ElapsedMilliseconds - temp} msec.";

    }
    #endregion

    #region ポテンシャルシミュレーション
    private void simulatePotential(bool realtimeMode = false)
    {
        sw1.Restart();

        if (!checkBoxPotentialUg.Checked && !checkBoxPotentialUgPrime.Checked) return;

        Beams = FormMain.Crystal.Bethe.GetDifractedBeamAmpriltudes(BlochNum, AccVol, FormMain.Crystal.RotationMatrix, ThicknessArray[0]);
        var images = FormMain.Crystal.Bethe.GetPotentialImage(Beams, ImageSize, ImageResolution, radioButtonPotentialModeMagAndPhase.Checked);

        //画像が上下左右反転しているみたいなので、処理 20230304
        for (int i = 0; i < images.Length; i++)
            images[i] = images[i].Reverse().ToArray();


        var temp = sw1.ElapsedMilliseconds;
        toolStripStatusLabel1.Text = $"Generation of Potential images: {temp} msec,   ";

        //最大値、最小値の設定
        double max = radioButtonPotentialModeMagAndPhase.Checked ? Max(images[0].Max(), images[2].Max()) : Max(Abs(images.Max(d => d.Max())), Abs(images.Min(d => d.Min())));
        double min = radioButtonPotentialModeMagAndPhase.Checked ? 0 : -max;

        //トラックバー設定
        SkipEvent = true;
        trackBarAdvancedMax.Value = trackBarAdvancedMin.Maximum = trackBarAdvancedMax.Maximum = max;
        trackBarAdvancedMin.Value = trackBarAdvancedMin.Minimum = trackBarAdvancedMax.Minimum = min;
        trackBarAdvancedMax.UpDown_Increment = trackBarAdvancedMin.UpDown_Increment = (max - min) / 100.0;
        SkipEvent = false;

        //作成したイメージをPseudoBitmapに変換
        var mat = FormMain.Crystal.RotationMatrix * FormMain.Crystal.MatrixReal;
        int width = ImageSize.Width, height = ImageSize.Height;
        var range = Enumerable.Range(0, 2).ToList();
        var pseudo = range.Select(_ => range.Select(_ => new PseudoBitmap()).ToList()).ToList();

        //振幅と位相モードの時
        if (radioButtonPotentialModeMagAndPhase.Checked)
            foreach (var (i, j, text) in new[] { (0, 0, "Ug magnitude"), (0, 1, "Ug phase"), (1, 0, "U'g magnitude"), (1, 1, "Ug phase") })
            {
                var src = j == 0 ? images[i * 2 + j] : images[i * 2 + j].Select(d => d / Math.PI * 180).ToArray();
                pseudo[i][j] = new PseudoBitmap(src, width)
                {
                    MaxValue = j == 0 ? max : 180,
                    MinValue = j == 0 ? min : -180,
                    Tag = new ImageInfo(width, height, ImageResolution, mat, text, j == 1),
                    Scale = j == 0 ?
                    (comboBoxScaleColorScale.SelectedIndex == 0 ? PseudoBitmap.Scales.GrayLinear : PseudoBitmap.Scales.ColdWarmLinear) :
                    PseudoBitmap.Scales.RotationLinear
                };
            }
        //実数と虚数モードの時
        else
            foreach (var (i, j, text) in new[] { (0, 0, "Ug real"), (0, 1, "Ug imag"), (1, 0, "U'g real"), (1, 1, "U'g imag") })
                pseudo[i][j] = new PseudoBitmap(images[i * 2 + j], width)
                {
                    MaxValue = max,
                    MinValue = min,
                    Tag = new ImageInfo(width, height, ImageResolution, mat, text),
                    Scale = comboBoxScaleColorScale.SelectedIndex == 0 ? PseudoBitmap.Scales.GrayLinear : PseudoBitmap.Scales.ColdWarmLinear
                };

        //チェック状況に応じて、削除
        if (!checkBoxPotentialUg.Checked)
            pseudo.RemoveAt(0);
        else if (!checkBoxPotentialUgPrime.Checked)
            pseudo.RemoveAt(1);

        if ((radioButtonPotentialModeRealAndImag.Checked && radioButtonPotentialShowReal.Checked) ||
            (radioButtonPotentialModeMagAndPhase.Checked && radioButtonPotentialShowMag.Checked))
            pseudo.ForEach(p => p.RemoveAt(1));
        else if ((radioButtonPotentialModeRealAndImag.Checked && radioButtonPotentialShowImag.Checked) ||
            (radioButtonPotentialModeMagAndPhase.Checked && radioButtonPotentialShowPhase.Checked))
            pseudo.ForEach(p => p.RemoveAt(0));

        //resultに格納して、ScalablePictureboxに転送
        var result = new PseudoBitmap[pseudo.Count, pseudo[0].Count];
        for (int r = 0; r < pseudo.Count; r++)
            for (int c = 0; c < pseudo[0].Count; c++)
                result[r, c] = pseudo[r][c];

        setPseudoBitamap(result);
        toolStripStatusLabel1.Text += $"Drawing: {sw1.ElapsedMilliseconds - temp} msec.";
        TrackBarAdvancedMin_ValueChanged(new object(), 0);
    }
    #endregion

    #region 計算結果をPictureBoxにセット

    /// <summary>
    /// PseudoBitmapを作成
    /// </summary>
    /// <param name="tLen"></param>
    /// <param name="dLen"></param>
    /// <param name="totalImage"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SendImage(int tLen, int dLen, double[][][] totalImage, int width, int height)
    {
        if (totalImage == null) return;
        //作成したイメージをPseudoBitmapに変換
        var pseudo = radioButtonHorizontalDefocus.Checked ? new PseudoBitmap[tLen, dLen] : new PseudoBitmap[dLen, tLen];
        var mat = FormMain.Crystal.RotationMatrix * FormMain.Crystal.MatrixReal;

        //全体でノーマライズ
        if (!checkBoxNormarizeIndividually.Checked)
            totalImage = Normalize(totalImage, checkBoxIntensityMin.Checked);//checkBoxNormalizeHigh.Checked, checkBoxNormalizeLow.Checked);

        for (int t = 0; t < tLen; t++)
            for (var d = 0; d < dLen; d++)
            {
                //個別にノーマライズ
                if (checkBoxNormarizeIndividually.Checked)
                    totalImage[t][d] = Normalize(totalImage[t][d], checkBoxIntensityMin.Checked);

                //PseudoBitmapを生成
                pseudo[radioButtonHorizontalDefocus.Checked ? t : d, radioButtonHorizontalDefocus.Checked ? d : t]
                = new PseudoBitmap(totalImage[t][d], width)
                {
                    Tag = new ImageInfo(width, height, ImageResolution, mat, $"t={ThicknessArray[t]}\r\nf={DefocusArray[d]}"),
                    MaxValue = trackBarAdvancedMax.Value,
                    MinValue = trackBarAdvancedMin.Value,
                    Scale = comboBoxScaleColorScale.SelectedIndex == 0 ? PseudoBitmap.Scales.GrayLinear : PseudoBitmap.Scales.ColdWarmLinear
                };
            }

        //1列あるいは1行で、他の要素が多いときは適当に折り返し
        if ((dLen == 1 && tLen > 2) || (tLen == 1 && dLen > 2))
        {
            var newCol = Ceiling(Sqrt(pseudo.Length));
            var newRow = Ceiling(pseudo.Length / newCol);
            var newPseudo = new PseudoBitmap[(int)newRow, (int)newCol];
            var oldPseudo = pseudo.Cast<PseudoBitmap>().ToList();
            for (int r = 0, n = 0; r < newRow; r++)
                for (int c = 0; c < newCol; c++, n++)
                    newPseudo[r, c] = n < pseudo.Length ? oldPseudo[n] : null;
            pseudo = newPseudo;
        }

        SkipEvent = true;
        trackBarAdvancedMax.Value = trackBarAdvancedMin.Maximum = trackBarAdvancedMax.Maximum = numericBoxIntensityMax.Value;
        trackBarAdvancedMin.Value = trackBarAdvancedMin.Minimum = trackBarAdvancedMax.Minimum = 0;
        trackBarAdvancedMax.UpDown_Increment = trackBarAdvancedMin.UpDown_Increment = (trackBarAdvancedMax.Value - trackBarAdvancedMin.Value) / 100.0;
        SkipEvent = false;

        //ScalableBoxに転送
        setPseudoBitamap(pseudo);

        TrackBarAdvancedMin_ValueChanged(new object(), 0);
    }

    #region normarize関数
    public double[] Normalize(double[] image, bool normalizeLow = true)
    {
        double min = image.Min(), max = image.Max();
        double destMin = numericBoxIntensityMin.Value, destMax = numericBoxIntensityMax.Value;

        return normalizeLow ?
            image.Select(d => (d - min) / (max - min) * (destMax - destMin) + destMin).ToArray() :
            image.Select(d => d * destMax / max).ToArray();
    }

    public double[][][] Normalize(double[][][] image, bool normalizeLow = true)
    {
        double min = image.Min(e1 => e1.Min(e2 => e2.Min())), max = image.Max(e1 => e1.Max(e2 => e2.Max()));
        double destMin = numericBoxIntensityMin.Value, destMax = numericBoxIntensityMax.Value;

        for (int i = 0; i < image.Length; i++)
            for (int j = 0; j < image[i].Length; j++)
            {
                if (normalizeLow)
                    image[i][j] = image[i][j].Select(d => (d - min) / (max - min) * (destMax - destMin) + destMin).ToArray();
                else
                    image[i][j] = image[i][j].Select(d => d * destMax / max).ToArray();
            }
        return image;
    }
    #endregion

    //作成したPseutoBitmapをscalablePictureBoxに転送
    private void setPseudoBitamap(PseudoBitmap[,] image)
    {
        var row = image.GetLength(0);
        var col = image.GetLength(1);

        if (pictureBoxes.GetLength(0) == row && pictureBoxes.GetLength(1) == col)
        {
            for (int r = 0; r < row; r++)
                for (int c = 0; c < col; c++)
                {
                    pictureBoxes[r, c].SkipEvent = true;
                    pictureBoxes[r, c].PseudoBitmap = image[r, c];
                    pictureBoxes[r, c].SkipEvent = false;
                }
        }
        else
        {
            tableLayoutPanel.SuspendLayout();
            pictureBoxes = new ScalablePictureBox[row, col];
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowCount = row;
            tableLayoutPanel.ColumnCount = col;
            Enumerable.Range(0, row).ToList().ForEach(r => tableLayoutPanel.RowStyles[r].Height = 1f);
            Enumerable.Range(0, col).ToList().ForEach(c => tableLayoutPanel.ColumnStyles[c].Width = 1f);

            for (int r = 0; r < row; r++)
                for (int c = 0; c < col; c++)
                {
                    pictureBoxes[r, c] = new ScalablePictureBox
                    {
                        SkipEvent = true,
                        Size = new Size(1, 1),
                        MouseScaling = true,
                        MouseTranslation = true,
                        PseudoBitmap = image[r, c],
                        ZoomAndCenter = (0, new PointD(0, 0))
                    };
                    tableLayoutPanel.Controls.Add(pictureBoxes[r, c], c, r);
                    pictureBoxes[r, c].Dock = DockStyle.Fill;
                    pictureBoxes[r, c].SkipEvent = false;

                    pictureBoxes[r, c].DrawingAreaChanged += PictureBox_DrawingAreaChanged;
                    pictureBoxes[r, c].Paint2 += PictureBox_Paint2;
                    pictureBoxes[r, c].MouseMove2 += FormImageSimulator_MouseMove2;
                    pictureBoxes[r, c].MouseDown2 += FormImageSimulator_MouseDown2;
                }
            tableLayoutPanel.ResumeLayout();
        }

        pictureBoxes[0, 0].ZoomAndCenter = (0, new PointD(0, 0));
    }
    #endregion

    #region マウス操作

    private bool FormImageSimulator_MouseMove2(object sender, MouseEventArgs e, PointD pt)
    {
        var pseud = (sender as ScalablePictureBox).PseudoBitmap;
        var info = pseud.Tag as ImageInfo;
        labelMousePositionX.Text = $"X: {(pt.X - info.Width / 2.0) * info.Resolution * 1000:f2} pm";
        labelMousePositionY.Text = $"Y: {(-pt.Y + info.Height / 2.0) * info.Resolution * 1000:f2} pm";
        labelMousePositionValue.Text = $"Value: {pseud.GetPixelRawValue(pt):g6}";
        return false;
    }
    private bool FormImageSimulator_MouseDown2(object sender, MouseEventArgs e, PointD pt)
    {
        if (e.Clicks == 2 && e.Button == MouseButtons.Left)
        {
            int rows = pictureBoxes.GetLength(0), cols = pictureBoxes.GetLength(1);
            if (rows == 1 && cols == 1)
                return false;

            for (int targetR = 0; targetR < rows; targetR++)
                for (int targetC = 0; targetC < cols; targetC++)
                    if ((sender as ScalablePictureBox) == pictureBoxes[targetR, targetC])//まずターゲットを見つける
                    {
                        List<int> rowsList = Enumerable.Range(0, rows).ToList(), colsList = Enumerable.Range(0, cols).ToList();

                        tableLayoutPanel.SuspendLayout();

                        SkipEvent = true;
                        //rowsList.ForEach(row => colsList.ForEach(cos => pictureBoxes[row, cos].SkipEvent = true));

                        if (tableLayoutPanel.RowStyles[targetR].Height == 100f)
                        {
                            rowsList.ForEach(row => tableLayoutPanel.RowStyles[row].Height = 1f);
                            colsList.ForEach(col => tableLayoutPanel.ColumnStyles[col].Width = 1f);
                            pictureBoxes[0, 0].ZoomAndCenter = (0, new PointD(0, 0));
                        }
                        else
                        {
                            rowsList.ForEach(row => tableLayoutPanel.RowStyles[row].Height = targetR == row ? 100f : 0f);
                            colsList.ForEach(col => tableLayoutPanel.ColumnStyles[col].Width = targetC == col ? 100f : 0f);
                        }

                        //rowsList.ForEach(row => colsList.ForEach(col => pictureBoxes[row, col].SkipEvent = false));
                        SkipEvent = false;

                        tableLayoutPanel.ResumeLayout();
                        return false;
                    }
        }
        return false;
    }
    #endregion

    #region 電子顕微鏡の各種光学パラメータや試料パラメータのイベント

    /// <summary>
    /// 電子顕微鏡の各種光学パラメータが変更されたとき。レンズ関数を描画
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxTEMproperty_ValueChanged(object sender, EventArgs e) => DrawLenzGraph();

    /// <summary>
    /// 加速電圧が変更されたとき。波長を変更、シェルツァーフォーカス変更、レンズ関数描画、ビームの個数計算
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxAccVol_ValueChanged(object sender, EventArgs e)
    {
        textBoxScherzer.Text = Scherzer.ToString("f1");
        DrawLenzGraph();
        CalculateInsideSpotInfo();
    }
    /// <summary>
    /// 球面収差が変更されたとき。シェルツァーフォーカス変更、レンズ関数描画
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxCs_ValueChanged(object sender, EventArgs e)
    {
        textBoxScherzer.Text = Scherzer.ToString("f1");
        DrawLenzGraph();
    }
    /// <summary>
    /// デフォーカスが変更されたとき。シリアルモードのデフォーカス開始値変更、レンズ関数描画
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxDefocus_ValueChanged(object sender, EventArgs e)
    {
        numericBoxDefocusStart.Value = numericBoxDefocus.Value;
        DrawLenzGraph();
    }
    /// <summary>
    /// 試料厚みが変更されたとき。シリアルモードの試料厚み開始値変更
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxThickness_ValueChanged(object sender, EventArgs e) => numericBoxThicknessStart.Value = numericBoxThickness.Value;

    /// <summary>
    /// 対物絞りの半径やシフトが変更されたとき。絞り半径のnm^-1換算値を設定、内側ビームの個数計算
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxObjAperRadius_ValueChanged(object sender, EventArgs e)
    {
        numericBoxObjAperRadius.Enabled = numericBoxObjAperX.Enabled = numericBoxObjAperY.Enabled = !checkBoxOpenAperture.Checked;

        textBoxApertureRadius.Text = checkBoxOpenAperture.Checked ? ObjAperRadius.ToString() : (2 * Math.Sin(ObjAperRadius / 2) / Rambda).ToString("f4");

        CalculateInsideSpotInfo();
    }

    /// <summary>
    /// シリアルモードの試料厚み、ステップ、個数が変更されたとき。厚みリストを変更
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxThicknessSerial_ValueChanged(object sender, EventArgs e)
    {
        textBoxThicknessList.Text = numericBoxThicknessStart.Value.ToString();
        for (int i = 1; i < numericBoxThicknessNum.ValueInteger; i++)
            textBoxThicknessList.Text += "\r\n" + (numericBoxThicknessStart.Value + numericBoxThicknessStep.Value * i).ToString();
    }
    /// <summary>
    /// シリアルモードのデフォーカス、ステップ、個数が変更されたとき。デフォーカスリストを変更
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxDefocusSerial_ValueChanged(object sender, EventArgs e)
    {
        textBoxDefocusList.Text = numericBoxDefocusStart.Value.ToString();
        for (int i = 1; i < numericBoxDefocusNum.ValueInteger; i++)
            textBoxDefocusList.Text += "\r\n" + (numericBoxDefocusStart.Value + numericBoxDefocusStep.Value * i).ToString();
    }
    /// <summary>
    /// ブロッホ波の個数が変更されたとき。FormDiffractionSimulator中のブロッホ波個数を変更、スポット情報更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NumericBoxNumOfBlochWave_ValueChanged(object sender, EventArgs e)
    {
        if (FormMain.FormDiffractionSimulator.Visible)
            FormMain.FormDiffractionSimulator.numericBoxNumOfBlochWave.Value = numericBoxNumOfBlochWave.Value;
        CalculateInsideSpotInfo();
    }

    /// <summary>
    /// 現在のパラメータに従って、対物絞り内のスポット情報を計算。SpotInfoのテーブルを更新。FormDiffractionSimulatorが表示されていれば更新
    /// </summary>
    public void CalculateInsideSpotInfo()
    {
        var beams = FormMain.Crystal.Bethe.Find_gVectors(FormMain.Crystal.RotationMatrix, new Vector3DBase(0, 0, 1 / Rambda), BlochNum);
        BeamsInside = BetheMethod.ExtractInsideBeams(beams, AccVol, ObjAperRadius, ObjAperX, ObjAperY);
        textBoxNumOfSpots.Text = BeamsInside.Length.ToString();

        if (FormDiffractionSpotInfo.Visible)
        {
            Beams = FormMain.Crystal.Bethe.GetDifractedBeamAmpriltudes(BlochNum, AccVol, FormMain.Crystal.RotationMatrix, ThicknessArray[0]);
            BeamsInside = BetheMethod.ExtractInsideBeams(Beams, AccVol, ObjAperRadius, ObjAperX, ObjAperY);
            FormDiffractionSpotInfo.SetTable(AccVol, BeamsInside);
        }

        if (FormMain.FormDiffractionSimulator.Visible)
            FormMain.FormDiffractionSimulator.Draw();
    }

    #endregion

    #region 他のフォームで結晶回転状態が変更されたとき
    public void RotationChanged()
    {
        if (checkBoxRealTimeSimulation.Checked)
        {
            if (ImageMode == ImageModes.HRTEM)
                SimulateHRTEM(true);
            else if (ImageMode == ImageModes.POTENTIAL)
                simulatePotential(true);
        }

        if (ImageMode == ImageModes.HRTEM)
            CalculateInsideSpotInfo();
    }
    #endregion

    #region スポット情報ボタン
    /// <summary>
    /// スポット情報ボタン
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonDetailsOfSpots_Click(object sender, EventArgs e)
    {
        FormDiffractionSpotInfo.SetTable(AccVol, BeamsInside);
        FormDiffractionSpotInfo.Visible = true;
    }
    #endregion

    #region レンズ関数描画関連
    private readonly Color colorKai = Color.Blue, colorEs = Color.Green, colorEc = Color.Red, colorAll = Color.FromArgb(128, 128, 0);
    /// <summary>
    /// レンズの各種関数のグラフを描画
    /// </summary>
    private void DrawLenzGraph()
    {
        checkBoxGraphPCTF.ForeColor = colorKai;
        checkBoxGraphEs.ForeColor = colorEs;
        checkBoxGraphEc.ForeColor = colorEc;
        checkBoxGraphAll.ForeColor = colorAll;
        double rambda = Rambda, rambda2 = rambda * rambda;

        List<PointD> kai = new(), es = new(), ec = new(), all = new();
        var delta = Cc * DeltaVol / AccVol;
        for (double u = 0; u < numericBoxMaxU1.Value; u += 0.01)
        {
            var u2 = u * u;
            kai.Add(new PointD(u, Sin(PI * Rambda * u2 * (Cs * rambda2 * u2 / 2.0 + Defocus))));//球面収差
            es.Add(new PointD(u, Exp(-Pi2 * Beta * Beta * u2 * (Defocus + rambda2 * Cs * u2) * (Defocus + rambda2 * Cs * u2))));//空間的インコヒーレンス
            ec.Add(new PointD(u, Exp(-Pi2 * rambda2 * delta * delta * u2 * u2 / 2/*16/Math.Log(2)*/)));//時間的インコヒーレンス
            all.Add(new PointD(u, kai[^1].Y * es[^1].Y * ec[^1].Y));
        }
        graphControl.ClearProfile();
        var profiles = new List<Profile>();
        if (checkBoxGraphPCTF.Checked) profiles.Add(new Profile(kai, colorKai));
        if (checkBoxGraphEs.Checked) profiles.Add(new Profile(es, colorEs));
        if (checkBoxGraphEc.Checked) profiles.Add(new Profile(ec, colorEc));
        if (checkBoxGraphAll.Checked) profiles.Add(new Profile(all, colorAll));
        graphControl.AddProfiles(profiles.ToArray());
    }
    /// <summary>
    /// グラフのコピーボタン。エクセルに張り付けられるように
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonCopyGraph_Click(object sender, EventArgs e)
    {
        var p = graphControl.ProfileList;
        if (p.Length > 0)
        {
            var sb = new StringBuilder();
            sb.Append("|u|");
            if (checkBoxGraphPCTF.Checked) sb.Append("\tSin[Kai(u)]");
            if (checkBoxGraphEs.Checked) sb.Append("\tEs(u)");
            if (checkBoxGraphEc.Checked) sb.Append("\tEc(u)");
            if (checkBoxGraphAll.Checked) sb.Append("\tProduct of all");
            sb.Append("\r\n");

            for (int i = 0; i < p[0].Pt.Count; i++)
            {
                sb.Append(p[0].Pt[i].X);
                for (int j = 0; j < p.Length; j++)
                    sb.Append($"\t{p[j].Pt[i].Y.ToString()}");
                sb.Append("\r\n");
            }
            Clipboard.SetDataObject(sb.ToString());
        }
    }
    #endregion

    #region チェックボックス On/Offやボタン押下イベントに伴うパネル類のEnabled, visible設定

    /// <summary>
    /// 連続画像モード関連のチェックボックス
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxSerialDefocus_CheckedChanged(object sender, EventArgs e)
    {
        panelSerial.Enabled = radioButtonSerialMode.Checked;

        panelSerialThickness.Enabled = checkBoxSerialThickness.Checked;
        panelSerialDefocus.Enabled = checkBoxSerialDefocus.Checked;
        flowLayoutPanelHorizontalDirection.Enabled = checkBoxSerialThickness.Checked && checkBoxSerialDefocus.Checked;

        groupBoxSampleProperty.Enabled = !(radioButtonSerialMode.Checked && checkBoxSerialThickness.Checked);
        numericBoxDefocus.Enabled = !(radioButtonSerialMode.Checked && checkBoxSerialDefocus.Checked);
    }

    private void CheckBoxShowLabel_CheckedChanged(object sender, EventArgs e)
    {
        flowLayoutPanelLabel.Enabled = checkBoxShowLabel.Checked;
        flowLayoutPanelScale.Enabled = checkBoxShowScale.Checked;

        foreach (var box in pictureBoxes)
            box.Refresh();
    }

    private void RadioButtonHRTEM_CheckedChanged(object sender, EventArgs e)
    {
        this.SuspendLayout();
        numericBoxDefocus.Enabled = ImageMode != ImageModes.POTENTIAL;

        numericBoxBetaAgnle.Enabled = ImageMode == ImageModes.HRTEM;

        numericBoxCs.Enabled = numericBoxCc.Enabled = numericBoxDeltaV.Enabled =
        groupBoxSampleProperty.Visible = groupBoxNormalization.Visible
               = groupBoxSerialImage.Visible = panelLenz.Visible = ImageMode != ImageModes.POTENTIAL;

        checkBoxRealTimeSimulation.Visible = ImageMode != ImageModes.STEM;

        groupBoxPotentialOption.Visible = ImageMode == ImageModes.POTENTIAL;
        groupBoxHREMoption1.Visible = groupBoxHREMoption2.Visible = ImageMode == ImageModes.HRTEM;
        groupBoxSTEMoption1.Visible = groupBoxSTEMoption2.Visible = ImageMode == ImageModes.STEM;
        this.ResumeLayout(true);
    }

    private void ButtonPanel_Click(object sender, EventArgs e)
    {
        if (panelGraphOption.Visible)
            buttonPanel.Text = ">\r\n>\r\n>\r\n>\r\n>\r\n>\r\n>\r\n>\r\n>\r\n>";
        else
            buttonPanel.Text = "<\r\n<\r\n<\r\n<\r\n<\r\n<\r\n<\r\n<\r\n<\r\n<>";
        panelGraphOption.Visible = !panelGraphOption.Visible;
    }


    #endregion

    #region 画像の描画、コピー/保存関連

    private void PictureBox_Paint2(object sender, PaintEventArgs e)
    {
        var box = sender as ScalablePictureBox;
        if (box.PseudoBitmap != null && box.PseudoBitmap.Tag != null && box.PseudoBitmap.Tag is ImageInfo info)
        {
            var conv = new Func<PointD, PointD>(src => box.ConvertToClientPt(src));
            var zoom = box.Zoom;
            drawSymbols(e.Graphics, conv, zoom, info);
        }
    }

    private void drawSymbols(Graphics g, Func<PointD, PointD> conv, double zoom, ImageInfo imageInfo, bool merge = false)
    {
        var reso = imageInfo.Resolution;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //ユニットセル
        if (checkBoxShowUnitcell.Checked)
        {
            Pen penA = new(Color.Red, 1), penB = new(Color.Green, 1), penC = new(Color.Blue, 1);
            var zero = new PointD(0, 0);
            var a = new PointD(imageInfo.A.X, -imageInfo.A.Y) / reso * zoom;
            var b = new PointD(imageInfo.B.X, -imageInfo.B.Y) / reso * zoom;
            var c = new PointD(imageInfo.C.X, -imageInfo.C.Y) / reso * zoom;

            var ptOrigin = conv(new PointD(0.5 * imageInfo.Width, 0.5 * imageInfo.Height)) - (a + b + c) / 2;

            foreach (var t in new[] { zero, b, c, b + c })
                g.DrawLine(penA, (ptOrigin + t).ToPointF(), (ptOrigin + t + a).ToPointF());

            foreach (var t in new[] { zero, c, a, c + a })
                g.DrawLine(penB, (ptOrigin + t).ToPointF(), (ptOrigin + t + b).ToPointF());

            foreach (var t in new[] { zero, a, b, a + b })
                g.DrawLine(penC, (ptOrigin + t).ToPointF(), (ptOrigin + t + c).ToPointF());
        }

        //ラベル
        if (checkBoxShowLabel.Checked)
        {
            var font = new Font("Segoe UI Symbol", (float)numericBoxLabelFontSize.Value);
            var sb = new SolidBrush(colorControlLabel.Color);
            g.DrawString(imageInfo.Text, font, sb, merge ? conv(new PointD(4, 8)).ToPointF() : new PointF(4f, 8f));
        }

        //スケールバー

        if (checkBoxShowScale.Checked)
        {
            var pen = new Pen(colorControlScale.Color, 3);
            var pt1 = merge ? conv(new PointD(4, 4)) : new PointD(4f, 4f);
            var pt2 = new PointD(pt1.X + numericBoxScaleLength.Value / reso * zoom, pt1.Y);
            g.DrawLine(pen, (float)pt1.X, (float)pt1.Y, (float)pt2.X, (float)pt2.Y);
        }


    }

    private enum formatEnum { Meta, PNG, TIFF }
    private enum actionEnum { Save, Copy }
    private void Save(formatEnum format, actionEnum action)
    {

        if (pictureBoxes != null && pictureBoxes.Length != 0)
        {
            int row = pictureBoxes.GetLength(0), col = pictureBoxes.GetLength(1);
            var pseudo = new PseudoBitmap[row, col];
            for (int r = 0; r < row; r++)
                for (int c = 0; c < col; c++)
                    pseudo[r, c] = pictureBoxes[r, c].PseudoBitmap;
            int width = pseudo[0, 0].Width, height = pseudo[0, 0].Height;

            //イメージを生成するAction. RとCが無効の場合は全画像、有効な場合は1枚画像
            var draw = new Action<Graphics, PseudoBitmap>((g, p) =>
            {
                if (p != null)
                {
                    g.DrawImage(p.GetImage(), new Point(0, 0));
                    if (toolStripMenuItemOverprintSymbols.Checked)
                        drawSymbols(g, new Func<PointD, PointD>(pt => pt), 1, (ImageInfo)p.Tag);
                }
                else
                {
                    for (int r = 0; r < row; r++)
                        for (int c = 0; c < col; c++)
                        {
                            if (pseudo[r, c].Width != 0)
                            {
                                g.DrawImage(pseudo[r, c].GetImage(), new Point(c * width, r * height));
                                if (toolStripMenuItemOverprintSymbols.Checked)
                                    drawSymbols(g, new Func<PointD, PointD>(pt => pt + new PointD(c * width, r * height)),
                                        1, (ImageInfo)pseudo[r, c].Tag, true);
                            }
                        }
                }
            });

            //メタファイルをセーブしたりコピーしたりするときのアクション
            var actionForMetafile = new Action<PseudoBitmap, string>((p, filename) =>
            {
                var grfx = CreateGraphics();
                var ipHdc = grfx.GetHdc();
                var ms = new MemoryStream();
                var mf = new Metafile(ms, ipHdc, EmfType.EmfPlusDual);
                grfx.ReleaseHdc(ipHdc);
                grfx.Dispose();
                var g = Graphics.FromImage(mf);

                draw(g, p);

                g.Dispose();

                if (filename.Length == 0)//finenameが""の時はコピー
                    ClipboardMetafileHelper.PutEnhMetafileOnClipboard(this.Handle, mf);
                else
                    using (var fsm = new FileStream(filename, FileMode.Create, FileAccess.Write))
                        fsm.Write(ms.GetBuffer(), 0, (int)ms.Length);
            });

            //ここから、実際の処理

            //先にファイルダイアログの処理をしてしまう
            var dlg = new SaveFileDialog { Filter = format switch { formatEnum.Meta => "*.emf|*.emf", formatEnum.PNG => "*.png|*.png", _ => "*.tif|*.tif" } };
            if (action == actionEnum.Save)
                if (dlg.ShowDialog() != DialogResult.OK) return;

            //メタファイル形式の時
            if (format == formatEnum.Meta)
            {
                //個別保存の時
                if (action == actionEnum.Save && pseudo.Length > 1 && toolStripMenuItemSaveIndividually.Checked)//Save
                {
                    for (int r = 0; r < row; r++)
                        for (int c = 0; c < col; c++)
                            if (pseudo[r, c].Width != 0)
                            {
                                var text = (pseudo[r, c].Tag as ImageInfo).Text.Replace("\r\n", ", ");
                                var fileName = dlg.FileName.Replace(".emf", " (" + text + ").emf");
                                actionForMetafile(pseudo[r, c], fileName);
                            }
                }
                else//全体保存 or 全体コピー
                {
                    if (action == actionEnum.Save)
                        actionForMetafile(null, dlg.FileName);
                    else
                        actionForMetafile(null, "");//filename を "" にすると、コピー
                }
            }
            //Png形式の時
            else if (format == formatEnum.PNG)
            {
                //個別保存の時
                if (action == actionEnum.Save && pseudo.Length > 1 && toolStripMenuItemSaveIndividually.Checked)//Save
                {
                    for (int r = 0; r < row; r++)
                        for (int c = 0; c < col; c++)
                            if (pseudo[r, c].Width != 0)
                            {
                                var bmp = new Bitmap(width, height);
                                draw(Graphics.FromImage(bmp), pseudo[r, c]);
                                var text = (pseudo[r, c].Tag as ImageInfo).Text.Replace("\r\n", ", ");
                                bmp.Save(dlg.FileName.Replace(".png", " (" + text + ").png"), ImageFormat.Png);
                            }
                }
                else//全体保存 or 全体コピー
                {
                    var bmp = new Bitmap(col * width, row * height);
                    draw(Graphics.FromImage(bmp), null);
                    if (action == actionEnum.Save)
                        bmp.Save(dlg.FileName, ImageFormat.Png);
                    else
                        Clipboard.SetDataObject(bmp);
                }
            }
            else if (format == formatEnum.TIFF)//Tiff形式 個別保存のみ
            {
                for (int r = 0; r < row; r++)
                    for (int c = 0; c < col; c++)
                        if (pseudo[r, c].Width != 0)
                        {
                            var text = (pseudo[r, c].Tag as ImageInfo).Text.Replace("\r\n", ", ");
                            var filename = pseudo.Length == 1 ? dlg.FileName : dlg.FileName.Replace(".tif", " (" + text + ").tif");
                            Tiff.Writer(filename, pseudo[r, c].SrcValuesGray, 3, width);
                        }
            }
        }
    }

    bool tableLayoutPanelFocused = false;
    private void tableLayoutPanel_Enter(object sender, EventArgs e) => tableLayoutPanelFocused = true;

    private void tableLayoutPanel_Leave(object sender, EventArgs e) => tableLayoutPanelFocused = false;

    private void FormImageSimulator_KeyDown(object sender, KeyEventArgs e)
    {
        if (tableLayoutPanelFocused && e.Control && e.KeyCode == Keys.C)
            ToolStripMenuItemCopyMetafile_Click(sender, new EventArgs());
    }
    private void ToolStripMenuItemSavePNG_Click(object sender, EventArgs e) => Save(formatEnum.PNG, actionEnum.Save);
    private void ToolStripMenuItemSaveTIFF_Click(object sender, EventArgs e) => Save(formatEnum.TIFF, actionEnum.Save);
    private void ToolStripMenuItemSaveMetafile_Click(object sender, EventArgs e) => Save(formatEnum.Meta, actionEnum.Save);



    private void ToolStripMenuItemCopyImage_Click(object sender, EventArgs e) => Save(formatEnum.PNG, actionEnum.Copy);
    private void ToolStripMenuItemCopyMetafile_Click(object sender, EventArgs e) => Save(formatEnum.Meta, actionEnum.Copy);
    #endregion 画像のコピー/保存

    #region その他イベント
    private void DetailsOfHRTEMSimulationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        new FormPDF(appPath + @"\doc\hrtem.pdf").ShowDialog();
    }


    private void PictureBox_DrawingAreaChanged(object sender, double zoom, PointD center)
    {
        if (SkipEvent) return;

        var box = sender as ScalablePictureBox;
        if (box.PseudoBitmap.Width == 0)
            return;

        foreach (var b in pictureBoxes)
            if (b != null && b != (ScalablePictureBox)sender)
            {
                b.DrawingAreaChanged -= PictureBox_DrawingAreaChanged;
                b.ZoomAndCenter = (zoom, center);
                b.DrawingAreaChanged += PictureBox_DrawingAreaChanged;
            }
    }
    #endregion

    #region 画像の輝度、カラースケール、ガウシアンぼかし

    public bool SkipEvent = false;

    private void RadioButtonPotentialAsMagnitudeAndPhase_CheckedChanged(object sender, EventArgs e)
    {
        flowLayoutPanelMagAndPhase.Visible = panelPhaseScale.Visible = radioButtonPotentialModeMagAndPhase.Checked;
        flowLayoutPanelRealAndImaiginary.Visible = radioButtonPotentialModeRealAndImag.Checked;
    }

    private void checkBoxIntensityMin_CheckedChanged(object sender, EventArgs e) => numericBoxIntensityMin.Enabled = checkBoxIntensityMin.Checked;

    private void checkBoxShowLensFunctionGraph_CheckedChanged(object sender, EventArgs e)
    {
        groupBoxLensFunction.Visible = checkBoxShowLensFunctionGraph.Checked;
    }

    private bool TrackBarAdvancedMin_ValueChanged(object sender, double value)
    {
        if (SkipEvent) return false;
        foreach (var box in pictureBoxes)
            if (box.PseudoBitmap.Tag != null && !(box.PseudoBitmap.Tag as ImageInfo).LockIntensity)
            {
                box.PseudoBitmap.MaxValue = trackBarAdvancedMax.Value;
                box.PseudoBitmap.MinValue = trackBarAdvancedMin.Value;
                box.drawPictureBox();
            }
        return false;
    }

    private void ComboBoxScaleColorScale_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SkipEvent) return;

        if (comboBoxScaleColorScale.SelectedIndex == 0)
            scaleImage.SetScaleGray();

        else
            scaleImage.SetScaleColdWarm();
        pictureBoxScaleOfIntensity.Image = scaleImage.GetImage();

        foreach (var box in pictureBoxes)
            if (box.PseudoBitmap.Tag != null && !(box.PseudoBitmap.Tag as ImageInfo).LockIntensity)
            {
                if (comboBoxScaleColorScale.SelectedIndex == 0)
                    box.PseudoBitmap.SetScaleGray();
                else
                    box.PseudoBitmap.SetScaleColdWarm();
                box.drawPictureBox();
            }
    }

    private void CheckBoxGaussianBlur_CheckedChanged(object sender, EventArgs e)
    {
        if (SkipEvent) return;

        numericBoxGaussianBlurRadius.Visible = checkBoxGaussianBlur.Checked;

        foreach (var box in pictureBoxes)
            if (box.PseudoBitmap.Tag != null && !(box.PseudoBitmap.Tag as ImageInfo).LockIntensity)
            {
                if (checkBoxGaussianBlur.Checked)
                    box.PseudoBitmap.SetBlurImage(numericBoxGaussianBlurRadius.Value / numericBoxResolution.Value, PseudoBitmap.BlurModeEnum.Gaussian);
                else
                    box.PseudoBitmap.SetOriginalGray();

                box.drawPictureBox();
            }
    }
    #endregion 画像の輝度、カラースケール、ガウシアンぼかし

    #region 右クリックメニュー
    private void setoZeroDefocusToolStripMenuItem_Click(object sender, EventArgs e)
    {
        numericBoxDefocus.Value = 0;
    }

    private void setoScherzerDefocusToolStripMenuItem_Click(object sender, EventArgs e)
    {
        numericBoxDefocus.Value = Scherzer;
    }

    private void zeroAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
        numericBoxCc.Value = numericBoxCs.Value = numericBoxBetaAgnle.Value = numericBoxDeltaV.Value = numericBoxDefocus.Value = 0;
    }

    private void presets1ToolStripMenuItem_Click(object sender, EventArgs e)
    {//ARM300F
        AccVol = 300;
        Cs = 0 * 1000000;
        Cc = 2.8 * 1000000;
        DeltaVol = 0.3 / 1000 / 2 / Sqrt(2 * Log(2));
        Defocus = Scherzer;

    }

    private void presets2ToolStripMenuItem_Click(object sender, EventArgs e)
    {//Schottky JEM2100F UHR
        AccVol = 200;
        Cs = 0.5 * 1000000;
        Cc = 1.1 * 1000000;
        DeltaVol = 0.8 / 1000 / 2 / Sqrt(2 * Log(2));
        Defocus = Scherzer;
    }

    private void presets3ToolStripMenuItem_Click(object sender, EventArgs e)
    {//Schottky JEM2100F HR
        AccVol = 200;
        Cs = 1.0 * 1000000;
        Cc = 1.4 * 1000000;
        DeltaVol = 0.8 / 1000 / 2 / Sqrt(2 * Log(2));
        Defocus = Scherzer;
    }

    private void presets4ToolStripMenuItem_Click(object sender, EventArgs e)
    {//LAB6 JEM2010 HR
        AccVol = 200;
        Cs = 1.0 * 1000000;
        Cc = 1.4 * 1000000;
        DeltaVol = 2.0 / 1000 / 2 / Sqrt(2 * Log(2));
        Defocus = Scherzer;
    }


    private void typicalBF02MradToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ConvergenceAngle = 25.0 / 1000;
        DetectorInnerAngle = 0;
        DetectorOuterAngle = 5.0 / 1000;
    }

    private void typicalABF1224MradToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ConvergenceAngle = 25.0 / 1000;
        DetectorInnerAngle = 12.0 / 1000;
        DetectorOuterAngle = 24.0 / 1000;
    }

    private void typicalLAADF2560MradToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ConvergenceAngle = 25.0 / 1000;
        DetectorInnerAngle = 26.0 / 1000;
        DetectorOuterAngle = 60.0 / 1000;
    }

    private void typicalHAADF80250MradToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ConvergenceAngle = 25.0 / 1000;
        DetectorInnerAngle = 80.0 / 1000;
        DetectorOuterAngle = 250.0 / 1000;

    }

    #endregion

    private void buttonPreset_Click(object sender, EventArgs e)
    {
        formPresets.ShowDialog();
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {

    }
}