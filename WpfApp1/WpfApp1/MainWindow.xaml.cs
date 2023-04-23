using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, Dictionary<string, List<string>>> subjectObject; // Наши данные
        public MainWindow()
        {
            InitializeComponent();
            InitializeData(); // Вызов метода инициализации данными
            PopulateComboBoxes(); // вызов метода автоматической инициализация Городов
        }
        // Метод инициализации данными
        private void InitializeData()
        {
            subjectObject = new Dictionary<string, Dictionary<string, List<string>>>
            {
                {
                    "Moscow", new Dictionary<string, List<string>>
                    {
                        {"Workshop Moscow 1", new List<string> {"Employee 1 Msc", "Employee 2 Msc", "Employee 3 Msc", "Employee 4 Msc","Employee 5 Msc"}},
                        {"Workshop Moscow 2", new List<string> {"Employee 6 Mcs", "Employee 7 Msc", "Employee 8 Msc", "Employee 9 Msc","Employee 10 Msc"}},
                        {"Workshop Moscow 3", new List<string> {"Employee 11 Msc", "Employee 12 Msc", "Employee 13 Msc", "Employee 14 Msc","Employee 15 Msc"}},
                        {"Workshop Moscow 4", new List<string> {"Employee 16 Msc", "Employee 17 Msc", "Employee 18 Msc", "Employee 19 Msc","Employee 20 Msc"}}
                    }
                },
                {
                    "Sankt-Peterburg", new Dictionary<string, List<string>>
                    {
                        {"Workshop Piter 1", new List<string> {"Employee 1 Spb", "Employee 2 Spb", "Employee 3 Spb", "Employee 4 Spb","Employee 5 Spb"}},
                        {"Workshop Piter 2", new List<string> {"Employee 6 Spb", "Employee 7 Spb", "Employee 8 Spb", "Employee 9 Spb","Employee 10 Spb"}},
                        {"Workshop Piter 3", new List<string> {"Employee 11 Spb", "Employee 12 Spb", "Employee 13 Spb", "Employee 14 Spb","Employee 15 Spb"}},
                        {"Workshop Piter 4", new List<string> {"Employee 16 Spb", "Employee 17 Spb", "Employee 18 Spb", "Employee 19 Spb","Employee 20 Spb"}}
                    }
                },
                {
                    "Ekaterinburg", new Dictionary<string, List<string>>
                    {
                        { "Workshop Ekb 1", new List<string> {"Employee 1 Ekb", "Employee 2 Ekb", "Employee 3 Ekb", "Employee 4 Ekb","Employee 5 Ekb"}},
                        { "Workshop Ekb 2", new List<string> {"Employee 6 Ekb", "Employee 7 Ekb", "Employee 8 Ekb", "Employee 9 Ekb", "Employee 10 Ekb"}},
                        { "Workshop Ekb 3", new List<string> {"Employee 11 Ekb", "Employee 12 Ekb", "Employee 13 Ekb", "Employee 14 Ekb", "Employee 15 Ekb"}},
                        { "Workshop Ekb 4", new List<string> {"Employee 16 Ekb", "Employee 17 Ekb", "Employee 18 Ekb", "Employee 19 Ekb","Employee 20 Ekb"}}
                    }
                },
                {
                    "Samara", new Dictionary<string, List<string>>
                    {
                        { "Workshop Sma 1", new List<string> {"Employee 1 Sma", "Employee 2 Sma", "Employee 3 Sma", "Employee 4 Sma","Employee 5 Sma"}},
                        { "Workshop Sma 2", new List<string> {"Employee 6 Sma", "Employee 7 Sma", "Employee 8 Sma", "Employee 9 Sma","Employee 10 Sma"}},
                        { "Workshop Sma 3", new List<string> {"Employee 11 Sma", "Employee 12 Sma", "Employee 13 Sma", "Employee 14 Sma","Employee 15 Sma"}},
                        { "Workshop Sma 4", new List<string> {"Employee 16 Sma", "Employee 17 Sma", "Employee 18 Sma", "Employee 19 Sma","Employee 20 Sma"}}
                    }
                },
                {
                    "Krasnodar", new Dictionary<string, List<string>>
                    {
                        { "Workshop Krsndr 1", new List<string> {"Employee 1 Krsndr", "Employee 2 Krsndr", "Employee 3 Krsndr", "Employee 4 Krsndr", "Employee 5 Krsndr"}},
                        { "Workshop Krsndr 2", new List<string> {"Employee 6 Krsndr", "Employee 7 Krsndr", "Employee 8 Krsndr", "Employee 9 Krsndr","Employee 10 Krsndr"}},
                        { "Workshop Krsndr 3", new List<string> {"Employee 11 Krsndr", "Employee 12 Krsndr", "Employee 13 Krsndr", "Employee 14 Krsndr","Employee 15 Krsndr"}},
                        { "Workshop Krsndr 4", new List<string> {"Employee 16 Krsndr", "Employee 17 Krsndr", "Employee 18 Krsndr", "Employee 19 Krsndr","Employee 20 Krsndr"}}
                    }
                }
            };
            // Автоматическая инициализация Бригад
            List<string> brigades = new List<string> { "Brigade 1", "Brigade 2", "Brigade 3", "Brigade 4", "Brigade 5" };
            BrigadeComboBox.ItemsSource = brigades;
        }
        // Автоматическая инициализация Городов
        private void PopulateComboBoxes()
        {
            CityComboBox.ItemsSource = subjectObject.Keys;
        }
        // Метод изменения списка Цехов при выборе в списке Города
        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityComboBox.SelectedItem != null)
            {
                string selectedCity = CityComboBox.SelectedItem.ToString();
                WorkshopComboBox.ItemsSource = subjectObject[selectedCity].Keys;
                EmployeeComboBox.ItemsSource = null;
            }
        }
        // Метод изменения списка Сотрудников при выборе в списке Цеха
        private void WorkshopComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WorkshopComboBox.SelectedItem != null && CityComboBox.SelectedItem != null)
            {
                string selectedCity = CityComboBox.SelectedItem.ToString();
                string selectedWorkshop = WorkshopComboBox.SelectedItem.ToString();
                EmployeeComboBox.ItemsSource = subjectObject[selectedCity][selectedWorkshop];
            }
        }
    }
}