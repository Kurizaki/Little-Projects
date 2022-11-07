namespace Passwordmanager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool entscheidung = true;
            int ausgabeprofil = 0;
            bool kontrolle = true;
            bool doppelkontrolle = true;
            bool endkontrolle = true;
            string ausgabe = "";
            string ausgabewiederholung = "";
            List<string> Passwort = new();
            List<string> Profil = new();
            List<string> Email = new();
            string[] inPath = System.IO.File.ReadAllLines(@"C:\Users\Startklar\Documents\PassowrdManager.txt");
            for (int i = 0; i < inPath.Length; i++)
            {
                string[] rowData = inPath[i].Split(',');

                Profil.Add(rowData[0]);
                Email.Add(rowData[1]);
                Passwort.Add(rowData[2]);
            }
            do
            {
                Console.Clear();
                Console.WriteLine("Willkommen zum Passwortmanager");
                do
                {
                    Console.WriteLine("Wollen sie Profile hinzufügen oder nicht?[y|n]");
                    ausgabe = Convert.ToString(Console.ReadLine());
                    switch (ausgabe)
                    {
                        case "y":
                            entscheidung = true;
                            kontrolle = true;
                            break;

                        case "n":
                            entscheidung = false;
                            kontrolle = true;
                            break;

                        default:
                            Console.WriteLine("Ungültige Eingabe");
                            kontrolle = false;
                            Console.Clear();
                            break;
                    }
                } while (kontrolle == false);
                if (entscheidung == true)
                {
                    do
                    {
                        Console.WriteLine("Bitte geben sie ein wie sie das Profil nennen wollen.");
                        Profil.Add(Convert.ToString(Console.ReadLine()));
                        Console.WriteLine("Was ist ihre Email für das Profil?");
                        Email.Add(Convert.ToString(Console.ReadLine()));
                        Console.WriteLine("Geben sie bitte das Passwort für Profil ein: ");
                        Passwort.Add(Convert.ToString(Console.ReadLine()));

                        do
                        {
                            Console.WriteLine("Wollen sie ein weiteres Profil anlegen? [y|n]");
                            string wiederholung = Convert.ToString(Console.ReadLine());
                            switch (wiederholung)
                            {
                                case "y":
                                    kontrolle = true;
                                    doppelkontrolle = true;
                                    break;

                                case "n":
                                    kontrolle = true;
                                    doppelkontrolle = false;
                                    entscheidung = false;
                                    break;

                                default:
                                    Console.WriteLine("Ungültige Eingabe");
                                    kontrolle = false;
                                    Console.Clear();
                                    break;
                            }
                        } while (kontrolle == false);
                    } while (doppelkontrolle == true);
                }
                if (entscheidung == false)
                {
                    do
                    {
                        Console.WriteLine("Wollen sie ein Profil ausgeben?[y|n]");
                        ausgabe = Convert.ToString(Console.ReadLine());
                        switch (ausgabe)
                        {
                            case "y":
                                do
                                {
                                    do
                                    {
                                        try
                                        {
                                            Console.Clear();
                                            kontrolle = true;
                                            Console.WriteLine("Welches Profil wollen sie ausgeben");
                                            Profil.ForEach(Console.WriteLine);
                                            ausgabeprofil = Convert.ToInt32(Console.ReadLine());
                                            if (ausgabeprofil > Profil.Count || ausgabeprofil < 1)
                                            {
                                                Console.WriteLine("Ungültige Eingabe");
                                                kontrolle = false;
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                kontrolle = true;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Ungültige Eingabe");
                                            kontrolle = false;
                                        }
                                    } while (kontrolle == false);
                                    ausgabeprofil--;
                                    Console.WriteLine(Profil[ausgabeprofil]);
                                    Console.WriteLine(Email[ausgabeprofil]);
                                    Console.WriteLine(Passwort[ausgabeprofil]);
                                    do
                                    {
                                        kontrolle = true;
                                        Console.WriteLine("Wollen sie ein weiteres Profil ausgeben? [y|n]");
                                        ausgabewiederholung = Convert.ToString(Console.ReadLine());
                                        switch (ausgabewiederholung)
                                        {
                                            case "y":
                                                kontrolle = true;
                                                entscheidung = false;
                                                break;

                                            case "n":
                                                kontrolle = true;
                                                entscheidung = true;
                                                break;

                                            default:
                                                kontrolle = false;
                                                Console.WriteLine("Ungültige Eingabe");
                                                Console.Clear();
                                                break;
                                        }
                                    } while (kontrolle == false);
                                } while (entscheidung == false);
                                break;

                            case "n":
                                kontrolle = true;
                                break;

                            default:
                                Console.WriteLine("Ungültige Eingabe");
                                kontrolle = false;
                                break;
                        }
                    } while (kontrolle == false);
                    do
                    {
                        Console.WriteLine("Wollen sie ein Profil Löschen?[y|n]");
                        ausgabe = Convert.ToString(Console.ReadLine());
                        switch (ausgabe)
                        {
                            case "y":
                                kontrolle = true;
                                do
                                {
                                    try
                                    {
                                        kontrolle = true;
                                        Console.WriteLine("Welches Profil wollen sie Löschen");
                                        Profil.ForEach(Console.WriteLine);
                                        ausgabeprofil = Convert.ToInt32(Console.ReadLine());
                                        if (ausgabeprofil > Profil.Count || ausgabeprofil < 1)
                                        {
                                            Console.WriteLine("Ungültige Eingabe");
                                            kontrolle = false;
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            kontrolle = true;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ungültige Eingabe");
                                        kontrolle = false;
                                    }
                                } while (kontrolle == false);
                                ausgabeprofil--;
                                Profil.RemoveAt(ausgabeprofil);
                                Email.RemoveAt(ausgabeprofil);
                                Passwort.RemoveAt(ausgabeprofil);
                                break;

                            case "n":
                                kontrolle = true;
                                break;

                            default:
                                Console.WriteLine("Ungültige Eingabe");
                                kontrolle = false;
                                break;
                        }
                    } while (kontrolle == false);

                    do
                    {
                        Console.WriteLine("Wollen sie das Programm beenden? [y|n]");
                        string wiederholung = Convert.ToString(Console.ReadLine());
                        switch (wiederholung)
                        {
                            case "y":
                                doppelkontrolle = false;
                                endkontrolle = false;
                                break;

                            case "n":
                                doppelkontrolle = true;
                                endkontrolle = false;
                                break;

                            default:
                                Console.WriteLine("Ungültige Eingabe");
                                endkontrolle = true;
                                Console.Clear();
                                break;
                        };
                    } while (endkontrolle == true);
                }
            } while (doppelkontrolle == true);
            string outText = "";
            for (int i = 0; i < Profil.Count; i++)
            {
                outText += $"{Profil[i]},{Email[i]},{Passwort[i]}\r\n";
            }
            string outPath = @"C:\Users\Startklar\Documents\PassowrdManager.txt";
            File.WriteAllText(outPath, outText);
        }
    }
}