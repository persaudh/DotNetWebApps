namespace AspDotNetCoreMVC.Services
{
    public class LocalizedText : ILocalizedText
    {
        public string GetPageTitle(string language)
        {
            switch (language)
            {
                case "en":
                    return "Welcome to our website";
                case "de":
                    return "Willkommen auf unserer Website";
            }

            throw new NotSupportedException($"Language '{language}' is not supported.");
            //return language switch
            //{
            //    "en" => "Welcome to our website",
            //    "fr" => "Bienvenue sur notre site Web",
            //    "es" => "Bienvenido a nuestro sitio web",
            //    _ => "Welcome to our website"
            //};
        }
    }
}
