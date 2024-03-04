namespace purchasing_coffee.Helper
{
    public class DocumentConf
    {
        public static string DocumentUpload(IFormFile file,string folderName)
        {
            if(file==null || file.Length ==0 || string.IsNullOrEmpty(folderName))
            {
                return null;
            }

            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(folderpath, fileName);

            using (var fs=new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return fileName;
        }

        public static void DocumentDelete(string fileName,string folderName)
        {
            if (fileName is not null && !string.IsNullOrEmpty(folderName))
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, fileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

            }

        }
    }
}
