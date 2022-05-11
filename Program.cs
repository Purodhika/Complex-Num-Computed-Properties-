using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Purodhika
{
    class Complex
    {
        //properties
        public int Real { get; set; }
        public int Imaginary { get; set; }
        //computed property
        public double Argument
        {
            get
            {   
                //finds inverse of tan
                return Math.Atan(Imaginary / Real);
            }
        }
        //computed property
        public double Modulus
        {
            get
            {
                return Math.Sqrt(Real * Real + Imaginary * Imaginary);
            }
        }

        //factory property
        public static Complex Zero 
        {
            get
            {
                return new Complex(0, 0);
               
             }
        }

        //constructor with 2-args
        public Complex(int real, int imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;

        }

        public override string ToString()
        {
            return $"(Real, Imaginary):({Real},{Imaginary})";
        }

        //adds two numbers
        public static Complex operator +(Complex lhs, Complex rhs)
        {
            int real = lhs.Real + rhs.Real;
            int imaginary = lhs.Imaginary + rhs.Imaginary;
            return new Complex(real, imaginary);
        }

        //subtraction overloading
        public static Complex operator -(Complex lhs, Complex rhs)
        {
            int real = lhs.Real - rhs.Real;
            int imaginary = lhs.Imaginary - rhs.Imaginary;
            return new Complex(real, imaginary);
        }

        //boolean operator to check matching values
        public static bool operator ==(Complex lhs, Complex rhs)
        {
            if ((lhs.Real == rhs.Real) && (lhs.Imaginary == rhs.Imaginary))
                return (true);
            else
                return (false);
        }

        public static bool operator !=(Complex lhs, Complex rhs)
        {
            if ((lhs.Real != rhs.Real) && (lhs.Imaginary != rhs.Imaginary))
                return (true);
            else
                return (false);
        }

        //overloads to multiply
        public static Complex operator *(Complex lhs, Complex rhs)
        {  
            //<a, b> * <c, d> = <ac-bd, ad+bc>
            int real = lhs.Real * rhs.Real - lhs.Imaginary * lhs.Imaginary;
            int imaginary = lhs.Real * rhs.Imaginary + rhs.Real * lhs.Imaginary;
            return new Complex(real, imaginary);
            
        }

        //unary operator overload to negate the value
        public static Complex operator -(Complex rhs)
        {
            //-<a, b> = <-a, -b>
            int real = -rhs.Real;
            int imaginary= -rhs.Imaginary;
            return new Complex(real, imaginary);
        }
        
    }

    class Complexrun
    { 
        public static void Main(String[] args)
        {   
            //declaring and assigning values to objects
            Complex c0 = new Complex(-2, 3);
            Complex c1 = new Complex(-2, 3);
            Complex c2 = new Complex(1, -2);

            //prints the value of first object
            Console.WriteLine($"{c0}");

            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine("\n");

            //calls the addition overload method and adds the values of two objects
            Console.WriteLine($"{c1} + {c2} = {c1 + c2}");
            Console.WriteLine("\n");

            ////calls the subtraction overload method and subtracts the values of two objects
            Console.WriteLine($"{c1} - {c2} = {c1 - c2}");
            Console.WriteLine("\n");

            //new object with value= sum of c1 and c2
            Complex c3 = c1 + c2;

            //prints the polar form of c3
            Console.WriteLine($"{c3} in polar form is { c3.Modulus:f2}cis({ c3.Argument:f2})");
            Console.WriteLine("\n");

            //evaluates if object c0 == c1
            Console.WriteLine($"{c0} {(c0 == c1 ? "=" : "!=")} {c1}");
            Console.WriteLine("\n");

            //evaluates if object c0 == c2
            Console.WriteLine($"{c0} {(c0 == c2 ? "=" : "!=")} {c2}");
            Console.WriteLine("\n");

            //calls the multiplication overload method and prints the product
            Console.WriteLine($"{c1} * {c0} = { c1 * c0}");
            Console.WriteLine("\n");

            //calls the unary operator method and negates value
            Console.WriteLine($" Unary Operator (-) on {c2}= {-c2}");
            Console.WriteLine("\n");

        }
    }
}