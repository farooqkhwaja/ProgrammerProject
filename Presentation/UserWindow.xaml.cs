using System.Security.Cryptography.X509Certificates;
using System.Windows;
using DataAccess.Dapper;
using DataAccess.Models;

namespace Presentation;

public partial class UserWindow : Window
{
    private readonly UserRepository _userRepository;
    private readonly User _user;
    private readonly LoginWindow _loginWindow;
    private string _connectionString;
    public UserWindow(LoginWindow loginwindow)
    {
        InitializeComponent();
        _loginWindow = loginwindow;
        _user = new User();
        _connectionString = new string("Data Source=.;Initial Catalog=SalsaManagment2;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        _userRepository = new UserRepository(_connectionString);
    }

    private void GeneratePartner_Click(object sender, RoutedEventArgs e)
    {

        List<User> RandomUser()
        {
            var result = _userRepository.GetUsers();
            RandomUser.
        }
        _userRepository.GetUserByFirstName(tbx_PartnerNaam.Text);

    }

    private void tbx_aansluitenBijEvent_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_SaveProgress_Click(object sender, RoutedEventArgs e)
    {

    }
}