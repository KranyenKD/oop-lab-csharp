namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        protected bool Equals(Complex other)
        {
            return re.Equals(other.re) && im.Equals(other.im);
        }

        private readonly double re;
        private readonly double im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real
        {
            get
            {
                return this.re;
            }
        }

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary
        {
            get
            {
                return this.im;
            }
        }

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.Real , 2) + Math.Pow(this.Imaginary , 2));
            }
        }

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase
        {
            get
            {
                return Math.Atan(this.Imaginary / this.Real);
            }
        }

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            return this.Real + this.Imaginary + "i";
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            if (this.Real == other.Real && this.Imaginary == other.Imaginary) return true;
            return false;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Complex) obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(re, im);
        }
    }
}
