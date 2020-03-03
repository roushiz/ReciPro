using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Xml.Serialization;

namespace Crystallography
{
    /// <summary>
    /// Crystal �̊T�v�̐����ł��B
    /// </summary>
    [Serializable()]
    public class Crystal : IEquatable<Crystal>, ICloneable, IComparable<Crystal>
    {
        public object Clone()
        {
            Crystal crystal = (Crystal)this.MemberwiseClone();
            crystal.Atoms = new Atoms[Atoms.Length];
            for (int i = 0; i < Atoms.Length; i++)
                crystal.Atoms[i] = (Atoms)Atoms[i].Clone();
            //crystal.EOSCondition = this.EOSCondition.Clone();
            crystal.ElasticStiffnessArray = this.ElasticStiffnessArray;

            return crystal;
        }

        public double Residual = 0;

        public int CompareTo(Crystal o) => Residual.CompareTo(o.Residual);

        public bool Equals(Crystal o)
        {
            if (A == o.A && B == o.B && C == o.C && Alpha == o.Alpha && Beta == o.Beta && Gamma == o.Gamma &&
                   SymmetrySeriesNumber == o.SymmetrySeriesNumber && Name == o.Name && JournalName == o.JournalName && PublSectionTitle == o.PublSectionTitle && JournalName == o.JournalName && ChemicalFormulaSum == o.ChemicalFormulaSum
                   && Density == o.Density)
                if (Atoms.Length == o.Atoms.Length)
                    for (int l = 0; l < Atoms.Length; l++)
                        if (Atoms[l].X == o.Atoms[l].X && Atoms[l].Y == o.Atoms[l].Y && Atoms[l].Z == o.Atoms[l].Z &&
                            Atoms[l].Occ == o.Atoms[l].Occ && Atoms[l].Label == o.Atoms[l].Label && Atoms[l].SubNumberElectron == o.Atoms[l].SubNumberElectron)
                            return true;
            return false;
        }

        #region �v���p�e�B�A�t�B�[���h

        public List<Bound> Bounds;

        public List<Bound> LatticePlanes;

        [NonSerialized]
        [XmlIgnore]
        public bool FlexibleMode = false;

        /// <summary>
        ///
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Plane> Plane;

        /// <summary>
        /// ���x�N�g���z��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfAxis = new List<Vector3D>();

        /// <summary>
        /// �ʃx�N�g���z��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfPlane = new List<Vector3D>();

        /// <summary>
        /// �t�i�q�_�x�N�g�� (kinematical)
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfG = new List<Vector3D>();

        /// <summary>
        /// �e�r���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfG_KikuchiLine = new List<Vector3D>();

        /// <summary>
        /// �Ƀx�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfPole = new List<Vector3D>();

        /// <summary>
        /// �x�[�e�@�ɂ�铮�͊w��܂�񋟂���t�B�[���h
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public BetheMethod Bethe;

        //public int planeMax;
        [NonSerialized]
        [XmlIgnore]
        public double DiffractionPeakIntensity = -1;

        public double A, B, C, Alpha, Beta, Gamma;	//�i�q�萔
        public double A_err, B_err, C_err, Alpha_err, Beta_err, Gamma_err;  //�i�q�萔�̌덷

        [NonSerialized]
        [XmlIgnore]
        public double InitialA, InitialB, InitialC, InitialAlpha, InitialBeta, InitialGamma;    //�i�q�萔

        [NonSerialized]
        [XmlIgnore]
        public double InitialA_err, InitialB_err, InitialC_err, InitialAlpha_err, InitialBeta_err, InitialGamma_err;    //�i�q�萔�̌덷

        [NonSerialized]
        [XmlIgnore]
        public double CellVolumeSqure;

        [NonSerialized]
        [XmlIgnore]
        private double sigma11, sigma22, sigma33, sigma23, sigma31, sigma12;

        /// <summary>
        /// �P�ʊi�q�̐�(nm^3)
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public double Volume, Volume_err;

        /// <summary>
        /// a���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D A_Axis;

        /// <summary>
        /// b���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D B_Axis;

        /// <summary>
        /// c���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D C_Axis;

        /// <summary>
        /// a*���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D A_Star;

        /// <summary>
        /// b*���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D B_Star;

        /// <summary>
        /// c*���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D C_Star;

        public Matrix3D RotationMatrix = new Matrix3D();

        //public Color color;
        public int Argb;

        public bool Reserved = false;//�ی삳��錋���ł��邩�ǂ���

        [NonSerialized]
        [XmlIgnore]
        public double Consistency, VolumeRatio, WeightRatio, MolRatio;//fittingForm�̂Ƃ���Ŏg�p

        [NonSerialized]
        [XmlIgnore]
        public double WeightPerFormula;

        [NonSerialized]
        [XmlIgnore]
        public double Density, Density_err;//���x

        public string Name = "";
        public string Note = "";

        public string PublAuthorName = "";

        public string PublSectionTitle = "";

        public int SymmetrySeriesNumber = 0;

        public string Journal;//�ׂ����������Ȃ��ꍇ����������B��������Ƃ��͈ȉ����g���B
        public string JournalName = "";
        public string JournalVolume = "";
        public string JournalIssue = "";
        public string JournalYear = "";
        public string JournalPageFirst = "";
        public string JournalPageLast = "";

        [NonSerialized]
        [XmlIgnore]
        public string ChemicalFormulaSum = "";//�v�Z�\�ȏꍇ�́B

        [NonSerialized]
        [XmlIgnore]
        public string ChemicalFormulaStructural = "";

        [NonSerialized]
        [XmlIgnore]
        public int ChemicalFormulaZ;

        /// <summary>
        /// ���f���z��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public string[] ElementName;

        /// <summary>
        /// ���f�ԍ��z��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public double[] ElementNum;

        /// <summary>
        /// �Ώ̐�
        /// </summary>
        [XmlIgnore]
        public Symmetry Symmetry = new Symmetry();

        /// <summary>
        /// �t�i�q�s�� (1�s�ڂ�a*, 2�s�ڂ�b*, 3�s�ڂɂ�*)
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Matrix3D MatrixInverse = new Matrix3D();

        /// <summary>
        /// ���i�q�s�� (1��ڂ�a, 2��ڂ�b, 3��ڂɂ�)
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Matrix3D MatrixReal = new Matrix3D();

        /// <summary>
        /// ���q�̏�����舵��Atoms�N���X�̔z��
        /// </summary>
        public Atoms[] Atoms = new Atoms[0];

        /// <summary>
        /// �����̏�����舵��Bond�N���X�̔z��
        /// </summary>
        public List<Bonds> Bonds = new List<Bonds>();

        /// <summary>
        /// �i�q�c�݃e���\��
        /// </summary>
        public Matrix3D Strain = new Matrix3D(0, 0, 0, 0, 0, 0, 0, 0, 0);

        /// <summary>
        /// ���̓e���\��
        /// </summary>
        public Matrix3D Stress = new Matrix3D(0, 0, 0, 0, 0, 0, 0, 0, 0);

        /// <summary>
        /// �q���萔
        /// </summary>
        public double HillCoefficient = 0;

        /// <summary>
        /// �e���萔 (�ۑ��p)
        /// </summary>
        public double[] ElasticStiffnessArray = new double[21];

