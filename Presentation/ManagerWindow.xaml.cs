using System.Windows;
using Logic;
using DataAccess.Models;
using DataAccess;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
    private readonly UploadEventAccess _uploadEventAccess;
    private readonly UploadEvents _uploadEvents;
    public ManagerWindow(LoginWindow loginWindow)
    {
        InitializeComponent();
        _loginWindow = loginWindow;
        _loginWindow.Visibility = Visibility.Collapsed;
        _saveAttendance = new SaveAttendance();
        _uploadlinksaccess = new UploadLinksAccess();
        _uploadlinks = new UploadLinks();
        _uploadEventAccess = new UploadEventAccess();
        _uploadEvents = new UploadEvents();
        _useraccess = new UserAccess();
        _dataaccessservices = new DataAccessServices();

        DansFilmLinksList.ItemsSource = _uploadlinksaccess.GetLinks(); 
        CursistenList.ItemsSource = _useraccess.GetUsers();
        EvenementenLinks.ItemsSource = _uploadEventAccess.GetEvents();
    }



    private void inschrijven_cursist_Click(object sender, RoutedEventArgs e)
    { 
        var msgResult = _dataaccessservices.RegisterUser(txtFirstname.Text, txtLastname.Text, txtsex.Text);
        MessageBox.Show(msgResult);

        CursistenList.ItemsSource = _useraccess.GetUsers();
    
    }
    private void delete_cursist_Click(object sender, RoutedEventArgs e)
    {
        if (CursistenList.SelectedItem is User)
        {
            var selectedItem = CursistenList.SelectedItem as User;
            _useraccess.DeleteUser(selectedItem.Id);
            CursistenList.ItemsSource = _useraccess.GetUsers();
        }
        else
        {
            MessageBox.Show("Please select a person to delete.", "No person Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    private void AddDanceLinks_Click(object sender, RoutedEventArgs e)
    {
        string link = DansLinksToevoegenBox.Text.Trim();

        if (!string.IsNullOrWhiteSpace(link))
        {
            UploadLinks newLink = new UploadLinks
            {
                Link = link
            };

            _uploadlinksaccess.CreateLink(newLink.Link);
        }
    }
    private void DeleteDanceMove_Click(object sender, RoutedEventArgs e)
    {
        if (DansFilmLinksList.SelectedItem is UploadLinks)
        {
            var selectedItem = DansFilmLinksList.SelectedItem as UploadLinks;
            _uploadlinksaccess.DeleteLink(selectedItem.Id);
        }
        else
        {
            MessageBox.Show("Please select a link to delete.", "No Link Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    private void UpdateDanceLinks_Click(object sender, RoutedEventArgs e)
    {
        DansFilmLinksList.ItemsSource = _uploadlinksaccess.GetLinks();
    }

    private void AddEvent_Click(object sender, RoutedEventArgs e)
    {
       
        if(_uploadEventAccess != null)
        {
            string eventData = EvenementenToevoegenBox.Text;
            string eventname = eventData.Split(' ')[0];
            string eventdate = eventData.Split(' ')[1];
            _uploadEventAccess.CreateEvent(eventname, eventdate);
        }
       
    }
    private void DeleteEvent_Click(object sender, RoutedEventArgs e)
    {
        if (_uploadEventAccess != null)
        {
            var selectedItem = EvenementenLinks.SelectedItem as UploadEvents;
            _uploadEventAccess.DeleteEvents(selectedItem.Id);
        }
        else
        {
            MessageBox.Show("Please select a event to delete.", "No event Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    private void UpdateEvent_Click(object sender, RoutedEventArgs e)
    {
        EvenementenLinks.ItemsSource = _uploadEventAccess.GetEvents();
    }
}