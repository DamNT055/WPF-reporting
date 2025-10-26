namespace DXApplication2.Model
{
    public class Dimensions
    {
        public Dimensions(double length, double width, double height, double depth)
        {
            
            Length = length;
            Width = width;
            Height = height;
            Depth = depth;
        }

        // Chiều dài
        public double Length { get; set; }

        // Chiều rộng
        public double Width { get; set; }

        // Chiều cao
        public double Height { get; set; }

        // Độ sâu
        public double Depth { get; set; }
    }
}
