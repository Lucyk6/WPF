<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <ComboBox HorizontalAlignment="Left" Margin="235,84,0,0" VerticalAlignment="Top" Width="120">
            <Button Content="AAAAAAA"/>
            <Label Content="bbbbbbb"/>
        </ComboBox>
        <RadioButton Content="Radio1" HorizontalAlignment="Left" Margin="425,0,0,0" VerticalAlignment="Center"/>
        <RadioButton Content="Radio2" HorizontalAlignment="Left" Margin="425,241,0,0" VerticalAlignment="Top"/>
        <Border BorderBrush="Black"
                BorderThickness="2"
                CornerRadius="5"
                Padding="5"
                Background="LightGray"
                Margin="556,60,22,80">
            <StackPanel Orientation="Vertical">
                <CheckBox Content="GIRL" Margin="5"/>
                <CheckBox Content="BOY" Margin="5"/>
                <CheckBox Content="WOMAN" Margin="5"/>
                <CheckBox Content="MAN" Margin="5"/>
                <CheckBox Content="FURRY" Margin="5"/>
                <CheckBox Content="DOG" Margin="5"/>
                <CheckBox Content="CAT" Margin="5"/>
                <CheckBox Content="HOTDOG" Margin="5"/>
                <CheckBox Content="HOTCAT" Margin="5"/>
                <CheckBox Content="HOTHORSE" Margin="5"/>
                <CheckBox Content="IT (BE CAREFULL! UR IN RUSSIA)" Margin="5"/>
            </StackPanel>
        </Border>
    </Grid>
</Window>
