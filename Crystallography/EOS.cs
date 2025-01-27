using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Crystallography;

public enum ThermalPressure
{
    MieGruneisen, T_dependence_BM
}

public enum IsothermalPressure
{
    BM3, BM4, Vinet, Vinet3, AP2, Keane
}

/// <summary>
/// EOS の概要の説明です。
/// </summary>
[Serializable()]
public class EOS
{
    /// <summary>
    /// EOSを有効かするかどうか
    /// </summary>
    public bool Enabled { get; set; } = false;

    /// <summary>
    /// Standard Cell Volume
    /// </summary>
    public double CellVolume0 { get; set; }

    /// <summary>
    /// Standard Temperature in Kelvin
    /// </summary>
    public double T0 { get; set; } = 300;

    /// <summary>
    /// Isothermal Bulk Modulus at Standard temperature
    /// </summary>
    public double K0 { get; set; }

    /// <summary>
    /// First Pressure Derivative Of Bulk Modulus
    /// </summary>
    public double Kp0 { get; set; }

    /// <summary>
    /// First Pressure Derivative Of Bulk Modulus at infinity
    /// </summary>
    public double KpInfinity { get; set; }

    /// <summary>
    /// Second Pressure derivative Of Bulk Modulus
    /// </summary>
    public double Kpp0 { get; set; }


    public double Vinet3rd_Ita { get; set; }
    public double Vinet3rd_Beta { get; set; }
    public double Vinet3rd_Psi { get; set; }

    /// <summary>
    /// Grüneisen Parameter at Standard Volume
    /// </summary>
    public double Gamma0 { get; set; }

    /// <summary>
    /// Debye Temperature at Standard Volume
    /// </summary>
    public double Theta0 { get; set; }

    /// <summary>
    /// Volume dependence of Grüneisen parameter
    /// </summary>
    public double Q { get; set; }

    /// <summary>
    /// Derivative of bulk modulus by temperature (∂KT0 /∂T)
    /// </summary>
    public double KperT { get; set; }

    /// <summary>
    /// Thermal expansivity coefficients A (10^-5/K)
    /// </summary>
    public double A { get; set; }

    /// <summary>
    /// Thermal expansivity coefficients B (10^-9/K)
    /// </summary>
    public double B { get; set; }

    /// <summary>
    /// Thermal expansivity coefficients C (K)
    /// </summary>
    public double C { get; set; }

    /// <summary>
    /// Thermal Pressure Approach (T-dependence K0&V0  or Mie-Gruneisen)
    /// </summary>
    public ThermalPressure ThermalPressureApproach { get; set; } = ThermalPressure.MieGruneisen;

    /// <summary>
    /// IsothermalPressureApproach (Vinet or Birch-Murnaghan)
    /// </summary>
    public IsothermalPressure IsothermalPressureApproach { get; set; } = IsothermalPressure.BM3;

    /// <summary>
    /// Number of formula in unit cell
    /// </summary>
    public double Z { get; set; }

    /// <summary>
    /// The total number of electrons in the unit cell
    /// </summary>
    public double Ze { get; set; }

    /// <summary>
    /// atoms per formula
    /// </summary>
    public int N { get; set; }

    /// <summary>
    /// Note
    /// </summary>
    public string Note { get; set; }

    /// <summary>
    /// Temperature in Kelvin
    /// </summary>
    public double Temperature { get; set; } = 300;

    /// <summary>
    /// Pressure in GPa
    /// </summary>
    public double Pressure { get; set; } = 0;


    public EOS()
    {
        //
        // TODO: コンストラクタ ロジックをここに追加してください。
        //
    }

    public double GetPressure(double cellVolume)
    {

        if (Z == 0) return 0;
        if (ThermalPressureApproach == ThermalPressure.MieGruneisen)
        {
            double cellV = cellVolume, cellV0 = CellVolume0;
            double molV = cellVolume * 6.0221367 / Z / 10000;
            double molV0 = CellVolume0 * 6.0221367 / Z / 10000;

            double Pst = IsothermalPressureApproach switch
            {
                IsothermalPressure.BM3 => BirchMurnaghan3rd(K0, Kp0, cellV0 / cellV),
                IsothermalPressure.BM4 => BirchMurnaghan4th(K0, Kp0, Kpp0, cellV0 / cellV),
                IsothermalPressure.Vinet => Vinet(K0, Kp0, cellV0, cellV),
                IsothermalPressure.AP2 => AP2(K0, Kp0, Ze, CellVolume0, cellVolume),
                IsothermalPressure.Keane => Keane(K0, Kp0, KpInfinity, cellV0, cellV),
                IsothermalPressure.Vinet3 => Vinet3rd(K0, Vinet3rd_Ita, Vinet3rd_Beta, Vinet3rd_Psi, cellV0, cellV),
                _ => 0
            };

            double gamma = Gamma0 * Math.Pow(molV / molV0, Q);
            double theta = Theta0 * Math.Exp((Gamma0 - gamma) / Q);
            double x = theta / Temperature;
            double x0 = theta / T0;
            double Eth = 9 * 8.31451 * N * Temperature / x / x / x * integ(x);
            double Eth0 = 9 * 8.31451 * N * T0 / x0 / x0 / x0 * integ(x0);
            double deltaPth = gamma / molV * (Eth - Eth0) / 1000000;
            return double.IsNaN(deltaPth) ? Pst : deltaPth + Pst;
        }
        else if (ThermalPressureApproach == ThermalPressure.T_dependence_BM)
        {
            double cellV = cellVolume;
            double KT0 = K0 + KperT * (Temperature - T0);
            double cellV0 = CellVolume0 * Math.Exp(A * 1.0E-5 * (Temperature - T0) + B * 1.0E-9 / 2 * (Temperature * Temperature - T0 * T0) - C * (1 / Temperature - 1 / T0));

            return IsothermalPressureApproach switch
            {
                IsothermalPressure.BM3 => BirchMurnaghan3rd(KT0, Kp0, cellV0 / cellV),
                IsothermalPressure.BM4 => BirchMurnaghan4th(KT0, Kp0, Kpp0, cellV0 / cellV),
                IsothermalPressure.Vinet => Vinet(KT0, Kp0, cellV0, cellV),
                IsothermalPressure.AP2 => AP2(KT0, Kp0, Ze, cellV0, cellV),
                IsothermalPressure.Keane => Keane(KT0, Kp0, KpInfinity, cellV0, cellV),
                _ => 0
            };
        }
        return 0;
    }


    /// <summary>
    /// MieGruneisenによるThermal pressureの計算
    /// </summary>
    /// <param name="z">Number of formula in unit cell</param>
    /// <param name="n"> atoms per formula</param>
    /// <param name="theta0">Debye Temperature at Standard Volume</param>
    /// <param name="gamma0">Grüneisen Parameter at Standard Volume</param>
    /// <param name="q">Volume dependence of Grüneisen parameter</param>
    /// <param name="t0">Standard temperature</param>
    /// <param name="v0">Stamdard volume (nm^3)</param>
    /// <param name="v">Target temperature</param>
    /// <param name="t">Target volume (nm^3)</param>
    /// <returns></returns>
    public static double MieGruneisen(double z, double n, double theta0, double gamma0, double q, double t0, double v0, double t, double v)
    {
        double V = v * 6.0221367 / z / 10000;
        double V0 = v0 * 6.0221367 / z / 10000;

        double gamma = gamma0 * Math.Pow(V / V0, q);
        double theta = theta0 * Math.Exp((gamma0 - gamma) / q);
        double x = theta / t;
        double x0 = theta / t0;
        double eth = 9 * UniversalConstants.R * n * t / x / x / x * integ(x);
        double eth0 = 9 * UniversalConstants.R * n * t0 / x0 / x0 / x0 * integ(x0);
        double deltaPth = gamma / V * (eth - eth0) / 1000000;

        return deltaPth;
    }

    /// <summary>
    /// MieGruneisenによるThermal pressureの計算 (Yokoo et alなど)
    /// </summary>
    /// <param name="z">Number of formula in unit cell</param>
    /// <param name="n"> atoms per formula</param>
    /// <param name="theta0">Debye Temperature at Standard Volume</param>
    /// <param name="gamma0">Grüneisen Parameter at Standard Volume</param>
    /// <param name="q">Volume dependence of Grüneisen parameter</param>
    /// <param name="t0">Standard temperature</param>
    /// <param name="v0">Stamdard volume (nm^3)</param>
    /// <param name="v">Target temperature</param>
    /// <param name="t">Target volume (nm^3)</param>
    /// <param name="a">Yokoo et al などで使われている変化球</param>
    /// <param name="b">Yokoo et al などで使われている変化球</param>
    /// <returns></returns>
    public static double MieGruneisen(double z, double n, double theta0, double gamma0, double q, double t0, double v0, double t, double v, double a, double b)
    {
        double V = v * 6.0221367 / z / 10000;
        double V0 = v0 * 6.0221367 / z / 10000;
        double V0perV = v0 / v;

        //double gamma = gamma0 * Math.Pow(V / V0, q);
        double gamma = gamma0 * (1 + a * (Math.Pow(V / V0, b) - 1));
        double theta = theta0 * Math.Pow(v / v0, (a - 1) * gamma0) * Math.Exp((gamma0 - gamma) / b);
        double x = theta / t;
        double x0 = theta / t0;
        double eth = 9 * UniversalConstants.R * n * t / x / x / x * integ(x);
        double eth0 = 9 * UniversalConstants.R * n * t0 / x0 / x0 / x0 * integ(x0);
        double deltaPth = gamma / V * (eth - eth0) / 1000000000;

        return deltaPth;
    }

    public static double Keane(double k0, double kp0, double kpInfinity, double v0, double v)
    {
        var x = v0 / v;
        var y = kp0 / kpInfinity;
        return k0 * (y / kpInfinity * (Math.Pow(x, kpInfinity) - 1) - (y - 1) * Math.Log(x));
    }

    public static double AP2(double k0, double kp0, double ze, double v0, double v)
    {
        var x = Math.Pow(v / v0, 1.0 / 3.0);
        var pFG = 2336.965 * Math.Pow(ze / v0, 5.0 / 3.0);
        var C0 = -Math.Log(3 * k0 / pFG);
        var C2 = 1.5 * (kp0 - 3) - C0;

        return 3 * k0 * (1 - x) / Math.Pow(x, 5) * Math.Exp(C0 * (1 - x)) * (1 + x * C2 * (1 - x));
    }

    /// <summary>
    /// 3次のBurchiNurnaghan
    /// </summary>
    /// <param name="k0"></param>
    /// <param name="k_prime"></param>
    /// <param name="v0"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static double BirchMurnaghan3rd(double k0, double k_prime, double v0, double v)
        => BirchMurnaghan3rd(k0, k_prime, v0 / v);

    /// <summary>
    /// 3次のBurchiNurnaghan
    /// </summary>
    /// <param name="k0"></param>
    /// <param name="k_prime"></param>
    /// <param name="v0"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static double BirchMurnaghan3rd(double k0, double k_prime, double V0perV) =>
        1.5 * k0 * (Math.Pow(V0perV, 7.0 / 3) - Math.Pow(V0perV, 5.0 / 3)) * (1 - 0.75 * (4 - k_prime) * (Math.Pow(V0perV, 2.0 / 3) - 1));

    public static double BirchMurnaghan4th(double k0, double kp, double kpp, double V0perV)
    {
        double a = Math.Pow(V0perV, 1.0 / 3.0), a2 = a * a, a4 = a2 * a2;
        return 1.5 * k0 * (a4 * a * (a2 - 1)) * (1 + 0.75 * (kp - 4) * (a2 - 1) + (9 * k0 * kpp + 9 * kp * kp - 63 * kp + 143) / 24.0 * (a4 - 2 * a2 + 1));

        //double b1 = k0 * kpp + (kp - 4) * (kp - 5) + 59.0 / 9.0;
        //double b2 = 3 * k0 * kpp + (kp - 4) * (3 * kp - 13) + 129.0 / 9.0;
        //double b3 = 3 * k0 * kpp + (kp - 4) * (3 * kp - 11) + 105.0 / 9.0;
        //double b4 = k0 * kpp + (kp - 4) * (kp - 3) + 35.0 / 9.0;

        //return 9.0 / 16 * k0 * (-b1 * Math.Pow(a, 5) + b2 * Math.Pow(a, 7) - b3 * Math.Pow(a, 9) + b4 * Math.Pow(a, 11));

    }

    public static double InverseThirdBirchMurnaghan(double k0, double k_prime, double pressure)
    {
        double start = 1.0, end = 3.0, step = 0.5;
        double bestR = double.PositiveInfinity, bestV = 0;

        for (int n = 0; n < 30; n++)
        {
            bestR = double.PositiveInfinity;
            for (double v = start; v <= end; v += step)
            {
                var r = Math.Abs(BirchMurnaghan3rd(k0, k_prime, v) - pressure);
                if (r < bestR)
                {
                    bestR = r;
                    bestV = v;
                }
            }
            step *= 0.5;
            start = bestV - step * 3;
            end = bestV + step * 3;
        }
        return bestV;
    }


    public static double Vinet(double k0, double k_prime, double v0, double v)
        => Vinet(k0, k_prime, v0 / v);
    public static double Vinet(double k0, double k_prime, double x)
    {
        double y = Math.Pow(x, -1.0 / 3.0);
        return 3 * k0 * (1 - y) / y / y * Math.Exp(1.5 * (k_prime - 1) * (1 - y));
    }

    public static double Vinet3rd(double k0, double ita, double beta, double psi, double v0, double v)
        => Vinet3rd(k0, ita, beta, psi, v0 / v);

    public static double Vinet3rd(double k0, double ita, double beta, double psi, double x)
    {
        double y = Math.Pow(x, -1.0 / 3.0);
        return 3 * k0 * (1 - y) / y / y * Math.Exp(ita * (1 - y) + beta * (1 - y) * (1 - y) + psi * (1 - y) * (1 - y) * (1 - y));
    }


    /// <summary>
    /// ∫z^3/(e^z-1)dz 0～xの積分を求める関数
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private static double integ(double x)
    {
        if (double.IsNaN(x)) return double.NaN;
        double z, f;
        double temp = 0;
        int num = 100000;
        for (int i = 1; i <= num; i++)
        {//10000分割で数値積分
            z = (i + 0.5) * x / num;
            f = z * z * z / (Math.Exp(z) - 1);
            temp += f;
        }
        return temp * x / num;
    }

    public static double MgO_Tange_Vinet(double T, double v0, double v)
    {
        double k0 = 160.63; //= KT0
        double k_prime = 4.367; // = K'T0
        double theta0 = 761;//= Theta0
        double gamma0 = 1.442;//= Gamma0
        double a = 0.138;//= a
        double b = 5.4;//= b
        double n = 2;//= n
        double z = 4;// = Z

        double p_t0 = Vinet(k0, k_prime, v0 / v);

        double gamma = gamma0 * (1 + a * (Math.Pow(v / v0, b) - 1));
        double theta = theta0 * Math.Pow((v / v0), (-(1 - a) * gamma0)) * Math.Exp(-(gamma - gamma0) / b);
        double et = -0.0000013397592 * Math.Pow(theta / T, 6) + 0.000035022653 * Math.Pow(theta / T, 5) - 0.00031034588 * Math.Pow(theta / T, 4)
            + 0.00018490174 * Math.Pow(theta / T, 3) + 0.016520035 * Math.Pow(theta / T, 2) - 0.12495878 * (theta / T) + 0.33333333;
        double et0 = -0.0000013397592 * Math.Pow(theta / 300.0, 6) + 0.000035022653 * Math.Pow(theta / 300.0, 5) - 0.00031034588 * Math.Pow(theta / 300.0, 4)
            + 0.00018490174 * Math.Pow(theta / 300.0, 3) + 0.016520035 * Math.Pow(theta / 300.0, 2) - 0.12495878 * (theta / 300) + 0.33333333;
        double de = 9 * n * 8.3145 * (T * et - 300.0 * et0);
        double v0mol = 6.0221 / z * v0 * 1.0E-7;
        double p_th = gamma / (v / v0) / v0mol * de * 1E-9;

        return p_t0 + p_th;
    }

    public static double MgO_Tange_BM(double t, double v0, double v)
    {
        double k0 = 160.64; //= KT0
        double k_prime = 4.221; // = K'T0
        double theta0 = 761;//= Theta0
        double gamma0 = 1.431;//= Gamma0
        double a = 0.29;//= a
        double b = 3.5;//= b
        double n = 2;//= n
        double z = 4;// = Z
        double t0 = 300.0;//T0=300K

        double gamma = gamma0 * (1 + a * (Math.Pow(v / v0, b) - 1));
        double theta = theta0 * Math.Pow((v / v0), (-(1 - a) * gamma0)) * Math.Exp(-(gamma - gamma0) / b);
        double et = -0.0000013397592 * Math.Pow(theta / t, 6) + 0.000035022653 * Math.Pow(theta / t, 5) - 0.00031034588 * Math.Pow(theta / t, 4)
            + 0.00018490174 * Math.Pow(theta / t, 3) + 0.016520035 * Math.Pow(theta / t, 2) - 0.12495878 * (theta / t) + 0.33333333;
        double et0 = -0.0000013397592 * Math.Pow(theta / t0, 6) + 0.000035022653 * Math.Pow(theta / t0, 5) - 0.00031034588 * Math.Pow(theta / t0, 4)
            + 0.00018490174 * Math.Pow(theta / t0, 3) + 0.016520035 * Math.Pow(theta / t0, 2) - 0.12495878 * (theta / t0) + 0.33333333;
        double de = 9 * n * 8.3145 * (t * et - t0 * et0);
        double v0mol = 6.0221 / z * v0 * 1.0E-7;
        double Yth = gamma / (v / v0) / v0mol * de * 1E-9;
        double YT0 = 1.5 * k0 * (Math.Pow(v0 / v, 7.0 / 3.0) - Math.Pow(v0 / v, 5.0 / 3.0)) * (1 - 3.0 / 4.0 * (4 - k_prime) * (Math.Pow(v0 / v, 2.0 / 3.0) - 1));
        return YT0 + Yth;
    }


    /// <summary>
    /// Au (Fratanduono et al., 2021) Thermal pressureなし
    /// </summary>
    /// <param name="v0"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static double Au_Fratanduono_Vinet(double v0, double v)
    {
        double k0 = 170.09; //= KT0
        double k_prime = 5.880; // = K'T0
        double p_t0 = Vinet(k0, k_prime, v0 / v);

        return p_t0;
    }

    /// <summary>
    /// Pt (Fratanduono et al., 2021) Thermal pressureなし
    /// </summary>
    /// <param name="v0"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static double Pt_Fratanduono_Vinet(double v0, double v)
    {
        double k0 = 259.7; //= KT0
        double k_prime = 5.839; // = K'T0
        double p_t0 = Vinet(k0, k_prime, v0 / v);

        return p_t0;
    }

    public static double Au_Anderson(double T, double a, double a0)
    { //Andersonの状態方程式
        double V = a * a * a;
        double V0 = a0 * a0 * a0;
        double KT = 166.65;
        double KTperT = -0.0115;
        double KTperP = 5.4823;

        return 3.0 / 2.0 * KT * (Math.Pow(V0 / V, 7.0 / 3.0) - Math.Pow(V0 / V, 5.0 / 3.0)) * (1 - 3.0 / 4.0 * (4 - KTperP) * (Math.Pow(V0 / V, 2.0 / 3.0) - 1))
            + (0.00714 + KTperT * Math.Log(V0 / V)) * (T - 300);
    }

    public static double NaClB2_Sata(double a, double Pr, double Kr)
    { //SataさんのNaClB2の状態方程式
        double V = a * a * a;
        return Pr * Math.Pow((V / 27.17), (-2.0 / 3.0)) * Math.Exp(-(3 * Kr / Pr - 2) * (Math.Pow(V / 27.17, 1.0 / 3.0) - 1));
    }

    public static double NaClB1_Sata(double a)
    { //SataさんのNaClB1の状態方程式
        double V = a * a * a;
        double V0 = 5.6402 * 5.6402 * 5.6402;
        return ((V0 - V) / V0 - 0.2561) / (0.261 - 0.2561) * (15.43 - 14.86) + 14.86;
    }

    //Sakaiさんの状態方程式
    public static double NaClB2_SakaiBM(double a)
    {
        double V = a * a * a;
        return BirchMurnaghan3rd(47.00, 4.10, 37.73 / V);
    }

    public static double NaClB2_SakaiVinet(double a)
    {
        double V = a * a * a;
        return Vinet(40.40, 5.04, 37.73 / V);
    }

    //Ueda et al (2008) J app phis
    public static double NaClB2_Ueda(double A, double T)
    {
        double V = A * A * A;
        double V0 = 24.76 / 6.0221367 * 10; ;

        double Kt0 = 28.45;//Kt0
        double KpT0 = 5.16;// K'tO

        double Pst = Vinet(Kt0, KpT0, V0 / V);

        double Pth = 0.00468 * (T - 300);

        return Pst + Pth;
    }

    //Matui et al (2012) Am Min
    public static double NaClB1_Matsui(double A0, double A, double T)
    {
        double V = A * A * A;
        double V0 = A0 * A0 * A0;

        double Kt0 = 23.7;//Kt0
        double KpT0 = 5.14;// K'tO
        double KppT0 = -0.392;// K'tO

        double a = 1.5 * (KpT0 - 4);
        double b = (9 * Kt0 * KppT0 + 9 * KpT0 * KpT0 - 63 * KpT0 + 143) / 6.0;

        double f = (Math.Pow(V0 / V, 2.0 / 3.0) - 1) / 2.0;

        double Pst = 3 * f * Kt0 * Math.Pow(1 + 2 * f, 5.0 / 2.0) * (1 + a * f + b * f * f);

        double deltaPth = MieGruneisen(4, 2, 279, 1.56, 0.96, 300, V0, T, V);
        return deltaPth + Pst;
    }

    public static double Pt_Holmez(double T, double a, double a0)
    { //Pt Holmesの状態方程式
        double X = a / a0;
        double BT = 266;
        double BprimeT = 5.81;
        double AlfaT = 0.261;

        return 3 * BT * ((1 - X) / X / X) * Math.Exp(1.5 * (BprimeT - 1) * (1 - X)) + AlfaT * BT * (T - 300) / 10000;
    }

    /// <summary>
    /// Pt(Matsui2009)の状態方程式
    /// </summary>
    /// <param name="T"></param>
    /// <param name="T0"></param>
    /// <param name="a"></param>
    /// <param name="a0"></param>
    /// <returns></returns>
    public static double Pt_Matsui(double T, double T0, double a, double a0)
    {
        double K0T = 273;
        double Kprime0T = 5.20;
        double gamma0 = 2.70;
        double q = 1.10;
        double theta0 = 230;

        double V = a * a * a * 6.0221367 / 4 / 10000;
        double V0 = a0 * a0 * a0 * 6.0221367 / 4 / 10000;
        double V0perV = (a0 / a) * (a0 / a) * (a0 / a);

        double Pst = Vinet(K0T, Kprime0T, V0perV);

        double gamma = gamma0 * Math.Pow(V / V0, q);
        double theta = theta0 * Math.Exp((gamma0 - gamma) / q);
        double x = theta / T;
        double x0 = theta / T0;
        double Eth = 9 * UniversalConstants.R * T / x / x / x * integ(x);
        double Eth0 = 9 * UniversalConstants.R * T0 / x0 / x0 / x0 * integ(x0);

        //PelT (the difference from the value at 300 K of 0.04 GPa) =0.21, 1.60, and 3.78 GPa at 1000, 3000, and 5000 K, respectively.
        //上記を多項式近似
        double Pel = -1.01162E-11 * T * T * T + 1.89796E-07 * T * T + 6.73266E-05 * T - 3.70065E-02;

        double deltaPth = gamma / V * (Eth - Eth0) / 1000000000;

        return deltaPth + Pst + Pel;
    }

    public static double Corundum_Dubrovinsky(double V0, double V, double T)
    {
        //Dubrovinskyの状態方程式
        double T0 = 300;

        double KTperT = -0.020;
        double KTperP = 4.88;
        double KT = 258 + KTperT * (T - T0); ;
        double a = 2.6E-5, b = 1.81E-9, c = -0.67;

        double v0 = V0 * Math.Exp(a * (T - T0) + b / 2 * (T * T - T0 * T0) - c * (1 / T - 1 / T0));
        double V0perV = v0 / V;

        return 3.0 / 2.0 * KT * (Math.Pow(V0perV, 7.0 / 3.0) - Math.Pow(V0perV, 5.0 / 3.0)) * (1 - 3.0 / 4.0 * (4 - KTperP) * (Math.Pow(V0perV, 2.0 / 3.0) - 1));
    }

    #region Brownの正攻法の解き方
    /*
    public static double NaClB1_Brown(double a, double T)
    {
        Profile dest = new Profile();
        //単位格子の体積 / 単位格子の質量
        double V = a * a * a / (22.99 + 35.45) * 6.0221367 / 4 * 100;
        //double V = 0.4500;
        dest.pt = new Pt[] { new Pt(V, 0) };

        //まず zero-kelvin のstatic compressionカーブから 0Kの圧力を求める
        List<Pt> pt = new List<Pt>();
        pt.Add(new Pt(0.3143, 23.12));
        pt.Add(new Pt(0.3256, 19.33));
        pt.Add(new Pt(0.3369, 16.03));
        pt.Add(new Pt(0.3482, 13.17));
        pt.Add(new Pt(0.3595, 10.07));
        pt.Add(new Pt(0.3709, 8.57));
        pt.Add(new Pt(0.3822, 6.73));
        pt.Add(new Pt(0.3935, 5.14));
        pt.Add(new Pt(0.4048, 3.77));
        pt.Add(new Pt(0.4161, 2.60));
        pt.Add(new Pt(0.4274, 1.59));
        pt.Add(new Pt(0.4387, 0.71));
        pt.Add(new Pt(0.4500, -0.05));
        pt.Add(new Pt(0.4613, -0.69));
        pt.Add(new Pt(0.4726, -1.23));
        pt.Add(new Pt(0.4839, -1.68));
        pt.Add(new Pt(0.4953, -2.05));
        pt.Add(new Pt(0.5066, -2.35));
        pt.Add(new Pt(0.5179, -2.59));
        pt.Add(new Pt(0.5292, -2.80));
        pt.Add(new Pt(0.5405, -2.97));

        Profile controlPoints = new Profile();
        controlPoints.pt = pt.ToArray();

        double P0 = Spline.GetSpline(controlPoints, dest).pt[0].Y;

        pt.Clear();
        pt.Add(new Pt(0.3143, 0.93));//446,402,402,388,375
        pt.Add(new Pt(0.3256, 0.98));
        pt.Add(new Pt(0.3369, 1.03));
        pt.Add(new Pt(0.3482, 1.08));
        pt.Add(new Pt(0.3595, 1.13));
        pt.Add(new Pt(0.3709, 1.19));
        pt.Add(new Pt(0.3822, 1.24));
        pt.Add(new Pt(0.3935, 1.29));
        pt.Add(new Pt(0.4048, 1.35));
        pt.Add(new Pt(0.4161, 1.40));
        pt.Add(new Pt(0.4274, 1.46));
        pt.Add(new Pt(0.4387, 1.51));
        pt.Add(new Pt(0.4500, 1.55));
        pt.Add(new Pt(0.4613, 1.59));
        pt.Add(new Pt(0.4726, 1.62));
        pt.Add(new Pt(0.4839, 1.63));
        pt.Add(new Pt(0.4953, 1.63));
        pt.Add(new Pt(0.5066, 1.63));
        pt.Add(new Pt(0.5179, 1.63));
        pt.Add(new Pt(0.5292, 1.63));
        pt.Add(new Pt(0.5405, 1.63));

        controlPoints.pt = pt.ToArray();
        double Gamma = Spline.GetSpline(controlPoints, dest).pt[0].Y;

        pt.Clear();
        pt.Add(new Pt(0.3143, 446));
        pt.Add(new Pt(0.3256, 431));
        pt.Add(new Pt(0.3369, 417));
        pt.Add(new Pt(0.3482, 402));
        pt.Add(new Pt(0.3595, 388));
        pt.Add(new Pt(0.3709, 375));
        pt.Add(new Pt(0.3822, 361));
        pt.Add(new Pt(0.3935, 348));
        pt.Add(new Pt(0.4048, 336));
        pt.Add(new Pt(0.4161, 323));
        pt.Add(new Pt(0.4274, 311));
        pt.Add(new Pt(0.4387, 299));
        pt.Add(new Pt(0.4500, 288));
        pt.Add(new Pt(0.4613, 277));
        pt.Add(new Pt(0.4726, 266));
        pt.Add(new Pt(0.4839, 256));
        pt.Add(new Pt(0.4953, 247));
        pt.Add(new Pt(0.5066, 238));
        pt.Add(new Pt(0.5179, 229));
        pt.Add(new Pt(0.5292, 221));
        pt.Add(new Pt(0.5405, 214));

        controlPoints.pt = pt.ToArray();
        double Theta = Spline.GetSpline(controlPoints, dest).pt[0].Y;

        double x = Theta / T;
        V = a * a * a * 6.0221367 / 4 / 10000;//1molあたりの体積に直す
        //V = a * a * a   / 10000;//1molあたりの体積に直す
        double Pth = 0;
        double Eth = 9 * 4 * 8.31451 * T / x / x / x * integ(x);
        if (T > 0)
            Pth = Gamma / V * Eth / 1000000000;
        //Pth = gamma / V * DebyeFunction(Theta,T) /100000;

        return P0 + Pth;
    }

    static double DebyeFunction(double Theta, double T)
    { 		//∫z^3/(e^z-1)dz 0～xの積分を求める関数
        double x = Theta / T;
        double z = 0;
        double f = 0;
        double temp = 0;
        for (int i = 0; i < 100000; i++)
        {//10000分割で数値積分
            z = (i + 0.5) * x / 100000;
            f = z * z * z * z * Math.Exp(z) / (Math.Exp(z) - 1) / (Math.Exp(z) - 1);
            temp += f;
        }
        return 3 / x / x * temp / 100000;
    }
    */
    #endregion Brownの正攻法の解き方

    #region

    #endregion

    #region AuJamiesonの定義

