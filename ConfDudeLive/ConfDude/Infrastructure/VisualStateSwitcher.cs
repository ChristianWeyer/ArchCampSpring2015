using System.Windows;

namespace ConfDude.Infrastructure
{
    public class VisualStateSwitcher
    {
        public static string GetState(UIElement element)
        {
            return element.GetValue(StateProperty) as string;
        }

        public static void SetState(UIElement element, string value)
        {
            element.SetValue(StateProperty, value);
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.RegisterAttached("State", typeof(string), typeof(VisualStateSwitcher),
            new PropertyMetadata("", OnStatePropertyChanged));

        private static void OnStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            var state = e.NewValue as string;
            if (element != null && state != null)
            {
                VisualStateManager.GoToElementState(element, state, false);
            }
        }
    }
}
