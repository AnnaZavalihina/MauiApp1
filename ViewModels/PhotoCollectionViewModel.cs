using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class PhotoCollectionViewModel : ViewModelBase
    {
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

        public ICommand AddExistingPhoto { get; }
        public ICommand AddNewPhoto { get; }

        public PhotoCollectionViewModel() 
        {
            AddExistingPhoto = new Command(async () => await PickPhotoAsync());
            AddNewPhoto = new Command(async () => await TakePhotoAsync());
        }

        private async Task TakePhotoAsync()
        {
            try
            {
                var status = await Permissions.RequestAsync<Permissions.Camera>();

                if (status == PermissionStatus.Granted)
                {
                    var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                    {
                        Title = "Сделайте фото"
                    });

                    if (photo != null)
                    {
                        var stream = await photo.OpenReadAsync();
                        Photos.Add(new Photo
                        {
                            Title = Path.GetFileName(photo.FullPath),
                            ImageUrl = photo.FullPath
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка съемки фото: {ex.Message}");
            }
        }

        private async Task PickPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Выберите фото"
                });

                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    Photos.Add(new Photo
                    {
                        Title = Path.GetFileName(photo.FullPath),
                        ImageUrl = photo.FullPath 
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выбора фото: {ex.Message}");
            }
        }
    }
}