        /// <summary>
        /// �e���萔�}�g���b�N�X
        /// </summary>
        [XmlIgnore]
        public double[,] ElasticStiffness
        {
            set
            {
                ElasticStiffnessArray = new double[]{
                 value[0, 0],value[0, 1], value[0, 2] ,value[0, 3] , value[0, 4] ,value[0, 5] ,
                 value[1, 1], value[1, 2] ,value[1, 3] , value[1, 4] ,value[1, 5] ,
                 value[2, 2] ,value[2, 3] , value[2, 4] ,value[2, 5] ,
                 value[3, 3] , value[3, 4] ,value[3, 5] ,
                 value[4, 4] ,value[4, 5] ,
                  value[5, 5]
                };
            }
            get
            {
                var mtx = new double[6, 6];
                mtx[0, 0] = ElasticStiffnessArray[0];
                mtx[0, 1] = mtx[1, 0] = ElasticStiffnessArray[1];
                mtx[0, 2] = mtx[2, 0] = ElasticStiffnessArray[2];
                mtx[0, 3] = mtx[3, 0] = ElasticStiffnessArray[3];
                mtx[0, 4] = mtx[4, 0] = ElasticStiffnessArray[4];
                mtx[0, 5] = mtx[5, 0] = ElasticStiffnessArray[5];
                mtx[1, 1] = ElasticStiffnessArray[6];
                mtx[1, 2] = mtx[2, 1] = ElasticStiffnessArray[7];
                mtx[1, 3] = mtx[3, 1] = ElasticStiffnessArray[8];
                mtx[1, 4] = mtx[4, 1] = ElasticStiffnessArray[9];
                mtx[1, 5] = mtx[5, 1] = ElasticStiffnessArray[10];
                mtx[2, 2] = ElasticStiffnessArray[11];
                mtx[2, 3] = mtx[3, 2] = ElasticStiffnessArray[12];
                mtx[2, 4] = mtx[4, 2] = ElasticStiffnessArray[13];
                mtx[2, 5] = mtx[5, 2] = ElasticStiffnessArray[14];
                mtx[3, 3] = ElasticStiffnessArray[15];
                mtx[3, 4] = mtx[4, 3] = ElasticStiffnessArray[16];
                mtx[3, 5] = mtx[5, 3] = ElasticStiffnessArray[17];
                mtx[4, 4] = ElasticStiffnessArray[18];
                mtx[4, 5] = mtx[5, 4] = ElasticStiffnessArray[19];
                mtx[5, 5] = ElasticStiffnessArray[20];
                return mtx;
            }
        }

        /// <summary>
        /// EOS�̃p�����[�^
        /// </summary>
        public EOS EOSCondition = new EOS();

        /// <summary>
        /// EOS�𗘗p���邩�ǂ���
        /// </summary>
        public bool DoesUseEOS = false;

        /// <summary>
        /// ���ʂƃT�C�Y��ێ�����Crystallite�N���X�z�� (�������̌v�Z���ɗp����)
        /// </summary>
       //[NonSerialized] [XmlIgnore]
        public Crystallite Crystallites;

        public double AngleResolution = 2;
        public int SubDivision = 4;

        /// <summary>
        /// �����q�̃T�C�Y (�P��:nm)
        /// </summary>
        public double GrainSize = 100;

        public int id = 0;

        #endregion �v���p�e�B�A�t�B�[���h

        #region �R���X�g���N�^

        public Crystal()
        {
            Symmetry = SymmetryStatic.Get_Symmetry(0);
            Plane = new List<Plane>();
            Atoms = new Atoms[0];
            ElasticStiffnessArray = new double[21];

            Bethe = new BetheMethod(this);

            A = B = C = Alpha = Beta = Gamma = 0;
            Name = "";
            Argb = Color.Black.ToArgb();
        }

        public Crystal(double a, double b, double c, double alpha, double beta, double gamma, int symmetrySeriesNumber, String name, String note, Color col)
            : this()
        {
            this.A = a; this.B = b; this.C = c; this.Alpha = alpha; this.Beta = beta; this.Gamma = gamma;
            Name = name;
            Note = note;
            Argb = col.ToArgb();
            SetAxis();
            SymmetrySeriesNumber = symmetrySeriesNumber;
            Symmetry = SymmetryStatic.Get_Symmetry(SymmetrySeriesNumber);
        }

        public Crystal(double a, double b, double c, double alpha, double beta, double gamma, double a_err, double b_err, double c_err, double alpha_err, double beta_err, double gamma_err,
           int symmetrySeriesNumber, String name, String note, Color col)
            : this(a, b, c, alpha, beta, gamma, symmetrySeriesNumber, name, note, col)
        {
            this.A_err = a_err; this.B_err = b_err; this.C_err = c_err; this.Alpha_err = alpha_err; this.Beta_err = beta_err; this.Gamma_err = gamma_err;
        }

        public Crystal(double a, double b, double c, double alpha, double beta, double gamma, int symmetrySeriesNumber, String name, String note, Color col,
            Atoms[] atoms, string authorName, string journal, string publishedSectionTitle, List<Bonds> bonds)
            : this(a, b, c, alpha, beta, gamma, symmetrySeriesNumber, name, note, col)
        {
            Atoms = atoms;
            PublAuthorName = authorName;
            Journal = journal;
            PublSectionTitle = publishedSectionTitle;
            GetFormulaAndDensity();
            Bonds = bonds;
        }

        public Crystal(double a, double b, double c, double alpha, double beta, double gamma, double a_err, double b_err, double c_err, double alpha_err, double beta_err, double gamma_err,
            int symmetrySeriesNumber, String name, String note, Color col,
            Atoms[] atoms, string authorName, string journal, string publishedSectionTitle, List<Bonds> bonds)
            : this(a, b, c, alpha, beta, gamma, symmetrySeriesNumber, name, note, col, atoms, authorName, journal, publishedSectionTitle, bonds)
        {
            this.A_err = a_err; this.B_err = b_err; this.C_err = c_err; this.Alpha_err = alpha_err; this.Beta_err = beta_err; this.Gamma_err = gamma_err;
        }

        public Crystal(Crystal cry)
        {
            this.A = cry.A; this.B = cry.B; this.C = cry.C; this.Alpha = cry.Alpha; this.Beta = cry.Beta; this.Gamma = cry.Gamma;
            this.A_err = cry.A_err; this.B_err = cry.B_err; this.C_err = cry.C_err; this.Alpha_err = cry.Alpha_err; this.Beta_err = cry.Beta_err; this.Gamma_err = cry.Gamma_err;
            Name = cry.Name; Note = cry.Note; /*color = col;*/ Argb = cry.Argb;
            SetAxis();

            SymmetrySeriesNumber = cry.SymmetrySeriesNumber;
            Symmetry = SymmetryStatic.Get_Symmetry(SymmetrySeriesNumber);

            Atoms = cry.Atoms;

            PublAuthorName = cry.PublAuthorName;
            Journal = cry.Journal;
            PublSectionTitle = cry.PublSectionTitle;

            GetFormulaAndDensity();

            Bonds = cry.Bonds;

            ElasticStiffnessArray = cry.ElasticStiffnessArray;
        }

        #endregion �R���X�g���N�^

        /// <summary>
        /// Crystal2�N���X�ɕϊ����܂��B
        /// </summary>
        public Crystal2 ToCrystal2()
        {
            return Crystal2.GetCrystal2(this);
        }

