using System;

namespace FileExplorerWPF
{
    /// <summary>
    /// Change window theme
    /// </summary>
    public static class ThemeChanger
    {
        public static void SetDarkTheme(MainWindow window)
        {
            window.Resources.MergedDictionaries.Clear();
            System.Windows.ResourceDictionary rd = System.Windows.Application.LoadComponent(new Uri("Themes/DarkTheme.xaml", UriKind.Relative)) as System.Windows.ResourceDictionary;
            window.Resources.MergedDictionaries.Add(rd);
        }
        public static void SetLightTheme(MainWindow window)
        {
            window.Resources.MergedDictionaries.Clear();
            System.Windows.ResourceDictionary rd = System.Windows.Application.LoadComponent(new Uri("Themes/LightTheme.xaml", UriKind.Relative)) as System.Windows.ResourceDictionary;
            window.Resources.MergedDictionaries.Add(rd);
        }
        public static void SetColourfulDarkTheme(MainWindow window)
        {
            window.Resources.MergedDictionaries.Clear();
            System.Windows.ResourceDictionary rd = System.Windows.Application.LoadComponent(new Uri("Themes/ColourfulDarkTheme.xaml", UriKind.Relative)) as System.Windows.ResourceDictionary;
            window.Resources.MergedDictionaries.Add(rd);
        }
        public static void SetColourfulLightTheme(MainWindow window)
        {
            window.Resources.MergedDictionaries.Clear();
            System.Windows.ResourceDictionary rd = System.Windows.Application.LoadComponent(new Uri("Themes/ColourfulLightTheme.xaml", UriKind.Relative)) as System.Windows.ResourceDictionary;
            window.Resources.MergedDictionaries.Add(rd);
        }
    }
}
