// EigenFuncs.cpp : DLL アプリケーション用にエクスポートされる関数を定義します。
//

#include "stdafx.h"

/*----------------*/
/* EigenFuncs.cpp */
/*----------------*/
// EigenFuncs.cpp : DLL アプリケーション用にエクスポートされる関数を定義します。
//

#define EIGEN_NO_DEBUG // コード内のassertを無効化．
//#define EIGEN_NO_STATIC_ASSERT
//#define EIGEN_STACK_ALLOCATION_LIMIT 0
//#define EIGEN_RUNTIME_NO_MALLOC

//#define EIGEN_DONT_VECTORIZE // SIMDを無効化．
//#define EIGEN_DONT_PARALLELIZE // 並列を無効化．
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

	//複素非対称行列の逆行列を求める
	EIGEN_FUNCS_API void _Inverse(int dim, double mat[], double inverse[])
	{
		memcpy(inverse, ((Mat)Map<Mat>((dcomplex*)mat, dim, dim).inverse()).data(), sizeComplex * dim * dim);
	}

	//複素非対称行列の固有値、固有ベクトルを求める
	EIGEN_FUNCS_API void _EigenSolver(int dim, double mat[], double eigenValues[], double eigenVectors[])
	{
		ComplexEigenSolver<Mat> solver(Map<Mat>((dcomplex*)mat, dim, dim));
		memcpy(eigenValues, solver.eigenvalues().data(), sizeComplex * dim);
		memcpy(eigenVectors, solver.eigenvectors().data(), sizeComplex * dim * dim);
	}

	//複素非対称行列の行列指数を求める
	EIGEN_FUNCS_API void _MatrixExponential(int dim, double mat[], double results[])
	{
		memcpy(results, Map<MatrixXcd>((dcomplex*)mat, dim, dim).exp().eval().data(), sizeComplex * dim * dim);
	}

	//CBEDソルバー
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

	//CBEDソルバー
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