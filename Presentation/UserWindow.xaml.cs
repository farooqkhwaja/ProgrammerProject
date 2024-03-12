using System.Windows;

namespace Presentation;

public partial class UserWindow : Window
{
    LoginWindow log;
    public UserWindow(LoginWindow log)
    {
        InitializeComponent();
        this.log = log;
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
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