        /// <summary>
        /// �i�q�萔����A�e���̃x�N�g����⏕�萔(sigma�Ȃ�)��ݒ肷��
        /// </summary>
        public void SetAxis()
        {
            double SinAlfa = Math.Sin(Alpha); double SinBeta = Math.Sin(Beta); double SinGamma = Math.Sin(Gamma);
            double CosAlfa = Math.Cos(Alpha); double CosBeta = Math.Cos(Beta); double CosGamma = Math.Cos(Gamma);
            double a2 = A * A; double b2 = B * B; var c2 = C * C;

            C_Axis = new Vector3D(0, 0, C);
            B_Axis = new Vector3D(0, B * SinAlfa, B * CosAlfa);
            A_Axis = new Vector3D(
            A * Math.Sqrt(1 - CosBeta * CosBeta - (CosGamma - CosAlfa * CosBeta) * (CosGamma - CosAlfa * CosBeta) / SinAlfa / SinAlfa),
            A * (CosGamma - CosAlfa * CosBeta) / SinAlfa,
            A * CosBeta);

            
            MatrixReal = new Matrix3D(A_Axis, B_Axis, C_Axis);
            MatrixInverse = Matrix3D.Inverse(MatrixReal);

            A_Star = new Vector3D(MatrixInverse.E11, MatrixInverse.E12, MatrixInverse.E13);
            B_Star = new Vector3D(MatrixInverse.E21, MatrixInverse.E22, MatrixInverse.E23);
            C_Star = new Vector3D(MatrixInverse.E31, MatrixInverse.E32, MatrixInverse.E33);

            sigma11 = b2 * c2 * SinAlfa * SinAlfa;
            sigma22 = c2 * a2 * SinBeta * SinBeta;
            sigma33 = a2 * b2 * SinGamma * SinGamma;
            sigma23 = a2 * B * C * (CosBeta * CosGamma - CosAlfa);
            sigma31 = A * b2 * C * (CosGamma * CosAlfa - CosBeta);
            sigma12 = A * B * c2 * (CosAlfa * CosBeta - CosGamma);
            CellVolumeSqure = a2 * b2 * c2 * (1 - CosAlfa * CosAlfa - CosBeta * CosBeta - CosGamma * CosGamma + 2 * CosAlfa * CosBeta * CosGamma);
            Volume = Math.Sqrt(CellVolumeSqure);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        #region �����􉽊w�֘A

        /// <summary>
        /// (h,k,l)�ʂ̖ʊԊu���v�Z���܂�
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public double GetLengthPlane(int h, int k, int l)
        {
            if ((h == 0 && k == 0 && l == 0) || A * B * C == 0 || CellVolumeSqure <= 0) return 0;
            switch (Symmetry.CrystalSystemStr)//�ꍇ���������ق����������ȁH
            {
                case "cubic":
                    return A / Math.Sqrt(h * h + k * k + l * l);

                case "tetragoanl":
                    return 1 / Math.Sqrt((h * h + k * k) / A / A + l * l / C / C);

                case "orthorhombic":
                    return 1 / Math.Sqrt(h * h / A / A + k * k / B / B + l * l / C / C);
            }
            return Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure);
        }

        /// <summary>
        /// (h1 k1 l1)�ʂ�(h2 l2 k2)�ʂ̂Ȃ��p���v�Z���܂�
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="k1"></param>
        /// <param name="l1"></param>
        /// <param name="h2"></param>
        /// <param name="k2"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public double GetAnglePlanes(int h1, int k1, int l1, int h2, int k2, int l2)
        {
            if (A * B * C == 0 || (h1 == 0 && k1 == 0 && l1 == 0) || (h2 == 0 && k2 == 0 && l2 == 0) || (h1 == h2 && k1 == k2 && l1 == l2) || CellVolumeSqure <= 0) return 0;
            double temp = GetLengthPlane(h1, k1, l1) * GetLengthPlane(h2, k2, l2) / CellVolumeSqure * (h1 * h2 * sigma11 + k1 * k2 * sigma22 + l1 * l2 * sigma33 + (k1 * l2 + l1 * k2) * sigma23 + (l1 * h2 + h1 * l2) * sigma31 + (h1 * k2 + k1 * h2) * sigma12);
            if (temp >= 1 || temp <= -1) return 0;
            return Math.Acos(temp);
        }

        /// <summary>
        /// ��[pqr]�̎����̒���
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public double GetLengthAxis(int u, int v, int w)
        {
            if (A * B * C == 0 || (u == 0 && v == 0 && w == 0)) return 0;
            return Math.Sqrt(u * u * A * A + v * v * B * B + w * w * C * C + 2 * v * w * B * C * Math.Cos(Alpha) + 2 * w * u * C * A * Math.Cos(Beta) + 2 * u * v * A * B * Math.Cos(Gamma));
        }

        /// <summary>
        /// �񎲂̂Ȃ��p
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="v1"></param>
        /// <param name="w1"></param>
        /// <param name="u2"></param>
        /// <param name="v2"></param>
        /// <param name="w2"></param>
        /// <returns></returns>
        public double GetAngleAxes(int u1, int v1, int w1, int u2, int v2, int w2)
        {
            if (A * B * C == 0 || (u1 == 0 && v1 == 0 && w1 == 0) || (u2 == 0 && v2 == 0 && w2 == 0) || (u1 == u2 && v1 == v2 && w1 == w2)) return 0;
            return Math.Acos(1.0 / GetLengthAxis(u1, v1, w1) / GetLengthAxis(u2, v2, w2) * (u1 * u2 * A * A + v1 * v2 * B * B + w1 * w2 * C * C + (v1 * w2 + w1 * v2) * B * C * Math.Cos(Alpha) + (w1 * u2 + u1 * w2) * C * A * Math.Cos(Beta) + (u1 * v2 + v1 * u2) * A * B * Math.Cos(Gamma)));
        }

        /// <summary>
        /// �ʂ̐����Ǝ��̂Ȃ��p
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public double GetAnglePlaneAxis(int h, int k, int l, int u, int v, int w)
        {
            if (A * B * C == 0 || (h == 0 && k == 0 && l == 0) || (u == 0 && v == 0 && w == 0)) return 0;
            return Math.Acos(GetLengthPlane(h, k, l) / GetLengthAxis(u, v, w) * (h * u + k * v + l * w));
        }

        /// <summary>
        /// 2�ʂ��琬�鏻�ю�
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="k1"></param>
        /// <param name="l1"></param>
        /// <param name="h2"></param>
        /// <param name="k2"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public String GetZoneAxis(int h1, int k1, int l1, int h2, int k2, int l2)
        {
            int u, v, w, z;
            u = l1 * k2 - k1 * l2; v = h1 * l2 - l1 * h2; w = k1 * h2 - h1 * k2;
            for (z = 2; z <= Math.Abs(u) || z <= Math.Abs(v) || z <= Math.Abs(w); z++)
                if ((u % z == 0) && (v % z == 0) && (w % z == 0))
                {
                    u = u / z; v = v / z; w = w / z; z = 1;
                }
            return " " + u.ToString() + " " + v.ToString() + " " + w.ToString();
        }

        /// <summary>
        /// a,b,c���x�N�g������hkl�ʂ̕����x�N�g���v�Z
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Vector3D CalcHklVector(int h, int k, int l, Vector3D a, Vector3D b, Vector3D c)
        {
            return new Vector3D(
                -h * (b.Z * c.Y - b.Y * c.Z) - k * (c.Z * a.Y - c.Y * a.Z) - l * (a.Z * b.Y - a.Y * b.Z),
                -h * (b.X * c.Z - b.Z * c.X) - k * (c.X * a.Z - c.Z * a.X) - l * (a.X * b.Z - a.Z * b.X),
                -h * (b.Y * c.X - b.X * c.Y) - k * (c.Y * a.X - c.X * a.Y) - l * (a.Y * b.X - a.X * b.Y)
                );
        }

        /// <summary>
        /// hkl�ʂ̕����x�N�g���v�Z
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public Vector3D CalcHklVector(int h, int k, int l)
        {
            return new Vector3D(
                -h * (B_Axis.Z * C_Axis.Y - B_Axis.Y * C_Axis.Z) - k * (C_Axis.Z * A_Axis.Y - C_Axis.Y * A_Axis.Z) - l * (A_Axis.Z * B_Axis.Y - A_Axis.Y * B_Axis.Z),
                -h * (B_Axis.X * C_Axis.Z - B_Axis.Z * C_Axis.X) - k * (C_Axis.X * A_Axis.Z - C_Axis.Z * A_Axis.X) - l * (A_Axis.X * B_Axis.Z - A_Axis.Z * B_Axis.X),
                -h * (B_Axis.Y * C_Axis.X - B_Axis.X * C_Axis.Y) - k * (C_Axis.Y * A_Axis.X - C_Axis.X * A_Axis.Y) - l * (A_Axis.Y * B_Axis.X - A_Axis.X * B_Axis.Y)
                );
        }

        #endregion �����􉽊w�֘A

        //���񂩂ǂ�������
        public static bool CheckIrreducible(int a, int b, int c)
        {
            for (int n = 2; n <= new[] { a, b, c }.Max(); n++)
                if (a % n == 0 && b % n == 0 && c % n == 0)
                    return false;
            return true;
        }

        #region ���x�N�g���̌v�Z

