using System.Windows;
using DataAccess.ADO;

namespace Presentation;

public partial class UserWindow : Window
{
    private readonly LoginWindow _loginWindow;
    public UserWindow(LoginWindow loginwindow)
    {
        InitializeComponent();
        _loginWindow = loginwindow;




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
    private void Window_Closed(object sender, EventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
    }
}