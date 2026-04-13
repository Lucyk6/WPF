// MainWindow.xaml.cs
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CipherApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Показываем значение сдвига при изменении слайдера
            sliderShift.ValueChanged += (s, e) => 
            {
                txtShiftValue.Text = $"Сдвиг: {(int)sliderShift.Value}";
            };
            
            // Показываем/скрываем настройки для разных шифров
            rbCezar.Checked += (s, e) => spCezar.Visibility = Visibility.Visible;
            rbAtbash.Checked += (s, e) => spCezar.Visibility = Visibility.Collapsed;
            rbReverse.Checked += (s, e) => spCezar.Visibility = Visibility.Collapsed;
        }

        // Кнопка "Зашифровать"
        private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Введите текст!", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string result = "";
            
            if (rbCezar.IsChecked == true)
                result = CezarCipher(txtInput.Text, (int)sliderShift.Value);
            else if (rbAtbash.IsChecked == true)
                result = AtbashCipher(txtInput.Text);
            else if (rbReverse.IsChecked == true)
                result = ReverseText(txtInput.Text);
            
            txtOutput.Text = result;
        }

        // Кнопка "Расшифровать"
        private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Введите текст!", "Ошибка", 
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string result = "";
            
            if (rbCezar.IsChecked == true)
                result = CezarDecrypt(txtInput.Text, (int)sliderShift.Value);
            else if (rbAtbash.IsChecked == true)
                result = AtbashCipher(txtInput.Text); // Атбаш одинаков для шифровки и расшифровки
            else if (rbReverse.IsChecked == true)
                result = ReverseText(txtInput.Text); // Переворот тоже одинаков
            
            txtOutput.Text = result;
        }

        // ШИФР 1: Цезаря (сдвиг букв)
        private string CezarCipher(string text, int shift)
        {
            string result = "";
            
            foreach (char c in text)
            {
                if (char.IsLetter(c)) // Если это буква
                {
                    char start = char.IsUpper(c) ? 'А' : 'а'; // Для русских букв
                    // Сдвигаем букву
                    char newChar = (char)(((c - start + shift) % 32) + start);
                    result += newChar;
                }
                else
                {
                    result += c; // Оставляем символы как есть
                }
            }
            
            return result;
        }

        // Расшифровка Цезаря
        private string CezarDecrypt(string text, int shift)
        {
            string result = "";
            
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char start = char.IsUpper(c) ? 'А' : 'а';
                    // Сдвигаем в обратную сторону
                    char newChar = (char)(((c - start - shift + 32) % 32) + start);
                    result += newChar;
                }
                else
                {
                    result += c;
                }
            }
            
            return result;
        }

        // ШИФР 2: Атбаш (А->Я, Б->Ю, В->Э...)
        private string AtbashCipher(string text)
        {
            string result = "";
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string alphabetReverse = "яюэьыъщшчцхфутсрпонмлкйизжёедгвба";
            
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    bool isUpper = char.IsUpper(c);
                    char lowerC = char.ToLower(c);
                    
                    int index = alphabet.IndexOf(lowerC);
                    if (index >= 0)
                    {
                        char newChar = alphabetReverse[index];
                        result += isUpper ? char.ToUpper(newChar) : newChar;
                    }
                    else
                    {
                        result += c;
                    }
                }
                else
                {
                    result += c;
                }
            }
            
            return result;
        }

        // ШИФР 3: Переворот текста
        private string ReverseText(string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
<!-- MainWindow.xaml -->
<Window x:Class="CipherApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Шифровальщик" Height="450" Width="500"
        WindowStartupLocation="CenterScreen">
    
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <!-- Заголовок -->
        <TextBlock Grid.Row="0" Text="🔐 Шифровка и дешифровка текста" 
                   FontSize="20" FontWeight="Bold" 
                   HorizontalAlignment="Center" Margin="0,0,0,20"/>

        <!-- Выбор шифра -->
        <GroupBox Grid.Row="1" Header="Выбери способ шифрования" Margin="0,5">
            <StackPanel Orientation="Horizontal" Margin="5">
                <RadioButton x:Name="rbCezar" Content="Шифр Цезаря" 
                             GroupName="Cipher" IsChecked="True" Margin="10"/>
                <RadioButton x:Name="rbAtbash" Content="Шифр Атбаш" 
                             GroupName="Cipher" Margin="10"/>
                <RadioButton x:Name="rbReverse" Content="Переворот текста" 
                             GroupName="Cipher" Margin="10"/>
            </StackPanel>
        </GroupBox>

        <!-- Настройки для шифра Цезаря -->
        <StackPanel x:Name="spCezar" Grid.Row="2" Margin="0,5" Visibility="Visible">
            <Label Content="Сдвиг (1-10):" Margin="0,5,0,0"/>
            <Slider x:Name="sliderShift" Minimum="1" Maximum="10" Value="3" 
                    TickFrequency="1" IsSnapToTickEnabled="True" Margin="5"/>
            <TextBlock x:Name="txtShiftValue" Text="Сдвиг: 3" Margin="5,0,5,5"/>
        </StackPanel>

        <!-- Текст для шифрования -->
        <GroupBox Grid.Row="3" Header="Введите текст" Margin="0,5">
            <TextBox x:Name="txtInput" Height="80" TextWrapping="Wrap" 
                     AcceptsReturn="True" FontSize="14"/>
        </GroupBox>

        <!-- Кнопки -->
        <StackPanel Grid.Row="4" Orientation="Horizontal" 
                    HorizontalAlignment="Center" Margin="0,10">
            <Button x:Name="btnEncrypt" Content="🔒 ЗАШИФРОВАТЬ" 
                    Width="150" Height="40" Margin="5" 
                    Click="BtnEncrypt_Click" Background="LightGreen"
                    FontWeight="Bold" FontSize="12"/>
            <Button x:Name="btnDecrypt" Content="🔓 РАСШИФРОВАТЬ" 
                    Width="150" Height="40" Margin="5" 
                    Click="BtnDecrypt_Click" Background="LightCoral"
                    FontWeight="Bold" FontSize="12"/>
        </StackPanel>

        <!-- Результат -->
        <GroupBox Grid.Row="5" Header="Результат" Margin="0,5">
            <TextBox x:Name="txtOutput" Height="80" TextWrapping="Wrap" 
                     IsReadOnly="True" Background="#F0F0F0" FontSize="14"/>
        </GroupBox>
    </Grid>
</Window>
