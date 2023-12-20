using Exam.Categorization;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cat = new Categorizator();
            cat.AddCategory(new Category("1", "1", null));
            cat.AddCategory(new Category("2", "2", null));
            cat.AddCategory(new Category("3", "3", null));
            cat.AddCategory(new Category("4", "4", null));

            cat.AssignParent("3", "1");
            cat.AssignParent("1", "4");
            cat.AssignParent("4", "2");
            //cat.RemoveCategory("1");
            

            //Console.WriteLine(String.Join(", ",cat.GetHierarchy("3")));
            //Console.WriteLine(String.Join(", ",cat.GetChildren("2")));
            Console.WriteLine(String.Join(", ",cat.GetTop3CategoriesOrderedByDepthOfChildrenThenByName()));
        }
    }
}