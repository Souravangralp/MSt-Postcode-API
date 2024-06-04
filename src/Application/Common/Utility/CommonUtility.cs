using System.Reflection;
using System.Text.RegularExpressions;

namespace ProductMatrix.Application.Common.Utility;

public record CommonUtility
{
    public static string ConvertToSnakeCase(string input)
    {
        string snakeCase = Regex.Replace(input, "([a-z])([A-Z])", "$1_$2").ToLower();
        return snakeCase;
    }

    public static List<string> GetPropertyNamesWithOptionalSnakeCase<T>(bool convertToSnakeCase) where T : class
    {
        return convertToSnakeCase
            ? typeof(T).GetProperties().Select(p => ConvertToSnakeCase(p.Name)).ToList()
            : typeof(T).GetProperties().Select(p => p.Name).ToList();
    }

    public static List<string> GetPropertyValues<T>(T instance) where T : class
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var propertyValues = new List<string>();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(instance, null);
            propertyValues.Add(value?.ToString() ?? "null");
        }

        return propertyValues;
    }

    public static List<int?> GetIntersectedProducts(List<GeneralLookUp> securityClassifications)
    {
        List<int?> productIds = [];

        foreach (var sc in securityClassifications)
        {
            //var checkProductIds = sc?.CommonDropdownClassification_SecurityTypeProductSelector?
            //                                                    .Select(stps => stps.SecurityTypeProductSelector_ProductID).ToList();

            //if (checkProductIds is not null)
            //{
            //    if (productIds.Any()) { productIds.AddRange(checkProductIds); }
            //    else { productIds = ProductFilterUtility.GetCommonProducts(productIds, checkProductIds); }
            //}
        }

        return productIds;
    }

    public static List<int?> GetDefaultProducts()
    {
        return [
                 (int)ProductTypes.UltraPrime,
            (int)ProductTypes.SuperPrime,
            (int)ProductTypes.Premium,
            (int)ProductTypes.Optimax,
            (int)ProductTypes.Tolerant,
            (int)ProductTypes.Progressive,
            (int)ProductTypes.Receptive,
            (int)ProductTypes.Liberal,
        ];
    }
}
