using System.Text.RegularExpressions;

public static class Walidacja
{
    public const string TekstPL = @"^[A-Za-zĄąĆćĘęŁłŃńÓóŚśŻżŹź ]+$";
    public const string TekstPLBezSpacji = @"^[A-Za-zĄąĆćĘęŁłŃńÓóŚśŻżŹź]+$";
    public const string Telefon = @"^[0-9]{9}$";

    public static bool PoprawnaNazwa(string nazwa) => Regex.IsMatch(nazwa, TekstPLBezSpacji);

    public static bool PoprawnyTelefon(string tel) => Regex.IsMatch(tel, Telefon);

    public static bool PoprawnyTekst(string tekst) => Regex.IsMatch(tekst, TekstPL);
}