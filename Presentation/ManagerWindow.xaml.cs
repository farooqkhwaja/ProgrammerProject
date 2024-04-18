using System.Windows;
using Logic;
using DataAccess.Models;
using DataAccess;
using System.Windows.Media.TextFormatting;
using System.Collections.ObjectModel;

namespace Presentation;

public partial class ManagerWindow : Window
{   
    private readonly UploadLinksAccess _uploadlinksaccess;
    private readonly UploadLinks _uploadlinks;
    private readonly UserAccess _useraccess;
    private readonly DataAccessServices _dataaccessservices;
    private readonly LoginWindow _loginWindow;
    private readonly SaveAttendance _saveAttendance;
    private readonly RegisterStudents _registerStudents;
    public ManagerWindow(LoginWindow loginWindow)
    {
        InitializeComponent();
        _loginWindow = loginWindow;
        _loginWindow.Visibility = Visibility.Collapsed;
        _saveAttendance = new SaveAttendance();
        _uploadlinksaccess = new UploadLinksAccess();
        _uploadlinks = new UploadLinks();
        _useraccess = new UserAccess();
        _dataaccessservices = new DataAccessServices();

        DansFilmLinksList.ItemsSource = _uploadlinksaccess.GetLinks(); 
        CursistenList.ItemsSource = _useraccess.GetUsers();
       
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        _loginWindow.Visibility = Visibility.Visible;
    }

    private void inschrijven_cursist_Click(object sender, RoutedEventArgs e)
    { 
        var msgResult = _dataaccessservices.RegisterUser(txtFirstname.Text, txtLastname.Text, txtsex.Text);
        MessageBox.Show(msgResult);

        CursistenList.ItemsSource = _useraccess.GetUsers();
        CursistenList.Items.Refresh();
    }

    private void addDanceMove_Click(object sender, RoutedEventArgs e)
    {
        string link = DansLinksToevoegenBox.Text.Trim();

        if (!string.IsNullOrWhiteSpace(link))
        {
            UploadLinks newLink = new UploadLinks
            {
                Link = link
            };

      
            _uploadlinksaccess.CreateLink(newLink.Link);

            DansFilmLinksList.ItemsSource = _uploadlinksaccess.GetLinks();
            
        }
    }
    private void DeleteDanceMove_Click(object sender, RoutedEventArgs e)
    { 

        if (DansFilmLinksList.SelectedItem is UploadLinks)
        {
            var selectedItem = DansFilmLinksList.SelectedItem as UploadLinks;

            _uploadlinksaccess.DeleteLink(selectedItem.Id);

            DansFilmLinksList.ItemsSource = _uploadlinksaccess.GetLinks();
      
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