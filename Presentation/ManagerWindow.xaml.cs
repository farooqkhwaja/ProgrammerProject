using System.Windows;
using Logic;
using DataAccess.Models;
using DataAccess;
using DataAccess.Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Policy;
using System;

namespace Presentation;

public partial class ManagerWindow : Window
{
    private readonly DanceCategoryRepository _danceCategoryRepository;
    private readonly DanceCategory _danceCategory;
    private readonly Locations _locations;
    private readonly LocationRepository _locationRepository;
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
        _danceCategoryRepository = new DanceCategoryRepository();
        _locationRepository = new LocationRepository();

        DansFilmLinksList.ItemsSource = _uploadlinksRepository.GetLinks(); 
        CursistenList.ItemsSource = _userRepository.GetUsers();
        EvenementenLinks.ItemsSource = _uploadEventRepository.GetEvents();
        cbx_categorie.ItemsSource = _danceCategoryRepository.GetdanceCategories();
        cbx_categoriename.ItemsSource = _danceCategoryRepository.GetdanceCategories();
        cbx_locatie.ItemsSource = _locationRepository.GetLocations();
    }

    private void inschrijven_cursist_Click(object sender, RoutedEventArgs e)
    {
        var msgResult = _registerStudent.RegisterUser(txtFirstname.Text, txtLastname.Text, txtsex.Text,tbx_password.Text, tbx_Username.Text, tbx_email.Text);
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
        var selectedLocation = cbx_locatie.SelectedItem as Locations;
        var selectedCategory = cbx_categoriename.SelectedItem as DanceCategory;
        
        Events _event = new Events();
        _event.Name = tbx_EvenementenToevoegenBox.Text;
        _event.Date = tbx_EvenementDatum.Text;
        _event.DanceCategoryId = selectedCategory.Id;
        _event.LocationId = selectedLocation.Id;
        _event.UserId = 3; //TODO

        _uploadEventRepository.SaveEvent(_event);

        
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
            _uploadEventRepository.DeleteEvent(selectedItem.Id);
        }
        else
        {
            MessageBox.Show("Please select a event to delete.", "No event Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    private void AddDanceFilmLinks_Click(object sender, RoutedEventArgs e)
    {
        string figureName = tbx_AddDanceName.Text;
        string linkadres = tbx_AddDanceUrl.Text;
        int gemaaktDoor = Convert.ToInt32( cbx_gemaaktdoor.Text);


        if (!string.IsNullOrWhiteSpace(figureName))
        {
            Links newLink = new Links
            {
                Name = figureName,
                url = linkadres,
                CreatedBy = gemaaktDoor
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
        var users = _userRepository.GetUserByFirstName(firstname) as IList<User>;

        aanwezighedenlijst.ItemsSource = users;

    }
    private void btn_SaveAanwezigheid_Click(object sender, RoutedEventArgs e)
    {

    }
    private void btn_bewaarProgress_Click(object sender, RoutedEventArgs e)
    {

    }
}