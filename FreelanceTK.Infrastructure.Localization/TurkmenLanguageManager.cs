using FluentValidation.Resources;

namespace FreelanceTK.Infrastructure.Localization
{
    public class TurkmenLanguageManager : LanguageManager
    {
        public TurkmenLanguageManager()
        {
            AddTranslation("tk", "EmailValidator", "{PropertyName}' nädogry email salgy.");
            AddTranslation("tk", "GreaterThanOrEqualValidator",
                "{PropertyName}' '{ComparisonValue}-den' uly ýa-da deň bolmalydyr.");
            AddTranslation("tk", "GreaterThanValidator", "'{PropertyName}' '{ComparisonValue}'-den uly bolmalydyr.");
            AddTranslation("tk", "LengthValidator",
                "{PropertyName}' uzynlygy {MinLength}-den {MaxLength} çenli belgilere deň bolmalydyr. Siz {TotalLength} simwollary girizdiňiz.");
            AddTranslation("tk", "MinimumLengthValidator",
                "'{PropertyName}' {MinLength} simwollardan uly ýa-da deň bolmalydyr. Siz {TotalLength} simwollary girizdiňiz.");
            AddTranslation("tk", "MaximumLengthValidator",
                "'{PropertyName}' {MaxLength} simwollardan kiçi ýa-da deň bolmalydyr. Siz {TotalLength} simwollary girizdiňiz.");
            AddTranslation("tk", "LessThanOrEqualValidator",
                "'{PropertyName}' {ComparisonValue}' -den kiçi ýa-da oňa deň bolmalydyr.");
            AddTranslation("tk", "LessThanValidator", "'{PropertyName}' {ComparisonValue}' -den kiçi bolmalydyr.");
            AddTranslation("tk", "NotEmptyValidator", "'{PropertyName}' boş bolmaly däldir.");
            AddTranslation("tk", "NotEqualValidator", "{PropertyName}' '{ComparisonValue}'-e deň bolmaly däldir.");
            AddTranslation("tk", "NotNullValidator", "{PropertyName}' hökman boş bolmaly däldir.");
            AddTranslation("tk", "PredicateValidator", "Görkezilen şert '{PropertyName}' üçin ýerine ýetirilmedi.");
            AddTranslation("tk", "AsyncPredicateValidator",
                "Görkezilen şert '{PropertyName}' üçin ýerine ýetirilmedi.");
            AddTranslation("tk", "RegularExpressionValidator", "{PropertyName}' nädogry formata eýedir.");
            AddTranslation("tk", "EqualValidator", "{PropertyName}' '{ComparisonValue}'-e deň bolmalydyr.");
            AddTranslation("tk", "ExactLengthValidator",
                "{PropertyName}' uzynlygy {MaxLength} simwol bolmalydyr. Siz {TotalLength} simwol girizdiňiz.");
            AddTranslation("tk", "InclusiveBetweenValidator",
                "{PropertyName}' hökmany {From} -dan {To} çenli bolmalydyr. Siz {Value} girizdiňiz.");
            AddTranslation("tk", "ExclusiveBetweenValidator",
                "{PropertyName}' {From} -dan {To} çenli (öz içine almazdan) bolmalydyr. Siz {Value} girizdiňiz.");
            AddTranslation("tk", "CreditCardValidator", "'{PropertyName}' nädogry kart belgisi.");
            AddTranslation("tk", "ScalePrecisionValidator",
                "{PropertyName}' {ExpectedScale} onluk sanlar bilen jemi {ExpectedPrecision} sanlardan uly bolmaly däldir. {Digits} sanlar we {ActualScale} onluk belgiler anyklandy.");
            AddTranslation("tk", "EmptyValidator", "'{PropertyName}' boş bolmalydyr.");
            AddTranslation("tk", "NullValidator", "'{PropertyName}' hökmany boş bolmalydyr.");
            AddTranslation("tk", "EnumValidator",
                "{PropertyName}' '{PropertyValue}' şu ýerde bolmadyk bahalar çygryna eýedir.");

            // Additional fallback messages used by clientside validation integration.
            AddTranslation("tk", "Length_Simple",
                "{PropertyName}' uzynlygy {MinLength} -den {MaxLength} çenlli simwollara deň bolmalydyr.");
            AddTranslation("tk", "MinimumLength_Simple",
                "'{PropertyName}' {MinLength} simwollardan uly ýa-da olara deň bolmalydyr.");
            AddTranslation("tk", "MaximumLength_Simple",
                "'{PropertyName}' {MinLength} simwollardan kiçi ýa-da olara deň bolmalydyr.");
            AddTranslation("tk", "ExactLength_Simple", "{PropertyName}' uzynlygy {MaxLength} simwola deň bolmalydyr.");
            AddTranslation("tk", "InclusiveBetween_Simple",
                "{PropertyName}' hökmany {From} -dan {To} çenli bolmalydyr.");
        }
    }
}