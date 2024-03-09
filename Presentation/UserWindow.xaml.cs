using System.Windows;

namespace Presentation;

public partial class UserWindow : Window
{
    public UserWindow()
    {
        InitializeComponent();
    }
    private void OnLoginCompleted(object sender, EventArgs e)
    {
        // Hide the Login user control
        loginControl.Visibility = Visibility.Hidden;

        // Show the UserWindow tab control
        UserWindow.Visibility = Visibility.Visible;
    }
}