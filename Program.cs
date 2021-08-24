using System;

namespace GenerateInvoice
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 10982;
            Console.WriteLine(GenerateInvoice(counter));

            //1.FORMAT : INV / 202108 / TH / XIX / XXI / 10983
            //2.INV => STATIS
            //3. 202108, 2021 Tahun sekarang; 08 Bulan sekarang, (agustus 8 => 08, december 12 => 12)
            //4.TH, Hari THURSDAY, 2 Karakter TH
            //5.XIX, 19 Tanggal Romawi
            //6.XXI, 2021, tahun belakang 21 Romawi
            //7. 10983, counter
        }

        private static string GenerateInvoice(int count)
        {

            string bagian1 = DateTime.Now.ToString("yyyyMM");
            string date = DateTime.Now.ToString("ddd").Substring(0, 2).ToUpper();
            int hari = DateTime.Now.Day;
            int tahun = DateTime.Now.Year;
            string romawi_hari = ToRoman(hari);
            string romawi_tahun = ToRoman(tahun).Substring(2);
            return $"INV/{bagian1}/{date}/{romawi_hari}/{romawi_tahun}/{count + 1}";
        }
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); 
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
        }
    }
}
