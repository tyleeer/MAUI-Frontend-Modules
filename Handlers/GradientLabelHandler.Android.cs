using Android.Graphics;
using AndroidX.AppCompat.Widget;
using FrontendModule.Templates;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;

namespace FrontendModule.Handlers
{
    public partial class GradientLabelHandler : LabelHandler
    {
        private GradientLabel gradientLabel;

        protected override void ConnectHandler(AppCompatTextView platformView)
        {
            gradientLabel = (GradientLabel)VirtualView;

            var width = platformView.Paint.MeasureText(gradientLabel.Text ?? "");
            var stringDeg = gradientLabel.GradientDegree;
            var deg = 0;
            if (int.TryParse(stringDeg, out int intValue))
                deg = intValue;// Conversion successful, use intValue here
            var c1 = gradientLabel.TextColor1.ToAndroid();
            var c2 = gradientLabel.TextColor2.ToAndroid();


            //Custom your on direction, colors, and Tile Mode here

            var textShader = new LinearGradient(deg, width, 0, platformView.TextSize,
                colors: new int[]
                {
                    c1,
                    c2
                },
                null,
                Shader.TileMode.Clamp);

            platformView.Paint.SetShader(textShader);

            base.ConnectHandler(platformView);
        }

        protected override void DisconnectHandler(AppCompatTextView platformView)
        {
            base.DisconnectHandler(platformView);

            gradientLabel = null;
        }
    }
    /*public partial class GradientLabelHandler : LabelHandler
    {
        private GradientLabel gradientLabel;

        protected override void ConnectHandler(AppCompatTextView platformView)
        {
            gradientLabel = (GradientLabel)VirtualView;

            var width = platformView.Paint.MeasureText(gradientLabel.Text ?? "");
            var stringDeg = gradientLabel.GradientDegree;
            var deg = 0;
            if (int.TryParse(stringDeg, out int intValue))
                deg = intValue;// Conversion successful, use intValue here
            var c1 = gradientLabel.TextColor2.ToAndroid();
            var c2 = gradientLabel.TextColor1.ToAndroid();


            //Custom your on direction, colors, and Tile Mode here

            var textShader = new LinearGradient(deg, width, 0, platformView.TextSize,
                colors: new int[]
                {
                    c1,
                    c2
                },
                new float[]
                {
                    0.0f,
                    1.0f
                },
                Shader.TileMode.Clamp);

            platformView.Paint.SetShader(textShader);

            base.ConnectHandler(platformView);
        }

        protected override void DisconnectHandler(AppCompatTextView platformView)
        {
            base.DisconnectHandler(platformView);

            gradientLabel = null;
        }
    }*/
}
