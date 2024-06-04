using System.Reflection;

namespace MSt_Postcode_API.Application.Common.Extensions;

public static class TypeConversionExtension
{
    /// <summary>
    /// This method is being used to dynamically typeCaste the value to the provided conversion type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns>dynamic value</returns>
    public static dynamic? GetValue(this object value, string dataType)
    {
        if (value is not null)
        {
            if (dataType.Replace(" ", "").ToLower() == "int") { return int.TryParse(value.ToString(), out int intValue) ? intValue : null; }
            if (dataType.Replace(" ", "").ToLower() == "double") { return double.TryParse(value.ToString(), out double doubleValue) ? doubleValue : null; }
            if (dataType.Replace(" ", "").ToLower() == "string") { return string.IsNullOrWhiteSpace(value.ToString()) ? string.Empty : value.ToString(); }
            if (dataType.Replace(" ", "").ToLower() == "bool") { return value.ToString() == "1" ? true : (dynamic)false; }
            // Add more data types as needed...
        }
        else 
        {
            return null;
        }

        // Return default value for the specified type if value is null or type is unsupported
        Type targetType = Assembly.GetExecutingAssembly().GetType(dataType) ?? throw new ArgumentException($"value : {value} of dataType : {dataType} is not supported");
        return targetType != null && targetType.IsValueType && Nullable.GetUnderlyingType(targetType) == null
            ? Activator.CreateInstance(targetType)
            : null;
    }

    public static dynamic GetCastedValue(string datatype, string value)
    {
        switch (datatype.ToLower().Replace(" ", ""))
        {
            case "int":
                if (int.TryParse(value, out int intValue))
                {
                    return intValue;
                }
                break;
            case "bool":
                return bool.TryParse(value, out bool boolValue);
            case "double":
                if (double.TryParse(value, out double doubleValue))
                {
                    return doubleValue;
                }
                break;
            case "decimal":
                if (decimal.TryParse(value, out decimal decimalValue))
                {
                    return decimalValue;
                }
                break;
            default:
                return value;
        }

        return value;
    }
}