    private static readonly double[][] AuJamieson =[
[  double.NaN  ,   200     ,   300     ,   400     ,   500     ,   600     ,   700     ,   800     ,   900     ,   1000    ,   1100    ,   1200    ,   1300    ,   1400    ,   1500    ],
[-0.010 , -2.28 , -1.52 , -0.75 , 0.02 , 00.79 , 01.56 , 02.33 , 03.11 , 03.88 , 04.66 , 05.43 , 06.20 , 06.98 , 07.75],
[-0.005 , -1.51 , -0.75 , 0.02 , 00.79 , 01.56 , 02.33 , 03.10 , 03.88 , 04.65 , 05.42 , 06.20 , 06.97 , 07.75 , 08.52],
[0.000 , -0.70 , 00.05 , 00.82 , 01.59 , 02.36 , 03.13 , 03.90 , 04.68 , 05.45 , 06.23 , 07.00 , 07.77 , 08.55 , 09.32],
[0.005 , 00.13 , 00.89 , 01.65 , 02.42 , 03.19 , 03.96 , 04.74 , 05.51 , 06.28 , 07.06 , 07.83 , 08.61 , 09.38 , 10.16],
[0.010 , 01.00 , 01.75 , 02.52 , 03.29 , 04.06 , 04.83 , 05.60 , 06.38 , 07.15 , 07.92 , 08.70 , 09.47 , 10.25 , 11.02],
[0.015 , 01.90 , 02.65 , 03.42 , 04.19 , 04.96 , 05.73 , 06.50 , 07.27 , 08.05 , 08.82 , 09.60 , 10.37 , 11.14 , 11.92],
[0.020 , 02.83 , 03.59 , 04.35 , 05.12 , 05.89 , 06.66 , 07.44 , 08.21 , 08.98 , 09.76 , 10.53 , 11.30 , 12.08 , 12.85],
[0.025 , 03.80 , 04.56 , 05.32 , 06.09 , 06.86 , 07.63 , 08.40 , 09.18 , 09.95 , 10.72 , 11.50 , 12.27 , 13.05 , 13.82],
[0.030 , 04.81 , 05.56 , 06.33 , 07.09 , 07.86 , 08.64 , 09.41 , 10.18 , 10.96 , 11.73 , 12.50 , 13.28 , 14.05 , 14.83],
[0.035 , 05.85 , 06.61 , 07.37 , 08.14 , 08.91 , 09.68 , 10.45 , 11.22 , 12.00 , 12.77 , 13.54 , 14.32 , 15.09 , 15.87],
[0.040 , 06.94 , 07.69 , 08.45 , 09.22 , 09.99 , 10.76 , 11.53 , 12.30 , 13.08 , 13.85 , 14.62 , 15.40 , 16.17 , 16.95],
[0.045 , 08.06 , 08.81 , 09.57 , 10.34 , 11.11 , 11.88 , 12.65 , 13.42 , 14.20 , 14.97 , 15.74 , 16.52 , 17.29 , 18.07],
[0.050 , 09.22 , 09.97 , 10.73 , 11.50 , 12.27 , 13.04 , 13.81 , 14.58 , 15.36 , 16.13 , 16.90 , 17.68 , 18.45 , 19.23],
[0.055 , 10.42 , 11.17 , 11.93 , 12.70 , 13.47 , 14.24 , 15.01 , 15.78 , 16.56 , 17.33 , 18.10 , 18.88 , 19.65 , 20.43],
[0.060 , 11.66 , 12.41 , 13.17 , 13.94 , 14.71 , 15.48 , 16.25 , 17.02 , 17.80 , 18.57 , 19.34 , 20.12 , 20.89 , 21.67],
[0.065 , 12.95 , 13.70 , 14.46 , 15.22 , 15.99 , 16.76 , 17.54 , 18.31 , 19.08 , 19.86 , 20.63 , 21.40 , 22.18 , 22.95],
[0.070 , 14.28 , 15.03 , 15.79 , 16.55 , 17.32 , 18.09 , 18.86 , 19.64 , 20.41 , 21.18 , 21.96 , 22.73 , 23.50 , 24.28],
[0.075 , 15.65 , 16.40 , 17.16 , 17.93 , 18.69 , 19.47 , 20.24 , 21.01 , 21.78 , 22.56 , 23.33 , 24.10 , 24.88 , 25.65],
[0.080 , 17.07 , 17.82 , 18.58 , 19.34 , 20.11 , 20.88 , 21.66 , 22.43 , 23.20 , 23.97 , 24.75 , 25.52 , 26.29 , 27.07],
[0.085 , 18.54 , 19.28 , 20.04 , 20.81 , 21.58 , 22.35 , 23.12 , 23.89 , 24.66 , 25.44 , 26.21 , 26.98 , 27.76 , 28.53],
[0.090 , 20.05 , 20.80 , 21.56 , 22.32 , 23.09 , 23.86 , 24.63 , 25.40 , 26.17 , 26.95 , 27.72 , 28.50 , 29.27 , 30.04],
[0.095 , 21.61 , 22.36 , 23.11 , 23.88 , 24.65 , 25.42 , 26.19 , 26.96 , 27.73 , 28.51 , 29.28 , 30.05 , 30.83 , 31.60],
[0.100 , 23.22 , 23.96 , 24.72 , 25.49 , 26.25 , 27.02 , 27.80 , 28.57 , 29.34 , 30.11 , 30.89 , 31.66 , 32.43 , 33.21],
[0.105 , 24.88 , 25.62 , 26.38 , 27.14 , 27.91 , 28.68 , 29.45 , 30.22 , 31.00 , 31.77 , 32.54 , 33.32 , 34.09 , 34.86],
[0.110 , 26.59 , 27.33 , 28.09 , 28.85 , 29.62 , 30.39 , 31.16 , 31.93 , 32.70 , 33.47 , 34.25 , 35.02 , 35.79 , 36.57],
[0.115 , 28.35 , 29.09 , 29.84 , 30.61 , 31.37 , 32.14 , 32.91 , 33.69 , 34.46 , 35.23 , 36.00 , 36.78 , 37.55 , 38.32],
[0.120 , 30.18 , 30.92 , 31.67 , 32.43 , 33.20 , 33.97 , 34.74 , 35.51 , 36.28 , 37.06 , 37.83 , 38.60 , 39.38 , 40.15],
[0.125 , 32.01 , 32.74 , 33.50 , 34.26 , 35.02 , 35.79 , 36.56 , 37.34 , 38.11 , 38.88 , 39.65 , 40.43 , 41.20 , 41.97],
[0.130 , 33.89 , 34.62 , 35.37 , 36.14 , 36.90 , 37.67 , 38.44 , 39.21 , 39.99 , 40.76 , 41.53 , 42.30 , 43.08 , 43.85],
[0.135 , 35.82 , 36.56 , 37.31 , 38.07 , 38.84 , 39.61 , 40.38 , 41.15 , 41.92 , 42.69 , 43.46 , 44.24 , 45.01 , 45.78],
[0.140 , 37.82 , 38.55 , 39.30 , 40.06 , 40.83 , 41.60 , 42.37 , 43.14 , 43.91 , 44.68 , 45.45 , 46.23 , 47.00 , 47.77],
[0.145 , 39.87 , 40.60 , 41.35 , 42.11 , 42.88 , 43.65 , 44.42 , 45.19 , 45.96 , 46.73 , 47.50 , 48.28 , 49.05 , 49.82],
[0.150 , 41.98 , 42.71 , 43.46 , 44.22 , 44.99 , 45.76 , 46.53 , 47.30 , 48.07 , 48.84 , 49.61 , 50.39 , 51.16 , 51.93],
[0.155 , 44.16 , 44.89 , 45.64 , 46.40 , 47.16 , 47.93 , 48.70 , 49.47 , 50.24 , 51.01 , 51.79 , 52.56 , 53.33 , 54.11],
[0.160 , 46.40 , 47.13 , 47.88 , 48.63 , 49.40 , 50.17 , 50.94 , 51.71 , 52.48 , 53.25 , 54.02 , 54.80 , 55.57 , 56.34],
[0.165 , 48.71 , 49.43 , 50.18 , 50.94 , 51.70 , 52.47 , 53.24 , 54.01 , 54.78 , 55.55 , 56.33 , 57.10 , 57.87 , 58.64],
[0.170 , 51.08 , 51.80 , 52.55 , 53.31 , 54.07 , 54.84 , 55.61 , 56.38 , 57.15 , 57.92 , 58.70 , 59.47 , 60.24 , 61.02],
[0.175 , 53.53 , 54.25 , 54.99 , 55.75 , 56.52 , 57.28 , 58.05 , 58.82 , 59.59 , 60.36 , 61.14 , 61.91 , 62.68 , 63.46],
[0.180 , 56.04 , 56.76 , 57.51 , 58.27 , 59.03 , 59.80 , 60.56 , 61.33 , 62.11 , 62.88 , 63.65 , 64.42 , 65.19 , 65.97],
[0.185 , 58.64 , 59.35 , 60.10 , 60.85 , 61.62 , 62.38 , 63.15 , 63.92 , 64.69 , 65.46 , 66.24 , 67.01 , 67.78 , 68.55],
[0.190 , 61.30 , 62.02 , 62.76 , 63.52 , 64.28 , 65.05 , 65.82 , 66.59 , 67.36 , 68.13 , 68.90 , 69.67 , 70.44 , 71.22],
[0.195 , 64.05 , 64.76 , 65.51 , 66.26 , 67.02 , 67.79 , 68.56 , 69.33 , 70.10 , 70.87 , 71.64 , 72.41 , 73.19 , 73.96],
[0.200 , 66.88 , 67.59 , 68.33 , 69.09 , 69.85 , 70.61 , 71.38 , 72.15 , 72.92 , 73.69 , 74.46 , 75.24 , 76.01 , 76.78],
[0.205 , 69.79 , 70.50 , 71.24 , 71.99 , 72.76 , 73.52 , 74.29 , 75.06 , 75.83 , 76.60 , 77.37 , 78.14 , 78.92 , 79.69],
[0.210 , 72.79 , 73.49 , 74.23 , 74.99 , 75.75 , 76.51 , 77.28 , 78.05 , 78.82 , 79.59 , 80.36 , 81.14 , 81.91 , 82.68],
[0.215 , 75.87 , 76.58 , 77.32 , 78.07 , 78.83 , 79.60 , 80.36 , 81.13 , 81.90 , 82.67 , 83.44 , 84.22 , 84.99 , 85.76],
[0.220 , 79.05 , 79.76 , 80.49 , 81.25 , 82.01 , 82.77 , 83.54 , 84.30 , 85.07 , 85.85 , 86.62 , 87.39 , 88.16 , 88.93],
[0.225 , 82.32 , 83.03 , 83.76 , 84.51 , 85.27 , 86.04 , 86.80 , 87.57 , 88.34 , 89.11 , 89.88 , 90.66 , 91.43 , 92.20]];

    #endregion

