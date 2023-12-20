using Exam.Expressionist;
using Exam.PackageManagerLite;
using System.Linq.Expressions;

namespace DemoExpr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ex = new Expressionist();
            //ex.AddExpression(new Exam.Expressionist.Expression("1", "+", Exam.Expressionist.ExpressionType.Operator, null, null));
            //ex.AddExpression(new Exam.Expressionist.Expression("2", "+", Exam.Expressionist.ExpressionType.Operator, null, null),"1");
            //ex.AddExpression(new Exam.Expressionist.Expression("3", "10", Exam.Expressionist.ExpressionType.Value, null, null),"1");
            //ex.AddExpression(new Exam.Expressionist.Expression("4", "+", Exam.Expressionist.ExpressionType.Operator, null, null),"2");
            //ex.AddExpression(new Exam.Expressionist.Expression("5", "13", Exam.Expressionist.ExpressionType.Value, null, null),"2");
            //ex.AddExpression(new Exam.Expressionist.Expression("6", "2", Exam.Expressionist.ExpressionType.Value, null, null),"4");
            //ex.AddExpression(new Exam.Expressionist.Expression("7", "3", Exam.Expressionist.ExpressionType.Value, null, null),"4");
            //Console.WriteLine(ex.Count());
            //ex.RemoveExpression("5");
            //Console.WriteLine(ex.Evaluate());


            var pm = new PackageManager();
            Package p = new Package("5", "name5", new DateTime(2023, 06, 24), "1.04");
            pm.RegisterPackage(new Package("1", "name1", new DateTime(2023, 06, 20), "1.00"));
            pm.RegisterPackage(new Package("2", "name2", new DateTime(2023, 06, 21), "1.01"));
            pm.RegisterPackage(new Package("3", "name2", new DateTime(2023, 06, 22), "1.02"));
            pm.RegisterPackage(new Package("4", "name4", new DateTime(2023, 06, 23), "1.03"));
            pm.RegisterPackage(p);
            pm.RegisterPackage(new Package("6", "name6", new DateTime(2023, 06, 25), "1.05"));

            pm.AddDependency("1", "6");
            pm.AddDependency("1", "4");
            pm.AddDependency("4", "5");
            pm.AddDependency("4", "1");

            //pm.RemovePackage("4");

            Console.WriteLine(String.Join(", ",pm.GetDependants(p)));
            Console.WriteLine(pm.Count());
            Console.WriteLine(pm.Contains(new Package("4", "name4", new DateTime(2023, 06, 23), "1.03")));
            Console.WriteLine(String.Join(", ", pm.GetIndependentPackages()));
            Console.WriteLine(String.Join(", ", pm.GetOrderedPackagesByReleaseDateThenByVersion()));
        }
    }
}