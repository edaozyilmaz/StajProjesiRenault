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
using System.Windows.Shapes;

namespace Akış
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        internal Boolean close;
        public Window1()
        {
            InitializeComponent();

            ExcelData excelData = new ExcelData();
            //this.paths.DataContext = excelData;

            if(((MainWindow)System.Windows.Application.Current.MainWindow).rowCount == 0)
            {
                close = true;
            }

            else if (((MainWindow)System.Windows.Application.Current.MainWindow).rowCount >= 1)
            {
                this.DataContext = excelData.Data.Table;

                //    if (rowCount > 1) //more than one record
                //    {
                //        this.Height = 645;

                //        //create groupBox
                //        GroupBox groupBox2 = new GroupBox();
                //        Grid grid2 = new Grid();
                //        groupBox2.Header = "Akış";
                //        groupBox2.FontFamily = new FontFamily("Global Sans Serif");
                //        groupBox2.FontWeight = FontWeights.SemiBold;
                //        groupBox2.FontSize = 13;
                //        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, 234, 230, 162));
                //        SolidColorBrush brush2 = new SolidColorBrush(Color.FromArgb(255, 87, 99, 106));
                //        groupBox2.Background = brush;
                //        groupBox2.BorderBrush = brush2;
                //        groupBox2.Height = 198;
                //        groupBox2.Margin = new Thickness(50, 310, 0, 0);
                //        groupBox2.HorizontalAlignment = HorizontalAlignment.Left;
                //        groupBox2.VerticalAlignment = VerticalAlignment.Top;
                //        groupBox2.Width = 589;
                //        grid2.Height = 198;
                //        grid2.Width = 589;
                //        grid2.Margin = new Thickness(50, 310, 0, 0);

                //        //get tool name
                //        Label newLabel5 = new Label();
                //        newLabel5.Name = "tool";
                //        newLabel5.Margin = new Thickness(-410, 105, 0, 0);
                //        newLabel5.Height = 29;
                //        newLabel5.Width = 96;
                //        newLabel5.FontFamily = new FontFamily("Global Sans Serif");

                //        var binding5 = new Binding("Rows[1][0]");
                //        binding5.Source = excelData.Data.Table;
                //        newLabel5.SetBinding(Label.ContentProperty, binding5);

                //        newLabel5.Content = "Parça Adı: " + newLabel5.Content.ToString();

                //        //get country name
                //        Label newLabel = new Label();
                //        newLabel.Name = "country";
                //        newLabel.Margin = new Thickness(-220, 350, 0, 0);
                //        newLabel.Height = 29;
                //        newLabel.Width = 96;
                //        newLabel.FontFamily = new FontFamily("Global Sans Serif");

                //        var binding = new Binding("Rows[1][1]");
                //        binding.Source = excelData.Data.Table;
                //        newLabel.SetBinding(Label.ContentProperty, binding);

                //        //get flux data
                //        Label newLabel1 = new Label();
                //        newLabel1.Name = "flux";
                //        newLabel1.Margin = new Thickness(60, 367, 0, 0);
                //        newLabel1.Height = 29;
                //        newLabel1.Width = 96;
                //        newLabel1.FontFamily = new FontFamily("Global Sans Serif");

                //        var binding1 = new Binding("Rows[1][2]");
                //        binding1.Source = excelData.Data.Table;
                //        newLabel1.SetBinding(Label.ContentProperty, binding1);

                //        //get company name
                //        Label newLabel2 = new Label();
                //        newLabel2.Name = "companyName";
                //        newLabel2.Margin = new Thickness(-220, 275, 0, 0);
                //        newLabel2.Height = 29;
                //        newLabel2.Width = 96;
                //        newLabel2.FontFamily = new FontFamily("Global Sans Serif");

                //        var binding2 = new Binding("Rows[1][4]");
                //        binding2.Source = excelData.Data.Table;
                //        newLabel2.SetBinding(Label.ContentProperty, binding2);

                //        //get dayNumber
                //        Label newLabel3 = new Label();
                //        newLabel3.Name = "dayNumber";
                //        newLabel3.Margin = new Thickness(70, 520, 0, 0);
                //        newLabel3.Height = 29;
                //        newLabel3.Width = 300;
                //        newLabel3.FontFamily = new FontFamily("Global Sans Serif");

                //        var binding3 = new Binding("Rows[1][3]");
                //        binding3.Source = excelData.Data.Table;
                //        newLabel3.SetBinding(Label.ContentProperty, binding3);
                //        newLabel3.Content = "Tahmini varış süresi: " + newLabel3.Content.ToString();

                //        //truck image
                //        Image image1 = new Image();
                //        image1.Source = new BitmapImage(new Uri("C:/Users/ege/source/repos/Flux/Flux/delivery-truck.png"));
                //        image1.Margin = new Thickness(-10, 200, 0, 0);
                //        image1.Height = 48;
                //        image1.Width = 66;

                //        //arrow image
                //        Image image2 = new Image();
                //        image2.Source = new BitmapImage(new Uri("C:/Users/ege/source/repos/Flux/Flux/iconfinder_next_308956.png"));
                //        image2.Margin = new Thickness(-110, 280, 0, 0);
                //        image2.Height = 44;
                //        image2.Width = 44;

                //        Image image3 = new Image();
                //        image3.Source = new BitmapImage(new Uri("C:/Users/ege/source/repos/Flux/Flux/iconfinder_next_308956.png"));
                //        image3.Margin = new Thickness(-65, 280, 0, 0);
                //        image3.Height = 44;
                //        image3.Width = 44;

                //        Image image4 = new Image();
                //        image4.Source = new BitmapImage(new Uri("C:/Users/ege/source/repos/Flux/Flux/iconfinder_next_308956.png"));
                //        image4.Margin = new Thickness(-20, 280, 0, 0);
                //        image4.Height = 44;
                //        image4.Width = 44;

                //        Image image5 = new Image();
                //        image5.Source = new BitmapImage(new Uri("C:/Users/ege/source/repos/Flux/Flux/iconfinder_next_308956.png"));
                //        image5.Margin = new Thickness(25, 280, 0, 0);
                //        image5.Height = 44;
                //        image5.Width = 44;

                //        Image image6 = new Image();
                //        image6.Source = new BitmapImage(new Uri("C:/Users/ege/source/repos/Flux/Flux/iconfinder_next_308956.png"));
                //        image6.Margin = new Thickness(70, 280, 0, 0);
                //        image6.Height = 44;
                //        image6.Width = 44;

                //        Image image7 = new Image();
                //        image7.Source = new BitmapImage(new Uri("C:/Users/ege/source/repos/Flux/Flux/iconfinder_next_308956.png"));
                //        image7.Margin = new Thickness(115, 280, 0, 0);
                //        image7.Height = 44;
                //        image7.Width = 44;

                //        Image image8 = new Image();
                //        image8.Source = new BitmapImage(new Uri("C:/Users/ege/source/repos/Flux/Flux/iconfinder_next_308956.png"));
                //        image8.Margin = new Thickness(160, 280, 0, 0);
                //        image8.Height = 44;
                //        image8.Width = 44;

                //        Label newLabel4 = new Label();
                //        newLabel4.Name = "OyakRenault";
                //        newLabel4.Margin = new Thickness(315, 280, 0, 0);
                //        newLabel4.Height = 29;
                //        newLabel4.Width = 96;
                //        newLabel4.FontFamily = new FontFamily("Global Sans Serif");
                //        newLabel4.Content = "Oyak-Renault";

                //        //change flux button
                //        Button button = new Button();
                //        button.Content = "Akışı Düzenle";
                //        button.FontFamily = new FontFamily("Global Sans Serif");
                //        button.Click += changeFluxButton;
                //        button.Margin = new Thickness(450, 520, 0, 0);
                //        button.Height = 29;
                //        button.Width = 96;

                //        this.myGrid.Children.Add(groupBox2);
                //        this.myGrid.Children.Add(grid2);
                //        this.myGrid.Children.Add(newLabel);
                //        this.myGrid.Children.Add(newLabel1);
                //        this.myGrid.Children.Add(newLabel2);
                //        this.myGrid.Children.Add(newLabel3);
                //        this.myGrid.Children.Add(image1);
                //        this.myGrid.Children.Add(image2);
                //        this.myGrid.Children.Add(image3);
                //        this.myGrid.Children.Add(image4);
                //        this.myGrid.Children.Add(image5);
                //        this.myGrid.Children.Add(image6);
                //        this.myGrid.Children.Add(image7);
                //        this.myGrid.Children.Add(image8);
                //        this.myGrid.Children.Add(newLabel4);
                //        this.myGrid.Children.Add(button);
                //        this.myGrid.Children.Add(newLabel5);
                //    }
                //this.DataContext = this;
            }
        }
        

        private void WindowLoaded(Object sender, RoutedEventArgs e)
        {
        }

        private void changeFluxButton(Object sender, RoutedEventArgs e)
        {
            Flux newFlux = new Flux();
            newFlux.Show();
        }

    }
}