    private static Spline[] SplineAuJamieson = [
new ([-0.01, -0.005, 0, 0.005, 0.01, 0.015, 0.02, 0.025, 0.03, 0.035, 0.04, 0.045, 0.05, 0.055, 0.06, 0.065, 0.07, 0.075, 0.08, 0.085, 0.09, 0.095, 0.1, 0.105, 0.11, 0.115, 0.12, 0.125, 0.13, 0.135, 0.14, 0.145, 0.15, 0.155, 0.16, 0.165, 0.17, 0.175, 0.18, 0.185, 0.19, 0.195, 0.2, 0.205, 0.21, 0.215, 0.22, 0.225], [0, 0, 152.01459570248, -0.759854042975204, 79416.1719008135, 2382.48515702446, 175.839447272724, -0.68043787107439, -77080.8595040715, 35.0296859511713, 164.102169917358, -0.7, 68907.2661154663, 35.0296859511713, 164.102169917358, -0.7, -38548.2049577843, 1646.86175204991, 156.043009586864, -0.686568066115844, 5285.55371567315, 331.8489918461, 169.193137188901, -0.730401824789304, 17405.9900950931, -213.570645227778, 177.374431745012, -0.771308297569837, 5090.48590394611, 525.359606241106, 162.595826715627, -0.672784264040657, -37767.933710859, 3739.74107735152, 82.2362899378853, -0.00312145755946942, 65981.2489394712, -5597.68536117793, 362.359083093752, -2.8043493891183, -66157.0620469831, 8276.83729239888, -123.249209781472, 2.86108069442605, 38646.999248435, -4299.65006305036, 379.810284436566, -3.84637922847995, -8430.93494676391, 2055.87105330021, 93.8118342007704, 0.443597525056632, -4923.25946133291, 1529.7197304871, 120.119400341481, 0.00513808937691679, 28123.9727921025, -3923.07359133017, 420.023033041393, -5.49309517678635, -27572.6317072, 6102.315218541, -181.500295551017, 6.53737139505586, 2166.55403676267, 303.173998477006, 195.443883753372, -1.6297524898684, 18906.4155602674, -3212.19692146641, 441.519848149065, -7.37152499242954, 2207.78372205045, 544.995242138165, 159.730435879241, -0.3267896856961, -27737.5504482288, 7731.87544299532, -415.21998018983, 15.0052214094879, 28742.4180707819, -6670.5165293495, 808.983337459086, -19.6805392572451, -7232.12183502468, 3042.60924522173, -65.1979822518835, 6.54490033409969, 186.069269371935, 928.424780464172, 135.649541899918, 0.184728735947423, 6487.8447575249, -962.107865983448, 324.702806546164, -6.11704675221853, -26137.4482997274, 9314.85944701952, -754.378761319971, 31.6508081231519, 98061.9484396815, -31670.9414769125, 3754.05934031275, -133.658588936796, -206110.34545907, 73268.4999181231, -8313.97642011767, 328.949448546345, 166379.433402743, -60827.8204721326, 7777.58202671183, -314.712889326832, -59407.3881566167, 23842.2376126248, -2806.17523388265, 126.27699653126, 71250.1192250681, -27114.1902662321, 3818.16039037043, -160.777547186296, -65593.0887446209, 28307.3089614955, -3663.7420053731, 175.908060622184, 31122.23575422, -12313.1273280532, 2023.11907516008, -89.4787898029429, 21104.1457272245, -7955.25816625948, 1391.22804670291, -58.9373900941171, -35538.8186634252, 17534.0758095223, -2432.17204966022, 132.232614724177, 41051.1289270686, -18080.2498200466, 3088.04842291761, -152.978776359277, -48665.6970442082, 24983.8266461558, -3802.20381166557, 214.501342818637, 73611.6592489937, -35543.4647189964, 6184.79926357642, -334.783826319648, -85780.9399500119, 45746.7608724232, -7634.53908696816, 448.312013544488, 109512.100551738, -56782.0853909497, 10308.0090091229, -598.336625393701, -112267.462261797, 62978.8785283382, -11248.9644963411, 695.081784934591, 99557.7484993232, -54584.1134440253, 10500.1890185321, -646.116015150203, -45963.5317386156, 28363.0162915955, -5259.76563122201, 352.014446001511, 4296.37845745427, -1039.03117311141, 473.633624396607, -20.6565056149411, 28778.0179057429, -15728.0148420678, 3411.43035818322, -216.509621199926, -39408.4500790238, 26206.6629685108, -5185.17859299039, 370.925323797012, 48855.7824127302, -29399.8035013378, 6492.17936568707, -446.489733309951, 3985.32042047381, -458.355516254902, 269.768048904836, -0.550255606882274, -144797.064085156, 97738.0182574838, -21333.4341813326, 1583.68457460962, 0, 0, 657.619926602161, -65.6444834854862], 200),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.921776551344,0.00921776551343894,43128.9379462436,1293.86813838733,165.860457935217,0.0523467034596825,24355.3102687793,1012.26372322536,164.452435859407,0.05,-60550.179021361,1012.26372322536,164.452435859407,0.05,57845.405816674,-763.670049345132,173.33210472226,0.0352005518952452,-10831.444245323,1296.6354525146,152.72904970366,0.103877401957237,-14519.6288353842,1462.60375906723,150.239525105375,0.116325024948686,-11090.0404131659,1256.82845373473,154.355031212023,0.0888883175709816,58879.7904880769,-3990.90886385897,285.548464151864,-1.00439029026095,-64429.1215392031,7106.89321859619,-47.3855983217921,2.32495033447575,38836.6956687627,-3736.01758823842,332.116279917457,-2.10257157831518,-10917.66113584,2234.50522831072,93.2953672554449,1.08170725717828,4833.94887455661,108.037876907504,188.986398068496,-0.35365820501911,-8418.13436236022,2095.8503624461,89.5957737916636,1.30285219959537,28838.5885748863,-4051.50892220065,427.700534447214,-4.89573507908969,-26936.2199373217,5987.95660999814,-174.667397484505,7.15162355954916,-1093.70882554821,948.666943204288,152.886430857075,0.0546239454766758,31311.0552395416,-5856.33351046587,629.236462613575,-11.0602101288518,-44150.5121323506,11122.5191482083,-644.177486787037,20.7751386061774,65290.9932894037,-15143.4421530176,1457.09941731069,-35.2589121697748,-57013.461024974,16044.193697149,-1193.84962995273,39.8513108360194,2762.85081021878,-95.410498352894,258.71474764137,-3.72562049178792,45962.0577842694,-12407.18448594,1428.33327646332,-40.7635405711785,-26611.0819472759,9364.75743350725,-748.860915480075,31.8095991602825,-19517.7299955757,7130.35156868932,-514.248299674673,23.5981576071983,104682.001927768,-33855.5599659421,3994.20196913453,-141.711685582525,-239210.277715864,84787.2765110794,-9649.72422572304,381.305485220318,212159.108943116,-77705.7026861755,9849.43327794356,-398.660814926418,-49426.1580625776,20388.7724409591,-2412.37611294913,112.247909694067,-14454.4766919211,6749.81670639766,-639.311867452406,35.4151257226059,27244.0648300036,-10138.0926099692,1640.55589025731,-67.1789233742198,-14521.7826284002,7403.56332258615,-815.275940296496,47.4265620516778,30843.0656840779,-12330.1456933255,2046.11186701005,-90.8738486348617,-28850.4801080303,14531.9499131263,-1983.20247396139,110.591868413291,4558.85474836573,-1003.39079516203,424.775335820043,-13.8203184250653,10615.0611135583,-3910.36985038079,889.891984659212,-38.6265396970256,32980.9007973619,-14981.4604939469,2716.62194084186,-139.096687286651,-62538.664301879,33733.5177066979,-5564.9243532598,330.190936045788,57173.7564102887,-29115.5031671778,5433.65429966586,-311.392818707932,-6156.36134130867,5082.76041867185,-722.033145788228,57.9484280185471,-32548.3110447389,19730.2925041602,-3431.8265816045,225.052356560603,56349.6055217595,-30941.5199388398,6195.81778256424,-384.698453169403,-32850.1110429566,21240.3142515766,-3979.63988456764,276.706295194368,-4949.16134832706,4499.74443475949,-631.52592120599,53.4986976365835,52646.7564357389,-30921.7450024467,6629.87941341358,-442.697333563381,-45637.8643986285,30997.5661230758,-6373.17592294607,467.516539981938,49904.701159656,-30627.388661921,6876.18935584277,-482.021304996684,-153980.940232933,103937.134657219,-22728.0057743751,1688.95300455159,0,0,657.849523505862,-64.9861427888188],300),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.694105681886,0.776941056818858,52235.7727245683,1567.07318173708,168.364837499257,0.829176829543426,-21178.8636228437,465.853636525885,162.8587397732,0.82,32479.6817668122,465.853636525885,162.8587397732,0.82,-28739.8634443825,1384.14681469367,158.267273882361,0.827652443151398,2479.77201071779,447.557751040712,167.633164518891,0.796432807696297,18820.7754015183,-287.787401545581,178.663341807681,0.741281921252349,2237.1263832128,707.231539552545,158.762962985724,0.873951113398804,-27769.2809343891,2957.71208837349,102.500949265194,1.34280122773651,28839.9973543361,-2137.12295761102,255.346000644745,-0.18564928605898,-7590.70848290574,1688.10115529893,121.463156692869,1.37631722671279,1522.83657731628,594.475748071471,165.208172982026,0.793050342858273,1499.3621736221,597.644792571982,165.065565979483,0.795189447896061,-7520.28527171838,1950.59190936861,97.4182101395439,1.92264537856128,28581.7789132383,-4006.24868114721,425.04444261797,-4.08383555021402,-26806.8303813507,5963.70099187948,-173.152537763406,7.88010405742193,-1354.45738780408,1000.48825814063,149.456289929644,0.890246124068013,32224.6599326637,-6051.12637915961,643.069314540487,-10.627391116842,-47544.1823426288,11896.8631327807,-703.029898855445,23.0250892180441,77952.0694373757,-18222.2372944165,1706.49813532065,-41.2289916933103,-104264.095406557,28242.88474078,-2243.03723767079,70.6745105414742,99104.3121890034,-26666.585310014,2698.81506690052,-77.5810585957029,-52153.1533493735,16441.7923684132,-1396.4808125508,52.1033109202331,29508.3012084114,-8056.64399893009,1053.36282418664,-29.5581436376309,-65880.0514845287,21990.6870993225,-2101.6069411328,80.8657981485789,154011.904727549,-50573.6584506344,5880.47106936153,-211.810395569605,-230167.56742527,81968.2594420658,-9361.84948829853,372.478559140696,126658.364977948,-46489.0762230748,6053.03079151667,-244.11665205202,43534.107509826,-15317.4796725273,2156.58122269925,-81.7645866845093,-60794.7950174783,25370.7923131236,-3132.89413543398,147.446012167942,39645.0725604807,-15307.3540559459,2358.65562439165,-99.6737270241829,-17785.495224863,8813.48441394875,-1018.26176139043,57.915750978878,31496.9083397039,-12624.361136684,2090.22584344726,-92.3278165882222,-28202.1381342737,14240.2097766135,-1939.45979354715,109.156465261251,1311.64419765163,516.300992242199,187.746068032127,-0.749170919604982,22955.5613428509,-9872.77923742105,1849.99890476905,-89.4026555461935,-13133.889568268,7991.49896356033,-1097.60699838643,72.7156691272854,29579.9969300846,-13792.5831506307,2605.68696102339,-137.137655238862,-25186.0981527705,14959.6167679197,-2425.94802471231,156.374385596047,-8835.60431779524,6130.35009703708,-836.680023960534,61.0183055508669,60528.5154245549,-32366.7363600047,6285.280970596,-378.169289112982,-73278.4573823388,43903.2381399086,-8206.01418439193,539.61273736862,72585.3141042707,-41427.0681796519,8433.395547917,-541.948895231559,-57062.7990277819,36361.7996994881,-7124.37802791136,495.236009823682,75665.8820017017,-45266.3391335979,9609.39043288049,-648.238168331038,-85600.7289855257,56331.6257881969,-11726.1822007103,845.251916020759,106737.033945531,-67726.2313021719,14946.2570737414,-1066.272898647,-181347.406790257,122409.499583453,-26883.6037210934,2001.25022630673,0,0,658.533685169801,-64.4100791632047],400),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.694424519994,1.54694424519994,52223.0192002242,1566.69057600675,168.361330280062,1.59916726440017,-21115.0960011249,466.618847986524,162.860971639961,1.59,32237.3648042747,466.618847986524,162.860971639961,1.59,-27834.3632159406,1367.69476828971,158.355592038444,1.59750896600253,-899.911940489083,559.661230026091,166.435927421083,1.57057451472706,31434.0109778888,-895.365301300894,188.261325390986,1.46144752487755,-44836.1319710694,3680.84327563617,96.7371538522335,2.07160866846919,67910.5169064082,-4775.15539017407,308.137120497494,0.309942279758694,-66805.9356546145,7349.32534031854,-55.5973014172791,3.947286498906,39313.225712076,-3793.18660318421,334.390616605261,-0.602572544690842,-10446.9671936945,2178.03654550827,95.5416906576151,2.58207980127986,2474.64306270463,433.619160891324,174.040472965162,1.40459806666478,548.394942875844,722.556378867711,159.593612066609,1.64537908164084,-4668.22283422016,1583.29831208985,112.252805739334,2.51329386430926,18124.4963940243,-2519.39114899625,358.414173404517,-2.40993348898956,12170.2372580667,-1358.31061748278,282.943938856392,-0.774745073775764,-66805.4454263184,15226.5827462453,-877.998596604725,26.3139140869636,95051.5444469562,-21191.2399752496,1853.33810750789,-41.9695035158344,-73400.7323609984,19237.3064586618,-1380.94560720492,44.2780622098368,38551.3849967696,-9310.4834675743,1045.61653652417,-24.474531862466,-804.807626085092,1315.68854059399,89.2610557886442,4.21613255956299,-35332.1544924282,11155.9823975216,-845.566860618834,33.8190165791441,62133.4255958139,-18083.6916289708,2078.40054203087,-63.6465635091873,-53201.5478906321,18246.8250192397,-1736.30370603274,69.8680851730557,70672.7659654173,-22631.6985532066,2760.33388693864,-95.0086265691957,-149489.515971148,53324.2887148927,-5974.60464889417,239.830683970995,127285.297923766,-46314.6442873039,5982.06731136675,-238.436194439498,-39651.675727445,16286.7208319137,-1843.10332853428,87.6125822230511,31321.4049868251,-11392.7806466392,1755.23186368138,-68.3152761062757,-5633.94422022018,3574.13578219294,-265.301854216758,22.6087411992267,-8785.62810624599,4897.84301436528,-450.620866713228,31.2569617823305,40776.4566460664,-16661.6638529417,2675.50762904081,-119.839248845718,-74320.1984799011,35131.8309537608,-5093.51659195874,268.611962204499,96504.3372755131,-44301.5781724819,7218.66182260415,-367.517255881561,-71697.1506214479,36435.136018033,-5699.21244787625,321.436038544247,30284.265210031,-14045.6648185397,2630.11969015705,-136.677229047655,30560.0897805426,-14186.3353494937,2654.03368042543,-138.03235516231,-72524.6243333192,39933.1395603186,-6816.87442878925,414.437284541644,99538.4075562469,-52980.897660082,9907.65227088077,-589.034317438939,-85629.0058952111,49787.0168054719,-9104.41190524308,583.376306755167,82977.6160271745,-46318.7576902818,9155.68524893735,-573.096513009461,-86281.4582126825,52697.8007399915,-10152.5436449595,681.938365093758,102148.216813562,-60360.0042757308,12459.0173581823,-825.499035115616,-82311.4090318475,53082.6656192243,-10796.7299702819,763.643698996952,67097.4193152189,-41044.8962395415,8970.05802004877,-620.031460328028,-26078.2682380974,19053.4222323895,-3951.08045142144,305.983463461045,-122784.346353322,82879.4337885231,-17992.8029937521,1335.70978323254,0,0,655.069608658865,-62.8806619482441],500),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.694424517727,2.31694424517727,52223.0192909116,1566.69057872736,168.361330305,2.36916726446818,-21115.0964545568,466.618842545313,162.86097162409,2.36,32237.3665273189,466.618842545313,162.86097162409,2.36,-27834.3696547168,1367.6948852759,158.355591410438,2.36750896702275,-899.887908446683,559.660432887791,166.435935934319,2.34057448527648,31433.9212884899,-895.360980974609,188.261257142254,2.23144787923681,-44835.7972455177,3680.82213106612,96.7375949014352,2.84160562750889,67909.2676935822,-4775.05773936666,308.134591662279,1.07996398783526,-66801.2735288955,7348.89097065828,-55.5838696384588,4.71714860084281,39295.8264220882,-3791.3045241974,334.322972681398,0.168235440444434,-10382.0321594438,2170.03850558842,95.8692514900957,3.34761838966074,2232.30221567401,467.103364942676,172.501332819159,2.19813716972852,1452.82329669641,584.025202790733,166.655240926645,2.29557203460078,-8043.59540252954,2150.93428816668,80.4752412311216,3.8755386956873,30721.558313532,-4826.79338072322,499.138901364414,-4.49773450697922,-34842.6378516322,7958.22487148329,-331.887285028877,13.5078328648744,28648.9930931299,-5375.01762691472,601.439689858806,-8.26979654916931,246.665478964685,1015.50608626441,122.150411370557,3.71243541304246,-29635.6550087108,8187.26300331713,-451.590141993087,19.0121835027287,38295.9545559226,-9135.29743567025,1020.82749532031,-22.7063162211282,-43548.1632150903,12962.6143625077,-967.984566516143,36.958045633943,55896.6983047092,-15379.1711706347,1724.48505913365,-48.3034925116245,-20038.6300037822,7401.42732189587,-553.574790119331,27.6318357968151,-55742.1782898037,18648.0450319559,-1734.46964967719,68.9631558813916,163007.343160699,-53539.2970466315,6206.13797897005,-222.192457168973,-276287.194353022,98017.318395589,-11222.8727968854,445.919622572075,222141.434259331,-81416.9879049138,10309.243959171,-415.365047670219,-52278.5426908814,21490.503451448,-2554.19246037337,120.611469810764,-13027.2634947783,6182.50456498406,-564.152605130599,34.3764094168997,24387.5966699179,-8970.51380173409,1481.50487437696,-57.6781771608823,-4523.12318473639,3171.98853723443,-218.44545307995,21.6528381205231,-6295.10393104042,3942.8001618594,-330.213138650934,27.0549429230682,29703.5389094454,-12256.5891163383,2099.69525307909,-94.4404766634275,-32519.0517071959,16676.9155203914,-2384.99796562043,137.268672969095,20372.6679189774,-8711.10990017722,1677.08610168465,-79.375810620031,31028.3800310964,-13985.6873957065,2547.39138843351,-127.242601391339,-64486.1880419215,34726.742321584,-5733.72166350447,342.020471551155,66916.3721372595,-34259.6017725258,6338.88855296692,-362.21512440914,-43179.3005097831,25192.0614568453,-4362.41082832862,279.862838468429,25800.8299034662,-13091.9109224852,2720.12406186082,-156.893479759576,19975.9808949811,-9771.74698757665,2089.29291422977,-116.940840409725,-25704.7534826188,16951.4826232815,-3121.73685987899,221.776094908806,2843.03303563129,-177.189287684392,303.997522306046,-6.60619723870332,14332.6213386226,-7243.28609406762,1752.54736759607,-105.590436666622,19826.4816115648,-10704.4180660471,2479.38508171868,-156.469076656038,-13638.5477901101,10880.5258980691,-2161.37787055224,176.118934925646,-125272.290442944,84558.7960489392,-18370.5973037556,1364.79502669303,0,0,655.131807261099,-62.1346566337474],600),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.694105659392,3.08694105659392,52235.7736242996,1567.07320872906,168.364837746683,3.13917683021822,-21178.8681215094,465.853582541877,162.858739615747,3.13,32479.6988617336,465.853582541877,162.858739615747,3.13,-28739.9273254069,1384.14797534913,158.267267651712,3.13765245327339,2480.01043991778,447.549842388828,167.633248981309,3.10643251550806,18819.885565728,-287.744538272544,178.662664691234,3.05128543695847,2240.44729716598,707.02175784118,158.767338768961,3.18392094310701,-27781.6747543661,2958.68091170779,102.475859922314,3.6530166001625,28886.2517203112,-2141.43247101453,255.479261403959,2.12298258534582,-7763.3321267981,1706.77383293209,120.792040765846,3.69433349279046,2167.07678687983,515.124763292981,168.458003551436,3.05878732231568,-904.975020724856,929.851757315316,149.795288820335,3.33872804328047,1452.82329604951,576.182009797996,167.478776196232,3.04400325368602,-4906.3181635925,1625.44035064169,109.769567449849,4.10200541403025,18172.4493583028,-2528.73780329802,359.020256686593,-0.883008370691113,12216.5207303142,-1367.33172084168,283.528861326883,0.752638528768467,-67038.5322795199,15276.2294112293,-881.520417918133,27.937121711143,95937.6083874443,-21393.4022388481,1868.70195583732,-40.8184376327496,-76711.9012697506,20042.4800788803,-1446.16862958135,47.5781113117599,50909.9966912646,-12501.1039011693,1320.03600872305,-30.7976867735542,-46928.0854953392,13915.1782892043,-1057.42938840976,40.5262751404524,56802.3452900912,-15647.9944846379,1751.07202510442,-48.4096029541799,-20281.2956651294,7477.09780191778,-561.437203548299,28.674038000963,-55677.1626300117,18626.7958958295,-1732.15550341108,69.6491784962226,162989.94618296,-53533.3500123743,6205.46054649214,-221.396743333665,-276282.622101804,98015.6860458332,-11222.6786002023,446.681923956351,222140.542232285,-81416.6531144533,10309.2020990306,-414.593304013002,-52279.5468336722,21490.880285291,-2554.23957593718,121.383432443917,-13022.3548966522,6180.57542985615,-563.899944730639,35.1353817583054,24368.9664204646,-8962.90970359206,1480.47054828202,-56.8612904273729,-4453.51078508135,3142.53072275055,-214.29111140147,22.2275870247279,-6554.9232801612,4056.64515811294,-346.8377045302,28.6340056926976,30673.203906257,-12696.0120757949,2166.0608805592,-97.0109235618684,-36137.8923456486,18371.1476813683,-2649.34888180276,151.785247493198,33878.365475936,-15236.6560729913,2727.89971888923,-135.001344543717,-19375.5695573074,11124.0417684617,-1621.61542494435,104.221988367494,43623.9127523597,-21005.6942095076,3840.43969130499,-205.29446822011,-75120.0814536238,41334.9027487051,-7069.16477637179,431.099125727689,96856.4130657874,-51532.4042918313,9646.95049091546,-571.867790309875,-72305.5708130844,42352.4967609136,-7721.7562038526,499.202455867574,32365.8701890981,-17310.2246103469,3614.16085670618,-218.73895796685,22842.0900538233,-11738.8132311625,2527.73563774486,-148.121318735271,-43734.2303990638,28206.9790405659,-5461.42281657737,384.489244887227,72094.8315387852,-43027.8940512091,9141.72616721271,-613.392602340842,-84645.095763132,55718.2601489574,-11594.9662147937,838.175864400808,106485.55151853,-67561.0073476434,14910.076296974,-1061.35218227422,-181297.110304832,122375.549455777,-26875.9661997855,2002.95760082034,0,0,658.532427757666,-62.1297962454746],700),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.920519172695,3.85920519172695,43179.2330921969,1295.37699276595,165.874289100355,3.90238442481915,24103.8345390078,1009.24601446808,164.443634208865,3.9,-59594.5712482154,1009.24601446808,164.443634208865,3.9,54274.4504538587,-698.789311063049,172.98381083652,3.88576637228724,2496.76943281024,854.541119568323,157.450506530208,3.93754405330828,-64261.5281851047,3858.66451237459,112.388655638112,4.16285330776874,94549.3433076102,-5669.98777718757,302.961701429371,2.89236633582715,-73935.8450452879,6966.40134927895,-12.9480267323189,5.52494740384087,41194.0368735425,-3395.28802341666,297.902654448565,2.41644059203206,-10840.3024488833,2068.31760543746,106.676457438608,4.6474128904813,2167.1729219502,507.420560937652,169.11233921863,3.8149344667492,2171.61076107673,506.821452661412,169.139299091055,3.81453006865743,-10853.6159661262,2460.60546173836,71.4500986373471,5.44268340955823,41242.8531034588,-6135.31193474279,544.225555443695,-3.22486663189861,-74117.7964479666,14629.6049845149,-701.669459711623,21.6930336712161,95228.3326887699,-18392.890197151,1444.79272709656,-24.8136470429654,-66795.5343071893,15632.121872002,-936.95811774382,30.7605393366497,11953.8045401265,-2086.47936864267,391.936975303721,-2.46183798954142,18980.31614655,-3772.84215418934,526.845998148165,-6.05941193203338,-7875.0691262032,3075.28109036871,-55.2444776394963,10.4331515486203,12519.9603584522,-2431.37687050261,440.354738838892,-4.43482494573485,-42204.7723077496,13165.1719393696,-1041.31739809888,42.4847927239008,76299.1288720974,-22385.9984145908,2513.79963729899,-76.0191084559751,-102991.743180451,34090.6262819385,-3416.24595583768,131.532487303885,175667.843847105,-57867.03743708,6699.0970532573,-239.363423029618,-279679.632208021,99227.8418018768,-11366.8140592258,453.163169615539,223050.684992586,-81755.0723903396,10351.1356438359,-415.55481850702,-52523.1077688224,21585.0998952164,-2566.38589185521,122.675245480093,-12958.2539161502,6154.80689266674,-560.447801525077,35.751261565848,24356.1234333784,-8957.51593387175,1479.7157800602,-56.0560996053446,-4466.23981702927,3147.87663128891,-215.039179062757,23.032465153445,-6491.16416539484,4028.71872282395,-342.761282334499,29.2057001449844,30430.8964792396,-12586.2085672885,2149.47781118037,-95.4062545306552,-35232.4217522958,17947.2344104501,-2583.20585035855,149.115734649042,30498.7905297729,-13603.7474849621,2464.95125290039,-120.119310858546,-6762.74036646257,4840.71030863987,-578.384283048857,47.2641436186726,-3447.82906337766,3150.1055440769,-290.981473073575,30.977984386751,20554.0566199542,-9450.88443968267,1914.19177408246,-97.6571216974842,1231.60258312002,983.240740233292,36.0492417023206,15.0314302448951,-25480.466952356,15808.4393324173,-2706.61249784973,184.162237518055,20690.2652276143,-10508.8780101512,2293.67779723823,-132.52281450469,22719.4060404061,-11695.9253857181,2525.15203546826,-147.568639989053,-31567.8893855857,20876.4518699725,-3989.32341566822,286.729723419725,23552.1514971405,-13022.3732730132,2959.93573863246,-188.136318790144,17359.2834001258,-9120.86637186259,2140.61928942241,-130.78416734573,-12989.2851029038,10453.9603126347,-2067.96844774857,170.831287152134,-125402.142980337,84646.4465117157,-18390.315411564,1367.80339783151,0,0,655.135053574537,-60.6053870542712],800),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.677782542104,4.63677782542104,52888.6983158512,1586.66094947557,168.544392036859,4.68966652373689,-24443.4915792613,426.678101048824,162.744477794726,4.68,44885.2680012126,426.678101048824,162.744477794726,4.68,-75097.5804255808,2226.42082745069,153.745764162716,4.69499785605334,95505.0537011067,-2891.6581963503,204.926554400724,4.52439522192664,-66922.634378851,4417.5877672479,95.2878649467484,5.07258866919655,12185.483814268,-328.899324339038,190.21760677848,4.43972372365161,18180.6991218264,-778.540472405609,201.458635480134,4.34604848447068,-4908.2803016099,1299.46767570477,139.118391036876,4.96945092890413,1452.42208464197,631.593925146722,162.493972306394,4.69673581409306,-901.408036951639,914.053539741394,151.195587722597,4.84738094187693,2153.21006323787,501.680096211923,169.752392681377,4.56902886749414,-7711.43221594812,1981.37643809208,95.7675755875569,5.80210915239449,28692.5188005485,-4025.27547963223,426.133431062159,-0.254598197975875,-27058.6429863815,6009.93364201378,-175.979116236219,11.787652747997,-457.946854953475,822.797896391373,161.184707229151,4.48243657290176,28890.4304062177,-5340.36132846015,592.605852968299,-5.58405682766344,-35103.7747698382,9058.33483615171,-487.296359377921,21.4134984809717,31524.6686729867,-6932.4915901292,791.969754724566,-12.7002645617491,-10994.899921959,3909.99840158686,-129.641894569547,13.4120655015944,12454.9310147783,-2421.45595134022,440.188997191318,-3.68286125125973,-38824.8241372483,12193.2742669911,-948.210373549524,40.2831188222461,62844.3655340731,-18307.4826344001,2101.86531659113,-61.3860708490929,-52552.6379987697,18042.5734784305,-1714.89057525542,72.2003853655709,67366.1864597112,-21530.6385928471,2638.16275258278,-87.4115699885669,-136912.107839934,48945.372940518,-5466.57857375298,223.270180854294,80282.244902886,-29244.594046878,3916.21746473533,-152.041660685197,55783.1282264948,-20057.4252932463,2767.8213705308,-104.191823426727,-63414.7578092621,26429.7502606711,-3275.51145148208,157.685932193784,37875.9030111551,-14592.9673715529,2262.55542887347,-91.527077422133,-8088.85423556026,4712.23067203465,-440.17229723179,34.6002164627964,-5520.48606893134,3594.99051958182,-278.172475119191,26.7702250608658,30170.7985117907,-12466.0875417504,2130.98923407385,-93.6878603990655,-35162.7079786773,17913.9929763129,-2577.92324622857,149.60595108321,30480.0334028093,-13594.522886798,2463.43929187371,-119.266717615543,-6757.42563217177,4838.01933550988,-577.930174807779,48.0086030518398,-3450.3308739717,3151.40100882856,-291.20505927406,31.7608465048549,20558.7491277874,-9453.36599213311,1914.62916589714,-96.9128166299108,1215.33436218786,992.077981373106,34.4492506697216,15.8979782840283,-25420.0865766205,15774.736602394,-2700.34259422072,184.543475385096,20465.01194511,-10379.7695550469,2269.01357568659,-130.182415375588,23560.0387945848,-12190.3602619992,2622.07876352905,-153.131652585609,-34705.1671197666,22768.7632866898,-4369.74594618462,312.989994728909,35260.6296808682,-20260.2017457243,4451.19188544992,-289.774090433057,-26337.3516055718,18546.5264645889,-3698.22103872336,280.684814258828,70088.7767406702,-43648.3263186216,9673.6723096855,-677.634209041484,-174017.755349278,117461.984860763,-25770.5961497836,1921.61214465136,0,0,658.350443883774,-60.5588498738477],900),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.694105656992,5.40694105656992,52235.7737203412,1567.07321161029,168.364837773095,5.45917683029025,-21178.8686017088,465.853576779472,162.85873959894,5.45,32479.7006865084,465.853576779472,162.85873959894,5.45,-28739.9341443325,1384.14809924228,158.267266986626,5.45765245435385,2480.03589082095,447.548998187059,167.633257997178,5.42643248431866,18819.7905810087,-287.73996287095,178.662592413052,5.37128581223932,2240.80178513815,706.999364880634,158.767805857988,5.50391772260639,-27782.9977215001,2958.78432788005,102.473181783041,5.97303958989773,28891.1891008425,-2141.89248613112,255.493486203383,4.4428365456939,-7781.75868176507,1708.76703104166,120.72040310228,6.01518918187426,2235.84562622422,506.654514081086,168.804903780759,5.37406250616238,-1161.62382314353,965.312889747835,148.165276875591,5.68365690973661,2410.64966637573,429.471866320252,174.957328047254,5.23712272354281,-8480.97484237203,2226.58991025743,76.1158356304733,7.04921675118486,31513.2497030507,-4972.37050791789,508.053460720935,-1.58953575062507,-37572.0239699199,8499.25785831823,-367.602383084326,17.3830075318097,38774.8461766643,-7533.58487246703,754.696608070531,-8.80396892846005,-37527.3607366574,9634.41168303477,-532.903133591302,23.3860246131091,31334.5967698734,-6892.45811852599,789.246450533799,-11.8712976302614,-7811.02634261514,3089.67577514856,-59.2349304291725,12.1690081636976,-90.4913995739335,1005.1313405326,128.374068687203,6.54073819024171,8172.99194096451,-1349.96141151422,352.107880129706,-0.544165838801401,-32601.4763638648,10882.3790799143,-871.126169011402,40.2303024658879,42232.9135139896,-12690.453731611,1604.02127619746,-46.3998581163877,23669.8223070107,-6564.63363326424,930.181065381328,-21.6923837198513,-136912.202742155,48836.1650086675,-5440.9107784415,222.532803626766,123978.988666084,-45084.6638982925,5829.58869039262,-228.28717512656,-39003.7519254213,16033.8638234892,-1810.22727483326,90.0384900909529,32036.0190362229,-11671.6468515371,1791.48911292026,-66.0358867115945,-9140.32421991146,5004.77216722617,-459.827454608266,35.2733588272024,4525.27784390767,-734.780699592853,343.709946743864,-2.22505323591082,-8960.78715610421,5131.6575753924,-506.923603130538,38.8889016748358,31317.8707812157,-12993.7384963959,2211.88580764243,-97.0515688638148,-36310.6959695332,18453.5450426862,-2662.44314092389,154.788760145286,33924.9130965745,-15259.5473090594,2731.65163535636,-132.89629458944,-19388.9564162534,11130.8180998393,-1622.75865710016,106.596271495677,43630.912567729,-21009.3150819475,3841.06398380646,-203.020344822638,-75134.6938560783,41342.6282905153,-7070.52610637557,433.489077104774,96907.8628603016,-51560.3523363361,9652.01040645361,-569.863113664924,-72496.7575883018,42459.2120126168,-7741.60899811221,502.743416282799,33079.1674952311,-17719.0652850108,3692.26368844445,-221.401853864986,20180.087605489,-10173.1035495067,2220.80115000202,-125.756788867133,-33799.5179133825,22214.6597618437,-4256.75151224772,306.080055283499,35017.9840444364,-20108.1039422676,4419.41504708212,-286.791326272127,-26272.4182662815,18504.849513419,-3689.30517861433,280.819089527358,70071.6890198886,-43637.099686116,9671.2138993144,-676.684777722694,-174014.337805182,117459.678018481,-25770.0771957189,1922.3432359118,0,0,658.350358445172,-59.7888306501647],1000),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,149.52305955175,6.15523059551751,99077.61792998,2972.3285378994,179.246344930745,6.25430821344748,-95388.0896498978,55.3429242012253,164.661416862254,6.23,42474.7406695863,55.3429242012253,164.661416862254,6.23,5489.1269715628,610.127129671464,161.887495834903,6.23462320171225,15568.7514441306,307.738395494522,164.911383176674,6.22454357723967,-67764.132748095,4057.71818414496,108.661686346917,6.50579206138846,95487.7795482723,-5737.39655363737,304.563981102559,5.19977676301743,-74186.9854450152,6988.21082086085,-13.576203259879,7.85094496603787,41260.1622318059,-3402.03247005356,298.131095467486,4.73387197876336,-10853.6634821053,2069.91922990658,106.61278596882,6.96825225624748,2154.49169664954,508.940608458223,169.051930826939,6.13573032480898,2235.69669553665,497.977933605265,169.545251195129,6.12833051928504,-11097.2784786354,2497.92420973414,69.5479373889764,7.79495241605363,42153.4172190368,-6288.44058038603,552.798000845549,-1.06463208064953,-77516.3903978432,15252.1247906572,-739.635921417229,24.7840463646112,107912.144372806,-20906.4394896243,1610.67075680108,-26.1392649967918,-114132.187093428,25722.8701182931,-1653.38091575224,50.0219406961309,108616.604000647,-24395.607877873,2105.5049339591,-43.9502055466719,-80334.2289084316,20952.5920203002,-1522.35105789531,52.7926209027691,52720.3116328939,-12976.3158177368,1361.60610833874,-28.9194988071759,-50547.0176231964,14905.8630813958,-1147.78999258304,46.3623842204589,69467.7588598267,-19298.3482162381,2101.61008069167,-56.5352847665554,-67324.0178156928,21739.1847864012,-2002.14321957139,80.256491908908,39828.3124023827,-12013.7992323273,1541.92010239481,-43.7857243598614,68010.7682045534,-21314.0096469884,2564.94324800891,-81.2965730323044,-231871.385221207,82145.3332848701,-9332.88118915497,374.786697058897,219474.772687859,-80339.2835623865,10165.2728325141,-405.139463807978,-86027.7055365467,34224.1457717736,-4155.15583425234,191.545063974047,44636.0494598115,-16734.7186768533,2469.49654406238,-95.5232057530828,-12516.4923034488,6412.06073732155,-655.318676846769,45.0934791879156,5429.91975437865,-1125.4323269797,399.930352151655,-4.15147549855479,-9203.18671412411,5239.96898678798,-523.052838347701,40.4593787086515,31382.8271026586,-13023.7372306915,2216.50309428371,-96.5184179225829,-36328.1216967473,18461.8539609901,-2663.7635404285,155.628691537308,33929.6596839079,-15261.8811017156,2732.0340695987,-132.147180997297,-19390.517037915,11131.6063755501,-1622.89136414544,107.373717858723,43632.408466828,-21010.0856318682,3841.19627711554,-202.257915145885,-75139.1168308216,41344.9651494191,-7070.93760961281,434.283228246338,96924.0588601191,-51569.1497236341,9653.60306755324,-569.189212382967,-72557.1186124453,42492.9037736525,-7747.87682945291,503.902047931359,33304.4155923592,-17848.170723212,3716.92732493612,-222.202215180299,19339.4562406172,-9678.669502398,2123.87458689106,-118.653787206218,-30662.2405514214,20322.3485728605,-3876.32902814646,281.35978713003,23309.5059604235,-12870.2755319234,2928.15891330317,-183.6135555371,17424.2167128921,-9162.54330600798,2149.53514587879,-129.109891817556,-13006.3728166521,10465.1869405508,-2070.42685712874,173.320718398783,-125398.725437641,84644.1396703869,-18389.7964577042,1370.07448910736,0,0,655.134968135972,-58.2953678305936],1100),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.69435715936,6.95694357159359,52225.7136256222,1566.77140876863,168.362071247046,7.00916928521922,-21128.5681281248,466.457182462479,162.860500115516,7,32288.5588868919,466.457182462479,162.860500115516,7,-28025.6674194413,1371.17057705754,158.336933142541,7.00753927828829,-185.889209137287,535.977230748185,166.68886660563,6.97969950007799,28769.2242559822,-767.0028751821,186.233568194594,6.88197599213319,-34891.0078147714,3052.61104906299,109.841289709673,7.39125784869923,30794.8070031153,-1873.82506227984,233.002192493235,6.36491699216974,-8288.22019776371,1643.64738580042,127.478019050857,7.42015872659354,2358.07378798807,525.786517298353,166.603149448409,6.96369887195553,-1144.0749541697,946.044366357862,149.792835486108,7.1878363914529,2218.2260286876,492.13373367036,170.218813957095,6.8814467143894,-7728.82916050509,1984.19201204854,95.6159000380491,8.12482861304127,28697.0906132165,-4026.08475061822,426.181121984927,2.06446621068669,-27059.5332924475,6010.10755240106,-175.990416196389,14.1078969743093,-458.95744339682,822.995261845308,161.171882689536,6.80271383176838,28895.3630660406,-5341.41204514924,592.68039417914,-3.26581810297756,-35122.4948206866,9062.6059793704,-487.620957659527,23.7417156930016,31594.6162164947,-6949.50066953889,793.347574253754,-10.4174451580262,-11255.9700449766,3977.39882712158,-135.438882962383,15.8981711297707,13429.2639634064,-2687.61435513974,464.412303441817,-2.09736446234548,-42461.0858088046,13241.1353299481,-1048.8189166434,45.8216241736385,76415.0792715216,-22421.7141941723,2517.46603577075,-73.0545409068089,-103199.231277016,34156.7936285807,-3423.27728562152,134.871475341972,176381.845834002,-58104.9618179644,6725.51581350071,-237.250938292591,-282328.15205902,100149.987455075,-11473.803352901,460.389629752727,232930.762410348,-85343.2217538972,10785.381752175,-429.97777445026,-89394.8975894314,35528.9007460146,-4323.63356031328,199.564530236805,44648.8279487625,-16748.1522138535,2472.38332447186,-94.9295347706088,-9200.41420609342,5060.79085883926,-471.823990344773,37.5597943960723,-7847.17112468048,4492.4287646467,-392.253297153311,33.8464953805295,40589.0987053861,-16577.3486114281,2662.86442237135,-113.817527729931,-74509.2236986761,35216.8964704142,-5106.27233990589,274.639310383796,97447.7960914877,-44743.1177320123,7287.52986147705,-365.707136687255,-75281.9606666471,38167.165511921,-5978.11545754079,341.79394699371,43680.046574324,-20719.0280723444,3738.10648384957,-192.598259782981,-19438.2256300201,11471.290751816,-1734.2477162596,117.50181155646,34072.8559459903,-16622.0270755706,3182.08290353661,-169.284141264826,-36853.1981551559,21678.0421390563,-3711.92955508064,244.356606253117,33339.9366760539,-17279.1476922737,3495.15056368744,-200.080001072371,-16506.5485501006,11133.3488866415,-1903.22378628761,141.817041093836,32686.2575241087,-17644.4426667942,3708.44556661474,-222.941466845361,-34238.4815426478,22510.4007731979,-4322.52312138258,312.456445687647,24267.6686411053,-13470.8815898057,3053.63976302138,-191.581351413653,17167.8069814518,-8997.96874418855,2114.32806544192,-125.829532583361,-12938.8965715766,10420.8550475836,-2060.71904975176,173.382177339867,-125412.220686585,84653.2489634752,-18391.8457112536,1370.9981325171,0,0,655.135305517189,-57.5254437413679],1200),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.92496029455,7.7292496029455,43001.588218007,1290.04764654017,165.825436759952,7.77225119116351,24992.0589099631,1019.90470691958,164.474722061849,7.77,-62969.8238578628,1019.90470691958,164.474722061849,7.77,66887.236521547,-927.951198771658,174.214001590305,7.75376786745257,-44579.122228331,2416.03956372472,140.774093965344,7.86523422620242,31429.2523918342,-1004.33729418375,192.079746833949,7.60870596185938,-1137.88733904349,949.691089670404,152.999179156899,7.86924307970646,-26877.7030356095,2880.17726691251,104.737024725834,8.27142769996525,28648.6994814333,-2117.19895962261,254.658311521906,6.77221483200466,-7717.09489017272,1701.20944939884,121.014017206144,8.33139826568816,2219.68007924497,508.796453066017,168.710537059506,7.69544466764345,-1161.62542686741,965.272696393608,148.169106109803,8.00356613189059,2426.82162824828,427.005638123163,175.082459023031,7.55501025000178,-8545.66108609708,2237.46528598866,75.5071783904517,9.38055706159516,31755.8227160921,-5016.80179840874,510.763203454451,0.675436560321642,-38477.6297784038,8678.72143803157,-379.445806914076,19.9632984516319,42154.6963975588,-8254.0670589291,805.849387873192,-7.69358942672502,-50141.1558116775,12512.4996881548,-751.643118157432,31.2437232240537,78409.9268486007,-18339.7601503184,1716.53766891969,-34.5744310980239,-103498.55158248,28046.9018496112,-2226.32860107393,77.1401132184519,95584.2794813174,-25705.4625376069,2611.38419377496,-67.991270627036,-38838.5663427926,12605.0485222568,-1028.11435691071,47.2595168114287,-20230.0141099777,7022.48285240197,-469.857789926412,28.6509645786055,39758.6227821515,-11873.9377686228,1514.26637528312,-40.7933812036209,21195.5229803736,-5748.11483400758,840.42585247325,-16.0858953674361,-124540.714703552,44530.8871669277,-4941.65937763387,205.560705119902,76967.3358364401,-28012.0110274513,3763.48840569199,-142.645206213123,56671.3713559626,-20401.0243472813,2812.11507067285,-103.004650587152,-63652.8212606602,26525.4107732004,-3288.32149499254,161.347600591627,37939.9136873263,-14619.6468807081,2266.2612882887,-88.6086246558207,-8106.83348839697,4719.98693308925,-441.287445645875,37.743649594217,-5512.57973362611,3591.48654974058,-277.654890059224,29.8347427410393,30157.1524235031,-12459.8929209601,2130.05203054597,-90.5506032893047,-35116.0299610273,17892.136887839,-2574.51258982556,152.518568762931,30306.9674202881,-13510.9018552535,2449.97360907381,-115.454028511075,-6111.83972036874,4516.40767940549,-524.532464143113,48.1438055156486,-5859.6085383637,4387.76977662087,-502.664020675804,46.9045937187062,29550.2738741979,-14202.4184899609,2750.61892598735,-142.870244836433,-32341.486959467,19219.1323601602,-3265.26022705722,218.082504345509,19815.6739644014,-9728.0919525571,2089.97627082378,-112.15707968852,33078.7911011653,-17288.0687205747,3526.37185672622,-203.128800129916,-72130.8383664868,44259.5645181242,-8475.4166247994,576.987451169409,95444.5623558518,-56285.6759153507,11633.6314618803,-763.615754609993,-69647.4110466838,45245.8877271656,-9180.33908484783,658.672232750163,23145.0818274841,-13213.3827835843,3096.10772241466,-200.679043759243,57067.0837323368,-35093.0740120709,7800.24133656919,-537.808619438671,-171413.41674763,115704.056304619,-25375.1273331232,1895.05174967181,0,0,658.285335418732,-57.4542004692138],1300),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.677782551188,8.50677782551188,52888.6979524857,1586.66093857457,168.544391936933,8.55966652346436,-24443.4897624126,426.678122851008,162.744477858316,8.55,44885.2610971543,426.678122851008,162.744477858316,8.55,-75097.5546262047,2226.42035870184,153.745766679062,8.56499785196542,95504.9574077261,-2891.65500231681,204.926520289244,8.39439533993148,-66922.2750046996,4417.57045624269,95.28813841085,8.94258724932337,12184.1426111,-328.814600705267,190.215839549822,8.30973590839712,18185.7045603001,-778.931746894506,201.468768204521,8.2159615029409,-4926.96085229381,1301.20814023838,139.064571590618,8.84000346908076,1522.1388489607,624.052671604642,162.765012992629,8.56349831938911,-1161.59454361606,946.10067871817,149.883092708158,8.73525725651601,3124.23932561989,367.513106369589,175.919533463996,8.34471064518075,-11335.3627587984,2536.45341903018,67.472517830728,10.1521609057323,42217.2117096421,-6299.72136826425,553.462131131781,1.24235132854102,-77533.4840801055,15255.403873897,-739.845383397408,27.1085016191363,107916.724611179,-20907.3868209126,1610.73601176519,-23.8207619427251,-114133.414364792,25723.142364041,-1653.40103118199,52.342435726046,108616.932847652,-24395.6857587478,2105.51107802698,-41.6303670041776,-80334.3170250951,20952.6142107097,-1522.35291952948,55.1126729306508,52720.3352525089,-12976.3221200759,1361.60666858853,-26.5995153993418,-50547.0239850675,14905.8648740559,-1147.79016088612,48.6823894848343,69467.7606878587,-19298.3487577369,2101.61013413417,-54.2152865241053,-67324.0187661677,21739.1850784714,-2002.14324948484,82.5764929298728,39828.3143759843,-12013.7998613195,1541.92016919354,-41.4657267237478,68010.7612606894,-21314.0073332064,2564.94299110068,-78.9765635271535,-231871.35941927,82145.3243013591,-9332.88014687202,377.106656761908,219474.676424169,-80339.2486023065,10165.2686015665,-402.819293175702,-86027.3462837573,34224.0099131639,-4155.13871286961,193.864344925701,44634.708712256,-16734.1915352785,2469.427475425,-93.2001899004925,-12511.4885658574,6410.01836237991,-655.040860754128,47.4008852276423,5411.24555147849,-1117.52996694791,398.815905346787,-1.77909719043077,-9133.49364054969,5209.43158158632,-518.593519190561,42.5623583288866,31122.7290110476,-12905.8686116364,2198.70150979822,-93.3023931204295,-35357.422404593,18007.4017966517,-2592.85540349066,154.261380732692,30306.960606719,-13511.5020487391,2450.16921177267,-114.699932081494,-5870.42002187387,4396.30136245282,-504.618351067865,47.8133838747446,-6825.28051864812,4883.28021575326,-587.404756132399,52.5046134955298,33171.5420966429,-16115.051657375,3087.3033216635,-161.853357709325,-45860.8878695432,26562.4605244303,-4594.64887106955,299.063773854726,70272.0093831622,-37891.2974507584,7329.29635435417,-436.246181712505,-75227.1496652847,45043.2232068314,-8428.26257058373,561.732550199219,70636.5892779897,-40287.0640750398,8211.14344936932,-519.828841096256,-47319.2074419511,30486.4139569188,-5943.55215703044,423.817532661807,38640.2404843606,-22378.6465176418,4893.78524025623,-316.733856152918,-27241.7544964999,19127.0103201717,-3822.40269567259,293.399299362325,70326.7775015533,-43804.6928184927,9707.91347911954,-676.273359831888,-174065.355501473,117494.114963472,-25777.8242328987,1926.01407238375,0,0,658.351633887582,-56.699117624705],1400),
new ([-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18,0.185,0.19,0.195,0.2,0.205,0.21,0.215,0.22,0.225],[0,0,152.924960294593,9.27924960294593,43001.5882162957,1290.04764648895,165.825436759482,9.32225119116222,24992.0589185163,1019.90470702232,164.474722062149,9.32,-62969.8238903852,1019.90470702232,164.474722062149,9.32,66887.2366430224,-927.951200979051,174.214001602153,9.30376786743333,-44579.1226817112,2416.03957876266,140.774093804735,9.41523422675804,31429.25408383,-1004.33737568555,192.079748121467,9.15870595517438,-1137.89365358052,949.691488558357,152.999170836587,9.41924313707341,-26877.6794695364,2880.17542475666,104.737072431645,9.82142729044764,28648.6115317025,-2117.19076535443,254.658058135028,8.32221743341431,-7716.76665724015,1701.17394448243,121.015293290585,9.88138302326531,2218.45509724102,508.947333944771,168.704357711993,9.24552883097841,-1157.05373172081,964.641025856494,148.198141576178,9.5531220730176,2409.75982968481,429.618991643768,174.949243286816,9.10727037784026,-8481.98558696031,2226.75698538888,76.1066536305907,10.9193845215394,31518.1825182558,-4973.27327354874,508.10846916721,2.27934821080844,-37590.7444860579,8502.96749229407,-367.847180612718,21.258387289362,38844.7954259413,-7548.49588923081,755.75525609467,-4.95900290045753,-37788.4372176421,9693.98145558572,-537.430544767559,27.3706421210921,32308.9534445383,-7129.39230333688,808.43935594794,-8.51922189799211,-11447.3765602851,4028.47184787813,-139.979096907003,18.3526342662362,13480.5527966384,-2702.06907848619,465.76958646602,0.180173765072871,-42474.8346262655,13245.2163370367,-1049.22252800803,48.1549240567662,76418.785708214,-22422.8697633075,2517.58608202836,-70.7386962778161,-103200.308206302,34157.1448197147,-3423.31544919163,137.192857314971,176382.447114214,-58105.1644359586,6725.53856893581,-234.93179001648,-282329.480250806,100150.450504936,-11473.8571492709,462.711712514776,232935.473897361,-85344.9329884015,10785.5888699315,-427.666128253281,-89412.4153455782,35535.5254777061,-4324.46843833332,201.919592924306,44714.1874864185,-16773.8496267838,2475.75032525138,-92.7565534975638,-9444.33460060288,5160.35181846088,-485.366869856079,40.4937202822699,-6936.84908405906,4107.20790157027,-337.92672148969,33.6131800251775,37191.7309379316,-15088.7244080311,2445.48346340199,-100.918312244657,-61830.0746683286,29471.0881147811,-4238.48841502163,233.280281676371,50128.56773757,-22589.6806040029,3830.93073639073,-183.639707813002,21315.803716495,-8759.55387388654,1618.11045956792,-65.6226263828234,-55391.7826035807,29210.7013546145,-4646.98165312362,278.957439815739,40251.3266973997,-19567.284388912,3645.27592326497,-190.937156179833,-25613.5241866587,15011.7623252063,-2406.05725169773,162.057279026897,62202.7700511019,-32409.0365631552,6129.68654820464,-350.087348967697,-63197.556019585,37188.1444060808,-6745.7919310997,443.900490589013,30587.4540295308,-16269.3113220201,3411.12465722018,-199.370893338424,20847.739899494,-10571.5785559207,2300.06676784295,-127.152130528353,-33978.4136240697,22324.1135582798,-4279.0716549987,311.457097661179,35065.9145932235,-20138.1482954472,4425.6920250142,-283.368420472398,-26285.2447510511,18513.0820913687,-3691.06635623425,284.804666212644,70075.0644105673,-43639.3173177242,9671.69951675832,-672.860221348237,-174015.012883246,117460.133696184,-25770.1797063164,1926.2109216759,0,0,658.350375322123,-55.9288344474769],1500) ];

    public static double Au_Jamieson(double a, double a0, double T)
    {
        if (SplineAuJamieson == null)
        {
            InitializeSpline(ref SplineAuJamieson, AuJamieson);
            string code = deveropper(SplineAuJamieson);
            Clipboard.SetDataObject(code, true);
        }
        return GetPressureFromSplineMethods(SplineAuJamieson, 1 - a * a * a / a0 / a0 / a0, T);
    }

    #region PtJamiesonの定義

    private static readonly double[][] PtJamieson = [
        [double.NaN, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500],
        [-0.010, -3.20, -2.56, -1.92, -1.26, -0.61, 0.04, 0.70, 1.36, 2.01, 2.67, 3.33, 3.98, 4.64, 5.30],
        [-0.005, -1.92, -1.28, -0.63, 0.02, 0.67, 1.33, 1.98, 2.64, 3.30, 3.95, 4.61, 5.27, 5.92, 6.58],
        [0.000, -0.59, 0.05, 0.69, 1.34, 2.00, 2.65, 3.31, 3.96, 4.62, 5.28, 5.93, 6.59, 7.25, 7.91],
        [0.005, 0.78, 1.41, 2.06, 2.71, 3.37, 4.02, 4.68, 5.33, 5.99, 6.65, 7.30, 7.96, 8.62, 9.27],
        [0.010, 2.19, 2.83, 3.47, 4.12, 4.78, 5.43, 6.09, 6.74, 7.40, 8.06, 8.72, 9.37, 10.03, 10.69],
        [0.015, 3.65, 4.29, 4.93, 5.58, 6.24, 6.89, 7.55, 8.20, 8.86, 9.52, 10.17, 10.83, 11.49, 12.15],
        [0.020, 5.16, 5.79, 6.44, 7.09, 7.74, 8.40, 9.05, 9.71, 10.36, 11.02, 11.68, 12.34, 12.99, 13.65],
        [0.025, 6.71, 7.35, 7.99, 8.64, 9.30, 9.95, 10.61, 11.26, 11.92, 12.58, 13.23, 13.89, 14.55, 15.20],
        [0.030, 8.32, 8.95, 9.60, 10.25, 10.90, 11.55, 12.21, 12.87, 13.52, 14.18, 14.84, 15.49, 16.15, 16.81],
        [0.035, 9.97, 10.61, 11.25, 11.90, 12.56, 13.21, 13.87, 14.52, 15.18, 15.83, 16.49, 17.15, 17.81, 18.46],
        [0.040, 11.68, 12.32, 12.96, 13.61, 14.26, 14.92, 15.57, 16.23, 16.89, 17.54, 18.20, 18.86, 19.51, 20.17],
        [0.045, 13.45, 14.08, 14.73, 15.38, 16.03, 16.68, 17.34, 17.99, 18.65, 19.31, 19.96, 20.62, 21.28, 21.93],
        [0.050, 15.27, 15.90, 16.55, 17.20, 17.85, 18.50, 19.16, 19.81, 20.47, 21.13, 21.78, 22.44, 23.10, 23.75],
        [0.055, 17.15, 17.78, 18.43, 19.07, 19.73, 20.38, 21.04, 21.69, 22.35, 23.00, 23.66, 24.32, 24.98, 25.63],
        [0.060, 19.09, 19.72, 20.36, 21.01, 21.67, 22.32, 22.97, 23.63, 24.29, 24.94, 25.60, 26.26, 26.91, 27.57],
        [0.065, 21.09, 21.72, 22.37, 23.01, 23.67, 24.32, 24.98, 25.63, 26.29, 26.94, 27.60, 28.26, 28.91, 29.57],
        [0.070, 23.16, 23.79, 24.43, 25.08, 25.73, 26.39, 27.04, 27.70, 28.35, 29.01, 29.67, 30.32, 30.98, 31.64],
        [0.075, 25.29, 25.92, 26.56, 27.21, 27.86, 28.52, 29.17, 29.83, 30.48, 31.14, 31.80, 32.45, 33.11, 33.77],
        [0.080, 27.49, 28.12, 28.76, 29.41, 30.06, 30.72, 31.37, 32.03, 32.68, 33.34, 34.00, 34.65, 35.31, 35.97],
        [0.085, 29.77, 30.39, 31.03, 31.68, 32.33, 32.99, 33.64, 34.30, 34.95, 35.61, 36.27, 36.92, 37.58, 38.24],
        [0.090, 32.11, 32.74, 33.38, 34.03, 34.68, 35.33, 35.98, 36.64, 37.30, 37.95, 38.61, 39.27, 39.92, 40.58],
        [0.095, 34.53, 35.16, 35.80, 36.44, 37.10, 37.75, 38.40, 39.06, 39.71, 40.37, 41.03, 41.68, 42.34, 43.00],
        [0.100, 37.03, 37.65, 38.29, 38.94, 39.59, 40.25, 40.90, 41.55, 42.21, 42.87, 43.52, 44.18, 44.84, 45.49],
        [0.105, 39.61, 40.23, 40.87, 41.52, 42.17, 42.82, 43.48, 44.13, 44.79, 45.44, 46.10, 46.76, 47.41, 48.07],
        [0.110, 42.27, 42.89, 43.53, 44.18, 44.83, 45.48, 46.14, 46.79, 47.45, 48.10, 48.76, 49.42, 50.07, 50.73],
        [0.115, 45.02, 45.64, 46.28, 46.93, 47.58, 48.23, 48.88, 49.54, 50.19, 50.85, 51.51, 52.16, 52.82, 53.48],
        [0.120, 47.85, 48.48, 49.11, 49.76, 50.41, 51.06, 51.72, 52.37, 53.03, 53.68, 54.34, 55.00, 55.65, 56.31],
        [0.125, 50.78, 51.40, 52.04, 52.69, 53.34, 53.99, 54.64, 55.30, 55.95, 56.61, 57.27, 57.92, 58.58, 59.24],
        [0.130, 53.81, 54.43, 55.07, 55.71, 56.36, 57.01, 57.67, 58.32, 58.98, 59.63, 60.29, 60.95, 61.60, 62.26],
        [0.135, 56.93, 57.55, 58.19, 58.83, 59.48, 60.13, 60.79, 61.44, 62.10, 62.75, 63.41, 64.07, 64.72, 65.38],
        [0.140, 60.16, 60.77, 61.41, 62.06, 62.71, 63.36, 64.01, 64.67, 65.32, 65.98, 66.63, 67.29, 67.95, 68.60],
        [0.145, 63.49, 64.10, 64.74, 65.39, 66.04, 66.69, 67.34, 68.00, 68.65, 69.31, 69.96, 70.62, 71.28, 71.93],
        [0.150, 66.93, 67.54, 68.18, 68.83, 69.47, 70.13, 70.78, 71.43, 72.09, 72.74, 73.40, 74.06, 74.71, 75.37],
        [0.155, 70.48, 71.10, 71.73, 72.38, 73.03, 73.68, 74.33, 74.99, 75.64, 76.30, 76.95, 77.61, 78.27, 78.92],
        [0.160, 74.16, 74.77, 75.40, 76.05, 76.70, 77.35, 78.00, 78.66, 79.31, 79.97, 80.62, 81.28, 81.94, 82.59],
        [0.165, 77.95, 78.56, 79.20, 79.84, 80.49, 81.14, 81.79, 82.45, 83.10, 83.76, 84.41, 85.07, 85.73, 86.38],
        [0.170, 81.87, 82.48, 83.12, 83.76, 84.41, 85.06, 85.71, 86.37, 87.02, 87.68, 88.33, 88.99, 89.65, 90.30],
        [0.175, 85.93, 86.54, 87.17, 87.81, 88.46, 89.11, 89.76, 90.42, 91.07, 91.73, 92.38, 93.04, 93.70, 94.35],
        [0.180, 90.11, 90.72, 91.36, 92.00, 92.65, 93.30, 93.95, 94.60, 95.26, 95.91, 96.57, 97.23, 97.88, 98.54]];

    #endregion

    private static Spline[] SplinePtJamieson = [
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,253.780631695855,-0.662193683041451,88774.7321658,2663.24196497404,280.413051345595,-0.57341895087565,-43873.6608290059,673.516070051928,270.464421870985,-0.59,6719.91115022998,673.516070051928,270.464421870985,-0.59,16994.0162281134,519.404493883671,271.234979751826,-0.591284263134737,5304.02393734665,870.104262606556,267.727982064595,-0.579594270843969,-38210.1119774855,2828.24037877341,238.35594032209,-0.432734062131448,67536.4239725555,-3516.5517782291,365.25178346214,-1.2787063497317,-71935.5839127527,6943.84881316937,103.741768677178,0.90054377347621,60205.9116784049,-4948.88579003461,460.523806773272,-2.66727660748524,-8888.06280083636,2305.98153028712,206.603450562015,0.295127548313325,-24653.6604750514,4197.85325118844,130.92858172591,1.30412579946119,27502.7047009684,-2843.25604756963,447.778500170111,-3.44862297720247,-5357.15832880556,2085.72340689968,201.329527446793,0.658859901520692,-6074.07138572585,2204.01406128744,194.823541455459,0.778136311361618,29653.4438716993,-4226.93868505124,580.680706236138,-6.93900698424696,-32539.7041012363,7900.72516967216,-207.617444321477,10.1407862778356,20505.3725333387,-3238.74092357689,572.145182206814,-8.05367500782025,30518.2139676208,-5491.63024628982,741.111881409989,-12.2778424879042,-62578.2284031339,16851.5159226824,-1046.33981210906,35.3875360059355,59794.699644833,-14353.5807295565,1606.0934033315,-39.7647384315653,-16600.5701762918,6273.14212215213,-250.311653322842,15.9274132680743,6607.58106047519,-341.180980320172,378.049041413428,-3.97067539854785,-9829.75406534997,4590.01955740747,-115.071012359308,12.4666597272066,32711.4352006026,-8810.45506135494,1291.97882260925,-36.780084496713,-41015.9867364775,15519.5941778803,-1384.32659370428,61.3511141014929,51352.5117450398,-16347.5377982322,2280.39358354854,-79.1298260266247,-4394.06024411196,3721.2281178596,-127.85832638279,17.2002503706922,-33776.2707682994,14739.5570644365,-1505.14944470093,74.5873803006947,59499.1433178708,-21637.8544291927,3223.91404946594,-130.338704446694,-44220.3025040868,20368.5211287012,-2446.94665085308,124.850027067491,37382.0666996898,-13904.4739368513,2351.27265833636,-99.0668740279517,-25307.9642963103,13365.6895463753,-1602.90104674129,92.051521717493,63849.7904870862,-26755.3001061674,4415.24740113797,-208.855900676314,-70091.197653532,35527.2593792388,-5238.54931909428,289.923596535951,56515.0001262911,-25243.7155550756,4484.80667039077,-228.655389569933,4031.19714925438,735.766918510199,198.19206225127,7.10841387801338,7360.21127593517,-962.030285999179,486.817587029189,-9.24703252618201,-193472.042254716,104474.902817532,-17964.6457061023,1067.08832623926,0,0,840.836801056288,-61.2406241901323],200),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,253.554532236112,-0.024454677638884,97818.7105555354,2934.5613166661,282.900145402772,0.0733640329166508,-89093.5527776782,130.877366667859,268.881725652782,0.05,98555.5005551799,130.877366667859,268.881725652782,0.05,-65128.4494430191,2586.13661664081,256.605429402917,0.0704604937497742,1958.29721690226,573.534216842885,276.731453400892,0.00337374708984619,57295.2605754061,-1916.62913428973,314.083903667882,-0.183388504245115,-71139.3395185457,5789.44687134672,159.962383555137,0.844088296506457,67262.0974988022,-4590.66090495307,419.465077962648,-1.31843415688926,-37909.0504767123,4874.74241284345,135.502978428757,1.52118683844925,4374.1044081079,435.011149935702,290.893572630429,-0.291703427237287,20412.6328442161,-1489.61226239656,367.878509123757,-1.31816924714945,-6024.63578501883,2079.41900255166,207.272102201235,1.09092685669026,3685.91029589853,622.837090413344,280.101197807866,-0.122891403421741,-8719.0053985672,2669.64817999819,167.526587880588,1.94097644524853,31190.1112985453,-4513.99282548379,598.54504820948,-6.67939276133316,-36041.4397956964,8596.15963789514,-253.614861909683,11.7840719579148,32975.6478843424,-5897.42877490713,760.936326987045,-11.8887891163421,-15861.1517417051,5090.85114095871,-63.184666702933,8.71423572590106,30468.9590823014,-6028.37545681294,826.35346111754,-15.0067810159703,-26014.684587283,8374.95367892967,-397.929515419382,19.6812366526069,-6410.2207334491,3081.74843838752,78.4589562281542,5.38958250317076,51655.5675213141,-13467.0012142149,1650.59017322683,-44.3945727017594,-40212.0493518187,14093.2838477472,-1105.43833296772,47.4730441713696,29192.6298855407,-7769.19011206279,1190.12143281039,-32.8715476308498,3441.52980933583,728.672913130157,255.356500037318,1.40316657065166,-42958.7491234264,16736.7691449236,-1585.57456661458,71.9721907924897,88393.4666871038,-30550.0285468725,4088.84115640142,-155.004438128121,-70615.117627611,29078.1905711203,-3364.68623334934,155.559203111557,34067.0038240459,-11747.8367950091,1942.69732424371,-74.4274177176793,14347.1023312184,-3761.27669038623,864.511710122602,-25.909065082525,-11455.4131493868,7075.77981141481,-652.676200137959,44.8930373965476,31474.550267131,-11598.7542747383,2055.13124235835,-85.9843223239191,-34442.7879199667,18064.0479094239,-2394.28908526419,136.486694057281,26296.6014140733,-10179.7681308696,1983.50240098475,-89.6991993986048,9256.38226282597,-2000.46293822303,674.813570164843,-19.9024617550313,16677.8695353046,-5674.09913817048,1280.9635431543,-53.2407102693105,4032.13959529996,775.223131224513,184.578757364303,8.88776092533953,-192806.427918583,104115.471076041,-17899.9646329917,1063.81945869559,0,0,840.820160697887,-60.6276289256196],300),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,256.996022129559,0.649960221295592,40159.1148176298,1204.77344452898,269.043756574849,0.690119336113222,39204.425911845,1190.45311094216,268.972154906915,0.69,-36976.8184650093,1190.45311094216,268.972154906915,0.69,28702.8479482027,205.258114744035,273.898129887905,0.681790041698348,2165.42667220641,1001.38075302379,265.936903505105,0.708327462974336,-37364.5546370035,2780.22991193835,239.254166121395,0.841741149892961,67292.791875792,-3499.21087882994,364.842981936748,0.00448237779054839,-71806.612866165,6933.24447681724,104.031598045594,2.17791057688348,59933.659588821,-4923.38004413166,459.730333674012,-1.37907677940144,-7928.02548911264,2202.0968890499,210.33864101256,1.53049296831539,-28221.5576323975,4637.32074624753,112.929686724812,2.82927902548606,40814.2560187347,-4682.51409665536,532.322254655302,-3.46160949347225,-55035.4664424174,9694.94427251579,-186.550663802985,8.51960581416976,99327.6097508854,-15774.9632993791,1214.29425265111,-17.1625509874958,-102274.972561487,20513.5015168473,-963.013636322495,26.3836067919885,69772.2804953805,-13035.7128292408,1217.68529617307,-20.8648700787647,-16814.1494200607,5147.43745299831,-55.135223583084,8.83427538222507,-2515.6828152473,1930.28246691602,186.151400372468,2.80210978330669,26876.8806806543,-5123.93277209549,750.488619493639,-12.2468827265624,-24991.8399072167,8102.59097781496,-373.765899247306,19.6069953044397,-6909.52105212565,3220.36488693861,65.6344489298512,6.42498485911167,52629.9241159222,-13748.3769859778,1677.66492685562,-44.6226469418818,-43610.1754115926,15123.652872282,-1209.53805897169,51.6174525856426,41810.7775301032,-11783.9473043312,1615.75995957487,-47.2679780634816,-43632.9347081187,16412.4777342576,-1485.84679466984,66.4576029255415,52720.961302089,-16829.6163892267,2336.9940295299,-80.0846286688195,-7250.91050061636,4760.2574597118,-253.790832341791,23.5467658061905,-23717.3192992087,10935.1607591929,-1025.65374477756,55.7077204908914,22120.1876976301,-6941.46696956314,1298.30785995695,-44.9972823810724,15236.5685087848,-4153.60119805986,921.94598081718,-28.0609978192548,-3066.46173251324,3533.67150323019,-154.272197372125,22.1625171625299,-2970.72157881915,3492.02453638936,-148.233387184606,21.8706413367968,14949.3480471,-4572.0067953153,1061.37131256568,-38.6095936510565,23173.3293908481,-8396.15812012739,1654.11476793361,-69.2346721774193,-27642.6656101681,15995.5194803923,-2248.55364817218,138.907643347018,7397.33305028826,-1349.27985651791,613.338242437691,-18.496410635591,78053.3334070444,-37383.8400384784,6739.21347336471,-365.629340388114,-239610.666680664,129389.760007575,-22446.166534692,1336.85116008157,0,0,843.990266666922,-60.5582480000463],400),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,254.460123272649,1.28460123272649,61595.0690940485,1847.85207282149,272.938644000864,1.34619630182054,12024.6545297573,1104.2958543571,269.220862908542,1.34,-29693.6872130744,1104.2958543571,269.220862908542,1.34,26750.0943225622,257.639131322458,273.454146523715,1.33294452730805,2693.30992282842,979.342663314433,266.237111203794,1.35700131170777,-37523.3340138726,2789.09164046585,239.090876546523,1.49273248499411,67400.0261326534,-3506.30996832508,364.998908722376,0.653345603821909,-72076.7705167823,6954.44978038196,103.479915004664,2.83267055146891,60907.0559344246,-5014.09460022511,462.536246422911,-0.757892762713341,-11551.4532208924,2594.04886108359,196.25122527712,2.3487658173206,-14701.2430508496,2972.02364067488,181.132234093283,2.55035236643844,-9643.57457580974,2289.23839654453,211.857570079282,2.08947232665058,53275.5413541094,-7148.62899293975,683.750939553752,-5.77541716458933,-43458.5908406879,8812.50281920189,-194.111310114281,10.3187240793235,40558.8220087314,-6310.63149369044,713.276748659278,-7.82903709615442,-38776.6971943625,9159.79475090928,-292.300957239764,13.9584798649973,34547.9667688833,-6238.38468137628,785.571603020694,-11.1918798744005,-19415.1698811991,5903.32106489032,-125.056327950201,11.5738183998398,43112.7127556767,-9103.370767956,1075.47901867744,-20.440457510221,-73035.6811412597,20514.469675765,-1442.03741903936,50.8891748917514,89030.0118094547,-23243.2674209177,2496.15891966435,-67.2567152693334,-43084.3660963914,14409.3302822327,-1080.83786213475,46.0148494876386,3307.45257614104,491.784680460144,310.916698038886,-0.37696918487043,29854.5557913848,-7870.55283232712,1188.96213688217,-31.1085595442914,-42725.6757409114,16080.9235733598,-1445.70026773993,65.4957286251071,61048.1471723783,-19721.0453317541,2671.52615634618,-92.331284298333,-41466.9129503411,17184.3763124184,-1757.1244409532,84.8147395938289,24819.5046304121,-7673.03028035197,1350.05138314507,-44.6509197435619,22188.8944283161,-6647.09230155041,1216.67944589527,-38.871469129511,-33575.0823440169,15937.318291263,-1832.21598413085,98.3288252217136,32111.434948629,-11651.0189716496,2030.15123267662,-81.9149782293821,-14870.6574513516,8786.19122236868,-933.244245457798,61.3158032140041,27371.1948577079,-10222.6423167273,1918.08078541284,-81.2504483297007,-14614.1219793316,9300.5300124567,-1108.01092561509,75.0976234070731,31085.2930590175,-12635.1892059017,2401.70414930745,-112.087180589297,-29727.0502554998,17466.920734752,-2565.14399087802,161.089467121928,87822.9079611599,-42483.5579557568,7626.43738648668,-416.433477596613,-241564.581591487,130444.874059409,-22636.0382161513,1348.87759922468,0,0,844.03911453969,-59.9270406171436],500),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,253.785409773557,1.92785409773557,88583.6090577066,2657.50827173123,280.360492490869,2.01643770679328,-42918.0452885328,684.983456537625,270.497868414901,2,3088.5720964245,684.983456537625,270.497868414901,2,30563.7569028365,272.855684441477,272.558507275383,1.9965656018992,-45343.5997077501,2550.07638275897,249.786300292204,2.07247295850977,70810.6419281922,-2676.8644908584,328.190413396473,1.6804523929885,-77898.9680050222,6245.71210513381,149.738881476607,2.87012927245407,80785.2300919034,-5655.60275213556,447.271752908338,0.39068867718952,-85241.9523627001,9286.84366877939,-1.00163971911317,4.87342260346447,100182.579358957,-10182.7321619945,680.433514358021,-3.07665419410257,-75488.3650731161,10897.7811698546,-162.787018915954,8.1662862495517,41770.8809334894,-4932.21704103336,549.562900574175,-2.51896254279993,-11595.1586607193,3072.68889809145,149.317603617981,4.15179240647148,4609.75370936786,398.878357028814,296.377183376238,1.45570011089953,-6843.85617684548,2460.52813655127,172.678196605004,3.92967984631922,22765.6709980634,-3313.32966255783,547.978953546844,-4.2018365540925,-4218.82781530235,2353.4150882546,151.306820989874,5.05384653891502,-5890.35973669662,2729.50977055383,123.099719817285,5.75902406821085,27780.266761834,-5351.4405890849,769.575748588853,-11.4803366990325,-25230.7073104804,8166.35779935265,-379.437114427459,21.0750277531257,-6857.437520214,3205.57495598815,67.0333414744528,7.68091407606376,52660.4573915468,-13757.0250938733,1678.48034621282,-43.348241073951,-43784.3920458907,15176.4297373576,-1214.86513691211,53.0966083634568,42477.1107915342,-11995.9436564147,1638.23406943292,-46.7618638586077,-46124.0511193285,17242.4397741311,-1577.9881079265,71.1662826446784,62019.0936857002,-20066.9451835585,2712.59116220828,-93.3059227105747,-41952.3236250779,17362.7650483164,-1778.97406561838,86.356686402361,25790.2008161711,-8040.68161716845,1396.45676756936,-45.9529316469877,18791.5203603528,-5311.19623939521,1041.62366846294,-30.5768306854688,-20956.2822578171,10786.6638209322,-1131.58743968503,67.2176691810788,-14966.3913299634,8270.90963127586,-779.381853126764,50.7814084750332,80821.8475786209,-33396.9742939459,5262.461316016,-241.241011366864,-68320.9989849823,33717.3066596623,-4804.68082702016,262.116095784539,32462.1483626002,-13146.856857005,2459.26451806544,-113.187747044554,18472.4055333436,-6431.78029899672,1384.85226877197,-55.8857604155637,-26351.7704952061,15756.1868351623,-2276.16230835859,145.47004132648,86934.6764453948,-42019.9011044353,7545.77264138684,-411.106272492092,-241386.935288399,130348.945055708,-22618.7754366435,1348.49236539262,0,0,844.034673382113,-59.276241208781],600),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,256.99633602761,2.6099633602761,40146.5588956003,1204.39676686805,269.04030369629,2.6501099191717,39267.2055219916,1191.20646626393,268.97435219327,2.65,-37215.3809835705,1191.20646626393,268.97435219327,2.65,29594.3184123038,189.060975325838,273.98507964796,2.64164878757552,-1161.89266564491,1111.74730766403,264.758216324575,2.67240499865345,-24946.7477497439,2182.06578644779,248.703439142808,2.75267888456221,20948.883664553,-571.672098409224,303.778196839947,2.38551383324806,21151.2130915892,-586.846805436527,304.157564515651,2.38235243595043,-25553.7360309843,3616.59861559818,178.054201884656,3.64338606226028,1063.73103250606,821.76457392827,275.873393342987,2.50216216191258,21298.8119009865,-1606.44513029123,373.001781511862,1.20711698633107,-6258.97863643459,2113.85659226487,205.588203996917,3.71832064905614,3737.10264482198,614.444400070571,280.558813606567,2.46881048888959,-8689.4319429221,2664.82260704222,167.788012222944,4.53627518092593,31020.6251267449,-4482.9876654872,596.656628575317,-4.04109714611648,-35393.0685642125,8467.68260424927,-245.136938958044,14.1977634837707,30551.6491302283,-5380.70811158203,724.250411150324,-8.4212746854258,-6813.52795677105,3026.45673298976,93.7130478068308,7.34215939815906,-3297.53730297968,2182.6189760715,161.220068360635,5.54197218337565,20003.6771685848,-3759.19071416777,666.273892032012,-8.76788615395111,3282.8286286383,755.438391625928,259.957272509256,3.42161243169548,-33134.9916831418,11134.5171804788,-726.055212431425,34.6453411215098,49257.1381040041,-13583.1217556704,1745.70868118446,-47.7467886656527,-3893.56073277487,3159.34837793032,-12.2506828451673,13.7817890753878,-33682.8951721655,12989.8287429225,-1093.60352299454,53.4313932141185,58625.1414216431,-18856.4438819565,2568.71782886565,-86.9575919404985,-40817.6705161786,16942.968415676,-1727.21164684621,84.8795870881478,24645.5406445362,-7605.73576963344,1341.37637631822,-42.978247210378,22235.5079376383,-6665.82301393381,1219.18771807227,-37.6834053533658,-33587.5723961426,15942.5245212761,-1832.9391991804,99.662305923137,32114.7816479422,-11652.4641772586,2030.35921861311,-80.6249535737075,-14871.5541966916,8786.59191515198,-933.303914787288,62.6187645406592,27371.4351396475,-10222.7532861892,1918.09786541437,-79.9513244699074,-14614.1863621231,9300.56071212515,-1108.01580432971,76.3978818002397,31085.3103087246,-12635.1976898462,2401.70553998067,-110.78725656282,-29727.0548716933,17466.9230743796,-2565.14438610151,162.38948937197,87822.9091759622,-42483.5585898608,7626.4374968186,-415.133483993355,-241564.581834465,130444.874190599,-22636.0382397659,1350.17760064034,0,0,844.039114545765,-58.6270406182377],700),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,253.785409891598,3.23785409891598,88583.6043360645,2657.50813008197,280.360491192418,3.32643770325205,-42918.021680329,684.983739836064,270.497869241188,3.31,3088.4823852503,684.983739836064,270.497869241188,3.31,30564.0921393488,272.84959352447,272.558539972747,3.30656554878073,-45344.8509426572,2550.11788598471,249.785857048143,3.38247449186274,70815.311631316,-2677.08942984421,328.193966785582,2.99043394317557,-77916.3955826632,6246.81300299364,149.715918128822,4.18028760088742,80850.270699354,-5660.68696815666,447.403417407618,1.69955844023085,-85484.6872149595,9309.45924413192,-1.70096896110536,6.19060230391711,101088.478160512,-10280.7231202936,683.9554137939,-1.80872216155617,-78869.2254272087,11314.2013102326,-179.841563427303,9.70857086805933,54388.4235482665,-6675.58130145387,629.698654098572,-2.43453239482904,-58684.468765755,10285.3525456477,-218.348038256466,11.6995791444209,100349.451514764,-15955.2443006363,1224.8847882893,-14.7596893422464,-102713.337293544,20596.0576848592,-968.193330840876,29.1018730403559,70503.8976599437,-13181.3031310607,1227.3351221943,-18.467910108738,-19302.2533459284,5677.98858015743,-92.8152975918394,12.3355996862553,6705.11572374159,-173.669460507062,346.059055459417,1.36374085999199,-7518.20954884904,3239.92860490841,72.971210224879,8.6460833995589,23367.7224718098,-4635.98406035883,742.423786773433,-10.3217396026021,-5952.68033830566,3280.52469836199,29.9379984879239,11.0528340459427,442.998881348529,1457.75612074891,203.101013361395,5.56933857495191,4180.68481286408,336.450341295114,315.231591307399,1.83165264343384,-17165.7381329871,7060.57356925156,-390.801347629479,26.5428055062061,64482.2677185443,-19883.2683617099,2573.02126478126,-82.1306902821235,-80763.3327411964,30226.4637968895,-3189.59793345827,138.769712317031,98571.0632497552,-34333.9187598726,4557.64797335149,-171.120123955423,-73520.9202606844,30200.5750565275,-3509.16375370099,164.997031338343,35512.6177939244,-12322.5047847805,2018.83662566486,-74.549651767412,11470.4490847524,-2585.42645752364,704.331051494115,-15.3969009296583,-1394.4141327087,2817.81609374086,-52.1229056882821,19.9042837389868,-5892.79255431169,4774.61070716829,-335.858124638165,33.6181526545192,24965.5843502153,-9111.65889990737,1747.08231642118,-70.5288693983193,-13969.5448463727,8993.17617653683,-1059.16712041886,74.4606848387957,30912.5950344764,-12550.250966318,2387.78122242959,-109.376560113786,-29680.8352912217,17443.497044906,-2561.18719942495,162.816703088756,87810.7461282611,-42477.2094789445,7625.3329096511,-414.419436425436,-241562.149224907,130443.560581446,-22635.8018509299,1350.81342460797,0,0,844.039053730525,-57.977029671494],800),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,254.460118782146,3.90460118782146,61595.2487141629,1847.857461425,272.938693396396,3.96619643653562,12023.7564291701,1104.28507715007,269.220831475021,3.96,-29690.2744308542,1104.28507715007,269.220831475021,3.96,26737.3412942386,257.870841273731,273.452902654402,3.95294654803436,2740.90925390232,977.763802483641,266.253973042302,3.97694298007467,-37700.9783098122,2797.64874285081,238.9556989368,4.11343435060222,68063.0039853132,-3548.19019485722,365.872477690953,3.2673224922412,-74551.0376314084,7147.8629263976,98.4711496595787,5.49566689250226,70141.1465402998,-5874.43364905608,489.140046923208,1.58897791986631,-46013.5485297471,6321.80933329764,62.2715425407796,6.56911047099337,33913.0475785456,-3269.3821996951,445.91920386062,1.4538083200666,-9638.64178442161,2610.09586430264,181.342690980642,5.42245601326284,4641.51955913677,468.071662768855,288.443901057084,3.63743584531692,-8927.4364522616,2706.94940465127,165.30562525381,5.89497090171825,31068.2262501019,-4492.26988178113,597.258782439365,-2.74409224199754,-35345.4685483137,8458.40060390809,-244.534799129741,15.4947686920137,30313.647943153,-5330.01385927544,720.654213293734,-7.0263082645455,-5909.123224329,2820.10965338783,109.394949843571,8.25517332172503,-6677.15504585707,3004.43729055609,94.64873886961,8.64840561433972,32617.7434078584,-7015.76181513862,946.365662853488,-15.4835738985518,-43793.8185859156,13615.3599232008,-910.435293596067,40.2204547949469,62557.5309360029,-16694.7746905591,1969.0274947113,-50.9625335014149,-46436.3051576787,16003.3761375317,-1300.7875881,58.031302592196,43187.689694151,-12228.1822407733,1663.52604162432,-45.7196744481363,-46314.4536180068,17307.5250522026,-1585.40176060636,73.4076783002662,62070.1247777346,-20085.1544942952,2714.75638724427,-91.4317173671678,-41966.045494476,17367.866803727,-1779.60616851964,88.3427848631907,25794.0572019376,-8042.1717074591,1396.6486453772,-44.0011657157404,18789.8166866631,-5310.51790648369,1041.53365125679,-28.612849303737,-20953.3239485496,10785.454050779,-1131.42256297771,69.17018033653,-14976.5208929596,8275.19676737735,-779.986543298719,52.7698327516379,80859.4075215305,-33413.4320929315,5264.86464143393,-239.397974510554,-68461.1091945034,33780.8004293115,-4814.27023690006,264.558769406201,32985.0292580836,-13391.6539511336,2497.46019208175,-113.213969423879,16520.9921612889,-5488.91614468768,1233.02214303869,-45.7772734750615,-19068.9979025424,12128.1289369166,-1673.79029541463,114.097410640097,59754.9994471967,-28072.1097114831,5160.25027481467,-273.164888340281,-219950.999888808,118773.539939955,-20537.7384141982,1225.88445185241,0,0,841.49877499713,-56.8697794994845],900),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,257.000777189557,4.58000777189558,39968.9124176961,1199.06737253092,268.991450914867,4.61997668431327,40155.4379115202,1201.86525493823,269.005440326903,4.62,-40590.6640637804,1201.86525493823,269.005440326903,4.62,42207.218343605,-40.102981172482,275.215281507457,4.60965026469908,-48238.2093106548,2673.25984845545,248.081653211184,4.70009569235332,70745.6188990258,-2681.01242098059,328.395737252716,4.29852527214568,-74744.2662854808,6048.38069009001,153.807875031281,5.46244435362174,68231.4462429228,-4674.7977495401,421.887336022017,3.22844884536537,-38181.5186862781,4902.36909408777,134.572330713274,6.10159889845341,4494.6285021801,421.373639296345,291.40717163075,4.27185908774739,20203.0046774242,-1463.63150172791,366.807377271896,3.2665230125319,-5306.64721189891,1980.17150332873,211.836242044406,5.59109004094934,1023.5841702028,1030.63679601499,259.312977410307,4.7998111181887,1212.31053098265,999.496946486376,261.025669133969,4.76841176991018,-5872.82629421505,2274.82157501888,184.506191422372,6.2988013241575,22278.9946459062,-3214.78350829469,541.330521837896,-1.43239250152286,-3243.15228937762,2144.86734810405,166.154961889265,7.32170389728277,-9306.38548831515,3509.09481785683,63.8379016573509,9.8796304030833,40468.6942423179,-8436.924317486,1019.51943248554,-15.6052104190018,-72568.3914809741,20387.5325419487,-1430.5594005677,53.8136898507943,89804.8716817306,-23453.2485119849,2515.1108942878,-64.5564189947728,-46651.0952461317,15436.7020624365,-1179.43441028443,52.4375156499222,16799.5093025842,-3598.47930214354,724.083726178045,-11.0130888987606,-20546.9419644881,8165.65284696975,-511.150149480975,32.2200967492227,65388.258554625,-20192.9633243004,2608.2976293609,-82.159655141581,-81006.0922542066,30313.0877047046,-3199.89823897689,140.487853144691,98636.1104651712,-34358.1052742481,4560.64491849919,-169.933873154256,-73538.3496094291,30207.3172537226,-3510.03289750063,166.344369179014,35517.2879737153,-12324.3814037134,2019.08792796565,-73.2508665914587,11469.1977139533,-2584.90484851366,704.258593016405,-14.0835465183803,-1394.07882889052,2817.67129948857,-52.1020677069473,21.2132843153383,-5892.88239860401,4774.65085234211,-335.864102873285,34.9284493478906,24965.6084239585,-9111.67001782963,1747.08402765686,-69.218957178342,-13969.5512968665,8993.17925235489,-1059.16760922008,75.7707107276146,30912.5967630446,-12550.2518163789,2387.78136177547,-108.06656772572,-29680.8357537687,17443.4972794205,-2561.18723902572,164.126705318631,87810.7462501824,-42477.2095426023,7625.33292071894,-413.109437067527,-241562.149249345,130443.560594633,-22635.8018533066,1352.12342475075,0,0,844.03905373114,-56.6670296716049],1000),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,253.78532398112,5.2078532398112,88587.0407552137,2657.61122265645,280.361436207684,5.2964402805664,-42935.2037760649,684.777554687195,270.497267867838,5.28,3153.77434906551,684.777554687195,270.497267867838,5.28,30320.1063798547,277.282574225105,272.534742770149,5.27660420849615,-44434.1998684974,2519.91176167596,250.108450895639,5.35135851474449,67416.6930941789,-2513.37842164385,325.607803645446,4.97386175099547,-65232.5725082092,5445.57751449762,166.428684922603,6.03505587581426,33513.596938584,-1960.38519401224,351.577752635356,4.4921469782083,11178.1847537236,49.801902626684,291.272139736165,5.09520310719962,1773.66404651829,1037.27657688117,256.710526137166,5.49842193252104,-18272.8409398139,3442.8571752448,160.487302202754,6.78139825164921,-8682.30028726951,2148.13418714904,218.749836667072,5.90746023468318,53002.0420888697,-7104.51716927588,681.382404488092,-1.80308256233998,-43325.8680682891,8789.58800666171,-192.793380188342,14.2234734900642,40301.4301844002,-6263.32567881371,710.381440940693,-3.84002293251536,-37879.8526693626,8982.02447766434,-280.566319230606,17.6305118711983,31217.9804931516,-5528.52048647017,735.171828259091,-6.07004490354843,-6992.06930338786,3068.74071774523,90.3772379416147,10.0498198543616,-3249.70327969993,2170.5728720703,162.23066559583,8.13372845024934,19990.8824224056,-3755.7764819594,665.970360689338,-6.1388962440431,3286.17358991819,754.494902792937,260.045936061299,6.03883649481871,-33135.5767821238,11134.6937588265,-726.072955261713,37.2659347199995,49256.1335382885,-13582.8193372705,1745.6783543487,-45.125775600286,-3888.95737082416,3157.88429908168,-12.0955274689447,16.3963102633676,-33700.3040545769,12995.6287046947,-1094.24741208952,56.0752126992723,58690.1735889839,-18879.0860823033,2571.34478841752,-84.4391549867971,-41060.3903031107,17031.1169188125,-1737.87957171576,87.929819418809,25551.387624669,-7948.29980410352,1384.54751864683,-42.1713093464717,18854.8398038503,-5336.64615392114,1045.03254413235,-27.4589937838839,-20970.7468403871,10792.7164369314,-1132.43140564272,70.5268839556171,-14971.8524431703,8273.18079015055,-779.696415086297,54.0659177297329,80858.1566143468,-33412.8731499057,5264.7814062197,-238.083843633309,-68460.7740152304,33780.6456334487,-4814.24641128162,265.867547241292,32984.9394476973,-13391.6111268355,2497.45338655822,-111.903608979879,16521.0162237436,-5488.92797933891,1233.02408294636,-44.4673794543924,-19069.0043417513,12128.1322005391,-1673.79084672406,115.407441677875,59755.0011418164,-28072.1105960459,5160.25042870641,-271.854897262761,-219951.00022772,118773.540122956,-20537.7384471297,1227.19445382687,0,0,841.498775005603,-55.5597795010088],1100),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,254.398261468432,5.87398261468432,64069.5412627413,1922.08623788229,273.619123847254,5.93805215594705,-347.706313718311,955.827524235451,268.78783027902,5.93,17321.2839921362,955.827524235451,268.78783027902,5.93,-68937.4296548301,2249.70822894006,262.318426755497,5.94078233920587,98428.4346271594,-2771.26769951983,312.528186040095,5.77341647492387,-84776.3088537907,5472.94575712233,188.864984190465,6.39173248417205,80676.8007879691,-4454.24082138411,387.408715760584,5.06810760703806,-77930.8942981184,7441.33631007589,90.0192874741047,7.54635284275862,71046.7764045898,-5966.65405316623,492.25899837134,3.52395573378539,-46256.2113200698,6350.15965791827,61.1705184833532,8.55332133247926,33978.0688756503,-3277.95396556716,446.295063422935,3.41832739995461,-9656.06418255451,2612.65399728759,181.217705094233,7.39448777488123,4646.18785457527,467.316191722378,288.484595372659,5.60670627024033,-8928.68723578324,2707.17058162976,165.292603927797,7.86522611339088,31068.56108849,-4492.33411673453,597.262885829746,-0.774179524639779,-35345.5571183103,8458.41893359055,-244.536062440957,17.4647976878972,30313.667384826,-5330.01821207651,720.654537754728,-5.05631631667138,-5909.11242107466,2820.10724426229,109.395128530348,10.2251689139268,-6677.21770035873,3004.452511285,94.6475071681305,10.6184388169396,32617.9832225268,-7015.82372404976,946.370987172247,-13.5137264498112,-43794.7151898936,13615.604847305,-910.457584250224,42.1911306928262,62560.8775371077,-16695.7390798904,1969.1200888322,-48.9954956214651,-46448.7949583658,16007.1626687355,-1301.17008603154,60.0141768739728,43234.3022958162,-12243.0129662935,1665.09835564878,-43.8052185848707,-46488.4142240326,17365.4834851923,-1591.83625401695,75.6157171030137,62719.3546002431,-20311.1967591663,2740.98197408432,-90.4756483077576,-44389.0041790756,18247.8124014057,-1886.09912518254,94.6075956630716,34836.6621175949,-11461.8124598412,1827.60398247172,-60.1300338226367,-14957.644291771,7957.96703985345,-696.967352480544,49.2680573589743,24993.9150499513,-8222.41449359723,1487.38415452476,-49.0277604566686,-5018.01590799518,4382.59650870942,-277.317385797933,33.3249780919291,-4921.85141807189,4340.76495567424,-271.25181059874,33.0318086238826,24705.4215804401,-8991.50789364276,1728.58911679829,-66.9602377460469,-13899.8349030521,8959.93637111643,-1053.88474423962,76.8009117412621,30893.9180310071,-12541.0650372375,2386.27548108413,-106.67430027618,-29675.8372199237,17440.9638119787,-2560.75927902758,165.412611530337,87809.4308464825,-42476.5229018629,7625.21346233785,-411.792510480387,-241561.886168569,130443.41853103,-22635.7762884311,1353.4318916474,0,0,844.039047154118,-55.3570284877412],1200),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,256.996336034249,6.54996336034249,40146.558630039,1204.39675890121,269.040303623261,6.59010991897253,39267.2068498067,1191.2064821978,268.974352239743,6.59,-37215.3860293015,1191.2064821978,268.974352239743,6.59,29594.3372673827,189.06063274767,273.985081486996,6.58164878458791,-1161.96304022929,1111.74964197522,264.758191394709,6.61240508489552,-24946.4851065028,2182.05313495808,248.703638999973,6.69267784686918,20947.9034662627,-571.610179408435,303.776905287304,6.32552273828696,21154.8712414678,-587.132762548812,304.164969865816,6.32228886679976,-25567.3884322169,3617.87060808157,178.014868746879,7.58378987798847,1114.68248739848,816.253161521813,276.071479376388,6.43979608731147,21108.6584825506,-1583.02395789318,372.042564153062,5.16018162362039,-5549.31641758196,2015.80265362881,210.095366634586,7.58938958640041,1088.60718793838,1020.11411279523,259.879793676201,6.75964913570102,1194.88766589389,1002.57783393169,260.844289013556,6.74196672117991,-5868.15785157678,2273.92602707843,184.563397425063,8.26758455296558,22277.743740526,-3214.52478337112,541.312700103823,0.53801632823777,-3242.81711029784,2144.79299529887,166.160455597894,9.29156870005851,-9306.4752992472,3509.11608779248,63.8362236589746,11.8496744985363,40468.7183071269,-8436.93037772726,1019.51994090269,-13.6352246279175,-72568.3979291556,20387.5342625262,-1430.55955351928,55.7836943806746,89804.8734095874,-23453.2489989255,2515.11094001201,-62.5864204253264,-46651.0957090515,15436.7021998776,-1179.43442387522,54.4075160978025,16799.5094266307,-3598.47934084101,724.083730197659,-9.04308903796157,-20546.9419977497,8165.65285784046,-511.150150665345,34.1900967922069,65388.2585635914,-20192.9633273716,2608.29762970614,-80.1896551547734,-81006.092256548,30313.0877055892,-3199.89823908197,142.457853148745,98636.1104658204,-34358.1052745224,4560.6449185296,-167.96387315565,-73538.3496097558,30207.3172538501,-3510.03289751344,168.314369179604,35517.2879739993,-12324.3814038367,2019.08792797741,-71.2808665919814,11469.1977137109,-2584.90484841088,704.258593001506,-12.1135465177099,-1394.07882874094,2817.67129942574,-52.1020676957796,23.1832843146292,-5892.88239873317,4774.65085236621,-335.864102877222,36.8984493483272,24965.6084239688,-9111.67001785873,1747.08402766139,-67.248957178238,-13969.5512969801,8993.17925235303,-1059.16760921234,77.7407107273357,30912.5967629701,-12550.2518164292,2387.78136176686,-106.096567725675,-29680.8357537538,17443.4972793609,-2561.18723901641,166.09670531837,87810.7462501228,-42477.2095425725,7625.33292070404,-411.13943706709,-241562.149249256,130443.560594603,-22635.8018532991,1354.09342475003,0,0,844.039053731136,-54.697029671604],1300),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,253.785409859977,7.17785409859977,88583.605600908,2657.50816802721,280.36049154025,7.26643770420068,-42918.0280045328,684.983663945554,270.497869019841,7.25,3088.50641724403,684.983663945554,270.497869019841,7.25,30564.0023355814,272.851225170372,272.558531213716,7.24656556301021,-45344.5157595697,2550.10676802492,249.785975785167,7.32247408110534,70814.0607027194,-2677.02917277813,328.193014897227,6.93043888554511,-77911.7270512931,6246.51809246191,149.722069592412,8.12024518757737,80832.8475024384,-5659.32499906844,447.368146880648,5.63986121017479,-85419.6629585414,9303.40094242251,-1.51363136415979,10.1286789926228,100845.804331827,-10254.4731230691,683.011960928188,2.14254708254648,-77963.5543688373,11202.6499210119,-175.272960834982,13.5863460393907,51008.4131435336,-6208.56569315944,608.231741802611,1.83377549982697,-46070.0982052203,8353.21100915517,-119.857093313077,13.9685894184237,53271.9796773181,-8038.23184146408,781.672263470772,-2.55944878928836,-7017.8205041024,2813.9321911853,130.542421511972,10.4631480498986,-25200.6976609501,6359.59323678166,-99.9255464511375,15.4566206890939,27820.6111479333,-4774.88161308709,679.487693039419,-2.72968823235437,-6081.74693094213,2853.14895466049,107.385400458268,11.5728690821565,-3493.6234242554,2231.99931306538,157.077371786194,10.2477498467656,20056.2406281711,-3773.21602031856,667.520675123047,-4.21481041444275,3268.66091148929,759.430503205933,259.582488006677,8.02333519904207,-33130.8842740819,11133.3008810621,-725.935197889429,39.2313952524313,49254.8761844984,-13582.4272565009,1745.63761586667,-43.1543652061037,-3888.62046392291,3157.77418776659,-12.0835357801944,18.365875101579,-33700.3943284545,12995.659563054,-1094.25092706438,58.0453461152207,58690.1977777977,-18879.0947136044,2571.3458147499,-82.4691956543631,-41060.3967844334,17031.1193288036,-1737.87987033643,89.8998317490876,25551.3893613685,-7948.30047588861,1384.54760524855,-40.2013130669509,18854.8393385171,-5336.64596697114,1045.03251909095,-25.488992666594,-20970.7467156296,10792.7163849884,-1132.43139841962,72.496883621361,-14971.8524765638,8273.18080457499,-779.696417164776,56.0359178293608,80858.1566232885,-33412.8731538769,5264.78140681551,-236.113843662908,-68460.7740177375,33780.6456345066,-4814.24641145671,267.83754725052,32984.9394482337,-13391.6111271335,2497.45338660205,-109.933608982468,16521.0162235051,-5488.92797924951,1233.02408293891,-42.4973794537218,-19069.0043416917,12128.1322005689,-1673.79084672779,117.377441677381,59755.0011418164,-28072.1105960011,5160.25042870268,-269.884897262556,-219951.00022772,118773.540122971,-20537.7384471297,1229.16445382708,0,0,841.498775005603,-53.5897795010079],1400),
new( [-0.01,-0.005,0,0.005,0.01,0.015,0.02,0.025,0.03,0.035,0.04,0.045,0.05,0.055,0.06,0.065,0.07,0.075,0.08,0.085,0.09,0.095,0.1,0.105,0.11,0.115,0.12,0.125,0.13,0.135,0.14,0.145,0.15,0.155,0.16,0.165,0.17,0.175,0.18],[0,0,253.553274848993,7.83553274848994,97869.0060402669,2936.07018120809,282.913976661075,7.9334017545302,-89345.030201349,127.859637583754,268.872923942953,7.91,99511.1147651308,127.859637583754,268.872923942953,7.91,-68699.428859142,2651.01779194792,256.257133171132,7.93102631795303,15286.6006714615,131.436906029508,281.452942030315,7.84704028842241,7553.02617332372,479.447758446019,276.232779244065,7.87314110235374,34501.2946352913,-1137.44834927097,308.570701398414,7.65755495465796,-65558.2047144154,6367.01410195639,120.959140117737,9.22098463199707,67731.524222389,-5629.06150235625,480.841408247165,5.62216195070307,-45367.8921751653,6246.37721938584,65.2010529861123,10.4712994287482,33740.0444781427,-3246.57517901213,444.919148922025,5.40839148293493,-9592.28573746261,2603.28940009753,181.675242862147,9.3570500738365,4629.09847174709,470.08176871458,288.335624431232,7.57937704768795,-8924.10814940364,2706.36086120756,165.340274344159,9.83429179927713,31067.3341259683,-4492.09874837354,597.247850918684,1.196140267786,-35345.2283546614,8458.35093536216,-244.531378523537,19.4346902390429,30313.5792928733,-5329.99867060851,720.653093894491,-3.08628078403464,-5909.08881686805,2820.10165407536,109.395569542786,12.195157324736,-6677.22402509699,3004.45410404021,94.6473735467406,12.5884425513406,32617.984917206,-7015.82417625725,946.371027369875,-11.5437276403457,-43794.7156439844,13615.6049752745,-910.457596266614,44.1611310687616,62560.8776587907,-16695.7391160275,1969.12009240562,-47.0254957391895,-46448.7949909319,16007.1626789131,-1301.17008708642,61.98417691055,43234.3023045269,-12243.0129691622,1665.09835596002,-41.83521859614,-46488.414226357,17365.4834860194,-1591.83625410671,77.5857171064784,62719.3546009463,-20311.19675939,2740.98197411041,-88.5056483087765,-44389.004179226,18247.8124014501,-1886.0991251896,96.5775956633801,34836.6621177102,-11461.8124598435,1827.6039824719,-58.1600338227898,-14957.6442919089,7957.96703982828,-696.967352490498,51.2380573588881,24993.9150499771,-8222.41449363216,1487.38415453127,-47.0577604568709,-5018.01590805192,4382.59650877242,-277.317385803753,35.2949780920057,-4921.85141801304,4340.76495560721,-271.25181059129,35.0018086238256,24705.4215802616,-8991.50789361296,1728.58911679457,-64.9902377453764,-13899.834903053,8959.93637111457,-1053.88474423619,78.7709117412342,30893.91803113,-12541.0650372673,2386.27548109158,-104.704300275989,-29675.8372199237,17440.9638119563,-2560.75927902479,167.382611530542,87809.4308466017,-42476.5229019225,7625.21346233785,-409.822510480648,-241561.886168629,130443.418531045,-22635.7762884349,1355.40189164737,0,0,844.039047154121,-53.3870284877421],1500) ];

    public static double Pt_Jamieson(double v, double v0, double T)
    {
        if (SplinePtJamieson == null)
        {
            InitializeSpline(ref SplinePtJamieson, PtJamieson);
            string code = deveropper(SplinePtJamieson);
            Clipboard.SetDataObject(code, true);
        }
        return GetPressureFromSplineMethods(SplinePtJamieson, 1 - v * v * v / v0 / v0 / v0, T);
    }

    #region MgOJamiesonの定義

    private static readonly double[][] MgOJamieson =
        [
            [double.NaN, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500],
            [-0.01, -1.86, -1.47, -1.00, -0.49, 0.04, 0.59, 1.15, 1.71, 2.28, 2.85, 3.42, 4.00, 4.58, 5.15],
            [-0.005, -1.11, -0.73, -0.26, 0.25, 0.78, 1.33, 1.88, 2.45, 3.02, 3.59, 4.16, 4.73, 5.31, 5.89],
            [0, -0.35, 0.03, 0.50, 1.01, 1.54, 2.09, 2.64, 3.21, 3.77, 4.34, 4.92, 5.49, 6.07, 6.64],
            [0.005, 0.43, 0.81, 1.28, 1.79, 2.32, 2.86, 3.42, 3.98, 4.55, 5.12, 5.69, 6.27, 6.84, 7.42],
            [0.01, 1.24, 1.62, 2.08, 2.59, 3.12, 3.67, 4.22, 4.78, 5.35, 5.92, 6.49, 7.07, 7.64, 8.22],
            [0.015, 2.07, 2.44, 2.91, 3.41, 3.94, 4.49, 5.04, 5.61, 6.17, 6.74, 7.32, 7.89, 8.47, 9.04],
            [0.02, 2.92, 3.29, 3.75, 4.26, 4.79, 5.34, 5.89, 6.45, 7.02, 7.59, 8.16, 8.74, 9.31, 9.89],
            [0.025, 3.80, 4.17, 4.63, 5.13, 5.66, 6.21, 6.76, 7.32, 7.89, 8.46, 9.03, 9.60, 10.18, 10.76],
            [0.03, 4.70, 5.07, 5.52, 6.03, 6.56, 7.10, 7.66, 8.22, 8.78, 9.35, 9.92, 10.50, 11.07, 11.65],
            [0.035, 5.62, 5.99, 6.45, 6.95, 7.48, 8.02, 8.58, 9.14, 9.70, 10.27, 10.84, 11.42, 11.99, 12.57],
            [0.04, 6.58, 6.94, 7.40, 7.90, 8.42, 8.97, 9.52, 10.08, 10.65, 11.22, 11.79, 12.36, 12.94, 13.51],
            [0.045, 7.55, 7.92, 8.37, 8.87, 9.40, 9.94, 10.49, 11.05, 11.62, 12.19, 12.76, 13.33, 13.91, 14.48],
            [0.05, 8.56, 8.92, 9.37, 9.87, 10.40, 10.94, 11.49, 12.05, 12.62, 13.19, 13.76, 14.33, 14.91, 15.48],
            [0.055, 9.59, 9.95, 10.40, 10.90, 11.43, 11.97, 12.52, 13.08, 13.65, 14.21, 14.78, 15.36, 15.93, 16.51],
            [0.06, 10.66, 11.01, 11.46, 11.96, 12.49, 13.03, 13.58, 14.14, 14.70, 15.27, 15.84, 16.41, 16.99, 17.57],
            [0.065, 11.75, 12.11, 12.55, 13.05, 13.57, 14.11, 14.67, 15.22, 15.79, 16.36, 16.93, 17.50, 18.07, 18.65],
            [0.07, 12.88, 13.23, 13.67, 14.17, 14.69, 15.23, 15.78, 16.34, 16.91, 17.47, 18.04, 18.62, 19.19, 19.77],
            [0.075, 14.03, 14.38, 14.83, 15.32, 15.84, 16.38, 16.93, 17.49, 18.06, 18.62, 19.19, 19.77, 20.34, 20.92],
            [0.08, 15.22, 15.57, 16.01, 16.51, 17.03, 17.57, 18.12, 18.67, 19.24, 19.80, 20.37, 20.95, 21.52, 22.10],
            [0.085, 16.44, 16.79, 17.23, 17.72, 18.25, 18.78, 19.33, 19.89, 20.45, 21.02, 21.59, 22.16, 22.74, 23.31],
            [0.09, 17.70, 18.05, 18.49, 18.98, 19.50, 20.04, 20.58, 21.14, 21.70, 22.27, 22.84, 23.41, 23.99, 24.56],
            [0.095, 19.00, 19.34, 19.78, 20.27, 20.79, 21.32, 21.87, 22.43, 22.99, 23.56, 24.13, 24.70, 25.27, 25.85],
            [0.1, 20.33, 20.67, 21.10, 21.59, 22.11, 22.65, 23.20, 23.75, 24.31, 24.88, 25.45, 26.02, 26.59, 27.17],
            [0.105, 21.70, 22.03, 22.47, 22.96, 23.48, 24.01, 24.56, 25.11, 25.68, 26.24, 26.81, 27.38, 27.96, 28.53],
            [0.11, 23.11, 23.44, 23.87, 24.36, 24.88, 25.41, 25.96, 26.52, 27.08, 27.64, 28.21, 28.78, 29.36, 29.93],
            [0.115, 24.55, 24.89, 25.32, 25.81, 26.32, 26.86, 27.40, 27.96, 28.52, 29.08, 29.65, 30.22, 30.80, 31.37],
            [0.12, 26.05, 26.38, 26.81, 27.29, 27.81, 28.34, 28.89, 29.44, 30.00, 30.57, 31.14, 31.71, 32.28, 32.85],
            [0.125, 27.58, 27.91, 28.34, 28.82, 29.34, 29.87, 30.42, 30.97, 31.53, 32.09, 32.66, 33.23, 33.81, 34.38],
            [0.13, 29.16, 29.49, 29.91, 30.40, 30.91, 31.44, 31.99, 32.54, 33.10, 33.67, 34.23, 34.80, 35.38, 35.95],
            [0.135, 30.79, 31.11, 31.54, 32.02, 32.53, 33.06, 33.61, 34.16, 34.72, 35.28, 35.85, 36.42, 36.99, 37.57],
            [0.14, 32.46, 32.78, 33.21, 33.69, 34.20, 34.73, 35.27, 35.83, 36.39, 36.95, 37.52, 38.09, 38.66, 39.23],
            [0.145, 34.18, 34.50, 34.93, 35.40, 35.91, 36.45, 36.99, 37.54, 38.10, 38.66, 39.23, 39.80, 40.37, 40.95],
            [0.15, 35.96, 36.27, 36.70, 37.17, 37.68, 38.21, 38.76, 39.31, 39.87, 40.43, 41.00, 41.57, 42.14, 42.71],
            [0.155, 37.78, 38.10, 38.52, 38.99, 39.50, 40.03, 40.58, 41.13, 41.69, 42.25, 42.82, 43.38, 43.96, 44.53],
            [0.16, 39.67, 39.98, 40.40, 40.87, 41.38, 41.91, 42.45, 43.00, 43.56, 44.12, 44.69, 45.26, 45.83, 46.40],
            [0.165, 41.60, 41.91, 42.33, 42.80, 43.31, 43.84, 44.38, 44.93, 45.49, 46.05, 46.62, 47.19, 47.76, 48.33],
            [0.17, 43.60, 43.91, 44.32, 44.79, 45.30, 45.83, 46.37, 46.92, 47.48, 48.04, 48.60, 49.17, 49.74, 50.32],
            [0.175, 45.66, 45.96, 46.37, 46.85, 47.35, 47.88, 48.42, 48.97, 49.52, 50.09, 50.65, 51.22, 51.79, 52.37],
            [0.18, 47.78, 48.08, 48.49, 48.96, 49.46, 49.99, 50.53, 51.08, 51.64, 52.20, 52.76, 53.33, 53.90, 54.47],
            [0.185, 49.96, 50.26, 50.67, 51.14, 51.64, 52.17, 52.71, 53.25, 53.81, 54.37, 54.94, 55.51, 56.08, 56.65],
            [0.19, 52.21, 52.51, 52.92, 53.38, 53.89, 54.41, 54.95, 55.50, 56.05, 56.61, 57.18, 57.75, 58.32, 58.89],
            [0.195, 54.53, 54.83, 55.23, 55.70, 56.20, 56.72, 57.26, 57.81, 58.37, 58.93, 59.49, 60.06, 60.63, 61.20],
            [0.2, 56.92, 57.22, 57.62, 58.09, 58.59, 59.11, 59.65, 60.19, 60.75, 61.31, 61.87, 62.44, 63.01, 63.58],
            [0.205, 59.39, 59.68, 60.09, 60.55, 61.05, 61.57, 62.11, 62.65, 63.21, 63.77, 64.33, 64.90, 65.47, 66.04],
            [0.21, 61.94, 62.23, 62.63, 63.09, 63.59, 64.11, 64.64, 65.19, 65.75, 66.30, 66.87, 67.44, 68.01, 68.58],
            [0.215, 64.56, 64.85, 65.25, 65.71, 66.21, 66.73, 67.26, 67.81, 68.36, 68.92, 69.48, 70.05, 70.62, 71.19],
            [0.22, 67.27, 67.56, 67.95, 68.41, 68.91, 69.43, 69.96, 70.51, 71.06, 71.62, 72.18, 72.75, 73.32, 73.89],
            [0.225, 70.07, 70.35, 70.74, 71.20, 71.70, 72.22, 72.75, 73.30, 73.85, 74.41, 74.97, 75.54, 76.11, 76.68],
            [0.23, 72.95, 73.23, 73.63, 74.08, 74.58, 75.09, 75.63, 76.17, 76.73, 77.28, 77.85, 78.41, 78.98, 79.55],
            [0.235, 75.93, 76.21, 76.60, 77.06, 77.55, 78.07, 78.60, 79.14, 79.70, 80.25, 80.82, 81.38, 81.95, 82.52],
            [0.24, 79.01, 79.29, 79.67, 80.13, 80.62, 81.13, 81.67, 82.21, 82.76, 83.32, 83.88, 84.45, 85.02, 85.59],
            [0.245, 82.19, 82.46, 82.85, 83.30, 83.79, 84.30, 84.84, 85.38, 85.93, 86.49, 87.05, 87.61, 88.18, 88.75],
            [0.25, 85.47, 85.74, 86.12, 86.57, 87.06, 87.58, 88.11, 88.65, 89.20, 89.76, 90.32, 90.89, 91.46, 92.03],
            [0.255, 88.86, 89.13, 89.51, 89.96, 90.45, 90.96, 91.49, 92.04, 92.59, 93.14, 93.70, 94.27, 94.84, 95.41],
            [0.26, 92.37, 92.63, 93.01, 93.46, 93.95, 94.46, 94.99, 95.53, 96.08, 96.64, 97.20, 97.76, 98.33, 98.90]];

    #endregion
    private static Spline[] SplineMgOJamieson;

    public static double MgO_Jamieson(double v, double v0, double T)
    {
        if (SplineMgOJamieson == null)
        {
            InitializeSpline(ref SplineMgOJamieson, MgOJamieson);
            string code = deveropper(SplineMgOJamieson);
            Clipboard.SetDataObject(code, true);
        }
        return GetPressureFromSplineMethods(SplineMgOJamieson, 1 - v * v * v / v0 / v0 / v0, T);
    }

    #region double[][] Brownの定義

    private static readonly double[][] Brown = [
            [double.NaN, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200],
        [0.3197, 23.68, 23.91, 24.15, 24.40, 24.64, 24.89, 25.14, 25.39, 25.64, 25.90],
        [0.3147, 22.88, 23.11, 23.36, 23.60, 23.85, 24.10, 24.35, 24.60, 24.85, 25.11],
        [0.31, 22.10, 22.34, 22.58, 22.83, 23.08, 23.33, 23.58, 23.83, 24.09, 24.34],
        [0.305, 21.35, 21.59, 21.83, 22.08, 22.33, 22.58, 22.83, 23.08, 23.34, 23.59],
        [0.3002, 20.62, 20.85, 21.10, 21.35, 21.60, 21.85, 22.10, 22.36, 22.61, 22.87],
        [0.2952, 19.90, 20.14, 20.39, 20.64, 20.89, 21.14, 21.39, 21.65, 21.90, 22.16],
        [0.2903, 19.21, 19.45, 19.69, 19.94, 20.20, 20.45, 20.70, 20.96, 21.22, 21.47],
        [0.2855, 18.53, 18.77, 19.02, 19.27, 19.52, 19.78, 20.03, 20.29, 20.55, 20.80],
        [0.2805, 17.87, 18.12, 18.37, 18.62, 18.87, 19.13, 19.38, 19.64, 19.90, 20.16],
        [0.2755, 17.24, 17.48, 17.73, 17.98, 18.24, 18.49, 18.75, 19.01, 19.27, 19.53],
        [0.2708, 16.62, 16.86, 17.11, 17.36, 17.62, 17.88, 18.14, 18.39, 18.65, 18.91],
        [0.2658, 16.01, 16.26, 16.51, 16.76, 17.02, 17.28, 17.54, 17.80, 18.06, 18.32],
        [0.261, 15.43, 15.67, 15.93, 16.18, 16.44, 16.70, 16.96, 17.22, 17.48, 17.74],
        [0.2561, 14.86, 15.11, 15.36, 15.62, 15.87, 16.13, 16.39, 16.66, 16.92, 17.18],
        [0.2511, 14.31, 14.55, 14.81, 15.07, 15.33, 15.59, 15.85, 16.11, 16.37, 16.63],
        [0.2463, 13.77, 14.02, 14.27, 14.53, 14.79, 15.05, 15.32, 15.58, 15.84, 16.10],
        [0.2413, 13.25, 13.50, 13.75, 14.01, 14.27, 14.54, 14.80, 15.06, 15.33, 15.59],
        [0.2364, 12.74, 12.99, 13.25, 13.51, 13.77, 14.03, 14.30, 14.56, 14.83, 15.09],
        [0.2316, 12.25, 12.50, 12.76, 13.02, 13.28, 13.55, 13.81, 14.08, 14.34, 14.61],
        [0.2266, 11.78, 12.03, 12.29, 12.55, 12.81, 13.07, 13.34, 13.61, 13.87, 14.14],
        [0.2219, 11.31, 11.56, 11.82, 12.09, 12.35, 12.62, 12.88, 13.15, 13.42, 13.68],
        [0.2169, 10.86, 11.12, 11.38, 11.64, 11.90, 12.17, 12.44, 12.71, 12.97, 13.24],
        [0.2119, 10.43, 10.68, 10.94, 11.21, 11.47, 11.74, 12.01, 12.27, 12.54, 12.81],
        [0.2071, 10.00, 10.26, 10.52, 10.78, 11.05, 11.32, 11.59, 11.86, 12.13, 12.40],
        [0.2022, 9.59, 9.85, 10.11, 10.38, 10.64, 10.91, 11.18, 11.45, 11.72, 11.99],
        [0.1972, 9.19, 9.45, 9.71, 9.98, 10.25, 10.52, 10.79, 11.06, 11.33, 11.60],
        [0.1924, 8.81, 9.06, 9.33, 9.60, 9.86, 10.13, 10.41, 10.68, 10.95, 11.22],
        [0.1874, 8.43, 8.69, 8.95, 9.22, 9.49, 9.76, 10.03, 10.31, 10.58, 10.85],
        [0.1827, 8.06, 8.32, 8.59, 8.86, 9.13, 9.40, 9.67, 9.95, 10.22, 10.49],
        [0.1777, 7.71, 7.97, 8.24, 8.51, 8.78, 9.05, 9.33, 9.60, 9.87, 10.15],
        [0.1727, 7.37, 7.63, 7.90, 8.17, 8.44, 8.71, 8.99, 9.26, 9.54, 9.81],
        [0.168, 7.03, 7.30, 7.56, 7.84, 8.11, 8.38, 8.66, 8.93, 9.21, 9.48],
        [0.163, 6.71, 6.97, 7.24, 7.51, 7.79, 8.06, 8.34, 8.61, 8.89, 9.17],
        [0.1582, 6.39, 6.66, 6.93, 7.20, 7.48, 7.75, 8.03, 8.31, 8.58, 8.86],
        [0.1532, 6.09, 6.35, 6.63, 6.90, 7.17, 7.45, 7.73, 8.01, 8.28, 8.56],
        [0.1483, 5.79, 6.06, 6.33, 6.61, 6.88, 7.16, 7.44, 7.72, 7.99, 8.27],
        [0.1435, 5.50, 5.77, 6.04, 6.32, 6.60, 6.88, 7.15, 7.43, 7.71, 7.99],
        [0.1336, 4.95, 5.22, 5.50, 5.78, 6.06, 6.33, 6.62, 6.90, 7.18, 7.46],
        [0.1238, 4.44, 4.71, 4.99, 5.26, 5.55, 5.83, 6.11, 6.39, 6.67, 6.96],
        [0.1141, 3.95, 4.22, 4.50, 4.78, 5.07, 5.35, 5.63, 5.92, 6.20, 6.49],
        [0.1043, 3.49, 3.77, 4.05, 4.33, 4.62, 4.90, 5.19, 5.47, 5.76, 6.04],
        [0.0944, 3.07, 3.34, 3.62, 3.91, 4.19, 4.48, 4.77, 5.05, 5.34, 5.63],
        [0.0846, 2.66, 2.94, 3.22, 3.51, 3.80, 4.08, 4.37, 4.66, 4.95, 5.24],
        [0.0749, 2.28, 2.56, 2.85, 3.13, 3.42, 3.71, 4.00, 4.29, 4.58, 4.87],
        [0.0652, 1.92, 2.20, 2.49, 2.78, 3.07, 3.36, 3.65, 3.94, 4.23, 4.52],
        [0.0554, 1.58, 1.86, 2.15, 2.44, 2.73, 3.02, 3.31, 3.60, 3.89, 4.19],
        [0.0407, 1.10, 1.39, 1.68, 1.97, 2.26, 2.55, 2.84, 3.13, 3.43, 3.72],
        [0.026, 0.67, 0.95, 1.24, 1.53, 1.82, 2.12, 2.41, 2.70, 3.00, 3.29],
        [0.0113, 0.27, 0.56, 0.85, 1.14, 1.43, 1.72, 2.01, 2.31, 2.60, 2.90],
        [0.0015, 0.03, 0.32, 0.60, 0.89, 1.19, 1.48, 1.77, 2.06, 2.36, 2.65],
        [0.0000, 0.00, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN],
        [-0.0035, -0.09, 0.20, 0.49, 0.78, 1.07, 1.36, 1.65, 1.95, 2.24, 2.53],
        [-0.0132, double.NaN, -0.02, 0.27, 0.56, 0.85, 1.14, 1.43, 1.72, 2.01, 2.31],
        [-0.0229, double.NaN, double.NaN, 0.06, 0.35, 0.64, 0.93, 1.22, 1.51, 1.80, 2.09],
        [-0.0329, double.NaN, double.NaN, -0.13, 0.15, 0.44, 0.73, 1.02, 1.31, 1.60, 1.89],
        [-0.0426, double.NaN, double.NaN, double.NaN, -0.03, 0.25, 0.54, 0.83, 1.11, 1.40, 1.69],
        [-0.0524, double.NaN, double.NaN, double.NaN, double.NaN, 0.08, 0.36, 0.65, 0.93, 1.22, 1.50],
        [-0.0671, double.NaN, double.NaN, double.NaN, double.NaN, -0.16, 0.12, 0.40, 0.68, 0.96, 1.25],
        [-0.0818, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, -0.10, 0.17, 0.45, 0.73, 1.01],
        [-0.1013, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, -0.09, 0.18, 0.46, 0.73],
        [-0.121, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, -0.05, 0.22, 0.48],
        [-0.1405, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, 0.01, 0.27],
        [-0.1602, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, -0.18, 0.08],
        [-0.1699, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, -0.01]];

    #endregion

    private static Spline[] SplineBrown = [
new ( [-0.0035,0,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,-2.02238578259007E-13,27.8394894142225,0.00743821294977886,-173486.016321372,-1821.60317137441,21.463878314412,0,563789.530066473,-1821.60317137441,21.463878314412,0,-24221.7764091261,824.447707765795,17.4948019957018,0.00198453815935516,1449.65794520593,-45.8139168460695,27.3287583538158,-0.0350566974562079,1743.00739154207,-68.6951736602866,27.9236710309858,-0.040212607325012,-2125.49510225278,403.648980832078,8.69926394314658,0.2205985155,3612.26120743646,-549.966117838241,61.5295404094874,-0.755000589911645,-3051.34788351546,753.435820352051,-23.4522659605226,1.09193733519638,4883.34679327183,-1029.49007352221,110.088883490658,-2.24214002943455,-10122.4918700541,2778.99177923,-212.108681252193,6.84383129631371,13702.6079281883,-3968.27648363238,424.833442762028,-13.1986142059997,-4499.00241380732,1727.00739237819,-169.184665505879,7.45341535811232,-5333.97464206171,2012.81838611017,-201.795699890679,8.69372169921458,4204.13115371437,-1529.63410643973,236.759918687001,-9.4040068274221,8748.95708275108,-3351.20033879479,480.121167329652,-20.241694433661,-16719.6692483116,7613.04329674848,-1093.24779436067,55.0177875673637,-52881.4576112892,23701.422939412,-3479.15449538143,172.961108820575,138979.467850831,-64477.858402874,10029.9114062766,-516.901856556453,-190124.028625015,91714.6610244746,-14679.7451671499,786.120700081224,210462.706038563,-104172.252226051,17249.8216926918,-948.719099302601,-218978.610498843,112266.171308857,-19111.8334611702,1087.53358931347,93312.433250489,-49531.8184577114,8830.67937150549,-521.023732754826,88096.5499984597,-46751.2310960917,8336.56899735632,-491.755928258633,-179208.473895829,99758.6525003973,-18430.78673573,1138.37603588567,117747.613501363,-67190.0598342812,12855.4019557927,-815.967884377757,-63953.8735693604,37688.0385029397,-7323.14416428604,478.149540123192,32046.0989285694,-19105.5452268431,3876.55054723286,-258.043725580593,48804.659184146,-29271.2878778465,5932.06371127151,-396.585312836118,-135134.151808645,85009.8953917896,-17735.5693439022,1237.27028906962,82921.9181748243,-53608.3482964874,11637.6364936949,-837.457149921667,103344.374258514,-66897.2404702296,14519.9972060932,-1045.85182943266,-264271.278329379,177824.499457491,-39783.7568838309,2970.81584808745,235410.73215841,-161859.331271967,37188.5991594695,-2843.16277838416,-118534.8781512,84062.0787711151,-19766.7994064638,1553.79399091253,-29364.1474150216,20822.1965330626,-4816.89124540114,375.741227814418,140599.239869438,-102214.29952226,24871.8152527238,-2012.22039818348,-190751.363385308,142620.661222766,-35431.0355787889,2938.64365508131,144561.143152794,-109970.249952511,27994.5422173591,-2370.07720645504,-37925.7181927463,30234.4056188118,-7911.87007462992,695.133522867965,-70655.6438450002,55861.9374053499,-14600.6558707245,1277.05788712543,169268.640113696,-135453.686623598,36251.0369961146,-3228.40210086725,-264233.112092416,216723.136868675,-59118.4468055471,5380.28330362661,176153.624466433,-147256.500897509,41157.9433989296,-3828.43186348745,25443.9879971876,-20434.3418084384,5584.32777451836,-502.298802602924,-130637.411624311,113249.37696755,-32582.3739360325,3129.89897685287,50412.2706129591,-44426.7912925771,13191.0177098543,-1299.43955474734,89309.9210071256,-78874.5504822677,23359.996222839,-2300.06704040951,-214929.233355517,195123.231937843,-58894.1380596492,5930.82999677758,321098.385958407,-295342.0397349,90697.7698004246,-9277.68063565984,-354271.065630898,332751.550242767,-104011.243092742,10842.2506966265,114384.187962264,-109705.874674618,35230.1085287742,-3764.16708846856,0,0,157.140395300661,-26.5577843776212],300),
new ( [-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,22.2449534289656,0.273633385262346,4628.110768077,183.273186415854,24.6641594896549,0.284277891929379,-8988.81488904164,40.2954670161055,24.1637374717558,0.283694066241831,2783.81617985336,-12.681372793925,24.2432027314709,0.283654333611973,1419.63597444363,33.5643361694728,23.7206262201845,0.285622705137818,-2471.98397908907,337.11069254502,15.8284209544201,0.354021817441109,2172.10753279115,-229.932881055555,38.9070943999638,0.0409211476965732,-216.471519951648,167.048957510301,16.9143005434173,0.447054740914195,-351.306344904736,193.422649271152,15.1947358406142,0.484426613788573,-2042.62458461723,573.46185773437,-13.2702008732957,1.19510120041216,3910.09326731366,-937.337933085553,114.543461430086,-2.40924407654289,-3626.84623164872,1197.12333302038,-86.9496820903279,3.93107350623286,9387.53347373069,-2875.07607679218,337.780716353132,-10.8353866796542,-11666.6917235724,4331.78520824511,-484.522156269608,20.439532575768,4701.20047483655,-1747.24995424258,268.062396846549,-10.6171233161668,12932.5166825968,-5046.3614903152,708.823698065959,-30.2456932637912,-66464.8858304604,29134.2202915485,-4196.08978763189,204.372668468808,61013.2341951646,-27580.7953078368,4214.74702575793,-211.40303133977,-11261.1314423496,5636.5031391645,-874.143096321105,48.4696242276507,-24283.962134686,11817.1385857483,-1851.91962396619,100.031039785712,56912.3752276851,-27887.8703844757,4619.99683817193,-251.609754657388,-94400.269159043,48373.7023863569,-8191.947387335,465.859121970826,35687.1850328712,-19024.6076303457,3447.74075256647,-204.198925281626,115594.900773867,-61623.4108919104,11017.548092144,-652.583846696557,-235763.656913386,130956.214576433,-24166.7494809375,1490.13987550381,219707.038552026,-125109.410414135,23819.9486423013,-1507.42920059498,-172358.852830764,101191.022091994,-19720.2545718676,1284.94916554078,95532.3763769055,-57293.429107262,11532.8792046265,-769.423494700764,-18228.8293224857,11714.1182699324,-2420.44687505988,171.030683070714,-16495.0397246512,10636.9147929267,-2197.35803493494,155.630116808225,-54400.9002478838,34733.6703276077,-7303.46053278137,516.291156566947,211597.285311923,-138351.349016258,30238.680162901,-2198.00561572964,-319013.892293866,214876.511915885,-48142.5821779191,3599.5950887498,249902.566188401,-171872.896560394,39494.8337827994,-3019.95106348379,-126357.877585858,89552.8597740595,-21051.3713842576,1654.21597541274,-13725.9551653809,9674.30039336689,-2168.07994665017,166.212610131317,87272.0326729099,-63438.1430027214,15473.9526448434,-1252.79487797662,-72210.0486510473,54403.1668876775,-13550.3619811694,1130.10135281846,-6091.64504762959,4596.17345292893,-1043.82592975149,83.3042853106865,123506.613325929,-94974.1684554147,24456.1386329951,-2093.54268952535,-225664.005517302,178426.426098494,-46901.4165456008,4114.56461100626,270437.730889051,-217165.09851147,58246.8106958061,-5201.56832257605,-269250.770451172,221277.839977162,-60483.5370469989,5515.82440033729,93567.9331908963,-78591.8185830288,22130.5538863988,-2070.90295037947,115329.054335645,-96903.8020264495,27267.0652422234,-2551.16676214213,-166246.983335301,144266.074239291,-41586.9344315692,4001.43887346837,14495.5344195422,-13142.5844735858,4108.79919284214,-420.384950219943,182182.769997551,-161646.400300839,47947.125624974,-4734.07627117312,-306740.763664783,278678.134114938,-84238.2996066557,8493.27861368167,330589.583941311,-304479.133944687,93624.6671515116,-9589.45634007407,-303599.395001978,285316.616472371,-89212.0154777877,9303.66753162304,87438.1566024944,-83861.9359974563,26968.4749844689,-2883.66591786779,0,0,157.814046084722,-26.5431505332857],400),
new ( [-0.0329,-0.0229,-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,18.3888901866717,0.4749944871415,6111.09813328288,603.165385755007,38.2330313780119,0.692618568873197,-3731.15790582839,-72.9976041319241,22.7488989096007,0.574423024364325,-8187.99066555556,-249.4881814171,20.4192232894364,0.564172451635601,38113.5797898764,236.678308364927,22.1208060036735,0.566157631468878,-16432.3177991161,482.134847515393,21.7526211949478,0.566341723873241,5913.3053161504,-275.381776092138,30.3125590417129,0.534099291317093,-3632.74952058175,469.21050117296,10.9531598328202,0.701880751127497,2321.50035705514,-257.803408886492,40.5426259722403,0.300450327169365,895.539997465457,-20.8087971227486,27.4131244805262,0.54290845471639,-5361.51495640788,1203.07115185483,-52.3838481928127,2.27716266081698,5937.83945680963,-1335.89378479506,137.784625562262,-2.47071023393496,-1107.29387752016,452.16105545789,-13.4848139231353,1.79508795955333,-2226.95192679667,769.248215012788,-43.4178417851055,2.73698056960948,8733.77445874755,-2660.36307102339,314.290615348466,-9.69935012339868,-10454.5253629586,3907.79195794545,-435.135873456959,18.8038373341694,568.01305510477,-185.978810522133,71.6729476793512,-2.11047335139394,17733.6802373132,-7065.97821715347,990.840868405049,-43.0440847543813,-32368.2906426128,14502.9202466579,-2104.29606114855,105.006631709317,-38731.3353927399,17333.8388559988,-2524.12129091594,125.759992234065,98787.6582950913,-45869.8906429575,7158.69006832002,-368.708907844584,-125492.563005024,60573.5023860359,-9680.65470886908,519.285873405967,171618.202559935,-84713.6619751656,14001.1530820165,-767.425683231798,-210668.488907131,107958.830524218,-18367.8256578854,1045.23712620265,101379.570402656,-53713.2690041922,9552.94593066709,-562.068624911682,48507.5794056926,-25527.2106036849,4544.2833529075,-265.38884488896,-111886.121285829,62384.5767453102,-11517.2001957644,712.755503224994,78214.2849233633,-44489.871625475,8511.07142892634,-538.343864263828,-56468.3075859051,33248.9207708863,-6445.87222813337,420.894788942231,43122.2998646422,-25668.8825968376,5172.71859598226,-342.833914562971,-3773.74743168238,2778.25969305367,-579.293575058684,44.8517057643462,-20411.9825203199,13115.5951536314,-2720.15574892301,192.642557834182,-53573.2463729908,34196.2105850458,-7187.13815881141,508.16041538502,211987.085687811,-138603.897487361,30293.2052820574,-2201.66841538716,-321620.90418195,216618.941369264,-48530.7426602085,3628.67626740726,259168.095039483,-178201.420301584,40935.5512943876,-3129.01113596288,-162737.464528412,114938.562486235,-26955.6687192834,2112.19104909331,33903.8391092757,-24519.4500536097,6012.20544517892,-485.677435063219,101607.119309975,-73529.8545907903,17838.416060026,-1436.89897551711,-179112.478964826,133893.856574237,-33250.0439999524,2757.46359540451,139306.880700268,-105971.447061406,26980.1337429623,-2283.80228167412,-27708.7979127121,22346.6988166341,-5882.14341646296,521.540778495463,-107221.050949028,84604.7929445748,-22131.5059838183,1935.23532185316,218014.794411824,-174738.270146462,46801.8801857618,-4172.26269276798,-257634.233158967,211678.999851917,-57839.916529813,5273.40349075669,102967.862153711,-86358.6319240262,24269.451024506,-2266.97342964382,67438.2307481212,-56460.4470960526,15883.0101802265,-1482.84121070967,-64002.030727902,56118.1368585365,-16258.1755388502,1575.92829688875,-78086.2035768853,68384.0429926097,-19818.968089575,1920.49432269163,195283.458341516,-173712.129602589,51647.8220604875,-5111.83782803433,-269274.280033164,244668.569578132,-73950.0638335187,7456.32395375229,341722.978096966,-314393.921611579,96563.9959794078,-9879.2721272324,-387570.145800978,363848.683613807,-113691.211640455,11847.0993268187,137086.069133297,-131479.248905741,42188.4887234364,-4504.68124135537,0,0,154.572848271329,-25.2669395923441],500),
new ( [-0.0426,-0.0329,-0.0229,-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,18.2646572890174,0.748074400512141,3103.87652152645,396.675419451091,35.1630301576339,0.988031295246495,-440.165825129157,46.8784398361848,23.6547095283034,0.861823379011501,916.640054472634,140.091003764839,25.7892772422691,0.878117245894779,-9526.95737923927,-273.475454610158,20.3301999917194,0.854097305992358,38911.9808134896,235.133396413481,22.1103309703022,0.856174125467371,-16540.0727522703,484.667637459398,21.7360296087333,0.856361276148155,5992.41002721166,-279.183528765045,30.3675477870695,0.823849224343089,-3875.87811426534,490.542946270152,10.3546594361543,0.997294256717691,3214.91002072825,-375.242285012564,45.5921183493598,0.51923939746187,-5014.13774304556,992.425453326637,-30.1766743546294,1.91843643606212,7223.58089697299,-1401.272312661,125.892419987765,-1.47346521431238,-5651.57059297483,1491.77422713031,-90.7967658425989,3.93654145858583,-105.132088596504,84.0881347188933,28.2934775753965,0.578196594198877,5385.35742718114,-1470.81849614895,175.076663529299,-4.0405809904865,-2071.79403724667,862.524197070792,-68.2909793734523,4.42050072776722,4005.59276059303,-1217.76530383031,169.070052679409,-4.60713052463362,-13637.0928278288,5334.72812370933,-642.128633650118,28.8683352645559,28115.4136277438,-11399.6764636876,1593.58781922654,-70.6955707701813,-74745.225874221,32881.8288419171,-4760.80819212669,233.256371772932,27338.6775937839,-12535.2998110116,1974.55198710094,-99.6949330867659,47204.788389935,-21665.7643328757,3373.33915185287,-171.126330966992,-63598.2499570907,30921.3576665833,-4945.94354845841,267.577176763165,67903.6519810956,-33383.0723811894,5535.67854932368,-301.924290550281,-101458.32732773,51975.3651904898,-8804.53896272395,501.127890124646,50836.1325140755,-26928.3944536077,4822.14032780981,-283.314614367571,61897.0166443559,-32824.9517834295,5869.95856532768,-345.380381302715,-114740.578751533,63990.1142530427,-11818.1539995377,731.825673897509,75396.6163544197,-42905.0168355457,8213.99356645957,-519.515810724458,-41872.2717973785,24782.5854057841,-4809.10110476053,315.698660856502,-9548.32122318578,5659.73624594752,-1038.07525045017,67.8165613671788,112597.733009602,-68434.0602515965,13943.6904013566,-941.954443566551,-178736.434492694,112571.858017704,-23542.6352722103,1645.85157209949,103893.377288687,-67095.9133319114,14528.9654767385,-1043.27249413708,60890.4693324973,-39113.9211247613,8459.67136699498,-604.462530001403,-198632.034721685,133650.209824036,-29876.6892905035,2231.15027996529,204975.900415941,-140722.464482374,32296.1587073429,-2464.97217213748,-147622.49116916,104262.897990815,-24442.4512414867,1915.24851591107,30682.9002759735,-22191.2856220565,5451.31776462853,-440.380481771983,99889.1127976638,-72289.6628664315,17540.0561937048,-1412.71800941272,-168538.084258431,126051.193038182,-31311.2966156366,2597.97805623035,100825.268305354,-76860.2204481131,19639.7593107485,-1666.62532480881,34502.1825238029,-25904.1936419867,6589.9208458143,-552.604114511907,-147605.542897297,116686.155362655,-30626.1602444228,2685.1949403382,228319.179433165,-183076.218223534,49050.6786547715,-4374.17298613372,-260609.933529035,214129.793146811,-58512.7092243428,5335.21549308645,103684.281023107,-86959.3751804705,24437.3566498361,-2282.36555635924,67305.3608523731,-56346.5138564658,15850.4490484676,-1479.48969563566,-64201.572717304,56289.1747454167,-16307.0400474897,1580.83134999242,-77169.4232817676,67582.8758022234,-19585.6014640894,1898.08680975378,191913.492222901,-170716.954168947,50760.5083433401,-5023.97039528362,-255995.279914289,232669.686017656,-70336.1610408372,7093.76965441118,294611.497339763,-271135.515169382,83324.4253213182,-8528.38995907531,-293379.162089229,275695.798099667,-86193.2817920633,8988.4397759703,85564.5885936022,-82064.9969201162,26394.0404006504,-2821.97032204666,0,0,157.860885284948,-26.0681250255976],600),
new ( [-0.0671,-0.0524,-0.0426,-0.0329,-0.0229,-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,16.1939135234553,0.926611597423853,613.712290201126,123.540284017491,24.483466581029,1.11202126747825,5101.41407858209,829.007005150983,61.4499227684237,1.75770203555142,-7671.08807135063,-803.318769610422,-8.08715523641198,0.770275527882744,6003.91283659165,546.403820003487,36.318717961886,1.25725993729074,-4130.55415466207,-149.834062295644,20.3748704572353,1.13555523467191,3994.13199487244,171.903509225897,24.6218064013197,1.15424175282588,-8603.6721579498,39.626565621275,24.1588370987036,1.15370162197283,2720.06985571778,-11.3302734402297,24.2352723572958,1.15366340434353,1483.12978894309,30.6019948234464,23.7614377259162,1.15544818145506,-2679.26243464823,355.26858826358,15.3201062964733,1.2286063871769,2937.72754052877,-330.565887705516,43.2335694684161,0.849913736810902,-5282.86697090711,1035.69692009497,-32.4573900837317,2.24767345654054,8875.02806331279,-1733.58734859842,148.099944235064,-1.67643927598835,-11992.9362800776,2955.44423936122,-203.10852170311,7.09206542360175,12654.3475320414,-3300.03639215419,326.105139723123,-7.83175982861771,-7495.61805679675,2406.43386260504,-212.585652326148,9.11904376119878,5691.33096604128,-1719.7624866419,217.776626900289,-5.84321814657309,-3620.44688766037,1467.65907268139,-145.908173018504,7.98892707700361,-1909.17353574738,832.092149778652,-67.2249879633503,4.74193430705345,10238.158131749,-4036.5583825542,583.226723156439,-24.224848561479,-28729.1286101233,12738.858559819,-1824.04560807451,90.9230112824606,25110.7610760203,-11214.5083615188,1728.23870635983,-84.6782433278399,7516.05427858893,-3127.98111746061,489.3827325699,-21.4139982664423,-66506.9484736439,32003.3359888114,-5068.39163364295,271.665969978814,118650.094373469,-58538.4579634844,9689.92078058512,-530.202337860836,-138276.17974452,70952.3841919927,-12064.5407015304,688.047505138046,56448.2883316827,-29934.3627182896,5358.60048986699,-314.944656113967,73160.3717967408,-38843.5744133985,6941.7674080988,-408.720909903762,-169977.912929947,94420.5194451269,-17405.5825398583,1074.03270192652,188710.252068492,-107233.966916992,20384.4682043852,-1286.58580123051,-199228.791363334,116684.448951927,-22697.4350087768,1476.4002581742,148677.921188101,-89137.1621934973,17890.5867091045,-1191.58570274823,-42196.7552956044,26647.4165615402,-5521.05511517578,386.358956207481,-59165.221220736,37189.9244408054,-7704.40849697353,537.083117995924,50664.7542970469,-32628.9909959777,7090.2196840709,-507.910785856635,75238.9042140513,-48619.390346959,10558.5373033032,-758.670149727074,-202717.265591095,136416.031892479,-30500.8228916115,2278.35385935797,205757.526583293,-141265.131827742,32421.7288073765,-2474.39621230596,-146947.282863926,103794.169776095,-24334.005444087,1907.14647190984,27238.5229341839,-19738.4036960317,4869.09492473971,-394.057837160065,112620.254082079,-81546.2388734905,19783.3255530615,-1593.65912069295,-218723.478683076,163283.645266548,-40518.2749106007,3357.1022773725,198878.92244723,-151296.243504912,38472.7351599834,-3254.44526553127,-65621.7899419199,51919.6538235113,-13570.8561460093,1188.34264561561,-99191.0484132843,78204.3832072766,-20431.1705149232,1785.18999572084,224351.245330305,-179788.241824359,48143.2692183654,-4290.50536465876,-293391.177148626,240825.702197073,-65758.9868227478,5991.07161398506,149060.828993007,-124860.880878545,34987.6668146696,-3260.82941171433,79538.1414664743,-66357.5393252982,18577.479508923,-1726.4768986233,-158866.859301671,137836.343832793,-39719.8741326136,3821.48792292541,22539.1743593186,-20150.1708831895,6143.61108934889,-616.56866372689,144026.877544788,-127739.680824164,37904.0344237881,-3741.79431984008,-244403.673733776,222080.873657644,-67112.0960316511,6766.8198010599,298431.461961281,-274613.275502777,84379.6194624938,-8634.83794082003,-321904.58074908,302299.244217545,-94463.2616508603,9845.59310755599,107391.364513353,-102999.057704762,33084.1139640994,-3534.12659445335,0,0,155.315215886901,-25.014274519042],700),
new ( [-0.0818,-0.0671,-0.0524,-0.0426,-0.0329,-0.0229,-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,14.7440429528461,1.10606271354281,1027.08798052511,252.04739042086,35.3615194892722,1.66823257376937,1160.75250649613,278.954059498824,37.166956984404,1.70861419241048,-751.862958587054,-21.7090916122668,21.4122078661829,1.43343124114555,-3213.06604309416,-336.250845812263,8.01272913726296,1.24315864319489,4867.41928995642,461.293056559815,34.2519235253043,1.53091514165041,-3865.76848035262,-138.676943260418,20.5126105294212,1.42603838578183,4120.4421366875,177.576997174385,24.6871625431604,1.44440641464229,-10684.4634063542,22.1254889724387,24.1430822644536,1.44377165431713,6318.32943856281,-54.3870788296878,24.2578511161568,1.44371426989128,-2717.86889359708,251.94004463054,20.7963546210563,1.45675257335616,1291.55292689258,-60.7948573676464,28.9274620730093,1.38628297543923,699.753390588095,11.4638660150775,25.98653203133,1.42618159300469,-2685.26033902159,574.053147876257,-5.18091418377849,2.00174043311033,1900.17934247446,-322.858853824332,53.2977483271039,0.730804167873978,2347.55577108765,-423.384337333844,60.8271070419565,0.542821178626409,-4887.70858469765,1412.92575616455,-94.5247268679883,4.92374289488755,5842.10455143125,-1625.75732398711,192.326955898314,-4.10252338949259,860.442979127457,-66.9954180137333,29.7480891052461,1.54980187934472,-8376.14506025033,3094.68866786497,-331.000065093523,15.2702566773728,11077.5399681569,-4130.40995168427,563.467144006752,-21.6414234848343,-5075.87593052615,2343.87914051205,-301.497878710249,16.8783521935062,-2292.21973457744,1145.51514813862,-129.532645806825,8.65268188628391,-17568.784361742,7942.05875080797,-1137.46006208176,58.4778938306729,68271.5993070173,-31510.1815833803,4906.623157122,-250.173289229674,-106196.496167652,51292.37652891,-8192.74153624969,440.59987560041,128778.333858822,-63610.3153540797,10536.3972406775,-577.016664612041,-141205.764180921,72461.6700580362,-12323.6963085519,703.148574144075,57170.057765039,-30316.8432922212,5426.15294703973,-318.651081335213,72964.256838067,-38736.7308179449,6922.36696036247,-407.276824725421,-169915.751046423,94385.8015034559,-17399.1196947399,1073.90171257158,188676.144275696,-107214.562046626,20380.7884345217,-1286.08321523679,-199145.78993119,116636.258377584,-22688.1094150941,1476.06876685201,148396.490736788,-88969.7548656966,17857.3963964709,-1189.12248182843,-41125.6499578061,25994.375679688,-5388.35079980165,377.640879199758,-63285.0279604194,39761.997232717,-8239.62522343711,574.473856911266,65248.1745764321,-41946.5596199183,9074.41797364094,-648.474727575786,21077.1438003888,-13204.4698939702,2840.25871209009,-197.745012964706,-79052.1717177173,53451.6154465325,-11950.7266249575,896.294869130986,52126.0112863692,-35723.3133598051,8256.3122425179,-630.010133326225,20118.2863883862,-13484.34610092,3105.7674254244,-232.388073443865,-127247.201454893,91027.2578776146,-21600.7757552117,1714.48752919105,224975.018704271,-163946.407295377,39924.3696511342,-3234.18499965633,-273196.092839357,204152.227024236,-50738.3239818141,4209.22214760305,213607.247797357,-162556.729477256,41342.2949957378,-3497.92566081512,-73082.3133966064,57706.860388176,-15067.2103687954,1317.56578046339,-84069.9178541035,66310.1546782689,-17312.6701784724,1512.92078391556,174249.375325092,-139673.649703012,37437.8250259805,-3337.97309120437,-188139.286658763,154730.899292735,-42286.9268420255,3858.51451074701,59564.5633406402,-49996.3327315938,14115.4255807016,-1321.10152007074,88665.6356282356,-74484.8850617082,20984.4645092716,-1963.35665989552,-107677.862127594,93683.3207658581,-27027.5582546171,2605.78750647165,-14269.4687873384,12333.9510063147,-3411.83621332466,320.572803590214,153666.399572158,-136390.054012861,40491.4900684698,-3999.51450252126,-247121.528023805,224559.553580094,-67865.5821310298,6843.41652223316,299124.134807412,-275255.227910647,84577.9262235845,-8655.00682714843,-322101.34712787,302484.470289052,-94521.3802183196,9851.92150518438,107427.435627893,-103033.653510712,33095.1733414792,-3535.05496323807,0,0,155.314314109038,-24.7639862206591],800),
new ( [-0.1013,-0.0818,-0.0671,-0.0524,-0.0426,-0.0329,-0.0229,-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,12.7180094845662,1.19833436078655,1618.20867525898,491.7736164112,62.5346768270208,2.88047716138343,-1431.35303695397,-256.588827765856,1.31862889333803,1.211319587725,573.337525503578,146.955382456853,28.3964453992819,1.81696008357461,959.829228496437,207.711878167315,31.5800857745091,1.87256766879526,-3676.55731340397,-384.818321887581,6.33829925217141,1.51413430017808,4987.03522977657,470.278262124345,34.4709768661637,1.82265599801152,-3899.35269595668,-140.21658837348,20.4906447897625,1.71593946316165,4130.0971324611,177.749624831841,24.6877988040733,1.73440694082462,-10690.0209829372,22.1383846201737,24.1431594633326,1.73377152826042,6318.74946770966,-54.4010824077255,24.2579686638744,1.73371412366015,-2717.70890445603,251.934856408691,20.796372555249,1.74675280233598,1290.72095261128,-60.7226724425596,28.9254683053813,1.67630063916816,702.921298572178,11.0476653156211,26.0044155586239,1.71592958809918,-2706.2717316309,577.655546935452,-5.38566108311288,2.29559967008318,1983.89639945749,-339.741339505342,54.4286159128333,0.995636050037917,2033.59509138167,-350.908635580919,55.2650463888807,0.974753169152571,-3731.87710408596,1112.36820762892,-68.5281745466859,4.46572199953548,1593.14728136538,-395.678698330934,73.8314533759498,-0.0138609590966734,6292.84183793698,-1866.21312508193,227.208194085991,-5.34625897778239,-4481.64495622097,1821.89370455769,-193.604795175802,10.6586617138085,-9734.56582997158,3772.82851706965,-435.130524964945,20.625623496432,31595.7883676495,-12792.3774453401,1777.98099161279,-77.9316093751544,-83474.0677410994,36745.1956094822,-5330.66074175501,262.098420204264,27080.8175256437,-12440.672845733,1963.6035501531,-98.4813779588619,56415.8062955766,-25923.0336843597,4029.10123062922,-203.959459508999,-102212.228638647,49361.8316954398,-7880.96447244868,424.098005233434,125487.535431854,-61983.3529350636,10268.3006223147,-562.012064915183,-131054.115257154,67313.6390122465,-11453.5940248188,654.414035324814,22863.2092369353,-12430.9268082048,2318.29249235366,-138.387565181579,119883.194822026,-64152.2811236774,11509.1771542218,-682.794299985433,-158327.100260627,88334.7816111808,-16350.2092074409,1013.84232943937,98837.4792386128,-56243.1449831839,10743.694236349,-678.623505683231,-98077.5641701719,57416.2180723176,-11124.3672155259,723.848168764547,100680.855383322,-60169.2629355525,12063.489639221,-800.366955154211,-31510.7968947909,20018.193336353,-4150.41401894415,292.450151406272,-52223.7547592898,32887.154057531,-6815.57578433745,476.435151942522,13973.4300301025,-9194.39631301796,2101.50473921533,-153.40796903775,134727.587028018,-87769.1262717727,19144.3636672729,-1385.60666953406,-243279.561089263,163870.232230003,-36694.4099842786,2744.60128822539,216495.361378058,-148684.760063263,34130.5512693551,-2605.04411846626,-152743.465735742,107862.377015527,-25285.7656780731,1981.89554987495,38824.4781580278,-27997.6087939855,6831.53496730727,-548.947740981704,73111.721693869,-52818.1443897571,12820.7302065661,-1030.67867805655,-154331.017224868,115239.295397623,-28571.8172130786,2367.64946509357,160259.740028855,-121741.922041709,30934.1664859199,-2613.00137051876,-57674.9058117556,45697.2663577865,-11947.0096631699,1047.62170008106,-90919.1972603603,71727.5465616444,-18740.9127964602,1638.6912726715,185272.697234284,-148507.870108142,39797.6609544568,-3547.82636165134,-228851.92569234,187926.973557209,-51308.8947101769,4676.05872967413,119324.571353698,-99840.9012510852,27971.1547995474,-2604.4924836357,51034.3541809876,-42374.6835004948,11851.8807204775,-1097.34035724161,-97047.2308351056,84457.1940659046,-24358.6203247551,2348.69232556518,-17032.657154906,14772.5018478922,-4129.15417386788,391.154317669445,154390.028939523,-137039.428957311,40685.7277998697,-4018.63006852938,-247325.55465286,224745.625626592,-67922.1455859914,6849.39779497319,299176.133071095,-275303.418641139,84592.8129154453,-8656.28965269576,-322116.118184611,302498.37502642,-94525.7431214638,9852.62780446233,107430.14345067,-103036.250583544,33096.0035579726,-3534.89342221292,0,0,155.314246413468,-24.5139645783855],900),
new ( [-0.121,-0.1013,-0.0818,-0.0671,-0.0524,-0.0426,-0.0329,-0.0229,-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,11.2077954454316,1.30614324889723,1204.18320008687,437.118501631533,64.0991341428475,3.43942724302632,-398.150960113301,-49.8308496532957,14.7711648576938,1.77378614683095,52.6133226133311,60.7867053278263,23.8196808551495,2.02050901636161,-480.533518027741,-46.5357536932321,16.6183438548366,1.85943911212128,5686.22348946839,922.878447885173,67.4156480175458,2.74669869149658,-10927.5960194764,-1200.367685358,-23.0346372586128,1.46230464057512,7530.00766739058,621.397798535802,36.9014471614919,2.11960369971563,3740.94748258258,361.08936383946,30.9403840069459,2.07410091763592,-18252.17074851,-509.838118111821,19.4441412451893,2.02351744948419,49948.4331719257,206.26822305277,21.9505134392652,2.02644155037728,-16872.3494325329,506.961744772837,21.4994731566851,2.02666707051857,4594.17278921093,-220.753358544277,29.7226538241685,1.99569309000438,-1533.45858495037,257.201888640318,17.2958173973692,2.10339233903664,1539.66155059121,-118.026079909355,32.5675957173391,1.89620521316238,-3372.70939433857,698.409971137992,-12.6629615106795,2.73146283663972,3293.39356197792,-605.479767117458,72.3506494235853,0.883833692335389,-2534.34791235671,704.013742165603,-25.7304144217321,3.33259091967335,2369.89750295551,-540.68374424094,79.570992928275,0.363091232403327,2914.45576709594,-694.902644645347,94.1292571264652,-0.0950088143656594,-5161.71798923549,1832.13212371013,-169.440469213061,9.06843200470562,8147.79905288486,-2723.71555980728,350.381751476597,-10.7021397888474,-16061.195048692,6267.50484951617,-762.731335198008,35.2323269212368,33644.6884857237,-13654.6132710769,1898.86364571326,-83.2973695620143,-87401.0522597759,38455.5781198626,-5578.94881888602,274.391326661343,38152.5137289725,-17403.203388528,2704.90847881007,-135.107352421265,17144.7345732249,-7748.02808852684,1225.73562284546,-59.570925243673,-38291.5992501916,18562.0559440317,-2936.51967110606,159.918670590769,88424.6091375865,-43402.1699575783,7163.64915085881,-388.857168736108,-129732.88263574,66549.2058962039,-11308.1819925717,645.565375296096,55032.8183961522,-29177.9038083762,5223.88985341163,-306.130893971201,70996.1469792016,-37687.9542761194,6736.12582152003,-395.705671148261,-158994.129108708,88369.7160476424,-16294.610546629,1006.86617367219,150194.93512433,-85456.3758641104,16280.3990776384,-1027.98609419033,-138569.3886275,81218.3918054576,-15787.8262219952,1028.65608835864,123257.119356528,-73678.1703178942,14757.7758287395,-979.208153108718,-84636.6363080552,52430.1818682281,-10741.33298332,739.431780822758,52530.6536320095,-32791.8553715414,6908.15092905347,-478.97092526055,-84191.8240864869,54122.6237143018,-11509.0271892134,821.895755825544,180206.663510255,-117921.472165209,25807.3372070261,-1876.07739002085,-245853.291247667,165706.639717369,-37129.7408197025,2779.16848135535,180548.351912214,-124161.197302804,28554.3110490531,-2182.16690313165,-89735.5789481502,63632.077858997,-14938.6114784285,1175.48671599108,2279.77837953605,-1625.21355781001,488.212212528076,-40.1469908550823,70610.1136877114,-51089.5432873476,12423.954976273,-1000.17856715344,-106073.077779027,79461.6668873049,-19730.8080897434,1639.72748056971,59303.9654567084,-45116.8597820822,11550.8599569504,-978.548134935288,56192.5167492908,-42726.333740632,10938.6462376538,-926.285490440271,-192949.015067311,152351.485672429,-39976.664629112,3503.34655496411,299219.959839209,-240104.054918439,64338.0180599174,-5738.93433127862,-340984.146742217,279997.761268276,-76505.5537634387,6974.54541864072,170457.436672463,-142708.707423817,39950.0783613056,-3719.96346481242,37967.2222424478,-31218.1919808601,8676.98877951962,-795.929588916334,-96123.1785902958,83630.2363325825,-24112.2375040117,2324.51177906597,-7176.91747165675,6166.93752429693,-1624.64185997202,148.462107227047,115274.700399087,-102276.215262296,30387.7768425733,-3001.55989307555,-182807.972210646,166177.039690481,-50201.8902942052,5062.77946507442,259688.086854909,-238706.854355026,73287.6973897265,-7491.99528279516,-310898.817108005,291938.966330737,-91212.5070228614,9506.35917316936,105373.793402448,-101064.005252294,32465.5281343199,-3467.46671481826,0,0,155.365655164678,-24.2803999561478],1000),
new ( [-0.1602,-0.1405,-0.121,-0.1013,-0.0818,-0.0671,-0.0524,-0.0426,-0.0329,-0.0229,-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,9.41845138236001,1.32883591145407,582.902595793244,280.142987538234,54.2973579859854,3.72536952408765,0.939605903008523,34.845587299496,19.8330732524422,2.11129218906675,157.929415038355,91.8328880156288,26.7285366390942,2.38940921232836,16.4326513984407,48.8320215454601,22.372548865665,2.24232202517891,1268.97135834948,356.20502023123,47.5156601581638,2.92789085975436,-2995.73129266129,-502.279623417215,-10.0886594306491,1.63947424495128,8340.43947291416,1279.76642093125,83.2905532932099,3.27049782719469,-11882.3512432307,-1304.70623259205,-26.8079817468837,1.70709862962535,8622.20718732065,719.093684503378,39.7750355255565,2.43729238571311,156.96307095868,137.531413709255,26.4572595243724,2.3356333622374,-5004.78043232056,-66.8736290205716,23.7591129603386,2.32376151735565,1132.57959245201,-2.4313487604882,23.9846609412488,2.32402465666671,4984.01258826286,-19.7627972416489,24.0106581139705,2.32401165808035,-2108.05737614174,220.658374551667,21.2938988727059,2.33424478455578,-314.095185943674,80.7293237162098,24.9320541944277,2.30271410510086,3364.43811991619,-368.419592929265,43.2124151018991,2.05471054212284,-5674.65198010245,1133.87718169374,-40.0148262122186,3.59164026505679,4009.51896154217,-760.346654491889,83.488567907088,0.907499832863961,-3064.92146284142,829.280108867022,-35.5744766684863,3.88010717910105,3757.29590628624,-902.198659417418,110.908627128396,-0.250716347970911,-2036.68816190439,738.657628694084,-43.9882064693784,4.6233706825718,2883.75954651689,-800.950459271415,116.592917105389,-0.959499713711698,2151.94895643277,-550.451694284778,88.0110080205436,0.12756556181293,-11053.3833006452,4354.00870599422,-519.161189534142,25.1835382475695,19731.2569988293,-7984.4751260343,1129.26025042477,-48.2261632119468,-33102.2386889613,14760.3447675488,-2134.62140430391,107.896175939247,-9744.92125223396,4368.67423993932,-593.536665059338,31.7152203295107,66890.2996100645,-30852.8732683094,4802.40441321486,-243.837504067501,-108436.886151859,52357.4090943158,-8361.46225655415,450.337064984987,138676.700120401,-68481.134592852,11335.2203644422,-619.84935742307,-181800.024319195,93039.1345246085,-15800.1848472941,899.733334434449,117616.593352764,-62088.6150911161,10990.3775113422,-642.510038678547,32500.2632751632,-16713.0995269038,2927.14839556857,-164.898100720959,-147786.692992661,82102.1812036448,-15126.4033938862,934.56320325735,147182.958430191,-83729.7568262991,15950.5017929362,-1006.70747407909,-136778.550889206,80172.8263528664,-15584.3552107415,1015.72802175689,119461.04730467,-71418.5199386607,14309.4582779442,-949.291984899691,-70839.769157926,44017.9553275288,-9031.79702088088,623.908622241393,-354.646304167253,225.548498444052,37.6104334098568,-2.1828056876816,22967.3528650187,-14600.2463734963,3179.19636677582,-224.083492113125,45123.2985025535,-29017.1201997982,6306.21629969847,-450.167033265774,-137410.363822367,92495.5388099989,-20657.4427345768,1544.24494663818,164215.256861693,-112549.558130972,25805.7762322741,-1965.27685932401,-129074.138138008,91227.913514721,-21389.0862008716,1678.16652051575,201.074624309166,-454.067376181126,284.534081755773,-29.7147577566151,120730.203466705,-87705.1037452129,21338.2091575949,-1723.1320230228,-142752.842448567,106982.518881601,-26613.3522954338,2213.69117226733,68625.6690439824,-52248.9138257313,13369.6604574436,-1132.88699514454,53606.7378155558,-40709.8689628327,10414.5110680504,-880.615742266408,-192191.34629283,151750.030893661,-39817.522794588,3489.57120376153,298855.788825165,-239810.954649167,64259.3871626937,-5731.64301844114,-340187.737801821,279348.006382405,-76328.8594846229,6958.78937892549,167872.027535646,-140563.389668839,39356.7301274897,-3665.00393379147,47503.4266189803,-39273.2119975836,10944.8352907082,-1008.49176654611,-133728.96866485,115952.334562995,-33372.0582523432,3208.99926896908,44966.1237011323,-39673.2213780739,11806.0406375181,-1162.7347669453,113249.059626031,-100144.589433618,29657.1884873413,-2919.28771536701,-225307.03562111,204759.029946473,-61874.8780504877,6240.02107619145,256611.500421874,-236196.430532765,72616.537395671,-7433.27282751154,-256657.037669063,241143.309891328,-75358.7821358256,7857.51019075001,77773.2914730832,-74592.3638518378,24003.2343911454,-2565.56534292828,0,0,156.055667712981,-24.2509969678396],1100),
new ( [-0.1699,-0.1602,-0.1405,-0.121,-0.1013,-0.0818,-0.0671,-0.0524,-0.0426,-0.0329,-0.0229,-0.0132,-0.0035,0.0015,0.0113,0.026,0.0407,0.0554,0.0652,0.0749,0.0846,0.0944,0.1043,0.1141,0.1238,0.1336,0.1435,0.1483,0.1532,0.1582,0.163,0.168,0.1727,0.1777,0.1827,0.1874,0.1924,0.1972,0.2022,0.2071,0.2119,0.2169,0.2219,0.2266,0.2316,0.2364,0.2413,0.2463,0.2511,0.2561,0.261,0.2658,0.2708,0.2755,0.2805,0.2855,0.2903,0.2952,0.3002,0.305,0.31,0.3147,0.3197],[0,0,9.24559889841045,1.56082725283993,348.088182095618,177.420546414128,39.3893497341706,3.26796834183859,260.938929219718,135.536615481986,32.6795439988404,2.90966471557189,589.703932487203,274.111064359224,52.1492540660937,3.82149613705491,-537.357736903761,-135.012321629684,2.64532436143329,1.82483763896696,923.288983532041,308.878216710749,47.6114358953226,3.34319333842786,-2295.93750723854,-481.119964124356,-17.0104152969898,1.58117086258418,3430.08303980313,671.527971995165,60.3322612166288,3.31106872727212,-1245.88160516047,-63.533670193166,21.8150311659611,2.63830110905382,-8022.18992266535,-929.545873170321,-15.0770886808665,2.11443300722889,13404.2328686871,1185.24205633621,54.4994341998996,2.87745554148793,-12618.5368229158,-602.522221476936,13.5596322379785,2.56494838651192,8583.1463295478,237.064431360613,24.6421760554341,2.61371157930873,-1314.50552089296,133.139086930992,24.2784373499302,2.61328721748564,-4222.93810159112,146.227033544136,24.2588054300105,2.6132970334456,2497.27477640817,-81.5881830200645,26.8331173771858,2.60360045844457,-311.598846135456,137.503959538348,21.1367216706674,2.6529692212344,-1250.8793918662,252.190114172043,16.4689951770749,2.71629471066413,3594.08311999638,-553.042655299464,61.0788906057993,1.89249864174716,-1807.20029819005,503.448381297808,-7.80432498034209,3.38956052715268,30.0668799383383,90.6144463724166,23.1169367455662,2.61755969272905,-2721.45185953292,788.949902450276,-35.9622428386159,4.28359255700296,10178.8645479554,-2864.41970415071,308.915848024517,-6.56857136882271,-8464.38678757735,2969.05363873738,-299.51542163873,14.584555773136,3446.56591646931,-1108.06547185789,165.683868880234,-3.10852390960101,-4817.78772073349,1961.31546899985,-214.305491597972,12.5723703661258,14839.566105054,-5917.35194437255,838.284474828741,-34.3029694720691,-29187.8865739201,13036.4664339178,-1881.58846245598,95.7976193613911,-13105.9155889646,5881.59754271409,-820.521405888458,43.345537865333,76251.1196327931,-35186.8958452017,5471.1717811335,-277.950260885465,-144482.070076046,69573.0759905684,-11101.8557632865,596.000724956579,186345.251303143,-92201.4841637803,15267.3975418736,-836.728704623598,-171067.041275624,87934.3112958604,-14995.416095343,857.988859060371,30197.3661671472,-16340.778200186,3012.89186063663,-178.689402270915,127222.284769471,-68064.7623070821,12204.2438364265,-723.123817638026,-198356.104923475,110384.753083577,-20398.4826254415,1262.38222389063,159749.810962604,-90942.3928275047,17330.2245182833,-1094.40434902199,-140561.156590739,82397.0976441983,-16020.2934484796,1044.47553658046,121274.148607632,-72504.6689111251,14526.3349162406,-963.456167927216,-74591.8482423353,46307.6447780654,-9497.51491171989,655.751310477668,13197.5343386186,-8235.89861936866,1798.45292588146,-124.047002580024,-24783.2111785307,15908.4613058562,-3317.73694227203,237.326541775058,142406.472077434,-92881.8655888565,20278.8849611907,-1468.70922184657,-234191.473116995,157819.386527126,-35351.7228833108,2646.10140505494,175157.833715073,-120456.272257335,27705.5413972258,-2116.82395693741,-78397.661190099,55714.0856026215,-13095.5134831741,1033.01747982789,-36475.1923432489,25982.6706963419,-6067.00699932766,479.171168901236,130338.104341183,-94773.4747733392,23071.4509025586,-1864.53212833642,-145473.778794794,109023.925676025,-27123.8488281208,2256.50197955265,69361.6797839328,-52811.625271489,13513.0580146764,-1144.80712319661,53232.7591007329,-40419.7755105471,10339.5052909375,-873.891505679837,-191430.928767808,151151.892090076,-39660.6999528677,3476.12635053799,296335.082243153,-237792.72508967,63720.7792936309,-5683.47271070494,-330046.077686953,271079.329237423,-74081.7730182355,6755.50434464745,132832.081716719,-111489.469509493,31315.9310366417,-2923.51814439175,97341.1797414036,-81623.8754974171,22938.6319162212,-2140.2406766349,-135495.559678021,117800.791815257,-33997.1106014803,3278.14415297246,3057.02841526864,-2864.65715490014,1032.06923449905,-111.512815830807,112594.613921226,-99871.1428789708,29668.3838201914,-2929.32617106359,-182052.324316392,165487.889698094,-49992.3977593512,5042.06270566449,259495.502294317,-238528.371650551,73232.561951994,-7485.80819831975,-310844.109944388,291887.467730835,-91196.3482563011,9505.17918986734,105363.764512435,-101054.386543885,32462.4532839581,-3466.6290917024,0,0,155.365905886929,-23.7704801120513],1200) ];

    public static double NaCl_Brown(double v, double v0, double T)
    {
        if (SplineBrown == null)
        {
            InitializeSpline(ref SplineBrown, Brown);
            string code = deveropper(SplineBrown);
            Clipboard.SetDataObject(code, true);
        }
        return GetPressureFromSplineMethods(SplineBrown, 1 - v * v * v / v0 / v0 / v0, T);
    }

    #region double[][] Tsuchiyaの定義

    private static readonly double[][] Tsuchiya = [
                [double.NaN,300,500,1000,1500,2000,2500],
                [0,0.00 ,1.52 ,5.35 ,9.19 ,13.04 ,16.88 ],
                [0.02,3.55 ,5.04 ,8.78 ,12.54 ,16.29 ,20.05 ],
                [0.04,7.68 ,9.13 ,12.79 ,16.45 ,20.12 ,23.79 ],
                [0.06,12.42 ,13.83 ,17.40 ,20.98 ,24.56 ,28.14 ],
                [0.08,17.86 ,19.23 ,22.71 ,26.20 ,29.70 ,33.19 ],
                [0.1,24.12 ,25.46 ,28.85 ,32.25 ,35.66 ,39.07],
                [0.12,31.30 ,32.60 ,35.90 ,39.22 ,42.54 ,45.86 ],
                [0.14,39.52 ,40.78 ,43.99 ,47.22 ,50.45 ,53.68 ],
                [0.16,48.94 ,50.17 ,53.29 ,56.43 ,59.58 ,62.72 ],
                [0.18,59.76 ,60.95 ,63.98 ,67.03 ,70.09 ,73.15 ],
                [0.2,72.11 ,73.26 ,76.21 ,79.18 ,82.14 ,85.11 ],
                [0.22,86.36 ,87.48 ,90.34 ,93.22 ,96.10 ,98.98 ],
                [0.24,102.65 ,103.73 ,106.50 ,109.29 ,112.08 ,114.88 ],
                [0.26,121.38 ,122.42 ,125.10 ,127.80 ,130.51 ,133.21 ],
                [0.28,142.98 ,143.99 ,146.58 ,149.19 ,151.81 ,154.43 ],
                [0.3,167.77 ,168.74 ,171.24 ,173.77 ,176.30 ,178.83 ],
                [0.32,196.48 ,197.41 ,199.83 ,202.26 ,204.70 ,207.15 ],
                [0.34,229.56 ,230.45 ,232.78 ,235.13 ,237.49 ,239.84 ]];

    #endregion

    private static Spline[] SplineTsuchiya = [
new ( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34],[0,0,171.408510733482,0,15228.7231662956,0,171.408510733482,0,-3643.61583147784,1132.34033986641,148.761703936154,0.150978711982192,3095.74015961646,323.617620935105,181.110612693406,-0.280340071447845,2510.65519301335,428.932914923702,174.791695054095,-0.153961718661658,1861.63906833068,584.696784847463,162.330585460189,0.178334537175664,2542.78853366499,380.35194524723,182.765069420206,-0.502814928158574,2967.20679700653,227.561370443849,201.099938396572,-1.23620968721187,5588.38427830942,-873.333171703494,355.225174297239,-8.42872069591014,-320.743910248741,1963.04835880424,-98.5958705840568,15.775068364426,11944.5913626759,-4660.2326885741,1093.59471794412,-55.7563669472699,-1207.62154045138,3231.09505330104,-484.670830431211,49.4613362777557,10385.8947991121,-4420.62573081097,1198.70774207391,-73.9864257059424,9664.04234399408,-3900.89196312756,1073.9716378289,-64.0075373663531,4707.93582488492,-35.128878226853,68.8732357539993,23.1009908133128,11504.2143565044,-5744.00284478301,1667.35794639075,-126.090915512526,40525.2067485657,-31862.895997636,9503.02589224791,-909.657710098196,-117355.041349811,119702.142176807,-38997.7863235744,4263.76225958939,0,0,1700.94201653995,-348.760285623583],300),
new ( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34],[0,0,170.045691643671,1.52,14885.7708908211,0,170.045691643671,1.52,-3178.85445410563,1083.87752069561,148.368141229759,1.66451700275942,2829.6469256014,362.857355130761,177.208947852351,1.27997291445816,3110.26675170109,312.345786432881,180.239641974229,1.21935903202067,979.286067593219,823.781150618539,139.324812839358,2.31042114228355,2972.58897792606,225.790277518876,199.123900149332,0.317118231951572,3380.35802069774,78.9934221208459,216.739522797118,-0.387506673959537,4755.97893928496,-498.767363685881,297.62603281005,-4.16221047456213,95.7262221605205,1738.15394053447,-60.2813758651316,14.9261846547763,12361.1161720703,-4885.15663241662,1131.91452726587,-56.60556953309,-2040.19091043133,3755.62761708282,-596.242322633933,58.6048871269058,10799.6474696397,-4718.665713765,1268.10221015246,-78.1137119440934,10091.6010318735,-4208.87227857386,1145.75178570567,-68.3256779883122,3833.94840284984,672.09677206201,-123.300167459325,41.6588246191877,12072.605356772,-6248.37506922754,1814.43194810185,-139.196172833013,40375.6301695481,-31721.0974007249,9456.24864755291,-903.377842778107,-117325.126034006,119671.628554687,-38989.4236581801,4264.16053649993,0,0,1698.93005041363,-347.186217140634],500),
new ( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34],[0,0,165.375814147138,5.35,15310.4646321535,0,165.375814147138,5.35,-4052.32316076809,1161.7672675753,142.140468795632,5.50490230234338,3398.82801091884,267.629126972899,177.905994419729,5.02802862735542,2957.01111709381,347.156167861315,173.134371966422,5.12346107642147,1023.12752070372,811.288230994849,136.00380691573,6.1136094777732,2950.47880009124,233.082847178811,193.824345297358,4.18625819838596,3424.95727892831,62.2705947972741,214.321815583126,3.36635938695682,4599.69208419661,-431.118023415412,283.396222132934,0.142887081301501,676.27438428394,1452.12247254309,-17.9222572203664,16.2132059801419,11445.210378664,-4363.10296442184,1028.81832143337,-46.5912287390862,-1457.11589892926,3378.29280213251,-519.460831877921,56.6273814816426,10633.2532170336,-4601.35081440259,1236.06076376014,-72.1108688651123,10174.1030308015,-4270.76268031853,1156.71961157884,-65.7635766906233,3670.33465974033,802.176649108063,-162.244614072464,48.546656199067,12644.5583302835,-6736.1712341425,1948.49279323861,-148.455501816541,39501.4320186228,-30907.357553646,9199.84868909139,-873.591091401817,-116900.28640382,119238.292131896,-38846.7592102829,4251.38041786477,0,0,1694.26011456155,-343.268438950928],1000),
new ( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34],[0,0,161.724298889713,9.19,14439.2527757183,0,161.724298889713,9.19,-2196.26387859161,998.130999258588,141.761678904541,9.32308413323448,1845.80273864801,513.08300518991,161.16359866729,9.06439186973116,3563.05292400096,203.977971826399,179.709900669098,8.69346582969493,1401.98556534982,722.634137902456,138.21740738301,9.79993231732401,2079.00481460058,519.528363127377,158.527984860508,9.12291306807434,4031.99517624486,-183.548167064827,242.897168483566,5.74814572315161,4293.01448042336,-293.176274819533,258.245103569326,5.03190875248219,1295.9469020551,1145.41616279543,28.0703135507219,17.307897553476,10523.1979113452,-3837.29938221896,924.959111653265,-36.5054303326942,-888.738547429104,3009.86249304396,-444.47326339947,54.7900613374995,10531.756278364,-4527.66409197711,1213.78258530572,-66.8153675675102,10011.7134339827,-4153.23324402783,1123.91918179711,-59.626295286791,4421.38998568174,207.219045645907,-9.79841351928189,38.6292296404408,11052.7266233363,-5363.1037299796,1549.89196365722,-106.941872229123,41367.7035204582,-32646.5829373822,9734.93572587939,-925.446248451481,-117773.540704189,120129.011518272,-39153.2544999304,4289.29404230166,0,0,1690.6094162817,-339.677201535778],1500),
new ( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34],[0,0,156.40819792221,13.04,15229.5051944739,0,156.40819792221,13.04,-3647.52597236936,1132.62187001062,133.755760521998,13.1910162493348,3110.59869500278,321.646909925905,166.194758925387,12.7584962706229,2455.13119235856,439.631060401786,159.115709896829,12.9000772511941,2068.87653556025,532.332178033589,151.699620486311,13.0978396354747,1769.36266540074,622.186339081335,142.7142043815,13.3973535056345,4603.6728028321,-398.165310394312,265.156402318588,8.49966558815246,3565.94612327105,37.6798950214466,204.138073560352,11.3471875968727,1132.54270408369,1205.71353623112,17.2526909668051,21.3144080018587,11903.8830603862,-4610.81025617252,1064.22697359914,-41.5040489560952,-2498.07494562318,4030.36454743434,-664.007987121968,73.7116150919706,11838.4167220921,-5431.71995325781,1417.6506030305,-78.943348185849,8894.40805725587,-3312.03371457756,908.925905746284,-38.2453724030738,5083.95104887814,-339.8772480482,136.165224448341,28.7272199759736,10769.7877472695,-5115.98007468972,1473.4740159089,-96.0882672268781,41836.8979615252,-33076.3792675212,9861.59377376037,-934.900243011827,-118117.379592404,120479.727184253,-39276.3602908086,4306.48152387521,0,0,1686.74695183699,-336.003963624576],2000),
new ( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34],[0,0,152.545456925199,16.88,14886.3576870025,0,152.545456925199,16.88,-3181.78843501295,1084.08876732095,130.86368157878,17.0245451689761,2840.79605305053,361.37862875328,159.772087121488,16.63909976174,3068.60422280986,320.373158196631,162.23241535488,16.5898931970721,1134.78705571111,784.489278300358,125.103125746606,17.5800075866264,2392.2475543457,407.251128710016,162.82694070562,16.322547087991,4296.22272690216,-278.179933410594,245.078668160119,13.0324779898141,4172.86153804438,-226.368234090951,237.825030255265,13.3709810920394,262.33112091722,1650.68636613125,-62.503705780203,29.3885136806006,12277.8139782854,-4837.67437684758,1105.40122795581,-40.685782343576,-1873.58703404342,3653.16623054917,-592.766893523368,72.5254257550277,10216.5341578735,-4326.31375611498,1162.71870354275,-56.2101846964861,11007.4504025665,-4895.77345229822,1299.38903062544,-67.1438108630355,3253.66423183249,1152.17976086831,-273.078804798133,69.1367348734966,12227.8926701401,-6386.17212730134,1837.65972389129,-127.865527803871,40334.7650870811,-31682.3573025446,9426.5152764651,-886.751083061507,-117316.953017512,119663.292077864,-39004.0925252666,4279.18041578995,0,0,1681.42678120703,-331.845105610391],2500) ];

    public static double Au_Tsuchiya(double a, double a0, double T)
    {
        if (SplineTsuchiya == null)
        {
            InitializeSpline(ref SplineTsuchiya, Tsuchiya);
            string code = deveropper(SplineTsuchiya);
            Clipboard.SetDataObject(code, true);
        }
        return GetPressureFromSplineMethods(SplineTsuchiya, 1 - a * a * a / a0 / a0 / a0, T);
    }

    #region double[][] Zha et al. レニウムの定義

    private static readonly double[][] Zha = [
                                [double.NaN, 300, 500, 1000, 1500, 2000, 2500, 3000],
        [0.00, 0, 1.31, 4.81, 8.54, 12.42, 16.34, 20.26],
        [0.01, 3.70, 5.02, 8.53, 12.25, 16.09, 19.98, 23.86],
        [0.02, 7.61, 8.94, 12.46, 16.16, 19.97, 23.82, 27.67],
        [0.03, 11.74, 13.07, 16.60, 20.29, 24.07, 27.88, 31.69],
        [0.04, 16.11, 17.45, 20.98, 24.64, 28.39, 32.16, 35.93],
        [0.05, 20.73, 22.07, 25.61, 29.24, 32.96, 36.68, 40.41],
        [0.06, 25.61, 26.95, 30.49, 34.10, 37.78, 41.46, 45.14],
        [0.07, 30.77, 32.11, 35.65, 39.23, 42.87, 46.50, 50.14],
        [0.08, 36.23, 37.57, 41.11, 44.64, 48.24, 51.83, 55.42],
        [0.09, 42.00, 43.35, 46.87, 50.37, 53.93, 57.47, 61.00],
        [0.10, 48.11, 49.46, 52.96, 56.42, 59.93, 63.42, 66.91],
        [0.11, 54.58, 55.92, 59.41, 62.82, 66.28, 69.72, 73.15],
        [0.12, 61.43, 62.76, 66.23, 69.58, 73.00, 76.39, 79.76],
        [0.13, 68.68, 70.00, 73.44, 76.74, 80.11, 83.44, 86.75],
        [0.14, 76.36, 77.68, 81.07, 84.32, 87.63, 90.90, 94.16],
        [0.15, 84.49, 85.80, 89.16, 92.33, 95.59, 98.81, 102.00],
        [0.16, 93.12, 94.41, 97.72, 100.82, 104.02, 107.18, 110.31],
        [0.17, 102.27, 103.54, 106.79, 109.82, 112.96, 116.06, 119.12],
        [0.18, 111.97, 113.23, 116.41, 119.35, 122.43, 125.46, 128.46],
        [0.19, 122.26, 123.50, 126.61, 129.45, 132.47, 135.44, 138.37],
        [0.20, 133.19, 134.40, 137.42, 140.17, 143.12, 146.03, 148.89]
                                ];

    #endregion

    private static Spline[] SplineZha = [
new ( [0,0.01,0.02,0.03,0.04,0.05,0.06,0.07,0.08,0.09,0.1,0.11,0.12,0.13,0.14,0.15,0.16,0.17,0.18,0.19,0.2],[0,0,365.591867178412,0,44081.3282158815,0,365.591867178412,0,-10406.6410794082,1634.63907885871,349.245476389824,0.054487969295292,7545.23610174972,557.526447989254,370.787729007214,-0.0891270481539724,225.696672416328,1216.28499662935,351.02497254801,0.108500516438082,1551.97720859477,1057.13133228741,357.391119121703,0.0236185621224001,3566.39449319998,754.968739597161,372.499248756215,-0.228183598453497,4182.44481857658,644.079681028522,379.152592270244,-0.361250468732952,-296.173767492196,1584.58958410258,313.316899055007,1.17491570628579,7002.25025136693,-167.032180421797,453.446640217163,-2.56187739136846,2287.17276200489,1106.03874170414,338.870257225697,0.875414098377381,3849.058700623,637.472960116598,385.72683538446,-0.686471840245922,2316.59243545813,1143.18682762265,330.098309958713,1.35324075868634,6884.57155752961,-501.285656321054,527.435008032214,-6.54022716421148,145.121334409225,2127.09993069659,185.744881720238,8.26634497595617,12534.9431049153,-3076.62521291968,914.266401826524,-25.7313259623219,-284.893754114863,2692.30137363728,48.9274138427136,17.5356234369078,8604.63191145845,-1574.6709458353,731.642984957929,-18.8758736893415,-4133.63389177062,4921.84461381193,-372.764660180314,43.7072262019938,47929.9036556259,-23192.4656617828,4687.81118942238,-259.927324774442,-137585.98073107,82551.5884386413,-15403.559089656,1012.52612623386,0,0,1106.75859807307,-88.1617196146145],300),
new ( [0,0.01,0.02,0.03,0.04,0.05,0.06,0.07,0.08,0.09,0.1,0.11,0.12,0.13,0.14,0.15,0.16,0.17,0.18,0.19,0.2],[0,0,366.495709485774,1.31,45042.9051422594,0,366.495709485774,1.31,-15214.5257112967,1807.72292560671,348.418480229707,1.37025743085356,15815.1977029253,-54.0604792466162,385.654148326774,1.12201964353975,-8046.26510040533,2093.47117305318,321.228198757767,1.76627913922978,6369.86269870408,363.535837159863,390.425612193504,0.843646960086688,2566.81430560192,933.993096124635,361.902749245264,1.31902800922428,3362.88007886306,790.701256938487,370.500259596449,1.14707780220044,3981.66537896788,660.756343914738,379.59640350796,0.934834444263884,710.458405253437,1445.84601760838,316.789229612758,2.60969241480715,3176.50100002074,780.014517022481,376.714064665238,0.81194736322764,6583.53759471162,-242.096461386051,478.925162506283,-2.59508923148093,489.348621115455,1768.9858998997,257.706102764544,5.51627629239185,11459.0679208703,-2180.11304800603,731.597976514053,-13.4393986575735,-6325.62030460304,4755.91535992157,-170.085716517118,25.6335613737386,13843.4132975554,-3715.07875297971,1015.85345928837,-29.7102668305409,951.967114398605,2086.07202943135,145.680841926434,13.7983640375942,12348.7182447915,-3384.36851316039,1020.95132874075,-32.8827285926145,-10346.8400936462,8190.36623945646,-946.753579200711,78.6205495242466,49038.6421298161,-23877.7941612229,4825.51529291924,-267.71558280295,-135807.728425905,81484.6370555423,-15193.346638266,1000.14567283879,0,0,1103.58077284256,-86.3161545685126],500),
new ( [0,0.01,0.02,0.03,0.04,0.05,0.06,0.07,0.08,0.09,0.1,0.11,0.12,0.13,0.14,0.15,0.16,0.17,0.18,0.19,0.2],[0,0,367.521432602879,4.81,44785.673971206,0,367.521432602879,4.81,-13928.3698560331,1761.42131481724,349.907219454707,4.86871404382725,10927.8054529218,270.050796279927,379.734629825454,4.66986464135557,217.148044347919,1234.00996305196,350.815854822297,4.95905239138725,-1796.39763030101,1475.63544400892,341.150835584007,5.08791931456446,6968.44247687155,160.909427933823,406.887136387773,3.99231430116781,3922.62772280262,709.156083666095,373.99233704386,4.65021028804517,-2658.9533680717,2091.28811274878,277.243095007981,6.90769260221643,6713.18574946301,-158.025275460984,457.188166064763,2.1091573740421,5806.21037020823,86.8580769397515,435.148664348532,2.77034242551671,61.9727697213084,1810.12935708653,262.821536333957,8.51458002600085,3945.89855092904,528.433849290786,403.808042191982,3.34507481120771,4154.43302653326,453.36143806568,412.816731538514,2.98472723737532,9436.36934295568,-1606.59372533505,680.610902780405,-8.61968684981127,-1899.91039831439,3154.64376599924,14.0376539939061,22.4870647602547,8163.27225029306,-1373.78842588008,693.302482776482,-11.4761766788179,9246.82139707357,-1893.89201633562,776.519057246449,-15.9143939840651,-5150.55783859268,5448.7713938579,-471.733722485369,54.8199302008943,41355.4099574238,-19664.4512159862,4048.64634728897,-216.402873985586,-130271.081991427,78162.6491948515,-14538.502730771,960.783234291535,0,0,1094.02710819911,-81.3854216398223],1000),
new ( [0,0.01,0.02,0.03,0.04,0.05,0.06,0.07,0.08,0.09,0.1,0.11,0.12,0.13,0.14,0.15,0.16,0.17,0.18,0.19,0.2],[0,0,366.898160329458,8.54,41018.3967054166,0,366.898160329458,8.54,-5091.98352708223,1383.31140697506,353.065046259709,8.5861103802325,-650.462597083226,1116.82015117514,358.394871375706,8.55057821279249,7693.83391542864,365.83346504888,380.924471959501,8.32528220695452,-124.873064645256,1304.07830265733,343.394678455149,8.82567945367898,2805.65834316016,864.498591487333,365.373664013659,8.4593630277042,-1097.76030802425,1567.11394870019,323.216742580847,9.30250145636013,11585.3828889829,-1096.34612267338,509.658947576882,4.95218333978449,-5243.77124794462,2942.65087018878,186.539188147849,13.5687102578894,9389.70210278779,-1008.38693450472,542.132590570301,2.90090818521989,-2315.03716318421,2503.03484528602,190.990412591732,14.6056474511857,9870.44654995971,-1518.17478005222,633.323471378479,-1.61323137100032,2833.25096333648,1015.2156311363,329.316622036682,10.5470426026634,-1203.45040330173,2589.52916412195,124.655862748281,19.4156755051771,11980.5506498951,-2947.75127822551,899.875124675344,-16.7612233847769,3281.24780362542,966.935002591636,312.672182552713,12.598923721353,4894.4581356002,192.594043238554,436.566736048611,5.99121420154552,-2859.08034610562,4146.89866891969,-235.665050316136,44.0843487622406,46541.8632488847,-22529.6108723693,4566.10666711908,-244.021954283875,-133308.372649729,79985.0235898308,-14911.6738807028,989.570813744853,0,0,1085.33083726494,-76.8961674529879],1500),
new ( [0,0.01,0.02,0.03,0.04,0.05,0.06,0.07,0.08,0.09,0.1,0.11,0.12,0.13,0.14,0.15,0.16,0.17,0.18,0.19,0.2],[0,0,362.63159887603,12.42,43684.0112396976,0,362.63159887603,12.42,-8420.0561984905,1563.12202314576,347.000378644574,12.4721040674382,-3.78644573287365,1058.14583797963,357.099902347887,12.4047739094161,8435.20198140843,298.636879537539,379.88517110116,12.1769212218832,-3737.02147991269,1759.3036948952,321.458498486865,12.9559435234077,6512.88393822101,221.817882175823,398.332789122819,11.6747053461413,-2314.51427301804,1810.74956019967,302.996888441415,13.5814233597687,12745.1731538832,-1351.78479944943,524.374293616829,8.41595057234361,-8666.17834252427,3786.93955968975,113.276344885776,19.3785625385035,11919.5402162387,-1771.20445117764,613.509305863903,4.37157370916983,988.017477590647,1508.25237041421,285.563623704653,15.3030964478101,4128.38987337519,471.929479811273,399.559141671267,11.1232607890312,2498.42302893503,1058.71754381048,329.144573990766,13.9398434962173,5877.91801092583,-259.285499173653,500.484969578548,6.51509302075399,3989.90492742241,533.679995898725,389.469800269137,11.6958009219177,8162.46227933082,-1343.97081245441,671.117421520801,-2.386580140756,3360.24595533311,961.093023057561,302.307207838807,17.2832979222512,-1603.44610070996,3492.57597162854,-128.044893417507,41.6699169936037,43053.538447462,-20622.1956843846,4212.61400466226,-218.769616891223,-130610.707689434,78366.4246136621,-14595.2238519639,972.393447361712,0,0,1078.06107076892,-72.4922141537826],2000),
new ( [0,0.01,0.02,0.03,0.04,0.05,0.06,0.07,0.08,0.09,0.1,0.11,0.12,0.13,0.14,0.15,0.16,0.17,0.18,0.19,0.2],[0,0,359.89251611496,16.34,41074.838850398,0,359.89251611496,16.34,-5374.19425199052,1393.4709930717,345.957806184244,16.3864490331024,421.938157570042,1045.70304849804,352.913165075708,16.3400799738259,3686.44162173096,751.897736723096,361.727324428974,16.2519383802934,4832.29535550239,614.395288670789,367.227422351048,16.1786037413325,-3015.62304375046,1791.5830485582,308.368034356624,17.1595935412384,7230.1968194758,-52.6645268219432,419.022888879485,14.9464964507804,4094.83576588096,605.761294433722,372.933081391446,16.0219252921678,-3609.53988296947,2454.81145015675,225.009068933541,19.9665656243745,10343.3237660015,-1312.46173506622,564.063655604102,9.79492802426667,2236.24481893978,1119.66194905286,320.851287191803,17.9020069713296,711.696958221515,1622.76274308973,265.510199847627,19.9311801739519,4916.96734814261,108.865402720551,447.177880692334,12.6644729401587,9620.43364923113,-1725.48645469958,685.643622157298,2.33095747666718,-3398.70194504067,3742.55049488878,-79.8815507848558,38.0554655473918,13974.3741309044,-4075.33373929054,1092.80108434075,-20.5786662089354,-2498.79457850335,3831.78724121302,-172.338272542052,46.8954328246309,6020.80418301374,-513.208127152175,566.310940083116,5.0386441094015,38415.5778464824,-18006.3859054111,3715.08294017054,-183.887675895821,-129683.115569226,77809.8693415374,-14490.005556751,969.101262242533,0,0,1071.9683115569,-68.3636623113786],2500),
new ( [0,0.01,0.02,0.03,0.04,0.05,0.06,0.07,0.08,0.09,0.1,0.11,0.12,0.13,0.14,0.15,0.16,0.17,0.18,0.19,0.2],[0,0,355.554575947248,20.26,44454.2405275136,0,355.554575947248,20.26,-12271.2026375691,1701.76329495254,338.536942997724,20.3167254431651,4630.57002274351,687.656935333414,358.819070190098,20.1815112618825,3748.92254659916,767.005208186283,356.438622004525,20.2053157437386,373.739790859953,1172.02713887529,340.23774477701,20.4213274401057,4756.11828997239,514.670364009841,373.105583520327,19.8735301277171,601.787049216281,1262.44998734372,328.238806120141,20.7708656757186,2836.73351317509,793.111229913703,361.092519140285,20.0042790385837,8051.27889808359,-458.379662463968,461.211790530395,17.3344318015134,-5041.84910549338,3076.76489849754,143.048780043707,26.8793221161143,12116.1175238987,-2070.62509031545,657.787778924906,9.7213554867388,-3422.62099011593,3057.15861930837,93.7315708670801,30.403416448877,11574.3664365778,-2341.75685430099,741.601427700488,4.48862217556224,-2874.84475624441,3293.43551089991,9.02642022389591,36.233539166183,9925.01258844748,-2082.50457386364,761.658032090438,1.11073061243712,3174.79440248618,955.093609804986,306.018304539975,23.8927169898766,7375.80980158085,-1061.39378176979,628.656287188409,6.68535791523937,-2678.03360882774,4066.06635755394,-243.011936492519,56.0798905907577,43336.3246337995,-20781.6870934702,4229.58368469123,-212.27584668051,-130667.264926702,78400.3589560241,-14615.0050647119,981.214774115069,0,0,1065.06672649263,-64.1233452985279],3000) ];

    public static double Re_Zha(double v0, double v, double T)
    {
        if (SplineZha == null)
        {
            InitializeSpline(ref SplineZha, Zha);
            string code = deveropper(SplineZha);
            Clipboard.SetDataObject(code, true);
        }
        return GetPressureFromSplineMethods(SplineZha, 1 - v / v0, T);
    }




    #region YokooのAuのテーブル

    private static readonly double[][] Table_Au_Yokoo = [
        [double.NaN,0,300,500,1000,1500,2000,2500,3000],
        [0.00,-1.73,0.00,1.42,4.99,8.58,12.18, double.NaN, double.NaN],
        [0.02,1.92,3.59,4.98,8.49,12.02,15.56, double.NaN, double.NaN],
        [0.04,6.08,7.70,9.07,12.53,16.00,19.48,22.99,  double.NaN],
        [0.06,10.83,12.41,13.76,17.16,20.59,24.02,27.47,   double.NaN],
        [0.08,16.26,17.80,19.13,22.49,25.87,29.26,32.67,36.10],
        [0.10,22.46,23.96,25.27,28.59,31.93,35.29,38.66,42.06],
        [0.12,29.55,31.01,32.30,35.59,38.91,42.23,45.58,48.94],
        [0.14,37.65,39.07,40.36,43.62,46.91,50.21,53.53,56.87],
        [0.16,46.93,48.31,49.59,52.83,56.10,59.39,62.69,66.01],
        [0.18,57.55,58.90,60.17,63.40,66.66,69.93,73.22,76.53],
        [0.20,69.73,71.05,72.31,75.54,78.79,82.06,85.34,88.65],
        [0.22,83.71,85.01,86.27,89.49,92.74,96.01,99.30,102.61],
        [0.24,99.80,101.07,102.33,105.56,108.82,112.10,115.39,118.71],
        [0.26,118.34,119.58,120.84,124.08,127.36,130.65,133.96,137.30],
        [0.28,139.75,140.96,142.23,145.49,148.78,152.10,155.43,158.79],
        [0.30,164.52,165.71,166.98,170.26,173.59,176.93,180.30,183.68],
        [0.32,193.25,194.42,195.70,199.01,202.37,205.75,209.16,212.58],
        [0.34,226.67,227.82,229.10,232.46,235.86,239.29,242.74,246.20],
        [0.36,265.66,266.78,268.08,271.48,274.93,278.41,281.91,285.44],
        [0.38,311.29,312.39,313.70,317.15,320.66,324.20,327.77,331.35],
        [0.40,364.87,365.95,367.27,370.78,374.37,377.98,381.61,385.26]];

    #endregion

    private static Spline[] SplineAuYokoo = [
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,177.282401336243,-1.73,13043.996659393,0,177.282401336243,-1.73,-1469.983296965,870.838797381484,159.865625388613,-1.61388816034913,2835.93652846705,354.128418329661,180.534040550686,-1.88946702917676,1376.23718309831,616.874300496038,164.769287620702,-1.57417197057716,2909.11473913943,248.983687046097,194.200536696696,-2.35900527927031,1987.30386034472,525.526950684642,166.546210332843,-1.43719440047619,4141.6698194777,-250.044794603226,259.614819767416,-5.15993877785539,2696.01686174928,357.129447642822,174.610425852928,-1.19306706184925,5074.26273352236,-784.428570808034,357.259708805126,-10.9343621526282,4506.93220416158,-478.07008495416,302.115181351341,-7.62569050540849,6898.00844983346,-1912.71583235752,589.044330831669,-26.7543004707728,6651.03399650094,-1749.71269315773,553.183640208163,-24.1245164917048,8997.8555641588,-3439.42422187179,958.714407099572,-56.5669778429759,9857.54374684905,-4109.98100436958,1133.0591705489,-71.6768573418545,12821.9694484897,-6600.09859374922,1830.29209557562,-136.751930344377,13854.5784591863,-7529.44670338399,2109.09652846506,-164.632373633196,23009.7167146478,-16318.379428651,4921.55500054022,-464.627943989421,4106.5546820662,2962.84584460501,-1634.06159235467,278.341936540382,94314.0645572003,-94461.2648205347,33438.6182470946,-3930.3796441938,-217612.812911352,261135.375493621,-101688.105072284,13185.6719762607,0,0,2766.04512516434,-741.548050065736],0),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,174.184339625258,0,13289.1509368539,0,174.184339625258,0,-1445.75468426985,884.094337267432,156.50245287991,0.117879244968993,2493.86780022537,411.339639127978,175.412640805488,-0.134256594038713,1470.28348336914,595.584816162079,164.357930183437,0.086837618402174,2874.99826629754,258.453268259244,191.328454015668,-0.632376350457255,2029.72345144128,512.035712716069,165.970209569983,0.21289846439801,4006.10792793158,-199.462698820733,251.350018954387,-3.20229391097716,3195.84483683266,140.847799440939,203.706549197718,-0.978931988999673,4460.51272472982,-466.192786749252,300.833042988226,-6.15901165782525,5212.1042642448,-872.052218088697,373.88774062915,-10.5422935162849,5941.07021829276,-1309.4317905169,461.363655114423,-16.374021148655,7273.61486257273,-2188.91125574265,654.849137464381,-30.5629565209912,8714.47033141691,-3226.32719330918,903.828962481094,-50.4813425222211,10368.50381175,-4516.47330796739,1239.26695229201,-79.5526349726126,12311.5144216151,-6148.60222025699,1696.26304773356,-122.205603880377,14135.4385017785,-7790.13389241335,2188.72254937871,-171.451554044779,22396.7315711547,-15720.9752390429,4726.59178028884,-442.15760534328,5027.63521342864,1995.50304586533,-1297.0108365647,240.517357901786,93742.7275752593,-93816.7967049032,33195.4170737108,-3898.57399133139,-217498.545514964,260998.254617957,-101634.302428978,13179.8571456753,0,0,2764.99941820579,-740.049767282315],300),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,172.550785637547,1.42,13623.0359061329,0,172.550785637547,1.42,-1865.17953066483,929.292926207877,153.964927113389,1.54390572349438,2587.68221652673,394.949516544898,175.338663499909,1.25892257167411,1514.45066455923,588.131195898958,163.747762738663,1.49074058689907,2604.51512523692,326.515725336417,184.677000383667,0.932627583032037,3067.48883449436,187.62361255909,198.566211661401,0.469653873774063,2625.52953678274,346.728959735568,179.473570000234,1.23335954022232,3930.3930183782,-201.313702535059,256.199542718101,-2.34718585327813,4152.89838969777,-308.116280768154,273.28795523545,-3.25856785420513,5708.01342282687,-1147.87839865751,424.445136455486,-12.3279987274103,5515.04791900167,-1032.09909636227,401.289275996251,-10.7842746967943,7231.79490116645,-2165.1521045917,650.560937806879,-29.0641965629006,9307.77247633876,-3659.85595871622,1009.2898627967,-57.7625105620493,9287.11519346636,-3643.7432780725,1005.10056582979,-57.3994381582351,13543.7667498483,-7219.33058543642,2006.26501189065,-150.841453123933,12787.8178071517,-6538.97653702239,1802.15879736534,-130.4308316713,24054.9620214188,-17355.434982738,5263.42549998412,-499.632613285678,3492.33410702413,3618.44548997004,-1867.69386072131,308.5609142631,94475.7015506346,-94643.5913491249,33506.6394013502,-3936.35907718586,-217645.140310036,261174.168372044,-101704.109292693,13190.3357573928,0,0,2765.55805612382,-738.953222449526],500),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,169.36094281946,4.99,14097.6429513495,0,169.36094281946,4.99,-2988.21475674801,1025.15146248586,148.857913569743,5.12668686166479,4105.21607564379,173.939762598893,182.906381565223,4.6727072883917,317.350454174599,855.755574463195,141.99743285336,5.49088626262909,3375.38210765872,121.82797762694,200.711640600256,3.92517405604492,2431.12111519159,405.106275367273,172.383810826231,4.8694350485122,3150.13343157026,146.261841470867,203.445142893845,3.62698176580994,3718.3451585322,-92.3870838536121,236.855992439129,2.0678087870261,4476.48593429603,-456.294656220342,295.081204017813,-1.03753583049877,4625.7111042814,-536.876248012285,309.585890540366,-1.90781702184946,7020.66964857921,-1973.85137459034,596.980915855945,-21.0674853762416,6041.61030139829,-1327.67220545151,454.821498645256,-10.6424614474716,10062.8891458316,-4222.99297344182,1149.69848296334,-66.2326201928412,8706.83311527031,-3165.26926960507,874.690319966166,-42.3985793997416,13859.7783931249,-7493.74330300091,2086.66304931665,-155.516034139146,13354.0533122406,-7038.59073022043,1950.1172774805,-141.861456955583,22724.0083577912,-16033.7475739662,4828.56746746908,-448.896143889098,4499.91325643938,2554.82942943461,-1491.54871367221,267.383689975482,94276.3386165779,-94403.7099595107,33413.5254663443,-3921.22521162708,-217855.267723229,261426.321267873,-101801.886400061,13206.0602914508,0,0,2768.64210708909,-736.676842835636],1000),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,166.443334158072,8.58,13891.6646048191,0,166.443334158072,8.58,-1958.32302409589,950.999257734899,147.423349003374,8.70679990103132,2691.62749156462,393.005195855624,169.743111478545,8.40920306802903,1191.8130578385,662.971793926225,153.54511559431,8.73316298571384,3791.12027708081,39.1380613081689,203.451814203773,7.402317689462,1143.70583383976,833.362394280134,124.02938090653,10.0497321327022,4134.05638755708,-243.163805058205,253.212524827095,4.88240637588094,3570.06861593721,-6.2889409776339,220.050043855893,6.42998882120548,4085.66914868746,-253.777196698012,259.648164771152,4.31808903905797,5087.25478930879,-794.633442633027,357.002289039549,-1.52315841704585,6815.31169407621,-1831.46758549367,564.369117611489,-15.3476136551817,6401.49843438464,-1558.35083409686,504.283432304646,-10.9413300659868,8828.69456838313,-3305.93205057643,923.702924259698,-44.4948894223634,10783.7232920694,-4830.85445504809,1320.1827494227,-78.8564742697974,11786.4122633831,-5673.11319095634,1556.01519547676,-100.86750256816,14570.6276543896,-8178.90704287094,2307.75335104752,-176.04131812539,22431.0771189502,-15724.9385288679,4722.48342655826,-433.61252618135,4455.06386965606,2610.59498544037,-1511.59796829149,272.916698570218,94748.6674025711,-94906.4968301058,33594.5550853014,-3939.82166786166,-218449.733480424,262139.680176508,-102082.992177212,13246.0009853904,0,0,2772.87989339197,-734.781957356788],1500),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,163.4731814044,12.18,13817.0464890012,0,163.4731814044,12.18,-1585.23244500614,924.136736040411,144.990446683591,12.3032182314721,2523.88329102312,431.042847716961,164.714202216529,12.0402348243662,1489.69928091548,617.195969536119,153.545014907374,12.2636185705493,2767.31958531213,310.567096480829,178.075324751788,11.6094769746984,2441.02237783565,408.456258723754,168.286408527463,11.9357741821749,3718.59090334274,-51.4684104585254,223.477368829369,9.72813577009847,2684.61400879697,382.801885250054,162.679527430207,12.5653683687279,5542.95306146243,-989.200860028593,382.19996667485,0.857611609019132,3893.57374534674,-98.5360293262053,221.880297148477,10.4767917805851,7632.7519571554,-2342.04295641169,670.581682565309,-19.4366339138562,5575.41842602799,-984.202825864682,371.856853845492,2.46985352558917,10065.5743387541,-4217.11508303093,1147.75579556494,-59.6020618119431,9162.28421893334,-3512.54878956996,964.568559265757,-43.7258346659371,13285.2887855538,-6975.87262553236,1934.29923333457,-134.234030912429,13946.5606388419,-7571.01729349961,2112.84263372319,-152.088370951282,22178.4686589674,-15473.6489928416,4641.68477750343,-421.831532955868,4839.56472513638,2212.03301968332,-1371.4471067437,259.656747260597,94713.2724406067,-94851.5713130087,33571.4504530281,-3933.49095991231,-218692.654488035,262431.185385641,-102195.997092461,13263.7190625161,0,0,2776.47706179501,-732.610824718005],2000),
new( [0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,216.496481335947,14.3301407465621,18758.7966601337,-2251.05559921604,306.538705304589,13.1295777603136,-3793.98330066831,1808.44479372825,62.9686817279242,18.0009782318467,5167.1365425368,-342.223968640938,235.022182717474,13.4128848721254,625.437130523008,1020.28585496292,98.771200357076,17.95458428414,4831.11493536681,-493.758154780526,280.456481526289,10.68717303737,2550.1031280127,464.266804308504,146.332987253886,16.9462694367482,4968.47255258099,-696.550519484515,332.063759060866,7.04062827371511,5076.00666166027,-754.618938387762,342.516074463334,6.41348934955585,5977.5008007794,-1295.51542185998,450.695371157576,-0.798463763370609,7263.99013521597,-2144.59838258755,637.493622518098,-14.4970021965038,8716.5386583509,-3190.43331924549,888.494007315355,-34.5770329802788,10369.8552313741,-4480.02024620033,1223.78660832419,-63.6357250676979,12304.0404161988,-6104.73580145369,1678.70696379491,-106.094958244943,14163.9831038492,-7778.68422033091,2180.8914894582,-156.313410811244,22290.0271683491,-15579.6865222715,4677.21222607774,-422.587622716885,5425.90822268184,1621.71480232943,-1171.26422428945,240.239708322159,93506.3399412129,-93505.1514536925,33074.4076278862,-3869.24091393652,-218201.267988143,261841.521585774,-101957.328127114,13234.7789483633,0,0,2779.28050719506,-730.102202878023],2500),
new( [0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,288.550917446255,13.0159266042996,23622.7063843652,-5669.44953224768,742.106880026077,0.921100935504694,-3113.53192182809,2351.42195961057,-59.9802691597496,27.6573392416974,5081.4213029518,-598.761201309868,294.041710150708,13.4964600692795,2787.8467100332,364.540127715785,159.179524087046,19.7900287522463,5017.19185691458,-705.545542788204,330.393231367633,10.6586310306121,4643.3858623049,-503.690305698512,294.059288691823,12.8386675911708,6409.26469386462,-1563.21760463434,505.964748478436,-1.28836306128932,7219.55536223541,-2098.00944575839,623.618953525711,-9.91633809810651,8462.51385720258,-2992.9395621343,838.402181456348,-27.0989963324815,10180.3892089446,-4332.88233649297,1186.78730279013,-57.2923735148503,13315.9293070649,-6966.73601890852,1924.26633386774,-126.123749748632,12805.8935627911,-6507.70384907431,1786.55668291436,-112.352784653405,24210.4964416644,-17456.1226127646,5290.05068729603,-486.058811787654,2852.12067060452,4329.42067366559,-2117.03403009544,353.410789516231,95631.0208759774,-95871.7915481031,33955.4023697479,-3975.28157846397,-219126.20417509,262951.445010111,-102397.427522373,13296.0768745379,0,0,2783.15048166983,-728.000192667933],3000) ];

    public static double AuYokoo(double v0, double v, double T)
    {
        if (SplineAuYokoo == null)
        {
            InitializeSpline(ref SplineAuYokoo, Table_Au_Yokoo);
            string code = deveropper(SplineAuYokoo);
            Clipboard.SetDataObject(code, true);
        }
        return GetPressureFromSplineMethods(SplineAuYokoo, 1 - v / v0, T);
        /*
        double a = 0.45;
        double b = 4.2;
        double theta = 170;
        double gamma0 = 2.96;
        double b0 = 167.5;
        double b_prime=5.79;

        double p_ph = MieGruneisen(4, 1, theta, gamma0, 0, 300, v0/1000, T, v / 1000, a, b);

        double Pc = ThirdBirchMurnaghan(b0, b_prime, v0 / v);

        double T0 = 300;

        double q_ph = a * b * Math.Pow(v / v0, b) / (1 + a * (Math.Pow(v / v0, b) - 1));
        double gamma_ph = gamma0 * (1 + a * (Math.Pow(v / v0, b) - 1));

        double theta_d = theta * Math.Pow(v / v0, -(1 - a) * gamma0) * Math.Exp(-(gamma_ph - gamma0) / b);

        double x = theta_d / T;
        double x0 = theta_d / T0;

        double d3 = 1 / x / x / x * integ(x);
        double d3_0 = 1 / x0 / x0 / x0 * integ(x0);
        double e_ph = 9 * 8.31451 * T * d3;
        double e_ph0 = 9 * 8.31451 * T0 * d3_0;

        double p_ph = gamma_ph / v * e_ph;
        double p_ph_0 = gamma_ph / v * e_ph0;

        //double deltaPth = (p_ph - p_ph_0) / 1000000;

        return Pc + p_ph;
        */
    }

    #region Yokoo, Ptのてーぶる　

    private static readonly double[][] Table_Pt_Yokoo = [
[double.NaN,0,300,500,1000,1500,2000,2500,3000],
[0.00,-1.76,0.00,1.52,5.37,9.25,13.15,17.09,21.06],
[0.02,4.18,5.89,7.38,11.16,14.97,18.81,22.67,26.57],
[0.04,10.90,12.55,14.02,17.74,21.49,25.27,29.07,32.92],
[0.06,18.48,20.09,21.53,25.20,28.91,32.63,36.39,40.18],
[0.08,27.06,28.62,30.04,33.67,37.33,41.02,44.73,48.48],
[0.10,36.76,38.28,39.68,43.28,46.90,50.56,54.24,57.96],
[0.12,47.73,49.21,50.61,54.18,57.78,61.40,65.06,68.76],
[0.14,60.16,61.61,63.00,66.54,70.13,73.74,77.38,81.06],
[0.16,74.26,75.68,77.06,80.59,84.17,87.77,91.41,95.08],
[0.18,90.28,91.66,93.04,96.57,100.14,103.74,107.38,111.05],
[0.20,108.48,109.85,111.22,114.75,118.33,121.94,125.58,129.26],
[0.22,129.22,130.56,131.93,135.48,139.07,142.70,146.35,150.05],
[0.24,152.88,154.20,155.57,159.14,162.75,166.40,170.08,173.80],
[0.26,179.94,181.23,182.61,186.20,189.84,193.52,197.24,200.98],
[0.28,210.93,212.20,213.59,217.21,220.90,224.61,228.37,232.15],
[0.30,246.53,247.77,249.17,252.83,256.56,260.33,264.13,267.97],
[0.32,287.51,288.74,290.14,293.85,297.64,301.46,305.32,309.21],
[0.34,334.83,336.03,337.45,341.21,345.06,348.95,352.87,356.83],
[0.36,389.62,390.80,392.23,396.06,399.98,403.94,407.94,411.97],
[0.38,453.28,454.44,455.89,459.79,463.78,467.83,471.90,476.02],
[0.40,527.51,528.64,530.11,534.08,538.17,542.30,546.47,550.69]];

    #endregion

    private static Spline[] SplinePtYokoo = [
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,288.897005240384,-1.76,20257.4868990396,0,288.897005240384,-1.76,-3787.43449519833,1442.69528365428,260.043099567298,-1.56764062884609,4892.25108175411,401.133014420044,301.70559033667,-2.12314050577104,1718.43016818379,972.420778862602,267.42832447011,-1.43759518843994,3234.02824551231,608.677240303716,296.527807554808,-2.21358140403224,4095.45684976911,350.248659026469,322.370665682521,-3.07501000829013,4134.14435540215,336.321156998238,324.041965925954,-3.14186201802304,5617.96572862148,-286.883819753847,411.290662671176,-7.21346786613428,4643.99273009746,180.623219538779,336.489536384491,-3.22407446416963,8306.06335098635,-1796.89491574238,692.442800734839,-24.5812703252059,7131.75386596341,-1092.30922472845,551.52566253216,-15.186794445022,10666.9211851531,-3425.51965539577,1064.83195727832,-52.8292560597601,10200.5613934199,-3089.74060534638,984.244985266681,-46.3822982987996,14780.8332411664,-6662.35264658523,1913.12411598945,-126.88515629474,15676.1056419634,-7414.38146326339,2123.69218465987,-146.538176037188,18764.7441909624,-10194.15615737,2957.62459289037,-229.931416860192,29264.9175940349,-20274.3226243542,6183.27786230965,-574.001098933724,5425.5854326766,4041.79618027341,-2084.20253123948,362.980012338026,124032.740675412,-124053.931481887,44030.2594271284,-5170.7554226669,-289056.548134968,346867.857761964,-134920.02048553,17496.2800329365,0,0,3827.12261925372,-1003.33904770149],0),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,286.615131761565,0,19712.170596087,0,286.615131761565,0,-2310.8529804353,1321.38141459135,260.187503469739,0.176184188612183,3281.24132565389,650.330097860726,287.029556138965,-0.181709846977513,2935.88767782204,712.493754470339,283.299736742385,-0.107113459046025,2475.20796305646,823.056886013991,274.454686218885,0.128754554913883,4663.28046995378,166.635133944956,340.096861425759,-2.05931795198233,3871.67015712474,451.614846563262,305.899295911573,-0.691415331414077,4850.03890155509,40.6999739020781,363.427378084072,-3.37605916613252,6728.17423664601,-860.804986940306,507.668171819123,-11.0689014986601,5737.26415186024,-325.713541157536,411.351711577989,-5.28991388420275,9072.76915591887,-2327.01654359155,811.61231206464,-31.9739539166437,9221.65922446234,-2425.28398882841,833.231150017323,-33.5593353664915,11540.5939462491,-4094.91698851937,1233.94306994244,-65.6162889605212,13365.9649905329,-5518.70640305709,1604.12831772313,-97.6990104347401,17495.5460916752,-8987.55452802269,2575.40579271263,-188.351574767174,16651.8506427532,-8228.22862400254,2347.60802150438,-165.571797646422,30897.0513371483,-21903.6212906542,6723.73367481929,-632.358534002014,4759.94400847144,4756.22818465158,-2340.61514676036,394.934332446574,123813.172629151,-123821.258725703,43947.2801409606,-5159.6131020803,-288762.634525713,346515.161430854,-134780.559518532,17479.2465881216,0,0,3825.50505381002,-1001.56202152401],300),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,284.934091441316,1.52,20164.7713967104,0,284.934091441316,1.52,-3323.85698355313,1409.31770281582,256.747737384999,1.70790902704211,4380.65653750172,484.776080289336,293.729402286063,1.21482016169462,2051.23083354736,904.072707000988,268.571604683356,1.71797611374861,3664.42012830926,516.907276257973,299.544839142787,0.892023194830528,3291.08865321527,628.906718786156,288.344894889983,1.26535466992491,4421.22525882179,222.0575407678,337.166796252246,-0.687521384562688,5274.01031150075,-136.112181356645,387.310557349567,-3.02756356911149,5732.73349517334,-356.299309519509,422.540497855512,-4.90649372942711,6795.05570780371,-929.953304340217,525.7982169236,-11.1019568735107,8337.0436736234,-1855.14608383276,710.836772821628,-23.4378606000175,9856.76959769573,-2858.16519371961,931.500976996964,-39.6199022395976,10985.8779356018,-3671.12319701279,1126.61089778768,-55.228695902772,13699.7186598854,-5787.91896195004,1676.97779667125,-102.927160472677,16715.2474249257,-8320.96312459062,2386.23016220892,-169.124047922803,18189.2916404192,-9647.60291854833,2784.22210039542,-208.923241741435,29277.5860132386,-20292.3655164856,6190.54613172304,-572.26447175158,5950.36430640705,3501.40062451921,-1899.33435619995,344.588650215097,123170.956761271,-123096.839226734,43676.0319902487,-5124.45531135867,-288634.19135214,346361.029622566,-134717.958172485,17472.1167759206,0,0,3826.45367654059,-1000.47147061623],500),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,281.328889686484,5.37,20427.7757837899,0,281.328889686484,5.37,-3388.87891894971,1428.99928216437,252.748904043196,5.56053323762193,4377.7398920103,497.005024849228,290.028674335803,5.06346963372048,2127.91935090974,901.972722247302,265.730612491917,5.5494308705982,3360.58270435095,606.133517421264,289.397748878014,4.91830723363623,3179.74983169014,660.38337922015,283.972762698111,5.09914010629856,5170.41796889024,-56.2571501722589,369.969626225294,1.65926556521577,4888.57829275416,62.1155138039868,353.397453268497,2.43263363652676,5275.26886008533,-123.49595851453,383.095288839435,0.848749072746361,7760.34626690426,-1465.43775819611,624.644812782057,-13.6442223638165,7433.34607230573,-1269.23764143907,585.404789430293,-11.0282208070636,10006.2694438612,-2967.36706666583,958.993262980762,-38.4247088674058,11291.5761522417,-3892.78789669609,1181.09426218809,-56.1927888039637,13577.4259471709,-5675.75073673685,1644.66460059956,-96.3688847995822,16898.7200591349,-8465.63779079542,2425.83297573546,-169.277933145509,17577.693816283,-9076.71417224268,2609.15589016638,-187.610224588798,30290.5046755623,-21281.0125971725,6514.53138613352,-604.183610826905,5010.2874812847,4504.80894101691,-2252.64793683169,389.430045778427,123418.345399462,-123375.893610612,43784.4049817473,-5135.01630445174,-288683.669079773,346420.402895734,-134738.187690658,17477.8454340529,0,0,3829.97346763164,-997.909387052658],1000),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,277.777704669988,9.25,20555.7383250305,0,277.777704669988,9.25,-2778.69162515287,1400.065797011,249.776388729767,9.43667543960147,3059.02817558131,699.53942092286,277.797443773291,9.06306137235448,3042.57892282804,702.500286418528,277.619791843556,9.06661441094911,3520.65613310746,587.76175595136,286.79887428091,8.82183887928602,2874.79654474679,781.519632460049,267.423086630098,9.46769846764883,4980.15768790188,23.5896209234451,358.37468801441,5.82963441227262,4704.5727036531,139.335314308571,342.170290940557,6.58583960905455,6201.55149748019,-579.214506728025,457.13826230663,0.454214469543445,6739.22130642602,-869.556203558301,509.399767735876,-2.68147585622488,8091.56327683083,-1680.96138580362,671.680804184417,-13.5002116194767,9644.52558624111,-2705.91651001124,897.170931511495,-30.0361542900733,12080.334378205,-4459.6988402286,1318.07869076204,-63.7087750301922,12034.1369009237,-4423.66480794692,1308.70984236934,-62.8968081694125,18533.1180181536,-9882.8089464254,2837.27020114298,-205.562441654814,16333.3910264585,-7903.0546539097,2243.34391338688,-146.169812879267,31133.3178758493,-22110.9844293504,6789.88144151639,-631.133815881847,4133.3374699438,5428.99558471423,-2573.71176324645,430.073413994105,124833.332244549,-124926.998771872,44354.4462051205,-5201.30554221058,-289716.666448798,347659.999738559,-135228.613228841,17545.8819860909,0,0,3835.38666657924,-995.984666631699],1500),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,274.750104358875,13.15,20624.739102811,0,274.750104358875,13.15,-3123.69551405422,1424.90607701191,246.251982818637,13.3399874769349,4370.04295340664,525.657460916574,282.221927462454,12.8603882150174,1893.52370042675,971.430926452878,255.475519530255,13.3953163736612,3055.8622448837,692.469675783144,277.792419583855,12.8001990388993,4633.02732003659,219.320153236985,325.107371838437,11.2230339637457,3412.02847496214,658.87973746502,272.360221731147,13.3329199680341,5468.85878012319,-204.988990704244,393.301843674674,7.68897761067306,5962.53640453545,-441.954250421884,431.216285229571,5.66687406107661,6930.9956017255,-964.922216904463,525.350519196307,0.0188200230662883,7563.48118856508,-1344.41356901059,601.248789617349,-5.04106467166972,10315.0796439972,-3160.46854958958,1000.78088534588,-34.3400850250535,11176.2002354375,-3780.47537543171,1149.58252354685,-46.244216081112,13730.1194142423,-5772.53233489594,1667.51733300786,-91.1318995677599,16403.322107649,-8018.02259735866,2296.25460649788,-149.814045093426,18156.5921551576,-9595.96564013069,2769.63751932727,-197.152336376455,29720.3092715521,-20697.1340719021,6322.01141748315,-576.072218847949,5462.17075842153,4046.16721154097,-2090.71101886686,377.369657274103,123431.007694956,-123360.176679928,43775.5727820527,-5126.58439883683,-289186.201538872,347023.441846646,-134970.202258043,17514.5471062416,0,0,3839.17448061528,-993.369792246112],2000),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,270.56793638781,17.09,21080.1590304743,0,270.56793638781,17.09,-2900.79515237253,1438.85725097081,241.790791368395,17.2818476334628,3023.02157901611,727.999243204135,270.22511167906,16.9027233626538,3308.70883630806,676.575536891589,273.310534057822,16.8410149150787,2492.14307575189,872.551319424985,257.632471455168,17.2590965844844,4222.71886068216,353.378583945963,309.54974500306,15.5285207995539,4366.98148151014,301.444040447376,315.781890222927,15.279234990762,4559.35521328162,220.647073103757,327.093465650847,14.7513614707836,6145.59766535301,-540.74930389084,448.916885970113,8.25411238709445,7108.2541252978,-1060.58379225866,542.48709387635,2.63989991269865,7921.38583346438,-1548.46281716164,640.062898856761,-3.86515375264723,9956.20254083496,-2891.44184402394,935.518284766944,-25.5318820527146,11003.8040031855,-3645.71489691675,1116.54381746125,-40.0139246682445,13528.5814464149,-5615.04130263709,1628.56868294813,-84.3894130104599,17381.8702111942,-8851.80386505132,2534.86220042431,-168.97680797474,16943.937708809,-8457.66461291688,2416.62042478344,-157.152630410656,31092.3789534126,-22040.1682077602,6763.02157511807,-620.768753114942,3686.54647736065,5913.78091785032,-2741.32112756791,456.390086525469,125411.435137339,-125549.098834936,44585.3155834284,-5222.80631879484,-290332.287027352,348398.744432818,-135514.86485832,17589.8832038261,0,0,3844.63291481067,-991.383165924271],2500),
new( [0,0.02,0.04,0.06,0.08,0.1,0.12,0.14,0.16,0.18,0.2,0.22,0.24,0.26,0.28,0.3,0.32,0.34,0.36,0.38,0.4],[0,0,266.746698774576,21.06,21883.2530635609,0,266.746698774576,21.06,-4416.26531780456,1577.97110288193,235.187276716937,21.2703961470509,4531.80820765869,504.202279826441,278.138029639152,20.6977194414213,2539.03248717298,862.901909513293,256.616051857926,21.1281589970459,2812.0618436461,797.374863959962,261.858215502202,20.9883679665318,3712.72013824032,527.177375582371,288.877964339977,20.0877096719393,4837.0576033866,122.415888129134,337.449342834397,18.1448545321621,4439.04944821301,289.579313301916,314.046463310167,19.2369889099597,6156.74460375614,-534.914361358734,445.965451255762,12.2013095528694,7183.97213676158,-1089.61722918247,545.811967464199,6.21051858034925,7607.3668491981,-1343.65405664208,596.619332956144,2.82336088087622,9886.56046642866,-2847.9218440167,927.558246178875,-21.4454927554207,11596.3912850795,-4079.00003344576,1223.01701164097,-45.0821939924604,13727.8743932437,-5741.5568578089,1655.28178597631,-82.5451411014508,15992.1111419922,-7643.51572675999,2187.83026928196,-132.249666210033,18553.6810387861,-9948.92863388645,2879.45414141909,-201.412053423384,29793.1647027368,-20738.832951308,6332.22352298157,-569.707454125193,4773.66015006509,4781.06169244088,-2344.5406558793,413.659152813896,124862.19469716,-124914.555618413,44345.881576024,-5189.19151501451,-290472.438939318,348566.926727176,-135577.081715295,17601.0505018858,0,0,3849.68897557546,-989.185590230184],3000) ];

    public static double PtYokoo(double v0, double v, double T)
    {
        if (SplinePtYokoo == null)
        {
            InitializeSpline(ref SplinePtYokoo, Table_Pt_Yokoo);
            string code = deveropper(SplinePtYokoo);
            Clipboard.SetDataObject(code, true);
        }
        return GetPressureFromSplineMethods(SplinePtYokoo, 1 - v / v0, T);
    }

    /*  Ar Ross et al. 1986
    cm^3/mol,  GPa
    19.0    1.6
    18.0    2.1
    17.0    2.8
    16.0    3.8
    15.0    5.3
    14.0    7.5
    13.0    10.7
    12.0    15.5
    11.0    22.9
    10.0    34.7
    9.0     54.0
    8.0     86.8
    7.0     145.3
    6.0     256.0
    5.0     484.1
    4.5     689.2
    */
    #region double[][] RossのArの定義

    private static readonly double[][] Ross = [
                [double.NaN,273],
                [19 ,1.6 ],
                [18, 2.1],
                [17, 2.8],
                [16, 3.8],
                [15, 5.3],
                [14, 7.5],
                [13, 10.7],
                [12, 15.5],
                [11, 22.9],
                [10, 34.7],
                [9, 54.0],
                [8, 86.8],
                [7, 145.3],
                [6, 256.0],
                [5, 484.1],
                [4.5, 689.2]];

    #endregion

    private static readonly Spline SplineRossAr =
