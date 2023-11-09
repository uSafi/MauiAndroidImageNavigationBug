using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiAndroidImageNavigationBug.ViewModels;

public partial class ViewModel : ObservableObject
{
    private readonly string defaultImage = "default_image.png";

    [ObservableProperty]
    private string _imagePath;
    [ObservableProperty]
    ImageSource myImageSource;
    [ObservableProperty]
    private bool _canDeleteImage;

    public ViewModel()
    {
        ImagePath = defaultImage;
    }

    [RelayCommand]
    public async Task ImageTapped()
    {
        var mediaFile = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select a photo"
        });

        if (mediaFile != null)
        {
            try
            {
                //var stream = await mediaFile.OpenReadAsync();
                //FormalLetterImageSource = ImageSource.FromStream(() => stream);
                //ImagePath = mediaFile.FullPath; // This is the path you can store in the database

                //var stream = await mediaFile.OpenReadAsync();
                //MyImageSource = ImageSource.FromStream(() => stream);

                //MyImageSource = ImageSource.FromFile(mediaFile.FullPath);
                ImagePath = new FileImageSource { File = mediaFile.FullPath };
            }
            catch (Exception)
            {
                // nothing to throw, it's a bad image format on mobile.
            }
        }
        if (ImagePath != defaultImage)
        {
            CanDeleteImage = true;
        }
    }

    [RelayCommand]
    public void DeleteImage()
    {
        ImagePath = defaultImage;
        CanDeleteImage = false;
    }

}
