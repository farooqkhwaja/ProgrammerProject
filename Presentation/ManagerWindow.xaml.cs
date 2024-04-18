using System.Windows;
using Logic;
using DataAccess.Models;
using DataAccess;
using System.Windows.Media.TextFormatting;
using System.Collections.ObjectModel;

namespace Presentation;

public partial class ManagerWindow : Window
{
    static public List<UploadLinks> Linklist = new List<UploadLinks>();
    private LoginWindow _loginWindow;
    private readonly SaveAttendance _saveAttendance;
    private RegisterStudents _registerStudents;
    public ManagerWindow(LoginWindow loginWindow)
    {
        InitializeComponent();
        _loginWindow = loginWindow;
        _loginWindow.Visibility = Visibility.Collapsed;

        _saveAttendance = new SaveAttendance();
        UploadLinksAccess uploadLinks = new UploadLinksAccess();
      
        DansFilmLinksList.ItemsSource = Linklist;
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        _loginWindow.Visibility = Visibility.Visible;
    }

    private void inschrijven_cursist_Click(object sender, RoutedEventArgs e)
    {
        DataAccessServices dataaccessservices = new DataAccessServices();   
        var msgResult = dataaccessservices.RegisterUser(txtFirstname.Text, txtLastname.Text, txtsex.Text);

        CursistenList.Items.Add(txtFirstname.Text); 

        MessageBox.Show(msgResult);
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

          
            Linklist.Add(newLink);

            UploadLinksAccess uploadLinksAccess = new UploadLinksAccess();
            uploadLinksAccess.CreateLink(newLink);
        }
    }
    private void DeleteDanceMove_Click(object sender, RoutedEventArgs e)
    {   
        //UploadLinksAccess uploadlinksaccess = new UploadLinksAccess();

        UploadLinksAccess link = (UploadLinksAccess)DansFilmLinksList.SelectedItem;
        
        if (link != null)
        {
            UploadLinksAccess uploadLinksAccess = new UploadLinksAccess();
            uploadLinksAccess.DeleteLink(1);
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