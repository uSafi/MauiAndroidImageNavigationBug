# MauiAndroidImageNavigationBug

This repository contains a .NET MAUI project that reproduces an issue where an `Image` control loses its image when navigating away from the page and then back again on Android. The `Image` control's `Source` property still holds the image source (i.e., it's not null), but the `Image` control appears empty, and its size reverts to its initial state.

## Steps to Reproduce

1. Clone this repository.
2. Open the solution in Visual Studio.
3. Run the project on an Android emulator or device.
4. Follow the instructions on the app to reproduce the issue.

## Workaround

After reproducing the issue, you can test the workaround by uncommenting the following lines in the `OnAppearing` method of the `Page1.xaml.cs` file:

```csharp
AgentImage.BindingContext = null;
AgentImage.BindingContext = imageBinding;
```

Then, run the project again and follow the same steps. The image should now persist when navigating away from the page and then back again.

---
