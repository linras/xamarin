using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MyApp.Validators
{
    public class DescriptionBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var name = textChangedEventArgs.NewTextValue;
            var nameEntry = sender as Entry;

            if (Regex.IsMatch(name, "^.{1,100}$"))
            {
                nameEntry.TextColor = Color.Black;
            }
            else
            {
                nameEntry.TextColor = Color.Red;
            }
        }
    }
}
