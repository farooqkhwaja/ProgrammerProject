using System.Windows;
using System.Windows.Controls;
using DataAccess;
using DataAccess.Models;
using Logic;

namespace Presentation;

public partial class ManagerWindow : Window
{
    private LoginWindow _loginWindow;
    private readonly SaveAttendance _saveAttendance;
    private RegisterStudents _registerStudents;
    public ManagerWindow(LoginWindow loginWindow)
    {
        InitializeComponent();
        _loginWindow = loginWindow;
        _loginWindow.Visibility = Visibility.Collapsed;

        _saveAttendance = new SaveAttendance();
    }
    private void Window_Closed(object sender, EventArgs e)
    {
        _loginWindow.Visibility = Visibility.Visible;
    }
    private void inschrijven_cursist_Click(object sender, RoutedEventArgs e)
    {
        
        User user = new User();

        user.FirstName = voornaam.Text;
        user.LastName = achternaam.Text;
        user.Sex = geslacht.Text;

    
        CursistenList.Items.Add(user.FirstName +" "+ user.LastName );
    }

    private void addDanceMove_Click(object sender, RoutedEventArgs e)
    {             
        
    }

    private void DeleteDanceMove_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddEvent_Click(object sender, RoutedEventArgs e)
    {
     
    }

    private void UpdateEvent_Click(object sender, RoutedEventArgs e)
    {

    }

    private void DeleteEvent_Click(object sender, RoutedEventArgs e)
    {

    }

    private void CursistenList_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {

    }

    
    private void Cursisten_lijst_updaten_Click(object sender, RoutedEventArgs e)
    {

    }

   
}