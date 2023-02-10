// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.IO;

namespace Makc2023.Backend.Common.Core.Converting;

/// <summary>
/// Расширение преобразования.
/// </summary>
public static class ConvertingExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать из IP-адреса версии в строковое представление версии 4.
    /// </summary>
    /// <param name="input">IP-адрес.</param>
    /// <returns>Строковое представление IP-адреса.</returns>
    public static string FromIPToV4String(this IPAddress input)
    {
        if (IPAddress.IsLoopback(input))
        {
            return "127.0.0.1";
        }

        // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
        // This usually only happens when the browser is on the same machine as the server.
        if (input.AddressFamily == AddressFamily.InterNetworkV6)
        {
            input = Dns.GetHostEntry(input).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
        }

        return input.ToString();
    }

    /// <summary>
    /// Преобразовать из даты и времени в строку в формате ISO8601.
    /// </summary>
    /// <param name="input">Дата и время.</param>
    /// <returns>Строковое представление даты и времени в формате ISO8601.</returns>
    public static string FromDateTimeToISO8601String(this DateTime input)
    {
        return input.ToString("yyyy-MM-ddTHH:mm:ss.FFF");
    }

    /// <summary>
    /// Преобразовать из даты и времени в строку в формате двусторонней передачи.
    /// </summary>
    /// <param name="input">Дата и время.</param>
    /// <returns>Строковое представление даты и времени в формате двусторонней передачи.</returns>
    public static string FromDateTimeToRoundTripString(this DateTime input)
    {
        return input.ToString("o");
    }

    /// <summary>
    /// Преобразовать из даты и времени с часовым поясом в строку в формате двусторонней передачи.
    /// </summary>
    /// <param name="input">Дата и время с часовым поясом.</param>
    /// <returns>Строковое представление даты и времени с часовым поясом в формате двусторонней передачи.</returns>
    public static string FromDateTimeOffsetToRoundTripString(this DateTimeOffset input)
    {
        return input.ToString("o");
    }

    /// <summary>
    /// Преобразовать из строки в формате двусторонней передачи в дату и время с часовым поясом.
    /// </summary>
    /// <param name="input">Строка в формате двусторонней передачи.</param>
    /// <returns>Дата и время с часовым поясом.</returns>
    public static DateTimeOffset FromRoundTripStringToDateTimeOffset(this string input)
    {
        return DateTimeOffset.ParseExact(input, "o", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Преобразовать из даты в строку.
    /// </summary>
    /// <param name="input">Дата.</param>
    /// <param name="resource">Ресурс.</param>
    /// <returns>Строковое представление даты.</returns>        
    public static string FromDateToString(this DateTime input, IConvertingResource resource)
    {
        return input.ToString(resource.GetFormatForDate(), CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Преобразовать из строки в дату.
    /// </summary>
    /// <param name="input">Строковое представление даты.</param>
    /// <param name="resource">Ресурс.</param>
    /// <returns>Дата.</returns>
    public static DateTime FromStringToDate(this string input, IConvertingResource resource)
    {
        return DateTime.ParseExact(input.Trim(), resource.GetFormatForDate(), CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Преобразовать из даты или нуля в строку.
    /// </summary>
    /// <param name="input">Дата или нуль.</param>
    /// <param name="resource">Ресурс.</param>
    /// <returns>Строковое представления даты или нуля.</returns>
    public static string FromDateNullableToString(this DateTime? input, IConvertingResource resource)
    {
        return input.HasValue ? input.Value.FromDateToString(resource) : "";
    }

    /// <summary>
    /// Преобразовать из предложений в текст.
    /// </summary>
    /// <returns>Текст, состоящий из предложений, разделённых точками.</returns>
    public static string FromSentencesToText(this IEnumerable<string> parts)
    {
        return parts.Any() ? string.Join(". ", parts.Select(x => x.Trim().Trim('.'))) : "";
    }

    /// <summary>
    /// Преобразовать из строки в дату или нуль.
    /// </summary>
    /// <param name="input">Строковое представление даты или нуля.</param>
    /// <param name="resource">Ресурсы преобразования основы ядра.</param>
    /// <returns>Дата или нуль.</returns>
    public static DateTime? FromStringToDateNullable(this string input, IConvertingResource resource)
    {
        return string.IsNullOrWhiteSpace(input) ? null : new DateTime?(input.FromStringToDate(resource));
    }

    /// <summary>
    /// Преобразовать из строки в дробное десятичное число.
    /// </summary>
    /// <param name="input">Строка.</param>
    /// <returns>Десятичная дробь.</returns>
    public static decimal FromStringToNumericDecimal(this string input)
    {
        return decimal.Parse(
            input.Trim(),
            NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
            CultureInfo.InvariantCulture
            );
    }

    /// <summary>
    /// Преобразовать из строки в дробное десятичное число или нуль.
    /// </summary>
    /// <param name="input">Строка.</param>
    /// <returns>Десятичная дробь или нуль.</returns>
    public static decimal? FromStringToNumericDecimalNullable(this string input)
    {
        return string.IsNullOrWhiteSpace(input) ? null : input.FromStringToNumericDecimal();
    }

    /// <summary>
    /// Преобразовать из строки в 32-х разрядное целое число.
    /// </summary>
    /// <param name="input">Строка.</param>
    /// <returns>Целое число.</returns>
    public static int FromStringToNumericInt32(this string input)
    {
        return int.Parse(input.Trim(), CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Преобразовать из строки в 32-х разрядное целое число или NULL.
    /// </summary>
    /// <param name="input">Строка.</param>
    /// <returns>Целое число или NULL.</returns>
    public static int? FromStringToNumericInt32Nullable(this string input)
    {
        return string.IsNullOrWhiteSpace(input) ? null : input.FromStringToNumericInt32();
    }

    /// <summary>
    /// Преобразовать из строки в 64-х разрядное целое число.
    /// </summary>
    /// <param name="input">Строка.</param>
    /// <returns>Целое число.</returns>
    public static long FromStringToNumericInt64(this string input)
    {
        return long.Parse(input.Trim(), CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Преобразовать из строки в 64-х разрядное целое число или NULL.
    /// </summary>
    /// <param name="input">Строка.</param>
    /// <returns>Целое число или NULL.</returns>
    public static long? FromStringToNumericInt64Nullable(this string input)
    {
        return string.IsNullOrWhiteSpace(input) ? null : input.FromStringToNumericInt64();
    }

    /// <summary>
    /// Преобразовать из строки в массив 64-битных целых чисел.
    /// </summary>
    /// <param name="input">Строка.</param>
    /// <returns>Массив 64-битных целых чисел.</returns>
    public static long[] FromStringToNumericInt64Array(this string input)
    {
        return input.FromStringToNumericArray(x => long.Parse(x));
    }

    #endregion Public methods

    #region Private methods

    private static T[] FromStringToNumericArray<T>(this string input, Func<string, T> funcParse)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return Array.Empty<T>();
        }
        else
        {
            return Regex.Replace(input, @"[^\d\+\-]", " ").Split(' ')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => funcParse.Invoke(x))
                .ToArray();
        }
    }

    #endregion Private methods
}
