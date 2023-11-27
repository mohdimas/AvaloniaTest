using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;

namespace AvaloniaTest;

public class CustomItemsControl : ItemsControl
{
    public static readonly StyledProperty<bool> AddToLogicalChildrenProperty =
        AvaloniaProperty.Register<CustomItemsControl, bool>(nameof(AddToLogicalChildren));

    public bool AddToLogicalChildren
    {
        get => GetValue(AddToLogicalChildrenProperty);
        set => SetValue(AddToLogicalChildrenProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        var presenter = e.NameScope.Find<ItemsPresenter>(name: "ItemsPresenter");
        presenter.ApplyTemplate();

        var panel = presenter.Panel;
        var textBox = new TextBox();

        if (AddToLogicalChildren)
            LogicalChildren.Add(textBox);

        panel.Children.Add(textBox);
    }
}
