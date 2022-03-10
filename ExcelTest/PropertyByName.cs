using System;

namespace Grand.Business.System.Utilities
{
    /// <summary>
    /// A helper class to access the property by name
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public class PropertyByName<T>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="func">Feature property access</param>
        public PropertyByName(string propertyName, Func<T, object> func = null)
        {
            PropertyName = propertyName;
            GetProperty = func;

            PropertyOrderPosition = 0;
        }

        /// <summary>
        /// Property order position
        /// </summary>
        public int PropertyOrderPosition { get; set; }

        /// <summary>
        /// Feature property access
        /// </summary>
        public Func<T, object> GetProperty { get; private set; }

        /// <summary>
        /// Property name
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// Property value
        /// </summary>
        public object PropertyValue { get; set; }

        /// <summary>
        /// Converted property value to Int32
        /// </summary>
        public int IntValue => PropertyValue == null || !int.TryParse(PropertyValue.ToString(), out var rez) ? default : rez;

        /// <summary>
        /// Converted property value to bool
        /// </summary>
        public bool BooleanValue => PropertyValue != null && bool.TryParse(PropertyValue.ToString(), out var rez) && rez;

        /// <summary>
        /// Converted property value to string
        /// </summary>
        public string StringValue => PropertyValue == null ? string.Empty : Convert.ToString(PropertyValue);

        /// <summary>
        /// Converted property value to double
        /// </summary>
        public double DecimalValue => PropertyValue == null || !double.TryParse(PropertyValue.ToString(), out var rez) ? default : rez;

        /// <summary>
        /// Converted property value to double?
        /// </summary>
        public double? DecimalValueNullable => PropertyValue == null || !double.TryParse(PropertyValue.ToString(), out var rez) ? null : rez;

        /// <summary>
        /// Converted property value to double
        /// </summary>
        public double DoubleValue => PropertyValue == null || !double.TryParse(PropertyValue.ToString(), out var rez) ? default : rez;

        /// <summary>
        /// Converted property value to DateTime?
        /// </summary>
        public DateTime? DateTimeNullable => PropertyValue != null && DateTime.TryParse(PropertyValue.ToString(), out var date) ? (DateTime?)date : default;

        public override string ToString()
        {
            return PropertyName;
        }
    }
}