        /// <summary>
        ///�@�����Ŏw�肳�ꂽ�w���̎��x�N�g�����v�Z���AVectorOfAxis�Ɋi�[
        /// </summary>
        /// <param name="indices"></param>
        public void SetVectorOfAxis((int U, int V, int W)[] indices)
        {
            if (A_Axis == null) return;
            VectorOfAxis = new List<Vector3D>();
            foreach (var index in indices)
            {
                var vec = index.U * A_Axis + index.V * B_Axis + index.W * C_Axis;
                vec.Index = "[" + index.U.ToString() + index.V.ToString() + index.W.ToString() + "]";
                VectorOfAxis.Add(vec);
            }
        }

        /// <summary>
        /// �����Ŏw�肳�ꂽuMax,vMax,wMax�͈̔͂Ŏ��x�N�g�����v�Z���AVectorOfAxis�Ɋi�[
        /// </summary>
        /// <param name="uMax"></param>
        /// <param name="vMax"></param>
        /// <param name="wMax"></param>
        public void SetVectorOfAxis(int uMax, int vMax, int wMax)
        {
            if (A_Axis == null) return;
            VectorOfAxis = new List<Vector3D>();
            var vec = new Vector3D();
            vec = A_Axis; vec.Index = "[100]"; VectorOfAxis.Add(vec);
            vec = B_Axis; vec.Index = "[010]"; VectorOfAxis.Add(vec);
            vec = C_Axis; vec.Index = "[001]"; VectorOfAxis.Add(vec);
            vec = -A_Axis; vec.Index = "[-100]"; VectorOfAxis.Add(vec);
            vec = -B_Axis; vec.Index = "[0-10]"; VectorOfAxis.Add(vec);
            vec = -C_Axis; vec.Index = "[00-1]"; VectorOfAxis.Add(vec);

            for (int u = -uMax; u <= uMax; u++)
                for (int v = -vMax; v <= vMax; v++)
                    for (int w = -wMax; w <= wMax; w++)
                        if (Crystal.CheckIrreducible(u, v, w) && !(u * v == 0 && v * w == 0 && w * u == 0))
                        {
                            vec = u * A_Axis + v * B_Axis + w * C_Axis;
                            vec.Index = "[" + u.ToString() + v.ToString() + w.ToString() + "]";
                            VectorOfAxis.Add(vec);
                        }
        }

        #endregion ���x�N�g���̌v�Z

        #region �ʃx�N�g���̌v�Z

        /// <summary>
        /// �����Ŏw�肳�ꂽ�w���̖ʃx�N�g�����v�Z���AVectorOfPlane�Ɋi�[
        /// </summary>
        /// <param name="indices"></param>
        public void SetVectorOfPlane((int H, int K, int L)[] indices)
        {
            VectorOfPlane = new List<Vector3D>();
            Vector3D vec;

            foreach (var index in indices)
            {
                vec = index.H * A_Star + index.K * B_Star + index.L * C_Star;
                vec.Index = "(" + index.H.ToString() + index.K.ToString() + index.L.ToString() + ")";
                VectorOfPlane.Add(vec);
            }
        }

        /// <summary>
        /// �����Ŏw�肳�ꂽhMax,kMax,lMax�͈̔͂Ŏ��x�N�g�����v�Z���AVectorOfAxis�Ɋi�[
        /// </summary>
        /// <param name="hMax"></param>
        /// <param name="kMax"></param>
        /// <param name="lMax"></param>
        public void SetVectorOfPlane(int hMax, int kMax, int lMax)
        {
            VectorOfPlane = new List<Vector3D>();
            Vector3D vec;

            vec = CalcHklVector(1, 0, 0); vec = vec * GetLengthPlane(1, 0, 0) / vec.d; vec.Index = "(100)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(0, 1, 0); vec = vec * GetLengthPlane(0, 1, 0) / vec.d; vec.Index = "(010)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(0, 0, 1); vec = vec * GetLengthPlane(0, 0, 1) / vec.d; vec.Index = "(001)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(-1, 0, 0); vec = vec * GetLengthPlane(-1, 0, 0) / vec.d; vec.Index = "(-100)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(0, -1, 0); vec = vec * GetLengthPlane(0, -1, 0) / vec.d; vec.Index = "(0-10)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(0, 0, -1); vec = vec * GetLengthPlane(0, 0, -1) / vec.d; vec.Index = "(00-1)"; VectorOfPlane.Add(vec);
            for (int h = -hMax; h <= hMax; h++)
                for (int k = -kMax; k <= kMax; k++)
                    for (int l = -lMax; l <= lMax; l++)
                        if (Crystal.CheckIrreducible(h, k, l) && !(h * k == 0 && k * l == 0 && l * h == 0))
                        {
                            vec = CalcHklVector(h, k, l);
                            vec = vec * GetLengthPlane(h, k, l) / vec.d;
                            vec.Index = "(" + h.ToString() + k.ToString() + l.ToString() + ")";
                            VectorOfPlane.Add(vec);
                        }
        }

