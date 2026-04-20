<Window x:Class="Testing.WorkModul"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Testing"
        mc:Ignorable="d"
        Title="WorkModul" Height="450" Width="800" Closed="Window_Closed">
    <Grid>

        <Grid.ColumnDefinitions>
            <ColumnDefinition></ColumnDefinition>
            <ColumnDefinition Width="3*"></ColumnDefinition>
        </Grid.ColumnDefinitions>

        <Grid Grid.Column="0" Margin="5">

            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            
            <Button Name="btnUser1" Grid.Row="0" Content="Пользователь 1" VerticalContentAlignment="Center" HorizontalContentAlignment="Center" Margin="5" FontFamily="Times New Roman" FontSize="20" Click="btnUser1_Click"/>
            <Button Name="btnUser2" Grid.Row="1" Content="Пользователь 2" VerticalContentAlignment="Center" HorizontalContentAlignment="Center" Margin="5" FontFamily="Times New Roman" FontSize="20"></Button>
            <Button Name="btnUser3" Grid.Row="2" Content="Пользователь 3" VerticalContentAlignment="Center" HorizontalContentAlignment="Center" Margin="5" FontFamily="Times New Roman" FontSize="20"></Button>
            <Button Name="btnUser4" Grid.Row="3" Content="Пользователь 4" VerticalContentAlignment="Center" HorizontalContentAlignment="Center" Margin="5" FontFamily="Times New Roman" FontSize="20"></Button>
            
        </Grid>

        <Grid Grid.Column="1" Margin="5">

            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>

            <Label Name="txtUserName" Grid.Row="0" Content="Имя: " VerticalContentAlignment="Center" HorizontalContentAlignment="Left" Margin="5" FontFamily="Times New Roman" FontSize="26"></Label>
            <Label Name="txtUserGender" Grid.Row="1" Content="Пол: " VerticalContentAlignment="Center" HorizontalContentAlignment="Left" Margin="5" FontFamily="Times New Roman" FontSize="26"></Label>
            <Label Name="txtUserAge" Grid.Row="2" Content="Возраст: " VerticalContentAlignment="Center" HorizontalContentAlignment="Left" Margin="5" FontFamily="Times New Roman" FontSize="26"></Label>
            <Label Name="txtUserLogin" Grid.Row="3" Content="Логин: " VerticalContentAlignment="Center" HorizontalContentAlignment="Left" Margin="5" FontFamily="Times New Roman" FontSize="26"></Label>
            <Label Name="txtUserPassword" Grid.Row="4" Content="Пароль: " VerticalContentAlignment="Center" HorizontalContentAlignment="Left" Margin="5" FontFamily="Times New Roman" FontSize="26"></Label>
            
        </Grid>
        
    </Grid>
</Window>
////////////////////////////



<Window x:Class="Testing.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Testing"
        mc:Ignorable="d"
        Title="Testing" Height="600" Width="400" FontFamily="Times New Roman" FontSize="36" Closed="Window_Closed">
    <Grid>

        <Grid.RowDefinitions>
            <RowDefinition Height="0.5*"></RowDefinition>
            <RowDefinition></RowDefinition>
            <RowDefinition></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>

        <Label Grid.Row="0" HorizontalAlignment="Center" VerticalAlignment="Center">Авторизация</Label>
        <Label Grid.Row="1" Content="Логин" HorizontalContentAlignment="Center" Height="70" VerticalAlignment="Top" VerticalContentAlignment="Center"></Label>
        <TextBox Name="txtBoxLogin" Grid.Row="1" HorizontalAlignment="Center" VerticalAlignment="Top" Width="300" Margin="0,80,0,0" TextAlignment="Center"></TextBox>

        <Label Grid.Row="2" Content="Пароль" HorizontalContentAlignment="Center" Height="70" VerticalAlignment="Top" VerticalContentAlignment="Center"></Label>
        <TextBox Name="txtBoxPass" Grid.Row="2" HorizontalAlignment="Center" VerticalAlignment="Top" Width="300" Margin="0,80,0,0" TextAlignment="Center"></TextBox>

        <Button Name="btnEnter" Grid.Row="3" HorizontalAlignment="Center" VerticalAlignment="Center" Content="Вход" Click="btnEnter_Click"></Button>

    </Grid>
