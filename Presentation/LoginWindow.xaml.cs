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
        _username = txtUserName.Text;
        _password = txtPassword.Password;


        if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
        {
            MessageBox.Show("Username or/and password can not be empty.");
        }
        

        DataAccessServices dataAccessServices = new DataAccessServices();
        var allUsers = dataAccessServices.GetUserdata();

        bool found = false;
        foreach (var users in allUsers)
        {
            
            if (users.Username == _username && users.Password == _password && users.IsManager == true)
            {
                
                found = true;
                _managerWindow = new ManagerWindow(this);
                _managerWindow.Show();
                break;
            }

            if (users.Username == _username && users.Password == _password && users.IsManager == false)
            {
                found = true;
                _userWindow = new UserWindow(this);
                _userWindow.Show();
                break;
            }                  
        }

        if (found is false)
        {
            MessageBox.Show("Username or/and password Incorrect");
        }
    }
    private void Window_Closed(object sender, EventArgs e)
    {
        
    }
}