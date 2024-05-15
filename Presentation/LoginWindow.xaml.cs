using System.Windows;
using System.Windows.Controls;
using DataAccess.Models;
using DataAccess;
using DataAccess.Dapper;
using Logic;
using BC = BCrypt.Net.BCrypt;

namespace Presentation;

public partial class LoginWindow : Window
{
    private ManagerWindow _managerWindow;
    private UserWindow _userWindow;
    
 
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

        _managerWindow = new ManagerWindow(this);
        _managerWindow.Show();
        /* if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
         {
             MessageBox.Show("Username or/and password can not be empty!");
         }*/
        //_managerWindow = new ManagerWindow(this);
        //_managerWindow.Show();
        /*   UserRepository access = new UserRepository();
           var user = access.GetUserByUsernamePassword(txtUserName.Text, txtPassword.Password);


           if (user != null  &&  user.IsManager == true)
           {   
               _managerWindow = new ManagerWindow(this);
               _managerWindow.Show();
           }

           if (user != null && user.IsManager == false)
           {
               _userWindow = new UserWindow(this);
               _userWindow.Show();
           }

           if(user == null)
           {
               MessageBox.Show("Username or / and password Incorrect!");
           }*//*
           _userWindow = new UserWindow(this);
           _userWindow.Show();*/
    }
}