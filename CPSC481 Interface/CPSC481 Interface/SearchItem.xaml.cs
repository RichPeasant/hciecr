﻿using System;
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

namespace CPSC481_Interface {
    /// <summary>
    /// Interaction logic for SearchItem.xaml
    /// </summary>
    public partial class SearchItem : UserControl {

        private bool expanded;
        private Brush highlight, transparent, selected;
        private MainWindow window;
        public int numSections;

        public SearchItem(string Name, string DescriptionText, MainWindow Window) {
            InitializeComponent();

            numSections = 1;

            ClassName.Content = Name;
            Description.Text = DescriptionText;
            window = Window;

            expanded = false;
            transparent = Brushes.Transparent;
            highlight = new SolidColorBrush(Color.FromRgb(31, 117, 254));
            selected = new SolidColorBrush(Color.FromRgb(204, 204, 255));
        }

        public void SetExpanded(bool visible) {
            if (visible) {
                Background = selected;
                Sections.Visibility = Visibility.Visible;
                Description.Visibility = Visibility.Visible;
                if (Sections.Children.Count > 0) {
                    Dragging_Info.Visibility = Visibility.Visible;
                } else {
                    Dragging_Info.Visibility = Visibility.Hidden;
                }
                Course_title.Visibility = Visibility.Visible;
            } else {
                Background = transparent;
                Sections.Visibility = Visibility.Collapsed;
                Description.Visibility = Visibility.Collapsed;
                Dragging_Info.Visibility = Visibility.Collapsed;
                Course_title.Visibility = Visibility.Collapsed;
            }
            expanded = visible;
        }

        private void SetBackground(Brush b) {
            if (!expanded) {
                Background = b;
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e) {
            window.TryExpandSearchItem(this);
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e) {
            SetBackground(highlight);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e) {
            SetBackground(transparent);
        }
    }
}
