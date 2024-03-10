using System.Windows;
using System.Windows.Controls;
using Logic;

namespace Presentation.UserControls;

public partial class Login : UserControl
{
    private ManagerWindow _managerWindow;
    
    private string _username;
    private string _password;
    
    public Login()
    {
        InitializeComponent();
        DataContext = this;
    }
    
    private void TxtUserName_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
        {
            btnLogin.IsEnabled = false;
        }
        else
        {
            btnLogin.IsEnabled = true;
        }
    }

    private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
        {
            btnLogin.IsEnabled = false;
        }
        else
        {
            btnLogin.IsEnabled = true;
        }
    }

    private void BtnLogin_Click(object sender, RoutedEventArgs e)
    {
        if(string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
        {
            MessageBox.Show("Username or/and password can not be empty.");
        }

        _username = txtUserName.Text;
        _password = txtPassword.Password;

        CurrentUserState.LoggedIn = true;

        Visibility = Visibility.Collapsed;
        
        _managerWindow = new ManagerWindow();
        _managerWindow.Show();
    }
}