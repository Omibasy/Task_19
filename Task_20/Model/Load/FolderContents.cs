using System.IO;

namespace Task_20.Model.Load
{
    class FolderContents
    {
        public string FolderName { get; set; }

        public FolderContents(string folderName)
        {
            FolderName = folderName;

            СreateFolder();
        }

        public void СreateFolder()
        {
            if (!Directory.Exists(FolderName))
            {
                Directory.CreateDirectory(FolderName);
            }
        }

        public string[] GetFileAnimals()
        {
            return Directory.GetFiles(FolderName);
        }
    }
}
