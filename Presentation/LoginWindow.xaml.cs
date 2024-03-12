using System.Windows;
using System.Windows.Controls;
using Logic;

namespace Presentation;

public partial class LoginWindow : Window
{
    private ManagerWindow _managerWindow;
    private UserWindow _userWindow;
    
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

        bool loggedin = CurrentUserState.LoggedIn = true;

        if (loggedin)
        {
            IsUser? foundUser = IsUser.FindUser(_username, _password);
            IsManager? foundManager = IsManager.FindManager(_username, _password);

            if (foundManager != null)
            {
                _managerWindow = new ManagerWindow();
                _managerWindow.Show();

            }
            else if (foundUser != null)
            {

                _userWindow = new UserWindow();
                _userWindow.Show();
            }
            else
            {
                MessageBox.Show("The user does not exist.");
            }
        }
        else
        {
            MessageBox.Show("The user is not logged in!");
        }
      
       
       

        /* if(IsManager.Ismanager(txtUserName.Text, txtPassword.Password))
         {
             ManagerWindow managerwindow = new ManagerWindow();
             _managerWindow.Show();

         }
         else if(IsUser.Isuser(txtUserName.Text,txtPassword.Password))
         {
             UserWindow userWindow = new UserWindow();
             userWindow.Show();
         }*/
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        _managerWindow = new ManagerWindow();
        _managerWindow.Show();
    }
}