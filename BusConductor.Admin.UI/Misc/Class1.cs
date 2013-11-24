using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ListViewItemValidation
{
    public class ListViewItemExtensions
    {
        #region ChildrenHaveError Property

        public bool ChildrenHaveError
        {
            get { return (bool)this.ListViewItem.GetValue(ChildrenHaveErrorProperty); }
            set { this.ListViewItem.SetValue(ChildrenHaveErrorProperty, value); }
        }

        public static bool GetChildrenHaveError(ListViewItem obj)
        {
            return EnsureInstance(obj).ChildrenHaveError;
        }

        public static void SetChildrenHaveError(ListViewItem obj, bool value)
        {
            EnsureInstance(obj).ChildrenHaveError = value;
        }

        public static readonly DependencyProperty ChildrenHaveErrorProperty =
            DependencyProperty.RegisterAttached(
                "ChildrenHaveError",
                typeof(bool),
                typeof(ListViewItemExtensions),
                new PropertyMetadata(
                    new PropertyChangedCallback((o, a) => { EnsureInstance((ListViewItem)o); })
                )
        );
        #endregion

        #region ValidatesChildren Property
        public bool ValidatesChildren
        {
            get { return (bool)this.ListViewItem.GetValue(ValidatesChildrenProperty); }
            set { this.ListViewItem.SetValue(ValidatesChildrenProperty, value); }
        }

        public static bool GetValidatesChildren(ListViewItem obj)
        {
            return EnsureInstance(obj).ValidatesChildren;
        }

        public static void SetValidatesChildren(ListViewItem obj, bool value)
        {
            EnsureInstance(obj).ValidatesChildren = value;
        }

        public static readonly DependencyProperty ValidatesChildrenProperty =
            DependencyProperty.RegisterAttached(
                "ValidatesChildren",
                typeof(bool),
                typeof(ListViewItemExtensions),
                new PropertyMetadata(
                    new PropertyChangedCallback((o, a) => { EnsureInstance((ListViewItem)o); })
                )
           );
        #endregion

        #region Instance Property
        public static ListViewItemExtensions GetInstance(ListViewItem obj)
        {
            return (ListViewItemExtensions)obj.GetValue(InstanceProperty);
        }

        public static void SetInstance(ListViewItem obj, ListViewItemExtensions value)
        {
            obj.SetValue(InstanceProperty, value);
        }

        public static readonly DependencyProperty InstanceProperty =
            DependencyProperty.RegisterAttached("Instance", typeof(ListViewItemExtensions), typeof(ListViewItemExtensions));
        #endregion

        #region ListViewItem Property
        public ListViewItem ListViewItem { get; private set; }
        #endregion

        static ListViewItemExtensions EnsureInstance(ListViewItem item)
        {
            var i = GetInstance(item);
            if (i == null)
            {
                i = new ListViewItemExtensions(item);
                SetInstance(item, i);
            }
            return i;
        }

        ListViewItemExtensions(ListViewItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            this.ListViewItem = item;
            item.Loaded += (o, a) =>
            {
                this.FindBindingExpressions(item);
                this.ChildrenHaveError = ComputeHasError(item);
            };
        }

        static bool ComputeHasError(DependencyObject obj)
        {
            var e = obj.GetLocalValueEnumerator();

            while (e.MoveNext())
            {
                var entry = e.Current;

                if (!BindingOperations.IsDataBound(obj, entry.Property))
                    continue;

                var binding = BindingOperations.GetBinding(obj, entry.Property);
                foreach (var rule in binding.ValidationRules)
                {
                    ValidationResult result = rule.Validate(obj.GetValue(entry.Property), null);
                    if (!result.IsValid)
                    {
                        BindingExpression expression = BindingOperations.GetBindingExpression(obj, entry.Property);
                        Validation.MarkInvalid(expression, new ValidationError(rule, expression, result.ErrorContent, null));
                        return true;
                    }
                }
            }

            for (int i = 0, count = VisualTreeHelper.GetChildrenCount(obj); i < count; ++i)
                if (ComputeHasError(VisualTreeHelper.GetChild(obj, i)))
                    return true;

            return false;
        }

        void OnDataTransfer(object sender, DataTransferEventArgs args)
        {
            this.ChildrenHaveError = ComputeHasError(this.ListViewItem);
        }

        void FindBindingExpressions(DependencyObject obj)
        {
            var e = obj.GetLocalValueEnumerator();

            while (e.MoveNext())
            {
                var entry = e.Current;
                if (!BindingOperations.IsDataBound(obj, entry.Property))
                    continue;

                Binding binding = BindingOperations.GetBinding(obj, entry.Property);
                if (binding.ValidationRules.Count > 0)
                {
                    Binding.AddSourceUpdatedHandler(obj, new EventHandler<DataTransferEventArgs>(this.OnDataTransfer));
                    Binding.AddTargetUpdatedHandler(obj, new EventHandler<DataTransferEventArgs>(this.OnDataTransfer));
                }
            }

            for (int i = 0, count = VisualTreeHelper.GetChildrenCount(obj); i < count; ++i)
            {
                var child = VisualTreeHelper.GetChild(obj, i);
                this.FindBindingExpressions(child);
            }
        }

    }
}