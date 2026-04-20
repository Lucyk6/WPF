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
1. Завершить форму авторизации;
2. Доработать форму вывода информации о пользователях;
