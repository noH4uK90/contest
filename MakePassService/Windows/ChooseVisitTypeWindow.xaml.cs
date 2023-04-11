using System.Windows;

namespace MakePassService.Windows;

public partial class ChooseVisitTypeWindow : Window
{
    public ChooseVisitTypeWindow()
    {
        InitializeComponent();
    }
    
    private void ToIndividualVisitButton_OnClick(object sender, RoutedEventArgs e)
    {
        var individualVisitingWindow = new IndividualVisitWindow();
        individualVisitingWindow.Show();
        Close();
    }

    private void ToGroupVisitButton_OnClick(object sender, RoutedEventArgs e)
    {
        var groupVisitingWindow = new GroupedVisitWindow();
        groupVisitingWindow.Show();
        Close();
    }
}