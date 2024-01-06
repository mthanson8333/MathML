using Microsoft.Maui.Graphics;

using static System.Net.Mime.MediaTypeNames;

using Font = Microsoft.Maui.Graphics.Font;

namespace Canvas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            //WidthOfGraphics = displayScreen.Width;
            //TitleOfPage = TitlePage.FontFamily;
            WebViewBorder.IsVisible = true;
        }

        public static string? TitleOfPage 
        {
            get;
            private set;
        }
        public static double WidthOfGraphics
        {
            get; private set;
        }

    }

    public class GraphicsDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float widthOfGraphics = (float)MainPage.WidthOfGraphics;
            string text1 = "Text is left aligned.";
            string text2 = "Text is centered.";
            string text3 = "Text is right aligned.";
            float fontSize = 18;

            var sizeText1 = canvas.GetStringSize(text1, new Font(MainPage.TitleOfPage), fontSize);
            var sizeText2 = canvas.GetStringSize(text2, new Font(MainPage.TitleOfPage), fontSize);
            var sizeText3 = canvas.GetStringSize(text3, new Font(MainPage.TitleOfPage), fontSize);

            sizeText1.Width += 1;
            sizeText2.Width += 1;
            sizeText3.Width += 1;
            sizeText1.Height *= 2;
            sizeText2.Height *= 2;
            sizeText3.Height *= 2;

            canvas.FontColor = Colors.Red;
            canvas.FontSize = fontSize;

            canvas.DrawString(text1, 10, 20, (float)Math.Ceiling(widthOfGraphics), sizeText1.Height, HorizontalAlignment.Left, VerticalAlignment.Top);
            canvas.DrawString(text2, (widthOfGraphics / 2) - (sizeText2.Width / 2), 60, (float)Math.Ceiling(sizeText2.Width), sizeText2.Height, HorizontalAlignment.Left, VerticalAlignment.Top);
            canvas.DrawString(text3, widthOfGraphics - sizeText3.Width - 10, 100, (float)Math.Ceiling(sizeText3.Width), sizeText3.Height, HorizontalAlignment.Left, VerticalAlignment.Top);            
        }
    }
}