        /// <summary>
        /// �ʊԊud_limit�ȏ�̖ʂ������A�\�[�g����B
        /// </summary>
        /// <param name="dMax">���̒l�ȏ�̖ʂ���������</param>
        /// <param name="dMin">���̒l�ȉ��̖ʂ���������</param>
        /// <param name="excludeEquivalentPlane">true�̂Ƃ��͌����w�I�ɓ����Ȗʂ�r������</param>
        /// <param name="excludeForbiddenPlane">true�̂Ƃ��͏��ő��Ɉ���������ʂ�r������</param>
        /// <param name="excludeSameDistance">true�̂Ƃ��͌����w�I�ɂ͔񓙉������A�ʊԊu���܂����������ʂ�r������</param>
        /// <param name="combineAdjacentPeak">true�̂Ƃ��́A�߂��s�[�N����������</param>
        /// <param name="horizontalAxis">�����̒P�ʂ��w�肷��</param>
        /// <param name="horizontalThreshold">�w�肳�ꂽ�����P�ʂɂ����鍷������臒l�ȉ��̖ʂǂ����𓝍�����</param>
        /// <param name="horizontalParameter">�������p�x�̎��͓��ː��̔g�����A�G�l���M�[�̎��͎��o���p���w�肷��</param>
        public void SetPlanes(double dMax, double dMin, bool excludeEquivalentPlane, bool excludeForbiddenPlane, bool excludeSameDistance, bool combineAdjacentPeak,
            HorizontalAxis horizontalAxis, double horizontalThreshold, double horizontalParameter)
        {
            #region
            if (dMin < (A + B + C) / 3 / 30)
                dMin = (A + B + C) / 3 / 30;
            int hMax = (int)(A / dMin);
            int kMax = (int)(B / dMin);
            int lMax = (int)(C / dMin);

            List<Plane> listPlane = new List<Plane>();
            int n = 0;
            double d;
            int multi = 1;
            if (excludeEquivalentPlane)//�����Ȗʂ�r������Ƃ�
            {
                for (int h = -hMax; h <= hMax; h++)//h��0����͂��߂�
                    for (int k = -kMax; k <= kMax; k++)
                        for (int l = -lMax; l <= lMax; l++)
                            if ((d = GetLengthPlane(h, k, l)) > dMin && d < dMax && SymmetryStatic.IsRootIndex(h, k, l, Symmetry, ref multi))
                            {
                                Plane temp = new Plane();
                                // if (!excludeForbiddenPlane | (temp.strCondition = SymmetryStatic.CheckExtinctionRule(h, k, l, Symmetry)).Length == 0)
                                if (!excludeForbiddenPlane | (temp.strCondition = Symmetry.CheckExtinctionRule(h, k, l)).Length == 0)
                                {
                                    temp.Multi[0] = multi;
                                    temp.h = h; temp.k = k; temp.l = l; temp.d = d;
                                    temp.strHKL = h.ToString() + " " + k.ToString() + " " + l.ToString();
                                    temp.IsRootIndex = true;
                                    listPlane.Add(temp);
                                }
                            }
            }
            else//�����Ȗʂ�r�����Ȃ��Ƃ�
            {
                for (int h = -hMax; h <= hMax; h++)//h��-hmax����͂��߂�
                    for (int k = -kMax; k <= kMax; k++)
                        for (int l = -lMax; l <= lMax; l++)
                            if ((d = GetLengthPlane(h, k, l)) > dMin)
                            {
                                Plane temp = new Plane();
                                temp.IsRootIndex = SymmetryStatic.IsRootIndex(h, k, l, Symmetry, ref multi);
                                if (!excludeForbiddenPlane | (temp.strCondition = Symmetry.CheckExtinctionRule(h, k, l)).Length == 0)
                                {
                                    temp.Multi[0] = multi;
                                    temp.h = h; temp.k = k; temp.l = l; temp.d = d;
                                    temp.strHKL = h.ToString() + " " + k.ToString() + " " + l.ToString();
                                    listPlane.Add(temp);
                                }
                            }
            }

            try
            {
                listPlane.Sort();
            }
            catch
            {
                return;
            }

            if (excludeSameDistance)//�S�����Ȃ������ʖʊԊu��������(511��333�Ƃ�)��r������
            {
                int i = 0;
                while (i < listPlane.Count - 1)
                {
                    if (listPlane[i].d == listPlane[i + 1].d)
                        listPlane.RemoveAt(i + 1);
                    else
                        i++;
                }
            }

            if (combineAdjacentPeak)//d�l�̋߂��s�[�N����������
            {
                if (horizontalAxis == HorizontalAxis.Angle && horizontalThreshold > 0 && horizontalParameter > 0) //臒l���p�x�̏ꍇ
                {
                    double minDif = double.PositiveInfinity;
                    do
                    {
                        minDif = double.PositiveInfinity;
                        int k = 0;
                        for (int i = 0; i < listPlane.Count - 1; i++)
                            if (minDif > Math.Abs(Math.Asin(horizontalParameter / listPlane[i].d / 2.0) * 2 - Math.Asin(horizontalParameter / listPlane[i + 1].d / 2.0) * 2))
                            {
                                minDif = Math.Abs(Math.Asin(horizontalParameter / listPlane[i].d / 2.0) * 2 - Math.Asin(horizontalParameter / listPlane[i + 1].d / 2.0) * 2);
                                k = i;
                            }
                        if (minDif < horizontalThreshold)
                        {
                            listPlane[k].d = (listPlane[k].d + listPlane[k + 1].d) / 2.0;
                            listPlane[k].strHKL += " + " + listPlane[k + 1].strHKL;
                            int[] multiplisity = new int[listPlane[k].Multi.Length + listPlane[k + 1].Multi.Length];
                            listPlane[k].Multi.CopyTo(multiplisity, 0);
                            listPlane[k + 1].Multi.CopyTo(multiplisity, listPlane[k].Multi.Length);
                            listPlane[k].Multi = multiplisity;

                            listPlane.RemoveAt(k + 1);
                        }
                    } while (minDif < horizontalThreshold);
                }
                else if (horizontalAxis == HorizontalAxis.EnergyXray && horizontalThreshold > 0 && horizontalParameter > 0)//Energy�̏ꍇ
                {
                    double minDif = double.PositiveInfinity;
                    do
                    {
                        minDif = double.PositiveInfinity;
                        int k = 0;
                        for (int i = 0; i < listPlane.Count - 1; i++)
                            if (minDif > Math.Abs(UniversalConstants.Convert.DspacingToXrayEnergy(listPlane[i].d, horizontalParameter) - UniversalConstants.Convert.DspacingToXrayEnergy(listPlane[i + 1].d, horizontalParameter)))
                            {
                                minDif = Math.Abs(UniversalConstants.Convert.DspacingToXrayEnergy(listPlane[i].d, horizontalParameter) - UniversalConstants.Convert.DspacingToXrayEnergy(listPlane[i + 1].d, horizontalParameter));
                                k = i;
                            }
                        if (minDif < horizontalThreshold)
                        {
                            listPlane[k].d = (listPlane[k].d + listPlane[k + 1].d) / 2.0;
                            listPlane[k].strHKL += " + " + listPlane[k + 1].strHKL;
                            int[] multiplisity = new int[listPlane[k].Multi.Length + listPlane[k + 1].Multi.Length];
                            listPlane[k].Multi.CopyTo(multiplisity, 0);
                            listPlane[k + 1].Multi.CopyTo(multiplisity, listPlane[k].Multi.Length);
                            listPlane[k].Multi = multiplisity;

                            listPlane.RemoveAt(k + 1);
                        }
                    } while (minDif < horizontalThreshold);
                }
                else if (horizontalAxis == HorizontalAxis.d && horizontalThreshold >= 0)
                {
                    double minDif = double.PositiveInfinity;
                    do
                    {
                        minDif = double.PositiveInfinity;
                        int k = 0;
                        for (int i = 0; i < listPlane.Count - 1; i++)
                            if (minDif > Math.Abs(listPlane[i].d - listPlane[i + 1].d))
                            {
                                minDif = Math.Abs(listPlane[i].d - listPlane[i + 1].d);
                                k = i;
                            }
                        if (minDif <= horizontalThreshold)
                        {
                            listPlane[k].d = (listPlane[k].d + listPlane[k + 1].d) / 2.0;
                            listPlane[k].strHKL += " + " + listPlane[k + 1].strHKL;
                            int[] multiplisity = new int[listPlane[k].Multi.Length + listPlane[k + 1].Multi.Length];
                            listPlane[k].Multi.CopyTo(multiplisity, 0);
                            listPlane[k + 1].Multi.CopyTo(multiplisity, listPlane[k].Multi.Length);
                            listPlane[k].Multi = multiplisity;

                            listPlane.RemoveAt(k + 1);
                        }
                    } while (minDif <= horizontalThreshold);
                    ;
                }
            }

            Plane[] temp_plane = listPlane.ToArray();
            for (n = 0; n < temp_plane.Length; n++)
            {
                temp_plane[n].F2[0] = -1;
                temp_plane[n].IsFittingChecked = false;
                temp_plane[n].IsFittingSelected = false;
                temp_plane[n].num = n;
                temp_plane[n].SerchRange = 0.10;
                temp_plane[n].SerchOption = temp_plane[n].peakFunction.Option = PeakFunctionForm.PseudoVoigt;
                temp_plane[n].Intensity = -1;
            }

            if (Plane != null)
                for (n = 0; n < Plane.Count && n < temp_plane.Length; n++)
                {
                    temp_plane[n].SerchRange = Plane[n].SerchRange;
                    temp_plane[n].FWHM = Plane[n].FWHM;
                    temp_plane[n].SerchOption = Plane[n].SerchOption;
                    temp_plane[n].IsFittingChecked = Plane[n].IsFittingChecked;
                    temp_plane[n].simpleParameter = Plane[n].simpleParameter;
                    temp_plane[n].peakFunction = Plane[n].peakFunction;
                    temp_plane[n].Intensity = Plane[n].Intensity;
                    temp_plane[n].observedIntensity = Plane[n].observedIntensity;
                }
            Plane = new List<Plane>();
            Plane.AddRange(temp_plane);

            #endregion �ʃx�N�g���̌v�Z
        }

        //plene[]��d�l���v�Z����B�v�Z����ʂ͈͕̔͂ς��Ȃ�
        public void SetPlanes()
        {
            for (int i = 0; i < Plane.Count; i++)
                Plane[i].d = GetLengthPlane(Plane[i].h, Plane[i].k, Plane[i].l);
        }

        #endregion

        #region �t�i�q�x�N�g���̌v�Z

        private readonly object lockThis = new object();

