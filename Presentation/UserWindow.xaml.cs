using System.Windows;
using DataAccess.ADO;

namespace Presentation;

public partial class UserWindow : Window
{
    private readonly UserRepository _userRepository;
    private readonly LoginWindow _loginWindow;
    public UserWindow(LoginWindow loginwindow)
    {
        InitializeComponent();
        _loginWindow = loginwindow;
        _userRepository = new UserRepository();



    }

    private void GeneratePartner_Click(object sender, RoutedEventArgs e)
    {
        _userRepository.GetUserByFirstName(tbx_PartnerNaam.Text);

    }

    private void tbx_aansluitenBijEvent_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_SaveProgress_Click(object sender, RoutedEventArgs e)
    {

    }
}