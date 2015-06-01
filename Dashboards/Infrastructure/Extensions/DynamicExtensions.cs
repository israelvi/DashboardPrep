using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace Dashboards.Infrastructure.Extensions
{
    public static class DynamicExtension
    {
        public static dynamic ToElectionResGeneral(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
                expando.Add(property.Name, property.GetValue(value));

            return expando as ExpandoObject;
        }
    }
}