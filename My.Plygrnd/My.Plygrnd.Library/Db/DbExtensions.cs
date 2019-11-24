using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace My.Plygrnd.Library.Db
{
    public static class DbExtensions
    {
        public static void AddParameter(this IDbCommand command, string name, dynamic value)
        {
            var p = command.CreateParameter();
            p.ParameterName = "@" + name;
            if (value != null) p.Value = value;
            else p.Value = DBNull.Value;
            command.Parameters.Add(p);
        }

        public static T PopulateFromRow<T>(this IDataReader dataReader) where T : class, new()
        {
            var result = new T();
            var type = typeof(T);
            dataReader.ForEachFieldInRow((name, value) => {
                var property = type.GetProperty(name);
                if (property != null) SetPropertyValue(value, property, result);
            });

            return result;
        }

        public static void ForEachFieldInRow(this IDataReader dataReader, Action<string, object> action)
        {
            for (var i = 0; i < dataReader.FieldCount; i++)
            {
                var fieldName = dataReader.GetName(i);
                var fieldValue = dataReader.GetValue(i);
                action(fieldName, fieldValue);
            }
        }

        private static void SetPropertyValue(object fieldValue, PropertyInfo property, object result)
        {
            if (fieldValue == DBNull.Value) return;
            property.SetValue(
                result,
                property.PropertyType.IsEnum ? Enum.Parse(property.PropertyType, fieldValue.ToString()) : fieldValue);
        }
    }
}
