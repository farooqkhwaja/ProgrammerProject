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
}