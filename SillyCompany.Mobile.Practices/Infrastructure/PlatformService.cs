﻿using Xamarin.Forms;

namespace SillyCompany.Mobile.Practices.Infrastructure
{
    public enum OS
    {
        Android = 1,
        iOS = 2,
    }

    public enum ScreenSize
    {
        Regular = 0,
        Small = 1,
        Big = 2,
    }

    public static class PlatformService
    {
        public static double DisplayScaleFactor { get; private set; }

        public static Size MainSize { get; private set; }

        public static bool IsFoldingScreen { get; private set; }

        public static ScreenSize ScreenSize
        {
            get
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    if (MainSize.Width <= 320)
                    {
                        return ScreenSize.Small;
                    }

                    if (MainSize.Width <= 375)
                    {
                        return ScreenSize.Regular;
                    }

                    return ScreenSize.Big;
                }

                // Android
                if (MainSize.Width <= 384)
                {
                    return ScreenSize.Small;
                }

                if (MainSize.Width <= 540)
                {
                    return ScreenSize.Regular;
                }

                return ScreenSize.Big;
            }
        }

        public static void Initialize(double scaleFactor, double width, double height)
        {
            DisplayScaleFactor = scaleFactor;

            if (width > height)
            {
                var temp = width;
                width = height;
                height = temp;
            }

            MainSize = new Size(width, height);
        }

        public static void InitializeFoldingScreen(bool isFoldingScreen)
        {
            IsFoldingScreen = isFoldingScreen;
        }

        public static int DpToPixels(int dp) => (int)(DisplayScaleFactor * dp);

        public static int DpToPixels(double dp) => (int)(DisplayScaleFactor * dp);
    }
}