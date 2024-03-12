using System.Windows;
using Logic;

namespace Presentation;

public partial class ManagerWindow : Window
{
    public ManagerWindow()
    {
        InitializeComponent();
    }

    private void addDanceMove_Click(object sender, RoutedEventArgs e)
    {             
        
    }

    private void DeleteDanceMove_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddEvent_Click(object sender, RoutedEventArgs e)
    {

    }

    private void UpdateEvent_Click(object sender, RoutedEventArgs e)
    {

    }

    private void DeleteEvent_Click(object sender, RoutedEventArgs e)
    {

    }

    private void CursistenList_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {

    }

    private void Window_Closed(object sender, EventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();     
        loginWindow.Show();               
    }
    private void Cursisten_lijst_updaten_Click(object sender, RoutedEventArgs e)
    {

    }

    private void inschrijven_cursist_Click(object sender, RoutedEventArgs e)
    {

    }
}