        /// <summary>
        /// dMin�ȏ�AdMax�ȉ��͈̔͂ŋt�i�q�x�N�g�����v�Z���Awavesorce�ɏ]���āA�\�����q���v�Z
        /// </summary>
        /// <param name="dMin"></param>
        /// <param name="dMax"></param>
        /// <param name="wavesource"></param>
        public void SetVectorOfG(double dMin, WaveSource wavesource, bool excludeLatticeCondition = true)
        {
            if (A_Star == null) SetAxis();

            double dMin2 = dMin * dMin, gMax2 = 1 / dMin2, gMax = Math.Sqrt(gMax2);
            var g = new List<Vector3D>();
            var maxGnum = 500000;

            var direction = new List<(int h, int k, int l)>();

            #region direction��������
            if (excludeLatticeCondition)
            {
                if (Symmetry.LatticeTypeStr == "F")
                    direction.AddRange(new (int h, int k, int l)[] { (1, 1, 1), (1, 1, -1), (1, -1, 1), (1, -1, -1), (-1, 1, 1), (-1, 1, -1), (-1, -1, 1), (-1, -1, -1) });
                else if (Symmetry.LatticeTypeStr == "A")
                    direction.AddRange(new (int h, int k, int l)[] { (0, 1, 1), (0, 1, -1), (0, -1, 1), (0, -1, -1), (1, 0, 0), (-1, 0, 0) });
                else if (Symmetry.LatticeTypeStr == "B")
                    direction.AddRange(new (int h, int k, int l)[] { (1, 0, 1), (1, 0, -1), (-1, 0, 1), (-1, 0, -1), (0, 1, 0), (0, -1, 0) });
                else if (Symmetry.LatticeTypeStr == "C")
                    direction.AddRange(new (int h, int k, int l)[] { (1, 1, 0), (1, -1, 0), (-1, 1, 0), (-1, -1, 0), (0, 0, 1), (0, 0, -1) });
                else if (Symmetry.LatticeTypeStr == "I")
                    direction.AddRange(new (int h, int k, int l)[] { (1, 1, 0), (1, -1, 0), (-1, 1, 0), (-1, -1, 0), (0, 1, 1), (0, 1, -1), (0, -1, 1), (0, -1, -1), (1, 0, 1), (1, 0, -1), (-1, 0, 1), (-1, 0, -1) });
                else if (Symmetry.LatticeTypeStr == "R" && Symmetry.SpaceGroupHMsubStr == "H")
                    direction.AddRange(new (int h, int k, int l)[] { (1, 0, 1), (0, -1, 1), (-1, 1, 1), (-1, 0, -1), (0, 1, -1), (1, -1, -1) });
                else if (Symmetry.CrystalSystemStr == "trigonal" || Symmetry.CrystalSystemStr == "hexagonal")
                    direction.AddRange(new (int h, int k, int l)[] { (1, 0, 0), (-1, 0, 0), (0, 1, 0), (0, -1, 0), (1, -1, 0), (-1, 1, 0), (0, 0, 1), (0, 0, -1) });
                else
                    direction.AddRange(new (int h, int k, int l)[] { (1, 0, 0), (-1, 0, 0), (0, 1, 0), (0, -1, 0), (0, 0, 1), (0, 0, -1) });
            }
            else
                direction.AddRange(new (int h, int k, int l)[] { (1, 0, 0), (-1, 0, 0), (0, 1, 0), (0, -1, 0), (0, 0, 1), (0, 0, -1) });

            #endregion

            var shift = direction.Select(dir => (MatrixInverse * dir).Length).Max();

            var outer = new Dictionary<(int h, int k, int l), double> { { (0, 0, 0), 0 } };
            var outerP = outer.AsParallel();

            var list = new List<(int h, int k, int l, int i)>();
            var listP = list.AsParallel();

            var whole = new HashSet<int> { 0 };
            const int n = 1024;
            var minG = 0.0;
            while (g.Count < maxGnum && minG < gMax)
            {
                minG = outer.Min(o => o.Value);
                var outerList = outer.Where(o => o.Value - minG < shift * 4).Select(o => o.Key).ToList();
                list.Clear();
                var i = 0;
                foreach ((int h2, int k2, int l2) in direction)
                    foreach ((int h1, int k1, int l1) in outerList)
                    {
                        int h = h1 + h2, k = k1 + k2, l = l1 + l2, key = h * n * n + k * n + l;
                        if (key > 0 && !whole.Contains(key))
                        {
                            whole.Add(key);
                            list.Add((h, k, l, i++));
                        }
                    }
                var gTemp = new Vector3D[list.Count * 2];
                var outerTemp = new (int h, int k, int l, double glen)[list.Count];
                listP.ForAll(index =>
                {
                    (int h, int k, int l, int i) = index;

                    var vec1 = h * A_Star + k * B_Star + l * C_Star;
                    var glen = vec1.Length;
                    vec1.h = (short)h;
                    vec1.k = (short)k;
                    vec1.l = (short)l;
                    vec1.d = 1 / glen;
                    vec1.Extinction = Symmetry.CheckExtinctionRule(h, k, l);
                    vec1.Index = h.ToString() + " " + k.ToString() + " " + l.ToString();

                    var vec2 = -vec1;
                    vec2.h = (short)-h;
                    vec2.k = (short)-k;
                    vec2.l = (short)-l;
                    vec2.d = vec1.d;
                    vec2.Extinction = vec1.Extinction;
                    vec2.Index = (-h).ToString() + " " + (-k).ToString() + " " + (-l).ToString();

                    gTemp[i * 2] = vec1;
                    gTemp[i * 2 + 1] = vec2;
                    outerTemp[i] = (h, k, l, glen);
                });
                g.AddRange(gTemp);
                outerList.ForEach(target => outer.Remove(target));
                foreach (var o in outerTemp)
                    outer.Add((o.h, o.k, o.l), o.glen);
            }
            g = g.OrderByDescending(v => v.d).ToList();

            if (wavesource != WaveSource.None)//���x�v�Z����ꍇ 250ms���炢
            {
                foreach (var _g in g)
                {
                    _g.F = _g.Extinction.Length == 0 ? GetStructureFactor(wavesource, Atoms, _g.h, _g.k, _g.l, _g.Length2/ 400.0) : 0;
                    _g.RawIntensity = _g.F.Magnitude2();
                }

                var maxIntensity = g.Max(v => v.RawIntensity);
                for (int i = 0; i < g.Count; i++)
                    g[i].RelativeIntensity = g[i].RawIntensity / maxIntensity;
            }
            VectorOfG = g; //�Ō�ɒl����
        }

        #endregion

        #region �e�r���t�i�q�x�N�g���̌v�Z

        //d_limit�ȏ�͈̔͂ŋe�r���t�i�q�x�N�g�����v�Z
        public void SetVectorOfG_KikuchiLine(double d_limit, double waveLength)
        {
            if (A_Star == null) SetAxis();
            int hMax = (int)(A / d_limit);
            int kMax = (int)(B / d_limit);
            int lMax = (int)(C / d_limit);
            VectorOfG_KikuchiLine = new List<Vector3D>();
            for (int h = 0; h <= hMax; h++)
                for (int k = h == 0 ? 0 : -kMax; k <= kMax; k++)
                    for (int l = (h == 0 && k == 0) ? 1 : -lMax; l <= lMax; l++)
                    {
                        Vector3D temp = h * A_Star + k * B_Star + l * C_Star;
                        if ((temp.d = temp.Length) < 1 / d_limit)
                        {
                            temp.Theta = waveLength / 2 * temp.Length;
                            temp.TanTheta = Math.Tan(temp.Theta);
                            temp.text = h.ToString() + " " + k.ToString() + " " + l.ToString();
                            VectorOfG_KikuchiLine.Add(temp);
                        }
                    }
        }

        #endregion

        #region ��܋��x�̋������̂�����

        /// <summary>
        /// ���݂̌����\���ŋ��x����ʍő�10�ʂ܂ł̂��̂��������A�Ԃ�
        /// </summary>
        /// <returns></returns>
        public double[] GetDspacingList(double waveLentgh, double d_limit)
        {
            SetPlanes(double.MaxValue, d_limit, true, true, true, false, 0, 0, 0);
            SetPeakIntensity(WaveSource.Xray, WaveColor.Monochrome, waveLentgh, null);

            //���x�̏��Ƀ\�[�g
            SortPlaneByIntensity[] s = new SortPlaneByIntensity[this.Plane.Count];
            for (int i = 0; i < Plane.Count; i++)
                s[i] = new SortPlaneByIntensity(Plane[i].d, Plane[i].Intensity);

            Array.Sort(s);
            double[] d = new double[Math.Min(8, s.Length)];
            for (int i = 0; i < d.Length; i++)
                d[i] = s[i].d;
            return d;
        }

