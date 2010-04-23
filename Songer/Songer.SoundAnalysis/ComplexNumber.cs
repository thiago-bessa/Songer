using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songer.SoundAnalysis
{
    public struct ComplexNumber
    {
        public double real;
        public double imaginary;

        public ComplexNumber(double real)
        {
            this.real = real;
            this.imaginary = 0;
        }

        public ComplexNumber(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public static ComplexNumber operator *(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.real * n2.real - n1.imaginary * n2.imaginary,
                n1.imaginary * n2.real + n1.real * n2.imaginary);
        }

        public static ComplexNumber operator +(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.real + n2.real, n1.imaginary + n2.imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.real - n2.real, n1.imaginary - n2.imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber n)
        {
            return new ComplexNumber(-n.real, -n.imaginary);
        }

        public static implicit operator ComplexNumber(double n)
        {
            return new ComplexNumber(n, 0);
        }

        public ComplexNumber PoweredE()
        {
            double e = Math.Exp(this.real);
            return new ComplexNumber(e * Math.Cos(this.imaginary), e * Math.Sin(this.imaginary));
        }

        public double Power2()
        {
            return Math.Pow(this.real, 2) - Math.Pow(this.imaginary, 2);
        }

        public double AbsPower2()
        {
            return Math.Pow(this.real, 2) + Math.Pow(this.imaginary, 2);
        }

        public override string ToString()
        {
            return String.Format("{0}+i*{1}", real, imaginary);
        }
    }
}
