using System.Xml.Linq;

namespace MauiAndroidImageNavigationBug.Views;

public partial class Page1 : ContentPage
{
    object imageBinding;

    //object _viewModel;
    public Page1()
	{
		InitializeComponent();



        // Save the binding.
        //_viewModel = BindingContext;

        imageBinding = AgentImage.BindingContext;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Uncomment those two lines

        //AgentImage.BindingContext = null;
        //AgentImage.BindingContext = imageBinding;

        // ---------------------------------

        // Or those, and don't forget to uncomment the related types up there.
        //BindingContext = null;
        //BindingContext = _viewModel;
    }

}