using System.Windows;

namespace Presentation;

public partial class UserWindow : Window
{
    public UserWindow()
    {
        InitializeComponent();
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
    }

    private void genereepartner_Click(object sender, RoutedEventArgs e)
    {
        //hello
    }

    private void bewaarfiguren_Click(object sender, RoutedEventArgs e)
    {

    }

    private void verzendemail_Click(object sender, RoutedEventArgs e)
    {

    }
}