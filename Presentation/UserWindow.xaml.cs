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
    public UserWindow(LoginWindow loginwindow)
    {
        InitializeComponent();
        _loginWindow = loginwindow;
        _user = new User();
        _userRepository = new UserRepository();
        _generatePartners = new GeneratePartners();
    }

    private void GeneratePartner_Click(object sender, RoutedEventArgs e)
    {
        var result = _generatePartners.GetRandomUser();
        tbx_PartnerNaam.Text = result.ToString();
    }

    private void tbx_aansluitenBijEvent_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_SaveProgress_Click(object sender, RoutedEventArgs e)
    {

    }
}