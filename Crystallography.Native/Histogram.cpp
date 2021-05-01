// Hitogram.cpp : DLL �A�v���P�[�V�����p�ɃG�N�X�|�[�g�����֐����`���܂��B
//

#include "stdafx.h"

/*----------------*/
/* Hitogram.cpp */
/*----------------*/
// Hitogram.cpp : DLL �A�v���P�[�V�����p�ɃG�N�X�|�[�g�����֐����`���܂��B
//

#include "stdafx.h"
#include "math.h"
#include <stdio.h>
#include <string.h>
#include <vector>
#define HISTOGRAM_EXPORTS
#include "Histogram.h"

using namespace std;

const double pi = 3.141592653589793238462643383279;

extern "C" {

	void _Histogram(
		int width, int height,
		double centerX, double centerY,
		double pixSizeX, double pixSizeY,
		double fd,
		double ksi, double tau, double phi,
		double SpericalRadiusInverse,
		double Intensity[], BYTE IsValid[],
		int yMin, int yMax,
		double startAngle, double stepAngle,
		double r2[], int r2len,
		double profile[], double pixels[]
	)
	{
		double TanKsi = tan(ksi), SinTau = sin(tau), CosTau = cos(tau);
		double SinPhi = sin(phi), CosPhi = cos(phi);
		auto Numer1 = CosPhi * SinPhi - CosPhi * CosTau * SinPhi;
		auto Numer2 = CosPhi * CosPhi + CosTau * SinPhi * SinPhi;
		auto Numer3 = CosPhi * CosPhi * CosTau + SinPhi * SinPhi;
		auto Denom1 = CosPhi * SinTau;
		auto Denom2 = -SinPhi * SinTau;

		//x������0.5�s�N�Z���i�񂾎��̕��i�x�N�g��
		double tX = pixSizeX / 2, tY = 0.0;
		double slideX[3] = { Numer2 * tX + Numer1 * tY, Numer1 * tX + Numer3 * tY, Denom2 * tX + Denom1 * tY };

		//Y������0.5�s�N�Z���i�񂾎��̕��i�x�N�g��
		tY = pixSizeY / 2.0;
		tX = pixSizeY * TanKsi / 2;

		double slideY[3] = { Numer2 * tX + Numer1 * tY, Numer1 * tX + Numer3 * tY, Denom2 * tX + Denom1 * tY };

		double slide[2][3] = {
			{slideX[0] + slideY[0], slideX[1] + slideY[1], slideX[2] + slideY[2]},
			{slideX[0] - slideY[0], slideX[1] - slideY[1], slideX[2] - slideY[2] }};

		//IP�̖@���x�N�g��
		double detector_normal[3] = { Denom2, Denom1, -CosTau };


		double ptx[5], pty[5];
		double vx[5], vy[5];
		//��������ϕ��J�n

		for (int j = yMin; j < yMax; j++)
		{
			auto tempY = (j - centerY) * pixSizeY;//IP���ʏ�̍��W�n�ɂ�����Y�ʒu
			auto tempY2TanKsi = tempY * TanKsi;
			auto numer1TempY = Numer1 * tempY;
			auto numer3TempY = Numer3 * tempY;
			auto denom1tempYFD = Denom1 * tempY + fd;

			auto jWidth = (j - yMin) * width;
			for (int i = 0; i < width; i++)
			{
				if (IsValid[i + jWidth] == (BYTE)1)//�}�X�N����Ă��Ȃ��Ƃ�
				{
					auto tempX = (i - centerX) * pixSizeX + tempY2TanKsi;//IP���ʏ�̍��W�n�ɂ�����X�ʒu
					//�ȉ���x,y,z���s�N�Z�����S�̋�Ԉʒu
					auto x = Numer2 * tempX + numer1TempY;
					auto y = Numer1 * tempX + numer3TempY;
					auto z = Denom2 * tempX + denom1tempYFD;

					if (SpericalRadiusInverse != 0) //���ʕ␳���K�v�ȏꍇ
					{
						//���o�풆�S(0,0,FD)����s�N�Z���܂ł̋���
						auto distance = sqrt(x * x + y * y + (z - fd) * (z - fd));

						//���o��̃_�C���N�g�X�|�b�g�����ɏk�߂銄��
						auto coeff_detector_palallel = sin(distance * SpericalRadiusInverse) / distance / SpericalRadiusInverse;

						//���o��̖@�������ɐi�ދ���
						auto slide_detector_normal = (1 - cos(distance * SpericalRadiusInverse)) / SpericalRadiusInverse;

						//(0,0,FD)����(X,Y,Z)�̃x�N�g����coeff_detector_palalle����������Adetector_normal�̕�����slide_detector_normal�����i�߂�B
						x = x * coeff_detector_palallel + detector_normal[0] * slide_detector_normal;
						y = y * coeff_detector_palallel + detector_normal[1] * slide_detector_normal;
						z = (z - fd) * coeff_detector_palallel + fd + detector_normal[2] * slide_detector_normal;
					}

					double l2 = x * x + y * y + z * z, q = sqrt(x * x + y * y), l = sqrt(l2);

					//�l���̒��_���W���v�Z
					
					for (int k = 0; k < 2; k++)
					{
						double a = x + slide[k][0], b = y + slide[k][1], c = z + slide[k][2];

						auto bNew = (b * x - a * y) / q;
						auto p = a * x + b * y + c * z;
						auto vxTemp = (a * a + b * b + c * c - bNew * bNew) * l2 / p / p - 1;
						vx[k] = vxTemp > 0 ? fd * sqrt(vxTemp) : 0;
						vy[k] = bNew * l * fd / p;
						if (c * l2 < z * p)
							vx[k] = -vx[k];
						vx[k + 2] = -vx[k];
						vy[k + 2] = -vy[k];
					}
					vx[4] = vx[0];
					vy[4] = vy[0];

					auto area = abs(vx[0] * (vy[1] - vy[2]) + vx[1] * (vy[2] - vy[0]) + vx[2] * (vy[0] - vy[1]));//��`�̖ʐ�

					double twoTheta = z >= 0 ? twoTheta = asin(q / l) : twoTheta = pi - asin(q / l);//2�ƎZ�o

					auto devTwoTheta = atan(max(abs(vx[0]), abs(vx[1])) / fd);

					auto startIndex = max(0, (int)((twoTheta - devTwoTheta - startAngle) / stepAngle + 0.5));
					auto intensityPerArea = Intensity[i + jWidth] / area;
					auto area2 = 0.0;
					//��`��x=c�̒����Ő؂���A�ʐϔ���v�Z���郋�[�v��������
					for (int k = startIndex; k < r2len; k++)
					{
						if (r2[k] > twoTheta + devTwoTheta)
						{
							pixels[k] += area - area2;
							profile[k] += (area - area2) * intensityPerArea;
							break;
						}
						auto c = tan(r2[k] - twoTheta) * fd;
						
						int n = 0;
						for (int m = 0; m < 4; m++)
						{
							if (vx[m] < c)
							{
								ptx[n] = vx[m];
								pty[n++] = vy[m];
							}
							if ((vx[m] < c && c <= vx[m + 1]) || (vx[m] >= c && c > vx[m + 1]))
							{
								ptx[n] = c;
								pty[n++] = (c * vy[m + 1] - c * vy[m] - vx[m] * vy[m + 1] + vx[m + 1] * vy[m]) / (vx[m + 1] - vx[m]);
							}
						}

						double area1 = 0;
						if (n == 3)
							area1 = ptx[0] * (pty[1] - pty[2]) + ptx[1] * (pty[2] - pty[0]) + ptx[2] * (pty[0] - pty[1]);
						else if (n == 4)
							area1 = ptx[0] * (pty[1] - pty[3]) + ptx[1] * (pty[2] - pty[0]) + ptx[2] * (pty[3] - pty[1]) + ptx[3] * (pty[0] - pty[2]);
						else if (n == 5)
							area1 = ptx[0] * (pty[1] - pty[4]) + ptx[1] * (pty[2] - pty[0]) + ptx[2] * (pty[3] - pty[1]) + ptx[3] * (pty[4] - pty[2]) + ptx[4] * (pty[0] - pty[3]);

						area1 = abs(area1) * 0.5;

						pixels[k] += area1 - area2;
						profile[k] += (area1 - area2) * intensityPerArea;
						area2 = area1;
					}
				}
			}
		}

		auto mag = 1 / (pixSizeX * pixSizeY);//�W��
		for (int i = 0; i < r2len; i++)
			pixels[i] *= mag;
	}
}