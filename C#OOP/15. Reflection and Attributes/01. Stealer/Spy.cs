using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsArray)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields((BindingFlags)60);
            StringBuilder sb = new StringBuilder();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {className}");
            foreach (FieldInfo field in classFields.Where(x => fieldsArray.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                
            }
            return sb.ToString().Trim();
        }
    }
}
