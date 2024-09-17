using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoYourTask_Reloaded
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            add_button.Click += addTask;
            remove_button.Click += deleteTask;

            String app_directory = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            String file_name = "save.json";
            bool fileExists = File.Exists(file_name);
            if (!fileExists) {
                string messageBoxText = "Save file not found, would you like to create a new one ?";
                string caption = "Save File Not Found";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        File.Create(System.IO.Path.Combine(app_directory, file_name));
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                }
            }
        }

        private void addTask(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(task_name_textbox.Text)) { 
                String task_name = task_name_textbox.Text;
                tasks_list.Items.Add(task_name);
            } else {
                MessageBox.Show("You need to enter a valid task name!",
                    "Invalid Input",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void deleteTask(object sender, RoutedEventArgs e) 
        {
            if (tasks_list.SelectedIndex != -1)
            {
                tasks_list.Items.RemoveAt(tasks_list.SelectedIndex);
            } 
            else
            {
                MessageBox.Show("You must select a valid task!",
                    "Invalid Input",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}