using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private string _value;
        public IConsole Console;

        public StringCalculator()
        {

        }

        public StringCalculator( IConsole console )
        {
            Console = console;
        }

        public int Add( string value )
        {
            _value = value;
            var result = calculateSum();
            outputResult( result );
            return result;
        }

        private void outputResult( int result )
        {
            if ( Console != null )
            {
                Console.WriteLine( result.ToString() );
            }
        }

        private int calculateSum()
        {
            return handleEmptyValues()
                .extractDigits()
                .Sum();
        }

        private List<int> extractDigits()
        {
            var digits = new List<int>();

            Array.ForEach(
                _value.Split( ',' ),
                extractDigit( digits )
            );

            return digits;
        }

        private static Action<string> extractDigit( List<int> digits )
        {
            return c =>
            {
                var number = int.Parse( c );
                handleNegatives( number );
                digits.Add( number );
            };
        }

        private static void handleNegatives( int number )
        {
            if ( number < 0 )
                throw new Exception( "Negative numbers are not allowed" );
        }

        private StringCalculator handleEmptyValues()
        {
            if ( stringIsEmpty() )
            {
                _value = "0";
            }
            return this;
        }

        private bool stringIsEmpty()
        {
            return string.IsNullOrEmpty( _value );
        }
    }
}