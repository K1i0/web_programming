using System;

namespace DegreesConversion
{
    class FahrenheitToCelsius
    {
        // static void Main(string[] args)
        // {
        //     Console.Write("Введите значение градусов: ");
        //     double degreesValue = Convert.ToDouble(Console.ReadLine());
        //     Console.Write("Введите название шкалы (C, K, F): ");
        //     string? scaleTypeFrom = Console.ReadLine();
        //     while (scaleTypeFrom != "C" && scaleTypeFrom != "K" && scaleTypeFrom != "F") {
        //         Console.Write("Неверная шкала измерений ({0}), введите еще раз (C, K, F): ", scaleTypeFrom);
        //         scaleTypeFrom = Console.ReadLine();
        //     }
        //     Console.Write("В какую шкалу требуется перевод? (C, K, F): ");
        //     string? scaleTypeTo = Console.ReadLine();
        //     while (scaleTypeTo != "C" && scaleTypeTo != "K" && scaleTypeTo != "F") {
        //         Console.Write("Неверная шкала измерений ({0}), введите еще раз (C, K, F): ", scaleTypeTo);
        //         scaleTypeTo = Console.ReadLine();
        //     }
        //     Console.WriteLine("{0}{1}° это {2}{3}°", degreesValue, scaleTypeFrom, convertDegrees(scaleTypeFrom, scaleTypeTo, degreesValue), scaleTypeTo);
        // }

        static double convertDegrees(string? scaleTypeFrom, string? scaleTypeTo, double degreesValue)
        {
            switch (scaleTypeFrom)
            {
                case "C":
                    {
                        switch (scaleTypeTo)
                        {
                            case "C":
                                {
                                    return degreesValue;
                                }
                            case "K":
                                {
                                    return degreesValue + 273.15;
                                }
                            case "F":
                                {
                                    return (9.0 / 5 * degreesValue) + 32;
                                }
                            default: return double.NaN;
                        }
                    }
                case "K":
                    {
                        switch (scaleTypeTo)
                        {
                            case "C":
                                {
                                    return degreesValue - 273.15;
                                }
                            case "K":
                                {
                                    return degreesValue;
                                }
                            case "F":
                                {
                                    return (9.0 / 5 * degreesValue) - 459.67;
                                }
                            default: return double.NaN;
                        }
                    }
                case "F":
                    {
                        switch (scaleTypeTo)
                        {
                            case "C":
                                {
                                    return (degreesValue - 32) * (5.0 / 9);
                                }
                            case "K":
                                {
                                    return (degreesValue + 459.67) * (5.0 / 9);
                                }
                            case "F":
                                {
                                    return degreesValue;
                                }
                            default: return double.NaN;
                        }
                    }
            }
            return double.NaN;
        }
    }
}
