using System.Windows;

namespace Presentation;

public partial class UserWindow : Window
{
    public LoginWindow loginWindow { get; set; }
    public UserWindow(LoginWindow loginWindow)
    {
        InitializeComponent();
        loginWindow = loginWindow;
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        
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