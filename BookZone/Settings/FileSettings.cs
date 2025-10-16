namespace BookZone.Settings
{
    public static class FileSettings
    {
        public const string ImagesPath = "/assets/images";
        public const string AllowedExtentions = ".jpg,.jpeg,.png";
        public const int MaxSizeinMB = 1;
        public const int MaxSizeinB = MaxSizeinMB*1024*1024;
    }
}
