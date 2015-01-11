using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace WorshipSong.UI.Behaviors
{
    public class TextBoxFontSizeBehavior : Behavior<TextBlock>
    {
        public double MaxTextBlockFontSize
        {
            get { return (double)GetValue(MaxTextBlockFontSizeProperty); }
            set { SetValue(MaxTextBlockFontSizeProperty, value); }
        }

        public static readonly DependencyProperty MaxTextBlockFontSizeProperty =
            DependencyProperty.Register("MaxTextBlockFontSize", typeof(double), typeof(TextBoxFontSizeBehavior), new PropertyMetadata(32.0));

        public FrameworkElement Parent
        {
            get { return AssociatedObject.Parent as FrameworkElement; }
        }

        protected override void OnAttached()
        {
            base.OnAttached();           
            if (Parent != null)
                this.Parent.SizeChanged += Parent_SizeChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
         
            if (Parent != null)
                Parent.SizeChanged -= Parent_SizeChanged;

        }

        private void Parent_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            if (Parent == null)
                return;

            if (Parent.ActualHeight < AssociatedObject.ActualHeight && AssociatedObject.FontSize > 1)
            {
                AssociatedObject.FontSize -= 1;
                //PrintSizeToOutput();
            }

            if ((e.PreviousSize.Height < e.NewSize.Height
                || e.PreviousSize.Width < e.NewSize.Width)
                && AssociatedObject.FontSize < MaxTextBlockFontSize)
            {
                AssociatedObject.FontSize += 1;
                AssociatedObject.UpdateLayout();
                if (Parent.ActualHeight < AssociatedObject.ActualHeight)
                    AssociatedObject.FontSize -= 1;
            }
        }



        private void PrintSizeToOutput()
        {
            Console.WriteLine("Window_SizeChanged:\tAssociatedObject \t{0} x \t{1} \t TextBlock \t{2} x \t{3}", Parent.ActualWidth, Parent.ActualHeight, AssociatedObject.ActualHeight, AssociatedObject.ActualWidth);
        }
    }
}
