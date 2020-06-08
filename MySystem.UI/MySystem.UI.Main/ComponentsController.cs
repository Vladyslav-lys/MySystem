using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using MySystem.UI.Contract;
using MySystem.UI.View;
using MySystem.Service.Domain;
using MySystem.Client.Contract;

namespace MySystem.UI.Main
{
    public class ComponentsController : IComponentsController
    {
        private MainWindow mainWindow;
        private IViewFactory viewCreator;

        public ComponentsController()
        {
            this.mainWindow = new MainWindow();
        }

        //Установка визуальных компонентов
        public void SetView(IViewFactory viewCreator)
        {
            this.viewCreator = viewCreator;
        }

        //Устанавливает свойства главного окна
        public void LoadLogin()
        {
            mainWindow.WindowState = WindowState.Normal;
            this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.mainWindow.Show();

            this.SetElement(mainWindow, (UIElement)viewCreator.CreateLoginPageView());
        }

        //Устанавливает свойства окна после вхождения пользователя
        public void LoadMain(UserDTO userDTO, IMainClient mainClient)
        {
            this.mainWindow.Dispatcher.Invoke(() =>
            {
                this.mainWindow.WindowState = WindowState.Normal;
                this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            });

            this.SetElement(mainWindow, (UIElement)viewCreator.CreateMainPageView(userDTO, mainClient));
        }

        public void LoadData(int id, UserDTO userDTO, AccountDTO accountDTO, IMainClient mainClient)
        {
            this.mainWindow.Dispatcher.Invoke(() =>
            {
                this.mainWindow.WindowState = WindowState.Normal;
                this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            });

            this.SetElement(mainWindow, (UIElement)viewCreator.CreateDataPageView(id, userDTO, accountDTO, mainClient));
        }

        //Устанавливает элемент в регионе окна
        public void SetElement(UIElement container, UIElement element)
        {
            ContentControl contentContainer = container as ContentControl;
            ContentControl contentElement = element as ContentControl;
            
            object curRegion = contentContainer.FindName("MainRegion");

            if (curRegion.GetType() == typeof(Grid))
            {
                ((Grid)curRegion).Children.Clear();
                if (contentElement != null)
                {
                    ((Grid)curRegion).Children.Add(contentElement);
                }
                return;
            }

            ContentControl regionControl = curRegion as ContentControl;
            if (contentElement != null && regionControl != null)
            {
                regionControl.Content = contentElement;
            }
        }
    }
}
