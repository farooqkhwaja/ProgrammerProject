using System.Windows;
using Logic;
using DataAccess.Models;
using DataAccess.Dapper;

namespace Presentation;

public partial class ManagerWindow : Window
{
    private readonly AttendanceRepository _attendanceRepository;
    private readonly Attendance _attendance;
    private readonly DanceCategoryRepository _danceCategoryRepository;
    private readonly DanceCategory _danceCategory;
    private readonly Location _locations;
    private readonly LocationRepository _locationRepository;
    private readonly LinksRepository _linksRepository;
    private readonly UserRepository _userRepository;
    private readonly RegisterStudent _registerStudent;
    private readonly LoginWindow _loginWindow;
    private readonly EventRepository _eventRepository;
    private readonly DanceFiguresRepository _danceFiguresRepository;
    private readonly DanceFigures _danceFigures;
    
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
        _attendance = new Attendance();
        _attendanceRepository = new AttendanceRepository();
        _danceFiguresRepository = new DanceFiguresRepository();


        aanwezighedenlijst.ItemsSource = _userRepository.GetUsersWithForeignKeys();
        cbx_gemaaktdoor.ItemsSource = _userRepository.GetUsers();
        cbx_categories.ItemsSource = _danceCategoryRepository.GetdanceCategories();
        DansFilmLinksList.ItemsSource = _linksRepository.GetLinks(); 
        CursistenList.ItemsSource = _userRepository.GetUsersWithForeignKeys(); 
        EvenementenLinks.ItemsSource = _eventRepository.GetEvents();
        cbx_categorie.ItemsSource = _danceCategoryRepository.GetdanceCategories();
        cbx_categoriename.ItemsSource = _danceCategoryRepository.GetdanceCategories();
        cbx_locatie.ItemsSource = _locationRepository.GetLocations();
        FigurenAanmakenLijst.ItemsSource = _danceFiguresRepository.GetDanceFigures();
        cbx_AddDanceFigureCategorie.ItemsSource = _danceCategoryRepository.GetdanceCategories();
    }

    private void SubscribeUser_Click(object sender, RoutedEventArgs e)
    {
        var selectedCategory = cbx_categorie.SelectedItem as DanceCategory;

        if (selectedCategory == null)
        {
            MessageBox.Show("Please select a category first.", "No category Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        var msgResult = _registerStudent.RegisterUser(txtFirstname.Text, txtLastname.Text, txtsex.Text,tbx_password.Text, tbx_Username.Text, tbx_email.Text, selectedCategory.Id);
        
        MessageBox.Show(msgResult);

        var users = _userRepository.GetUsers();
        CursistenList.ItemsSource = users;
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
        Events _event = new Events();

        var selectedLocation = cbx_locatie.SelectedItem as Location;
        var selectedCategory = cbx_categoriename.SelectedItem as DanceCategory;

        if (selectedLocation == null)
        {
            MessageBox.Show("Please select a location first.", "No location Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        if (selectedCategory == null)
        {
            MessageBox.Show("Please select a category first.", "No category Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        _event.Name = tbx_EvenementenToevoegenBox.Text;
        _event.Date = tbx_EvenementDatum.Text;
        _event.DanceCategoryId = selectedCategory.Id;
        _event.LocationId = selectedLocation.Id;

        _eventRepository.SaveEvent(_event);
       

    }
    private void EvenementenLinks_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {

        var selectedEvent = EvenementenLinks.SelectedItem as Events;

        if (selectedEvent == null)
        {
            MessageBox.Show("Please select an event first.", "No event Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        var result = _userRepository.GetUserWithEvents(selectedEvent.Id);

        AssignedStudentsOnEvent.ItemsSource = result;
    }
    private void UpdateEvent_Click(object sender, RoutedEventArgs e)
    {
        EvenementenLinks.ItemsSource = _eventRepository.GetEvents();
    }
    
    private void DeleteEvent_Click(object sender, RoutedEventArgs e)
    {
        if (_eventRepository != null)
        {
            var selectedevent = EvenementenLinks.SelectedItem as Events;

            if (selectedevent == null)
            {
                MessageBox.Show("Please select an event first.", "No event Selected", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _eventRepository.DeleteEvent(selectedevent.Id);
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

        var selectedCategory = cbx_categories.SelectedItem as DanceCategory; // Foriegn keys moet je casten en wij hebben altijd de id van foriegn key table nodig
        var selectedUser = cbx_gemaaktdoor.SelectedItem as User;

        if (selectedCategory == null)
        {
            MessageBox.Show("Please select a category first.", "No cateogory Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        if (selectedUser == null)
        {
            MessageBox.Show("Please select a user first.", "No user Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        if (!string.IsNullOrWhiteSpace(figureName))
        {
            Links newLink = new Links
            {
                Name = figureName,
                url = linkadres,
                CreatedBy = selectedUser.Id,
                DanceCategoryId = selectedCategory.Id
            };
            
            _linksRepository.CreateLink(newLink);
        }
    }
    
    private void DeleteDanceLink_Click(object sender, RoutedEventArgs e)
    {
        if (DansFilmLinksList.SelectedItem is Links)
        {
            var selecteddance = DansFilmLinksList.SelectedItem as Links;

            if (selecteddance == null)
            {
                MessageBox.Show("Please select a dance first.", "No dance Selected", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _linksRepository.DeleteLink(selecteddance.Id);
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
    
   
    private void aanwezighedenlijst_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        var selecteduser = aanwezighedenlijst.SelectedItem as User;
        var result = _attendanceRepository.GetAttendanceByUserId(selecteduser.Id);

        DatumAanwezigheid.ItemsSource = result;
    }
    private void SaveAttendance_Click(object sender, RoutedEventArgs e)
    {
        var selectedUser = aanwezighedenlijst.SelectedItem as User;
        var selectedAttendanceDate = tbx_SelecteerDatum.SelectedDate;

        if (selectedUser == null)
        {
            MessageBox.Show("Please select a user first.", "No user Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        if (selectedAttendanceDate == null)
        {
            MessageBox.Show("Please select a date first.", "No date Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        Attendance attendance = new Attendance()
        {
            Date = selectedAttendanceDate,
            UserId = selectedUser.Id,
        };

        _attendanceRepository.AddAttendance(attendance);
    }
    private void UpdateAttendance(object sender, RoutedEventArgs e)

    {
        var selecteduser = aanwezighedenlijst.SelectedItem as User;

        if (selecteduser == null)
        {
            MessageBox.Show("Please select a user first.", "No user Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var result = _attendanceRepository.GetAttendanceByUserId(selecteduser.Id);

        DatumAanwezigheid.ItemsSource = result;
    }

    private void SaveFiguur_Click(object sender, RoutedEventArgs e)
    {
        string figuurName = tbx_AddDanceFigureName.Text;

        if (string.IsNullOrWhiteSpace(figuurName))
        {
            MessageBox.Show("Please enter a valid dance figure name.", "No valid figure name", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        DanceFigures _danceFigures = new DanceFigures();

        var selectedCategorie = cbx_AddDanceFigureCategorie.SelectedItem as DanceCategory;

        _danceFigures.FigureName = figuurName;
        _danceFigures.CategoryId = Convert.ToInt32(selectedCategorie.Id);

        _danceFiguresRepository.AddDanceFigures(_danceFigures);

        MessageBox.Show("Figure succesfully added");

        FigurenAanmakenLijst.ItemsSource = _danceFiguresRepository.GetDanceFigures();
    }
    private void Window_Closed(object sender, EventArgs e)
    {
        _loginWindow.Close();
    }

    private void CopyUrl_Click(object sender, RoutedEventArgs e)
    {
        var selectedLink = DansFilmLinksList.SelectedItem as Links;
        if (selectedLink != null)
        {
            string url = selectedLink.url;

            Clipboard.SetText(url);
        }
    }
}
