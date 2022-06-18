
namespace Task_20.Model.Save
{
    static class FormatDefinition
    {
        public static ISaveAnimal GetSaveAnimal(string nameFile, string formatFile)
        {            
            switch (formatFile)
            {
                case "html":
                    return new KeeperHtml(nameFile);

                case "json":
                    return new KeeperJson(nameFile);

                case "txt":
                    return new KeeperTxt(nameFile);

                default: return new KeeperTxt(nameFile);
            }
        }
    }
}
