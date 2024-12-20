using MauiApp1.Data;
using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class PhotoCollectionViewModel : ViewModelBase
    {
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

        private readonly DbService _databaseService;

        public ICommand AddExistingPhoto { get; }
        public ICommand AddNewPhoto { get; }
        public ICommand LoadPhotosCommand { get; }

        public PhotoCollectionViewModel(DbService databaseService) 
        {
            _databaseService = databaseService;

            AddExistingPhoto = new Command(async () => await PickPhotoAsync());
            AddNewPhoto = new Command(async () => await TakePhotoAsync());
            LoadPhotosCommand = new Command(async () => await LoadPhotosAsync());

            _ = LoadPhotosAsync();
        }

        private async Task LoadPhotosAsync()
        {
            try
            {
                Photos.Clear();

                var photos = await _databaseService.GetImagesAsync();
                foreach (var photo in photos)
                {
                    Photos.Add(photo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки фото: {ex.Message}");
            }
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
                        var fileName = Path.GetFileName(photo.FullPath);
                        var photoModel = new Photo
                        {
                            Title = fileName,
                            ImageUrl = photo.FullPath
                        };

                        await _databaseService.AddImageAsync(photoModel);

                        Photos.Add(photoModel);
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
                    var fileName = Path.GetFileName(photo.FullPath);
                    var photoModel = new Photo
                    {
                        Title = fileName,
                        ImageUrl = photo.FullPath
                    };

                    await _databaseService.AddImageAsync(photoModel);

                    Photos.Add(photoModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выбора фото: {ex.Message}");
            }
        }
    }
}
