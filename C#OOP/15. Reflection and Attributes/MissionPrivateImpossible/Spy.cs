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
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classNonPrivateFields = classType.GetFields((BindingFlags)28);
            MethodInfo[] classNonPublicMethods = classType.GetMethods((BindingFlags)36);
            MethodInfo[] classNonPrivateMethods = classType.GetMethods((BindingFlags)20);
            StringBuilder sb = new StringBuilder();
            foreach (var field in classNonPrivateFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in classNonPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in classNonPrivateMethods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);            
            MethodInfo[] classNonPublicMethods = classType.GetMethods((BindingFlags)36);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (var method in classNonPublicMethods)
            {
                sb.AppendLine($"{method.Name}");
            }
            return sb.ToString().Trim();
        }
    }
}
