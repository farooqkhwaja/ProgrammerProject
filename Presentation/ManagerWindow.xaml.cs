using System.Windows;
using Logic.Dto;
using Logic;
using DataAccess.Models;
using DataAccess;
using System.Windows.Media.TextFormatting;

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
        
        UserDto user = new UserDto();
        
        user.FirstName = voornaam.Text;
        user.LastName = achternaam.Text;
        user.Sex = geslacht.Text;

        if (!CursistenList.Items.Contains(user.FirstName + " " + user.LastName))
        {
            CursistenList.Items.Add(user.FirstName + " " + user.LastName);
        }
       
    }

    private void addDanceMove_Click(object sender, RoutedEventArgs e)
    {

        string link = DansLinksToevoegenBox.Text;
        DansFilmLinksList.ItemsSource = link;

        if (!string.IsNullOrWhiteSpace(link))
        {
            UploadLinks newLink = new UploadLinks
            {            
                Link = link
            };

            UploadLinksAccess uploadLinksAccess = new UploadLinksAccess();

            uploadLinksAccess.CreateLink(newLink);
        }
    }
    private void DeleteDanceMove_Click(object sender, RoutedEventArgs e)
    {
        UploadLinks selectedLink = (UploadLinks)DansFilmLinksList.SelectedItem;

        if (selectedLink != null)
        {
            UploadLinksAccess uploadLinksAccess = new UploadLinksAccess();

            uploadLinksAccess.DeleteLink(selectedLink);
        }
        else
        {
            MessageBox.Show("Please select a link to delete.", "No Link Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }

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
    
    private void Cursisten_lijst_updaten_Click(object sender, RoutedEventArgs e)
    {

    }

    private void UpdateDanceLinks_Click(object sender, RoutedEventArgs e)
    {

    }
}