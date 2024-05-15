namespace RemoveDuplicationExample
{
    public class ImageProcessor
    {
        public Image Scale(Image image, float scaleFactor)
        {
            return image;
        }

        public Image Rotate(Image image, int degrees)
        {
            return image;
        }
    }
    public class Image
    {
        private int _width = 100;
        public int width { get { return _width; } }

        public void Dispose() { }
    }
    public class Original
    {
        private readonly ImageProcessor processor;
        public Original()
        {
            processor = new ImageProcessor();
        }
        public void ScaleImage(ref Image image, int newWidth)
        {
            var scaleFactor = newWidth / image.width;
            var newImage = processor.Scale(image, scaleFactor);

            image.Dispose();//these two lines are repeated code
            image = newImage;//it is worth even trying to remove duplications of these lines
        }

        public void RotateImage(ref Image image, int degrees)
        {
            var newImage = processor.Rotate(image, degrees);

            image.Dispose();
            image = newImage;
        }
    }

    public class Refactored
    {
        private readonly ImageProcessor processor;
        public Refactored()
        {
            processor = new ImageProcessor();
        }

        public void ScaleImage(ref Image image, int newWidth)
        {
            var scaleFactor = newWidth / image.width;
            var newImage = processor.Scale(image, scaleFactor);
            ReplaceImage(ref image, newImage);
        }

        public void RotateImage(ref Image image, int degrees)
        {
            var newImage = processor.Rotate(image, degrees);
            ReplaceImage(ref image, newImage);
        }

        private void ReplaceImage(ref Image image, Image newImage)
        {
            image.Dispose();
            image = newImage;
        }
    }
}
