using AccessControlProject.Interfaces.Services;
using AccessControlProject.WPF.Infrastructure.DialogService;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Input;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels
{
    public class FileDecryptionWindowViewModel : ViewModel
    {
        private readonly string _filePath;
        private readonly string _filePathTmp;
        private readonly IEncryptionService _encryptionService;
        private readonly IDialogService _dialogService;

        public FileDecryptionWindowViewModel(IEncryptionService encryptionService, IDialogService dialogService, IConfiguration configuration)
        {
            _encryptionService = encryptionService;
            _dialogService = dialogService;
            _filePath = configuration["Persons:FilePath"];
            _filePathTmp = configuration["Persons:FilePathTmp"];
        }

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _title = "Расшифровка файла";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title!, value);
        }

        #endregion

        #region Caption : string - Описание вводимых данных

        /// <summary>Описание вводимых данных</summary>
        private string _caption = "Введите ключ для расшифровки:";

        /// <summary>Описание вводимых данных</summary>
        public string Caption
        {
            get => _caption;
            set => Set(ref _caption!, value);
        }

        #endregion

        #region Key : string - Ключ расшифровки файла

        /// <summary>Ключ расшифровки файла</summary>
        private string _key = string.Empty;

        /// <summary>Ключ расшифровки файла</summary>
        public string Key
        {
            get => _key;
            set => Set(ref _key!, value);
        }

        #endregion

        #region Command DecryptCommand - Команда расшифровки файла

        /// <summary>Команда расшифровки файла</summary>
        private ICommand? _decryptCommand;

        /// <summary>Команда расшифровки файла</summary>
        public ICommand DecryptCommand => _decryptCommand
            ??= new LambdaCommand(OnDecryptCommandExecuted, CanDecryptCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда расшифровки файла</summary>
        private bool CanDecryptCommandExecute() => Key.IsNotNullOrEmpty();

        /// <summary>Логика выполнения - Команда расшифровки файла</summary>
        private void OnDecryptCommandExecuted()
        {
            // Логика расшифровки файла
            // Тестовый код
            //_encryptionService.DecryptFile("test_out.txt", "road_map_out.txt", "qwerty12");
            //_encryptionService.EncryptFile(@"road_map.txt", "test_out.txt", "qwerty12");
            _encryptionService.EncryptFile(_filePath, _filePathTmp, "qwerty12");
            //_encryptionService.EncryptFile("qwerty12");
        }

        #endregion
    }
}