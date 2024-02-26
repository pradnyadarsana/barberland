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

    /// <summary>
    /// This method is used to Populating Data to Show By Paging.
    /// </summary>
    /// <param name="Data">Data Ready to Show</param>
    /// <param name="Page">Current page (Automatically changed to 1 if less than 1 and changed to 1 if more than TotalPages)</param>
    /// <param name="DataPerPage">Maximum data returned in one page</param>
    /// <param name="TotalPages">Total maximum pages within provided data</param>
    public static IQueryable<T> PopulateDataPaging<T>(IQueryable<T> Data, int Page, int DataPerPage, out int TotalPages)
    {
        TotalPages = (int)Math.Ceiling(((decimal)Data.Count() / (decimal)DataPerPage));
        Page = Page <= 0 ? 1 : (Page > TotalPages ? 1 : Page);

        return Data.Skip((Page - 1) * DataPerPage).Take(DataPerPage);
    }
}

