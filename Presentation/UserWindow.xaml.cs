using System.Windows;

namespace Presentation;

public partial class UserWindow : Window
{
    private LoginWindow _loginWindow;
    public UserWindow(LoginWindow loginWindow)
    {
        InitializeComponent();
        _loginWindow = loginWindow;

        _loginWindow.Visibility = Visibility.Collapsed;
        
    }
    private void Window_Closed(object sender, EventArgs e)
    {
        _loginWindow.Visibility = Visibility.Visible;
    }

    private void genereepartner_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void bewaarfiguren_Click(object sender, RoutedEventArgs e)
    {

    }

    private void verzendemail_Click(object sender, RoutedEventArgs e)
    {

    }
}