using System.Windows;
using System.Windows.Controls;
using DataAccess;
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
         
        _username = txtUserName.Text;
        _password = txtPassword.Password;

        bool loggedin = CurrentUserState.LoggedIn = true;

        if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
        {
            MessageBox.Show("Username or/and password can not be empty.");
        }


        DummyDatabase ddb = new DummyDatabase();
        var allUsers = ddb.GetAllUsers();

        _managerWindow = new ManagerWindow(this);
        _userWindow = new UserWindow(this);

        foreach (var user in allUsers)
        {
            if (user.Username == _username && user.Password == _password && user.IsManager == true)
            {               
                _managerWindow.Show();
            }
            else if (user.Username == _username && user.Password == _password && user.IsManager == false)
            {          
                _userWindow.Show();
            }
           
        }

        this.Close();
    }

    private void Window_Closed(object sender, EventArgs e)
    {

    }
}