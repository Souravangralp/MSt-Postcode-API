using System.Reflection;

namespace ProductMatrix.Application.Common.Extensions;

public static class TypeConversionExtension
{
    public static dynamic? GetValue2(this object value, string dataType)
    {
        if (value is not null)
        {
            if (dataType.Replace(" ","").ToLower() == "int") { return int.TryParse(value.ToString(), out int intValue) ? intValue : null; }
            if (dataType.Replace(" ","").ToLower() == "double") { return double.TryParse(value.ToString(), out double doubleValue) ? doubleValue : null; }
            if (dataType.Replace(" ","").ToLower() == "string") { return string.IsNullOrWhiteSpace(value.ToString()) ? string.Empty : value.ToString(); }
            if (dataType.Replace(" ", "").ToLower() == "bool") { return value.ToString() == "1" ? true : (dynamic)false; }
            // Add more data types as needed...
        }

        // Return default value for the specified type if value is null or type is unsupported
        Type targetType = Assembly.GetExecutingAssembly().GetType(dataType) ?? throw new ArgumentException($"value : {value} of dataType : {dataType} is not supported");
        return targetType != null && targetType.IsValueType && Nullable.GetUnderlyingType(targetType) == null
            ? Activator.CreateInstance(targetType)
            : null;
    }

    /// <summary>
    /// This method is being used to dynamically typeCaste the value to the provided conversion type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns>dynamic value</returns>
    public static dynamic? GetValue<T>(this object value)
    {
        if (value is not null)
        {
            if (typeof(T) == typeof(int)) { return int.TryParse(value.ToString(), out int intValue) ? intValue : null; }
            if (typeof(T) == typeof(double)) { return double.TryParse(value.ToString(), out double doubleValue) ? doubleValue : null; }
            //if (typeof(T) == typeof(float)) { return float.TryParse(value.ToString(), out float floatValue) ? floatValue : null; }
            if (typeof(T) == typeof(string)) { return value.ToString(); }
            if (typeof(T) == typeof(bool)) { return value.ToString() == 1.ToString() ? true : (dynamic)false; }
        }

        // Return default value for the specified type if value is null or type is unsupported
        return typeof(T).IsValueType && Nullable.GetUnderlyingType(typeof(T)) == null ? Activator.CreateInstance(typeof(T)) : null;
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
