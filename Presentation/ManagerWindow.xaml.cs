using System.Windows;
using Logic;

using DataAccess.Models;
using DataAccess;


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
  
    private void CursistenList_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)

    {
        if(_useraccess != null)
        {
            string eventlink = EvenementenToevoegenBox.Text;

            string name = eventlink.Split(' ')[0];
            string date = eventlink.Split(' ')[1];

            _uploadEvents.Name = name;
            _uploadEvents.Date = date;

            _uploadEventAccess.CreateEvent(name, date);
        }  
        else
        {
            MessageBox.Show("Please provide both name and date separated by space.");
        }
    }

   
    private void UpdateEvent_Click(object sender, RoutedEventArgs e)
    {
        EvenementenLinks.ItemsSource = _uploadEventAccess.GetEvents();
    }


   
    

}