        private class SortPlaneByIntensity : System.IComparable
        {
            public double d, intensity;

            public SortPlaneByIntensity(double d, double intensity)
            {
                this.d = d;
                this.intensity = intensity;
            }

            public int CompareTo(object obj)
            {
                return -intensity.CompareTo(((SortPlaneByIntensity)obj).intensity);
            }
        }

        #endregion

        #region ���q�̒ǉ�/�폜

        //�����̌��q��������
        public bool AddAtoms(Atoms Atoms)
        {
            return AddAtoms(Atoms, true);
        }

        public bool AddAtoms(Atoms atoms, bool RenewFormulaAndDensity)
        {
            if (Atoms.Length > 0)
            {
                Atoms[] temp = new Atoms[Atoms.Length + 1];
                Array.Copy(Atoms, temp, Atoms.Length);
                temp[Atoms.Length] = atoms;
                temp[Atoms.Length].ID = Atoms[Atoms.Length - 1].ID + 1;
                Atoms = temp;
                if (RenewFormulaAndDensity)
                    GetFormulaAndDensity();
                return true;
            }
            else
            {
                Atoms = new Atoms[1];
                Atoms[0] = atoms;
                if (RenewFormulaAndDensity)
                    GetFormulaAndDensity();
                return true;
            }
        }

        public bool AddAtoms(string label, int atomicNumber, int subXray, int subElectron, double[] isotope, double x, double y, double z, double occ, DiffuseScatteringFactor dsf)
        {
            return AddAtoms(label, atomicNumber, subXray, subElectron, isotope, x, y, z, occ, dsf, true);
        }

        //�����̌��q��������
        public bool AddAtoms(string label, int atomicNumber, int subXray, int subElectron, double[] isotope, double x, double y, double z, double occ, DiffuseScatteringFactor dsf, bool RenewFormulaAndDensity)
        {
            Atoms atoms = new Atoms(label, atomicNumber, subXray, subElectron, isotope, SymmetrySeriesNumber, new Vector3D(x, y, z), occ, dsf);
            return AddAtoms(atoms, RenewFormulaAndDensity);
        }

