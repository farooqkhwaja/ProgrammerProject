using DataAccess;
using DataAccess.Models;
using Logic;
using System.Windows;

namespace Presentation;

public partial class UserWindow : Window
{
    private readonly LoginWindow _loginWindow;
    private readonly UserRepository _userAccess;
    private readonly UploadDanceFiguresRepository _uploadDanceFiguresRepository;
    private readonly GeneratePartners _generatePartners;

    public UserWindow(LoginWindow loginwindow)
    {
        InitializeComponent();
        _loginWindow = loginwindow;
        loginwindow.Close();
        _generatePartners = new GeneratePartners();
        _userAccess = new UserRepository();
        _uploadDanceFiguresRepository = new UploadDanceFiguresRepository();
        CursistenLijst.ItemsSource = _userAccess.GetUsers();
        FigurenLijst.ItemsSource = _uploadDanceFiguresRepository.GetFigures();
 
    }
    private void genereepartner_Click(object sender, RoutedEventArgs e)
    {
        var randomUser = _generatePartners.GetRandomUser();
        PartnerNaamLijst.Text = randomUser.FirstName;
    }
    private void tbx_bewaarfiguren_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(tbx_bewaarfiguren.Text))
        {
            btn_bewaarfiguren.IsEnabled = false;
        }
        else
        {
            btn_bewaarfiguren.IsEnabled = true;
        }
    }
    private void bewaarfiguren_Click(object sender, RoutedEventArgs e)
    {
        
        var result = _uploadDanceFiguresRepository.AddDance(tbx_bewaarfiguren.Text);
        if(result == true)
        {
            FigurenLijst.ItemsSource = _uploadDanceFiguresRepository.GetFigures();
        }
        tbx_bewaarfiguren.Clear();
    }

    private void verzendemail_Click(object sender, RoutedEventArgs e)
    {

    }

   
}