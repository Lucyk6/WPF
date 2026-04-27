using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using static WPF25_1.Persons;

namespace WPF25_1
{
    public partial class WorkWind : Window
    {
        private User currentUser;
        private WorkSession currentSession;
        private DispatcherTimer timer;
        private List<WorkSession> userSessions = new List<WorkSession>();

        public WorkWind()
        {
            InitializeComponent();
            InitializeTimer();

        }
        private void LoadSessions()
        {
          
            SessionsDataGrid.ItemsSource = null;
            SessionsDataGrid.ItemsSource = userSessions;
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentSession != null && currentSession.EndTime == null)
            {
                var elapsed = DateTime.Now - currentSession.StartTime;
                CurrentTimeText.Text = $"Текущее время работы: {elapsed:hh\\:mm\\:ss}";
            }
        }

        private void goAutoris_Click(object sender, RoutedEventArgs e)
        {
            string username = lbUserName.Content.ToString();

            if (!string.IsNullOrEmpty(username))
            {
                currentUser = new User { Username = username, Id = 1 };
                WelcomeText.Text = $"Добро пожаловать, {currentUser.Username}!";
                StartWorkButton.IsEnabled = true;
                EndWorkButton.IsEnabled = false;
                LoadSessions();
            }
            else
            {
                MessageBox.Show("Введите имя пользователя");
            }
        }

        private void StartWorkButton_Click(object sender, RoutedEventArgs e)
        {
            currentSession = new WorkSession
            {
                UserId = currentUser.Id,
                StartTime = DateTime.Now
            };

            StartWorkButton.IsEnabled = false;
            EndWorkButton.IsEnabled = true;
            timer.Start();
            CurrentTimeText.Visibility = Visibility.Visible;
            TotalTimeText.Text = "Сессия начата";
        }
      
        private void showPgRaschetZP(object sender, RoutedEventArgs e)
        {
         
        }

    
        private void showPgOtchets(object sender, RoutedEventArgs e)
        {
          
        }

        private void EndWorkButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (currentSession != null)
            {
                currentSession.EndTime = DateTime.Now;
                timer.Stop();
                StartWorkButton.IsEnabled = true;
                EndWorkButton.IsEnabled = false;
            
            }
        }

    }


}
//users.cs
using System;

public class WorkSession
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public TimeSpan? TotalTime => EndTime.HasValue ? EndTime.Value - StartTime : (TimeSpan?)null;

    public string DisplayTotalTime => TotalTime?.ToString(@"hh\:mm\:ss") ?? "В процессе";
}
//WorkSession


<Window x:Class="WPF25_1.WorkWind"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WPF25_1"
        mc:Ignorable="d"
        Title="WorkWind" Height="500" Width="900" WindowStyle="None">

    <Window.Resources>
      
             <Style TargetType="Grid">
                <Setter Property="Background" Value="DarkSlateGray"/>
                </Style>
             <Style TargetType="Label">
                    <Setter Property="FontSize" Value="24"/>
                    <Setter Property="FontFamily" Value="Times New Roman"/>
                    <Setter Property="Foreground" Value="Wheat"/>
             </Style>

                <Style TargetType="Button">
                    <Setter Property="FontFamily" Value="Times New Roman"/>
                    <Setter Property="HorizontalAlignment" Value="Center"/>
                    <Setter Property="VerticalAlignment" Value="Top"/>
                    <Setter Property="FontSize" Value="28"/>
                    <Setter Property="Padding" Value="5"/>
                </Style>
         </Window.Resources>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>

        <Grid Grid.Row="0" Grid.ColumnSpan="2">
            <Label Name="lbUserName" Content="Имя пользователя" VerticalAlignment="Center" HorizontalAlignment="Left" Margin="10, 0, 0, 0"/>
            <Button Name="btnGoAutoris" Click="goAutoris_Click" Width="40" Height="40" VerticalAlignment="Center" HorizontalAlignment="Right" Margin="0, 0, 10, 0" BorderBrush="{x:Null}" Foreground="{x:Null}">
                <Button.Background>
                    <ImageBrush ImageSource="/illustration-neon-green-sign-circle-radiation-light-background-line-darkness-symbol-number-computer-wallpaper-font-604544.jpg" Stretch="UniformToFill"/>
                </Button.Background>
            </Button>
        </Grid>


        <Grid Grid.Row="1" Grid.Column="0">
            <Button Name="btnOne" Click="showPgRaschetZP" Content="1" Margin="0, 10, 0, 0"/>
            <Button Name="btnTwo" Click="showPgOtchets" Content="2" Margin="0, 60, 0, 0"/>
            <Button Name="btnThree" Content="3" Margin="0, 110, 0, 0"/>
            <Button Name="btnFour" Content="4" Margin="0, 160, 0, 0"/>
        </Grid>


        <Grid Grid.Row="1" Grid.Column="1" Background="White">
            <StackPanel Margin="20">
                <TextBlock Name="WelcomeText" FontSize="18" FontWeight="Bold" Foreground="DarkGreen" Margin="0,0,0,20"/>

                <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,0,0,20">
                    <Button Name="StartWorkButton" Content="Начать" Click="StartWorkButton_Click" Width="180" Height="50" Margin="0,0,20,0"/>
                    <Button Name="EndWorkButton" Content="Завершить" Click="EndWorkButton_Click" Width="180" Height="50"/>
                </StackPanel>

                <TextBlock Name="CurrentTimeText" FontSize="18" HorizontalAlignment="Center" Margin="0,0,0,10"/>
                <TextBlock Name="TotalTimeText" FontSize="20" FontWeight="Bold" HorizontalAlignment="Center" Foreground="Blue"/>

                <DataGrid Name="SessionsDataGrid" AutoGenerateColumns="False" Margin="0,20,0,0">
                    <DataGrid.Columns>
                        <DataGridTextColumn Header="Дата" Binding="{Binding StartTime, StringFormat=dd.MM.yyyy}" Width="100"/>
                        <DataGridTextColumn Header="Начало" Binding="{Binding StartTime, StringFormat=HH:mm}" Width="80"/>
                        <DataGridTextColumn Header="Конец" Binding="{Binding EndTime, StringFormat=HH:mm}" Width="80"/>
                        <DataGridTextColumn Header="Общее время" Binding="{Binding DisplayTotalTime}" Width="120"/>
                    </DataGrid.Columns>
                </DataGrid>
            </StackPanel>
        </Grid>
    </Grid>
</Window>
//xaml