        //�����̌��q���폜����
        public bool DeleteAtoms(Atoms atoms)
        {
            for (int i = 0; i < Atoms.Length; i++)
            {
                if (Atoms[i].ID == atoms.ID)
                {
                    Atoms[] temp = new Atoms[Atoms.Length - 1];
                    Array.Copy(Atoms, 0, temp, 0, i);
                    Array.Copy(Atoms, i + 1, temp, i, temp.Length - i);
                    GetFormulaAndDensity();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���C�R�t�ʒu��ۂ����܂܁A���q�ʒu�𗐐��I�ɕω�������
        /// </summary>
        /// <param name="seed"></param>
        public void RandomizeAllAtomicPositionKeepingWykoff(Random r)
        {
            for (int i = 0; i < Atoms.Length; i++)
                Atoms[i].RandomizeKeepingWykoff(r);
        }

        /// <summary>
        /// ���q�̈ʒu���Ē������āA�����Ƃ����_�ʒu�ɋ߂����q��Atoms[i]=0�ɓ����
        /// </summary>
        public void ReCoordinateAtom()
        {
            for (int i = 0; i < Atoms.Length; i++)
            {
                double minR = double.PositiveInfinity;
                double r;
                int k = -1;
                for (int j = 0; j < Atoms[i].Atom.Count; j++)
                    if ((r = Atoms[i].Atom[j].Length2) < minR)
                    {
                        minR = r;
                        k = j;
                    }
                if (k >= 0)
                {
                    Atoms[i].X = Atoms[i].Atom[k].X;
                    Atoms[i].Y = Atoms[i].Atom[k].Y;
                    Atoms[i].Z = Atoms[i].Atom[k].Z;
                }
            }
        }

        /// <summary>
        /// ���݂̌��q��Ɗi�q�萔����A�g���Ɩ��x���v�Z���܂��B
        /// </summary>
        public void GetFormulaAndDensity()
        {
            #region
            if (Atoms == null || Atoms.Length == 0) return;

            string tempName;
            double tempNum;
            List<string> elName = new List<string>();
            List<double> elNum = new List<double>();

            for (int i = 0; i < Atoms.Length; i++)
            {
                tempName = Atoms[i].ElementName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                tempNum = Atoms[i].Multiplicity * Atoms[i].Occ;
                if (elName.IndexOf(tempName) >= 0)
                    elNum[elName.IndexOf(tempName)] = (double)elNum[elName.IndexOf(tempName)] + tempNum;
                else
                {
                    elName.Add(tempName);
                    elNum.Add(tempNum);
                }
            }

            ElementName = elName.ToArray();
            ElementNum = elNum.ToArray();

            double[] Num = elNum.ToArray();
            //�����Ŋ����Ƃ���܂ł��
            double numSum = 0;
            for (int i = 0; i < Num.Length; i++)
                numSum += Num[i];
            if (numSum == 0)
                return;

            if (ElementName != null)
            {
                //�܂�Num�̍ŏ��l��������
                int n = int.MaxValue;
                foreach (double var in Num)
                    if (n > var)
                        n = (int)var;

                //����2���珇�Ԃɂ���Ă���
                for (int i = 2; i <= n; i++)
                {
                    bool IsDivisor = true;
                    foreach (double var in Num)
                        if (var % i != 0) IsDivisor = false;
                    if (IsDivisor)
                    {
                        for (int j = 0; j < Num.Length; j++) Num[j] = Num[j] / i;
                        i--;
                    }
                }

                //�P�ʊi�q������̑g�����̐�Z��
                ChemicalFormulaZ = (int)(ElementNum[0] / Num[0]);

                //�g���� Fe21.333333333 O32  Fe2O3   *32/3 �̂悤�ɕ\��������
                bool is3times = true;
                int denom = 0;
                for (int i = 0; i < Num.Length; i++)
                    if (Math.Abs((Num[i] / 3.0)) % 1.0 > 0.000000001)
                        is3times = false;

                if (is3times == true)
                {
                    denom = (int)(Num[0] * 3 + 0.1);
                    for (int i = 0; i < Num.Length; i++)
                        Num[i] = (int)(Num[i] * 3 + 0.1);
                    //�܂�Num�̍ŏ��l��������
                    int m = int.MaxValue;
                    foreach (double var in Num)
                        if (m > var)
                            m = (int)var;

                    //����2���珇�Ԃɂ���Ă���
                    for (int i = 2; i <= m; i++)
                    {
                        bool IsDivisor = true;
                        foreach (double var in Num)
                            if (var % i != 0)
                                IsDivisor = false;
                        if (IsDivisor)
                        {
                            for (int j = 0; j < Num.Length; j++)
                                Num[j] = Num[j] / i;
                            i--;
                        }
                    }
                    denom = denom / (int)Num[0];
                }

                ChemicalFormulaSum = "";
                for (int i = 0; i < Num.Length; i++)
                {
                    if (Num[i] == 1)
                        ChemicalFormulaSum += ElementName[i] + " ";
                    else
                        ChemicalFormulaSum += ElementName[i] + Num[i].ToString() + " ";
                }
                ChemicalFormulaSum = ChemicalFormulaSum.Substring(0, ChemicalFormulaSum.Length - 1);

                if (is3times && denom != 3)
                    ChemicalFormulaSum += "  *" + denom.ToString() + "/3";

                double TotalWeightPerUnitCell = 0;
                for (int i = 0; i < ElementName.Length; i++)
                {
                    TotalWeightPerUnitCell += AtomConstants.AtomicWeight(ElementName[i]) * ElementNum[i];
                }
                Density = TotalWeightPerUnitCell / Math.Sqrt(CellVolumeSqure) / 6.0221367 / 100;
                WeightPerFormula = TotalWeightPerUnitCell / ChemicalFormulaZ;
            }
            return;
            #endregion
        }

        #endregion

        #region �\�����q�̌v�Z

       
        [NonSerialized]
        [XmlIgnore]
        private static readonly Complex TwoPiI = 2 * Complex.ImaginaryOne * Math.PI;

        //(h,k,l)�̍\���U�����q(�M�U���U������)��F (���f��) ���v�Z����
        /// <summary>
        /// �\�����q�����߂� s2�̒P�ʂ́�^-2
        /// </summary>
        /// <param name="wave"></param>
        /// <param name="atomsArray"></param>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private Complex GetStructureFactor(WaveSource wave, Atoms[] atomsArray, int h, int k, int l, double s2)
        {
            #region
            //s2 = (sin(theta)/ramda)^2 = 1 /4 /d^2
            if (atomsArray.Length == 0)
                return new Complex(0, 0);
            Complex F = 0;
            foreach (var atoms in atomsArray)
            {
                Complex f = 0;
                if (wave == WaveSource.Electron)
                    f = new Complex(atoms.GetAtomicScatteringFactorForElectron(s2), 0);
                else if (wave == WaveSource.Xray)
                    f = new Complex(atoms.GetAtomicScatteringFactorForXray(s2), 0);
                else if (wave == WaveSource.Neutron)
                    f = atoms.GetAtomicScatteringFactorForNeutron();

                if (atoms.Dsf.IsIso)
                {
                    var T = Math.Exp(-atoms.Dsf.Biso * s2);
                    foreach (var atom in atoms.Atom)
                        F += f * T * Complex.Exp(-TwoPiI * (h * atom.X + k * atom.Y + l * atom.Z));
                }
                else
                {
                    foreach (var atom in atoms.Atom)
                    {
                        var (H, K, L) = atom.Operation.ConvertPlaneIndex(h, k, l);
                        var T = Math.Exp(-(atoms.Dsf.B11 * H * H + atoms.Dsf.B22 * K * K + atoms.Dsf.B33 * L * L + 2 * atoms.Dsf.B12 * H * K + 2 * atoms.Dsf.B23 * K * L + 2 * atoms.Dsf.B31 * L * H));
                        F += f * T * Complex.Exp(-TwoPiI * (h * atom.X + k * atom.Y + l * atom.Z));
                    }
                }
            }
            return F;// Complex(Real, Inverse);
            #endregion
        }

        /// <summary>
        /// ������܎����ɂ�����(h,k,l)�̉�܋��x�ƈʒu���v�Z����
        /// </summary>
        /// <param name="ramda">�g��</param>
        public void SetPeakIntensity(WaveSource waveSource, WaveColor waveColor, double ramda, Profile whiteProfile)
        {
            #region
            if (Atoms == null || Atoms.Length == 0 || Plane == null) return;

            double temp = double.NegativeInfinity;

            for (int i = 0; i < Plane.Count; i++)
            {
                Plane[i].XCalc = 2 * Math.Asin(ramda / 2 / Plane[i].d);
                double twoTheta = Plane[i].XCalc;
                string[] s = Plane[i].strHKL.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                Plane[i].F2 = new double[s.Length];
                Plane[i].F = new Complex[s.Length];
                Plane[i].eachIntensity = new double[s.Length];

                for (int j = 0; j < Plane[i].F2.Length; j++)
                {
                    string[] hkl = s[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int h = Convert.ToInt32(hkl[0]), k = Convert.ToInt32(hkl[1]), l = Convert.ToInt32(hkl[2]);

                    Plane[i].F[j] = GetStructureFactor(waveSource, (Atoms[])Atoms.Clone(), h, k, l, 1 / Plane[i].d / Plane[i].d / 400);
                    Plane[i].F2[j] = Plane[i].F[j].Magnitude2();

                    if (waveSource == WaveSource.Xray)
                    {
                        if (waveColor == WaveColor.Monochrome)
                            Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure * (1 + Math.Cos(twoTheta) * Math.Cos(twoTheta)) / Math.Sin(twoTheta) / Math.Sin(twoTheta / 2);
                        else if (waveColor == WaveColor.FlatWhite)
                            Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure * Plane[i].d * Plane[i].d;
                    }
                    else if (waveSource == WaveSource.Electron)
                    {
                        Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure / Math.Sin(twoTheta) / Math.Sin(twoTheta / 2);
                    }
                    else if (waveSource == WaveSource.Neutron)
                    {
                        if (waveColor == WaveColor.Monochrome)
                            Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure / Math.Sin(twoTheta) / Math.Sin(twoTheta / 2);
                        else
                            Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure * Plane[i].d * Plane[i].d * Plane[i].d * Plane[i].d;
                    }
                }

                Plane[i].RawIntensity = 0;
                for (int j = 0; j < s.Length; j++)
                    Plane[i].RawIntensity += Plane[i].eachIntensity[j];
                temp = Math.Max(Plane[i].RawIntensity, temp);
            }

            for (int i = 0; i < Plane.Count; i++)
            {
                Plane[i].XCalc = 2 * Math.Asin(ramda / 2 / Plane[i].d) / Math.PI * 180;
                Plane[i].Intensity = Plane[i].RawIntensity / temp;
                for (int j = 0; j < Plane[i].eachIntensity.Length; j++)
                    Plane[i].eachIntensity[j] /= temp;
            }
            #endregion
        }

        #endregion

        /// <summary>
        /// �Ώ̐��A���q�̈ʒu�A�g���Ȃǂ��Čv�Z����
        /// </summary>
        internal void Reset()
        {
            Symmetry = SymmetryStatic.Get_Symmetry(SymmetrySeriesNumber);
            SetAxis();
            for (int i = 0; i < Atoms.Length; i++)
            {
                if (Symmetry.CrystalSystemStr == "hexagonal" || Symmetry.CrystalSystemStr == "trigonal")
                {
                    double value66667;
                    double value33333;
                    if (Miscellaneous.IsDecimalPointComma)
                    {
                        double.TryParse(",66667", out value66667);
                        double.TryParse(",33333", out value33333);
                    }
                    else
                    {
                        double.TryParse(".66667", out value66667);
                        double.TryParse(".33333", out value33333);
                    }

                    if (Atoms[i].X == value66667) Atoms[i].X = 2.0 / 3.0;
                    if (Atoms[i].X == value33333) Atoms[i].X = 1.0 / 3.0;
                    if (Atoms[i].Y == value66667) Atoms[i].Y = 2.0 / 3.0;
                    if (Atoms[i].Y == value33333) Atoms[i].Y = 1.0 / 3.0;
                }
                Atoms[i].ResetSymmetry(SymmetrySeriesNumber);
            }
            GetFormulaAndDensity();
        }

        public void SetCrystallites() => this.Crystallites = new Crystallite(this);

        public void SetCrystallites(double[] density) => this.Crystallites = new Crystallite(this, density);

        public void SaveInitialCellConstants()
        {
            InitialA = A;
            InitialB = B;
            InitialC = C;
            InitialAlpha = Alpha;
            InitialBeta = Beta;
            InitialGamma = Gamma;
            InitialA_err = A_err;
            InitialB_err = B_err;
            InitialC_err = C_err;
            InitialAlpha_err = Alpha_err;
            InitialBeta_err = Beta_err;
            InitialGamma_err = Gamma_err;
        }

        public void RevertInitialCellConstants()
        {
            if (InitialA != 0)
            {
                A = InitialA;
                B = InitialB;
                C = InitialC;
                Alpha = InitialAlpha;
                Beta = InitialBeta;
                Gamma = InitialGamma;
                A_err = InitialA_err;
                B_err = InitialB_err;
                C_err = InitialC_err;
                Alpha_err = InitialAlpha_err;
                Beta_err = InitialBeta_err;
                Gamma_err = InitialGamma_err;
            }
        }
    }
}