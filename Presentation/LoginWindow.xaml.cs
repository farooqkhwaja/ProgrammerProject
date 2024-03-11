using System.Windows;
using System.Windows.Controls;
using Logic;

namespace Presentation;

public partial class LoginWindow : Window
{
    private ManagerWindow _managerWindow;
    
    private string _username;
    private string _password;
    
    public LoginWindow()
    {
        InitializeComponent();
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
        this.Visibility = Visibility.Collapsed;
        
        if(IsManager.Ismanager(txtUserName.Text, txtPassword.Password))
        {
            ManagerWindow managerwindow = new ManagerWindow();
            _managerWindow.Show();

        }
        else if(IsUser.Isuser(txtUserName.Text,txtPassword.Password))
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
        }
        else
        {
            Console.WriteLine("The user does not exist.");
        }      
        
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Close();
    }
}