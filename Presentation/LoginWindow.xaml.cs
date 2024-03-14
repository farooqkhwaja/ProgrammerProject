using System.Windows;
using System.Windows.Controls;
using DataAccess;
using Logic;

namespace Presentation;

public partial class LoginWindow : Window
{
    private ManagerWindow _managerWindow { get; set; }
    private UserWindow _userWindow { get; set; }
    
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
        _username = txtUserName.Text;
        _password = txtPassword.Password;

        bool loggedin = CurrentUserState.LoggedIn = true;

        if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
        {
            MessageBox.Show("Username or/and password can not be empty.");
        }


        DummyDatabse ddb = new DummyDatabse();
        var allUsers = ddb.GetAllUsers();

        foreach (var user in allUsers)
        {
            if (user.Username == _username && user.Password == _password && user.IsManager == true)
            {
                _managerWindow = new ManagerWindow(this);
                _managerWindow.Show();
            }
            else
            {
                _userWindow = new UserWindow(this);
                _userWindow.Show();
            }
        }        
        MessageBox.Show("The user is not logged in!");     

                
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        
    }
}