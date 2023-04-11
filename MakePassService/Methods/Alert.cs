using System.Windows;

namespace MakePassService.Methods;

public static class Alert
{
    public static void ShowErrorMessage(string message) =>
        MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

    public static void ShowInfoMessage(string message) =>
        MessageBox.Show(message, "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
}