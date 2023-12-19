using System.Globalization;

namespace Barberland.Utility;

public class GlobalFunction
{
    public static string CreateDecimalMoneyFormatIDR(decimal value)
    {
        CultureInfo culture = CultureInfo.CreateSpecificCulture("id-ID");
        //return value.ToString("00.00", culture);
        string result = string.Format(culture, "{0:C0}", value);
        result = result.Replace("Rp", "");
        return result;
    }
}

