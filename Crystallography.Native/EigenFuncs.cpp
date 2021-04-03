// EigenFuncs.cpp : DLL アプリケーション用にエクスポートされる関数を定義します。
//

#include "stdafx.h"

/*----------------*/
/* EigenFuncs.cpp */
/*----------------*/
// EigenFuncs.cpp : DLL アプリケーション用にエクスポートされる関数を定義します。
//

//#define EIGEN_NO_DEBUG // コード内のassertを無効化．
//#define EIGEN_NO_STATIC_ASSERT
//#define EIGEN_STACK_ALLOCATION_LIMIT 0
//#define EIGEN_RUNTIME_NO_MALLOC

//#define EIGEN_DONT_VECTORIZE // SIMDを無効化．
//#define EIGEN_DONT_PARALLELIZE // 並列を無効化．
//#define EIGEN_MALLOC_ALREADY_ALIGNED 1
//#define EIGEN_FAST_MATH 1
//#define EIGEN_STRONG_INLINE
//#define EIGEN_INITIALIZE_MATRICES_BY_ZERO
//#define EIGEN_USE_MKL_ALL

#define EIGENFUNCS_EXPORTS

//#include <complex>
#include <stdio.h>
#include <string.h>
#include <vector>
#include "math.h"

#include <Eigen/Core>
#include <Eigen/Dense>
#include <Eigen/Geometry>
#include <Eigen/LU>
#include <Eigen/Eigenvalues>
#include "EigenFuncs.h"
#include <unsupported/Eigen/MatrixFunctions>

using namespace Eigen;
using namespace std;

EIGEN_FUNCS_API complex<double>* toArray(int length, complex<double>* src)
{
	auto result = new complex<double>[length];
	auto r = &result[0];
	memcpy(r, src, length * sizeof(complex<double>));
	return result;
}


const std::complex<double> two_pi_i = complex<double>(0, 2 * 3.141592653589793238462643383279);


extern "C" {

	//複素非対称行列の逆行列を求める
	EIGEN_FUNCS_API complex<double>* _Inverse(int dim, complex<double>* mat)
	{
		//逆行列を求める
		MatrixXcd _mat_inverse = Map<MatrixXcd>(&mat[0], dim, dim).inverse();
		return toArray(dim * dim, _mat_inverse.data());
	}

	//複素非対称行列の固有値、固有ベクトルを求める
	EIGEN_FUNCS_API complex<double>** _EigenSolver(int dim, complex<double>* mat)// , double eigenValues[], double eigenVectors[])
	{
		//固有値、固有ベクトルを求める
		ComplexEigenSolver<MatrixXcd> solver;
		solver.compute(Map<MatrixXcd>(&mat[0], dim, dim));

		complex<double>** result = new complex<double>*[2];
		result[0] = toArray(dim, ((VectorXcd)solver.eigenvalues()).data());
		result[1] = toArray(dim * dim, ((MatrixXcd)solver.eigenvectors()).data());

		return result;
	}

	//複素非対称行列の行列指数を求める
	EIGEN_FUNCS_API complex<double>* _MatrixExponential(int dim, complex<double>* mat)
	{
		MatrixXcd matExp = Map<MatrixXcd>(&mat[0], dim, dim).exp().eval();
		return	toArray(dim * dim, matExp.data());
	}

	//CBEDソルバー
	EIGEN_FUNCS_API complex<double>* _CBEDSolver_Eigen(int dim, complex<double>* potential, complex<double>* psi0, int tDim, double thickness[], double coeff)
	{
		ComplexEigenSolver<MatrixXcd> solver;
		solver.compute(Map<MatrixXcd>(&potential[0], dim, dim));
		VectorXcd values = solver.eigenvalues();
		MatrixXcd vectors = solver.eigenvectors();

		VectorXcd alpha = vectors.partialPivLu().solve(Map<VectorXcd>(&psi0[0], dim));

		VectorXcd gammma_alpha = VectorXcd::Zero(dim);

		complex<double>* result = new complex<double>[dim * tDim];
		auto r = &result[0];
		for (int t = 0; t < tDim; ++t, r+= dim)
		{
			const auto coeff2 = two_pi_i * thickness[t] * coeff;
			for (int g = 0; g < dim; ++g) 
				gammma_alpha[g] = exp(values[g] * coeff2) * alpha[g];

			VectorXcd temp = vectors * gammma_alpha;
			memcpy(r, temp.data(), dim * sizeof(complex<double>));
		}
		return result;

	}

	//CBEDソルバー
	EIGEN_FUNCS_API complex<double>* _CBEDSolver_MtxExp(int dim, complex<double>* potential, complex<double>* psi0, int tDim, double tStart, double tStep, double coeff)//, double result[])
	{
		MatrixXcd pot = Map<MatrixXcd>(&potential[0], dim, dim);

		MatrixXcd matExpStart = (two_pi_i * coeff * tStart * pot).exp().eval();

		VectorXcd vec = matExpStart * Map<VectorXcd>(&psi0[0], dim);

		MatrixXcd matExpStep;

		if (tStep == 0)
			matExpStep = MatrixXcd::Identity(dim, dim);
		else if (tStart == tStep)
			matExpStep = matExpStart;
		else
			matExpStep = (two_pi_i * coeff * tStep * pot).exp().eval();

		complex<double>* result = new complex<double>[dim * tDim];
		auto r = &result[0];

		for (int t = 0; t < tDim; ++t, r += dim)
		{
			if (t != 0)
				vec = matExpStep * vec;
			memcpy(r, vec.data(), dim * sizeof(complex<double>));
		}
		return result;
	}

} // extern "C"