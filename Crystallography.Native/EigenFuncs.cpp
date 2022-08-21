// EigenFuncs.cpp : DLL �A�v���P�[�V�����p�ɃG�N�X�|�[�g�����֐����`���܂��B
//

#include "stdafx.h"

/*----------------*/
/* EigenFuncs.cpp */
/*----------------*/
// EigenFuncs.cpp : DLL �A�v���P�[�V�����p�ɃG�N�X�|�[�g�����֐����`���܂��B
//

#define EIGEN_NO_DEBUG // �R�[�h����assert�𖳌����D
//#define EIGEN_NO_STATIC_ASSERT
//#define EIGEN_STACK_ALLOCATION_LIMIT 0
//#define EIGEN_RUNTIME_NO_MALLOC

//#define EIGEN_DONT_VECTORIZE // SIMD�𖳌����D
//#define EIGEN_DONT_PARALLELIZE // ����𖳌����D
//#define EIGEN_MALLOC_ALREADY_ALIGNED 1
//#define EIGEN_FAST_MATH 1
#define EIGEN_STRONG_INLINE
//#define EIGEN_INITIALIZE_MATRICES_BY_ZERO
//#define EIGEN_USE_MKL_ALL

#define EIGENFUNCS_EXPORTS

//#include <complex>
#include <stdio.h>
#include <string.h>
#include <vector>
#include "math.h"

#include <../Eigen/Core>
#include <../Eigen/Dense>
#include <../Eigen/Geometry>
#include <../Eigen/LU>
#include <../Eigen/Eigenvalues>
#include "EigenFuncs.h"
#include <../unsupported/Eigen/MatrixFunctions>

using namespace Eigen;
using namespace std;

const std::complex<double> two_pi_i = complex<double>(0, 2 * 3.141592653589793238462643383279);
const size_t sizeComplex = sizeof(complex<double>);

#define Mat MatrixXcd
#define Vec VectorXcd

extern "C" {

	//STEM�̔�e���U���d�q���x�̌v�Z�p�̓���֐�
	EIGEN_FUNCS_API void _STEM_TDS(int dim, double B[],  double U[], double C_k[], double C_kq[], double result[])
	{
		auto b = Map<Mat>((dcomplex*)B, dim, dim);
		auto u = Map<Mat>((dcomplex*)U, dim, dim);
		auto c_k = Map<Mat>((dcomplex*)C_k, dim, dim);
		auto c_kq = Map<Mat>((dcomplex*)C_kq, dim, dim);

		dcomplex s = b.cwiseProduct(c_kq.adjoint() * u * c_k).sum();
		//auto s = (b * c_kq.adjoint() * u * c_k).trace();
		result[0] = s.real();
		result[1] = s.imag();
	}

	//���f��Ώ̍s���mat1��mat2�̗v�f���Ƃ̊|�Z(�A�_�}�[����)�����
	EIGEN_FUNCS_API void _PointwiseMultiply(int dim, double mat1[], double mat2[], double result[])
	{
		auto m1 = (Mat)Map<Mat>((dcomplex*)mat1, dim, dim);
		auto m2 = (Mat)Map<Mat>((dcomplex*)mat2, dim, dim);
		memcpy(result, m1.cwiseProduct(m2).eval().data(), sizeComplex * dim * dim);
	}

	//���f��Ώ̍s���mat1������]�l���āAmat2�Ɋ|����
	EIGEN_FUNCS_API void _AdjointAndMultiply(int dim, double mat1[], double mat2[], double result[])
	{
		auto m1 = (Mat)Map<Mat>((dcomplex*)mat1, dim, dim);
		auto m2 = (Mat)Map<Mat>((dcomplex*)mat2, dim, dim);
		memcpy(result, (m1.adjoint() * m2).eval().data(), sizeComplex * dim * dim);
	}

	//���f��Ώ̍s��̏�Z�����߂�
	EIGEN_FUNCS_API void _Multiply(int dim, double mat1[], double mat2[], double result[])
	{
		auto m1 = (Mat)Map<Mat>((dcomplex*)mat1, dim, dim);
		auto m2 = (Mat)Map<Mat>((dcomplex*)mat2, dim, dim);
		memcpy(result, (m1 * m2).eval().data(), sizeComplex * dim * dim);
	}

	//���f��Ώ̍s��̋t�s������߂�
	EIGEN_FUNCS_API void _Inverse(int dim, double mat[], double inverse[])
	{
		memcpy(inverse, ((Mat)Map<Mat>((dcomplex*)mat, dim, dim).inverse()).data(), sizeComplex * dim * dim);
	}

	//���f��Ώ̍s��̌ŗL�l�A�ŗL�x�N�g�������߂�
	EIGEN_FUNCS_API void _EigenSolver(int dim, double mat[], double eigenValues[], double eigenVectors[])
	{
		ComplexEigenSolver<Mat> solver(Map<Mat>((dcomplex*)mat, dim, dim));
		memcpy(eigenValues, solver.eigenvalues().data(), sizeComplex * dim);
		memcpy(eigenVectors, solver.eigenvectors().data(), sizeComplex * dim * dim);
	}

	//���f��Ώ̍s��̍s��w�������߂�
	EIGEN_FUNCS_API void _MatrixExponential(int dim, double mat[], double results[])
	{
		memcpy(results, Map<MatrixXcd>((dcomplex*)mat, dim, dim).exp().eval().data(), sizeComplex * dim * dim);
	}

	//CBED�\���o�[
	EIGEN_FUNCS_API void _CBEDSolver_Eigen(int dim, double potential[], double psi0[], int tDim, double thickness[], double coeff, double result[])
	{
		ComplexEigenSolver<Mat> solver(Map<Mat>((dcomplex*)potential, dim, dim));
		Vec values = solver.eigenvalues();
		Mat vectors = solver.eigenvectors();
		Vec alpha = vectors.partialPivLu().solve(Map<Vec>((dcomplex*)psi0, dim));
		Vec gammma_alpha = Vec::Zero(dim);

		for (int t = 0; t < tDim; ++t)
		{
			const auto coeff2 = two_pi_i * thickness[t] * coeff;
			for (int g = 0; g < dim; ++g)
				gammma_alpha[g] = exp(values[g] * coeff2) * alpha[g];
			memcpy(&result[t * dim * 2], ((Vec)(vectors * gammma_alpha)).data(), sizeComplex * dim);
		}
	}

	//CBED�\���o�[
	EIGEN_FUNCS_API void _CBEDSolver_MtxExp(int dim, double potential[], double psi0[], int tDim, double tStart, double tStep, double coeff, double result[])
	{
		Mat matExp = (two_pi_i * tStart * coeff * Map<Mat>((dcomplex*)potential, dim, dim)).exp().eval();
		Vec vec = matExp * Map<Vec>((dcomplex*)psi0, dim);
		memcpy(&result[0], vec.data(), sizeComplex * dim);

		if (tStep == 0)
			return;
		
		if (tStart != tStep)
			matExp = (two_pi_i * tStep * coeff * Map<Mat>((dcomplex*)potential, dim, dim)).exp().eval();
		for (int t = 1; t < tDim; ++t)
		{
			vec = matExp * vec;
			memcpy(&result[t * dim * 2], vec.data(), sizeComplex * dim);
		}
	}

} // extern "C"