new([4.5, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19], [0, 0, -438.37604627262, 2661.89220822682, 112.704185090475, -1521.50649872148, 6408.40319797425, -7608.27665814318, -43.3083701809642, 818.681830350182, -5292.53844738429, 11893.2927507873, -4.17070436661926, 114.203845691975, -1065.67053943502, 3439.55693488882, -5.20881235255954, 136.004113396721, -1218.27241336826, 3795.62797406635, -1.49404622314329, 46.8497262907302, -505.037316520319, 1893.6677158052, -1.01500275486734, 33.9155526472796, -388.629753729276, 1544.4450274321, -0.44594275738706, 16.843752722872, -217.911754485182, 975.385029951803, -0.301226215584767, 12.0681068433965, -165.379649810962, 782.76731281293, -0.149152380274052, 6.59344877221054, -99.6837529567286, 519.983725396021, -0.102164263318603, 4.76091221094784, -75.8607776603151, 416.750832444898, -0.0421905664515601, 2.24201694253192, -40.5962439024943, 252.183008241729, -0.0290734708752302, 1.65174764159717, -31.7422043884731, 207.912810671615, -0.0415155500474946, 2.24896744186602, -41.2977211927694, 258.875566961194, -0.00486432893482969, 0.379755165120105, -9.5211124880903, 78.8081176346795, -0.039027134213055, 2.22454665014414, -42.7273592185256, 278.045598017296, -5.74063345111801E-23, 6.26804380968182E-21, -0.460972865786842, 10.35848444995]);

    public static double Ar_Ross(double a)
    {
        /* if (SplineRossAr == null)
        {
            InitializeSpline(ref SplineRossAr, Ross);
            string code = deveropper(SplineRossAr);
            Clipboard.SetDataObject(code, true);
        }*/

        return SplineRossAr.GetValue(UniversalConstants.A / 1.0E21 * a * a * a / 4);
    }

    public static double Ar_Jephcoat(double a, double T)
    {
        //double a0=Math.Pow(22.557,1.0/3.0);
        double gamma0 = 0.5;
        double gamma1 = 2.20;
        double Z = 4;
        double K0T = 3.03;
        double Kprime0T = 7.24;
        double theta0 = 93.3;

        double V = a * a * a * 6.0221367 / Z;
        double V0 = 22.557 / 100;
        double V0perV = V0 / V;
        double T0 = 4;
        double Pst = 3.0 / 2.0 * K0T * (Math.Pow(V0perV, 7.0 / 3.0) - Math.Pow(V0perV, 5.0 / 3.0)) * (1 - 3.0 / 4.0 * (4 - Kprime0T) * (Math.Pow(V0perV, 2.0 / 3.0) - 1));
        double gamma = gamma0 + gamma1 * (V / V0);
        double theta = theta0;// *Math.Exp((gamma0 - gamma) / q);
        double x = theta / T;
        double x0 = theta / T0;
        double Eth = 9 * 8.31451 * T / x / x / x * integ(x);
        double Eth0 = 9 * 8.31451 * T0 / x0 / x0 / x0 * integ(x0);
        double deltaPth = gamma / V * (Eth - Eth0) / 100000;
        return deltaPth + Pst;
    }

    //与えられたパラメータから温度ごとのスプライン曲線を設定する関数
    private static void InitializeSpline(ref Spline[] Splines, double[][] param)
    {
        Splines = new Spline[param[0].Length - 1];
        for (int i = 0; i < Splines.Length; i++)
        {
            List<PointD> pt = [];
            for (int j = 0; j < param.Length - 1; j++)
                if (!double.IsNaN(param[j + 1][i + 1]))
                    pt.Add(new PointD(param[j + 1][0], param[j + 1][i + 1]));
            var p = new Profile { Pt = pt };
            Splines[i] = Spline.GetSpline(p);
            Splines[i].T = param[0][i + 1];
        }
    }

    //温度ごとのスプライン曲線から各温度の圧力を計算し、それをスプラインで返す
    private static double GetPressureFromSplineMethods(Spline[] Splines, double x, double T)
    {
        var pt = new List<PointD>();
        for (int i = 0; i < Splines.Length; i++)
            pt.Add(new PointD(Splines[i].T, Splines[i].GetValue(x)));
        var p = new Profile { Pt = pt };
        return Spline.GetSpline(p).GetValue(T);
    }

    //以下は開発用の関数でSpline[] 型の初期化コードを吐き出してくれる
    private static string deveropper(Spline[] s)
    {
        string code = "";

        code += "= new Spline[]{\r\n";

        for (int i = 0; i < s.Length; i++)
        {
            code += "new Spline( ";

            code += "new double[]{";
            for (int j = 0; j < s[i].p.Length - 1; j++)
                code += s[i].p[j].ToString() + ",";
            code += s[i].p[^1].ToString() + "},";

            code += "new double[]{";
            for (int j = 0; j < s[i].c.Length - 1; j++)
                code += s[i].c[j].ToString() + ",";
            code += s[i].c[^1].ToString() + "},";

            if (i != s.Length - 1)
                code += s[i].T.ToString() + "),\r\n";
            else
                code += s[i].T.ToString() + ") };\r\n";
        }
        return code;
    }
}
