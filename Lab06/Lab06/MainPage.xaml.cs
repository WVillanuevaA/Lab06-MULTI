using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab06
{
    public partial class MainPage : ContentPage
    {
        private List<Alumno> nameItems;

        public MainPage()
        {
            InitializeComponent();

            nameItems = new List<Alumno>
            {
                new Alumno { Name = "Eduardo", IsExpanded = false },
                new Alumno { Name = "Bryan", IsExpanded = false },
                new Alumno { Name = "Johan", IsExpanded = false }
            };

            foreach (var nameItem in nameItems)
            {
                var viewCell = new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children =
                        {
                            new Label { Text = nameItem.Name },
                            new ContentView
                            {
                                Content = new StackLayout
                                {
                                    Children =
                                    {
                                        new Label { Text = "Detalles 1" },
                                        new Label { Text = "Detalles 2" }
                                    },
                                    IsVisible = nameItem.IsExpanded
                                }
                            }
                        }
                    }
                };

                viewCell.Tapped += (sender, e) =>
                {
                    nameItem.IsExpanded = !nameItem.IsExpanded;
                    ((StackLayout)((ContentView)viewCell.View).Content).IsVisible = nameItem.IsExpanded;
                };

                nameTableView.Root[0].Add(viewCell);
            }
        }
    }
}
