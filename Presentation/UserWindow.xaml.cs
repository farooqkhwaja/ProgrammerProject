using System.Security.Cryptography.X509Certificates;
using System.Windows;
using DataAccess.Dapper;
using DataAccess.Models;
using Logic;

namespace Presentation;

public partial class UserWindow : Window
{
    private readonly UserRepository _userRepository;
    private readonly User _user;
    private readonly LoginWindow _loginWindow;
    private readonly GeneratePartners _generatePartners;
    private readonly EventRepository _eventRepository;
    private readonly DanceFiguresRepository _danceFiguresRepository;
    public UserWindow(LoginWindow loginwindow)
    {
        InitializeComponent();
        _loginWindow = loginwindow;
        loginwindow.Visibility = Visibility.Collapsed;
        _user = new User();
        _userRepository = new UserRepository();
        _generatePartners = new GeneratePartners();
        _eventRepository = new EventRepository();
        _danceFiguresRepository = new DanceFiguresRepository();


        EvenementenLinks.ItemsSource = _eventRepository.GetEvents();
        CursistenLijstenView.ItemsSource = _userRepository.GetUsers();
        FigurenLijst.ItemsSource = _danceFiguresRepository.GetDanceFigures();
        comboBoxUsers.ItemsSource = _userRepository.GetFirstnames();
    }

    private void GeneratePartner_Click(object sender, RoutedEventArgs e)
    {
        var result = _generatePartners.GetRandomUser();

        tbx_PartnerNaam.Text = result.Firstname.ToString();
    }

    private void tbx_aansluitenBijEvent_Click(object sender, RoutedEventArgs e)
    {
        var events = EvenementenLinks.SelectedItem as Events;
        var result = comboBoxUsers.SelectedItem as User;
        if (string.IsNullOrEmpty(result.Firstname))
        {
            MessageBox.Show("Cannot add yourself to the event, it's already full");
            return;
        }
        _eventRepository.UpdateUserEvent(events.Id, events.UserId, result.Id);
        MessageBox.Show("You got succesfully added to the Event.");

    }
    private void progressCheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        bool progress = false;
        _danceFiguresRepository.UpdateProgress(progress);
    }
    private void progressCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        bool progress = true;
        _danceFiguresRepository.UpdateProgress(progress);
    }
    private void btn_SaveProgress_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Progress Saved Succesfully!");
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        _loginWindow.Close();
    }

}