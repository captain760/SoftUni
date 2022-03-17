using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            GraphicEditor edit = new GraphicEditor();
            edit.DrawShape(circle);
            IShape triangle = new Triangle();
            edit.DrawShape(triangle);
        }
    }
}
