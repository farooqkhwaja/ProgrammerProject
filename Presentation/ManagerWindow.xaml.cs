using System.Windows;
using Logic;
using DataAccess.Models;
using DataAccess;
using DataAccess.ADO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentation;

public partial class ManagerWindow : Window
{   
    private readonly LinksRepository _uploadlinksRepository;
    private readonly Links _uploadlinks;
    private readonly UserRepository _userRepository;
    private readonly RegisterStudent _registerStudent;
    private readonly LoginWindow _loginWindow;
    private readonly SaveAttendance _saveAttendance;
    private readonly EventRepository _uploadEventRepository;
    private readonly Events _uploadEvents;
    public ManagerWindow(LoginWindow loginWindow)
    {
        InitializeComponent();
        _loginWindow = loginWindow;
        _loginWindow.Visibility = Visibility.Collapsed;
        _saveAttendance = new SaveAttendance();
        _uploadlinksRepository = new LinksRepository();
        _uploadlinks = new Links();
        _uploadEventRepository = new EventRepository();
        _uploadEvents = new Events();
        _userRepository = new UserRepository();
        _registerStudent = new RegisterStudent();

        DansFilmLinksList.ItemsSource = _uploadlinksRepository.GetLinks(); 
        CursistenList.ItemsSource = _userRepository.GetUsers();
        EvenementenLinks.ItemsSource = _uploadEventRepository.GetEvents();
    }

    private void inschrijven_cursist_Click(object sender, RoutedEventArgs e)
    {
        var msgResult = ""; // _registerStudent.RegisterUser(txtFirstname.Text, txtLastname.Text, txtsex.Text,tbx_password.Text, tbx_Username.Text, tbx_leraar.Text,cbx_categorie.Text);
        MessageBox.Show(msgResult);

        CursistenList.ItemsSource = _userRepository.GetUsers();
    
    }
    private void delete_cursist_Click(object sender, RoutedEventArgs e)
    {
        if (CursistenList.SelectedItem is User)
        {
            var selectedItem = CursistenList.SelectedItem as User;
            _userRepository.DeleteUser(selectedItem.Id);
            CursistenList.ItemsSource = _userRepository.GetUsers();
        }
        else
        {
            MessageBox.Show("Please select a person to delete.", "No person Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    private void AddEvent_Click(object sender, RoutedEventArgs e)
    {

        if (_uploadEventRepository != null)
        {
            string eventName = tbx_EvenementenToevoegenBox.Text;
            string eventDate = tbx_EvenementDatum.Text;
            string eventStudent = tbx_EvenementStudent.Text;
            int eventLocatie = Convert.ToInt32(tbx_EvenementLocatie.Text);

            _uploadEventRepository.CreateEvent(eventName, eventDate, eventStudent, eventLocatie);
        }

    }
    private void UpdateEvent_Click(object sender, RoutedEventArgs e)
    {
        EvenementenLinks.ItemsSource = _uploadEventRepository.GetEvents();
    }
    private void DeleteEvent_Click(object sender, RoutedEventArgs e)
    {
        if (_uploadEventRepository != null)
        {
            var selectedItem = EvenementenLinks.SelectedItem as Events;
            _uploadEventRepository.DeleteEvents(selectedItem.Id);
        }
        else
        {
            MessageBox.Show("Please select a event to delete.", "No event Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    private void AddDanceFilmLinks_Click(object sender, RoutedEventArgs e)
    {
        string figureName = tbx_AddDanceName.Text;
        string linkadres = tbx_AddDanceLink.Text;
        string gemaaktDoor =  tbx_AddGemaaktDoor.Text;

        if (!string.IsNullOrWhiteSpace(figureName))
        {
            Links newLink = new Links
            {
                //FigureName = figureName,
                //LinkAdres = linkadres,
                //GemaaktDoor = gemaaktDoor
            };

            _uploadlinksRepository.CreateLink(newLink);
        }
    }
    private void DeleteDanceLink_Click(object sender, RoutedEventArgs e)
    {
        if (DansFilmLinksList.SelectedItem is Links)
        {
            var selectedItem = DansFilmLinksList.SelectedItem as Links;
            _uploadlinksRepository.DeleteLink(selectedItem.Id);
        }
        else
        {
            MessageBox.Show("Please select a link to delete.", "No Link Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    private void UpdateDanceLink_Click(object sender, RoutedEventArgs e)
    {
        DansFilmLinksList.ItemsSource = _uploadlinksRepository.GetLinks();
    }

    private void btn_ZoekOpNaam_Click(object sender, RoutedEventArgs e)
    {
        string firstname = tbx_ZoekOpNaam.Text;
        _userRepository.GetUserByFirstName(firstname);
    }

    private void btn_SaveAanwezigheid_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_bewaarProgress_Click(object sender, RoutedEventArgs e)
    {

    }
}