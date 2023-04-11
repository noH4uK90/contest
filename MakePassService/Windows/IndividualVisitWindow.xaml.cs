using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MakePassService.Methods;
using Persistence.Entities;

namespace MakePassService.Windows;

public partial class IndividualVisitWindow : Window
{
    private static readonly Dictionary<string, ImageFormat> ImageFormats = new()
    {
        { ".png", ImageFormat.Png },
        { ".jpeg", ImageFormat.Jpeg },
        { ".jpg", ImageFormat.Jpeg }
    };
    
    private byte[]? _photo;
    private byte[]? _passportScan;
    
    public IndividualVisitWindow()
    {
        InitializeComponent();
    }
    
    private async void IndividualVisitingWindow_OnLoadedAsync(object sender, RoutedEventArgs e)
    {
        var departments = await HttpMethods.HttpGetAsync<ICollection<Department>>("Department");
        var employees = await HttpMethods.HttpGetAsync<ICollection<Employee>>("Employee");

        DepartmentComboBox.ItemsSource = departments?.Select(x => x.Name).ToArray();
        FCsEmployeeComboBox.ItemsSource = employees?.Select(x => $"{x.MiddleName} {x.Name} {x.LastName}").ToArray();
        PurposeComboBox.ItemsSource = new[] { "Походить", "Посмотреть", "Пошпионить" };
    }

    private async void AddFileLabel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        try
        {
            var fileDialog = new OpenFileDialog()
            {
                Filter = "Pdf files|*.pdf;"
            };

            if (fileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            var fileName = fileDialog.FileName;
            _passportScan = await Documents.GetBytesPdf(fileName);
            if (_passportScan is null)
                Alert.ShowErrorMessage("Не удалось загрузить скан паспорта");
            else
                Alert.ShowInfoMessage("Скан паспорта успешно загружен");
        }
        catch (Exception ex)
        {
            Alert.ShowErrorMessage($"Произошла ошибка: {ex.Message}");
        }
    }

    private void ClearFormLabel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
    }


    private async void MakeRequestButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var startDate = StartDatePicker.SelectedDate;
            var endDate = EndDatePicker.SelectedDate ?? startDate?.AddDays(15);
            var purpose = PurposeComboBox.SelectedItem as string;
            var department = DepartmentComboBox.SelectedItem as string;
            var FCsEmployeer = FCsEmployeeComboBox.SelectedItem as string;
            var middleName = MiddleNameTextBox.Text;
            var firstName = FirstNameTextBox.Text;
            var lastName = LastNameTextBox.Text;
            var phone = PhoneTextBox.Text;
            var email = EmailTextBox.Text;
            var organization = OrganizationTextBox.Text;
            var note = NoteTextBox.Text;
            var birthday = BirthdayDatePicker.SelectedDate;
            var series = SeriesTextBox.Text;
            var number = NumberTextBox.Text;

            var departments = await HttpMethods.HttpGetAsync<ICollection<Department>>("Department");
            var employees = await HttpMethods.HttpGetAsync<ICollection<Employee>>("Employee");
            var employee = employees?.FirstOrDefault(x =>
                $"{x.MiddleName} {x.Name} {x.LastName}" == FCsEmployeer &&
                x.IdDepartment == departments?.FirstOrDefault(d => d.Name == department)?.IdDepartment);
            if (employee == null)
            {
                Alert.ShowErrorMessage("Указанного сотрудника не существует");
                return;
            }
            
            var visitInfo = new VisitInfo
            {
                StartDate = startDate.Value.Date,
                EndDate = endDate.Value.Date,
                Purpose = purpose
            };
            
            var newVisitInfo = await HttpMethods.HttpPostAsync("VisitInfo", visitInfo);

            var visit = new Visit
            {
                IdEmployee = employee.IdEmployee,
                Date = startDate.Value.Date,
                IdVisitInfo = newVisitInfo?.IdVisitInfo
            };
            var newVisit = await HttpMethods.HttpPostAsync("Visit", visit);

            var user = new User
            {
                MiddleName = middleName,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Email = email,
                Birthsday = birthday.Value.Date,
                PassportSeries = series,
                PassportNumber = number,
                Photo = _photo,
                PassportScan = _passportScan,
                Note = note,
                Organization = organization
            };
            var newUser = await HttpMethods.HttpPostAsync("User", user);

            var userVisit = new UserVisit
            {
                IdVisit = newVisit.IdVisit,
                IdUser = newUser.IdUser,
            };
            await HttpMethods.HttpPostAsync("UserVisit", userVisit);
        }
        catch (Exception ex)
        {
            Alert.ShowErrorMessage($"Произошла ошибка: {ex.Message}");
        }
    }

    private void AddPhotoButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var fileDialog = new OpenFileDialog()
            {
                Filter = "Image files|*.jpeg;*.jpg;*.png;"
            };

            if (fileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            var fileName = fileDialog.FileName;
            var extension = Path.GetExtension(fileName);
            if (!ImageFormats.TryGetValue(extension, out var extensionFormat)) return;
            _photo = Documents.GetBytesImage(fileName, extensionFormat);
            if (_photo is null)
                Alert.ShowErrorMessage("Не удалось загрузить фотографию");
            else
                Alert.ShowInfoMessage("Фотография успешно загружена");
            
        }
        catch (Exception ex)
        {
            Alert.ShowErrorMessage($"Произошла ошибка: {ex.Message}");
        }
    }

    private async void DepartmentComboBox_OnSelected(object sender, RoutedEventArgs e)
    {
        var employees = await HttpMethods.HttpGetAsync<ICollection<Employee>>("Employee");
        var departments = await HttpMethods.HttpGetAsync<ICollection<Department>>("Department");

        var departmentName = DepartmentComboBox.SelectedItem as string;
        var department = departments?.FirstOrDefault(x => x.Name == departmentName);
        FCsEmployeeComboBox.ItemsSource = employees?.Where(x => x.IdDepartment == department.IdDepartment)
            .Select(x => $"{x.MiddleName} {x.Name} {x.LastName}").ToArray();
    }
}