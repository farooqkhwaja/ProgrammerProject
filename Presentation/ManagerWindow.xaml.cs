using System.Windows;
using Logic;
using DataAccess.Models;
using DataAccess.Dapper;

namespace Presentation;

public partial class ManagerWindow : Window
{
    private readonly DanceCategoryRepository _danceCategoryRepository;
    private readonly DanceCategory _danceCategory;
    private readonly Locations _locations;
    private readonly LocationRepository _locationRepository;
    private readonly LinksRepository _linksRepository;
    private readonly UserRepository _userRepository;
    private readonly RegisterStudent _registerStudent;
    private readonly LoginWindow _loginWindow;
    private readonly EventRepository _eventRepository;
    
    public ManagerWindow(LoginWindow loginWindow)
    {
        InitializeComponent();
        _loginWindow = loginWindow;
        _loginWindow.Visibility = Visibility.Collapsed;
        _linksRepository = new LinksRepository();
        _eventRepository = new EventRepository();
        _userRepository = new UserRepository();
        _registerStudent = new RegisterStudent();
        _danceCategoryRepository = new DanceCategoryRepository();
        _locationRepository = new LocationRepository();

        DansFilmLinksList.ItemsSource = _linksRepository.GetLinks(); 
        CursistenList.ItemsSource = _userRepository.GetUsers();
        EvenementenLinks.ItemsSource = _eventRepository.GetEvents();
        cbx_categorie.ItemsSource = _danceCategoryRepository.GetdanceCategories();
        cbx_categoriename.ItemsSource = _danceCategoryRepository.GetdanceCategories();
        cbx_locatie.ItemsSource = _locationRepository.GetLocations();
    }

    private void SubscribeUser_Click(object sender, RoutedEventArgs e)
    {
        var msgResult = _registerStudent.RegisterUser(txtFirstname.Text, txtLastname.Text, txtsex.Text,tbx_password.Text, tbx_Username.Text, tbx_email.Text);
        
        MessageBox.Show(msgResult);

        CursistenList.ItemsSource = _userRepository.GetUsers();
    }
    
    private void DeleteUser_Click(object sender, RoutedEventArgs e)
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

        _eventRepository.SaveEvent(_event);
    }
    
    private void UpdateEvent_Click(object sender, RoutedEventArgs e)
    {
        EvenementenLinks.ItemsSource = _eventRepository.GetEvents();
    }
    
    private void DeleteEvent_Click(object sender, RoutedEventArgs e)
    {
        if (_eventRepository != null)
        {
            var selectedItem = EvenementenLinks.SelectedItem as Events;
            _eventRepository.DeleteEvent(selectedItem.Id);
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

        //int gemaaktDoor = Convert.ToInt32( cbx_gemaaktdoor.Text);

        var selectedCategory = cbx_categories.SelectedItem as DanceCategory; // Foriegn keys moet je casten en wij hebben altijd de id van foriegn key table nodig

        if (!string.IsNullOrWhiteSpace(figureName))
        {

            Links newLink = new Links
            {
                Name = figureName,
                url = linkadres,
                CreatedBy = selectedCategory.Id,
            };
            
          
            _linksRepository.CreateLink(newLink);
        }
    }
    
    private void DeleteDanceLink_Click(object sender, RoutedEventArgs e)
    {
        if (DansFilmLinksList.SelectedItem is Links)
        {
            var selectedItem = DansFilmLinksList.SelectedItem as Links;
            _linksRepository.DeleteLink(selectedItem.Id);
        }
        else
        {
            MessageBox.Show("Please select a link to delete.", "No Link Selected", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    
    private void UpdateDanceLink_Click(object sender, RoutedEventArgs e)
    {
        DansFilmLinksList.ItemsSource = _linksRepository.GetLinks();
    }
    
    private void SearchByName_Click(object sender, RoutedEventArgs e)
    {
        string firstname = tbx_ZoekOpNaam.Text;
        var users = _userRepository.GetUserByFirstName(firstname) as IList<User>;

        aanwezighedenlijst.ItemsSource = users;

    }
    
    private void SaveAttendance_Click(object sender, RoutedEventArgs e)
    {

    }
    
    private void SaveProgress_Click(object sender, RoutedEventArgs e)
    {

    }
}