</Window>
////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Testing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private class Users
        {
            public string login;
            public string password;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WorkModul workModul = new WorkModul();
            workModul.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Testing
{
    public partial class MainWindow : Window
    {
        // Простой список пользователей
        private Dictionary<string, string> users = new Dictionary<string, string>()
        {
            { "user1", "123" },
            { "user2", "123" },
            { "user3", "123" },
            { "user4", "123" }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtBoxLogin.Text;
            string password = txtBoxPass.Text;

            // Проверка логина и пароля
            if (users.ContainsKey(login) && users[login] == password)
            {
                this.Hide();
                WorkModul workModul = new WorkModul(login);
                workModul.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Testing
{
    /// <summary>
    /// Логика взаимодействия для WorkModul.xaml
    /// </summary>
    public partial class WorkModul : Window
    {
        private List<User> usersList;
        private string currentUserLogin;

        // Класс пользователя (должен совпадать с классом в MainWindow)
        private class User
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
        }

        public WorkModul(List<User> users, string currentLogin)
        {
            InitializeComponent();
            usersList = users;
            currentUserLogin = currentLogin;
            
            // Привязка обработчиков для всех кнопок
            btnUser2.Click += btnUser_Click;
            btnUser3.Click += btnUser_Click;
            btnUser4.Click += btnUser_Click;
            
            // Автоматически показываем информацию о текущем пользователе
            DisplayUserInfo(currentUserLogin);
        }

        // Обработчик для всех кнопок пользователей
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string login = GetLoginFromButton(clickedButton.Content.ToString());
                DisplayUserInfo(login);
            }
        }

        // Обработчик для кнопки "Пользователь 1"
        private void btnUser1_Click(object sender, RoutedEventArgs e)
        {
            DisplayUserInfo("user1");
        }

        // Получение логина из текста кнопки
        private string GetLoginFromButton(string buttonText)
        {
            switch (buttonText)
            {
                case "Пользователь 1": return "user1";
                case "Пользователь 2": return "user2";
                case "Пользователь 3": return "user3";
                case "Пользователь 4": return "user4";
                default: return currentUserLogin;
            }
        }

        // Отображение информации о пользователе
        private void DisplayUserInfo(string login)
        {
            User user = usersList.FirstOrDefault(u => u.Login == login);
            
            if (user != null)
            {
                txtUserName.Content = $"Имя: {user.Name}";
                txtUserGender.Content = $"Пол: {user.Gender}";
                txtUserAge.Content = $"Возраст: {user.Age} лет";
                txtUserLogin.Content = $"Логин: {user.Login}";
                txtUserPassword.Content = $"Пароль: {user.Password}";
            }
            else
            {
                txtUserName.Content = "Имя: Не найдено";
                txtUserGender.Content = "Пол: Не найдено";
                txtUserAge.Content = "Возраст: Не найдено";
                txtUserLogin.Content = "Логин: Не найдено";
                txtUserPassword.Content = "Пароль: Не найдено";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}<Window x:Class="Testing.WorkModul"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Testing"
        mc:Ignorable="d"
        Title="Панель управления" Height="450" Width="800" Closed="Window_Closed">
    <Grid>

        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="1.5*"/>
            <ColumnDefinition Width="3*"/>
        </Grid.ColumnDefinitions>

        <Grid Grid.Column="0" Margin="5">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            
            <Button Name="btnUser1" Grid.Row="0" Content="Пользователь 1" 
                    VerticalContentAlignment="Center" HorizontalContentAlignment="Center" 
                    Margin="5" FontFamily="Times New Roman" FontSize="20" 
                    Click="btnUser1_Click"/>
            
            <Button Name="btnUser2" Grid.Row="1" Content="Пользователь 2" 
                    VerticalContentAlignment="Center" HorizontalContentAlignment="Center" 
                    Margin="5" FontFamily="Times New Roman" FontSize="20"/>
            
            <Button Name="btnUser3" Grid.Row="2" Content="Пользователь 3" 
                    VerticalContentAlignment="Center" HorizontalContentAlignment="Center" 
                    Margin="5" FontFamily="Times New Roman" FontSize="20"/>
            
            <Button Name="btnUser4" Grid.Row="3" Content="Пользователь 4" 
                    VerticalContentAlignment="Center" HorizontalContentAlignment="Center" 
                    Margin="5" FontFamily="Times New Roman" FontSize="20"/>
        </Grid>

        <Border Grid.Column="1" Margin="10" Background="#F0F0F0" CornerRadius="10" Padding="15">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="*"/>
                </Grid.RowDefinitions>

                <TextBlock Grid.Row="0" Text="Информация о пользователе" 
                           FontSize="28" FontWeight="Bold" FontFamily="Times New Roman"
                           HorizontalAlignment="Center" Margin="0,0,0,20"/>

                <Label Name="txtUserName" Grid.Row="1" Content="Имя: " 
                       VerticalContentAlignment="Center" HorizontalContentAlignment="Left" 
                       Margin="5" FontFamily="Times New Roman" FontSize="22"/>
                
                <Label Name="txtUserGender" Grid.Row="2" Content="Пол: " 
                       VerticalContentAlignment="Center" HorizontalContentAlignment="Left" 
                       Margin="5" FontFamily="Times New Roman" FontSize="22"/>
                
                <Label Name="txtUserAge" Grid.Row="3" Content="Возраст: " 
                       VerticalContentAlignment="Center" HorizontalContentAlignment="Left" 
                       Margin="5" FontFamily="Times New Roman" FontSize="22"/>
                
                <Label Name="txtUserLogin" Grid.Row="4" Content="Логин: " 
                       VerticalContentAlignment="Center" HorizontalContentAlignment="Left" 
                       Margin="5" FontFamily="Times New Roman" FontSize="22"/>
                
                <Label Name="txtUserPassword" Grid.Row="5" Content="Пароль: " 
                       VerticalContentAlignment="Center" HorizontalContentAlignment="Left" 
                       Margin="5" FontFamily="Times New Roman" FontSize="22"/>
            </Grid>
        </Border>
        
    </Grid>
</Window>
1. Завершить форму авторизации;
2. Доработать форму вывода информации о пользователях;
