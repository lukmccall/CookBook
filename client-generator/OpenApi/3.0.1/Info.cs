namespace client_generator.OpenApi._3._0._1
{
    public class Info
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public Contact Contact { get; set; }
        public License License { get; set; }
        public string Version { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Title)}: {Title}, {nameof(Description)}: {Description}, {nameof(TermsOfService)}: {TermsOfService}, {nameof(Contact)}: {Contact}, {nameof(License)}: {License}, {nameof(Version)}: {Version}";
        }
    }
}