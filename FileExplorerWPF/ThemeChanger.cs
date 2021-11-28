using System;
using System.Windows;

namespace FileExplorerWPF
{
    /// <summary>
    /// Change window theme
    /// </summary>
    public static class ThemeChanger
    {
        public static void Change(MainWindow window, Theme theme)
        {
            window.Resources.MergedDictionaries.Clear();
            window.Resources.MergedDictionaries.Add(getThemeUri(theme));
        }
        private static ResourceDictionary getThemeUri(Theme theme)
        {
            string uri = "";
            switch (theme)
            {
                case Theme.Dark:
                    uri = "Themes/DarkTheme.xaml";
                    break;
                case Theme.Light:
                    uri = "Themes/LightTheme.xaml";
                    break;
                case Theme.ColourfulDark:
                    uri = "Themes/ColourfulDarkTheme.xaml";
                    break;
                case Theme.ColourfulLight:
                    uri = "Themes/ColourfulLightTheme.xaml";
                    break;
            }
            return Application.LoadComponent(new Uri(uri, UriKind.Relative)) as ResourceDictionary;
        }
    }
    public enum Theme
    {
        Dark, Light, ColourfulDark, ColourfulLight,
    }
}
